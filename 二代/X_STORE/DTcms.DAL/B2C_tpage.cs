 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	 
	public partial class B2C_tpage
	{
		public B2C_tpage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "B2C_tpage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B2C_tpage");
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
		public int Add(DTcms.Model.B2C_tpage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B2C_tpage(");
			strSql.Append("cno,shopID,gtitle,gcontent,gfile,ggif,g_isurl,g_url,g_title,g_key,g_des,g_sort,g_hits,regtime,g_r1,g_r2,g_isSys)");
			strSql.Append(" values (");
			strSql.Append("@cno,@shopID,@gtitle,@gcontent,@gfile,@ggif,@g_isurl,@g_url,@g_title,@g_key,@g_des,@g_sort,@g_hits,@regtime,@g_r1,@g_r2,@g_isSys)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@cno", SqlDbType.VarChar,200),
					new SqlParameter("@shopID", SqlDbType.Int,4),
					new SqlParameter("@gtitle", SqlDbType.VarChar,255),
					new SqlParameter("@gcontent", SqlDbType.NText),
					new SqlParameter("@gfile", SqlDbType.VarChar,255),
					new SqlParameter("@ggif", SqlDbType.VarChar,255),
					new SqlParameter("@g_isurl", SqlDbType.Int,4),
					new SqlParameter("@g_url", SqlDbType.VarChar,2000),
					new SqlParameter("@g_title", SqlDbType.VarChar,255),
					new SqlParameter("@g_key", SqlDbType.VarChar,255),
					new SqlParameter("@g_des", SqlDbType.VarChar,255),
					new SqlParameter("@g_sort", SqlDbType.Int,4),
					new SqlParameter("@g_hits", SqlDbType.Int,4),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@g_r1", SqlDbType.VarChar,2000),
					new SqlParameter("@g_r2", SqlDbType.VarChar,2000),
					new SqlParameter("@g_isSys", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.cno;
			parameters[1].Value = model.shopID;
			parameters[2].Value = model.gtitle;
			parameters[3].Value = model.gcontent;
			parameters[4].Value = model.gfile;
			parameters[5].Value = model.ggif;
			parameters[6].Value = model.g_isurl;
			parameters[7].Value = model.g_url;
			parameters[8].Value = model.g_title;
			parameters[9].Value = model.g_key;
			parameters[10].Value = model.g_des;
			parameters[11].Value = model.g_sort;
			parameters[12].Value = model.g_hits;
			parameters[13].Value = model.regtime;
			parameters[14].Value = model.g_r1;
			parameters[15].Value = model.g_r2;
			parameters[16].Value = model.g_isSys;

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
		public bool Update(DTcms.Model.B2C_tpage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B2C_tpage set ");
			strSql.Append("cno=@cno,");
			strSql.Append("shopID=@shopID,");
			strSql.Append("gtitle=@gtitle,");
			strSql.Append("gcontent=@gcontent,");
			strSql.Append("gfile=@gfile,");
			strSql.Append("ggif=@ggif,");
			strSql.Append("g_isurl=@g_isurl,");
			strSql.Append("g_url=@g_url,");
			strSql.Append("g_title=@g_title,");
			strSql.Append("g_key=@g_key,");
			strSql.Append("g_des=@g_des,");
			strSql.Append("g_sort=@g_sort,");
			strSql.Append("g_hits=@g_hits,");
			strSql.Append("regtime=@regtime,");
			strSql.Append("g_r1=@g_r1,");
			strSql.Append("g_r2=@g_r2,");
			strSql.Append("g_isSys=@g_isSys");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@cno", SqlDbType.VarChar,200),
					new SqlParameter("@shopID", SqlDbType.Int,4),
					new SqlParameter("@gtitle", SqlDbType.VarChar,255),
					new SqlParameter("@gcontent", SqlDbType.NText),
					new SqlParameter("@gfile", SqlDbType.VarChar,255),
					new SqlParameter("@ggif", SqlDbType.VarChar,255),
					new SqlParameter("@g_isurl", SqlDbType.Int,4),
					new SqlParameter("@g_url", SqlDbType.VarChar,2000),
					new SqlParameter("@g_title", SqlDbType.VarChar,255),
					new SqlParameter("@g_key", SqlDbType.VarChar,255),
					new SqlParameter("@g_des", SqlDbType.VarChar,255),
					new SqlParameter("@g_sort", SqlDbType.Int,4),
					new SqlParameter("@g_hits", SqlDbType.Int,4),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@g_r1", SqlDbType.VarChar,2000),
					new SqlParameter("@g_r2", SqlDbType.VarChar,2000),
					new SqlParameter("@g_isSys", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.cno;
			parameters[1].Value = model.shopID;
			parameters[2].Value = model.gtitle;
			parameters[3].Value = model.gcontent;
			parameters[4].Value = model.gfile;
			parameters[5].Value = model.ggif;
			parameters[6].Value = model.g_isurl;
			parameters[7].Value = model.g_url;
			parameters[8].Value = model.g_title;
			parameters[9].Value = model.g_key;
			parameters[10].Value = model.g_des;
			parameters[11].Value = model.g_sort;
			parameters[12].Value = model.g_hits;
			parameters[13].Value = model.regtime;
			parameters[14].Value = model.g_r1;
			parameters[15].Value = model.g_r2;
			parameters[16].Value = model.g_isSys;
			parameters[17].Value = model.id;

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
			strSql.Append("delete from B2C_tpage ");
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
			strSql.Append("delete from B2C_tpage ");
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
		public DTcms.Model.B2C_tpage GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,cno,shopID,gtitle,gcontent,gfile,ggif,g_isurl,g_url,g_title,g_key,g_des,g_sort,g_hits,regtime,g_r1,g_r2,g_isSys from B2C_tpage ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.B2C_tpage model=new DTcms.Model.B2C_tpage();
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
		public DTcms.Model.B2C_tpage DataRowToModel(DataRow row)
		{
			DTcms.Model.B2C_tpage model=new DTcms.Model.B2C_tpage();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["cno"]!=null)
				{
					model.cno=row["cno"].ToString();
				}
				if(row["shopID"]!=null && row["shopID"].ToString()!="")
				{
					model.shopID=int.Parse(row["shopID"].ToString());
				}
				if(row["gtitle"]!=null)
				{
					model.gtitle=row["gtitle"].ToString();
				}
				if(row["gcontent"]!=null)
				{
					model.gcontent=row["gcontent"].ToString();
				}
				if(row["gfile"]!=null)
				{
					model.gfile=row["gfile"].ToString();
				}
				if(row["ggif"]!=null)
				{
					model.ggif=row["ggif"].ToString();
				}
				if(row["g_isurl"]!=null && row["g_isurl"].ToString()!="")
				{
					model.g_isurl=int.Parse(row["g_isurl"].ToString());
				}
				if(row["g_url"]!=null)
				{
					model.g_url=row["g_url"].ToString();
				}
				if(row["g_title"]!=null)
				{
					model.g_title=row["g_title"].ToString();
				}
				if(row["g_key"]!=null)
				{
					model.g_key=row["g_key"].ToString();
				}
				if(row["g_des"]!=null)
				{
					model.g_des=row["g_des"].ToString();
				}
				if(row["g_sort"]!=null && row["g_sort"].ToString()!="")
				{
					model.g_sort=int.Parse(row["g_sort"].ToString());
				}
				if(row["g_hits"]!=null && row["g_hits"].ToString()!="")
				{
					model.g_hits=int.Parse(row["g_hits"].ToString());
				}
				if(row["regtime"]!=null && row["regtime"].ToString()!="")
				{
					model.regtime=DateTime.Parse(row["regtime"].ToString());
				}
				if(row["g_r1"]!=null)
				{
					model.g_r1=row["g_r1"].ToString();
				}
				if(row["g_r2"]!=null)
				{
					model.g_r2=row["g_r2"].ToString();
				}
				if(row["g_isSys"]!=null && row["g_isSys"].ToString()!="")
				{
					model.g_isSys=int.Parse(row["g_isSys"].ToString());
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
			strSql.Append("select id,cno,shopID,gtitle,gcontent,gfile,ggif,g_isurl,g_url,g_title,g_key,g_des,g_sort,g_hits,regtime,g_r1,g_r2,g_isSys ");
			strSql.Append(" FROM B2C_tpage ");
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
			strSql.Append(" id,cno,shopID,gtitle,gcontent,gfile,ggif,g_isurl,g_url,g_title,g_key,g_des,g_sort,g_hits,regtime,g_r1,g_r2,g_isSys ");
			strSql.Append(" FROM B2C_tpage ");
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
			strSql.Append("select count(1) FROM B2C_tpage ");
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
			strSql.Append(")AS Row, T.*  from B2C_tpage T ");
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
			parameters[0].Value = "B2C_tpage";
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

