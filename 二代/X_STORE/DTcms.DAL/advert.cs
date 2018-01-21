using System;
using System.Collections.Generic;
using System.Text;
using DTcms.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DTcms.DAL
{
    public  class advert
    {
        public advert() { }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "advert");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from advert");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.advert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into advert(");
            strSql.Append("code,name,array,types,类别号)");
            strSql.Append(" values (");
            strSql.Append("@code,@name,@array,@types,@类别号)");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@array", SqlDbType.NText,10731231),
                    new SqlParameter("@types", SqlDbType.Int,10),
                                        					new SqlParameter("@类别号", SqlDbType.VarChar,50),};

            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.array;
            parameters[3].Value = model.types;
            parameters[4].Value = model.类别号;
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
        public bool Update(DTcms.Model.advert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update advert set ");
            strSql.Append("code=@code,");
            strSql.Append("name=@name,");
            strSql.Append("array=@array,");
            strSql.Append(" 类别号=@类别号 ");strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
                    new SqlParameter("@array", SqlDbType.NText,10731231),
                    new SqlParameter("@id", SqlDbType.Int,4),
                                        new SqlParameter("@类别号", SqlDbType.VarChar,50)
                    };
            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.array;
            parameters[3].Value = model.id;
            parameters[4].Value = model.类别号;
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
            strSql.Append("delete from advert ");
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
            strSql.Append("delete from advert ");
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
        public DTcms.Model.advert GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,code,name,array,类别号 from advert ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            DTcms.Model.advert model = new DTcms.Model.advert();
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
        public DTcms.Model.advert DataRowToModel(DataRow row)
        {
            DTcms.Model.advert model = new DTcms.Model.advert();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["array"] != null)
                {
                    model.array = row["array"].ToString();
                }
                if (row["类别号"] != null)
                {
                    model.类别号 = row["类别号"].ToString();
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
            strSql.Append("select id,code,name,array,类别号 ");
            strSql.Append(" FROM advert ");
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
            strSql.Append(" id,code,name,array,类别号 ");
            strSql.Append(" FROM advert ");
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
            strSql.Append("select count(1) FROM advert ");
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
            strSql.Append(")AS Row, T.*  from advert T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

    }
}
