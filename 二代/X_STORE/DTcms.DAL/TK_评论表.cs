using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:TK_评论表
    /// </summary>
    public partial class TK_评论表
    {
        public TK_评论表()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TK_评论表");
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
        public int Add(DTcms.Model.TK_评论表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TK_评论表(");
            strSql.Append("openid,发帖表id,评论内容,评论时间,备注,是否显示,parentid)");
            strSql.Append(" values (");
            strSql.Append("@openid,@发帖表id,@评论内容,@评论时间,@备注,@是否显示,@parentid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@发帖表id", SqlDbType.Int,4),
					new SqlParameter("@评论内容", SqlDbType.Text),
					new SqlParameter("@评论时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,50),
					new SqlParameter("@是否显示", SqlDbType.Int,4),
					new SqlParameter("@parentid", SqlDbType.Int,4)};
            parameters[0].Value = model.openid;
            parameters[1].Value = model.发帖表id;
            parameters[2].Value = model.评论内容;
            parameters[3].Value = model.评论时间;
            parameters[4].Value = model.备注;
            parameters[5].Value = model.是否显示;
            parameters[6].Value = model.parentid;

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
        public bool Update(DTcms.Model.TK_评论表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_评论表 set ");
            strSql.Append("openid=@openid,");
            strSql.Append("发帖表id=@发帖表id,");
            strSql.Append("评论内容=@评论内容,");
            strSql.Append("评论时间=@评论时间,");
            strSql.Append("备注=@备注,");
            strSql.Append("是否显示=@是否显示,");
            strSql.Append("parentid=@parentid");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@发帖表id", SqlDbType.Int,4),
					new SqlParameter("@评论内容", SqlDbType.Text),
					new SqlParameter("@评论时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,50),
					new SqlParameter("@是否显示", SqlDbType.Int,4),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.openid;
            parameters[1].Value = model.发帖表id;
            parameters[2].Value = model.评论内容;
            parameters[3].Value = model.评论时间;
            parameters[4].Value = model.备注;
            parameters[5].Value = model.是否显示;
            parameters[6].Value = model.parentid;
            parameters[7].Value = model.id;

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
            strSql.Append("delete from TK_评论表 ");
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
            strSql.Append("delete from TK_评论表 ");
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
        public DTcms.Model.TK_评论表 GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,openid,发帖表id,评论内容,评论时间,备注,是否显示,parentid from TK_评论表 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            DTcms.Model.TK_评论表 model = new DTcms.Model.TK_评论表();
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
        public DTcms.Model.TK_评论表 DataRowToModel(DataRow row)
        {
            DTcms.Model.TK_评论表 model = new DTcms.Model.TK_评论表();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
                if (row["发帖表id"] != null && row["发帖表id"].ToString() != "")
                {
                    model.发帖表id = int.Parse(row["发帖表id"].ToString());
                }
                if (row["评论内容"] != null)
                {
                    model.评论内容 = row["评论内容"].ToString();
                }
                if (row["评论时间"] != null && row["评论时间"].ToString() != "")
                {
                    model.评论时间 = DateTime.Parse(row["评论时间"].ToString());
                }
                if (row["备注"] != null)
                {
                    model.备注 = row["备注"].ToString();
                }
                if (row["是否显示"] != null && row["是否显示"].ToString() != "")
                {
                    model.是否显示 = int.Parse(row["是否显示"].ToString());
                }
                if (row["parentid"] != null && row["parentid"].ToString() != "")
                {
                    model.parentid = int.Parse(row["parentid"].ToString());
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
            strSql.Append("select id,openid,发帖表id,评论内容,评论时间,备注,是否显示,parentid ");
            strSql.Append(" FROM TK_评论表 ");
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
            strSql.Append(" id,openid,发帖表id,评论内容,评论时间,备注,是否显示,parentid ");
            strSql.Append(" FROM TK_评论表 ");
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
            strSql.Append("select count(1) FROM TK_评论表 ");
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
            strSql.Append(")AS Row, T.*  from TK_评论表 T ");
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
            parameters[0].Value = "TK_评论表";
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

