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
    public class orderCart_mod : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            decimal _totalmoney = 0;
            string _gid = (context.Request["guid"] != null) ? context.Request["guid"].ToString().Trim() : "";
            string _gnum = (context.Request["gnum"] != null) ? context.Request["gnum"].ToString().Trim() : "1";
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
                            //相同货物
                            int _guid = Convert.ToInt32(_gid);
                            B2C_Goods bg = new B2C_Goods(_guid);
                            if (Convert.ToDouble(_gnum) < bg.g_lowN) _gnum = bg.g_lowN.ToString();
                            dr[2] = _gnum;
                            dr[4] = (Convert.ToDecimal(dr[2]) * Convert.ToDecimal(dr[3])).ToString().Trim();
                            dr[6] = (Convert.ToDecimal(dr[2]) * Convert.ToDecimal(dr[5])).ToString().Trim();
                        }

                        _totalmoney += Convert.ToDecimal(dr[4]);
                    }
                    context.Session[orderAuth.getOrderCookieKey()] = dt;
                    //dt.Dispose();
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
