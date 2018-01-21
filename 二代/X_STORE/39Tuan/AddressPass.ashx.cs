using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// AddressPass 的摘要说明
    /// </summary>
    public class AddressPass : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           int id=Convert.ToInt32(context.Request["id"].ToString());
           string sql = "select * from WP_订单地址表 where id=" + id + "";
           DataTable dt = comfun.GetDataTableBySQL(sql);
           if (dt.Rows.Count > 0)
           {
               context.Response.Write(dt.Rows[0]["收货人"].ToString() + ":" + dt.Rows[0]["手机号"].ToString() + ":" + dt.Rows[0]["省"].ToString() + ":" + dt.Rows[0]["市"].ToString() + ":" + dt.Rows[0]["区"].ToString() + ":" + dt.Rows[0]["详细地址"].ToString()+":"+dt.Rows[0]["是否为默认地址"].ToString());
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