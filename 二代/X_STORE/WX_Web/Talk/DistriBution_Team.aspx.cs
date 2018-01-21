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
    public partial class DistriBution_Team : weixinAuth
    {
        public static string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DistriBution_head1.page = "我的团队";
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                DataTable dt_top = DbHelperSQL.Query(@"select * from [dbo].[B2C_mem] a left join WP_会员表 b on a.openid=b.openid  where a.ParentID in (select id from B2C_mem where openid='"+openid+"') order by a.M_regtime desc").Tables[0];
                Rp_UserInfo.DataSource = dt_top;
                Rp_UserInfo.DataBind();


            }
        }
    }
}