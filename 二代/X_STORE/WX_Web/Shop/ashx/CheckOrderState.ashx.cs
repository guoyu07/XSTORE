using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// CheckOrderState 的摘要说明
    /// </summary>
    public class CheckOrderState : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string order_no = context.Request["orderno"].ObjToStr();
                string sql_state = "select * from WP_订单表 where 订单编号='" + order_no + "' and state = 3";
                Log.WriteLog("接口：paySucessOpenbox", "方法：ProcessRequest", "sql_state:" + sql_state);
                DataTable dt_state = comfun.GetDataTableBySQL(sql_state);
                if (dt_state.Rows.Count > 0)
                {
                    context.Response.Write(true);

                }
                else
                {
                    context.Response.Write(false);
                }
            }
            catch (Exception ex)
            {

                context.Response.Write(false);
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