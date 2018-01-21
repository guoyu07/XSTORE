using DTcms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Talk
{
    /// <summary>
    /// AddHuiFu 的摘要说明
    /// </summary>
    public class AddHuiFu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string openid=context.Request["openid"];
            string id = context.Request["id"];
            string textarea_jj = context.Request["textarea_jj"];

            TK_评论表 tk评论表 = new TK_评论表();
            tk评论表.openid = openid;
            tk评论表.发帖表id = Convert.ToInt32(id);
            tk评论表.评论内容 = textarea_jj;
            tk评论表.评论时间 = DateTime.Now;
            int sp = new DTcms.BLL.TK_评论表().Add(tk评论表);
            if (sp > 0)
            {
                context.Response.Write("1");
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