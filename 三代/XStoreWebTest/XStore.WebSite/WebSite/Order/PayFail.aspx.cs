using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Common;
using XStore.Entity;

namespace XStore.WebSite.WebSite.Order
{
    public partial class PayFail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-开箱失败";
            if (orderInfo == null)
            {
                MessageBox.Show(this, "system_alert", "订单不存在");
                return;
            }
            title_img.ImageUrl = "~/Content/Images/fail-emoij.png";
            lc1.ImageUrl = "~/Content/Images/lc1.jpg";
            lc2.ImageUrl = "~/Content/Images/lc2.jpg";
            lc2.ImageUrl = "~/Content/Images/lc3.jpg";
        }
        #region 订单信息
        private OrderInfo _orderInfo;
        protected OrderInfo orderInfo
        {
            get
            {
                if (_orderInfo == null)
                {
                    var orderNo = Session[Constant.OrderNo].ObjToInt(0);
                    _orderInfo = context.Query<OrderInfo>().FirstOrDefault(o => o.id == orderNo);
                }
                return _orderInfo;
            }
        }

        #endregion

        #region 购买的商品
        private Product _productInfo;
        protected Product productInfo
        {
            get
            {
                if (_productInfo == null)
                {
                    var productId = orderInfo.product.ObjToInt(0);
                    _productInfo = context.Query<Product>().FirstOrDefault(o => o.id == productId);
                }
                return _productInfo;
            }
        }

        #endregion
       
    }
}