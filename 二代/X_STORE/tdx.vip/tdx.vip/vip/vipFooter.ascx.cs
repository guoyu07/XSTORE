using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using Creatrue.Common;
using tdx.Weixin;
using System.Data;
namespace tdx.vip
{
    public partial class vipFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            string wwv = "";
            string wwx = "";
            string wid = "";
            string appX = "";
            wwv = (Request["WWV"] == null) ? ((Session["WWV"] == null) ? "" : Session["WWV"].ToString()) : Request["WWV"].ToString();
            wwx = (Request["WWX"] == null) ? ((Session["WWX"] == null) ? "" : Session["WWV"].ToString()) : Request["WWX"].ToString();
            wid = (Session["wID"] == null) ? "" : Session["wID"].ToString();
            string _sql = "select * from B2C_worker where id = '" + wid + "'";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                appX = dt.Rows[0]["wx_GNTheme"].ToString();
            }

            html += "<li><a href='../" + appX + "/index.aspx?WWX=" + wwx + "&WWV=" + wwv + "'><i></i><span>首页</span></a></li>";
            html += "<li><a href='vip_Goods_Show.aspx?WWX=" + wwx + "&WWV=" + wwv + "'><i></i><span>特权</span></a></li>";
            html += "<li><a href='share.aspx?WWX=" + wwx + "&WWV=" + wwv + "'><i></i><span>分享</span></a></li>";
            html += "<li><a href='coupon.aspx?WWX=" + wwx + "&WWV=" + wwv + "'><i></i><span>优惠券</span></a></li>";
            html += "<li><a href='myhome.aspx?WWX=" + wwx + "&WWV=" + wwv + "'><i></i><span>我</span></a></li>";
            lt_footer.Text = html;
        }
    }
}