 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
 
	public partial class B2C_pclass
	{
		public B2C_pclass()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("c_id", "B2C_pclass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int c_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B2C_pclass");
			strSql.Append(" where c_id=@c_id");
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4)
			};
			parameters[0].Value = c_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.B2C_pclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B2C_pclass(");
			strSql.Append("c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child)");
			strSql.Append(" values (");
			strSql.Append("@c_no,@c_name,@c_gif,@c_url,@c_sort,@c_des,@c_isactive,@c_isdel,@regtime,@c_parent,@c_level,@c_child)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@c_no", SqlDbType.VarChar,100),
					new SqlParameter("@c_name", SqlDbType.NVarChar,200),
					new SqlParameter("@c_gif", SqlDbType.VarChar,300),
					new SqlParameter("@c_url", SqlDbType.VarChar,2000),
					new SqlParameter("@c_sort", SqlDbType.Int,4),
					new SqlParameter("@c_des", SqlDbType.VarChar,300),
					new SqlParameter("@c_isactive", SqlDbType.Int,4),
					new SqlParameter("@c_isdel", SqlDbType.Int,4),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@c_parent", SqlDbType.Int,4),
					new SqlParameter("@c_level", SqlDbType.Int,4),
					new SqlParameter("@c_child", SqlDbType.Int,4)};
			parameters[0].Value = model.c_no;
			parameters[1].Value = model.c_name;
			parameters[2].Value = model.c_gif;
			parameters[3].Value = model.c_url;
			parameters[4].Value = model.c_sort;
			parameters[5].Value = model.c_des;
			parameters[6].Value = model.c_isactive;
			parameters[7].Value = model.c_isdel;
			parameters[8].Value = model.regtime;
			parameters[9].Value = model.c_parent;
			parameters[10].Value = model.c_level;
			parameters[11].Value = model.c_child;

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
		public bool Update(DTcms.Model.B2C_pclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B2C_pclass set ");
			strSql.Append("c_no=@c_no,");
			strSql.Append("c_name=@c_name,");
			strSql.Append("c_gif=@c_gif,");
			strSql.Append("c_url=@c_url,");
			strSql.Append("c_sort=@c_sort,");
			strSql.Append("c_des=@c_des,");
			strSql.Append("c_isactive=@c_isactive,");
			strSql.Append("c_isdel=@c_isdel,");
			strSql.Append("regtime=@regtime,");
			strSql.Append("c_parent=@c_parent,");
			strSql.Append("c_level=@c_level,");
			strSql.Append("c_child=@c_child");
			strSql.Append(" where c_id=@c_id");
			SqlParameter[] parameters = {
					new SqlParameter("@c_no", SqlDbType.VarChar,100),
					new SqlParameter("@c_name", SqlDbType.NVarChar,200),
					new SqlParameter("@c_gif", SqlDbType.VarChar,300),
					new SqlParameter("@c_url", SqlDbType.VarChar,2000),
					new SqlParameter("@c_sort", SqlDbType.Int,4),
					new SqlParameter("@c_des", SqlDbType.VarChar,300),
					new SqlParameter("@c_isactive", SqlDbType.Int,4),
					new SqlParameter("@c_isdel", SqlDbType.Int,4),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@c_parent", SqlDbType.Int,4),
					new SqlParameter("@c_level", SqlDbType.Int,4),
					new SqlParameter("@c_child", SqlDbType.Int,4),
					new SqlParameter("@c_id", SqlDbType.Int,4)};
			parameters[0].Value = model.c_no;
			parameters[1].Value = model.c_name;
			parameters[2].Value = model.c_gif;
			parameters[3].Value = model.c_url;
			parameters[4].Value = model.c_sort;
			parameters[5].Value = model.c_des;
			parameters[6].Value = model.c_isactive;
			parameters[7].Value = model.c_isdel;
			parameters[8].Value = model.regtime;
			parameters[9].Value = model.c_parent;
			parameters[10].Value = model.c_level;
			parameters[11].Value = model.c_child;
			parameters[12].Value = model.c_id;

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
		public bool Delete(int c_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B2C_pclass ");
			strSql.Append(" where c_id=@c_id");
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4)
			};
			parameters[0].Value = c_id;

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
		public bool DeleteList(string c_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B2C_pclass ");
			strSql.Append(" where c_id in ("+c_idlist + ")  ");
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
		public DTcms.Model.B2C_pclass GetModel(int c_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 c_id,c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child from B2C_pclass ");
			strSql.Append(" where c_id=@c_id");
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4)
			};
			parameters[0].Value = c_id;

			DTcms.Model.B2C_pclass model=new DTcms.Model.B2C_pclass();
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
		public DTcms.Model.B2C_pclass DataRowToModel(DataRow row)
		{
			DTcms.Model.B2C_pclass model=new DTcms.Model.B2C_pclass();
			if (row != null)
			{
				if(row["c_id"]!=null && row["c_id"].ToString()!="")
				{
					model.c_id=int.Parse(row["c_id"].ToString());
				}
				if(row["c_no"]!=null)
				{
					model.c_no=row["c_no"].ToString();
				}
				if(row["c_name"]!=null)
				{
					model.c_name=row["c_name"].ToString();
				}
				if(row["c_gif"]!=null)
				{
					model.c_gif=row["c_gif"].ToString();
				}
				if(row["c_url"]!=null)
				{
					model.c_url=row["c_url"].ToString();
				}
				if(row["c_sort"]!=null && row["c_sort"].ToString()!="")
				{
					model.c_sort=int.Parse(row["c_sort"].ToString());
				}
				if(row["c_des"]!=null)
				{
					model.c_des=row["c_des"].ToString();
				}
				if(row["c_isactive"]!=null && row["c_isactive"].ToString()!="")
				{
					model.c_isactive=int.Parse(row["c_isactive"].ToString());
				}
				if(row["c_isdel"]!=null && row["c_isdel"].ToString()!="")
				{
					model.c_isdel=int.Parse(row["c_isdel"].ToString());
				}
				if(row["regtime"]!=null && row["regtime"].ToString()!="")
				{
					model.regtime=DateTime.Parse(row["regtime"].ToString());
				}
				if(row["c_parent"]!=null && row["c_parent"].ToString()!="")
				{
					model.c_parent=int.Parse(row["c_parent"].ToString());
				}
				if(row["c_level"]!=null && row["c_level"].ToString()!="")
				{
					model.c_level=int.Parse(row["c_level"].ToString());
				}
				if(row["c_child"]!=null && row["c_child"].ToString()!="")
				{
					model.c_child=int.Parse(row["c_child"].ToString());
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
			strSql.Append("select c_id,c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child ");
			strSql.Append(" FROM B2C_pclass ");
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
			strSql.Append(" c_id,c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child ");
			strSql.Append(" FROM B2C_pclass ");
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
			strSql.Append("select count(1) FROM B2C_pclass ");
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
				strSql.Append("order by T.c_id desc");
			}
			strSql.Append(")AS Row, T.*  from B2C_pclass T ");
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
			parameters[0].Value = "B2C_pclass";
			parameters[1].Value = "c_id";
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

