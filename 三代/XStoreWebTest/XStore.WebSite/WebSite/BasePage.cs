using Chloe.MySql;
using log4net;
using Newtonsoft.Json;
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
        protected override void OnInit(EventArgs e)
        {
            var InitOpenid = OpenId;
            base.OnInit(e);
        }
        private string _openid;
        protected string OpenId
        {
            get
            {
                if (debug)
                {
                    //_openid = "ooZJm0e-HAspMBhNrw0bUGXD-k6M";//袁
                    //_openid = "ooZJm0d_Cimev2TQHdCJGq4LOlHU";//储
                    _openid = "ooZJm0Z0wg3kmeht0e4u40pgKuq4";//小号
                }
                LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "openid：");
                if (_openid == null || string.IsNullOrEmpty(_openid))
                {
                    if (Session[Constant.OpenId] == null || string.IsNullOrEmpty(Session[Constant.OpenId].ObjToStr()))
                    {
                        _openid = RedrectWeiXin();
                    }
                    else
                    {
                        _openid = Session[Constant.OpenId].ObjToStr();
                    }
                }
                else
                {
                    Session[Constant.OpenId] = _openid;
                }
                return _openid;
            }
        }
        

        protected string RedrectWeiXin()
        {
            try
            {
                LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "重新获取openid：");
                string root = HttpContext.Current.Request.Url.Host;
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                string query = HttpContext.Current.Request.Url.Query;
                string RedirectUri = "http://" + root + url + query;
                WeiXinOath wxOath = new WeiXinOath();
                WxUserInfo wxUserInfo = new WxUserInfo();
                if (Session == null || string.IsNullOrEmpty(Session[Constant.OpenId].ObjToStr()))
                {
                    LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "OpenId不存在：");
                    var code = Request.QueryString[Constant.WxCode];
                    LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "code："+ code);
                    #region 根据code获取openid
                    if (code != null && !string.IsNullOrEmpty(code))
                    {
                        OauthToken oathToken = new OauthToken();
                        oathToken = wxOath.GetOauthToken(code);//获取用户openid
                        Session[Constant.OpenId] = oathToken.openid;
                        LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "openid：" + oathToken.openid);
                        #region 存入用户信息
                        wxUserInfo = wxOath.GetWebUserInfo(access_token(), oathToken.openid);
                        LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +"存入用户信息："+ JsonConvert.SerializeObject(wxUserInfo));
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
                LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "数据异常：" + ex.InnerException.Message);
                MessageBox.Show(this, "system_alert", "数据异常:" + ex.Message + ":" + ex.StackTrace);
                return string.Empty;
            }

        }
        public string access_token()
        {
            var accessToken = context.Query<AccessToken>().ToList().Where(o=>DateTime.Compare(o.createtime.AddMinutes(110),DateTime.Now)>0).ToList();
            //如果加了两个小时还是小于当前时间，说明token过期，需要重新获取
            if (accessToken.Count==0)
            {
                var wxOath = new WeiXinOath();
                var access_token = wxOath.GetAccessToken();
                LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "access_token：" + access_token);
                context.Insert(new AccessToken
                {
                    access_token = access_token,
                    createtime = DateTime.Now
                });
                return access_token;
            }
            else
            {
                return accessToken.First().access_token;
            }
        }

        public string GetProductImg(int productId,string image) {
            return "/Source/product/" + productId + "/" + image;

        }
        public string GetProductHtml( string html)
        {
            return "/Source/html/"+ html + ".html";

        }

    }
}