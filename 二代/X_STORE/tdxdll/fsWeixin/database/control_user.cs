using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using tdx.kernel;

namespace tdx.database
{
    public class control_user
    {
        public int id = 0;
        //public DateTime create_time = DateTime.Now;//创建时间
        //public DateTime star_time = DateTime.Now;//创建时间
        //public DateTime end_time = DateTime.Now;//创建时间

        public int key_id = 0;
        public int value_id = 0;
        public int mid = 0;
        public string value_txt = "";
        public string ip = "";
        public DateTime regtime = DateTime.Now;//创建时间
        public string ono = "";
        public string wwv = "";
        public control_user() { }
        public control_user(int _id)
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
            _sql += " from control_user where 1=1";
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
                value_id = Convert.IsDBNull(dr["value_id"]) ? 0 : Convert.ToInt32(dr["value_id"]);
                mid = Convert.IsDBNull(dr["mid"]) ? 0 : Convert.ToInt32(dr["mid"]);
                value_txt = Convert.IsDBNull(dr["value_txt"]) ? "" : Convert.ToString(dr["value_txt"]);
                ip = Convert.IsDBNull(dr["ip"]) ? "" : Convert.ToString(dr["ip"]);
                regtime = Convert.IsDBNull(dr["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regtime"]);
                ono = Convert.IsDBNull(dr["ono"]) ? "" : dr["regtime"].ToString();
                wwv = Convert.IsDBNull(dr["wwv"]) ? "" : dr["wwv"].ToString();
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id, key_id, value_id, mid, value_txt, ip, ono, wwv);
            }
            else
            {
                this.myInsertMethod(key_id, value_id, mid, value_txt, ip,ono, wwv);
            }
        }
        private void myUpdateMethod(int _id, int _key_id, int _value_id, int _mid, string _value_txt, string _ip, string _ono, string _wwv)
        {
            string sql = "update control_user set key_id=@key_id,value_id=@value_id,mid=@mid,value_txt=@value_txt, ip=@ip,ono=@ono,wwv=@wwv  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@key_id", _key_id), 
                    new SqlParameter("@value_id", _value_id),
                    new SqlParameter("@mid", _mid),
                    new SqlParameter("@value_txt", _value_txt),
                    new SqlParameter("@ip", _ip),
                    new SqlParameter("@ono",_ono),
                    new SqlParameter("@wwv",_wwv),
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
        private void myInsertMethod(int _key_id, int _value_id, int _mid, string _value_txt, string _ip, string _ono, string _wwv)
        {
            string sql = "insert into control_user (key_id,value_id,mid,value_txt,ip,ono,wwv) values (@key_id,@value_id,@mid,@value_txt,@ip,@ono,@wwv) ";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@key_id", _key_id),  
                    new SqlParameter("@value_id", _value_id),      
                    new SqlParameter("@mid", _mid),      
                    new SqlParameter("@value_txt", _value_txt), 
                    new SqlParameter("@ip", _ip),
                    new SqlParameter("@ono", _ono),
                    new SqlParameter("@wwv", _wwv)    
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
            value_id = 0;
            mid = 0;
            value_txt = "";
            ip = "";
            regtime = DateTime.Now;
            ono = "";
            wwv = "";
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from control_user where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}