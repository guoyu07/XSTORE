using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:WP_PingLun
	/// </summary>
	public partial class WP_PingLun
	{
		public WP_PingLun()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "WP_PingLun"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WP_PingLun");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DTcms.Model.WP_PingLun model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WP_PingLun(");
			strSql.Append("UserID,NewsID,PContent,PCreateDate,ReMark,IsView)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@NewsID,@PContent,@PCreateDate,@ReMark,@IsView)");
			SqlParameter[] parameters = { 
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@PContent", SqlDbType.Text),
					new SqlParameter("@PCreateDate", SqlDbType.DateTime),
					new SqlParameter("@ReMark", SqlDbType.VarChar,50),
					new SqlParameter("@IsView", SqlDbType.Bit,1)};
			 
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.NewsID;
			parameters[2].Value = model.PContent;
			parameters[3].Value = model.PCreateDate;
			parameters[4].Value = model.ReMark;
			parameters[5].Value = model.IsView;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.WP_PingLun model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WP_PingLun set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("NewsID=@NewsID,");
			strSql.Append("PContent=@PContent,");
			strSql.Append("PCreateDate=@PCreateDate,");
			strSql.Append("ReMark=@ReMark,");
			strSql.Append("IsView=@IsView");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@PContent", SqlDbType.Text),
					new SqlParameter("@PCreateDate", SqlDbType.DateTime),
					new SqlParameter("@ReMark", SqlDbType.VarChar,50),
					new SqlParameter("@IsView", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.NewsID;
			parameters[2].Value = model.PContent;
			parameters[3].Value = model.PCreateDate;
			parameters[4].Value = model.ReMark;
			parameters[5].Value = model.IsView;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from WP_PingLun ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
			strSql.Append("delete from WP_PingLun ");
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
		public DTcms.Model.WP_PingLun GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,UserID,NewsID,PContent,PCreateDate,ReMark,IsView from WP_PingLun ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			DTcms.Model.WP_PingLun model=new DTcms.Model.WP_PingLun();
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
		public DTcms.Model.WP_PingLun DataRowToModel(DataRow row)
		{
			DTcms.Model.WP_PingLun model=new DTcms.Model.WP_PingLun();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["NewsID"]!=null && row["NewsID"].ToString()!="")
				{
					model.NewsID=int.Parse(row["NewsID"].ToString());
				}
				if(row["PContent"]!=null)
				{
					model.PContent=row["PContent"].ToString();
				}
				if(row["PCreateDate"]!=null && row["PCreateDate"].ToString()!="")
				{
					model.PCreateDate=DateTime.Parse(row["PCreateDate"].ToString());
				}
				if(row["ReMark"]!=null)
				{
					model.ReMark=row["ReMark"].ToString();
				}
				if(row["IsView"]!=null && row["IsView"].ToString()!="")
				{
					if((row["IsView"].ToString()=="1")||(row["IsView"].ToString().ToLower()=="true"))
					{
						model.IsView=true;
					}
					else
					{
						model.IsView=false;
					}
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
			strSql.Append("select id,UserID,NewsID,PContent,PCreateDate,ReMark,IsView ");
			strSql.Append(" FROM WP_PingLun ");
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
			strSql.Append(" id,UserID,NewsID,PContent,PCreateDate,ReMark,IsView ");
			strSql.Append(" FROM WP_PingLun ");
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
			strSql.Append("select count(1) FROM WP_PingLun ");
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
			strSql.Append(")AS Row, T.*  from WP_PingLun T ");
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
			parameters[0].Value = "WP_PingLun";
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

