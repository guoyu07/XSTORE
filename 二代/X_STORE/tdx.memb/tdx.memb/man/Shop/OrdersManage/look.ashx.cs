using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdx.memb.man.Shop.OrdersManage
{
    /// <summary>
    /// look 的摘要说明
    /// </summary>
    public class look : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}