 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{ 
	public partial class B2C_tmsg
	{
		public B2C_tmsg()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "B2C_tmsg"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B2C_tmsg");
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
		public int Add(DTcms.Model.B2C_tmsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B2C_tmsg(");
			strSql.Append("cno,shopID,t_title,t_author,t_source,t_gif,t_msg,t_isurl,t_url,t_filename,t_sort,t_iflag,t_cflag,t_hits,t_wdate,regdate,t_isactive,t_isdel,t_isHead,t_ischead,t_key,t_des,t_isF,app_id,file_id)");
			strSql.Append(" values (");
			strSql.Append("@cno,@shopID,@t_title,@t_author,@t_source,@t_gif,@t_msg,@t_isurl,@t_url,@t_filename,@t_sort,@t_iflag,@t_cflag,@t_hits,@t_wdate,@regdate,@t_isactive,@t_isdel,@t_isHead,@t_ischead,@t_key,@t_des,@t_isF,@app_id,@file_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@cno", SqlDbType.VarChar,200),
					new SqlParameter("@shopID", SqlDbType.Int,4),
					new SqlParameter("@t_title", SqlDbType.VarChar,255),
					new SqlParameter("@t_author", SqlDbType.VarChar,50),
					new SqlParameter("@t_source", SqlDbType.VarChar,255),
					new SqlParameter("@t_gif", SqlDbType.VarChar,255),
					new SqlParameter("@t_msg", SqlDbType.NText),
					new SqlParameter("@t_isurl", SqlDbType.Int,4),
					new SqlParameter("@t_url", SqlDbType.VarChar,255),
					new SqlParameter("@t_filename", SqlDbType.VarChar,255),
					new SqlParameter("@t_sort", SqlDbType.Int,4),
					new SqlParameter("@t_iflag", SqlDbType.Int,4),
					new SqlParameter("@t_cflag", SqlDbType.Int,4),
					new SqlParameter("@t_hits", SqlDbType.Int,4),
					new SqlParameter("@t_wdate", SqlDbType.DateTime),
					new SqlParameter("@regdate", SqlDbType.DateTime),
					new SqlParameter("@t_isactive", SqlDbType.Int,4),
					new SqlParameter("@t_isdel", SqlDbType.Int,4),
					new SqlParameter("@t_isHead", SqlDbType.Int,4),
					new SqlParameter("@t_ischead", SqlDbType.Int,4),
					new SqlParameter("@t_key", SqlDbType.VarChar,255),
					new SqlParameter("@t_des", SqlDbType.VarChar,255),
					new SqlParameter("@t_isF", SqlDbType.TinyInt,1),
					new SqlParameter("@app_id", SqlDbType.VarChar,255),
					new SqlParameter("@file_id", SqlDbType.VarChar,255)};
			parameters[0].Value = model.cno;
			parameters[1].Value = model.shopID;
			parameters[2].Value = model.t_title;
			parameters[3].Value = model.t_author;
			parameters[4].Value = model.t_source;
			parameters[5].Value = model.t_gif;
			parameters[6].Value = model.t_msg;
			parameters[7].Value = model.t_isurl;
			parameters[8].Value = model.t_url;
			parameters[9].Value = model.t_filename;
			parameters[10].Value = model.t_sort;
			parameters[11].Value = model.t_iflag;
			parameters[12].Value = model.t_cflag;
			parameters[13].Value = model.t_hits;
			parameters[14].Value = model.t_wdate;
			parameters[15].Value = model.regdate;
			parameters[16].Value = model.t_isactive;
			parameters[17].Value = model.t_isdel;
			parameters[18].Value = model.t_isHead;
			parameters[19].Value = model.t_ischead;
			parameters[20].Value = model.t_key;
			parameters[21].Value = model.t_des;
			parameters[22].Value = model.t_isF;
			parameters[23].Value = model.app_id;
			parameters[24].Value = model.file_id;

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
		public bool Update(DTcms.Model.B2C_tmsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B2C_tmsg set ");
			strSql.Append("cno=@cno,");
			strSql.Append("shopID=@shopID,");
			strSql.Append("t_title=@t_title,");
			strSql.Append("t_author=@t_author,");
			strSql.Append("t_source=@t_source,");
			strSql.Append("t_gif=@t_gif,");
			strSql.Append("t_msg=@t_msg,");
			strSql.Append("t_isurl=@t_isurl,");
			strSql.Append("t_url=@t_url,");
			strSql.Append("t_filename=@t_filename,");
			strSql.Append("t_sort=@t_sort,");
			strSql.Append("t_iflag=@t_iflag,");
			strSql.Append("t_cflag=@t_cflag,");
			strSql.Append("t_hits=@t_hits,");
			strSql.Append("t_wdate=@t_wdate,");
			strSql.Append("regdate=@regdate,");
			strSql.Append("t_isactive=@t_isactive,");
			strSql.Append("t_isdel=@t_isdel,");
			strSql.Append("t_isHead=@t_isHead,");
			strSql.Append("t_ischead=@t_ischead,");
			strSql.Append("t_key=@t_key,");
			strSql.Append("t_des=@t_des,");
			strSql.Append("t_isF=@t_isF,");
			strSql.Append("app_id=@app_id,");
			strSql.Append("file_id=@file_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@cno", SqlDbType.VarChar,200),
					new SqlParameter("@shopID", SqlDbType.Int,4),
					new SqlParameter("@t_title", SqlDbType.VarChar,255),
					new SqlParameter("@t_author", SqlDbType.VarChar,50),
					new SqlParameter("@t_source", SqlDbType.VarChar,255),
					new SqlParameter("@t_gif", SqlDbType.VarChar,255),
					new SqlParameter("@t_msg", SqlDbType.NText),
					new SqlParameter("@t_isurl", SqlDbType.Int,4),
					new SqlParameter("@t_url", SqlDbType.VarChar,255),
					new SqlParameter("@t_filename", SqlDbType.VarChar,255),
					new SqlParameter("@t_sort", SqlDbType.Int,4),
					new SqlParameter("@t_iflag", SqlDbType.Int,4),
					new SqlParameter("@t_cflag", SqlDbType.Int,4),
					new SqlParameter("@t_hits", SqlDbType.Int,4),
					new SqlParameter("@t_wdate", SqlDbType.DateTime),
					new SqlParameter("@regdate", SqlDbType.DateTime),
					new SqlParameter("@t_isactive", SqlDbType.Int,4),
					new SqlParameter("@t_isdel", SqlDbType.Int,4),
					new SqlParameter("@t_isHead", SqlDbType.Int,4),
					new SqlParameter("@t_ischead", SqlDbType.Int,4),
					new SqlParameter("@t_key", SqlDbType.VarChar,255),
					new SqlParameter("@t_des", SqlDbType.VarChar,255),
					new SqlParameter("@t_isF", SqlDbType.TinyInt,1),
					new SqlParameter("@app_id", SqlDbType.VarChar,255),
					new SqlParameter("@file_id", SqlDbType.VarChar,255),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.cno;
			parameters[1].Value = model.shopID;
			parameters[2].Value = model.t_title;
			parameters[3].Value = model.t_author;
			parameters[4].Value = model.t_source;
			parameters[5].Value = model.t_gif;
			parameters[6].Value = model.t_msg;
			parameters[7].Value = model.t_isurl;
			parameters[8].Value = model.t_url;
			parameters[9].Value = model.t_filename;
			parameters[10].Value = model.t_sort;
			parameters[11].Value = model.t_iflag;
			parameters[12].Value = model.t_cflag;
			parameters[13].Value = model.t_hits;
			parameters[14].Value = model.t_wdate;
			parameters[15].Value = model.regdate;
			parameters[16].Value = model.t_isactive;
			parameters[17].Value = model.t_isdel;
			parameters[18].Value = model.t_isHead;
			parameters[19].Value = model.t_ischead;
			parameters[20].Value = model.t_key;
			parameters[21].Value = model.t_des;
			parameters[22].Value = model.t_isF;
			parameters[23].Value = model.app_id;
			parameters[24].Value = model.file_id;
			parameters[25].Value = model.id;

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
			strSql.Append("delete from B2C_tmsg ");
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
			strSql.Append("delete from B2C_tmsg ");
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
		public DTcms.Model.B2C_tmsg GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,cno,shopID,t_title,t_author,t_source,t_gif,t_msg,t_isurl,t_url,t_filename,t_sort,t_iflag,t_cflag,t_hits,t_wdate,regdate,t_isactive,t_isdel,t_isHead,t_ischead,t_key,t_des,t_isF,app_id,file_id from B2C_tmsg ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.B2C_tmsg model=new DTcms.Model.B2C_tmsg();
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
		public DTcms.Model.B2C_tmsg DataRowToModel(DataRow row)
		{
			DTcms.Model.B2C_tmsg model=new DTcms.Model.B2C_tmsg();
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
				if(row["t_title"]!=null)
				{
					model.t_title=row["t_title"].ToString();
				}
				if(row["t_author"]!=null)
				{
					model.t_author=row["t_author"].ToString();
				}
				if(row["t_source"]!=null)
				{
					model.t_source=row["t_source"].ToString();
				}
				if(row["t_gif"]!=null)
				{
					model.t_gif=row["t_gif"].ToString();
				}
				if(row["t_msg"]!=null)
				{
					model.t_msg=row["t_msg"].ToString();
				}
				if(row["t_isurl"]!=null && row["t_isurl"].ToString()!="")
				{
					model.t_isurl=int.Parse(row["t_isurl"].ToString());
				}
				if(row["t_url"]!=null)
				{
					model.t_url=row["t_url"].ToString();
				}
				if(row["t_filename"]!=null)
				{
					model.t_filename=row["t_filename"].ToString();
				}
				if(row["t_sort"]!=null && row["t_sort"].ToString()!="")
				{
					model.t_sort=int.Parse(row["t_sort"].ToString());
				}
				if(row["t_iflag"]!=null && row["t_iflag"].ToString()!="")
				{
					model.t_iflag=int.Parse(row["t_iflag"].ToString());
				}
				if(row["t_cflag"]!=null && row["t_cflag"].ToString()!="")
				{
					model.t_cflag=int.Parse(row["t_cflag"].ToString());
				}
				if(row["t_hits"]!=null && row["t_hits"].ToString()!="")
				{
					model.t_hits=int.Parse(row["t_hits"].ToString());
				}
				if(row["t_wdate"]!=null && row["t_wdate"].ToString()!="")
				{
					model.t_wdate=DateTime.Parse(row["t_wdate"].ToString());
				}
				if(row["regdate"]!=null && row["regdate"].ToString()!="")
				{
					model.regdate=DateTime.Parse(row["regdate"].ToString());
				}
				if(row["t_isactive"]!=null && row["t_isactive"].ToString()!="")
				{
					model.t_isactive=int.Parse(row["t_isactive"].ToString());
				}
				if(row["t_isdel"]!=null && row["t_isdel"].ToString()!="")
				{
					model.t_isdel=int.Parse(row["t_isdel"].ToString());
				}
				if(row["t_isHead"]!=null && row["t_isHead"].ToString()!="")
				{
					model.t_isHead=int.Parse(row["t_isHead"].ToString());
				}
				if(row["t_ischead"]!=null && row["t_ischead"].ToString()!="")
				{
					model.t_ischead=int.Parse(row["t_ischead"].ToString());
				}
				if(row["t_key"]!=null)
				{
					model.t_key=row["t_key"].ToString();
				}
				if(row["t_des"]!=null)
				{
					model.t_des=row["t_des"].ToString();
				}
				if(row["t_isF"]!=null && row["t_isF"].ToString()!="")
				{
					model.t_isF=int.Parse(row["t_isF"].ToString());
				}
				if(row["app_id"]!=null)
				{
					model.app_id=row["app_id"].ToString();
				}
				if(row["file_id"]!=null)
				{
					model.file_id=row["file_id"].ToString();
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
			strSql.Append("select id,cno,shopID,t_title,t_author,t_source,t_gif,t_msg,t_isurl,t_url,t_filename,t_sort,t_iflag,t_cflag,t_hits,t_wdate,regdate,t_isactive,t_isdel,t_isHead,t_ischead,t_key,t_des,t_isF,app_id,file_id ");
			strSql.Append(" FROM B2C_tmsg ");
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
			strSql.Append(" id,cno,shopID,t_title,t_author,t_source,t_gif,t_msg,t_isurl,t_url,t_filename,t_sort,t_iflag,t_cflag,t_hits,t_wdate,regdate,t_isactive,t_isdel,t_isHead,t_ischead,t_key,t_des,t_isF,app_id,file_id ");
			strSql.Append(" FROM B2C_tmsg ");
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
			strSql.Append("select count(1) FROM B2C_tmsg ");
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
			strSql.Append(")AS Row, T.*  from B2C_tmsg T ");
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
			parameters[0].Value = "B2C_tmsg";
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

