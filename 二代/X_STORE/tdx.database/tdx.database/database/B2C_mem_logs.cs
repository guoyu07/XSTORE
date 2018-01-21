using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Creatrue.kernel;

namespace tdx.database
{
    public class B2C_mem_logs
    {
        public int id = 0;
        public string log_action = "";
        public string log_IPs = "";
        public string log_tabs = "";
        public string log_rows = "";
        public string log_values = "";
        public string tag_tabs = "";
        public string tag_rows = "";
        public string tag_value = "";
        public string log_timezone = "";
        public string log_browser = "";
        public string log_width = "";
        //public int cityID = 1;

        public B2C_mem_logs() { }
        public B2C_mem_logs(int _id) {
            id = _id;
            this.load();
        }
        private void load()
        {
            string sql = "select * from B2C_mem_logs where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_mem_logs_id：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    log_action = Convert.IsDBNull(dt.Rows[0]["log_action"]) ? "" : Convert.ToString(dt.Rows[0]["log_action"]);
                    log_IPs = Convert.IsDBNull(dt.Rows[0]["log_IPs"]) ? "" : Convert.ToString(dt.Rows[0]["log_IPs"]);
                    log_tabs = Convert.IsDBNull(dt.Rows[0]["log_tabs"]) ? "" : Convert.ToString(dt.Rows[0]["log_tabs"]);
                    log_rows = Convert.IsDBNull(dt.Rows[0]["log_rows"]) ? "" : Convert.ToString(dt.Rows[0]["log_rows"]);
                    log_values = Convert.IsDBNull(dt.Rows[0]["log_values"]) ? "" : Convert.ToString(dt.Rows[0]["log_values"]);
                    tag_tabs = Convert.IsDBNull(dt.Rows[0]["tag_tabs"]) ? "" : Convert.ToString(dt.Rows[0]["tag_tabs"]);
                    tag_rows = Convert.IsDBNull(dt.Rows[0]["tag_rows"]) ? "" : Convert.ToString(dt.Rows[0]["tag_rows"]);
                    tag_value = Convert.IsDBNull(dt.Rows[0]["tag_value"]) ? "" : Convert.ToString(dt.Rows[0]["tag_value"]);
                    log_timezone = Convert.IsDBNull(dt.Rows[0]["log_timezone"]) ? "" : Convert.ToString(dt.Rows[0]["log_timezone"]);
                    log_browser = Convert.IsDBNull(dt.Rows[0]["log_browser"]) ? "" : Convert.ToString(dt.Rows[0]["log_browser"]);
                    log_width = Convert.IsDBNull(dt.Rows[0]["log_width"]) ? "" : Convert.ToString(dt.Rows[0]["log_width"]);
                    //cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_mem_logs_id：" + id + "不存在");
            }
        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _log_action, string _log_IPs, string _log_tabs, string _log_rows, string _log_values, string _tag_tabs, string _tag_rows, string _tag_value, string _log_timezone, string _log_browser, string _log_width)//, int _cityID
        {
            try
            {//                                                                                                                                ,cityID                                                                                                                                                              
                string sql = "insert into B2C_mem_logs (log_action,log_IPs,log_tabs,log_rows,log_values,tag_tabs,tag_rows,tag_value,log_timezone,log_browser,log_width) values (@log_action,@log_IPs,@log_tabs,@log_rows,@log_values,@tag_tabs,@tag_rows,@tag_value,@log_timezone,@log_browser,@log_width)";//,@cityID
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@log_action", _log_action), 
                    new SqlParameter("@log_IPs", _log_IPs), 
                    new SqlParameter("@log_tabs", _log_tabs),
                    new SqlParameter("@log_rows", _log_rows),
                    new SqlParameter("@log_values", _log_values),
                    new SqlParameter("@tag_tabs", _tag_tabs),
                    new SqlParameter("@tag_rows", _tag_rows),
                    new SqlParameter("@tag_value", _tag_value),
                    new SqlParameter("@log_timezone", _log_timezone),
                    new SqlParameter("@log_browser", _log_browser),
                    new SqlParameter("@log_width", _log_width)};//,new SqlParameter("@cityID", _cityID)

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary> 
        public static int myDel(int _id)
        {
            string sql = "delete from B2C_mem_logs where id=" + _id + "";
            try
            {
                return comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(log_action, log_IPs, log_tabs, log_rows, log_values, tag_tabs, tag_rows, tag_value, log_timezone, log_browser, log_width); //, cityID
            }
        }
        /// <summary>
        /// 添加默认方法
        /// </summary>
        public void AddNew()
        {
            id = 0;
            log_action = "";
            log_IPs = "";
            log_tabs = "";
            log_rows = "";
            log_values = "";
            tag_tabs = "";
            tag_rows = "";
            tag_value = "";
            log_timezone = "";
            log_browser = "";
            log_width = "";
            //cityID = 1;
        }
        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataTable GetList(int _page, string _dzd, string _sql)
        {
            try
            {
                DataTable dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_mem_logs where " + _sql + "");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
