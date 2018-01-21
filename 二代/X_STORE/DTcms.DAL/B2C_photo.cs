 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	 
	public partial class B2C_photo
	{
		public B2C_photo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "B2C_photo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B2C_photo");
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
		public int Add(DTcms.Model.B2C_photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B2C_photo(");
			strSql.Append("P_tab,P_row,P_no,cno,P_name,P_url,P_url2,P_des,P_ftype,P_fweight,P_sort,P_wdate,P_hits,P_isactive,P_isdel,regdate)");
			strSql.Append(" values (");
			strSql.Append("@P_tab,@P_row,@P_no,@cno,@P_name,@P_url,@P_url2,@P_des,@P_ftype,@P_fweight,@P_sort,@P_wdate,@P_hits,@P_isactive,@P_isdel,@regdate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@P_tab", SqlDbType.VarChar,50),
					new SqlParameter("@P_row", SqlDbType.VarChar,50),
					new SqlParameter("@P_no", SqlDbType.VarChar,50),
					new SqlParameter("@cno", SqlDbType.VarChar,50),
					new SqlParameter("@P_name", SqlDbType.VarChar,255),
					new SqlParameter("@P_url", SqlDbType.VarChar,255),
					new SqlParameter("@P_url2", SqlDbType.NVarChar,-1),
					new SqlParameter("@P_des", SqlDbType.VarChar,1000),
					new SqlParameter("@P_ftype", SqlDbType.VarChar,50),
					new SqlParameter("@P_fweight", SqlDbType.VarChar,50),
					new SqlParameter("@P_sort", SqlDbType.Int,4),
					new SqlParameter("@P_wdate", SqlDbType.DateTime),
					new SqlParameter("@P_hits", SqlDbType.Int,4),
					new SqlParameter("@P_isactive", SqlDbType.Int,4),
					new SqlParameter("@P_isdel", SqlDbType.Int,4),
					new SqlParameter("@regdate", SqlDbType.DateTime)};
			parameters[0].Value = model.P_tab;
			parameters[1].Value = model.P_row;
			parameters[2].Value = model.P_no;
			parameters[3].Value = model.cno;
			parameters[4].Value = model.P_name;
			parameters[5].Value = model.P_url;
			parameters[6].Value = model.P_url2;
			parameters[7].Value = model.P_des;
			parameters[8].Value = model.P_ftype;
			parameters[9].Value = model.P_fweight;
			parameters[10].Value = model.P_sort;
			parameters[11].Value = model.P_wdate;
			parameters[12].Value = model.P_hits;
			parameters[13].Value = model.P_isactive;
			parameters[14].Value = model.P_isdel;
			parameters[15].Value = model.regdate;

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
		public bool Update(DTcms.Model.B2C_photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B2C_photo set ");
			strSql.Append("P_tab=@P_tab,");
			strSql.Append("P_row=@P_row,");
			strSql.Append("P_no=@P_no,");
			strSql.Append("cno=@cno,");
			strSql.Append("P_name=@P_name,");
			strSql.Append("P_url=@P_url,");
			strSql.Append("P_url2=@P_url2,");
			strSql.Append("P_des=@P_des,");
			strSql.Append("P_ftype=@P_ftype,");
			strSql.Append("P_fweight=@P_fweight,");
			strSql.Append("P_sort=@P_sort,");
			strSql.Append("P_wdate=@P_wdate,");
			strSql.Append("P_hits=@P_hits,");
			strSql.Append("P_isactive=@P_isactive,");
			strSql.Append("P_isdel=@P_isdel,");
			strSql.Append("regdate=@regdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@P_tab", SqlDbType.VarChar,50),
					new SqlParameter("@P_row", SqlDbType.VarChar,50),
					new SqlParameter("@P_no", SqlDbType.VarChar,50),
					new SqlParameter("@cno", SqlDbType.VarChar,50),
					new SqlParameter("@P_name", SqlDbType.VarChar,255),
					new SqlParameter("@P_url", SqlDbType.VarChar,255),
					new SqlParameter("@P_url2", SqlDbType.NVarChar,-1),
					new SqlParameter("@P_des", SqlDbType.VarChar,1000),
					new SqlParameter("@P_ftype", SqlDbType.VarChar,50),
					new SqlParameter("@P_fweight", SqlDbType.VarChar,50),
					new SqlParameter("@P_sort", SqlDbType.Int,4),
					new SqlParameter("@P_wdate", SqlDbType.DateTime),
					new SqlParameter("@P_hits", SqlDbType.Int,4),
					new SqlParameter("@P_isactive", SqlDbType.Int,4),
					new SqlParameter("@P_isdel", SqlDbType.Int,4),
					new SqlParameter("@regdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.P_tab;
			parameters[1].Value = model.P_row;
			parameters[2].Value = model.P_no;
			parameters[3].Value = model.cno;
			parameters[4].Value = model.P_name;
			parameters[5].Value = model.P_url;
			parameters[6].Value = model.P_url2;
			parameters[7].Value = model.P_des;
			parameters[8].Value = model.P_ftype;
			parameters[9].Value = model.P_fweight;
			parameters[10].Value = model.P_sort;
			parameters[11].Value = model.P_wdate;
			parameters[12].Value = model.P_hits;
			parameters[13].Value = model.P_isactive;
			parameters[14].Value = model.P_isdel;
			parameters[15].Value = model.regdate;
			parameters[16].Value = model.id;

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
			strSql.Append("delete from B2C_photo ");
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
			strSql.Append("delete from B2C_photo ");
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
		public DTcms.Model.B2C_photo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,P_tab,P_row,P_no,cno,P_name,P_url,P_url2,P_des,P_ftype,P_fweight,P_sort,P_wdate,P_hits,P_isactive,P_isdel,regdate from B2C_photo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.B2C_photo model=new DTcms.Model.B2C_photo();
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
		public DTcms.Model.B2C_photo DataRowToModel(DataRow row)
		{
			DTcms.Model.B2C_photo model=new DTcms.Model.B2C_photo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["P_tab"]!=null)
				{
					model.P_tab=row["P_tab"].ToString();
				}
				if(row["P_row"]!=null)
				{
					model.P_row=row["P_row"].ToString();
				}
				if(row["P_no"]!=null)
				{
					model.P_no=row["P_no"].ToString();
				}
				if(row["cno"]!=null)
				{
					model.cno=row["cno"].ToString();
				}
				if(row["P_name"]!=null)
				{
					model.P_name=row["P_name"].ToString();
				}
				if(row["P_url"]!=null)
				{
					model.P_url=row["P_url"].ToString();
				}
				if(row["P_url2"]!=null)
				{
					model.P_url2=row["P_url2"].ToString();
				}
				if(row["P_des"]!=null)
				{
					model.P_des=row["P_des"].ToString();
				}
				if(row["P_ftype"]!=null)
				{
					model.P_ftype=row["P_ftype"].ToString();
				}
				if(row["P_fweight"]!=null)
				{
					model.P_fweight=row["P_fweight"].ToString();
				}
				if(row["P_sort"]!=null && row["P_sort"].ToString()!="")
				{
					model.P_sort=int.Parse(row["P_sort"].ToString());
				}
				if(row["P_wdate"]!=null && row["P_wdate"].ToString()!="")
				{
					model.P_wdate=DateTime.Parse(row["P_wdate"].ToString());
				}
				if(row["P_hits"]!=null && row["P_hits"].ToString()!="")
				{
					model.P_hits=int.Parse(row["P_hits"].ToString());
				}
				if(row["P_isactive"]!=null && row["P_isactive"].ToString()!="")
				{
					model.P_isactive=int.Parse(row["P_isactive"].ToString());
				}
				if(row["P_isdel"]!=null && row["P_isdel"].ToString()!="")
				{
					model.P_isdel=int.Parse(row["P_isdel"].ToString());
				}
				if(row["regdate"]!=null && row["regdate"].ToString()!="")
				{
					model.regdate=DateTime.Parse(row["regdate"].ToString());
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
			strSql.Append("select id,P_tab,P_row,P_no,cno,P_name,P_url,P_url2,P_des,P_ftype,P_fweight,P_sort,P_wdate,P_hits,P_isactive,P_isdel,regdate ");
			strSql.Append(" FROM B2C_photo ");
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
			strSql.Append(" id,P_tab,P_row,P_no,cno,P_name,P_url,P_url2,P_des,P_ftype,P_fweight,P_sort,P_wdate,P_hits,P_isactive,P_isdel,regdate ");
			strSql.Append(" FROM B2C_photo ");
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
			strSql.Append("select count(1) FROM B2C_photo ");
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
			strSql.Append(")AS Row, T.*  from B2C_photo T ");
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
			parameters[0].Value = "B2C_photo";
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

