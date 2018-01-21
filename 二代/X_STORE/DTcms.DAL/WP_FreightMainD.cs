/**  版本信息模板在安装目录下，可自行修改。
* WP_FreightMainD.cs
*
* 功 能： N/A
* 类 名： WP_FreightMainD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016-04-08 18:24:01   N/A    初版
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
	/// 数据访问类:WP_FreightMainD
	/// </summary>
	public partial class WP_FreightMainD
	{
        public WP_FreightMainD()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WP_FreightMainD");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.WP_FreightMainD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WP_FreightMainD(");
            strSql.Append("mainid,计价方式,name,shouzhong,shoujia,xuzhong,xujia,areas,运送方式,createtime)");
            strSql.Append(" values (");
            strSql.Append("@mainid,@计价方式,@name,@shouzhong,@shoujia,@xuzhong,@xujia,@areas,@运送方式,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@mainid", SqlDbType.Int,4),
					new SqlParameter("@计价方式", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@shouzhong", SqlDbType.Decimal,9),
					new SqlParameter("@shoujia", SqlDbType.Decimal,9),
					new SqlParameter("@xuzhong", SqlDbType.Decimal,9),
					new SqlParameter("@xujia", SqlDbType.Decimal,9),
					new SqlParameter("@areas", SqlDbType.VarChar,100),
					new SqlParameter("@运送方式", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
            parameters[0].Value = model.mainid;
            parameters[1].Value = model.计价方式;
            parameters[2].Value = model.name;
            parameters[3].Value = model.shouzhong;
            parameters[4].Value = model.shoujia;
            parameters[5].Value = model.xuzhong;
            parameters[6].Value = model.xujia;
            parameters[7].Value = model.areas;
            parameters[8].Value = model.运送方式;
            parameters[9].Value = model.createtime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.WP_FreightMainD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WP_FreightMainD set ");
            strSql.Append("mainid=@mainid,");
            strSql.Append("计价方式=@计价方式,");
            strSql.Append("name=@name,");
            strSql.Append("shouzhong=@shouzhong,");
            strSql.Append("shoujia=@shoujia,");
            strSql.Append("xuzhong=@xuzhong,");
            strSql.Append("xujia=@xujia,");
            strSql.Append("areas=@areas,");
            strSql.Append("运送方式=@运送方式,");
            strSql.Append("createtime=@createtime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@mainid", SqlDbType.Int,4),
					new SqlParameter("@计价方式", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@shouzhong", SqlDbType.Decimal,9),
					new SqlParameter("@shoujia", SqlDbType.Decimal,9),
					new SqlParameter("@xuzhong", SqlDbType.Decimal,9),
					new SqlParameter("@xujia", SqlDbType.Decimal,9),
					new SqlParameter("@areas", SqlDbType.VarChar,100),
					new SqlParameter("@运送方式", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.mainid;
            parameters[1].Value = model.计价方式;
            parameters[2].Value = model.name;
            parameters[3].Value = model.shouzhong;
            parameters[4].Value = model.shoujia;
            parameters[5].Value = model.xuzhong;
            parameters[6].Value = model.xujia;
            parameters[7].Value = model.areas;
            parameters[8].Value = model.运送方式;
            parameters[9].Value = model.createtime;
            parameters[10].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WP_FreightMainD ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WP_FreightMainD ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.WP_FreightMainD GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,mainid,计价方式,name,shouzhong,shoujia,xuzhong,xujia,areas,运送方式,createtime from WP_FreightMainD ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.WP_FreightMainD model = new Model.WP_FreightMainD();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Model.WP_FreightMainD DataRowToModel(DataRow row)
        {
            Model.WP_FreightMainD model = new Model.WP_FreightMainD();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["mainid"] != null && row["mainid"].ToString() != "")
                {
                    model.mainid = int.Parse(row["mainid"].ToString());
                }
                if (row["计价方式"] != null && row["计价方式"].ToString() != "")
                {
                    model.计价方式 = int.Parse(row["计价方式"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["shouzhong"] != null && row["shouzhong"].ToString() != "")
                {
                    model.shouzhong = decimal.Parse(row["shouzhong"].ToString());
                }
                if (row["shoujia"] != null && row["shoujia"].ToString() != "")
                {
                    model.shoujia = decimal.Parse(row["shoujia"].ToString());
                }
                if (row["xuzhong"] != null && row["xuzhong"].ToString() != "")
                {
                    model.xuzhong = decimal.Parse(row["xuzhong"].ToString());
                }
                if (row["xujia"] != null && row["xujia"].ToString() != "")
                {
                    model.xujia = decimal.Parse(row["xujia"].ToString());
                }
                if (row["areas"] != null)
                {
                    model.areas = row["areas"].ToString();
                }
                if (row["运送方式"] != null)
                {
                    model.运送方式 = row["运送方式"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mainid,计价方式,name,shouzhong,shoujia,xuzhong,xujia,areas,运送方式,createtime ");
            strSql.Append(" FROM WP_FreightMainD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,mainid,计价方式,name,shouzhong,shoujia,xuzhong,xujia,areas,运送方式,createtime ");
            strSql.Append(" FROM WP_FreightMainD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM WP_FreightMainD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from WP_FreightMainD T ");
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
            parameters[0].Value = "WP_FreightMainD";
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

