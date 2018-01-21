using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.Common_Pay.WeiXinPay;
using tdx.Weixin;
namespace Wx_NewWeb.Shop.Buyer
{
    public partial class index : weixinAuth3
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("http://x.x-store.com.cn/Shop/Pages/enter.html");
        }
    }
}