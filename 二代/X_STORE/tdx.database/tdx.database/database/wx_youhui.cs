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
using tdx.database;
using Creatrue.kernel;

namespace tdx.database
{
    public class wx_youhui
    {
        public static void MyInsert(string _fromUser,string _yhNo)
        {

            string queryString = " INSERT INTO wx_youhui (FromUser,yh_no)";
            queryString += " VALUES (@FromUser,@yh_no)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@FromUser", _fromUser),
				new SqlParameter("@yh_no", _yhNo) 
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
		public static void setYHDel(string _fromUser,string _yhNo)
		{
			string queryString = "update wx_youhui set isA=0 where fromuser=@FromUser and yh_no=@yh_no";
			SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@FromUser", _fromUser),
				new SqlParameter("@yh_no", _yhNo) 
					};
			try{
				 comfun con = new comfun();
                 con.ExecuteNonQuery(queryString, paras); 
			}
			catch(Exception ex)
			{
				throw new NotSupportedException(ex.Message);
			}
		}

    }
}
