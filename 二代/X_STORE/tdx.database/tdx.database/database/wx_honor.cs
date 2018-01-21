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
    public class wx_honor
    {
        public static void MyInsert(string _fromUser,string _resultNum,int _isHonor)
        {

            string queryString = " INSERT INTO wx_honor (FromUser,resultNum,isHonor)";
            queryString += " VALUES (@FromUser,@resultNum,@isHonor)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@FromUser", _fromUser),
				new SqlParameter("@resultNum", _resultNum),
				new SqlParameter("@isHonor", _isHonor)
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
		public static int GetUserNum(string _fromUser)
		{
			string queryString = "select count(id) from wx_honor where FromUser='" + _fromUser + "' and DateDiff(dd,regtime,getdate())=0";
			try{
				DataTable dt = comfun.GetDataTableBySQL(queryString);
				return Convert.ToInt32(dt.Rows[0][0]);
			}
			catch(Exception ex)
			{
				throw new NotSupportedException(ex.Message);
			}
		}

    }
}
