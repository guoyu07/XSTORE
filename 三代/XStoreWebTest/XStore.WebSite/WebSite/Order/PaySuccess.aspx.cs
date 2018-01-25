using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XStore.WebSite.WebSite.Order
{
    public partial class PaySuccess : BasePage
    {
        public string telphone = "";

        public string success_str = string.Empty;
        public string success_link = string.Empty;
        public string display = string.Empty;
        public string undisplay = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-支付成功";
            orders();
        }
        private string _orderno;

        protected string OrderNo
        {
            get
            {
                if (debug)
                {
                    return "S201712274872250";
                }

                if (string.IsNullOrEmpty(_orderno))
                {
                    _orderno = Request["order"] != null ? Convert.ToString(Request["order"]) : string.Empty;
                }
                return _orderno;
            }

        }
        //加载页面详情

        public string pay_price = "";

        protected void orders()
        {
            //telphone = HotelPhone;
            if (debug)
            {
                telphone = "13404265055";
            }
            string sql_wz = "";
            sql_wz = @"select 总金额,支付时间,state from Wp_订单表
left join WP_订单支付表 on WP_订单表.订单编号=wp_订单支付表.订单编号 where Wp_订单表.订单编号='" + OrderNo + "'";
            //    }
            DataTable dt_price = comfun.GetDataTableBySQL(sql_wz);

            pay_price = dt_price.Rows[0]["总金额"].ObjToStr();
            pay_time.Text = dt_price.Rows[0]["支付时间"].ObjToStr();
            //测试使用下方时间并根据当前时间修改
            order_lbl.Text = OrderNo;
            state_lbl.Text = dt_price.Rows[0]["state"].ObjToStr();
            IsSuccess();

        }
        protected void IsSuccess()
        {
            var sql = string.Format("SELECT * FROM WP_订单表 WHERE 订单编号 = '{0}' AND state in(2,5)", OrderNo);
            Log.WriteLog("页面：paySuccess", "方法：IsSuccess", "sql:" + sql);
            var dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count == 0)
            {
                success_str = "开箱成功";
                success_link = "../img/paymentSuccessed.png";
                display = "display:none;";
                undisplay = "";
            }
            else
            {
                success_str = "正在为您开箱";
                success_link = "../img/yh.png";
                undisplay = "display:none;";

            }


        }
        protected void look_order_Click(object sender, EventArgs e)
        {
            //MessageBox.ShowAndRedirect(this, "查看订单！", "../buyer/mySpace.aspx");
            Response.Write("<script>window.location.href='../buyer/myself.aspx';</script>");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            var url = "../Buyer/mySpace.aspx";
            Response.Redirect(url, false);
            return;
        }
    }
}