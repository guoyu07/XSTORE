﻿ 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:TM_订单支付表
	/// </summary>
	public partial class TM_订单支付表
	{
		public TM_订单支付表()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "TM_订单支付表"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TM_订单支付表");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DTcms.Model.TM_订单支付表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TM_订单支付表(");
			strSql.Append("订单编号,支付方式,支付金额,openid,支付时间)");
			strSql.Append(" values (");
			strSql.Append("@订单编号,@支付方式,@支付金额,@openid,@支付时间)");
			SqlParameter[] parameters = {
					new SqlParameter("@订单编号", SqlDbType.VarChar,50),
					new SqlParameter("@支付方式", SqlDbType.VarChar,50),
					new SqlParameter("@支付金额", SqlDbType.Decimal,9),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@支付时间", SqlDbType.DateTime)};
			parameters[0].Value = model.订单编号;
			parameters[1].Value = model.支付方式;
			parameters[2].Value = model.支付金额;
			parameters[3].Value = model.openid;
			parameters[4].Value = model.支付时间;

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
		public bool Update(DTcms.Model.TM_订单支付表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TM_订单支付表 set ");
			strSql.Append("订单编号=@订单编号,");
			strSql.Append("支付方式=@支付方式,");
			strSql.Append("支付金额=@支付金额,");
			strSql.Append("openid=@openid,");
			strSql.Append("支付时间=@支付时间");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@订单编号", SqlDbType.VarChar,50),
					new SqlParameter("@支付方式", SqlDbType.VarChar,50),
					new SqlParameter("@支付金额", SqlDbType.Decimal,9),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@支付时间", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.订单编号;
			parameters[1].Value = model.支付方式;
			parameters[2].Value = model.支付金额;
			parameters[3].Value = model.openid;
			parameters[4].Value = model.支付时间;
			parameters[5].Value = model.id;

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
			strSql.Append("delete from TM_订单支付表 ");
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
			strSql.Append("delete from TM_订单支付表 ");
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
		public DTcms.Model.TM_订单支付表 GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,订单编号,支付方式,支付金额,openid,支付时间 from TM_订单支付表 ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			DTcms.Model.TM_订单支付表 model=new DTcms.Model.TM_订单支付表();
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
		public DTcms.Model.TM_订单支付表 DataRowToModel(DataRow row)
		{
			DTcms.Model.TM_订单支付表 model=new DTcms.Model.TM_订单支付表();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["订单编号"]!=null)
				{
					model.订单编号=row["订单编号"].ToString();
				}
				if(row["支付方式"]!=null)
				{
					model.支付方式=row["支付方式"].ToString();
				}
				if(row["支付金额"]!=null && row["支付金额"].ToString()!="")
				{
					model.支付金额=decimal.Parse(row["支付金额"].ToString());
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["支付时间"]!=null && row["支付时间"].ToString()!="")
				{
					model.支付时间=DateTime.Parse(row["支付时间"].ToString());
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
			strSql.Append("select id,订单编号,支付方式,支付金额,openid,支付时间 ");
			strSql.Append(" FROM TM_订单支付表 ");
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
			strSql.Append(" id,订单编号,支付方式,支付金额,openid,支付时间 ");
			strSql.Append(" FROM TM_订单支付表 ");
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
			strSql.Append("select count(1) FROM TM_订单支付表 ");
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
			strSql.Append(")AS Row, T.*  from TM_订单支付表 T ");
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
			parameters[0].Value = "TM_订单支付表";
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

