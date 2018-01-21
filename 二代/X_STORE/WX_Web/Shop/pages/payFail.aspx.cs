using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;

namespace Wx_NewWeb.Shop.pages
{
    public partial class payFail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        protected void PageInit()
        {
            var orderNo = Request.QueryString["order"].ObjToStr();
            string orderSql = string.Format(@"select top 1 c.总金额,
(select b.品名+',' from WP_订单子表 a left join WP_商品表 b on a.商品id = b.id where a.订单编号 = c.订单编号 FOR XML PATH('')) as 品名 
from WP_订单表 c left join WP_订单子表 d on c.订单编号 = d.订单编号 where c.订单编号 = '{0}'", orderNo);
            DataTable orderDt = comfun.GetDataTableBySQL(orderSql);
            if (orderDt.Rows.Count > 0)
            {
                goodsName.Text = orderDt.Rows[0]["品名"].ObjToStr().TrimEnd(',');
                goodsSale.Text = orderDt.Rows[0]["总金额"].ObjToStr();
            }
        }
    }
}