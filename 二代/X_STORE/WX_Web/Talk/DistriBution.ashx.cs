using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Talk
{
    /// <summary>
    /// DistriBution 的摘要说明
    /// </summary>
    public class DistriBution : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string openid = context.Request["openidsss"].ToString();
            string active = context.Request["activesss"].ToString();
            string name = context.Request["name"];
            string tel = context.Request["tel"];
            if (active == "-2" || active == "-1")
            {
                string sql = " update B2C_mem set M_isactive=0,M_truename='" + name + "',M_mobile='" + tel + "' where  openid='" + openid + "'";
                int count = DbHelperSQL.ExecuteSql(sql);
                if (count > 0)
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("申请提交失败");
                }
            }
            else
            {
                context.Response.Write("申请提交失败");
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