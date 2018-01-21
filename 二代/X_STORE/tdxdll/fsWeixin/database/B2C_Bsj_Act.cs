using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_Bsj_Act
    {
        public int id = 0;       

        public int activity_id = 0;          
        public string begin_time = "";
        public string end_time="";

        public B2C_Bsj_Act() { }
        public B2C_Bsj_Act(int _id)
        {
            this.id = _id;
            this.LoadData();
        }    
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_Bsj_Act where 1=1";
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
                throw (new Exception("B2C_Bsj_Act取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_Bsj_Act没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                activity_id = Convert.IsDBNull(dr["activity_id"]) ? 0 : Convert.ToInt32(dr["activity_id"]);
                begin_time = Convert.IsDBNull(dr["begin_time"]) ? "" : Convert.ToString(dr["begin_time"]);
                end_time = Convert.IsDBNull(dr["end_time"]) ? "" : Convert.ToString(dr["end_time"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id, activity_id, begin_time, end_time);
            }
            else
            {
                this.myInsertMethod(activity_id, begin_time, end_time);
            }
        }
        private void myUpdateMethod(int _id, int _activity_id, string _begin_time, string _end_time)
        {
            string sql = "update B2C_Bsj_Act set activity_id=@activity_id,begin_time=@begin_time,end_time=@end_time where id="+_id.ToString();
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@activity_id", _activity_id), 
                     new SqlParameter("@begin_time", _begin_time),
                      new SqlParameter("@end_time", _end_time)  
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
        private void myInsertMethod(int _activity_id, string _begin_time, string _end_time)
        {
            string sql = "insert into B2C_Bsj_Act (activity_id,begin_time,end_time) values (@activity_id,@begin_time,@end_time)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@activity_id", _activity_id),               
                     new SqlParameter("@begin_time", _begin_time), 
                    new SqlParameter("@end_time", _end_time)
                      
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
            activity_id = 0;//是否是文本框
            begin_time = "";
            end_time = "";
        }
       
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Bsj_Act where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}