using Creatrue.kernel;
using DTcms.Common;
using DTcms.Common.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class AssistOpenBox : System.Web.UI.Page
    {
        protected static string url_fenxiang = "";
        protected string shareurl = string.Empty;
        public string no_img = string.Empty;
        protected string jsdkSignature = string.Empty;
        #region 订单总价
        private decimal _totalprice;
        public decimal TotalPrice
        {
            get
            {
                if (_totalprice == new decimal())
                {
                    string sql_price = "select isnull(sum( 价格*数量),0) as 总价  from WP_订单子表 where 订单编号='" + OrderNo + "'";
                    DataTable dt_price = comfun.GetDataTableBySQL(sql_price);
                    _totalprice = dt_price.Rows[0]["总价"].ObjToDecimal(0);
                }
                return _totalprice;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGoods();
                total_price.InnerText = TotalPrice.ObjToStr();
                hid_order.Value = OrderNo;
            }
        }
        protected void BindGoods()
        {
            var sql = string.Format(@"SELECT ISNULL(B.品名,'') AS 品名,ISNULL(B.编号new,'') AS 编号,B.本站价 as 单价,C.图片路径 FROM [dbo].[WP_订单子表] A 
LEFT JOIN [dbo].[WP_商品表] B ON A.商品id = B.id
LEFT JOIN [dbo].[WP_商品图片表] C ON B.编号 = C.商品编号 WHERE 订单编号 = '{0}'", OrderNo);
            var dt_good = comfun.GetDataTableBySQL(sql);
            car_rp.DataSource = dt_good;
            car_rp.DataBind();

        }
        #region 订单内的商品展示
        #endregion

        #region 订单编号
        private string _orderno;
        protected string OrderNo
        {
            get
            {
                if (string.IsNullOrEmpty(_orderno))
                {
                    _orderno = Request["OrderNo"] != null ? Convert.ToString(Request["OrderNo"]) : string.Empty;
                }
                Session["order_no"] = _orderno;
                return _orderno;
            }
        }
        #endregion
        protected void OpenBox_Click(object sender, EventArgs e)
        {

            var selectSql = string.Format(@"select 订单编号,mac, LEFT(位置,LEN(位置)-1) as 位置 from (
select top 1 
(select isnull(箱子MAC,'') from WP_库位表 where id = a.库位id) as mac,
(select convert(nvarchar(2),位置-1)+',' from WP_订单子表 where 订单编号 = a.订单编号 FOR XML PATH('')) as 位置,
a.订单编号
 from WP_订单子表 a left join WP_订单表 b on a.订单编号 = b.订单编号 where b.订单编号 = '{0}'
) as c", OrderNo);
            Log.WriteLog("OpenBox_Click", "sql：" + selectSql, "------");

            DataTable selectDt = comfun.GetDataTableBySQL(selectSql);
            Log.WriteLog("OpenBox_Click", "selectDtCount：" + selectDt.Rows.Count, "------");
            if (selectDt.Rows.Count != 0)
            {
                var orderNo = selectDt.Rows[0]["订单编号"].ToString();
                var position = selectDt.Rows[0]["位置"].ToString();
                var mac = selectDt.Rows[0]["mac"].ToString();
                OpenBox(orderNo, mac, position);

            }
        }

        private bool OpenBox(string orderNo, string mac, string postion_list)
        {

            var rbh = new RemoteBoxHelper();
            try
            {

                rbh.OpenRemoteBox("" + mac + "", orderNo.Substring(1, orderNo.Length - 1), "" + postion_list + "");
                return true;


            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：OpenBox_Click", "方法：OpenBox", "异常信息：" + ex.Message);
                return false;
            }

        }
    }
}