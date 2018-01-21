 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:TM_商品详情表
	/// </summary>
	public partial class TM_商品详情表
	{
		public TM_商品详情表()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "TM_商品详情表"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TM_商品详情表");
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
		public int Add(DTcms.Model.TM_商品详情表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TM_商品详情表(");
			strSql.Append("商品编号,描述,特点,注意事项,资质证明,品牌介绍)");
			strSql.Append(" values (");
			strSql.Append("@商品编号,@描述,@特点,@注意事项,@资质证明,@品牌介绍)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@商品编号", SqlDbType.VarChar,50),
					new SqlParameter("@描述", SqlDbType.NText),
					new SqlParameter("@特点", SqlDbType.NText),
					new SqlParameter("@注意事项", SqlDbType.NText),
					new SqlParameter("@资质证明", SqlDbType.NText),
					new SqlParameter("@品牌介绍", SqlDbType.NText)};
			parameters[0].Value = model.商品编号;
			parameters[1].Value = model.描述;
			parameters[2].Value = model.特点;
			parameters[3].Value = model.注意事项;
			parameters[4].Value = model.资质证明;
			parameters[5].Value = model.品牌介绍;

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
		public bool Update(DTcms.Model.TM_商品详情表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TM_商品详情表 set ");
			strSql.Append("商品编号=@商品编号,");
			strSql.Append("描述=@描述,");
			strSql.Append("特点=@特点,");
			strSql.Append("注意事项=@注意事项,");
			strSql.Append("资质证明=@资质证明,");
			strSql.Append("品牌介绍=@品牌介绍");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@商品编号", SqlDbType.VarChar,50),
					new SqlParameter("@描述", SqlDbType.NText),
					new SqlParameter("@特点", SqlDbType.NText),
					new SqlParameter("@注意事项", SqlDbType.NText),
					new SqlParameter("@资质证明", SqlDbType.NText),
					new SqlParameter("@品牌介绍", SqlDbType.NText),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.商品编号;
			parameters[1].Value = model.描述;
			parameters[2].Value = model.特点;
			parameters[3].Value = model.注意事项;
			parameters[4].Value = model.资质证明;
			parameters[5].Value = model.品牌介绍;
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
			strSql.Append("delete from TM_商品详情表 ");
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
			strSql.Append("delete from TM_商品详情表 ");
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
		public DTcms.Model.TM_商品详情表 GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,商品编号,描述,特点,注意事项,资质证明,品牌介绍 from TM_商品详情表 ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.TM_商品详情表 model=new DTcms.Model.TM_商品详情表();
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
		public DTcms.Model.TM_商品详情表 DataRowToModel(DataRow row)
		{
			DTcms.Model.TM_商品详情表 model=new DTcms.Model.TM_商品详情表();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["商品编号"]!=null)
				{
					model.商品编号=row["商品编号"].ToString();
				}
				if(row["描述"]!=null)
				{
					model.描述=row["描述"].ToString();
				}
				if(row["特点"]!=null)
				{
					model.特点=row["特点"].ToString();
				}
				if(row["注意事项"]!=null)
				{
					model.注意事项=row["注意事项"].ToString();
				}
				if(row["资质证明"]!=null)
				{
					model.资质证明=row["资质证明"].ToString();
				}
				if(row["品牌介绍"]!=null)
				{
					model.品牌介绍=row["品牌介绍"].ToString();
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
			strSql.Append("select id,商品编号,描述,特点,注意事项,资质证明,品牌介绍 ");
			strSql.Append(" FROM TM_商品详情表 ");
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
			strSql.Append(" id,商品编号,描述,特点,注意事项,资质证明,品牌介绍 ");
			strSql.Append(" FROM TM_商品详情表 ");
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
			strSql.Append("select count(1) FROM TM_商品详情表 ");
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
			strSql.Append(")AS Row, T.*  from TM_商品详情表 T ");
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
			parameters[0].Value = "TM_商品详情表";
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

