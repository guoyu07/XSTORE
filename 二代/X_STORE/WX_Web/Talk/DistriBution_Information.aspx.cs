using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.Weixin;

namespace Wx_NewWeb.Talk
{
    public partial class DistriBution_Information : weixinAuth
    {
        public static string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                string sql = "select  M_truename,M_sex,M_mobile,M_card,M_bank,convert(varchar(50),M_regtime,23) as M_regtime  from   [dbo].[B2C_mem] where  openid='" + openid + "' ";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.txt_M_bank.Text = dt.Rows[0]["M_bank"] != null ? dt.Rows[0]["M_bank"].ToString() : "";
                    this.txt_M_card.Text = dt.Rows[0]["M_card"] != null ? dt.Rows[0]["M_card"].ToString() : "";
                    this.txt_M_mobile.Text = dt.Rows[0]["M_mobile"] != null ? dt.Rows[0]["M_mobile"].ToString() : "";
                    this.txt_M_regtime.Text = dt.Rows[0]["M_regtime"] != null ? dt.Rows[0]["M_regtime"].ToString() : "";
                    this.txt_M_sex.Text = dt.Rows[0]["M_sex"] != null ? dt.Rows[0]["M_sex"].ToString() : "";
                    this.txt_M_truename.Text = dt.Rows[0]["M_truename"] != null ? dt.Rows[0]["M_truename"].ToString() : "";
                }
            }
        }
    }
}