using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:TK_发帖表
    /// </summary>
    public partial class TK_发帖表
    {
        public TK_发帖表()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TK_发帖表");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.TK_发帖表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TK_发帖表(");
            strSql.Append("编号,类别号,名称,内容,创建时间,openid,是否显示,是否置顶)");
            strSql.Append(" values (");
            strSql.Append("@编号,@类别号,@名称,@内容,@创建时间,@openid,@是否显示,@是否置顶)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@编号", SqlDbType.VarChar,50),
					new SqlParameter("@类别号", SqlDbType.VarChar,50),
					new SqlParameter("@名称", SqlDbType.VarChar,200),
					new SqlParameter("@内容", SqlDbType.NText),
					new SqlParameter("@创建时间", SqlDbType.DateTime),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@是否显示", SqlDbType.Int,4),
					new SqlParameter("@是否置顶", SqlDbType.Int,4)};
            parameters[0].Value = model.编号;
            parameters[1].Value = model.类别号;
            parameters[2].Value = model.名称;
            parameters[3].Value = model.内容;
            parameters[4].Value = model.创建时间;
            parameters[5].Value = model.openid;
            parameters[6].Value = model.是否显示;
            parameters[7].Value = model.是否置顶;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.TK_发帖表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_发帖表 set ");
            strSql.Append("编号=@编号,");
            strSql.Append("类别号=@类别号,");
            strSql.Append("名称=@名称,");
            strSql.Append("内容=@内容,");
            strSql.Append("创建时间=@创建时间,");
            strSql.Append("openid=@openid,");
            strSql.Append("是否显示=@是否显示,");
            strSql.Append("是否置顶=@是否置顶");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@编号", SqlDbType.VarChar,50),
					new SqlParameter("@类别号", SqlDbType.VarChar,50),
					new SqlParameter("@名称", SqlDbType.VarChar,200),
					new SqlParameter("@内容", SqlDbType.NText),
					new SqlParameter("@创建时间", SqlDbType.DateTime),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@是否显示", SqlDbType.Int,4),
					new SqlParameter("@是否置顶", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.编号;
            parameters[1].Value = model.类别号;
            parameters[2].Value = model.名称;
            parameters[3].Value = model.内容;
            parameters[4].Value = model.创建时间;
            parameters[5].Value = model.openid;
            parameters[6].Value = model.是否显示;
            parameters[7].Value = model.是否置顶;
            parameters[8].Value = model.id;

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
            strSql.Append("delete from TK_发帖表 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
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
            strSql.Append("delete from TK_发帖表 ");
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
        public DTcms.Model.TK_发帖表 GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,编号,类别号,名称,内容,创建时间,openid,是否显示,是否置顶 from TK_发帖表 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            DTcms.Model.TK_发帖表 model = new DTcms.Model.TK_发帖表();
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
        public DTcms.Model.TK_发帖表 DataRowToModel(DataRow row)
        {
            DTcms.Model.TK_发帖表 model = new DTcms.Model.TK_发帖表();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["编号"] != null)
                {
                    model.编号 = row["编号"].ToString();
                }
                if (row["类别号"] != null)
                {
                    model.类别号 = row["类别号"].ToString();
                }
                if (row["名称"] != null)
                {
                    model.名称 = row["名称"].ToString();
                }
                if (row["内容"] != null)
                {
                    model.内容 = row["内容"].ToString();
                }
                if (row["创建时间"] != null && row["创建时间"].ToString() != "")
                {
                    model.创建时间 = DateTime.Parse(row["创建时间"].ToString());
                }
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
                if (row["是否显示"] != null && row["是否显示"].ToString() != "")
                {
                    model.是否显示 = int.Parse(row["是否显示"].ToString());
                }
                if (row["是否置顶"] != null && row["是否置顶"].ToString() != "")
                {
                    model.是否置顶 = int.Parse(row["是否置顶"].ToString());
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
            strSql.Append("select id,编号,类别号,名称,内容,创建时间,openid,是否显示,是否置顶 ");
            strSql.Append(" FROM TK_发帖表 ");
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
            strSql.Append(" id,编号,类别号,名称,内容,创建时间,openid,是否显示,是否置顶 ");
            strSql.Append(" FROM TK_发帖表 ");
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
            strSql.Append("select count(1) FROM TK_发帖表 ");
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
            strSql.Append(")AS Row, T.*  from TK_发帖表 T ");
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
            parameters[0].Value = "TK_发帖表";
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

