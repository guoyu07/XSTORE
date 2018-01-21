using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using Creatrue.kernel;
using tdx.database.Common_Pay.WeiXinPay;
using tdx.Weixin.Weixin;
namespace tdx.Weixin
{
    public class weixinAuth2 : System.Web.UI.Page
    {
        public string _DefTheme = "";
        public string _DefWID = "";
        public string _DefNiChen = "";
        public string _DefGuID = "";
        public string _index = "";
        public string _list = "";
        public string _detail = "";
        public string _kuaijie = "";

        public weixinAuth2()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            Page.Title = "幸事多私享空间";
            weixin _wx = new tdx.Weixin.weixin();

            if (Request["WHC"] != null)
            {
                Session["openid"] = "ofGbbwsKQZ7jPygGHaQOgaWRRiTM";
                //Session["WWV"] = Request["WWV"] != null ? Request["WWV"].ToString() : "";
            }
            if (Session["openid"] == null)
            {
                //授权获取用户信息
                if (Request["code"] != null)
                {
                    tdx.Weixin.weixin weixin = new weixin();
                    OAuth_Token web_Oatuth = weixin.Get_WebOauthToken(Request["code"].ToString()); //获取用户openid

                    weixinUser userinfo = _wx.GetWebUserInfo(web_Oatuth.access_token, web_Oatuth.openid);
                    if (userinfo != null)
                    {
                        string nickname = userinfo.Nickname;
                        string headpic = userinfo.Headimgurl;
                        string sql = "select * from wp_会员表 where openid='" + web_Oatuth.openid + "'";
                        DataTable dt = comfun.GetDataTableBySQL(sql);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            comfun.UpdateBySQL("update WP_会员表 set wx昵称='" + SQLSafe(nickname) + "',wx头像='" + headpic + "' where openid='" + web_Oatuth.openid + "'");
                            // comfun.UpdateBySQL("update WP_用户表 set 微信昵称='" + SQLSafe(nickname) + "',微信头像='" + headpic + "' where openid='" + web_Oatuth.openid + "'");
                            comfun.UpdateBySQL("update B2C_mem set M_name='" + SQLSafe(nickname) + "'  where openid='" + web_Oatuth.openid + "'");
                        }
                        else //将新用户加入用户表
                        {
                            //   comfun.InsertBySQL("insert into WP_用户表  (微信昵称,微信头像,openid) values('" + SQLSafe(nickname) + "','" + headpic + "','" + web_Oatuth.openid + "'");
                            comfun.InsertBySQL("insert into wp_会员表(openid,wx昵称,wx头像) values('" + web_Oatuth.openid + "','" +
                                             SQLSafe(nickname) + "','" + headpic + "')");

                            string _sql = "select count(id) from b2c_mem where parentID=0";
                            DataTable dts = comfun.GetDataTableBySQL(_sql);
                            string _M_no = "";
                            if (dts.Rows.Count > 0)
                            {
                                _M_no = (Convert.ToInt32(dts.Rows[0][0].ToString().Trim()) + 1).ToString().Trim();
                            }
                            else
                                _M_no = "0001";

                            while (_M_no.Length < 4)
                                _M_no = "0" + _M_no;

                            comfun.InsertBySQL(
                                "insert into B2C_mem(openid,M_name,M_truename,M_isactive,M_no) values('" + web_Oatuth.openid +
                                "','" + SQLSafe(nickname) + "','" + SQLSafe(nickname) + "',-2,'" + _M_no + "')");

                        }
                        Session["openid"] = web_Oatuth.openid;
                    }
                    else
                    {
                        string RedirectUri = Request.Url.ToString();
                        //只获取OpenID
                        string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                        Response.Redirect(URL);
                    }
                }
                else
                {
                    string RedirectUri = Request.Url.ToString();
                    string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                    Response.Redirect(URL);
                }
            }
            else
            {
                //Session["openid"] = "ofGbbwkFkaexaRXsjVGbWxDcKvNQ";
            }
        }


        private void GetDefData()
        {
            string _wxguid = Request["WWX"] != null ? Request["WWX"].ToString().Trim() : "";
            //根据现在的数据库情况修改2015-03-12
            string _sql = "select id,wx_nichen,(select t_theme from wx_theme where cid=1 and isactive = 1) as wxTheme,(select t_theme  from wx_theme where cid=2 and isactive = 1) as wxTheme2 ,(select t_theme  from wx_theme where cid=3 and isactive = 1) as wxTheme3,(select t_theme  from wx_theme where cid=4 and isactive = 1) as wxTheme4 from wx_config"; // where id in (select wid from wx_mp where wx_ID='" + _wxguid + "')
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                _DefWID = dr["id"].ToString().Trim();
                _DefNiChen = dr["wx_nichen"].ToString().Trim();
                _DefTheme = dr["wxTheme"].ToString().Trim();
                _DefGuID = _wxguid;
                //写入Session并写入Cookie //2015-03-12不再写入Cookies
                /////////////////修改增加皮肤的
                _index = dr["wxTheme"].ToString().Trim();
                _list = dr["wxTheme2"].ToString().Trim();
                _detail = dr["wxTheme3"].ToString().Trim();
                _kuaijie = dr["wxTheme4"].ToString().Trim();
                Session["theme"] = _index + "|" + _list + "|" + _detail + "|" + _kuaijie;
                ////////////////////////////////
                Session["tdxWeixin"] = _DefWID + "|" + _DefNiChen + "|" + _DefTheme + "|" + _DefGuID;
                Session["wID"] = _DefWID;
            }

            //}
        }
        public string PriceIsNull(string price)
        {
            if (DTcms.Common.Utils.StrToInt(price, 0) == 0)
            {
                return string.Empty;
            }
            else
            {
                return price;
            }
        }
        public static string SQLSafe(string Parameter)
        {
            Parameter = Parameter.Replace("'", "");
            Parameter = Parameter.Replace(">", ">");
            Parameter = Parameter.Replace("<", "<");
            Parameter = Parameter.Replace("\n", "<br>");
            Parameter = Parameter.Replace("\0", "·");
            return Parameter;
        }


    }
}
