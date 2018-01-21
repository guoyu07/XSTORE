using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using tdx.kernel;

namespace tdx.database
{
    public class control_value
    {
         public int id = 0;
        //public DateTime create_time = DateTime.Now;//创建时间
        //public DateTime star_time = DateTime.Now;//创建时间
        //public DateTime end_time = DateTime.Now;//创建时间

        public int key_id = 1;
        public int is_select = 1;
        public int sort = 99;
        public string value = "";

        public control_value() { }
        public control_value(int _id)
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
            _sql += " from control_value where 1=1";
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
                key_id = Convert.IsDBNull(dr["key_id"]) ? 0 : Convert.ToInt32(dr["key_id"]);
                is_select = Convert.IsDBNull(dr["is_select"]) ? 0 : Convert.ToInt32(dr["is_select"]);
                sort = Convert.IsDBNull(dr["sort"]) ? 0 : Convert.ToInt32(dr["sort"]);
                value = Convert.IsDBNull(dr["value"]) ? "" : Convert.ToString(dr["value"]); 
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id,key_id,is_select,sort,value);
            }
            else
            {
                this.myInsertMethod(key_id,is_select,sort,value);
            }
        }
        private void myUpdateMethod(int _id, int _key_id, int _is_select, int _sort, string _value)
        {
            string sql = "update control_value set key_id=@key_id,is_select=@is_select, sort=@sort,value=@value  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@key_id", _key_id), 
                     new SqlParameter("@is_select", _is_select),
                     new SqlParameter("@sort", _sort),
                      new SqlParameter("@value", _value),
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
        private void myInsertMethod(int _key_id, int _is_select, int _sort, string _value)
        {
            string sql = "insert into control_value (key_id,is_select,sort,value) values (@key_id,@is_select,@sort,@value)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@key_id", _key_id),               
                     new SqlParameter("@is_select", _is_select), 
                    new SqlParameter("@sort", _sort),
                     new SqlParameter("@value", _value) 
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
            key_id = 0;//是否是文本框
            is_select = 0;
            sort = 99;
            value = "";
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from control_value where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}