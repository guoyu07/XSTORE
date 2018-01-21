using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class C2C_voucher_log
    {
        public int id = 0;
        public int v_id = 0;//关联代金卷
        public int mid = 0;//关联会员ID B2C_MEM
        public int isuse = 0;//是否使用默认0
        public DateTime vl_date = DateTime.Now;//领用时间
        public DateTime vl_update = DateTime.Now;//使用时间 使用时更新时间 此时isuse=1

        public C2C_voucher_log() { }
        public C2C_voucher_log(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from C2C_voucher_log where 1=1";
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
                v_id = Convert.IsDBNull(dr["v_id"]) ? 1 : Convert.ToInt32(dr["v_id"]);
                mid = Convert.IsDBNull(dr["mid"]) ? 0 : Convert.ToInt32(dr["mid"]);
                isuse = Convert.IsDBNull(dr["isuse"]) ? 0 : Convert.ToInt32(dr["isuse"]);
                vl_date = Convert.IsDBNull(dr["vl_date"]) ? System.DateTime.Now : Convert.ToDateTime(dr["vl_date"]);
                vl_update = Convert.IsDBNull(dr["vl_update"]) ? System.DateTime.Now : Convert.ToDateTime(dr["vl_update"]);

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.v_id, this.mid, this.isuse, this.vl_date, this.vl_update);
            }
            else
            {
                this.myInsertMethod(this.v_id, this.mid, this.isuse, this.vl_date, this.vl_update);
            }
        }
        private void myUpdateMethod(int _id, int _v_id, int _mid, int _isuse, DateTime _vl_date, DateTime _vl_update)
        {
            string sql = "update C2C_voucher_log set v_id=@v_id,mid=@mid,isuse=@isuse,vl_date=@vl_date,vl_update=@vl_update where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@v_id", _v_id), 
                    new SqlParameter("@mid", _mid), 
                    new SqlParameter("@isuse", _isuse), 
                    new SqlParameter("@vl_date", _vl_date), 
                    new SqlParameter("@_vl_update", _vl_update),  
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
        private void myInsertMethod(int _v_id, int _mid, int _isuse, DateTime _vl_date, DateTime _vl_update)
        {
            string sql = "insert into C2C_voucher_log (v_id,mid,isuse,vl_date,vl_update) values (@v_id,@mid,@isuse,@vl_date,@vl_update)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@v_id", _v_id), 
                    new SqlParameter("@mid", _mid), 
                    new SqlParameter("@isuse", _isuse), 
                    new SqlParameter("@vl_date", _vl_date), 
                    new SqlParameter("@vl_update", _vl_update)
                  
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

            v_id = 0;//公众号id
            mid = 0;
            isuse = 0;
            vl_date = DateTime.Now;//创建时间
            vl_update = DateTime.Now;
        }

        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from C2C_voucher_log where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
