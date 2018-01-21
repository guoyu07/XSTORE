using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.Weixin;

namespace Wx_NewWeb.Talk
{
    public partial class DistriBution_TiXianList : weixinAuth
    {
        public static string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                DataTable dt_top = DbHelperSQL.Query(@"select * from B2C_Account a left join [dbo].[B2C_kemu] b on a.cno=b.c_no where a.cno='005' and a.mid in (select id from B2C_mem where openid='"+openid+"') order by a.ac_regdate desc").Tables[0];
                Rp_UserInfo.DataSource = dt_top;
                Rp_UserInfo.DataBind();
            }
        }
    }
}