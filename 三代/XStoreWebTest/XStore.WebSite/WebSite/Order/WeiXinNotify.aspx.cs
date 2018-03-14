using Chloe.MySql;
using Newtonsoft.Json;
using System;
using System.Text;
using XStore.Common;
using XStore.Common.Helper;
using XStore.Common.WeiXinPay;
using XStore.Entity;
using XStore.Entity.Model;

namespace XStore.WebSite.WebSite.Order
{
    public partial class WeiXinNotify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "进入微信回调的aspx页面");
            WxPayNotify resultNotify = new WxPayNotify(this);
            resultNotify.ProcessNotify();
        }


    }
}