using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.installer.install
{
    public partial class installer : System.Web.UI.Page
    {
        protected string user = "";
        protected string pwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.Params["user"];
            pwd = Request.Params["pwd"];
        }
    }
}