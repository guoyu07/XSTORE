using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// CartDel 的摘要说明
    /// </summary>
    public class CartDel : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");
            errReg er = new errReg();
            string cart_id = context.Request["CartId"].ToString();
            string sql = "delete WP_购物车 where id='" + cart_id + "'";
            comfun.DelbySQL(sql);
            string openid = context.Session["OpenId"].ObjToStr();
            string sql_price = @"select sum(单价) as price from wp_购物车 where 是否结算=0 and openid='" + openid + "'";
            DataTable dt_price = comfun.GetDataTableBySQL(sql_price);
            string price = "";
            int state = 0;
            if (dt_price.Rows.Count > 0)
            {
                price = dt_price.Rows[0]["price"].ObjToStr();
                state = 1;
            }
            else
            {
                state = 0;
                price = "0";
            }
            er.state = state;
            er.info = price;
            er.guid = Guid.NewGuid().ToString();
            context.Response.Write(Utils.JsonSerialize(er));
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