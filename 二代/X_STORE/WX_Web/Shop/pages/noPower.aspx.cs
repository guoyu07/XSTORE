using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class noPower : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           var  _phone = "13404265055";
        }
        protected void link_click(object sender, EventArgs e) {
            var url = string.Format("../Buyer/mySpace.aspx?is_offline={0}", 1);
            Response.Redirect(url);
        
        }
    }
}