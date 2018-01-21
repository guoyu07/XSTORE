using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using tdx.kernel;

namespace tdx.database
{
    public class zagt_logs
    {
        public static void MyInsert(string _logs)
        {
            HttpContext context = HttpContext.Current;
            string[] uInfo = (context.Session["wInfo"]!=null)?(string[])context.Session["wInfo"]:null;
            string _uname = (uInfo != null) ? uInfo[1] : "";

            string queryString = " INSERT INTO zagt_logs (Lmsg,Luname,Lip)";
            queryString += " VALUES (@lmsg,@Luname,@Lip)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@lmsg", _logs),
                new SqlParameter("@Luname", _uname),
                new SqlParameter("@Lip", context.Request.UserHostAddress)
            };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 一次彻底删除一组监控
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from zagt_logs where id in (" + _ids + ")";
            try
            {
                comfun.UpdateBySQL(sql);
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(int currentpage, string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from zagt_logs where " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from zagt_logs where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select * from zagt_logs order id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
