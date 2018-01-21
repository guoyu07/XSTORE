using Creatrue.kernel;
using DTcms.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// AlipayEnter 的摘要说明
    /// </summary>
    public class AlipayEnter : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");
            //Log.WriteLog("接口：AlipayEnter", "方法：ProcessRequest", "进入了方法");
            errReg er = new errReg();
            try
            {
                string order_no = context.Request["order"].ObjToStr();
                Log.WriteLog("接口：AlipayEnter", "方法：ProcessRequest", "order_no：" + order_no);
                string sql_select = @"select * from WP_订单表 where 订单编号='" + order_no + "' and  state in(2,3,5)";
                DataTable dt_select = comfun.GetDataTableBySQL(sql_select);
                if (dt_select.Rows.Count > 0)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "success" }));
                }
                else
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { state = 0, info = "fail" }));
                }
            }
            catch(Exception ex)
            {
                Log.WriteLog("接口：AlipayEnter", "方法：ProcessRequest", "异常信息：" + ex.Message);
                er.state = 0;
                er.info = "fail";
                context.Response.Write(Utils.JsonSerialize(er));
            }
        }

        struct errReg
        {
            public int state;
            public string info;
            public List<Dictionary<string, object>> data;
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