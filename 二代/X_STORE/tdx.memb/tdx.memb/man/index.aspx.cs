using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace tdx.memb.admin
{
    public partial class index : DTcms.Web.UI.ManagePage
    {
        protected DTcms.Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            //admin_info.user_name = "";
            if (!Page.IsPostBack)
            {
                admin_info = GetAdminInfo();

            }
       // HttpCookie cookie = Request.Cookies["DTRememberName"];  //检查cookies
        //    if (admin_info.user_name =="")
        //    {
        //        Response.Redirect("login.aspx");
        //    }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[DTKeys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "DTcms", -14400);
            Utils.WriteCookie("AdminPwd", "DTcms", -14400);
            Response.Redirect("login.aspx");
        }

    }
}