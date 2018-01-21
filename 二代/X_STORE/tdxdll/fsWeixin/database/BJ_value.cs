using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using tdx.kernel;

namespace tdx.database
{
    public class BJ_value
    {
        public int id = 0;
        public int obj_id = 0;//商户ID
        public int pro_id = 0;//商品ID
        public double price = 0;//价格
        public BJ_value() { }
        public BJ_value(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        public BJ_value(string _obg_id)
        {
            this.obj_id = Convert.ToInt32(_obg_id);
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from BJ_value where 1=1";
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
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                obj_id = Convert.IsDBNull(dr["obj_id"]) ? 0 : Convert.ToInt32(dr["obj_id"]);
                pro_id = Convert.IsDBNull(dr["pro_id"]) ? 0 : Convert.ToInt32(dr["pro_id"]);
                price = Convert.IsDBNull(dr["price"]) ? 0 : Convert.ToDouble(dr["price"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void AddNew()
        {
            id = 0;
            obj_id = 0;
            pro_id = 0;
            price = 0;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from BJ_value where " + _sql + "");
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
                this.myUpdateMethod(this.id, this.price);
            }
            else
            {
                this.myInsertMethod(this.obj_id, this.pro_id, this.price);
            }
        }
        private void myUpdateMethod(int _id, double _price)
        {
            string sql = "update BJ_value set price=@price where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@price", _price), 
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
        private void myInsertMethod(int _obj_id, int _pro_id, double _price)
        {
            string sql = "insert into BJ_value (obj_id,pro_id,price) values (@obj_id,@pro_id,@price)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@obj_id", _obj_id), 
                    new SqlParameter("@pro_id",_pro_id),
                    new SqlParameter("@price", _price)
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