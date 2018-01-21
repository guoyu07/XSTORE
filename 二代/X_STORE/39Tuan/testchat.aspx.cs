using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tuan
{
    public partial class testchat : System.Web.UI.Page
    {
        Chat chat = new Chat();
        protected void Page_Load(object sender, EventArgs e)
        {
            chat.wxid = 2;
            Response.Write(chat.access_token());
        }
    }
}