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
    public class wx_acm_action
    {
        public int id = 0;                     //编号，自增
        public string ac_name = "";
        public int wid =  Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());
        //所属的微网站ID
        public string lid = "0"; //需要的层级ID
        public int hid = 0; //适合的节日
        public int whid = 0; //适合的氛围

        //
        public String hname = "";//节日名称
        public string whname = "";//氛围名称

        public DateTime bdate = System.DateTime.Now; //开始时间
        public DateTime edate = System.DateTime.Now; //结束时间
        public int freq = 1;  //频率
        public DateTime regtime = System.DateTime.Now; //注册时间
 
        public wx_acm_action() { }
        public wx_acm_action(int _id)
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
            sql += ",(select c_name from wx_acm_holiday where id=hid)  as hname";
            sql += ",(select c_name from wx_acm_with where id=whid)  as whname";
            sql += " from wx_acm_action where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("wx_acm_actionID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    ac_name = Convert.IsDBNull(dt.Rows[0]["ac_name"]) ? "" : Convert.ToString(dt.Rows[0]["ac_name"]);
                    //wid，lid,hid,whid,hname,whname,bdate,edate,freq,regtime
                    wid = Convert.IsDBNull(dt.Rows[0]["wid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["wid"]);
                    lid = Convert.IsDBNull(dt.Rows[0]["lid"]) ? "0" : Convert.ToString(dt.Rows[0]["lid"]);
                    hid = Convert.IsDBNull(dt.Rows[0]["hid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["hid"]);
                    whid = Convert.IsDBNull(dt.Rows[0]["whid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["whid"]);

                    hname = Convert.IsDBNull(dt.Rows[0]["hname"]) ? "" : Convert.ToString(dt.Rows[0]["hname"]);
                    whname = Convert.IsDBNull(dt.Rows[0]["whname"]) ? "" : Convert.ToString(dt.Rows[0]["whname"]);
                    bdate = Convert.IsDBNull(dt.Rows[0]["bdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["bdate"]);
                    edate = Convert.IsDBNull(dt.Rows[0]["edate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["edate"]);

                    freq = Convert.IsDBNull(dt.Rows[0]["freq"]) ? 1 : Convert.ToInt32(dt.Rows[0]["freq"]);

                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);

                }
            }
            else
            {
                throw new NotSupportedException("wx_acm_actionID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _ac_name,int _wid,string _lid,int _hid,int _whid,DateTime _bdate,DateTime _edate,int _freq)
        {
            try
            {
                string sql = "insert into wx_acm_action (ac_name,wid,lid,hid,whid,bdate,edate,freq) values (@ac_name,@wid,@lid,@hid,@whid,@bdate,@edate,@freq)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ac_name", _ac_name), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@lid", _lid),
                    new SqlParameter("@hid", _hid),
                    new SqlParameter("@whid", _whid),
                    new SqlParameter("@bdate", _bdate),
                    new SqlParameter("@edate", _edate),
                    new SqlParameter("@freq", _freq) };

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
        private void myUpdate(int _id, string _ac_name, int _wid, string _lid, int _hid, int _whid, DateTime _bdate, DateTime _edate, int _freq)
        {
            try
            {
                string sql = "update wx_acm_action set ac_name=@ac_name,wid=@wid,lid=@lid,hid=@hid,whid=@whid,bdate=@bdate,edate=@edate,freq=@freq where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ac_name", _ac_name),
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@lid", _lid), 
                    new SqlParameter("@hid", _hid),
                    new SqlParameter("@whid", _whid),
                    new SqlParameter("@bdate", _bdate),
                    new SqlParameter("@edate", _edate),
                    new SqlParameter("@freq", _freq)};

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
            string sql = "delete from wx_acm_action where id=" + _cid + "";
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
                this.myInsert(ac_name,wid,lid,hid,whid ,bdate,edate,freq );
            }
            else
            {
                this.myUpdate(id, ac_name,wid, lid, hid, whid, bdate, edate, freq);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void AddNew()
        {
            id = 0;
            ac_name = "";
            wid = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());
            lid= "0";
            hid = 0;
            whid=0;

            hname = "";
            whname = "";

            bdate = System.DateTime.Now;
            edate = System.DateTime.Now;
            freq = 1;
             
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

            string sql = "select count(*) from wx_acm_action where wid=" +System.Web.HttpContext.Current.Session["wID"].ToString() + " and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from wx_acm_action where wid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + " and " + _sql + " order by id desc");
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

    public class wx_acm_level
    {
        public int id = 0;
        public string c_name = "";

        public static DataTable GetList()
        {
            return comfun.GetDataTableBySQL("select * from wx_acm_level order by id");
        }
    }
    public class wx_acm_holiday
    {
        public int id = 0;
        public string c_name = "";

        public static DataTable GetList()
        {
            return comfun.GetDataTableBySQL("select * from wx_acm_holiday order by id");
        }
    }
    public class wx_acm_with
    {
        public int id = 0;
        public string c_name = "";

        public static DataTable GetList()
        {
            return comfun.GetDataTableBySQL("select * from wx_acm_with order by id");
        }
    }

    //题库类
    public class wx_acm_test
    {
        public int id = 0;                     //编号，自增
        public int lid = 0;
        public string hid = "0";
        public string whid = "0";
        public string t_title = "";
        public string t_answer = "";
        public string t_cont = "";
        public DateTime regdate = System.DateTime.Now;

        public string lname = "";
        public string hname = "";
        public string whname = "";
 
        public wx_acm_test() { }
        public wx_acm_test(int _id)
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
            sql += ",(select  c_name from wx_acm_level where id=lid)  as lname"; 
            sql += " from wx_acm_test where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("wx_acm_testID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    // lid,hid,whid,t_title,t_anser,t_cont,regdate
                    lid = Convert.IsDBNull(dt.Rows[0]["lid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["lid"]);
                    hid = Convert.IsDBNull(dt.Rows[0]["hid"]) ? "0" : Convert.ToString(dt.Rows[0]["hid"]);
                    whid = Convert.IsDBNull(dt.Rows[0]["whid"]) ? "0" : Convert.ToString(dt.Rows[0]["whid"]);

                    lname = Convert.IsDBNull(dt.Rows[0]["lname"]) ? "" : Convert.ToString(dt.Rows[0]["lname"]);
                    //hname = Convert.IsDBNull(dt.Rows[0]["hname"]) ? "" : Convert.ToString(dt.Rows[0]["hname"]);
                    //whname = Convert.IsDBNull(dt.Rows[0]["whname"]) ? "" : Convert.ToString(dt.Rows[0]["whname"]);

                    t_title = Convert.IsDBNull(dt.Rows[0]["t_title"]) ? "" : Convert.ToString(dt.Rows[0]["t_title"]);
                    t_answer = Convert.IsDBNull(dt.Rows[0]["t_answer"]) ? "" : Convert.ToString(dt.Rows[0]["t_answer"]);
                    t_cont = Convert.IsDBNull(dt.Rows[0]["t_cont"]) ? "" : Convert.ToString(dt.Rows[0]["t_cont"]);
 
                    regdate = Convert.IsDBNull(dt.Rows[0]["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regdate"]);

                }
            }
            else
            {
                throw new NotSupportedException("wx_acm_testID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _lid,string _hid,string _whid,string _t_title,string _t_answer,string _t_cont)
        {
            try
            {
                string sql = "insert into wx_acm_test (lid,hid,whid,t_title,t_answer,t_cont) values (@lid,@hid,@whid,@t_title,@t_answer,@t_cont)";
                SqlParameter[] paras = new SqlParameter[] {  
                    new SqlParameter("@lid", _lid), 
                    new SqlParameter("@hid", _hid),
                    new SqlParameter("@whid", _whid),
                    new SqlParameter("@t_title", _t_title),
                    new SqlParameter("@t_answer", _t_answer),
                    new SqlParameter("@t_cont", _t_cont) };

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
        private void myUpdate(int _id, int _lid, string _hid, string _whid, string _t_title, string _t_answer, string _t_cont)
        {
            try
            {
                string sql = "update wx_acm_test set lid=@lid,hid=@hid,whid=@whid,t_title=@t_title,t_answer=@t_answer,t_cont=@t_cont where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@lid", _lid), 
                    new SqlParameter("@hid", _hid),
                    new SqlParameter("@whid", _whid),
                    new SqlParameter("@t_title", _t_title),
                    new SqlParameter("@t_answer", _t_answer),
                    new SqlParameter("@t_cont", _t_cont)};

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
            string sql = "delete from wx_acm_test where id=" + _cid + "";
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
                this.myInsert(lid,hid,whid ,t_title,t_answer,t_cont );
            }
            else
            {
                this.myUpdate(id, lid, hid, whid, t_title, t_answer, t_cont);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void AddNew()
        {
            id = 0;
           
            lid= 0;
            hid = "0";
            whid="0";

            lname = "";
            hname = "";
            whname = "";

            t_title = "";
            t_answer = "";
            t_cont = "";

            regdate = System.DateTime.Now;  
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

            string sql = "select count(*) from wx_acm_test where " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from wx_acm_test where " + _sql + " order by id desc");
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
