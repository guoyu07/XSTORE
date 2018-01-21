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
    public class B2C_laws_notes
    {
        public int id = 0;                     //编号，自增 
        public int tID = 0;                 //所属会员ID
        public string tname = "";           //所属会员号 
        public string n_name = "";           //商户名
        public string n_msg = "";             //页面标题
        public string n_email = "";           //页面内容 
        public string n_ips = "";               //图片文件名   
        DateTime regtime = DateTime.Now;       //录入时间  

        public B2C_laws_notes() { }
        public B2C_laws_notes(int _id)
        {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select gtitle from b2c_laws where b2c_laws.id=b2c_laws_logs.tid) as tname from B2C_laws_notes where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_laws_notesID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]); 
                    tID = Convert.IsDBNull(dt.Rows[0]["tID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["tID"]);
                    tname = Convert.IsDBNull(dt.Rows[0]["tname"]) ? "" : Convert.ToString(dt.Rows[0]["tname"]);
                    n_name = Convert.IsDBNull(dt.Rows[0]["n_name"]) ? "" : Convert.ToString(dt.Rows[0]["n_name"]);
                    n_msg = Convert.IsDBNull(dt.Rows[0]["n_msg"]) ? "" : Convert.ToString(dt.Rows[0]["n_msg"]);
                    n_email = Convert.IsDBNull(dt.Rows[0]["n_email"]) ? "" : Convert.ToString(dt.Rows[0]["n_email"]);
                    n_ips = Convert.IsDBNull(dt.Rows[0]["n_ips"]) ? "" : Convert.ToString(dt.Rows[0]["n_ips"]);  
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); 
                }
            }
            else
            {
                throw new NotSupportedException("B2C_laws_notesID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _tID, string _nname, string _nmsg, string _nemail, string _nips)
        {
            try
            {
                string sql = "insert into B2C_laws_notes (tid,n_name,n_msg,n_email,n_ips) values (@tid,@nname,@nmsg,@nemail,@nips)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@tid", _tID), 
                    new SqlParameter("@nname", _nname), 
                    new SqlParameter("@nmsg", _nmsg), 
                    new SqlParameter("@nemail", _nemail),
                    new SqlParameter("@nips", _nips)};

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
        private void myUpdate(int _id, int _tID, string _nname, string _nmsg, string _nemail, string _nips)
        {
            try
            {
                string sql = "update B2C_laws_notes set tid=@tid,n_name=@nname,n_msg=@nmsg,n_email=@nemail,n_ips=@nips where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@tid", _tID), 
                    new SqlParameter("@nname", _nname), 
                    new SqlParameter("@nmsg", _nmsg), 
                    new SqlParameter("@nemail", _nemail),
                    new SqlParameter("@nips", _nips)};


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
        public static int myDel(int _cid)
        {
            int res = 0;
            string sql = "delete from B2C_laws_notes where id=" + _cid + "";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(tID,n_name,n_msg,n_email,n_ips);
            }
            else
            {
                this.myUpdate(id, tID, n_name, n_msg, n_email, n_ips);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0; 
            tID = 0;
            tname  = ""; 
            n_name = "";
            n_msg = "";
            n_email = ""; 
            n_ips = "";  
            regtime = DateTime.Now;  
        }
        #region 设置按钮功能
        /// <summary>
        /// 设置是否跳转页
        /// </summary>
        /// <param name="_cid"></param>
        public static int setG_isurl(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_laws set g_isurl= -1 * (g_isurl - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion
        /// <summary>
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(int _page,string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from B2C_laws_notes where 1=1 and " + _sql + " ";
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalpage < totalcount / pagesize)
            {
                totalpage = totalpage + 1;
            }

            beginItem = pagesize * (_page - 1);
            endItem = pagesize * _page - 1;
            if (endItem > (totalcount - 1))
            {
                endItem = totalcount - 1;
            }

            if (beginItem < 0)
            {
                beginItem = 0;
            }

            try
            {
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_laws_notes where " + _sql + " order by id desc");
                DataTable dt2 = proTable.Clone();
                for (int i = beginItem; i <= endItem; i++)
                {
                    dt2.ImportRow(proTable.Rows[i]);
                }
                return dt2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
    }
}
