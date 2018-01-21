 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:WP_订单地址表
	/// </summary>
	public partial class WP_订单地址表
	{
		public WP_订单地址表()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "WP_订单地址表"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WP_订单地址表");
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
		public int Add(DTcms.Model.WP_订单地址表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WP_订单地址表(");
			strSql.Append("订单编号,省,市,区,商圈,详细地址,手机号,收货人,备注,是否为默认地址,is_del)");
			strSql.Append(" values (");
            strSql.Append("@订单编号,@省,@市,@区,@商圈,@详细地址,@手机号,@收货人,@备注,@是否为默认地址,@is_del)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@订单编号", SqlDbType.VarChar,50),
					new SqlParameter("@省", SqlDbType.VarChar,50),
					new SqlParameter("@市", SqlDbType.VarChar,50),
					new SqlParameter("@区", SqlDbType.VarChar,50),
					new SqlParameter("@商圈", SqlDbType.VarChar,50),
					new SqlParameter("@详细地址", SqlDbType.VarChar,250),
					new SqlParameter("@手机号", SqlDbType.VarChar,50),
					new SqlParameter("@收货人", SqlDbType.VarChar,50),
					new SqlParameter("@备注", SqlDbType.NText),
                    new SqlParameter("@是否为默认地址", SqlDbType.Int),
                    new SqlParameter("@is_del", SqlDbType.Int)   };
			parameters[0].Value = model.订单编号;
			parameters[1].Value = model.省;
			parameters[2].Value = model.市;
			parameters[3].Value = model.区;
			parameters[4].Value = model.商圈;
			parameters[5].Value = model.详细地址;
			parameters[6].Value = model.手机号;
			parameters[7].Value = model.收货人;
			parameters[8].Value = model.备注;
            parameters[9].Value = model.是否为默认地址;
            parameters[10].Value = model.is_del;
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
		public bool Update(DTcms.Model.WP_订单地址表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WP_订单地址表 set ");
			strSql.Append("订单编号=@订单编号,");
			strSql.Append("省=@省,");
			strSql.Append("市=@市,");
			strSql.Append("区=@区,");
			strSql.Append("商圈=@商圈,");
			strSql.Append("详细地址=@详细地址,");
			strSql.Append("手机号=@手机号,");
			strSql.Append("收货人=@收货人,");
			strSql.Append("备注=@备注,");
            strSql.Append("是否为默认地址=@是否为默认地址");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@订单编号", SqlDbType.VarChar,50),
					new SqlParameter("@省", SqlDbType.VarChar,50),
					new SqlParameter("@市", SqlDbType.VarChar,50),
					new SqlParameter("@区", SqlDbType.VarChar,50),
					new SqlParameter("@商圈", SqlDbType.VarChar,50),
					new SqlParameter("@详细地址", SqlDbType.VarChar,250),
					new SqlParameter("@手机号", SqlDbType.VarChar,50),
					new SqlParameter("@收货人", SqlDbType.VarChar,50),
					new SqlParameter("@备注", SqlDbType.NText),
                    new SqlParameter("@是否为默认地址", SqlDbType.Int),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.订单编号;
			parameters[1].Value = model.省;
			parameters[2].Value = model.市;
			parameters[3].Value = model.区;
			parameters[4].Value = model.商圈;
			parameters[5].Value = model.详细地址;
			parameters[6].Value = model.手机号;
			parameters[7].Value = model.收货人;
			parameters[8].Value = model.备注;
            parameters[9].Value = model.是否为默认地址;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from WP_订单地址表 ");
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
			strSql.Append("delete from WP_订单地址表 ");
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
		public DTcms.Model.WP_订单地址表 GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,订单编号,省,市,区,商圈,详细地址,手机号,收货人,备注,是否为默认地址,is_del from WP_订单地址表 ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.WP_订单地址表 model=new DTcms.Model.WP_订单地址表();
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
		public DTcms.Model.WP_订单地址表 DataRowToModel(DataRow row)
		{
			DTcms.Model.WP_订单地址表 model=new DTcms.Model.WP_订单地址表();
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
				if(row["省"]!=null)
				{
					model.省=row["省"].ToString();
				}
				if(row["市"]!=null)
				{
					model.市=row["市"].ToString();
				}
				if(row["区"]!=null)
				{
					model.区=row["区"].ToString();
				}
				if(row["商圈"]!=null)
				{
					model.商圈=row["商圈"].ToString();
				}
				if(row["详细地址"]!=null)
				{
					model.详细地址=row["详细地址"].ToString();
				}
				if(row["手机号"]!=null)
				{
					model.手机号=row["手机号"].ToString();
				}
				if(row["收货人"]!=null)
				{
					model.收货人=row["收货人"].ToString();
				}
				if(row["备注"]!=null)
				{
					model.备注=row["备注"].ToString();
				}
                if (row["是否为默认地址"] != null)
                {
                    model.是否为默认地址 =int.Parse( row["是否为默认地址"].ToString());
                }
                if (row["is_del"] != null && row["is_del"].ToString() != "")
                {
                    model.is_del = int.Parse(row["is_del"].ToString());
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
			strSql.Append("select id,订单编号,省,市,区,商圈,详细地址,手机号,收货人,备注,是否为默认地址,is_del ");
			strSql.Append(" FROM WP_订单地址表 ");
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
            strSql.Append(" id,订单编号,省,市,区,商圈,详细地址,手机号,收货人,备注,是否为默认地址,is_del ");
			strSql.Append(" FROM WP_订单地址表 ");
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
			strSql.Append("select count(1) FROM WP_订单地址表 ");
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
			strSql.Append(")AS Row, T.*  from WP_订单地址表 T ");
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
			parameters[0].Value = "WP_订单地址表";
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

