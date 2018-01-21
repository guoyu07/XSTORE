using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Creatrue.kernel;

namespace tdx.appv
{
    public partial class orders_chaxun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string _key = keywords.Value.Trim();
            string _sql = "select ol_date,(select a_name from b2c_order_active where id=aid) as aname from b2c_order_log where ono='" + _key + "' order by id desc";
            _sql += ";select id from b2c_orders where o_no='" + _key + "'";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            string result = "";
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result += "<li>" + dr["aname"].ToString() + "[" + dr["ol_date"].ToString() + "]</li> \r\n";
                } 
            }
            else
            {
                result = "您查询的订单不存在";
            }
            ds.Dispose();

            lt_result.Text = result;

        }
    }
}
