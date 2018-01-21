 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:WP_酒店表
	/// </summary>
	public partial class WP_酒店表
	{
		public WP_酒店表()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "WP_酒店表"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WP_酒店表");
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
		public int Add(DTcms.Model.WP_酒店表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WP_酒店表(");
			strSql.Append("酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id)");
			strSql.Append(" values (");
            strSql.Append("@酒店全称,@酒店简称,@Logo,@区域id,@地址,@电话,@总数,@总额,@区域管理id,@酒店管理id,@是否活跃,@是否删除,@删除人id,@删除时间,@最后修改时间,@最后修改人id,@创建时间,@创建人id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
            //        new SqlParameter("@类别名", SqlDbType.VarChar,500),
                      new SqlParameter("@酒店全称",SqlDbType.VarChar,50),
                      new SqlParameter("@酒店简称",SqlDbType.VarChar,50),
                      new SqlParameter("@Logo",SqlDbType.VarChar,50),
                      new SqlParameter("@区域id",SqlDbType.Int,10),
                      new SqlParameter("@地址",SqlDbType.VarChar,50),
                      new SqlParameter("@电话",SqlDbType.VarChar,50),
                      new SqlParameter("@总数",SqlDbType.Int,10),
                      new SqlParameter("@总额",SqlDbType.Decimal,10),
                      new SqlParameter("@区域管理id",SqlDbType.BigInt,10),
                      new SqlParameter("@酒店管理id",SqlDbType.BigInt,10),
                      new SqlParameter("@是否活跃",SqlDbType.Bit,5),
                      new SqlParameter("@是否删除",SqlDbType.Bit,5),
                      new SqlParameter("@删除人id",SqlDbType.BigInt,10),
                      new SqlParameter("@删除时间",SqlDbType.DateTime),
                      new SqlParameter("@最后修改时间",SqlDbType.DateTime),
                      new SqlParameter("@最后修改人id",SqlDbType.BigInt,4),
                      new SqlParameter("@创建时间",SqlDbType.DateTime),
                      new SqlParameter("@创建人id",SqlDbType.BigInt,4)};
            parameters[0].Value=model.酒店全称;
            parameters[1].Value=model.酒店简称;
            parameters[2].Value=model.Logo;
            parameters[3].Value=model.区域id;
            parameters[4].Value=model.地址;
            parameters[5].Value=model.电话;
            parameters[6].Value=model.总数;
            parameters[7].Value=model.总额;
            parameters[8].Value=model.区域管理id;
            parameters[9].Value = model.酒店管理id;
            parameters[10].Value = model.是否活跃;
            parameters[11].Value = model.是否删除;
            parameters[12].Value = model.删除人id;
            parameters[13].Value = model.删除时间;
            parameters[14].Value = model.最后修改时间;
            parameters[15].Value = model.最后修改人id;
            parameters[16].Value = model.创建时间;
            parameters[17].Value = model.创建人id;
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
		public bool Update(DTcms.Model.WP_酒店表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WP_酒店表 set ");
            strSql.Append("酒店全称=@酒店全称");
            strSql.Append("酒店简称=@酒店简称");
            strSql.Append("Logo=@Logo");
            strSql.Append("区域id=@区域id");
            strSql.Append("地址=@地址");
            strSql.Append("电话=@电话");
            strSql.Append("总数=@总数");
            strSql.Append("总额=@总额");
            strSql.Append("区域管理id=@区域管理id");
            strSql.Append("酒店管理id=@酒店管理id");
            strSql.Append("是否活跃=@是否活跃");
            strSql.Append("是否删除=@是否删除");
            strSql.Append("删除人id=@删除人id");
            strSql.Append("删除时间=@删除时间");
            strSql.Append("最后修改时间=@最后修改时间");
            strSql.Append("创建时间=@创建时间");
            strSql.Append("创建人id=@创建人id");
			strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                      new SqlParameter("@酒店全称",SqlDbType.VarChar,50),
                      new SqlParameter("@酒店简称",SqlDbType.VarChar,50),
                      new SqlParameter("@Logo",SqlDbType.VarChar,50),
                      new SqlParameter("@区域id",SqlDbType.Int,10),
                      new SqlParameter("@地址",SqlDbType.VarChar,50),
                      new SqlParameter("@电话",SqlDbType.VarChar,50),
                      new SqlParameter("@总数",SqlDbType.Int,10),
                      new SqlParameter("@总额",SqlDbType.Decimal,10),
                      new SqlParameter("@区域管理id",SqlDbType.BigInt,10),
                      new SqlParameter("@酒店管理id",SqlDbType.BigInt,10),
                      new SqlParameter("@是否活跃",SqlDbType.Bit,5),
                      new SqlParameter("@是否删除",SqlDbType.Bit,5),
                      new SqlParameter("@删除人id",SqlDbType.BigInt,10),
                      new SqlParameter("@删除时间",SqlDbType.DateTime),
                      new SqlParameter("@最后修改时间",SqlDbType.DateTime),
                      new SqlParameter("@最后修改人id",SqlDbType.BigInt,4),
                      new SqlParameter("@创建时间",SqlDbType.DateTime),
                      new SqlParameter("@创建人id",SqlDbType.BigInt,4)};
            parameters[0].Value = model.酒店全称;
            parameters[1].Value = model.酒店简称;
            parameters[2].Value = model.Logo;
            parameters[3].Value = model.区域id;
            parameters[4].Value = model.地址;
            parameters[5].Value = model.电话;
            parameters[6].Value = model.总数;
            parameters[7].Value = model.总额;
            parameters[8].Value = model.区域管理id;
            parameters[9].Value = model.酒店管理id;
            parameters[10].Value = model.是否活跃;
            parameters[11].Value = model.是否删除;
            parameters[12].Value = model.删除人id;
            parameters[13].Value = model.删除时间;
            parameters[14].Value = model.最后修改时间;
            parameters[15].Value = model.最后修改人id;
            parameters[16].Value = model.创建时间;
            parameters[17].Value = model.创建人id;

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
			strSql.Append("delete from WP_酒店表 ");
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
			strSql.Append("delete from WP_酒店表 ");
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
		public DTcms.Model.WP_酒店表 GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id from WP_酒店表 ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.WP_酒店表 model=new DTcms.Model.WP_酒店表();
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
		public DTcms.Model.WP_酒店表 DataRowToModel(DataRow row)
		{
			DTcms.Model.WP_酒店表 model=new DTcms.Model.WP_酒店表();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["酒店全称"]!=null)
				{
					model.酒店全称=row["酒店全称"].ToString();
				}
				if(row["酒店简称"]!=null)
				{
					model.酒店简称=row["酒店简称"].ToString();
				}
                if (row["Logo"] != null)
                {
                    model.Logo = row["Logo"].ToString();
                }
                if (row["区域id"] != null)
                {
                    model.区域id = int.Parse(row["区域id"].ToString());
                }
                if (row["地址"] != null)
                {
                    model.地址 = row["地址"].ToString();
                }
                if (row["电话"] != null)
                {
                    model.Logo = row["电话"].ToString();
                }
                if (row["总数"] != null)
                {
                    model.总数 = int.Parse(row["总数"].ToString());
                }
                if (row["总额"] != null)
                {
                    model.总额 =decimal.Parse( row["总额"].ToString());
                }
                if (row["区域管理id"] != null)
                {
                    model.区域管理id =int.Parse( row["区域管理id"].ToString());
                }
                if (row["酒店管理id"] != null)
                {
                    model.酒店管理id = int.Parse( row["酒店管理id"].ToString());
                }
                if (row["是否删除"] != null)
                {
                    model.是否删除 =Boolean.Parse( row["是否删除"].ToString());
                }
                if (row["是否活跃"] != null)
                {
                    model.是否活跃 =Boolean.Parse( row["是否活跃"].ToString());
                }
                if (row["删除人id"] != null)
                {
                    model.删除人id =int.Parse( row["删除人id"].ToString());
                }
                if (row["删除时间"] != null)
                {
                    model.删除时间 =DateTime.Parse( row["删除时间"].ToString());
                }
                if (row["最后修改时间"] != null)
                {
                    model.最后修改时间 = DateTime.Parse(row["最后修改时间"].ToString());
                }
                if (row["最后修改人id"] != null)
                {
                    model.最后修改人id = int.Parse(row["最后修改人id"].ToString());
                }
                if (row["创建时间"] != null)
                {
                    model.创建时间 = DateTime.Parse(row["创建时间"].ToString());
                }
                if (row["创建人id"] != null)
                {
                    model.创建人id = int.Parse(row["创建人id"].ToString());
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
            strSql.Append("select id,酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id ");
			strSql.Append(" FROM WP_酒店表 ");
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
            strSql.Append(" id,酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,删除人id,删除时间,最后修改时间,最后修改人id,创建时间,创建人id ");
			strSql.Append(" FROM WP_酒店表 ");
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
			strSql.Append("select count(1) FROM WP_酒店表 ");
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
			strSql.Append(")AS Row, T.*  from WP_酒店表 T ");
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
			parameters[0].Value = "WP_酒店表";
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

