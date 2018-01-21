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
    /// GetCartNum 的摘要说明
    /// </summary>
    public class GetCartNum : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string kwid = context.Request["kwid"].ToString();
                Log.WriteLog("接口：GetCartNum", "方法：ProcessRequest", "kwid：" + kwid);
                string openid = HttpContext.Current.Session["OpenId"].ObjToStr();
                Log.WriteLog("接口：GetCartNum", "方法：ProcessRequest", "openid：" + openid);
                string sql_cart = "select * from wp_购物车 where 是否结算=0 and 库位id = " + kwid + " and openid='" + openid + "'";
                Log.WriteLog("接口：GetCartNum", "方法：ProcessRequest", "sql_cart：" + sql_cart);
                DataTable dt_cart = comfun.GetDataTableBySQL(sql_cart);
                context.Response.Write(Utils.JsonSerialize(new { state = 0, info = "获取成功", data = dt_cart.Rows.Count }));
            }
            catch(Exception ex)
            {
                
                context.Response.Write(Utils.JsonSerialize(new { state = 1, info = "数据异常", exception = ex.Message }));
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