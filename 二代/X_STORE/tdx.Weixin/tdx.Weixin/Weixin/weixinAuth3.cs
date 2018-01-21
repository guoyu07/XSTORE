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
    public class weixinAuth3 : System.Web.UI.Page
    {
        public string _DefTheme = "";
        public string _DefWID = "";
        public string _DefNiChen = "";
        public string _DefGuID = "";
        public string _index = "";
        public string _list = "";
        public string _detail = "";
        public string _kuaijie = "";
        public weixinAuth3()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            Page.Title = "test";
            Session["boxmac"] = Request["box_mac"].ObjToStr(); ;
            weixin _wx = new tdx.Weixin.weixin();
            if (Request["WHC"] != null)
            {
                Session["openid"] = "ofGbbwsKQZ7jPygGHaQOgaWRRiTM";
            }
            if (Session["openid"] == null)
            {
                //授权获取用户信息

                if (Request["code"] != null)
                {
                    tdx.Weixin.weixin weixin = new weixin();
                    OAuth_Token web_Oatuth = weixin.Get_WebOauthToken(Request["code"].ToString()); //获取用户openid         
                    Session["OpenId"] = web_Oatuth.openid;

                    string RedirectUri = Request.Url.ToString();

                    //只获取OpenID
                    string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                    Response.Redirect("http://x.x-store.com.cn/Shop/Pages/enter.html");

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
                Response.Redirect("http://x.x-store.com.cn/Shop/Pages/enter.html");
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