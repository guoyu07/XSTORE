using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XStore.WebSite.WebSite.Information
{
    public partial class RoomInfo : CenterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-基础信息(房间)";
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        protected void PageInit()
        {


        }
    }
}