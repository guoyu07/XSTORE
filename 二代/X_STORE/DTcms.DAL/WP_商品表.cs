/**  版本信息模板在安装目录下，可自行修改。
* WP_商品表.cs
*
* 功 能： N/A
* 类 名： WP_商品表
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016-04-18 14:51:27   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:WP_商品表
	/// </summary>
	public partial class WP_商品表
	{
		public WP_商品表()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "WP_商品表"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WP_商品表");
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
		public int Add(DTcms.Model.WP_商品表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WP_商品表(");
			strSql.Append("用户ID,编号,编号new,类别号,品名,规格,单位,重量,序号,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,分销率,IsShow,是否上架,类型,critical_value,折扣率,是否卖家承担运费,满多少包邮,运费模板)");
			strSql.Append(" values (");
			strSql.Append("@用户ID,@编号,@编号new,@类别号,@品名,@规格,@单位,@重量,@序号,@市场价,@本站价,@三团价,@九团价,@上架时间,@下架时间,@录入时间,@库存数量,@限购数量,@分销率,@IsShow,@是否上架,@类型,@critical_value,@折扣率,@是否卖家承担运费,@满多少包邮,@运费模板)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@用户ID", SqlDbType.Int,4),
					new SqlParameter("@编号", SqlDbType.VarChar,50),
					new SqlParameter("@编号new", SqlDbType.VarChar,50),
					new SqlParameter("@类别号", SqlDbType.VarChar,50),
					new SqlParameter("@品名", SqlDbType.NVarChar,200),
					new SqlParameter("@规格", SqlDbType.VarChar,50),
					new SqlParameter("@单位", SqlDbType.VarChar,50),
					new SqlParameter("@重量", SqlDbType.Decimal,9),
					new SqlParameter("@序号", SqlDbType.Int,4),
					new SqlParameter("@市场价", SqlDbType.Decimal,9),
					new SqlParameter("@本站价", SqlDbType.Decimal,9),
					new SqlParameter("@三团价", SqlDbType.Decimal,9),
					new SqlParameter("@九团价", SqlDbType.Decimal,9),
					new SqlParameter("@上架时间", SqlDbType.DateTime),
					new SqlParameter("@下架时间", SqlDbType.DateTime),
					new SqlParameter("@录入时间", SqlDbType.DateTime),
					new SqlParameter("@库存数量", SqlDbType.Int,4),
					new SqlParameter("@限购数量", SqlDbType.Int,4),
					new SqlParameter("@分销率", SqlDbType.Decimal,9),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@是否上架", SqlDbType.Int,4),
					new SqlParameter("@类型", SqlDbType.Int,4),
					new SqlParameter("@critical_value", SqlDbType.Int,4),
					new SqlParameter("@折扣率", SqlDbType.Money,8),
					new SqlParameter("@是否卖家承担运费", SqlDbType.TinyInt,1),
					new SqlParameter("@满多少包邮", SqlDbType.Money,8),
					new SqlParameter("@运费模板", SqlDbType.Int,4)};
			parameters[0].Value = model.用户ID;
			parameters[1].Value = model.编号;
			parameters[2].Value = model.编号new;
			parameters[3].Value = model.类别号;
			parameters[4].Value = model.品名;
			parameters[5].Value = model.规格;
			parameters[6].Value = model.单位;
			parameters[7].Value = model.重量;
			parameters[8].Value = model.序号;
			parameters[9].Value = model.市场价;
			parameters[10].Value = model.本站价;
			parameters[11].Value = model.三团价;
			parameters[12].Value = model.九团价;
			parameters[13].Value = model.上架时间;
			parameters[14].Value = model.下架时间;
			parameters[15].Value = model.录入时间;
			parameters[16].Value = model.库存数量;
			parameters[17].Value = model.限购数量;
			parameters[18].Value = model.分销率;
			parameters[19].Value = model.IsShow;
			parameters[20].Value = model.是否上架;
			parameters[21].Value = model.类型;
			parameters[22].Value = model.critical_value;
			parameters[23].Value = model.折扣率;
			parameters[24].Value = model.是否卖家承担运费;
			parameters[25].Value = model.满多少包邮;
			parameters[26].Value = model.运费模板;

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
		public bool Update(DTcms.Model.WP_商品表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WP_商品表 set ");
			strSql.Append("用户ID=@用户ID,");
			strSql.Append("编号=@编号,");
			strSql.Append("编号new=@编号new,");
			strSql.Append("类别号=@类别号,");
			strSql.Append("品名=@品名,");
			strSql.Append("规格=@规格,");
			strSql.Append("单位=@单位,");
			strSql.Append("重量=@重量,");
			strSql.Append("序号=@序号,");
			strSql.Append("市场价=@市场价,");
			strSql.Append("本站价=@本站价,");
			strSql.Append("三团价=@三团价,");
			strSql.Append("九团价=@九团价,");
			strSql.Append("上架时间=@上架时间,");
			strSql.Append("下架时间=@下架时间,");
			strSql.Append("录入时间=@录入时间,");
			strSql.Append("库存数量=@库存数量,");
			strSql.Append("限购数量=@限购数量,");
			strSql.Append("分销率=@分销率,");
			strSql.Append("IsShow=@IsShow,");
			strSql.Append("是否上架=@是否上架,");
			strSql.Append("类型=@类型,");
			strSql.Append("critical_value=@critical_value,");
			strSql.Append("折扣率=@折扣率,");
			strSql.Append("是否卖家承担运费=@是否卖家承担运费,");
			strSql.Append("满多少包邮=@满多少包邮,");
			strSql.Append("运费模板=@运费模板");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@用户ID", SqlDbType.Int,4),
					new SqlParameter("@编号", SqlDbType.VarChar,50),
					new SqlParameter("@编号new", SqlDbType.VarChar,50),
					new SqlParameter("@类别号", SqlDbType.VarChar,50),
					new SqlParameter("@品名", SqlDbType.NVarChar,200),
					new SqlParameter("@规格", SqlDbType.VarChar,50),
					new SqlParameter("@单位", SqlDbType.VarChar,50),
					new SqlParameter("@重量", SqlDbType.Decimal,9),
					new SqlParameter("@序号", SqlDbType.Int,4),
					new SqlParameter("@市场价", SqlDbType.Decimal,9),
					new SqlParameter("@本站价", SqlDbType.Decimal,9),
					new SqlParameter("@三团价", SqlDbType.Decimal,9),
					new SqlParameter("@九团价", SqlDbType.Decimal,9),
					new SqlParameter("@上架时间", SqlDbType.DateTime),
					new SqlParameter("@下架时间", SqlDbType.DateTime),
					new SqlParameter("@录入时间", SqlDbType.DateTime),
					new SqlParameter("@库存数量", SqlDbType.Int,4),
					new SqlParameter("@限购数量", SqlDbType.Int,4),
					new SqlParameter("@分销率", SqlDbType.Decimal,9),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@是否上架", SqlDbType.Int,4),
					new SqlParameter("@类型", SqlDbType.Int,4),
					new SqlParameter("@critical_value", SqlDbType.Int,4),
					new SqlParameter("@折扣率", SqlDbType.Money,8),
					new SqlParameter("@是否卖家承担运费", SqlDbType.TinyInt,1),
					new SqlParameter("@满多少包邮", SqlDbType.Money,8),
					new SqlParameter("@运费模板", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.用户ID;
			parameters[1].Value = model.编号;
			parameters[2].Value = model.编号new;
			parameters[3].Value = model.类别号;
			parameters[4].Value = model.品名;
			parameters[5].Value = model.规格;
			parameters[6].Value = model.单位;
			parameters[7].Value = model.重量;
			parameters[8].Value = model.序号;
			parameters[9].Value = model.市场价;
			parameters[10].Value = model.本站价;
			parameters[11].Value = model.三团价;
			parameters[12].Value = model.九团价;
			parameters[13].Value = model.上架时间;
			parameters[14].Value = model.下架时间;
			parameters[15].Value = model.录入时间;
			parameters[16].Value = model.库存数量;
			parameters[17].Value = model.限购数量;
			parameters[18].Value = model.分销率;
			parameters[19].Value = model.IsShow;
			parameters[20].Value = model.是否上架;
			parameters[21].Value = model.类型;
			parameters[22].Value = model.critical_value;
			parameters[23].Value = model.折扣率;
			parameters[24].Value = model.是否卖家承担运费;
			parameters[25].Value = model.满多少包邮;
			parameters[26].Value = model.运费模板;
			parameters[27].Value = model.id;

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
			strSql.Append("delete from WP_商品表 ");
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
			strSql.Append("delete from WP_商品表 ");
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
		public DTcms.Model.WP_商品表 GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,用户ID,编号,编号new,类别号,品名,规格,单位,重量,序号,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,分销率,IsShow,是否上架,类型,critical_value,折扣率,是否卖家承担运费,满多少包邮,运费模板 from WP_商品表 ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			DTcms.Model.WP_商品表 model=new DTcms.Model.WP_商品表();
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
		public DTcms.Model.WP_商品表 DataRowToModel(DataRow row)
		{
			DTcms.Model.WP_商品表 model=new DTcms.Model.WP_商品表();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["用户ID"]!=null && row["用户ID"].ToString()!="")
				{
					model.用户ID=int.Parse(row["用户ID"].ToString());
				}
				if(row["编号"]!=null)
				{
					model.编号=row["编号"].ToString();
				}
				if(row["编号new"]!=null)
				{
					model.编号new=row["编号new"].ToString();
				}
				if(row["类别号"]!=null)
				{
					model.类别号=row["类别号"].ToString();
				}
				if(row["品名"]!=null)
				{
					model.品名=row["品名"].ToString();
				}
				if(row["规格"]!=null)
				{
					model.规格=row["规格"].ToString();
				}
				if(row["单位"]!=null)
				{
					model.单位=row["单位"].ToString();
				}
				if(row["重量"]!=null && row["重量"].ToString()!="")
				{
					model.重量=decimal.Parse(row["重量"].ToString());
				}
				if(row["序号"]!=null && row["序号"].ToString()!="")
				{
					model.序号=int.Parse(row["序号"].ToString());
				}
				if(row["市场价"]!=null && row["市场价"].ToString()!="")
				{
					model.市场价=decimal.Parse(row["市场价"].ToString());
				}
				if(row["本站价"]!=null && row["本站价"].ToString()!="")
				{
					model.本站价=decimal.Parse(row["本站价"].ToString());
				}
				if(row["三团价"]!=null && row["三团价"].ToString()!="")
				{
					model.三团价=decimal.Parse(row["三团价"].ToString());
				}
				if(row["九团价"]!=null && row["九团价"].ToString()!="")
				{
					model.九团价=decimal.Parse(row["九团价"].ToString());
				}
				if(row["上架时间"]!=null && row["上架时间"].ToString()!="")
				{
					model.上架时间=DateTime.Parse(row["上架时间"].ToString());
				}
				if(row["下架时间"]!=null && row["下架时间"].ToString()!="")
				{
					model.下架时间=DateTime.Parse(row["下架时间"].ToString());
				}
				if(row["录入时间"]!=null && row["录入时间"].ToString()!="")
				{
					model.录入时间=DateTime.Parse(row["录入时间"].ToString());
				}
				if(row["库存数量"]!=null && row["库存数量"].ToString()!="")
				{
					model.库存数量=int.Parse(row["库存数量"].ToString());
				}
				if(row["限购数量"]!=null && row["限购数量"].ToString()!="")
				{
					model.限购数量=int.Parse(row["限购数量"].ToString());
				}
				if(row["分销率"]!=null && row["分销率"].ToString()!="")
				{
					model.分销率=decimal.Parse(row["分销率"].ToString());
				}
				if(row["IsShow"]!=null && row["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(row["IsShow"].ToString());
				}
				if(row["是否上架"]!=null && row["是否上架"].ToString()!="")
				{
					model.是否上架=int.Parse(row["是否上架"].ToString());
				}
				if(row["类型"]!=null && row["类型"].ToString()!="")
				{
					model.类型=int.Parse(row["类型"].ToString());
				}
				if(row["critical_value"]!=null && row["critical_value"].ToString()!="")
				{
					model.critical_value=int.Parse(row["critical_value"].ToString());
				}
				if(row["折扣率"]!=null && row["折扣率"].ToString()!="")
				{
					model.折扣率=decimal.Parse(row["折扣率"].ToString());
				}
				if(row["是否卖家承担运费"]!=null && row["是否卖家承担运费"].ToString()!="")
				{
					model.是否卖家承担运费=int.Parse(row["是否卖家承担运费"].ToString());
				}
				if(row["满多少包邮"]!=null && row["满多少包邮"].ToString()!="")
				{
					model.满多少包邮=decimal.Parse(row["满多少包邮"].ToString());
				}
				if(row["运费模板"]!=null && row["运费模板"].ToString()!="")
				{
					model.运费模板=int.Parse(row["运费模板"].ToString());
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
			strSql.Append("select id,用户ID,编号,编号new,类别号,品名,规格,单位,重量,序号,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,分销率,IsShow,是否上架,类型,critical_value,折扣率,是否卖家承担运费,满多少包邮,运费模板 ");
			strSql.Append(" FROM WP_商品表 ");
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
			strSql.Append(" id,用户ID,编号,编号new,类别号,品名,规格,单位,重量,序号,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,分销率,IsShow,是否上架,类型,critical_value,折扣率,是否卖家承担运费,满多少包邮,运费模板 ");
			strSql.Append(" FROM WP_商品表 ");
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
			strSql.Append("select count(1) FROM WP_商品表 ");
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
			strSql.Append(")AS Row, T.*  from WP_商品表 T ");
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
			parameters[0].Value = "WP_商品表";
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

