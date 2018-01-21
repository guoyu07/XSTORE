using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

namespace tdx.kernel
{
    public class weixinAuth : System.Web.UI.Page
    {
        public string _DefTheme = "";
        public string _DefWID = "";
        public string _DefNiChen = "";
        public string _DefGuID = "";
        public string _index = "";
        public string _list = "";
        public string _detail = "";
        public string _kuaijie = "";
        public weixinAuth()
        {
        }
        protected override void OnInit(EventArgs e)
        {
            tdx.Weixin.weixin _wx = new tdx.Weixin.weixin();

            //授权获取用户信息
            if (Request["code"] != null)
            {
                tdx.Weixin.weixin weixin = new tdx.Weixin.weixin();
                string openid = weixin.GetOpenID(Request["code"].ToString());//获取用户openid

                Creatrue.kernel.weixinUser userinfo = weixin.GetInfo(openid, _wx.devlopID, _wx.devlogPsw);
                if (userinfo != null)
                {
                    string nickname = userinfo.Nickname;
                    string headpic = userinfo.Headimgurl;

                    string sql = "select * from wp_会员表 where openid='" + openid + "'";
                    DataTable dt = comfun.GetDataTableBySQL(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {

                    }
                    else//将新用户加入用户表
                    {
                        comfun.InsertBySQL("insert into wp_会员表(openid,wx昵称,wx头像) values('" + openid + "','" + nickname + "','" + headpic + "')");
                    }
                    Session["openid"] = openid;
                }
            }
            else
            {

                // 网页授权跳转页面

                ////string RedirectUri = "http://hongdou.creatrue.net/Shop/index.aspx";
                //string RedirectUri = Request.Url.ToString();

                ////只获取OpenID
                //string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                //Response.Redirect(URL);
            }


            //if (Request["WWX"] != null)
            //{
            //    _DefGuID = Request["WWX"].ToString().Trim(); //新的参数.需要进行判断是否一致
            //    if (Session["tdxWeixin"] != null && Session["theme"] != null)
            //    {
            //        string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
            //        string[] _tdxWeixinArry = _tdxWeixin.Split('|');
            //        if (_DefGuID != _tdxWeixinArry[3])
            //        {
            //            GetDefData();
            //        }
            //        else
            //        {
            //            _DefWID = _tdxWeixinArry[0];
            //            _DefNiChen = _tdxWeixinArry[1];
            //            _DefTheme = _tdxWeixinArry[2];
            //            _DefGuID = _tdxWeixinArry[3];
            //        }
            //    }
            //    else if (Request.Cookies["tdxWeixin"] != null && Request.Cookies["theme"] != null)
            //    {
            //        if (_DefGuID != (Request.Cookies["tdxWeixin"]["GuID"] != null ? Request.Cookies["tdxWeixin"]["GuID"].ToString().Trim() : ""))
            //        {
            //            GetDefData();
            //        }
            //        else
            //        {
            //            _DefWID = Request.Cookies["tdxWeixin"]["WID"];
            //            _DefNiChen = HttpUtility.UrlDecode(Request.Cookies["tdxWeixin"]["NiChen"]);
            //            _DefTheme = Request.Cookies["tdxWeixin"]["Theme"];
            //            _DefGuID = Request.Cookies["tdxWeixin"]["GuID"];
            //            _index = Request.Cookies["theme"]["index"];
            //            _list = Request.Cookies["theme"]["list"];
            //            _detail = Request.Cookies["theme"]["detail"];
            //            _kuaijie = Request.Cookies["theme"]["kuaijie"];
            //            //写入Session
            //            Session["wID"] = _DefWID;
            //            Session["tdxWeixin"] = _DefWID + "|" + _DefNiChen + "|" + _DefTheme + "|" + _DefGuID;
            //            Session["theme"] = _index + "|" + _list + "|" + _detail + "|" + _kuaijie ;

            //        }
            //    }
            //    else
            //    {
            //        GetDefData();
            //    }

            //}
            //else //如果没有传参进来
            //{
            //    if (Session["tdxWeixin"] != null)
            //    {
            //        string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
            //        string[] _tdxWeixinArry = _tdxWeixin.Split('|');
            //        _DefWID = _tdxWeixinArry[0];
            //        _DefNiChen = _tdxWeixinArry[1];
            //        _DefTheme = _tdxWeixinArry[2];
            //        _DefGuID = _tdxWeixinArry[3];

            //        Session["wID"] = _DefWID;
            //    }
            //    else if (Request.Cookies["tdxWeixin"] != null & Request.Cookies["theme"] != null)
            //    {
            //        _DefWID = Request.Cookies["tdxWeixin"]["WID"];
            //        _DefNiChen = HttpUtility.UrlDecode(Request.Cookies["tdxWeixin"]["NiChen"]);
            //        _DefTheme = Request.Cookies["tdxWeixin"]["Theme"];
            //        _DefGuID = Request.Cookies["tdxWeixin"]["GuID"];

            //        _index = Request.Cookies["theme"]["index"];
            //        _list = Request.Cookies["theme"]["list"];
            //        _detail = Request.Cookies["theme"]["detail"];
            //        _kuaijie = Request.Cookies["theme"]["kuaijie"];
            //        //写入Session
            //        Session["wID"] = _DefWID;
            //        Session["tdxWeixin"] = _DefWID + "|" + _DefNiChen + "|" + _DefTheme + "|" + _DefGuID;
            //        Session["theme"] = _index + "|" + _list + "|" + _detail + "|" + _kuaijie;
            //    }
            //    else
            //    {
            //        Response.Redirect("err.aspx?t=只支持微信浏览本站11111");
            //        return;
            //    }
            //}

            //if (Request["WWV"] != null)
            //{
            //    Session["WWV"] = Request["WWV"];
            //}
        }
        private void GetDefData()
        {
            string _wxguid = Request["WWX"].ToString().Trim();
            if (_wxguid.Length < 10)
            {
                Response.Redirect("err.aspx?t=无效的公众号");
                return;
            }
            else
            {
                //string _sql = "select id,wx_nichen,(select t_theme from wx_theme where wx_theme=id) as wxTheme,(select t_theme  from wx_theme where wx_theme2=id) as wxTheme2 ,(select t_theme  from wx_theme where wx_theme3=id) as wxTheme3,(select t_theme  from wx_theme where wx_theme4=id) as wxTheme4 from b2c_worker where id in (select id from wx_mp where wx_ID='" + _wxguid + "')";
                string _sql = "select id,wx_nichen,"+
			                  "(select t_theme from wx_theme where cid=1 and isActive = 1) as wxTheme,"+
			                  "(select t_theme  from wx_theme where cid=2 and isActive = 1) as wxTheme2,"+
                              "(select t_theme  from wx_theme where cid=3 and isActive = 1) as wxTheme3," +
			                  "(select t_theme  from wx_theme where cid=4 and isActive = 1) as wxTheme4 "+
                              "from wx_mp where wx_ID='" + _wxguid + "'";
                DataTable dt = comfun.GetDataTableBySQL(_sql);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    _DefWID = dr["id"].ToString().Trim();
                    _DefNiChen = dr["wx_nichen"].ToString().Trim();
                    _DefTheme = dr["wxTheme"].ToString().Trim();
                    _DefGuID = _wxguid;
                    //写入Session并写入Cookie
                    /////////////////修改增加皮肤的
                    _index = dr["wxTheme"].ToString().Trim();
                    _list = dr["wxTheme2"].ToString().Trim();
                    _detail = dr["wxTheme3"].ToString().Trim();
                    _kuaijie = dr["wxTheme4"].ToString().Trim();
                    Session["theme"] = _index + "|" + _list + "|" + _detail + "|" + _kuaijie;
                    ////////////////////////////////
                    Session["tdxWeixin"] = _DefWID + "|" + _DefNiChen + "|" + _DefTheme + "|" + _DefGuID;
                    Session["wID"] = _DefWID;
                    HttpCookie cookie = new HttpCookie("tdxWeixin");//初使化并设置Cookie的名称 
                    cookie.Expires = DateTime.Now.AddDays(1);//设置过期时间
                    cookie.Values.Add("WID", _DefWID);
                    cookie.Values.Add("NiChen", HttpUtility.UrlEncode(_DefNiChen));
                    cookie.Values.Add("Theme", _DefTheme);
                    cookie.Values.Add("GuID", _DefGuID);
                    Response.AppendCookie(cookie);
                    HttpCookie themes = new HttpCookie("theme");//初使化并设置Cookie的名称 
                    themes.Expires = DateTime.Now.AddHours(1);//设置过期时间
                    themes.Values.Add("index", _index);
                    themes.Values.Add("list", _list);
                    themes.Values.Add("detail", _detail);
                    themes.Values.Add("kuaijie", _kuaijie);
                    Response.AppendCookie(themes);
                }
                else
                {
                    Response.Redirect("err.aspx?t=无效的公众号");
                    return;
                }
            }
        }
    }
}
