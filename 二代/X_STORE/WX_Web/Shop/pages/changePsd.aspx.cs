using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using tdx.Weixin;
using System.Data;
using DTcms.Common;
using Creatrue.kernel;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using DTcms.BLL;

namespace Wx_NewWeb.Shop.pages
{
    public partial class changePsd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private DataRow _changeuserinfo;

        protected DataRow ChangeUserInfo
        {
            get
            {
                if (_changeuserinfo == null)
                {
                    if (Request.QueryString["userId"] != null && !string.IsNullOrEmpty(Request.QueryString["userId"].ObjToStr()))
                    {
                        var user_sql = string.Format("SELECT * FROM [WP_用户表] WHERE id ={0}", Request.QueryString["userId"].ObjToStr());
                        DataTable user_dt = comfun.GetDataTableBySQL(user_sql);
                        if (user_dt.Rows.Count > 0)
                        {
                            _changeuserinfo = user_dt.Rows[0];
                        }
                        else
                        {
                            RedirectError("用户不存在");
                        }
                    }
                    else
                    {
                        var user_sql = string.Format("SELECT * FROM [WP_用户表] WHERE id ={0}", UserId);
                        DataTable user_dt = comfun.GetDataTableBySQL(user_sql);
                        if (user_dt.Rows.Count > 0)
                        {
                            _changeuserinfo = user_dt.Rows[0];
                        }
                        else
                        {
                            RedirectError("用户不存在");
                        }
                    }
                   
                }
                return _changeuserinfo;
            }


        }

        protected void PageInit()
        {
            name_input.Value = ChangeUserInfo["真实姓名"].ObjToStr();
            phone_input.Value = ChangeUserInfo["手机号"].ObjToStr();
            account_input.Value = ChangeUserInfo["用户名"].ObjToStr();
        }

        //protected void sub_pswd_Click(object sender, EventArgs e)
        //{

        //    string user_id = "";

        //    string sql = "select 用户名, 密码, openid, 手机号, 真实姓名, QQ, Email, 微信昵称, 微信头像, IsShow, 角色id from WP_用户表 where id='" + user_id + "'";
        //    DataTable dt = comfun.GetDataTableBySQL(sql);
        //    string old_psd = old_pswd.Value.ObjToStr();
        //    string mobile = tel.Value.ObjToStr();
        //    try
        //    {
        //        string x = "^1[3578][0-9]{9}$";
        //        //string telp = mobile.ObjToStr();
        //        //  string strmatch = @"^((13[0-9])|(15[0-9])|(17[0-9])|(18[0,3-9]))\\d{8}$";
        //        Regex reg = new System.Text.RegularExpressions.Regex(x);
        //        if (reg.IsMatch(mobile))//是手机号
        //        {
        //            if (old_psd == null || old_psd == string.Empty)
        //            {
        //                Response.Write("<script>alert('请输入原密码!')</script>");
        //            }
        //            else//密码不为空
        //            {
        //                if (old_psd != dt.Rows[0]["密码"].ObjToStr())
        //                {
        //                    Response.Write("<script>alert('密码错误!')</script>");
        //                }
        //                else
        //                {
        //                    try
        //                    {
        //                        //Log.WriteLog("", "try", "");
        //                        //Log.WriteLog("", "new_a", newPsd.Value);
        //                        //Log.WriteLog("", "new_b", newPsdRepeat.Value);
        //                        #region
        //                        if (!string.IsNullOrEmpty(newPsd.Value) && !string.IsNullOrEmpty(newPsdRepeat.Value))
        //                        {
        //                            string new_a = newPsd.Value;
        //                            //Log.WriteLog("", "new_a", new_a);
        //                            string new_b = newPsdRepeat.Value;
        //                            //Log.WriteLog("", "new_b", new_b);
        //                            if (new_a == new_b)
        //                            {
        //                                MD5 md5 = MD5.Create();
        //                                string pwd = "";
        //                                byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(new_a));
        //                                for (int i = 0; i < s.Length; i++)
        //                                {
        //                                    // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
        //                                    pwd = pwd + s[i].ToString("X");

