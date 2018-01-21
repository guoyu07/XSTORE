 
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:TM_会员表
	/// </summary>
	public partial class TM_会员表
	{
		public TM_会员表()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "TM_会员表"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TM_会员表");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DTcms.Model.TM_会员表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TM_会员表(");
			strSql.Append("openid,wx昵称,wx头像,手机号,password,jifen)");
			strSql.Append(" values (");
			strSql.Append("@openid,@wx昵称,@wx头像,@手机号,@password,@jifen)");
			SqlParameter[] parameters = {
					//new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@wx昵称", SqlDbType.VarChar,100),
					new SqlParameter("@wx头像", SqlDbType.VarChar,100),
					new SqlParameter("@手机号", SqlDbType.VarChar,50),
                    new SqlParameter("@password", SqlDbType.VarChar,50),
                    new SqlParameter("@jifen", SqlDbType.Int,10)};
            //parameters[0].Value = model.id;
            //parameters[1].Value = model.openid;
            //parameters[2].Value = model.wx昵称;
            //parameters[3].Value = model.wx头像;
            //parameters[4].Value = model.手机号;
          
            parameters[0].Value = model.openid;
            parameters[1].Value = model.wx昵称;
            parameters[2].Value = model.wx头像;
            parameters[3].Value = model.手机号;
            parameters[4].Value = model.password;
            parameters[5].Value = model.jifen;
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
		public bool Update(DTcms.Model.TM_会员表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TM_会员表 set ");
			//strSql.Append("openid=@openid,");
			strSql.Append("wx昵称=@wx昵称,");
			//strSql.Append("wx头像=@wx头像,");
			//strSql.Append("手机号=@手机号,");
            strSql.Append("email=@email,");
            strSql.Append("qq=@qq,");
            strSql.Append("sex=@sex, ");
            strSql.Append("jifen=@jifen ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					//new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@wx昵称", SqlDbType.VarChar,100),
					//new SqlParameter("@wx头像", SqlDbType.VarChar,100),
					//new SqlParameter("@手机号", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@email", SqlDbType.VarChar,100),
                    new SqlParameter("@qq", SqlDbType.VarChar,50),
                    new SqlParameter("@sex", SqlDbType.VarChar,50),
                    new SqlParameter("@jifen", SqlDbType.Int,10)
                    };
			//parameters[0].Value = model.openid;
			parameters[0].Value = model.wx昵称;
			//parameters[2].Value = model.wx头像;
			//parameters[3].Value = model.手机号;
			parameters[1].Value = model.id;
            parameters[2].Value = model.email;
            parameters[3].Value = model.qq;
            parameters[4].Value = model.sex;
            parameters[5].Value = model.jifen;
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
			strSql.Append("delete from TM_会员表 ");
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
			strSql.Append("delete from TM_会员表 ");
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
		public DTcms.Model.TM_会员表 GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,openid,wx昵称,wx头像,手机号,password,email,qq,sex,jifen from TM_会员表 ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			DTcms.Model.TM_会员表 model=new DTcms.Model.TM_会员表();
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
		public DTcms.Model.TM_会员表 DataRowToModel(DataRow row)
		{
			DTcms.Model.TM_会员表 model=new DTcms.Model.TM_会员表();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["wx昵称"]!=null)
				{
					model.wx昵称=row["wx昵称"].ToString();
				}
				if(row["wx头像"]!=null)
				{
					model.wx头像=row["wx头像"].ToString();
				}
                if (row["手机号"] != null)
                {
                    model.手机号 = row["手机号"].ToString();
                }
				
                if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}

                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["qq"] != null)
                {
                    model.qq = row["qq"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["jifen"] != null)
                {
                    model.jifen = DTcms.Common.Utils.ObjToInt(row["jifen"].ToString(),0);
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
			strSql.Append("select id,openid,wx昵称,wx头像,手机号,password,email,qq,sex,jifen ");
			strSql.Append(" FROM TM_会员表 ");
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
			strSql.Append(" id,openid,wx昵称,wx头像,手机号,password,email,qq,sex,jifen ");
			strSql.Append(" FROM TM_会员表 ");
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
			strSql.Append("select count(1) FROM TM_会员表 ");
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
			strSql.Append(")AS Row, T.*  from TM_会员表 T ");
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
			parameters[0].Value = "TM_会员表";
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

