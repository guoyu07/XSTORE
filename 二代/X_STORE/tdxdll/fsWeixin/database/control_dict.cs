using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using tdx.kernel;

namespace tdx.database
{
    public class control_dict
    {
        public int id = 0;
        //public DateTime create_time = DateTime.Now;//创建时间
        //public DateTime star_time = DateTime.Now;//创建时间
        //public DateTime end_time = DateTime.Now;//创建时间

        public int is_txt = 1;
        public string name = "";
        public string des = "";

        public control_dict() { }
        public control_dict(int _id)
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
            _sql += " from control_dict where 1=1";
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
                is_txt = Convert.IsDBNull(dr["is_txt"]) ? 0 : Convert.ToInt32(dr["is_txt"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                des = Convert.IsDBNull(dr["des"]) ? "" : Convert.ToString(dr["des"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id, is_txt, name, des);
            }
            else
            {
                this.myInsertMethod(is_txt, name, des);
            }
        }
        private void myUpdateMethod(int _id, int _is_txt, string _name, string _des)
        {
            string sql = "update control_dict set is_txt=@is_txt,name=@name, des=@des  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_txt", _is_txt), 
                     new SqlParameter("@name", _name),
                      new SqlParameter("@des", _des),
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
        private void myInsertMethod(int _is_txt, string _name, string _des)
        {
            string sql = "insert into control_dict (is_txt,name,des) values (@is_txt,@name,@des)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_txt", _is_txt),               
                     new SqlParameter("@name", _name), 
                    new SqlParameter("@des", _des)     
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
            is_txt = 0;//是否是文本框
            name = "";
            des = "";
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from control_dict where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}