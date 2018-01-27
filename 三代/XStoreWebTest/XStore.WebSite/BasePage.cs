using Chloe.MySql;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using XStore.Common;
using XStore.Common.WeiXinPay;
using XStore.Entity;
using XStore.WebSite.DBFactory;

namespace XStore.WebSite
{
    public class BasePage:System.Web.UI.Page
    {
        
        public static string connString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        protected bool debug = bool.Parse(ConfigurationManager.AppSettings["DEBUG"].ObjToStr());
        public MySqlContext context ;
        public ILog Log;
        public BasePage() {
            context = new MySqlContext(new MySqlConnectionFactory(connString));
            Log = log4net.LogManager.GetLogger("Weixin.Logging");//获取一个日志记录器
            Log.Info(DateTime.Now.ToString() + ": login success");//写入一条新log
        }
        private string _openid;
        protected string OpenId
        {
            get
            {
                if (debug)
                {
                    return "o8eAHwM94iBA0GGYsh8tnJ1pmuM8";//袁益鹏
                }
                if (_openid == null || string.IsNullOrEmpty(_openid))
                {
                    if (Session[Constant.OpenId] == null || string.IsNullOrEmpty(Session[Constant.OpenId].ObjToStr()))
                    {
                        _openid = RedrectWeiXin();
                    }
                    else
                    {
                        _openid = Session["OpenId"].ObjToStr();
                    }
                }
                return _openid;
            }
        }


        protected string RedrectWeiXin()
        {
            try
            {
                string root = HttpContext.Current.Request.Url.Host;
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                string query = HttpContext.Current.Request.Url.Query;
                string RedirectUri = "http://" + root + url + query;
                WeiXinOath wxOath = new WeiXinOath();
                WxUserInfo wxUserInfo = new WxUserInfo();
                if (Session == null || string.IsNullOrEmpty(Session[Constant.OpenId].ObjToStr()))
                {
                    var code = Request.QueryString[Constant.WxCode];
                    #region 根据code获取openid
                    if (code != null && !string.IsNullOrEmpty(code))
                    {
                        OauthToken oathToken = new OauthToken();
                        oathToken = wxOath.GetOauthToken(code);//获取用户openid
                        Session[Constant.OpenId] = oathToken.openid;
                        #region 存入用户信息
                        wxUserInfo = wxOath.GetWebUserInfo(access_token(), oathToken.openid);
                        var wxUserDB = context.Query<UserWeiChat>().FirstOrDefault(o => o.openid.Equals(oathToken.openid));
                        if (wxUserDB == null)
                        {
                            context.Insert(new UserWeiChat
                            {
                                createtime = DateTime.Now,
                                headpic = wxUserInfo.headimgurl,
                                nickname = wxUserInfo.nickname,
                                openid = wxUserInfo.openid,
                                unionid = string.Empty
                            });
                        }
                        else
                        {
                            wxUserDB.headpic = wxUserInfo.headimgurl;
                            wxUserDB.nickname = wxUserInfo.nickname;
                            context.Update(wxUserDB);
                        }
                        #endregion
                        return oathToken.openid;
                    }
                    else
                    {
                        wxOath.GetCode(RedirectUri);
                        return string.Empty;
                    }
                    #endregion
                }
                {
                    return Session[Constant.OpenId].ObjToStr();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "system_alert", "数据异常");
                return string.Empty;
            }

        }
        public string access_token()
        {
            var accessToken = context.Query<AccessToken>().FirstOrDefault(o=>o.createtime.AddMinutes(110) > DateTime.Now);
            //如果加了两个小时还是小于当前时间，说明token过期，需要重新获取
            if (accessToken == null)
            {
                var wxOath = new WeiXinOath();
                var access_token = wxOath.GetAccessToken();
                context.Insert(new AccessToken
                {
                    access_token = access_token,
                    createtime = DateTime.Now
                });
                return access_token;
            }
            else
            {

                return accessToken.access_token;
            }
        }
       
    }
}