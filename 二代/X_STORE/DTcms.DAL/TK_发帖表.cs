using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
    /// <summary>
    /// ���ݷ�����:TK_������
    /// </summary>
    public partial class TK_������
    {
        public TK_������()
        { }
        #region  BasicMethod
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TK_������");
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
        public int Add(DTcms.Model.TK_������ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TK_������(");
            strSql.Append("���,����,����,����,����ʱ��,openid,�Ƿ���ʾ,�Ƿ��ö�)");
            strSql.Append(" values (");
            strSql.Append("@���,@����,@����,@����,@����ʱ��,@openid,@�Ƿ���ʾ,@�Ƿ��ö�)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@���", SqlDbType.VarChar,50),
					new SqlParameter("@����", SqlDbType.VarChar,50),
					new SqlParameter("@����", SqlDbType.VarChar,200),
					new SqlParameter("@����", SqlDbType.NText),
					new SqlParameter("@����ʱ��", SqlDbType.DateTime),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@�Ƿ���ʾ", SqlDbType.Int,4),
					new SqlParameter("@�Ƿ��ö�", SqlDbType.Int,4)};
            parameters[0].Value = model.���;
            parameters[1].Value = model.����;
            parameters[2].Value = model.����;
            parameters[3].Value = model.����;
            parameters[4].Value = model.����ʱ��;
            parameters[5].Value = model.openid;
            parameters[6].Value = model.�Ƿ���ʾ;
            parameters[7].Value = model.�Ƿ��ö�;

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
        public bool Update(DTcms.Model.TK_������ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_������ set ");
            strSql.Append("���=@���,");
            strSql.Append("����=@����,");
            strSql.Append("����=@����,");
            strSql.Append("����=@����,");
            strSql.Append("����ʱ��=@����ʱ��,");
            strSql.Append("openid=@openid,");
            strSql.Append("�Ƿ���ʾ=@�Ƿ���ʾ,");
            strSql.Append("�Ƿ��ö�=@�Ƿ��ö�");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@���", SqlDbType.VarChar,50),
					new SqlParameter("@����", SqlDbType.VarChar,50),
					new SqlParameter("@����", SqlDbType.VarChar,200),
					new SqlParameter("@����", SqlDbType.NText),
					new SqlParameter("@����ʱ��", SqlDbType.DateTime),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@�Ƿ���ʾ", SqlDbType.Int,4),
					new SqlParameter("@�Ƿ��ö�", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.���;
            parameters[1].Value = model.����;
            parameters[2].Value = model.����;
            parameters[3].Value = model.����;
            parameters[4].Value = model.����ʱ��;
            parameters[5].Value = model.openid;
            parameters[6].Value = model.�Ƿ���ʾ;
            parameters[7].Value = model.�Ƿ��ö�;
            parameters[8].Value = model.id;

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
            strSql.Append("delete from TK_������ ");
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
            strSql.Append("delete from TK_������ ");
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
        public DTcms.Model.TK_������ GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,���,����,����,����,����ʱ��,openid,�Ƿ���ʾ,�Ƿ��ö� from TK_������ ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            DTcms.Model.TK_������ model = new DTcms.Model.TK_������();
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
        public DTcms.Model.TK_������ DataRowToModel(DataRow row)
        {
            DTcms.Model.TK_������ model = new DTcms.Model.TK_������();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["���"] != null)
                {
                    model.��� = row["���"].ToString();
                }
                if (row["����"] != null)
                {
                    model.���� = row["����"].ToString();
                }
                if (row["����"] != null)
                {
                    model.���� = row["����"].ToString();
                }
                if (row["����"] != null)
                {
                    model.���� = row["����"].ToString();
                }
                if (row["����ʱ��"] != null && row["����ʱ��"].ToString() != "")
                {
                    model.����ʱ�� = DateTime.Parse(row["����ʱ��"].ToString());
                }
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
                if (row["�Ƿ���ʾ"] != null && row["�Ƿ���ʾ"].ToString() != "")
                {
                    model.�Ƿ���ʾ = int.Parse(row["�Ƿ���ʾ"].ToString());
                }
                if (row["�Ƿ��ö�"] != null && row["�Ƿ��ö�"].ToString() != "")
                {
                    model.�Ƿ��ö� = int.Parse(row["�Ƿ��ö�"].ToString());
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
            strSql.Append("select id,���,����,����,����,����ʱ��,openid,�Ƿ���ʾ,�Ƿ��ö� ");
            strSql.Append(" FROM TK_������ ");
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
            strSql.Append(" id,���,����,����,����,����ʱ��,openid,�Ƿ���ʾ,�Ƿ��ö� ");
            strSql.Append(" FROM TK_������ ");
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
            strSql.Append("select count(1) FROM TK_������ ");
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
            strSql.Append(")AS Row, T.*  from TK_������ T ");
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
            parameters[0].Value = "TK_������";
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

