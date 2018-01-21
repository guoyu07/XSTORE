using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tuan
{
    public partial class MyInfo : System.Web.UI.Page
    {
        public string name = "";
        public string headimg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["name"]!=null&&Request["headimg"]!=null)
            {
                name = Request["name"].ToString();
                headimg ="<img src='"+Request["headimg"].ToString()+"' />" ;
            }
            else
            {
                //string str = HttpContext.Current.Request.Url.AbsolutePath;
                //string strs = Path.GetFileName(str);
                //string url = HttpContext.Current.Request.Url.Query;
                //if (url.Equals(""))
                //    url = "?1+1";
                //Response.Redirect("TestGetInfo.aspx?back_url=" + (strs + url));
            }
        }
    }
}