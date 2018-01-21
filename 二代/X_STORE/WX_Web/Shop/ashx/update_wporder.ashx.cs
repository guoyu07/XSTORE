using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Data;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// update_wporder 的摘要说明
    /// </summary>
    public class update_wporder : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //Log.WriteLog("接口：update_wporder", "方法：processrequest", "接口进来了");
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            //订单支付orderno
            string orderno = Utils.ObjectToStr(context.Request["orderno"]);
            //Log.WriteLog("接口：update_wporder", "方法：processrequest", "订单编号：" + orderno);
            DataTable result = comfun.GetDataTableBySQL("select * from  WP_订单表 where  state='3' and  订单编号='" + orderno + "'");
            if (result.Rows.Count > 0)
            {
                er.state = 1;
                er.info = "success";
                er.guid = Guid.NewGuid().ToString();
                //Log.WriteLog("接口：update_wporder", "方法：processrequest", "Json:" + Utils.JsonSerialize(er));
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