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
    public class B2C_lawanli
    {
        public int id = 0;                     //编号，自增
        public string cno = "";                //关联B2C_lawcate的c_no
        public string cname = "";
        public int shopID = 0;                 //所属商户ID
        public string gtitle = "";             //页面标题
        public string gcontent = "";           //页面内容
        public string gfile = "";              //文件名
        public string ggif = "";               //图片文件名
        public int g_isurl = 0;                //是否跳转
        public string g_url = "";              //如果是跳转，则跳转网址
        public string g_title = "";            //网页title优化用
        public string g_key = "";              //网页keyword优化用
        public string g_des = "";              //网页description优化用
        public int g_sort = 99;                 //排序,越小越靠前
        public int g_hits = 0;                 //浏览次数
        DateTime regtime = DateTime.Now;       //录入时间
        public string g_r1 = "";               //页面上装饰用代码
        public string g_r2 = "";               //页面上装饰用代码
        public int cityID = 1;                 //城市ID，目前缺省为1，不用编辑

        public B2C_lawanli() { }
        public B2C_lawanli(int _id) {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select c_name from B2C_lawcate where c_no=cno) as cname from B2C_lawanli where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_lawanliID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    cname = Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]);
                    shopID = Convert.IsDBNull(dt.Rows[0]["shopID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["shopID"]);
                    gtitle = Convert.IsDBNull(dt.Rows[0]["gtitle"]) ? "" : Convert.ToString(dt.Rows[0]["gtitle"]);
                    gcontent = Convert.IsDBNull(dt.Rows[0]["gcontent"]) ? "" : Convert.ToString(dt.Rows[0]["gcontent"]);
                    gfile = Convert.IsDBNull(dt.Rows[0]["gfile"]) ? "" : Convert.ToString(dt.Rows[0]["gfile"]);
                    ggif = Convert.IsDBNull(dt.Rows[0]["ggif"]) ? "" : Convert.ToString(dt.Rows[0]["ggif"]);
                    g_isurl = Convert.IsDBNull(dt.Rows[0]["g_isurl"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_isurl"]);
                    g_url = Convert.IsDBNull(dt.Rows[0]["g_url"]) ? "" : Convert.ToString(dt.Rows[0]["g_url"]);
                    g_title = Convert.IsDBNull(dt.Rows[0]["g_title"]) ? "" : Convert.ToString(dt.Rows[0]["g_title"]);
                    g_key = Convert.IsDBNull(dt.Rows[0]["g_key"]) ? "" : Convert.ToString(dt.Rows[0]["g_key"]);
                    g_des = Convert.IsDBNull(dt.Rows[0]["g_des"]) ? "" : Convert.ToString(dt.Rows[0]["g_des"]);
                    g_sort = Convert.IsDBNull(dt.Rows[0]["g_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["g_sort"]);
                    g_hits = Convert.IsDBNull(dt.Rows[0]["g_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_hits"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                    g_r1 = Convert.IsDBNull(dt.Rows[0]["g_r1"]) ? "" : Convert.ToString(dt.Rows[0]["g_r1"]);
                    g_r2 = Convert.IsDBNull(dt.Rows[0]["g_r2"]) ? "" : Convert.ToString(dt.Rows[0]["g_r2"]);
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_lawanliID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _cno, int _shopID, string _gtitle, string _gcontent, string _gfile,string _ggif, int _g_isurl, string _g_url, string _g_title, string _g_key, string _g_des, int _g_sort, int _g_hits, DateTime _regtime, string _g_r1, string _g_r2,int _cityID)
        {
            try
            {
                string sql = "insert into B2C_lawanli (cno,shopID,gtitle,gcontent,gfile,ggif,g_isurl,g_url,g_title,g_key,g_des,g_sort,g_hits,regtime,g_r1,g_r2,cityID) values (@cno,@shopID,@gtitle,@gcontent,@gfile,@ggif,@g_isurl,@g_url,@g_title,@g_key,@g_des,@g_sort,@g_hits,@regtime,@g_r1,@g_r2,@cityID)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@shopID", _shopID), 
                    new SqlParameter("@gtitle", _gtitle),
                    new SqlParameter("@gcontent", _gcontent),
                    new SqlParameter("@gfile", _gfile),
                    new SqlParameter("@ggif", _ggif),
                    new SqlParameter("@g_isurl", _g_isurl),
                    new SqlParameter("@g_url", _g_url),
                    new SqlParameter("@g_title", _g_title),
                    new SqlParameter("@g_key", _g_key),
                    new SqlParameter("@g_des", _g_des),
                    new SqlParameter("@g_sort", _g_sort),
                    new SqlParameter("@g_hits", _g_hits),
                    new SqlParameter("@regtime", _regtime),
                    new SqlParameter("@g_r1", _g_r1),
                    new SqlParameter("@g_r2", _g_r2),
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
        private void myUpdate(int _id,string _cno, int _shopID, string _gtitle, string _gcontent, string _gfile,string _ggif, int _g_isurl, string _g_url, string _g_title, string _g_key, string _g_des, int _g_sort, int _g_hits, DateTime _regtime, string _g_r1, string _g_r2, int _cityID)
        {
            try
            {
                string sql = "update B2C_lawanli set cno=@cno,shopID=@shopID,gtitle=@gtitle,gcontent=@gcontent,gfile=@gfile,ggif=@ggif,g_isurl=@g_isurl,g_url=@g_url,g_title=@g_title,g_key=@g_key,g_des=@g_des,g_sort=@g_sort,g_hits=@g_hits,regtime=@regtime,g_r1=@g_r1,g_r2=@g_r2,cityID=@cityID where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@shopID", _shopID), 
                    new SqlParameter("@gtitle", _gtitle),
                    new SqlParameter("@gcontent", _gcontent),
                    new SqlParameter("@gfile", _gfile),
                    new SqlParameter("@ggif", _ggif),
                    new SqlParameter("@g_isurl", _g_isurl),
                    new SqlParameter("@g_url", _g_url),
                    new SqlParameter("@g_title", _g_title),
                    new SqlParameter("@g_key", _g_key),
                    new SqlParameter("@g_des", _g_des),
                    new SqlParameter("@g_sort", _g_sort),
                    new SqlParameter("@g_hits", _g_hits),
                    new SqlParameter("@regtime", _regtime),
                    new SqlParameter("@g_r1", _g_r1),
                    new SqlParameter("@g_r2", _g_r2),
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
        public static int myDel(int _cid)
        {
            int res = 0;
            string sql = "delete from B2C_lawanli where id=" + _cid + "";
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
                this.myInsert(cno, shopID, gtitle, gcontent, gfile,ggif,g_isurl, g_url, g_title, g_key, g_des, g_sort, g_hits, regtime, g_r1, g_r2, cityID);
            }
            else
            {
                this.myUpdate(id, cno, shopID, gtitle, gcontent, gfile, ggif,g_isurl, g_url, g_title, g_key, g_des, g_sort, g_hits, regtime, g_r1, g_r2, cityID);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;
            cno = "";
            shopID = 0;
            gtitle = "";
            gcontent = "";
            gfile = "";
            ggif = "";
            g_isurl = 0;
            g_url = "";
            g_title = "";
            g_key = "";
            g_des = "";
            g_sort = 99;
            g_hits = 0;
            regtime = DateTime.Now;
            g_r1 = "";
            g_r2 = "";
            cityID = 1;
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
                res = comfun.UpdateBySQL("update B2C_lawanli set g_isurl= -1 * (g_isurl - 1) where id in ('" + _cid + "')");
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

            string sql = "select count(*) from B2C_lawanli where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_lawanli where " + _sql + " order by id desc");
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
        /// <summary>
        /// 树形结构
        /// </summary>
        public static void getOneClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect cid)
        {
            string texts = "";
            string values = "";

            B2C_lawcate cate = new B2C_lawcate(classid);
            int depth = cate.c_level;
            while (depth > 0)
            {
                texts += "　";
                depth = depth - 1;
            }
            values = cate.c_no;
            if (cate.c_child < 1)
            {
                texts += " - " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = comfun.GetDataTableBySQL("select * from B2C_lawcate where c_parent=" + classid + " order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["c_id"]), cid);
                }
            }
        }
    }
}
