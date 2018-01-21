using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Creatrue.kernel;
using System.Data;

namespace tdx.database
{
    public class B2C_share_log
    {

        public int id = 0;
        public int s_id = 0;      //所属商家
        public int s_cent = 0;      //访问次数

        public string ip = "";        //ip地址
        public string wwv = "";           //对应的分享者

        public DateTime regdate = DateTime.Now;    //创建时间

        public B2C_share_log() { }
        public B2C_share_log(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_share_log where 1=1";
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
                s_id = Convert.IsDBNull(dr["s_id"]) ? 0 : Convert.ToInt32(dr["s_id"]);
                s_cent = Convert.IsDBNull(dr["s_cent"]) ? 0 : Convert.ToInt32(dr["s_cent"]);
                ip = Convert.IsDBNull(dr["ip"]) ? "" : Convert.ToString(dr["ip"]);
                wwv = Convert.IsDBNull(dr["wwv"]) ? "" : Convert.ToString(dr["wwv"]);
                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.s_id, this.s_cent, this.ip, this.wwv, this.regdate);
            }
            else
            {
                this.myInsertMethod(this.s_id, this.s_cent, this.ip, this.wwv, this.regdate);
            }
        }
        private void myUpdateMethod(int _id, int _s_id, int _s_cent, string _ip, string _wwv, DateTime _regdate)
        {
            string sql = "update B2C_share_log set s_id=@s_id,s_cent=@s_cent,ip=@ip,wwv=@wwv,regdate=@regdate    where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@s_id", _s_id), 
                    new SqlParameter("@s_cent", _s_cent), 
                    new SqlParameter("@ip", _ip), 
                    new SqlParameter("@wwv", _wwv), 
                    new SqlParameter("@regdate", _regdate),  
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
        private void myInsertMethod(int _s_id, int _s_cent, string _ip, string _wwv, DateTime _regdate)
        {
            string sql = "insert into B2C_share_log (s_id,s_cent,ip,wwv,regdate) values (@s_id,@s_cent,@ip,@wwv,@regdate)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@s_id", _s_id), 
                    new SqlParameter("@s_cent", _s_cent), 
                    new SqlParameter("@ip", _ip), 
                    new SqlParameter("@wwv", _wwv), 
                    new SqlParameter("@regdate", _regdate)
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
            s_id = 0;
            s_cent = 0;

            ip = "";
            wwv = "";
            regdate = DateTime.Now;
        }

        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_share_log where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
