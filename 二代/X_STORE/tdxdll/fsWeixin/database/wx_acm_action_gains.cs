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
    public class wx_acm_action_gains
    {
        public int id = 0;                     //编号，自增
        public int acid = 0;
        public string acname = "";
        public string lno = "";

        public string g_name = "";
        public string g_gif = "";
        public string g_cont = "";
        public int g_num = 0;
        public double g_per = 0.0;         
 
        public wx_acm_action_gains() { }
        public wx_acm_action_gains(int _id)
        {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *";
            sql += ",(select ac_name from wx_acm_action where id = acid) as acname";
            sql += " from wx_acm_action_gains where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("wx_acm_action_gainsID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    acid = Convert.IsDBNull(dt.Rows[0]["acid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["acid"]);
                    acname = Convert.IsDBNull(dt.Rows[0]["acname"]) ? "" : Convert.ToString(dt.Rows[0]["acname"]);
                    lno = Convert.IsDBNull(dt.Rows[0]["lno"]) ? "" : Convert.ToString(dt.Rows[0]["lno"]);

                    g_name = Convert.IsDBNull(dt.Rows[0]["g_name"]) ? "" : Convert.ToString(dt.Rows[0]["g_name"]);
                    g_gif = Convert.IsDBNull(dt.Rows[0]["g_gif"]) ? "" : Convert.ToString(dt.Rows[0]["g_gif"]);
                    g_cont = Convert.IsDBNull(dt.Rows[0]["g_cont"]) ? "" : Convert.ToString(dt.Rows[0]["g_cont"]);
                    g_num = Convert.IsDBNull(dt.Rows[0]["g_num"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_num"]);
                    g_per = Convert.IsDBNull(dt.Rows[0]["g_per"]) ? 0.0 : Convert.ToDouble(dt.Rows[0]["g_per"]);  
                }
            }
            else
            {
                throw new NotSupportedException("wx_acm_action_gainsID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _acid, string _lno, string _g_name, string _g_gif, string _g_cont, int _g_num,double _g_per)
        {
            try
            {
                string sql = "insert into wx_acm_action_gains (acid,lno,g_name,g_gif,g_cont,g_num,g_per) values (@acid,@lno,@g_name,@g_gif,@g_cont,@g_num,@g_per)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@acid", _acid), 
                    new SqlParameter("@lno", _lno), 
                    new SqlParameter("@g_name", _g_name), 
                    new SqlParameter("@g_gif", _g_gif),
                    new SqlParameter("@g_cont", _g_cont),
                    new SqlParameter("@g_num", _g_num),
                    new SqlParameter("@g_per", _g_per) };

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
        private void myUpdate(int _id, int _acid, string _lno, string _g_name, string _g_gif, string _g_cont, int _g_num, double _g_per)
        {
            try
            {
                string sql = "update wx_acm_action_gains set acid=@acid,lno=@lno,g_name=@g_name,g_gif=@g_gif,g_cont=@g_cont,g_num=@g_num,g_per=@g_per where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@acid", _acid), 
                    new SqlParameter("@lno", _lno), 
                    new SqlParameter("@g_name", _g_name), 
                    new SqlParameter("@g_gif", _g_gif),
                    new SqlParameter("@g_cont", _g_cont),
                    new SqlParameter("@g_num", _g_num),
                    new SqlParameter("@g_per", _g_per)};

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
            string sql = "delete from wx_acm_action_gains where id=" + _cid + "";
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
                this.myInsert(acid,lno,g_name,g_gif,g_cont,g_num,g_per);
            }
            else
            {
                this.myUpdate(id, acid, lno, g_name, g_gif, g_cont, g_num, g_per);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;
            acid = 0;
            lno = "";
            g_name = "";
            g_gif = "";
            g_cont = "";
            g_num = 0;
            g_per = 0.0; 
             
        }
        
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

            string sql = "select count(*) from wx_acm_action_gains where " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from wx_acm_action_gains where " + _sql + " order by id desc");
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

    public class wx_acm_action_log
    {
        public static void MyUpdate(int _acid, int _tid, string _wwv, string _answer, int _YorN)
        {
            string queryString = " update wx_acm_action_log set answer=@answer,YorN=@YorN where acid=" + _acid.ToString() + " and tid=" + _tid.ToString() + " and wwv='" + _wwv + "'";
            SqlParameter[] paras = new SqlParameter[] {  
                new SqlParameter("@answer", _answer),
                new SqlParameter("@YorN", _YorN)
            };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static void MyInsert(int _acid, int _tid, string _wwv, string _acl_no, string _guid_no)
        {
            HttpContext context = HttpContext.Current;
            string queryString = " INSERT INTO wx_acm_action_log (acid,tid,wwv,acl_no,guid_no,ips)";
            queryString += " VALUES (@acid,@tid,@wwv,@acl_no,@guid_no,@ips)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@acid", _acid),
                new SqlParameter("@tid", _tid),
                new SqlParameter("@wwv", _wwv),
                new SqlParameter("@acl_no", _acl_no),
                new SqlParameter("@guid_no", _guid_no),
                new SqlParameter("@ips", context.Request.UserHostAddress)
            };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static void MyInsert(int _acid,int _tid,string _wwv,string _answer,int _YorN,string _acl_no,string _guid_no)
        {
            HttpContext context = HttpContext.Current;
            string queryString = " INSERT INTO wx_acm_action_log (acid,tid,wwv,answer,YorN,acl_no,guid_no,ips)";
            queryString += " VALUES (@acid,@tid,@wwv,@answer,@YorN,@acl_no,@guid_no,@ips)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@acid", _acid),
                new SqlParameter("@tid", _tid),
                new SqlParameter("@wwv", _wwv),
                new SqlParameter("@answer", _answer),
                new SqlParameter("@YorN", _YorN),
                new SqlParameter("@acl_no", _acl_no),
                new SqlParameter("@guid_no", _guid_no),
                new SqlParameter("@ips", context.Request.UserHostAddress)
            };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 一次彻底删除一组监控
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from wx_acm_action_log where id in (" + _ids + ")";
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
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(int currentpage, string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from wx_acm_action_log where " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from wx_acm_action_log where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select * from wx_acm_action_log order id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }

    public class wx_acm_gain
    {
        public static void MyInsert(int _acid, int _gid, string _wwv, string _ga_idc, string _ga_tel, string _ga_uname, string _ga_addr,string _ga_zip)
        {
            HttpContext context = HttpContext.Current;
            string queryString = " INSERT INTO wx_acm_gain (acid,gid,wwv,ga_idc,ga_tel,ga_uname,ga_addr,ga_zip)";
            queryString += " VALUES (@acid,@gid,@wwv,@ga_idc,@ga_tel,@ga_uname,@ga_addr,@ga_zip)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@acid", _acid),
                new SqlParameter("@gid", _gid),
                new SqlParameter("@wwv", _wwv),
                new SqlParameter("@ga_idc", _ga_idc),
                new SqlParameter("@ga_tel", _ga_tel),
                new SqlParameter("@ga_uname", _ga_uname),
                new SqlParameter("@ga_addr", _ga_addr),
                new SqlParameter("@ga_zip", _ga_addr)
            };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 一次彻底删除一组监控
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from wx_acm_gain where id in (" + _ids + ")";
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
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(int currentpage, string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from wx_acm_gain where " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from wx_acm_gain where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select * from wx_acm_gain order id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //领奖设计
        public static bool GetGain(string _wwv,string _idc, string _wuser)
        {
            bool result = false;
            string _sql = "select * from wx_acm_gain where wwv='" + _wwv + "' or ga_idc='" + _idc + "'";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                _sql = "update wx_acm_gain set ga_wwv='" + _wwv + "',ga_wdate=getDate(),wuser='" + _wuser + "' where id=" + dt.Rows[0]["id"].ToString();
                try
                {
                    comfun.UpdateBySQL(_sql);
                    result = true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return result;
        }
        public static bool GetGain(int _id,  string _wuser)
        {
            bool result = false;
         
             string  _sql = "update wx_acm_gain set ga_wwv=wwv,ga_wdate=getDate(),wuser='" + _wuser + "' where id=" + _id.ToString();
                try
                {
                    comfun.UpdateBySQL(_sql);
                    result = true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            

            return result;
        }
    }
}
