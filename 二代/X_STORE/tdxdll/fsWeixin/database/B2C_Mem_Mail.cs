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
using tdx.kernel;

namespace tdx.database
{
    public class B2C_Mem_Mail
    {
        public int id = 0;
        public int mid = 0;
        public string n_title = "";
        public string n_msg = "";
        public string n_target = "";
        public int n_isRead = 0;
        public int n_isReply = 0;
        public int n_isdel = 0;
        public DateTime regtime = DateTime.Now;
        public int cityID = 1;

        public B2C_Mem_Mail() { }
        public B2C_Mem_Mail(int _id)
        {
            id = _id;
            this.load();
        }

        private void load()
        {
            string sql = "select * from B2C_Mem_Mail where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_Mem_Mail_id：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mid"]);
                    n_title = Convert.IsDBNull(dt.Rows[0]["n_title"]) ? "" : Convert.ToString(dt.Rows[0]["n_title"]);
                    n_msg = Convert.IsDBNull(dt.Rows[0]["n_msg"]) ? "" : Convert.ToString(dt.Rows[0]["n_msg"]);
                    n_target = Convert.IsDBNull(dt.Rows[0]["n_target"]) ? "" : Convert.ToString(dt.Rows[0]["n_target"]);
                    n_isRead = Convert.IsDBNull(dt.Rows[0]["n_isRead"]) ? 0 : Convert.ToInt32(dt.Rows[0]["n_isRead"]);
                    n_isReply = Convert.IsDBNull(dt.Rows[0]["n_isReply"]) ? 0 : Convert.ToInt32(dt.Rows[0]["n_isReply"]);
                    n_isdel = Convert.IsDBNull(dt.Rows[0]["n_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["n_isdel"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_Mem_Mail_id：" + id + "不存在");
            }
        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _mid, string _n_title, string _n_msg, string n_target_, int _n_isRead, int _n_isReply, int _n_isdel, int _cityID)
        {
            try
            {
                string sql = "insert into B2C_Mem_Mail (mid,n_title,n_msg,n_target,n_isRead,n_isReply,n_isdel,cityID) values (@mid,@n_title,@n_msg,@n_target,@n_isRead,@n_isReply,@n_isdel,@cityID)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mid", _mid), 
                    new SqlParameter("@n_title", _n_title), 
                    new SqlParameter("@n_msg", _n_msg),
                    new SqlParameter("@n_target", n_target_),
                    new SqlParameter("@n_isRead", _n_isRead),
                    new SqlParameter("@n_isReply", _n_isReply),
                    new SqlParameter("@n_isdel", _n_isdel),
                    new SqlParameter("@cityID", _cityID)};

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
        private void myUpdate(int _id, int _mid, string _n_title, string _n_msg, string n_target_, int _n_isRead, int _n_isReply, int _n_isdel, int _cityID)
        {
            try
            {
                string sql = "update B2C_Mem_Mail set mid=@mid,n_title=@n_title,n_msg=@n_msg,n_target=@n_target,n_isRead=@n_isRead,n_isReply=@n_isReply,n_isdel=@n_isdel,cityID=@cityID where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mid", _mid), 
                    new SqlParameter("@n_title", _n_title), 
                    new SqlParameter("@n_msg", _n_msg),
                    new SqlParameter("@n_target", n_target_),
                    new SqlParameter("@n_isRead", _n_isRead),
                    new SqlParameter("@n_isReply", _n_isReply),
                    new SqlParameter("@n_isdel", _n_isdel),
                    new SqlParameter("@cityID", _cityID)};

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
            string sql = "delete from B2C_Mem_Mail where id=" + _id + "";
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
                this.myInsert(mid, n_title, n_msg, n_target, n_isRead, n_isReply, n_isdel, cityID);
            }
            else
            {
                this.myUpdate(id, mid, n_title, n_msg, n_target, n_isRead, n_isReply, n_isdel, cityID);
            }
        }
        /// <summary>
        /// 添加默认方法
        /// </summary>
        public void AddNew()
        {
            id = 0;
            mid = 0;
            n_title = "";
            n_msg = "";
            n_target = "";
            n_isRead = 0;
            n_isReply = 0;
            n_isdel = 0;
            regtime = DateTime.Now;
            cityID = 1;
        }
        #region 按钮功能
        /// <summary>
        /// 设置是否已读
        /// </summary>
        /// <param name="_cid"></param>
        public static int isRead(string _cid,string _sjr)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Mem_Mail set n_isRead= -1 * (n_isRead - 1) where n_target='" + _sjr + "' and id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 设置是否已回
        /// </summary>
        /// <param name="_cid"></param>
        public static int isReply(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Mem_Mail set n_isReply= -1 * (n_isReply - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 设置是否删除(加入回收站)
        /// </summary>
        /// <param name="_cid"></param>
        public static int isdel(string _cid,string _mname)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Mem_Mail set n_isdel= -1 * (n_isdel - 1) where n_target='" + _mname + "' and id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetList(string _dzd,string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Mem_Mail where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion
    }
}
