using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using tdx.kernel;

namespace tdx.database
{
    public class B2C_rankvsfran
    {
        public int id = 0;
        public DateTime create_time = DateTime.Now;//创建时间
        public int franid = 0;
        public int rankid = 0;

        public B2C_rankvsfran() { }
        public B2C_rankvsfran(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        //public B2C_group_fran(string _wid)
        //{
        //    this.wid = int.Parse(_wid);
        //    this.LoadData();
        //}
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_rankvsfran where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                franid = Convert.IsDBNull(dr["franid"]) ? 0 : Convert.ToInt32(dr["franid"]);
                rankid = Convert.IsDBNull(dr["rankid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                create_time = Convert.IsDBNull(dr["create_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["create_time"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id, franid, rankid);
            }
            else
            {
                this.myInsertMethod(franid, rankid);
            }
        }
        private void myUpdateMethod(int _id, int _franid, int _rankid)
        {
            string sql = "update B2C_rankvsfran set franid=@franid,rankid=@rankid  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@franid", _franid), 
                    new SqlParameter("@rankid", _rankid), 
                    new SqlParameter("@id",_id)};

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        private void myInsertMethod(int _franid, int _rankid)
        {
            string sql = "insert into B2C_rankvsfran (franid,rankid) values (@franid,@rankid)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@franid", _franid), 
                    new SqlParameter("@rankid", _rankid)
                    };
            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public void AddNew()
        {
            id = 0;
            franid = 0;//公众号id
            rankid = 0;
            create_time = DateTime.Now;//创建时间
        }
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_rankvsfran where " + _ids;
            try
            {
                comfun.UpdateBySQL(sql);
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_rankvsfran where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}