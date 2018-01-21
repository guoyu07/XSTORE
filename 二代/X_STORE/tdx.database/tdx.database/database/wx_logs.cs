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
using Creatrue.kernel;

namespace tdx.database
{
    public class wx_logs
    {
        public static void MyInsert(string _logs)
        {

            string queryString = " INSERT INTO wx_logs (Lmsg)";
            queryString += " VALUES (@lmsg)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@lmsg", _logs)};

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
        public static void MyInsert(string _logs,string _fromUser,string _toUser)
        {

            string queryString = " INSERT INTO wx_logs (Lmsg,fromUser,toUser)";
            queryString += " VALUES (@lmsg,@fromUser,@toUser)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@lmsg", _logs),
                new SqlParameter("@fromUser", _fromUser),
                new SqlParameter("@toUser", _toUser)};

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
        public static void MyInsert(string _logs, string _fromUser, string _toUser,string _type)
        {

            string queryString = " INSERT INTO wx_logs (Lmsg,fromUser,toUser,Ltype)";
            queryString += " VALUES (@lmsg,@fromUser,@toUser,@Ltype)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@lmsg", _logs),
                new SqlParameter("@fromUser", _fromUser),
                new SqlParameter("@toUser", _toUser),
                new SqlParameter("@Ltype", _type)};

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
        public static void MyInsert(string _logs, string _fromUser, string _toUser, string _type,string _rmsg)
        {

            string queryString = " INSERT INTO wx_logs (Lmsg,fromUser,toUser,Ltype,isReply,LRe)";
            queryString += " VALUES (@lmsg,@fromUser,@toUser,@Ltype,1,@LRe)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@lmsg", _logs),
                new SqlParameter("@fromUser", _fromUser),
                new SqlParameter("@toUser", _toUser),
                new SqlParameter("@Ltype", _type),
                new SqlParameter("@LRe", _rmsg)};

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
        public static DataTable GetList(int _currentpage, string _dzd, string _sql, int pagesize)
        {
            DataTable dt = new DataTable();
            try
            {
                string _sql2 = "select " + _dzd + ",(row_number() over(order by id)) as rown from wx_logs where " + _sql;
                _sql2 = "with a as (" + _sql2 + ") select top " + pagesize + " * from a where rown>" + (_currentpage - 1) * pagesize + " order by rown";
                dt = comfun.GetDataTableBySQL(_sql2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
