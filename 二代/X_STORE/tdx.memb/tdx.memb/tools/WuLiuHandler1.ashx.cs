using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace tdx.memb.tools
{
    /// <summary>
    /// WuLiuHandler1 的摘要说明
    /// </summary>
    public class WuLiuHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ordernum = string.IsNullOrEmpty(context.Request.Params["ordernum"]) ? "" : context.Request.Params["ordernum"].ToString();
            string ordertype = string.IsNullOrEmpty(context.Request.Params["ordertype"]) ? "" : context.Request.Params["ordertype"].ToString();
            string danhao = string.IsNullOrEmpty(context.Request.Params["danhao"]) ? "" : context.Request.Params["danhao"].ToString();
            string gongsi = string.IsNullOrEmpty(context.Request.Params["gongsi"]) ? "" : context.Request.Params["gongsi"].ToString();
            if (!string.IsNullOrEmpty(ordernum))
            {
                string sql = "update " + ordertype + "_订单表 set  物流单号='" + danhao + "' , 物流公司='" + gongsi + "' where 订单编号='" + ordernum + "'";
                comfun.UpdateBySQL(sql);
                context.Response.Write("true");
                context.Response.End();
            }
            context.Response.Write("false");
            context.Response.End();
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