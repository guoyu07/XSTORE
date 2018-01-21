using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// AddressTop 的摘要说明
    /// </summary>
    public class AddressTop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string unionid = context.Request["unionid"].ToString();
            string type = context.Request["type"].ToString();
            if(type.Equals("info"))
            {
                string sql = "select top 1* from dbo.WP_订单地址表 where 订单编号 in(select openid from WP_会员表 where unionid='" + unionid + "') order by 是否为默认地址 desc ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("<div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[0]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[0]["手机号"].ToString() + "</span></div><div class=\"bot_a\">收货地址：" + dt.Rows[0]["省"].ToString() + dt.Rows[0]["市"].ToString() + dt.Rows[0]["区"].ToString() + dt.Rows[0]["详细地址"].ToString() + "</div></div></div></div>");
            }
            else
            {
                context.Response.Write("<div class=\"shr clear newadd\"><span class=\"fl\">新增收货地址信息</span></div>");
            }
            }
            else if (type.Equals("id"))
            {
                string sql = "select top 1* from dbo.WP_订单地址表 where 订单编号 in(select openid from WP_会员表 where unionid='" + unionid + "') order by 是否为默认地址 desc ";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count > 0)
                {
                    context.Response.Write(dt.Rows[0]["id"].ToString());
                }
                else
                {
                    context.Response.Write(0);
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