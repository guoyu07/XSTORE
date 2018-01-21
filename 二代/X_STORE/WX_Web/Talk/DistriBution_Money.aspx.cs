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
    public partial class DistriBution_Money : weixinAuth
    {
        public static string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DistriBution_head1.page = "我的佣金";
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                this.hide_mid.Value = Request["mid"];
                DataTable dt_top = DbHelperSQL.Query(@"select top 10 *, case a.cno when '017' then (-1*ac_money) else ac_money end  as acmoney from B2C_Account a left join [dbo].[B2C_kemu] b on a.cno=b.c_no where a.cno in ('015','016','017') and a.mid in
 (select top 1 id from  [B2C_mem] where openid='"+openid+"') order by a.ac_regdate desc").Tables[0];
                Rp_UserInfo.DataSource = dt_top;
                Rp_UserInfo.DataBind();


            }
        }
    }
}