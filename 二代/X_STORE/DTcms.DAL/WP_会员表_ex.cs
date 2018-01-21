using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references

namespace DTcms.DAL
{
    public partial class WP_会员表
    {
        public DataTable GetVipInfo(string where,int pageindex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n  select * from   ");
            sb.Append("\r\n  (select  * ,ROW_NUMBER() over  (order by  id asc) as rownum from  (select  *  from   VipInfo where 1=1 and " + where + ") t)t2  ");
            sb.Append("\r\n  where t2.rownum between " + (10*(pageindex-1)+1) + " and "+(10*pageindex)+" ");
            DataSet ds = DbHelperSQL.Query(sb.ToString());
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }







        public DataSet GetListNew(string where )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,openid,wx昵称,wx头像,手机号,ordercount,password,email,qq,sex,jifen ");
            strSql.Append(" FROM VipInfo ");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
