using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.Common_Pay.WeiXinPay;

namespace tdx.memb.NotifyPay.WeXinPay
{
    public partial class ResultNotifyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ResultNotify resultNotify = new ResultNotify(this);
            resultNotify.ProcessNotify();
        }
    }
}