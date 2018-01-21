using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace tdx.memb.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Text = Utils.GetCookie("DTRememberName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                msgtip.InnerHtml = "请输入用户名或密码";
                return;
            }
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判断登录错误次数
            if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 5)
            {
                msgtip.InnerHtml = "错误超过5次，关闭浏览器重新登录！";
                return;
            }
            DTcms.BLL.manager bll = new DTcms.BLL.manager();
            DTcms.Model.manager model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                msgtip.InnerHtml = "用户名或密码有误，请重试！";
                return;
            }
            Session[DTKeys.SESSION_ADMIN_INFO] = model;
            Session["dtid"] = model.id;
            //2014.11.14 星期五 新增的代码 目的：兼容内部代码----------------------------begin
            //                    id(0)          用户名()             等级(0)                 模板(1)            原始码()       功能模板("appv")
            //string[] uInfo = { this.id.ToString(), this.M_name, this.M_vip.ToString(), this.wx_theme.ToString(), this.wx_ID, this.wx_GNTheme };
            //System.Web.HttpContext.Current.Session["wInfo"] = uInfo;

            string[] uInfo = { "\"" + model.id + "\"", model.user_name, "1", "", "gh_43e6da782abd", "" };
            Session["wInfo"] = uInfo; 
            Session["wID"] = model.id;
            //2014.11.14 星期五 新增的代码 ----------------------------end

            Session.Timeout = 600;
            //写入登录日志
            DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new DTcms.BLL.manager_log().Add(model.id, model.user_name, DTEnums.ActionEnum.Login.ToString(), "用户登录");
            }
            //写入Cookies
            Utils.WriteCookie("DTRememberName", model.user_name, 14400);
            Utils.WriteCookie("AdminName", "DTcms", model.user_name);
            Utils.WriteCookie("AdminPwd", "DTcms", model.password);
            Response.Redirect("index.aspx");
            return;
        }

    }
}