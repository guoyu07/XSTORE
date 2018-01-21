using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Talk
{
    /// <summary>
    /// AddTalk 的摘要说明
    /// </summary>
    public class AddTalk : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string bianhao=context.Request["bianhao"];
            string cno = context.Request["cno"];
            string title = context.Request["title"];
            string textarea_jj = context.Request["textarea_jj"];
            //string regtime = context.Request["regtime"];
            string openid = context.Request["openid"];
            DTcms.Model.TK_发帖表 tk发帖表 = new DTcms.Model.TK_发帖表();
            tk发帖表.编号 = bianhao;
            tk发帖表.类别号 = cno;
            tk发帖表.名称 = title;
            tk发帖表.内容 = textarea_jj;
            tk发帖表.创建时间 = DateTime.Now;
            tk发帖表.openid = openid;
            tk发帖表.是否显示 = 1;
            tk发帖表.是否置顶 = 0;
            int sp = new DTcms.BLL.TK_发帖表().Add(tk发帖表);
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