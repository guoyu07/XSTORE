using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using tdx.database;

namespace tdx.memb.man
{
    /// <summary>
    /// CheckMP 的摘要说明
    /// </summary>
    public class CheckMP : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int _wid = HttpContext.Current.Session["wID"] != null ? Convert.ToInt32(HttpContext.Current.Session["wID"].ToString().Trim()) : 0;
            if (_wid == 0)
            {
                ///没有登录
                context.Response.Write("noL");
                return;
            }
            DataTable dt = wx_mp.GetWxList(_wid);
            if (dt.Rows.Count > 0)
            {
                DataTable dtmenu = B2C_menu.GetList("*", " c_no like '001%' ");
                if (dtmenu.Rows.Count > 1)
                {
                    // 有公众号并且有栏目
                    context.Response.Write("yes");
                }
                else
                {
                    ///没有栏目菜单
                    context.Response.Write("noC");
                }

                return;
            }
            else
            {
                context.Response.Write("noMP");
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