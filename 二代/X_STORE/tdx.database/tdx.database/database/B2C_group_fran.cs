using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_group_fran
    {
        public int id = 0;
        public DateTime create_time = DateTime.Now;//创建时间
        public string name = "";//特权名称
        public int wid = 0;

        public B2C_group_fran() { }
        public B2C_group_fran(int _id)
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
            _sql += " from B2C_group_fran where 1=1";
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
            if (dt.Rows.Count > 1)
            {
                throw (new Exception("B2C_vipcard取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_vipcard没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);  
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
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
                this.myUpdateMethod(this.id,this.name);
            }
            else
            {
                this.myInsertMethod( this.wid, this.name);
            }
        }
        private void myUpdateMethod(int _id,  string _name)
        {
            string sql = "update B2C_group_fran set name=@name where id=@id";
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
        private void myInsertMethod( int _wid, string _name)
        {
            string sql = "insert into B2C_group_fran (wid,name) values (@wid,@name)";
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
        public void AddNew()
        {
            id = 0;
            wid = 0;//公众号id
            name = "";//名称
            create_time = DateTime.Now;//创建时间
        }
        //public static int delete(string _ids)
        //{
        //    int result = 0;

        //    string sql = "delete from B2C_vipcard where id in (" + _ids + ")";
        //    try
        //    {
        //        comfun.UpdateBySQL(sql);
        //        result = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = 0;
        //        throw ex;
        //    }
        //    return result;
        //}
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_group_fran where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}