using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using tdx.database;
using System.Web.SessionState;

namespace tdx.appv
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class orderCartDel : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        { 
            string _gid = (context.Request["guid"] != null) ? context.Request["guid"].ToString().Trim() : "";
            decimal _totalmoney = 0;
            if (_gid != "")
            {
                if (context.Session[orderAuth.getOrderCookieKey()] != null)
                {
                    DataTable dt = (DataTable)context.Session[orderAuth.getOrderCookieKey()];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        if (dr["guid"].ToString() == _gid)
                        {
                            dt.Rows.Remove(dr);
                        }
                    }
                    context.Session[orderAuth.getOrderCookieKey()] = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        _totalmoney += Convert.ToDecimal(dr[4]);
                    }
                }
            }
            context.Response.Write("￥" + _totalmoney.ToString("f2"));
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
