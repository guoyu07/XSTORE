using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Creatrue.kernel;

namespace tdx.database
{
    public class BJ_obj
    {
        public int id = 0;
        public int wid = 0;//商户ID
        public string name = "";//商家名称
        public BJ_obj() { }
        public BJ_obj(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from BJ_obj where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (wid != 0)
            {
                _sql += " and wid=" + this.wid;
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void AddNew()
        {
            id = 0;
            wid = 0;
            name = "";
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from BJ_obj where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.name);
            }
            else
            {
                this.myInsertMethod(this.wid, this.name);
            }
        }
        private void myUpdateMethod(int _id, string _name)
        {
            string sql = "update BJ_obj set name=@name where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@name", _name), 
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
        private void myInsertMethod(int _wid, string _name)
        {
            string sql = "insert into BJ_obj (wid,name) values (@wid,@name)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                     new SqlParameter("@name", _name)
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
    }
}