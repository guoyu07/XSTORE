using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using System.Text;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.vip
{
    public partial class coupon : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["wID"] != null)
                    {
                        string safeSql = @"select tb.id,
tb.v_num-(select count(*) from C2C_voucher_log where v_id=tb.id) as v_num,
v_amount,v_deduction,regtime,v_start_time,v_end_time from(
select * from C2C_voucher 
where v_isactive=1 and 
v_end_time>getdate() and 
v_start_time<getdate() and wid="+Session["wID"]+") as tb";
                        DataTable dt = comfun.GetDataTableBySQL(safeSql);
                        if (dt.Rows.Count > 0)
                        {
                            StringBuilder outSb = new StringBuilder();
                            foreach (DataRow dr in dt.Rows)
                            {
                                outSb.Append("<li><div class='couponCustom'><img src='image/couponCustom.png' /><div class='couponCustomText'>");
                                outSb.Append("<h1>" + dr["v_deduction"] + "<span>元</span></h1><p>订单满" + dr["v_amount"] + "元使用</p>");
                                outSb.Append("<p>有效期" + Convert.ToDateTime(dr["v_start_time"]).ToString("yyyy-MM-dd") + "至" + Convert.ToDateTime(dr["v_end_time"]).ToString("yyyy-MM-dd") + "</p>");
                                outSb.Append("<i>剩余" + dr["v_num"] + "张</i><a><span>立即领取</span></a></div></div></li>");
                            }
                            list_active.Text = outSb.ToString();
                        }


                        DataTable dtmid = comfun.GetDataTableBySQL("select id from B2C_mem where M_card='" + Request["wwv"] + "'");
                        if (dtmid.Rows.Count > 0)
                        {
                            DataTable Deldt = comfun.GetDataTableBySQL("select * from C2C_voucher where wid="+Session["wID"]+" and id in (select v_id from C2C_voucher_log where mid=" + dtmid.Rows[0][0] + ")");
                            if (Deldt.Rows.Count > 0)
                            {
                                StringBuilder deloutSb = new StringBuilder();
                                foreach (DataRow dr in Deldt.Rows)
                                {
                                    deloutSb.Append("<li><div class='couponCustom'><img src='image/couponCustom.png' /><div class='couponCustomText'>");
                                    deloutSb.Append("<h1>" + dr["v_deduction"] + "<span>元</span></h1><p>订单满" + dr["v_amount"] + "元使用</p>");
                                    deloutSb.Append("<p>有效期" + Convert.ToDateTime(dr["v_start_time"]).ToString("yyyy-MM-dd") + "至" + Convert.ToDateTime(dr["v_end_time"]).ToString("yyyy-MM-dd") + "</p>");
                                    deloutSb.Append("<i>剩余" + dr["v_num"] + "张</i><a><span></span></a></div></div></li>");
                                }
                                list_unactive.Text = deloutSb.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "vip/coupon.aspx.cs", Session["wID"].ToString());
                }
            }
        }
    }
}