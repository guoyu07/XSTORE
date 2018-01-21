using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Web;
using System.Web.SessionState;
namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// Cancellation 的摘要说明
    /// </summary>
    public class Cancellation : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            errReg er = new errReg();
            try {
                Log.WriteLog("接口：Cancellation", "方法：ProcessRequest", "进入接口：");
             //   string member_out = context.Request["state"].ToString();
                string user_id = context.Session["UserId"].ObjToStr();
                Log.WriteLog("接口：Cancellation", "方法：ProcessRequest", "user_id：" + user_id);
                if (!string.IsNullOrEmpty(user_id))
                {
                 // string user_id=context.Request["userid"].ToString();
                    comfun.UpdateBySQL("update WP_用户表 set openid='',手机号='' where id='" + user_id + "' ");
                  //  context.Response.Write("注销成功！");
                  
                    er.state = 1;
                    er.info = "注销成功！";
                    er.guid = Guid.NewGuid().ObjToStr(); 
                    context.Session.Clear();
                    context.Response.Write(Utils.JsonSerialize(er));
                }
                else
                {
                    context.Response.Write("注销失败");
                }
            }
            catch(Exception ex) {
                Log.WriteLog("接口：Cancellation", "方法：ProcessRequest", "异常信息：" + ex.Message);
                er.state = 0;
                er.info = "未知错误，注销失败！";
                er.guid = Guid.NewGuid().ObjToStr(); ;
                context.Response.Write(Utils.JsonSerialize(er));
            }
        }
        struct errReg
        {
            public int state;
            public string info;
            public string guid;
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