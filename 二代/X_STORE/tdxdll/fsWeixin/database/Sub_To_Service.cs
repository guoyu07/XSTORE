using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tdx.kernel;
using System.Data;
using System.Data.SqlClient;

namespace tdx.database
{
    public class Sub_To_Service
    {
        public int id = 0;
        public string sub_company = "";
        public string sub_name = "";
        public string sub_mobile = "";
        public string sub_email = "";
        public string sub_zhiwu = "";
        public string sub_time = DateTime.Now.ToString();
        public string sub_ip = "";
        public int wid = 0;
        public int sub_type = 0;
        public int sub_from = 1;
        public Sub_To_Service() { }
        public Sub_To_Service(int _id)
        {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select * from Sub_To_Service where id=" + id + " and  wid=" + System.Web.HttpContext.Current.Session["wID"].ToString();
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("Sub_To_Service：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    sub_company = Convert.IsDBNull(dt.Rows[0]["sub_company"]) ? "" : Convert.ToString(dt.Rows[0]["sub_company"]);
                    sub_name = Convert.IsDBNull(dt.Rows[0]["sub_name"]) ? "" : Convert.ToString(dt.Rows[0]["sub_name"]);
                    sub_mobile = Convert.IsDBNull(dt.Rows[0]["sub_mobile"]) ? "" : Convert.ToString(dt.Rows[0]["sub_mobile"]);

                    sub_email = Convert.IsDBNull(dt.Rows[0]["sub_email"]) ? "" : Convert.ToString(dt.Rows[0]["sub_email"]);

                    sub_zhiwu = Convert.IsDBNull(dt.Rows[0]["sub_zhiwu"]) ? "" : Convert.ToString(dt.Rows[0]["sub_zhiwu"]);
                    sub_time = Convert.IsDBNull(dt.Rows[0]["sub_time"]) ? "" : Convert.ToString(dt.Rows[0]["sub_time"]);
                    sub_ip = Convert.IsDBNull(dt.Rows[0]["sub_ip"]) ? "" : Convert.ToString(dt.Rows[0]["sub_ip"]);
                    wid = Convert.IsDBNull(dt.Rows[0]["wid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["wid"]);
                    sub_type = Convert.IsDBNull(dt.Rows[0]["sub_type"]) ? 1 : Convert.ToInt32(dt.Rows[0]["sub_type"]);
                    sub_from = Convert.IsDBNull(dt.Rows[0]["sub_from"]) ? 1 : Convert.ToInt32(dt.Rows[0]["sub_from"]);
                }
            }
            else
            {
                throw new NotSupportedException("Sub_To_Service：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _sub_company, string _sub_name, string _sub_mobile, string _sub_email, string _sub_zhiwu, string _sub_time, string _sub_ip, int _wid, int _sub_type, int _sub_from)
        {
            try
            {
                string sql = "insert into Sub_To_Service (sub_company,sub_name,sub_mobile,sub_email,sub_zhiwu,sub_time,sub_ip,wid,sub_type,sub_from) values (@sub_company,@sub_name,@sub_mobile,@sub_email,@sub_zhiwu,@sub_time,@sub_ip,@wid,@sub_type,@sub_from)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@sub_company", _sub_company), 
                    new SqlParameter("@sub_name", _sub_name), 
                    new SqlParameter("@sub_mobile", _sub_mobile), 
                    new SqlParameter("@sub_email", _sub_email), 
                    new SqlParameter("@sub_zhiwu", _sub_zhiwu),
                    new SqlParameter("@sub_time", _sub_time),
                    new SqlParameter("@sub_ip", _sub_ip),
                    new SqlParameter("@wid", _wid),
                    new SqlParameter("@sub_type",_sub_type),
                     new SqlParameter("@sub_from",_sub_from)
                };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 修改一条新的记录
        /// </summary>
        private void myUpdate(int _id, string _sub_company, string _sub_name, string _sub_mobile, string _sub_email, string _sub_zhiwu, string _sub_time, string _sub_ip, int _wid, int _sub_type, int _sub_from)
        {
            try
            {
                string sql = "update Sub_To_Service set sub_company=@sub_company,sub_name=@sub_name,sub_mobile=@sub_mobile,sub_email=@sub_email,sub_zhiwu=@sub_zhiwu,sub_time=@sub_time,sub_ip=@sub_ip,wid=@wid,sub_type=@sub_type,sub_from=@sub_from where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@sub_company", _sub_company), 
                    new SqlParameter("@sub_name", _sub_name), 
                    new SqlParameter("@sub_mobile", _sub_mobile), 
                    new SqlParameter("@sub_email", _sub_email), 
                    new SqlParameter("@sub_zhiwu", _sub_zhiwu),
                    new SqlParameter("@sub_time", _sub_time),
                    new SqlParameter("@sub_ip", _sub_ip),
                    new SqlParameter("@wid", _wid),
                    new SqlParameter("@sub_type",_sub_type),
                     new SqlParameter("@sub_from",_sub_from)
                };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(sub_company, sub_name, sub_mobile, sub_email, sub_zhiwu, sub_time, sub_ip, wid, sub_type,sub_from);
            }
            else
            {
                this.myUpdate(id, sub_company, sub_name, sub_mobile, sub_email, sub_zhiwu, sub_time, sub_ip, wid, sub_type,sub_from);
            }
        }

        public void AddNew()
        {
            id = 0;
            sub_company = "";
            sub_name = "";
            sub_mobile = "";
            sub_email = "";
            sub_zhiwu = "";
            sub_time = DateTime.Now.ToString();
            sub_ip = "";
            wid = 0;
            sub_type = 0;
            sub_from = 1;
        }
    }
}