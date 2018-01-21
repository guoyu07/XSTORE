using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;


namespace Wx_NewWeb.Shop.pages
{
    public partial class euqipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                rooms();
            }
        }
        protected void rooms()
        {
            int kw_id = Request["kwid"] != null ? Convert.ToInt32(Request["kwid"]) : 0;
            string sql = @"select a.id as kwid,a.库位名,b.仓库名,b.详细地址,实际商品id from wp_库位表 A
left join WP_仓库表 b on A.仓库id=b.id
left join wp_箱子表 c on c.库位id=a.id
where A.id='"+kw_id+"' and 实际商品id=0";
            string sql_name = @"select a.id as kwid,a.库位名,b.仓库名,b.详细地址 from wp_库位表 A
left join WP_仓库表 b on A.仓库id=b.id
where A.id='" + kw_id + "'";

            DataTable dt = comfun.GetDataTableBySQL(sql);
            DataTable dt_name = comfun.GetDataTableBySQL(sql_name);
            if (dt.Rows.Count > 0)
            {
                normal.Style["display"] = "none";
                replenishment.Style["display"] = "block";
            }
            else
            {

            }
            jdqc.Text = dt_name.Rows[0]["仓库名"].ObjToStr();
            kwm.Text = dt_name.Rows[0]["库位名"].ObjToStr();
        }
    }
}