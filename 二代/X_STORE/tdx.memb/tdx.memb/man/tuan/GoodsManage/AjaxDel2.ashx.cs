using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdx.memb.man.tuan.GoodsManage
{
    /// <summary>
    /// AjaxDel2 的摘要说明
    /// </summary>
    public class AjaxDel2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["id"];
            int flag = comfun.DelbySQL("delete from [dbo].[TM_商品表] where id='" + id + "'");
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