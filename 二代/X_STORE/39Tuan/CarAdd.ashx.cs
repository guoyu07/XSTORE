using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// CarAdd 的摘要说明
    /// </summary>
    public class CarAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          string openid= context.Request["openid"].ToString();
          string spbh = context.Request["spbh"].ToString();
          decimal danjia =Convert.ToDecimal(context.Request["danjia"].ToString());
          comfun.InsertBySQL("insert into TM_购物车 (openid,商品编号,单价,数量,是否结算) values('" + openid + "','" + spbh + "'," + danjia + ",1,0)");



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