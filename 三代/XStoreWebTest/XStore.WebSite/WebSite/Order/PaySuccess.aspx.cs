using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Entity;

namespace XStore.WebSite.WebSite.Order
{
    public partial class PaySuccess : BasePage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-开箱成功";
           
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
    }
}