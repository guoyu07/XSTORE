using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class control_obj
    {
        public int id = 0;
        //public DateTime create_time = DateTime.Now;//创建时间
        //public DateTime star_time = DateTime.Now;//创建时间
        //public DateTime end_time = DateTime.Now;//创建时间

        public int wid = 0;
        public string name = "";
        public string des = "";
        public string urls = "";
        public control_obj() { }
        public control_obj(int _id)
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
            _sql += " from control_obj where 1=1";
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
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                des = Convert.IsDBNull(dr["des"]) ? "" : Convert.ToString(dr["des"]);
                urls = Convert.IsDBNull(dr["urls"]) ? "" : Convert.ToString(dr["urls"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id, wid, name,des,urls);
            }
            else
            {
                this.myInsertMethod(wid, name,des,urls);
            }
        }
        private void myUpdateMethod(int _id, int _wid, string _name,string _des,string _urls)
        {
            string sql = "update control_obj set wid=@wid,des=@des,name=@name,urls=@urls  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                     new SqlParameter("@name", _name),
                       new SqlParameter("@des", _des),
                       new SqlParameter("@urls", _urls),
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
        private void myInsertMethod(int _wid, string _name, string _des,string _urls)
        {
            string sql = "insert into control_obj (wid,name,des,urls) values (@wid,@name,@des,@urls)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid),               
                     new SqlParameter("@name", _name),
                     new SqlParameter("@des", _des),
                     new SqlParameter("@urls", _urls)
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
            wid = 0;//是否是文本框
            name = "";
            des = "";
            urls = "";
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from control_obj where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}