        //                                }
        //                               //Log.WriteLog("", "pswd", pwd);
        //                               // Log.WriteLog("", "1", "new_a == new_b");
        //                                string sql_old = @"insert into WP_用户历史表 (用户名, 密码, openid, 手机号, 真实姓名, QQ, Email, 微信昵称, 微信头像, IsShow, 角色id) values('" + dt.Rows[0]["用户名"].ObjToStr() + "','" + dt.Rows[0]["密码"].ObjToStr() + "','" + dt.Rows[0]["openid"].ObjToStr() + "','" + dt.Rows[0]["手机号"].ObjToStr() + "','" + dt.Rows[0]["真实姓名"].ObjToStr() + "','" + dt.Rows[0]["QQ"].ObjToStr() + "','" + dt.Rows[0]["Email"].ObjToStr() + "','" + dt.Rows[0]["微信昵称"].ObjToStr() + "','" + dt.Rows[0]["微信头像"].ObjToStr() + "','" + dt.Rows[0]["IsShow"].ObjToStr() + "','" + dt.Rows[0]["角色id"].ObjToStr() + "')";
        //                                //Log.WriteLog("插入历史信息", sql_old, "");
        //                                comfun.InsertBySQL(sql_old);
        //                                string sql_wxPic = "select wx头像 from wp_会员表 where openid='" + openid + "'";
        //                                DataTable dt_wxPic = comfun.GetDataTableBySQL(sql_wxPic);
        //                                string sql_new = "update WP_用户表 set 加密='"+pwd+"',密码='" + new_a + "',openid='" + openid + "',手机号='" + mobile + "',微信头像='" + dt_wxPic.Rows[0]["wx头像"].ObjToStr() + "' where id='" + user_id + "'";
        //                                //Log.WriteLog("更新新用户openid 等数据", sql_new, "");

        //                                comfun.UpdateBySQL(sql_new);
        //                                //  Response.Write("<script>alert('修改成功!');window.location.href ='user.aspx'</script>");
        //                                int role_id = dt.Rows[0]["角色id"].ObjToInt(0);
        //                                #region
        //                                if (role_id == 1)//经理
        //                                {
        //                                    Response.Write("<script>alert('修改成功!');window.location.href ='../pages/hotelManager.aspx'</script>");
        //                                    //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../pages/hotelManager.aspx");
        //                                    Session["UserId"] = user_id;

        //                                }
        //                                else if (role_id == 2)//财务
        //                                {
        //                                    Response.Write("<script>alert('修改成功!');window.location.href ='../pages/goodsList.aspx'</script>");
        //                                    //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../pages/goodsList.aspx");
        //                                    Session["UserId"] = user_id;
        //                                }
        //                                else if (role_id == 3)//配送员
        //                                {
        //                                    Response.Write("<script>alert('修改成功!');window.location.href ='../Distributer/disMyself.aspx'</script>");
        //                                    //  MessageBox.ShowAndRedirect(this, "登陆成功！", "../Distributer/disMyself.aspx");
        //                                    Session["UserId"] = user_id;
        //                                }
        //                                else if (role_id == 4)
        //                                {
        //                                    Response.Write("<script>alert('修改成功!');window.location.href ='../OperateManager/home.aspx'</script>");
        //                                    // MessageBox.ShowAndRedirect(this, "登陆成功！", "../OperateManager/home.aspx");
        //                                    Session["UserId"] = user_id;
        //                                }
        //                                else
        //                                {
        //                                    Response.Write("<script>alert('修改成功');window.location.href ='../pages/login.aspx'</script>");
        //                                }
        //                                #endregion
        //                            }
        //                            else
        //                            {
        //                                Response.Write("<script>alert('两次密码不同!')</script>");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Response.Write("<script>alert('不能为空!')</script>");
        //                        }
        //                        #endregion
        //                    }
        //                    catch
        //                    {
        //                        Response.Write("<script>alert('爆炸了!')</script>");
        //                    }
        //                }
        //            }

        //        }

        //        else
        //        {
        //            Response.Write("<script>alert('请输入正确手机号!')</script>");
        //        }
        //    }
        //    catch
        //    {
        //        Response.Write("<script>alert('请输入正确手机号!')</script>");
        //    }


        //}
    }
}