using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references

namespace DTcms.DAL
{
    public partial class WP_地区表
    {
        public WP_地区表()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "WP_地区表"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WP_地区表");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.WP_地区表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WP_地区表(");
			strSql.Append("名称,父级id,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id)");
			strSql.Append(" values (");
			strSql.Append("@名称,@父级id,@是否删除,@删除人id,@删除时间,@最后修改时间,@最后修改人id,@创建时间,@创建人id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@名称", SqlDbType.VarChar,50),
					new SqlParameter("@父级id", SqlDbType.Int,4),
					new SqlParameter("@是否删除", SqlDbType.Bit),
					new SqlParameter("@删除人id", SqlDbType.Int,4),
					new SqlParameter("@删除时间", SqlDbType.DateTime),
                    new SqlParameter("@最后修改时间",SqlDbType.DateTime),
                                        new SqlParameter("最后修改人id",SqlDbType.Int,4),
                                        new SqlParameter("创建时间",SqlDbType.DateTime),
                                        new SqlParameter("创建人id",SqlDbType.Int,4)};
			parameters[0].Value = model.名称;
			parameters[1].Value = model.父级id;
			parameters[2].Value = model.是否删除;
			parameters[3].Value = model.删除人id;
			parameters[4].Value = model.删除时间;
            parameters[5].Value = model.最后修改时间;
            parameters[6].Value = model.最后修改人id;
            parameters[7].Value = model.创建时间;
            parameters[8].Value = model.创建人id;
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(DTcms.Model.WP_地区表 model)
		{
						StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WP_地区表(");
strSql.Append("名称,父级id,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id)");
			strSql.Append(" values (");
			strSql.Append("@名称,@父级id,@是否删除,@删除人id,@删除时间,@最后修改时间,@最后修改人id,@创建时间,@创建人id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@名称", SqlDbType.VarChar,50),
					new SqlParameter("@父级id", SqlDbType.Int,4),
					new SqlParameter("@是否删除", SqlDbType.Bit),
					new SqlParameter("@删除人id", SqlDbType.Int,4),
					new SqlParameter("@删除时间", SqlDbType.DateTime),
                    new SqlParameter("@最后修改时间",SqlDbType.DateTime),
                                        new SqlParameter("最后修改人id",SqlDbType.Int,4),
                                        new SqlParameter("创建时间",SqlDbType.DateTime),
                                        new SqlParameter("创建人id",SqlDbType.Int,4)};
			parameters[0].Value = model.名称;
			parameters[1].Value = model.父级id;
			parameters[2].Value = model.是否删除;
			parameters[3].Value = model.删除人id;
			parameters[4].Value = model.删除时间;
            parameters[5].Value = model.最后修改时间;
            parameters[6].Value = model.最后修改人id;
            parameters[7].Value = model.创建时间;
            parameters[8].Value = model.创建人id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WP_地区表 ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WP_地区表 ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public DTcms.Model.WP_地区表 GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,名称,父级id,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id from WP_地区表 ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.WP_地区表 model=new DTcms.Model.WP_地区表();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public DTcms.Model.WP_地区表 DataRowToModel(DataRow row)
		{
			DTcms.Model.WP_地区表 model=new DTcms.Model.WP_地区表();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["名称"]!=null)
				{
					model.名称=row["名称"].ToString();
				}
				if(row["父级id"]!=null && row["父级id"].ToString()!="")
				{
					model.父级id=int.Parse(row["父级id"].ToString());
				}
				if(row["是否删除"]!=null && row["是否删除"].ToString()!="")
				{
					model.是否删除=Boolean.Parse(row["是否删除"].ToString());
				}
				if(row["删除人id"]!=null && row["删除人id"].ToString()!="")
				{
					model.删除人id=int.Parse(row["删除人id"].ToString());
				}
				if(row["删除时间"]!=null && row["删除时间"].ToString()!="")
				{
					model.删除时间=DateTime.Parse(row["删除时间"].ToString());
				}
               if(row["最后修改时间"]!=null && row["最后修改时间"].ToString()!="")
				{
					model.最后修改时间=DateTime.Parse(row["最后修改时间"].ToString());
				}
                if(row["最后修改人id"]!=null && row["最后修改人di"].ToString()!="")
				{
					model.最后修改人id=int.Parse(row["最后修改人id"].ToString());
				}
                if(row["创建时间"]!=null && row["创建时间"].ToString()!="")
				{
					model.创建时间=DateTime.Parse(row["创建时间"].ToString());
                 }
                  if(row["创建人id"]!=null && row["创建人id"].ToString()!="")
				{
					model.创建人id=int.Parse(row["创建人id"].ToString());
                  }     
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,名称,父级id,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id from WP_地区表 ");
			strSql.Append(" FROM WP_地区表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" id,名称,父级id,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id from WP_地区表 ");
			strSql.Append(" FROM WP_地区表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM WP_地区表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from WP_地区表 T ");
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
