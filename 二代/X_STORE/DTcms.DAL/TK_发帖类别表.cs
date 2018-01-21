using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Creatrue.kernel;
using DTcms.DBUtility;
namespace DTcms.DAL
{
    /// <summary>
    /// ���ݷ�����:TK_��������
    /// </summary>
    public partial class TK_��������
    {
        public TK_��������()
        { }
        #region  BasicMethod
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TK_��������");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DTcms.Model.TK_�������� model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TK_��������(");
            strSql.Append("�����,�����,ͼƬ,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child)");
            strSql.Append(" values (");
            strSql.Append("@�����,@�����,@ͼƬ,@c_url,@c_sort,@c_des,@c_isactive,@c_isdel,@regtime,@c_parent,@c_level,@c_child)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@�����", SqlDbType.VarChar,500),
					new SqlParameter("@�����", SqlDbType.VarChar,255),
					new SqlParameter("@ͼƬ", SqlDbType.NVarChar,100),
					new SqlParameter("@c_url", SqlDbType.VarChar,2000),
					new SqlParameter("@c_sort", SqlDbType.Int,4),
					new SqlParameter("@c_des", SqlDbType.VarChar,300),
					new SqlParameter("@c_isactive", SqlDbType.Int,4),
					new SqlParameter("@c_isdel", SqlDbType.Int,4),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@c_parent", SqlDbType.Int,4),
					new SqlParameter("@c_level", SqlDbType.Int,4),
					new SqlParameter("@c_child", SqlDbType.Int,4)};
            parameters[0].Value = model.�����;
            parameters[1].Value = model.�����;
            parameters[2].Value = model.ͼƬ;
            parameters[3].Value = model.c_url;
            parameters[4].Value = model.c_sort;
            parameters[5].Value = model.c_des;
            parameters[6].Value = model.c_isactive;
            parameters[7].Value = model.c_isdel;
            parameters[8].Value = model.regtime;
            parameters[9].Value = model.c_parent;
            parameters[10].Value = model.c_level;
            parameters[11].Value = model.c_child;

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
        /// ����һ������
        /// </summary>
        public bool Update(DTcms.Model.TK_�������� model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_�������� set ");
            strSql.Append("�����=@�����,");
            strSql.Append("�����=@�����,");
            strSql.Append("ͼƬ=@ͼƬ,");
            strSql.Append("c_url=@c_url,");
            strSql.Append("c_sort=@c_sort,");
            strSql.Append("c_des=@c_des,");
            strSql.Append("c_isactive=@c_isactive,");
            strSql.Append("c_isdel=@c_isdel,");
            strSql.Append("regtime=@regtime,");
            strSql.Append("c_parent=@c_parent,");
            strSql.Append("c_level=@c_level,");
            strSql.Append("c_child=@c_child");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@�����", SqlDbType.VarChar,500),
					new SqlParameter("@�����", SqlDbType.VarChar,255),
					new SqlParameter("@ͼƬ", SqlDbType.NVarChar,100),
					new SqlParameter("@c_url", SqlDbType.VarChar,2000),
					new SqlParameter("@c_sort", SqlDbType.Int,4),
					new SqlParameter("@c_des", SqlDbType.VarChar,300),
					new SqlParameter("@c_isactive", SqlDbType.Int,4),
					new SqlParameter("@c_isdel", SqlDbType.Int,4),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@c_parent", SqlDbType.Int,4),
					new SqlParameter("@c_level", SqlDbType.Int,4),
					new SqlParameter("@c_child", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.�����;
            parameters[1].Value = model.�����;
            parameters[2].Value = model.ͼƬ;
            parameters[3].Value = model.c_url;
            parameters[4].Value = model.c_sort;
            parameters[5].Value = model.c_des;
            parameters[6].Value = model.c_isactive;
            parameters[7].Value = model.c_isdel;
            parameters[8].Value = model.regtime;
            parameters[9].Value = model.c_parent;
            parameters[10].Value = model.c_level;
            parameters[11].Value = model.c_child;
            parameters[12].Value = model.id;

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
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_�������� ");
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
        /// ����ɾ������
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_�������� ");
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
        /// �õ�һ������ʵ��
        /// </summary>
        public DTcms.Model.TK_�������� GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,�����,�����,ͼƬ,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child from TK_�������� ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            DTcms.Model.TK_�������� model = new DTcms.Model.TK_��������();
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
        /// �õ�һ������ʵ��
        /// </summary>
        public DTcms.Model.TK_�������� DataRowToModel(DataRow row)
        {
            DTcms.Model.TK_�������� model = new DTcms.Model.TK_��������();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["�����"] != null)
                {
                    model.����� = row["�����"].ToString();
                }
                if (row["�����"] != null)
                {
                    model.����� = row["�����"].ToString();
                }
                if (row["ͼƬ"] != null)
                {
                    model.ͼƬ = row["ͼƬ"].ToString();
                }
                if (row["c_url"] != null)
                {
                    model.c_url = row["c_url"].ToString();
                }
                if (row["c_sort"] != null && row["c_sort"].ToString() != "")
                {
                    model.c_sort = int.Parse(row["c_sort"].ToString());
                }
                if (row["c_des"] != null)
                {
                    model.c_des = row["c_des"].ToString();
                }
                if (row["c_isactive"] != null && row["c_isactive"].ToString() != "")
                {
                    model.c_isactive = int.Parse(row["c_isactive"].ToString());
                }
                if (row["c_isdel"] != null && row["c_isdel"].ToString() != "")
                {
                    model.c_isdel = int.Parse(row["c_isdel"].ToString());
                }
                if (row["regtime"] != null && row["regtime"].ToString() != "")
                {
                    model.regtime = DateTime.Parse(row["regtime"].ToString());
                }
                if (row["c_parent"] != null && row["c_parent"].ToString() != "")
                {
                    model.c_parent = int.Parse(row["c_parent"].ToString());
                }
                if (row["c_level"] != null && row["c_level"].ToString() != "")
                {
                    model.c_level = int.Parse(row["c_level"].ToString());
                }
                if (row["c_child"] != null && row["c_child"].ToString() != "")
                {
                    model.c_child = int.Parse(row["c_child"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,�����,�����,ͼƬ,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child ");
            strSql.Append(" FROM TK_�������� ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,�����,�����,ͼƬ,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child ");
            strSql.Append(" FROM TK_�������� ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TK_�������� ");
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
        /// ��ҳ��ȡ�����б�
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
            strSql.Append(")AS Row, T.*  from TK_�������� T ");
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
        /// ��ҳ��ȡ�����б�
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
            parameters[0].Value = "TK_��������";
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
        #region ������ѯ
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from TK_�������� where " + _sql);//cityID=" + System.Web.HttpContext.Current.Session["wID"].ToString() + " and 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

