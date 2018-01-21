using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references

namespace DTcms.DAL
{
    public partial class WP_商品表组 {
        public WP_商品表组() { }
        #region  BasicMethod
        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "WP_商品表组");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WP_商品表组");
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
        public int Add(DTcms.Model.WP_商品表组 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WP_商品表组(");
            strSql.Append("商品组合Id,商品id,数量)");
            strSql.Append(" values(");
            strSql.Append("@商品组合Id,@商品id,@数量）");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@商品组合Id",SqlDbType.Int,10),
                        new SqlParameter("@商品id",SqlDbType.Int,10),                
                        new SqlParameter("@数量",SqlDbType.Int,10)
                                        };
            parameters[0].Value = model.商品组合Id;
            parameters[0].Value = model.商品Id;
            parameters[0].Value = model.数量;
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
        public bool Update(DTcms.Model.WP_商品表组 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WP_商品表组 set ");
            strSql.Append("商品组合Id=@商品组合Id,");
            strSql.Append("商品Id=@商品ID,");
            strSql.Append("数量=@数量,");
            SqlParameter[] parameters = {
					new SqlParameter("@商品组合Id", SqlDbType.Int,4),
					new SqlParameter("@商品Id", SqlDbType.VarChar,50),
					new SqlParameter("@数量", SqlDbType.VarChar,50)
                                            };
            parameters[0].Value = model.商品组合Id;
            parameters[1].Value = model.商品Id;
            parameters[2].Value = model.数量;
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
            strSql.Append("delete from WP_商品表组 ");
            strSql.Append(" where 商品组合Id=@商品组合Id");
            SqlParameter[] parameters = {
					new SqlParameter("@商品组合Id", SqlDbType.Int,10)
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
            strSql.Append("delete from WP_商品表组 ");
            strSql.Append(" where 商品组合Id in (" + idlist + ")  ");
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
        public DTcms.Model.WP_商品表组 GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 商品组合Id,商品Id,数量 from WP_商品表 ");
            strSql.Append(" where 商品组合Id=@商品组合Id");
            SqlParameter[] parameters = {
					new SqlParameter("@商品组合Id", SqlDbType.Int,10)
			};
            parameters[0].Value = id;

            DTcms.Model.WP_商品表组 model = new DTcms.Model.WP_商品表组();
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
        public DTcms.Model.WP_商品表组 DataRowToModel(DataRow row)
        {
            DTcms.Model.WP_商品表组 model = new DTcms.Model.WP_商品表组();
            if (row != null)
            {
                if (row["商品组合Id"] != null && row["商品组合Id"].ToString() != "")
                {
                    model.商品组合Id = int.Parse(row["商品组合Id"].ToString());
                }
                if (row["商品Id"] != null && row["商品Id"].ToString() != "")
                {
                    model.商品Id = int.Parse(row["商品Id"].ToString());
                }
                if (row["数量"] != null)
                {
                    model.数量 = int.Parse(row["数量"].ToString());
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
            strSql.Append("select 商品组合Id,商品Id,数量 ");
            strSql.Append(" FROM WP_商品表组 ");
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
            strSql.Append(" 商品组合Id,商品Id,数量  ");
            strSql.Append(" FROM WP_商品表组 ");
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
            strSql.Append("select count(1) FROM WP_商品表组 ");
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
            strSql.Append(")AS Row, T.*  from WP_商品表组 T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        
        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod

    }

}
