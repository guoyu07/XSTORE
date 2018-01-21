using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// TotalMoney 的摘要说明
    /// </summary>
    public class TotalMoney : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"].ToString();
            if(type.Equals("dan"))
            { 
            int id= Convert.ToInt32(context.Request["id"].ToString());
            string sql = "select * from TM_购物车 where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                decimal a = Convert.ToDecimal(dt.Rows[0]["数量"].ToString()) * Convert.ToDecimal(dt.Rows[0]["单价"].ToString());
                string b = String.Format("{0:f}", a);
                context.Response.Write(b);
               
            }
            }
            else if (type.Equals("all"))
            {
                string openid = context.Request["openid"].ToString();
                string sql = "select * from TM_购物车 where openid='" + openid + "' and 是否结算=0";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count > 0)
                {
                    decimal a=0;
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                       
                        a += Convert.ToInt32(dt.Rows[i]["数量"].ToString()) * Convert.ToDecimal(dt.Rows[i]["单价"].ToString());
                    }
                    string b = String.Format("{0:f}", a);
                    context.Response.Write(b);
                }
            
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