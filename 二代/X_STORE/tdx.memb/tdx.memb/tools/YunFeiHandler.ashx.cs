using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace tdx.memb.tools
{
    /// <summary>
    /// YunFeiHandler 的摘要说明
    /// </summary>
    public class YunFeiHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string ordernum = string.IsNullOrEmpty(context.Request.Params["ordernum"]) ? "" : context.Request.Params["ordernum"].ToString();
            string ordertype = string.IsNullOrEmpty(context.Request.Params["ordertype"]) ? "" : context.Request.Params["ordertype"].ToString();
            string yunfei = string.IsNullOrEmpty(context.Request.Params["yunfei"]) ? "" : context.Request.Params["yunfei"].ToString();
            string yingfuold = string.IsNullOrEmpty(context.Request.Params["yingfuold"]) ? "" : context.Request.Params["yingfuold"].ToString();
            string yingfunew = string.IsNullOrEmpty(context.Request.Params["yingfunew"]) ? "" : context.Request.Params["yingfunew"].ToString();
            string quanxian = string.IsNullOrEmpty(context.Request.Params["quanxian"]) ? "" : context.Request.Params["quanxian"].ToString();
            if (!string.IsNullOrEmpty(ordernum) && !string.IsNullOrEmpty(yingfuold) && !string.IsNullOrEmpty(yingfunew))
            {
                if (quanxian == "qwe159357")
                {

                    if (yingfuold.Trim().Equals(yingfunew.Trim()))//只改运费时，更新运费与金额
                    {
                        StringBuilder sbsql = new StringBuilder();
                        sbsql.Append("\r\n update " + ordertype + "_订单表  set   应付款=(应付款-运费+" + yunfei + ") where 订单编号='" + ordernum + "' ");
                        sbsql.Append("\r\n  update " + ordertype + "_订单表  set 运费=" + yunfei + " where 订单编号='" + ordernum + "' ");
                        comfun.UpdateBySQL(sbsql.ToString());
                        context.Response.Write("true");
                        context.Response.End();
                    }
                    else
                    {
                        string sql = "update " + ordertype + "_订单表 set 运费=" + yunfei + ",应付款=" + yingfunew + "  where 订单编号='" + ordernum + "'";
                        comfun.UpdateBySQL(sql.ToString());
                        context.Response.Write("true");
                        context.Response.End();
                    }
                }
                else
                {
                    context.Response.Write("false");
                    context.Response.End();
                }
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