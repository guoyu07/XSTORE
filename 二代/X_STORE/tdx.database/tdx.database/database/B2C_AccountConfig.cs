using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_AccountConfig
    {
        public int id = 0;
        public int wid = 0;//所属公众号
        public int category = 0;//对应类别
        public int opened = 0;//是否开启

        public B2C_AccountConfig() { }
        public B2C_AccountConfig(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        public B2C_AccountConfig(string wid)
        {
            this.wid = Convert.ToInt32(wid);
            this.id = 0;
            this.LoadData();
        }
        public B2C_AccountConfig(int category, int wid)
        {
            this.wid = wid;
            this.id = 0;
            this.category = category;
            this.LoadData();
        }

        //#region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_AccountConfig where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (this.category!=0)
            {
                _sql += "and wid=" + this.wid + " and category="+this.category+"" ;
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
                throw (new Exception("B2C_AccountConfig取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_AccountConfig没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                category = Convert.IsDBNull(dr["category"]) ? 0 : Convert.ToInt32(dr["category"]);
                opened = Convert.IsDBNull(dr["opened"]) ? 0 : Convert.ToInt32(dr["opened"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        /// <summary>
        /// 插入方法
        /// </summary>

        private void myInsertMethod(int _wid, int _category, int _opened)
        {
            if (wid != 0 && _category!=0)
            {
                this.wid = _wid;
                this.category = _category;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }


            string sql = @"insert into B2C_AccountConfig(wid,category,opened)
                         values (@wid,@category,@opened)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@category", _category), 
                    new SqlParameter("@opened", _opened), 
                  
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
        /// <summary>
        /// 更新方法

        private void myUpdateMethod(int _id, int _wid, int _category, int _opened)
        {
            string sql = @"update B2C_AccountConfig set wid=@wid,category=@category,opened=@opened
                          where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid),
                    new SqlParameter("@category", _category), 
                    new SqlParameter("@opened", _opened), 
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
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="_id"></param>
        private void myDeleteMethod(int _id)
        {
            if (_id == 0)
            {
                throw new NotSupportedException("没有取得ID号");
            }
            else
            {
                string sql = "delete from B2C_AccountConfig where id=" + _id;

                try
                {
                    comfun.UpdateBySQL(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        /// <summary>
        /// 添加新纪录
        /// </summary>
        public void AddNew()
        {
            this.id = 0;
            this.wid = 0;
            this.category = 0;
            this.opened = 0;
        }
        /// <summary>
        /// 更新方法
        /// </summary>
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.wid, this.category, this.opened);
            }
            else
            {
                this.myInsertMethod(this.wid, this.category, this.opened);
            }
        }
        /// <summary>
        /// 删除方法
        /// </summary>
        public void Delete()
        {
            if (this.id != 0)
                this.myDeleteMethod(this.id);
        }

        //public void updateHits()
        //{
        //    if (this.id != 0)
        //    {
        //        try
        //        {
        //            comfun.UpdateBySQL("update weixin_class set login_time=getDate() where id=" + this.id);
        //        }
        //        finally { }
        //    }
        //}
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_AccountConfig where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //#region "静态方法"
        /// <summary>
        /// 一次彻底删除一组用户
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_AccountConfig where id in (" + _ids + ")";
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

        /// <summary>
        /// 判断钱包或者积分是否开启
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static bool IsOpen(int _wid, int _category)
        {
            string _sql = "opened";
            string _where = "wid=" + _wid + " and category=" + _category;
            DataTable dt = B2C_AccountConfig.GetList(_sql,_where);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["opened"]) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else {
                return false;
            }
        }
    }
}