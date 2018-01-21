using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Tuan
{
    /// <summary>
    /// RefreshPeoPle 的摘要说明
    /// </summary>
    public class RefreshPeoPle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string spbh = context.Request["spbh"].ToString();
            //string sql="select count(*) as count from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and 商品编号='"+spbh+"' and a.订单编号 in (select 订单编号 from TM_订单支付表)";
            string sql = "select count(*) as count from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and 商品编号='" + spbh + "' ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                context.Response.Write(dt.Rows[0]["count"]);
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