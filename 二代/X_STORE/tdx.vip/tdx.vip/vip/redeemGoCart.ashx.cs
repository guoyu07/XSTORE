using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using System.Web.SessionState;
using System.Web.Services;
namespace tdx.vip
{
    /// <summary>
    /// redeemGoCart 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class redeemGoCart : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string wwx = context.Request.Form["wwx"];
            string wwv = context.Request.Form["wwv"];
            string gid = context.Request.Form["gid"];
            string _sql = "select top 1 * from B2C_Goods where id=" + gid + "";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable orderTable = new DataTable();
                orderTable.Columns.Add("guid");
                orderTable.Columns.Add("g_name");
                orderTable.Columns.Add("g_num");
                orderTable.Columns.Add("g_price");
                orderTable.Columns.Add("g_amt");
                orderTable.Columns.Add("g_cent");
                orderTable.Columns.Add("g_allcent");
                orderTable.Columns.Add("g_gif");
                orderTable.Columns.Add("g_des");

                DataRow row = orderTable.NewRow();
                row[0] = dt.Rows[0]["id"];
                row[1] = dt.Rows[0]["g_name"];
                row[2] = 1;
                row[3] = 0;
                row[4] = 0;
                row[5] = dt.Rows[0]["g_cent"];
                row[6] = 0;
                row[7] = 0;
                row[8] = 0;
                orderTable.Rows.Add(row);
                context.Session[orderAuth.getOrderCookieKey()] = orderTable;
            }
            context.Response.Write("http://localhost:15925/appx/cart.aspx?WWX=" + wwx + "&WWV="+wwv+"");
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