using Creatrue.kernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// GetWxInfo 的摘要说明
    /// </summary>
    public class GetWxInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var openId = context.Request["OpenId"].ObjToStr();
            var dt = comfun.GetDataTableBySQL(string.Format("select top 1 * from WP_会员表 where openid='{0}'", openId));
            if (dt.Rows.Count > 0)
            {
                context.Response.Write(JsonConvert.SerializeObject(new { success = true, code = "00", message = dt.Rows[0]["wx头像"].ObjToStr() }));
            }
            else
            {
                context.Response.Write(JsonConvert.SerializeObject(new { success = false, code = "01", message = string.Empty }));
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