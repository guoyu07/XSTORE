using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using tdx.kernel;

namespace tdx.database
{
    public class control_key
    {
        public int id = 0;
        //public DateTime create_time = DateTime.Now;//创建时间
        //public DateTime star_time = DateTime.Now;//创建时间
        //public DateTime end_time = DateTime.Now;//创建时间

        public int wid = 0;
           public int type_id = 1;
           public int sort = 99;
        public string name = "";

        public control_key() { }
        public control_key(int _id)
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
            _sql += " from control_key where 1=1";
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
                type_id = Convert.IsDBNull(dr["type_id"]) ? 0 : Convert.ToInt32(dr["type_id"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                sort = Convert.IsDBNull(dr["sort"]) ? 0 : Convert.ToInt32(dr["sort"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id,wid,type_id,sort,name);
            }
            else
            {
                this.myInsertMethod(wid, type_id, sort, name);
            }
        }
        private void myUpdateMethod(int _id, int _wid, int _type_id, int _sort, string _name)
        {
            string sql = "update control_key set wid=@wid,type_id=@type_id,sort=@sort,name=@name  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                     new SqlParameter("@type_id", _type_id),
                      new SqlParameter("@sort", _sort),
                       new SqlParameter("@name", _name),
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
        private void myInsertMethod(int _wid, int _type_id,int _sort,  string _name)
        {
            string sql = "insert into control_key (wid,type_id,sort,name) values (@wid,@type_id,@sort,@name)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid),               
                     new SqlParameter("@type_id", _type_id), 
                    new SqlParameter("@sort", _sort),
                      new SqlParameter("@name", _name)  
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
            sort =99;
            type_id = 1;
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from control_key where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}