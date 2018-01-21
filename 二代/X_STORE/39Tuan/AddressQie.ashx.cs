using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// AddressQie 的摘要说明
    /// </summary>
    public class AddressQie : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"].ToString());
            string sql = "select * from WP_订单地址表 where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("<div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[0]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[0]["手机号"].ToString() + "</span></div><div class=\"bot_a\">收货地址：" + dt.Rows[0]["省"].ToString() + dt.Rows[0]["市"].ToString() + dt.Rows[0]["区"].ToString() + dt.Rows[0]["详细地址"].ToString() + "</div></div></div></div>");
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