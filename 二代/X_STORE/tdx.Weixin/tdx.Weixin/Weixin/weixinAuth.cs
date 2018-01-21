using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using Creatrue.kernel;
using tdx.Weixin.Weixin;
using tdx.database.Common_Pay.WeiXinPay;

namespace tdx.Weixin
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
        public string _boxmac = "";
        public weixinAuth()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            Page.Title = "";
            weixin _wx = new tdx.Weixin.weixin();
            //Log.WriteLog("第一步 ", "openid是否为空", "");
            _boxmac = Request["mac"] != null ? Convert.ToString(Request["mac"]) : "";
            //Log.WriteLog("", "_boxmac", _boxmac);
            Session["boxmac"] = _boxmac;
            if (Request["WHC"] != null)
            {
                Session["OpenId"] = "ofGbbwsKQZ7jPygGHaQOgaWRRiTM";
            }
            if (Session["OpenId"] == null)
            {
                Log.WriteLog(" ", "openid 为空", "");
                //授权获取用户信息
                string x = Request["code"].ObjToStr();
                if (Request["code"] != null)
                {

                    tdx.Weixin.weixin weixin = new weixin();
                    OAuth_Token web_Oatuth = weixin.Get_WebOauthToken(Request["code"].ToString()); //获取用户openid

                    weixinUser userinfo = _wx.GetWebUserInfo(web_Oatuth.access_token, web_Oatuth.openid);
                    #region
                    if (userinfo != null)
                    {
                        string nickname = userinfo.Nickname;
                        string headpic = userinfo.Headimgurl;
                        string sql = "select * from wp_会员表 where openid='" + web_Oatuth.openid + "'";
                        DataTable dt = comfun.GetDataTableBySQL(sql);
                        #region
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
                        #endregion

                        Log.WriteLog("", "openid为空", "获取到了新的openid并更新了数据");
                        string login_a = "http://x.x-store.com.cn/shop/pages/login2.aspx";
                        //string login_b = Session["redir"].ObjToStr();
                        string login_b = Request.Url.ToString();
                        string[] login_c = login_b.Split(new char[] { '?' });
                        string login_d = login_c[0];
                        Log.WriteLog("", "根据链接判断跳转", login_d);
                        string open = web_Oatuth.openid;
                        Session["OpenId"] = web_Oatuth.openid;
                        if (login_d == login_a)//权限用户
                        {

                           // Session["OpenId"] = web_Oatuth.openid;
                         //   string open = web_Oatuth.openid;
                            Log.WriteLog("", "openid为空", "权限用户");
                            string sql_user = "select id,用户名,密码,角色id,openid,手机号 from WP_用户表 where openid='" + open + "' and isshow=1";
                            DataTable dt_sql_user = comfun.GetDataTableBySQL(sql_user);
                            if (dt_sql_user.Rows.Count > 0)
                            {
                                int role_id = dt_sql_user.Rows[0]["角色id"].ObjToInt(0);
                                int user_id = dt_sql_user.Rows[0]["id"].ObjToInt(0);
                                #region
                                if (role_id == 1)//经理
                                {
                                    Response.Write("<script>window.location.href ='../pages/hotelManager.aspx'</script>");
                                    //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../pages/hotelManager.aspx");
                                    Session["UserId"] = user_id;

                                }
                                else if (role_id == 2)//财务
                                {
                                    Response.Write("<script>window.location.href ='../pages/goodsList.aspx'</script>");
                                    //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../pages/goodsList.aspx");
                                    Session["UserId"] = user_id;
                                }
                                else if (role_id == 3)//配送员
                                {
                                    Response.Write("<script>window.location.href ='../Distributer/disMyself.aspx'</script>");
                                    //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../Distributer/disMyself.aspx");
                                    Session["UserId"] = user_id;
                                }
                                else if (role_id == 4)
                                {
                                    Response.Write("<script>window.location.href ='../OperateManager/home.aspx'</script>");
                                    // MessageBox.ShowAndRedirect(this, "登陆成功！", "../OperateManager/home.aspx");
                                    Session["UserId"] = user_id;
                                }
                                else
                                {
                                    Response.Write("<script>alert('没有对应页面')</script>");
                                }
                                #endregion
                            }
                            else
                            {
                                Response.Redirect("http://x.x-store.com.cn/Shop/Pages/login.aspx");
                            }


                        }
                        else
                        {//客户 
                            Response.Redirect("http://x.x-store.com.cn/Shop/Pages/enter.html");
                        }
                    }
                    else
                    {
                        string RedirectUri = Request.Url.ToString();
                        Log.WriteLog("openid 为空 request code 不为空", "获取授权跳转页面", RedirectUri);
                        Session["redir"] = RedirectUri;
                        string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                        Response.Redirect(URL);
                    }
                    #endregion
                }
                else
                {
                    // 网页授权跳转页面
                    string RedirectUri = Request.Url.ToString();
                    Log.WriteLog("openid为空 request code 为空", "获取授权跳转页面", RedirectUri);
                    Session["redir"] = RedirectUri;
                    string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                    Response.Redirect(URL);
                }
            }
            else
            {
                Log.WriteLog(" ", "openid 不为空", "");
                string login_a = "http://x.x-store.com.cn/shop/pages/login2.aspx";
                //string login_b = Session["redir"].ObjToStr();
                string login_b = Request.Url.ToString();
                string[] login_c = login_b.Split(new char[] { '?' });
                string login_d = login_c[0];
                Log.WriteLog("", "判断需跳转页面", login_d);
                string open = Session["OpenId"].ObjToStr();
                if (login_d == login_a)//权限用户
                {
                   

                    Log.WriteLog("", "权限用户", "");
                    string sql_user = "select id,用户名,密码,角色id,openid,手机号 from WP_用户表 where openid='" + open + "' and isshow=1";
                    DataTable dt_sql_user = comfun.GetDataTableBySQL(sql_user);
                    if (dt_sql_user.Rows.Count > 0)
                    {
                        int role_id = dt_sql_user.Rows[0]["角色id"].ObjToInt(0);
                        int user_id = dt_sql_user.Rows[0]["id"].ObjToInt(0);
                        #region
                        if (role_id == 1)//经理
                        {
                            Response.Write("<script>window.location.href ='../pages/hotelManager.aspx'</script>");
                            //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../pages/hotelManager.aspx");
                            Session["UserId"] = user_id;

                        }
                        else if (role_id == 2)//财务
                        {
                            Response.Write("<script>window.location.href ='../pages/goodsList.aspx'</script>");
                            //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../pages/goodsList.aspx");
                            Session["UserId"] = user_id;
                        }
                        else if (role_id == 3)//配送员
                        {
                            Response.Write("<script>window.location.href ='../Distributer/disMyself.aspx'</script>");
                            //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../Distributer/disMyself.aspx");
                            Session["UserId"] = user_id;
                        }
                        else if (role_id == 4)
                        {
                            Response.Write("<script>window.location.href ='../OperateManager/home.aspx'</script>");
                            // MessageBox.ShowAndRedirect(this, "登陆成功！", "../OperateManager/home.aspx");
                            Session["UserId"] = user_id;
                        }
                        else
                        {
                            Response.Write("<script>alert('没有对应页面')</script>");
                        }
                        #endregion
                    }
                    else
                    {
                        Response.Redirect("http://x.x-store.com.cn/Shop/Pages/login.aspx");

                    }

                }
                else
                {//客户 
                    Response.Redirect("http://x.x-store.com.cn/Shop/Pages/enter.html");
                }
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
