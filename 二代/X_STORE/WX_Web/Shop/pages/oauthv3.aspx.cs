using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class oauthv3 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = string.Format("http://wx2.x-store.com.cn/WebSite/Login/Oath.aspx?OpenId={0}", OpenId);
            Log.WriteLog("类：BasePage", "方法：url------------------------", "url:" + url);
            Response.Redirect(url);
          

        }
    }
}