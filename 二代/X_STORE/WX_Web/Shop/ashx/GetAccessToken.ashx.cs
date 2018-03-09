using Creatrue.kernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tdx.Weixin;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// GetAccessToken 的摘要说明
    /// </summary>
    public class GetAccessToken : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(JsonConvert.SerializeObject(new { success = true, code = "00", message = access_token() }));
        }
        public string access_token()
        {
            var dt = comfun.GetDataTableBySQL(@"select Id from WP_AccessToken where DATEADD(hour,2, create_time) > getdate()");
            //如果加了两个小时还是小于当前时间，说明token过期，需要重新获取
            if (dt.Rows.Count == 0)
            {
                var wxOath = new weixin();
                var access_token = wxOath.GetAccessToken();
                comfun.InsertBySQL(string.Format("insert into WP_AccessToken(access_token) values('{0}')", access_token));
                return access_token;
            }
            else
            {
                return dt.Rows[0]["access_token"].ObjToStr();
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