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
    public partial class DistriBution_Order : weixinAuth
    {
        public static string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DistriBution_head1.page = "我的订单";
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";

                DataTable dt_top = DbHelperSQL.Query(@"select top 10 * from B2C_Account a left join [dbo].[WP_订单表] b on a.orderNo=b.订单编号 left join WP_会员表 c on b.openid=c.openid where a.cno=015 and a.mid in (select top 1 id from B2C_mem where openid='" + openid + "') union select * from B2C_Account a left join [dbo].[TM_订单表] b on a.orderNo=b.订单编号 left join WP_会员表 c on b.openid=c.openid  where a.cno=016 and a.mid in (select top 1 id from B2C_mem where openid='" + openid + "') order by 下单时间 desc").Tables[0];
                Rp_UserInfo.DataSource = dt_top;
                Rp_UserInfo.DataBind();
            }
        }
    }
}