using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class C2C_voucher
    {
        public int id = 0;
        public int wid = 0;//所属商家
        public int v_num = 0;//发行数量
        public int v_amount = 0;//使用金额条件
        public int v_deduction = 0;//抵扣金额
        public int v_isactive = 0;//是否激活
        public DateTime v_start_time = DateTime.Now;//有效期开始
        public DateTime v_end_time = DateTime.Now;//有效期结束
        public DateTime regtime = DateTime.Now;//创建时间

        public C2C_voucher() { }
        public C2C_voucher(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from C2C_voucher where 1=1";
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
                wid = Convert.IsDBNull(dr["wid"]) ? 1 : Convert.ToInt32(dr["wid"]);
                v_num = Convert.IsDBNull(dr["v_num"]) ? 0 : Convert.ToInt32(dr["v_num"]);
                v_amount = Convert.IsDBNull(dr["v_amount"]) ? 0 : Convert.ToInt32(dr["v_amount"]);
                v_deduction = Convert.IsDBNull(dr["v_deduction"]) ? 0 : Convert.ToInt32(dr["v_deduction"]);
                v_isactive = Convert.IsDBNull(dr["v_isactive"]) ? 0 : Convert.ToInt32(dr["v_isactive"]);

                v_start_time = Convert.IsDBNull(dr["v_start_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["v_start_time"]);
                v_end_time = Convert.IsDBNull(dr["v_end_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["v_end_time"]);
                regtime = Convert.IsDBNull(dr["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regtime"]);

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.wid, this.v_num, this.v_amount, this.v_deduction, this.v_isactive, this.v_start_time, this.v_end_time);
            }
            else
            {
                this.myInsertMethod(this.wid, this.v_num, this.v_amount, this.v_deduction, this.v_isactive, this.v_start_time, this.v_end_time);
            }
        }
        private void myUpdateMethod(int _id, int _wid, int _v_num, int _v_amount, int _v_deduction, int _v_isactive, DateTime _v_start_time, DateTime _v_end_time)
        {
            string sql = "update C2C_voucher set wid=@wid,v_num=@v_num,v_amount=@v_amount,v_deduction=@v_deduction,v_isactive=@v_isactive,v_start_time=@v_start_time,v_end_time=@v_end_time  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@v_num", _v_num), 
                    new SqlParameter("@v_amount", _v_amount), 
                    new SqlParameter("@v_deduction", _v_deduction), 
                    new SqlParameter("@v_isactive", _v_isactive), 
                    new SqlParameter("@v_start_time", _v_start_time), 
                    new SqlParameter("@v_end_time", _v_end_time), 
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
        private void myInsertMethod(int _wid, int _v_num, int _v_amount, int _v_deduction, int _v_isactive, DateTime _v_start_time, DateTime _v_end_time)
        {
            string sql = "insert into C2C_voucher (wid,v_num,v_amount,v_deduction,v_isactive,v_start_time,v_end_time) values (@wid,@v_num,@v_amount,@v_deduction,@v_isactive,@v_start_time,@v_end_time)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@v_num", _v_num), 
                    new SqlParameter("@v_amount", _v_amount), 
                    new SqlParameter("@v_deduction", _v_deduction), 
                    new SqlParameter("@v_isactive", _v_isactive), 
                    new SqlParameter("@v_start_time", _v_start_time), 
                    new SqlParameter("@v_end_time", _v_end_time) 
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
        public static int IsNoactive(string _ids)
        {
            int result = 0;

            string sql = "update C2C_voucher  set v_isactive=0  where id in (" + _ids + ")";
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
        public void AddNew()
        {
            id = 0;

            wid = 0;//公众号id
            v_num = 0;
            v_amount = 0;
            v_deduction = 0;
            v_isactive = 0;
            v_start_time = DateTime.Now;//创建时间
            v_end_time = DateTime.Now;
            regtime = DateTime.Now;
        }

        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from C2C_voucher where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
