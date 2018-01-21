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
    public class B2C_laws_logs
    {
        public int id = 0;                     //编号，自增 
        public int tID = 0;                 //所属案件ID
        public string tname = "";           //所属案件标题
        public int aID = 0;                 //所属步骤
        public string aName = "";           //所属步骤
        public string lmsg = "";             //页面标题 
        DateTime regtime = DateTime.Now;       //录入时间 
        
        public B2C_laws_logs() { }
        public B2C_laws_logs(int _id)
        {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select a_name from B2C_laws_active where B2C_laws_active.id=b2c_laws.aid) as aname,(select gtitle from b2c_laws where b2c_laws.id=b2c_laws_logs.tid) as tname from B2C_laws_logs where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_laws_logsID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);                   
                    tID = Convert.IsDBNull(dt.Rows[0]["tID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["tID"]);
                    tname = Convert.IsDBNull(dt.Rows[0]["tname"]) ? "" : Convert.ToString(dt.Rows[0]["tname"]);
                    aID = Convert.IsDBNull(dt.Rows[0]["aID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["aID"]);
                    aName = Convert.IsDBNull(dt.Rows[0]["aName"]) ? "" : Convert.ToString(dt.Rows[0]["aName"]);
                    lmsg = Convert.IsDBNull(dt.Rows[0]["l_msg"]) ? "" : Convert.ToString(dt.Rows[0]["lmsg"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); 
                     
                }
            }
            else
            {
                throw new NotSupportedException("B2C_laws_logsID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _tID, int _aID, string _lmsg)
        {
            try
            {
                string sql = "insert into B2C_laws_logs (tid,aID,l_msg) values (@tid,@aID,@lmsg)";
                SqlParameter[] paras = new SqlParameter[] {  
                    new SqlParameter("@tID", _tID), 
                    new SqlParameter("@aID", _aID), 
                    new SqlParameter("@lmsg", _lmsg)};

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
        private void myUpdate(int _id, int _tID, int _aID, string _lmsg)
        {
            try
            {
                string sql = "update B2C_laws_logs set tid=@tid,aID=@aID,l_msg=@lmsg where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@tID", _tID), 
                    new SqlParameter("@aID", _aID), 
                    new SqlParameter("@lmsg", _lmsg)};

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
            string sql = "delete from B2C_laws_logs where id=" + _cid + "";
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
                this.myInsert(tID, aID, lmsg);
            }
            else
            {
                this.myUpdate(id,tID, aID, lmsg);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0; 
            tID = 0; 
            aID = 0; 
            lmsg = ""; 
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

            string sql = "select count(*) from B2C_laws_logs where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_laws_logs,b2c_laws where b2c_laws_logs.tid=b2c_laws.id and " + _sql + " order by id desc");
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
