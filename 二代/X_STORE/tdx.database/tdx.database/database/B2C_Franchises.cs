using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Creatrue.kernel;

namespace tdx.database
{
    public class B2C_Franchises
    {
        public int id = 0;
        public DateTime create_time = DateTime.Now;//创建时间
        public int is_long = 1;
        public int group_id = 0;
        public string name = "";
        public string des = "";

        public B2C_Franchises() { }
        public B2C_Franchises(int _id)
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
            _sql += " from B2C_Franchises where 1=1";
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
                is_long = Convert.IsDBNull(dr["is_long"]) ? 0 : Convert.ToInt32(dr["is_long"]);
                group_id = Convert.IsDBNull(dr["group_id"]) ? 0 : Convert.ToInt32(dr["group_id"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                des = Convert.IsDBNull(dr["des"]) ? "" : Convert.ToString(dr["des"]);
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
                this.myUpdateMethod(id, is_long, group_id, name, des);
            }
            else
            {
                this.myInsertMethod(is_long, group_id, name, des);
            }
        }
        private void myUpdateMethod(int _id, int _is_long, int _group_id, string _name, string _des)
        {
            string sql = "update B2C_Franchises set is_long=@is_long,group_id=@group_id,name=@name, des=@des where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_long", _is_long), 
                    new SqlParameter("@group_id", _group_id),
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
        private void myInsertMethod(int _is_long, int _group_id, string _name, string _des)
        {
            string sql = "insert into B2C_Franchises (is_long,group_id,name,des) values (@is_long,@group_id,@name,@des)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_long", _is_long), 
                    new SqlParameter("@group_id", _group_id),
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
            is_long = 1;//公众号id
            group_id = 0;
            create_time = DateTime.Now;//创建时间
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
        public static int MyDel(string _id)
        {
            int result = 0;
            string sql = "delete from B2C_Franchises where id="+_id;
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
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select " + _dzd + " from B2C_Franchises where " + _sql;
                dt = comfun.GetDataTableBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}