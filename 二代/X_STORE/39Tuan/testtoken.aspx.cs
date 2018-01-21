using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tuan
{
    public partial class testtoken : System.Web.UI.Page
    {
        Chat chat = new Chat();
        protected void Page_Load(object sender, EventArgs e)
        {
            chat.wxid = 0;
            Response.Write("chat1"+chat.access_token());
            chat.wxid = 2;
            Response.Write("chat2" + chat.access_token());
        }
    }
}