using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdx.memb.man.Shop.GoodsManage
{
    /// <summary>
    /// AjaxDel 的摘要说明
    /// </summary>
    public class AjaxDel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id=context.Request["id"];
            int flag= comfun.DelbySQL("delete from [dbo].[WP_商品表] where id='"+id+"'");
            if (flag > 0)
            {
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }
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