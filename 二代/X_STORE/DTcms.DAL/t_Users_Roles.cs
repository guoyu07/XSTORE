
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:t_Users_Roles
    /// </summary>
    public partial class t_Users_Roles
    {
        public t_Users_Roles()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "t_Users_Roles");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_User_Roles");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.t_Users_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_Users_Roles(");
            strSql.Append("tenantid,userid,roleid,creationtime,creatoruserid)");
            strSql.Append(" values (");
            strSql.Append("@tenantid,@userid,@roleid,@creationtime,@creatoruserid)");
            //strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					//new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@tenantid", SqlDbType.Int ,4),
					new SqlParameter("@userid", SqlDbType.BigInt,4),
					new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@creationtime", SqlDbType.DateTime),
                    new SqlParameter("@creatoruserid", SqlDbType.DateTime)};

            parameters[0].Value = model.Tenantid;
            parameters[1].Value = model.Userid;
            parameters[2].Value = model.Roleid;
            parameters[3].Value = model.CreationTime;
            parameters[4].Value = model.CreatorUserid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.t_Users_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_Users_Roles set ");
            //strSql.Append("openid=@openid,");
            strSql.Append("tenantid=@tenantid,");
            //strSql.Append("wx头像=@wx头像,");
            //strSql.Append("手机号=@手机号,");
            strSql.Append("userid=@userid,");
            strSql.Append("roleid=@roleid,");
            strSql.Append("creationtime=@creationtime, ");
            strSql.Append("creatoruserid=@creatoruserid ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					//new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@tenantid", SqlDbType.Int ,4),
					new SqlParameter("@userid", SqlDbType.BigInt,4),
					new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@creationtime", SqlDbType.DateTime),
                    new SqlParameter("@creatoruserid", SqlDbType.DateTime)};

            parameters[0].Value = model.Tenantid;
            parameters[1].Value = model.Userid;
            parameters[2].Value = model.Roleid;
            parameters[3].Value = model.CreationTime;
            parameters[4].Value = model.CreatorUserid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM t_User_Roles ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM t_User_Roles ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.t_Users_Roles GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tenantid,userid,roleid,creationtime,creatoruserid FROM t_User_Roles ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            DTcms.Model.t_Users_Roles model = new DTcms.Model.t_Users_Roles();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.t_Users_Roles DataRowToModel(DataRow row)
        {
            DTcms.Model.t_Users_Roles model = new DTcms.Model.t_Users_Roles();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tenantid"] != null)
                {
                    model.Tenantid =int.Parse( row["tenantid"].ToString());
                }
                if (row["userid"] != null)
                {
                    model.Roleid =int.Parse( row["roleid"].ToString());
                }
                if (row["creationtime"] != null)
                {
                    model.CreationTime=DateTime.Parse( row["creationtime"].ToString());
                }
                if (row["creatoruserid"] != null)
                {
                    model.CreatorUserid = int.Parse(row["creatoruserid"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tenantid,userid,roleid,creationtime,creatoruserid ");
            strSql.Append(" FROM t_User_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,tenantid,userid,roleid,creationtime,creatoruserid ");
            strSql.Append(" FROM t_User_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_User_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  FROM t_User_Roles T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "t_Users_Roles";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

