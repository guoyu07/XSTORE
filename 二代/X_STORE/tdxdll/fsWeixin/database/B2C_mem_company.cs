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
    public class B2C_mem_company
    {
        public int id = 0;                     //编号，自增
        public string cno = "";                //关联B2C_lawcate的c_no
        public string cname = "";
        public string cpath = "";
        public int mID = 0;						//所属会员ID
		public string mName = "";                 //所属会员名称
        public string gtitle = "";             //页面标题
        public string gtitle_en = "";           //英文名称
        public string gcontent = "";           //页面内容 
        public string ggif = "";               //图片文件名 

        public string gaddr1 = "";              //大类地址
        public string gaddr2 = ""; //详细地址
        public string gIDN = "";//营业执照号码
        public string gurl = "";//网址
        public string gtel = "";//电话
        public string gfax = "";//传真
        public string glinker = "";//联系人
        public string gjob = "";//职务
        public string gmobile = "";//手机号码
        public string gmail = "";//Email
        public string gword = "";//一句话信息
        public string gcause = "";//评选理由
        public string gmap = "";//地图
        public string gword2 = "";//优惠信息

        public int g_sort = 99;                 //排序,越小越靠前
        public int g_hits = 0;                 //浏览次数
        DateTime regtime = DateTime.Now;       //录入时间 
        public int cityID = 1;                 //城市ID，目前缺省为1，不用编辑
        public int g_isa = 0;//审核标志

        public B2C_mem_company() { }
        public B2C_mem_company(int _id) {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select c_name from B2C_comcate where c_no=cno) as cname,(select c_url from B2C_comcate where c_no=cno) as cpath,(select m_name from B2C_mem where b2c_mem.id=B2C_mem_company.mid) as mname from B2C_mem_company where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_mem_companyID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    cname = Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]);
                    cpath = Convert.IsDBNull(dt.Rows[0]["cpath"]) ? "" : Convert.ToString(dt.Rows[0]["cpath"]);
                    mID = Convert.IsDBNull(dt.Rows[0]["mID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mID"]);
                    mName = Convert.IsDBNull(dt.Rows[0]["mname"]) ? "" : Convert.ToString(dt.Rows[0]["mname"]);
                    gtitle = Convert.IsDBNull(dt.Rows[0]["gtitle"]) ? "" : Convert.ToString(dt.Rows[0]["gtitle"]);
                    gtitle_en = Convert.IsDBNull(dt.Rows[0]["gtitle_en"]) ? "" : Convert.ToString(dt.Rows[0]["gtitle_en"]);
                    gcontent = Convert.IsDBNull(dt.Rows[0]["gcontent"]) ? "" : Convert.ToString(dt.Rows[0]["gcontent"]);
                    ggif = Convert.IsDBNull(dt.Rows[0]["ggif"]) ? "" : Convert.ToString(dt.Rows[0]["ggif"]);

                    gaddr1 = Convert.IsDBNull(dt.Rows[0]["gaddr1"]) ? "" : Convert.ToString(dt.Rows[0]["gaddr1"]);
                    gaddr2 = Convert.IsDBNull(dt.Rows[0]["gaddr2"]) ? "" : Convert.ToString(dt.Rows[0]["gaddr2"]);
                    gIDN = Convert.IsDBNull(dt.Rows[0]["gIDN"]) ? "" : Convert.ToString(dt.Rows[0]["gIDN"]);
                    gurl = Convert.IsDBNull(dt.Rows[0]["gurl"]) ? "" : Convert.ToString(dt.Rows[0]["gurl"]);
                    gtel = Convert.IsDBNull(dt.Rows[0]["gtel"]) ? "" : Convert.ToString(dt.Rows[0]["gtel"]);
                    gfax = Convert.IsDBNull(dt.Rows[0]["gfax"]) ? "" : Convert.ToString(dt.Rows[0]["gfax"]);
                    glinker = Convert.IsDBNull(dt.Rows[0]["glinker"]) ? "" : Convert.ToString(dt.Rows[0]["glinker"]);
                    gjob = Convert.IsDBNull(dt.Rows[0]["gjob"]) ? "" : Convert.ToString(dt.Rows[0]["gjob"]);
                    gmobile = Convert.IsDBNull(dt.Rows[0]["gmobile"]) ? "" : Convert.ToString(dt.Rows[0]["gmobile"]);
                    gmail = Convert.IsDBNull(dt.Rows[0]["gmail"]) ? "" : Convert.ToString(dt.Rows[0]["gmail"]);
                    gword = Convert.IsDBNull(dt.Rows[0]["gword"]) ? "" : Convert.ToString(dt.Rows[0]["gword"]);
                    gcause = Convert.IsDBNull(dt.Rows[0]["gcause"]) ? "" : Convert.ToString(dt.Rows[0]["gcause"]);
                    gmap = Convert.IsDBNull(dt.Rows[0]["gmap"]) ? "" : Convert.ToString(dt.Rows[0]["gmap"]);
                    gword2 = Convert.IsDBNull(dt.Rows[0]["gword2"]) ? "" : Convert.ToString(dt.Rows[0]["gword2"]);

                    g_sort = Convert.IsDBNull(dt.Rows[0]["g_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["g_sort"]);
                    g_hits = Convert.IsDBNull(dt.Rows[0]["g_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_hits"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); 
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);

                    g_isa = Convert.IsDBNull(dt.Rows[0]["g_isa"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_isa"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_mem_companyID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _cno, int _mID, string _gtitle, string _gcontent,  string _ggif, int _g_sort, int _g_hits, DateTime _regtime, int _cityID,string _gtitleEN,string _gaddr1,string _gaddr2,string _gIDN,string _gurl,string _gtel,string _gfax,string _glinker,string _gjob,string _gmobile,string _gmail,string _gword,string _gcause,string _gmap,string _gword2)
        {
            try
            {
                string sql = "insert into B2C_mem_company (cno,mID,gtitle,gcontent, ggif,g_sort,g_hits,regtime,cityID,gtitle_en,gaddr1,gaddr2,gIDN,gurl,gtel,gfax,glinker,gjob,gmobile,gmail,gword,gcause,gmap,gword2) values (@cno,@mID,@gtitle,@gcontent, @ggif,@g_sort,@g_hits,@regtime,@cityID,@gtitle_en,@gaddr1,@gaddr2,@gIDN,@gurl,@gtel,@gfax,@glinker,@gjob,@gmobile,@gmail,@gword,@gcause,@gmap,@gword2)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@mID", _mID), 
                    new SqlParameter("@gtitle", _gtitle),
                    new SqlParameter("@gcontent", _gcontent), 
                    new SqlParameter("@ggif", _ggif), 
                    new SqlParameter("@g_sort", _g_sort),
                    new SqlParameter("@g_hits", _g_hits),
                    new SqlParameter("@regtime", _regtime), 
                    new SqlParameter("@cityID", _cityID), 
                    new SqlParameter("@gtitle_en", _gtitleEN), 
                    new SqlParameter("@gaddr1", _gaddr1), 
                    new SqlParameter("@gaddr2", _gaddr2), 
                    new SqlParameter("@gIDN", _gIDN), 
                    new SqlParameter("@gurl", _gurl), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@gfax", _gfax), 
                    new SqlParameter("@glinker", _glinker),
                    new SqlParameter("@gjob", _gjob),
                    new SqlParameter("@gmobile", _gmobile), 
                    new SqlParameter("@gmail", _gmail), 
                    new SqlParameter("@gword", _gword), 
                    new SqlParameter("@gcause", _gcause), 
                    new SqlParameter("@gmap", _gmap), 
                    new SqlParameter("@gword2", _gword2)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
                comfun.UpdateBySQL("update b2c_mem set m_busi=1 where id=" + _mID.ToString());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 修改一条新的记录
        /// </summary>
        private void myUpdate(int _id, string _cno, int _mID, string _gtitle, string _gcontent, string _ggif, int _g_sort, int _g_hits, DateTime _regtime, int _cityID, string _gtitleEN, string _gaddr1, string _gaddr2, string _gIDN, string _gurl, string _gtel, string _gfax, string _glinker, string _gjob, string _gmobile, string _gmail, string _gword, string _gcause, string _gmap, string _gword2)
        {
            try
            {
                string sql = "update B2C_mem_company set cno=@cno,mID=@mID,gtitle=@gtitle,gcontent=@gcontent, ggif=@ggif,g_sort=@g_sort,g_hits=@g_hits,regtime=@regtime,cityID=@cityID,gtitle_en=@gtitleEN,gaddr1=@gaddr1,gaddr2=@gaddr2,gIDN=@gIDN,gurl=@gurl,gtel=@gtel,gfax=@gfax,glinker=@glinker,gjob=@gjob,gmobile=@gmobile,gmail=@gmail,gword=@gword,gcause=@gcause,gmap=@gmap,gword2=@gword2 where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@mID", _mID), 
                    new SqlParameter("@gtitle", _gtitle),
                    new SqlParameter("@gtitleEN", _gtitleEN),
                    new SqlParameter("@gcontent", _gcontent), 
                    new SqlParameter("@ggif", _ggif), 
                    new SqlParameter("@g_sort", _g_sort),
                    new SqlParameter("@g_hits", _g_hits),
                    new SqlParameter("@regtime", _regtime), 
                    new SqlParameter("@cityID", _cityID), 
                    new SqlParameter("@gtitle_en", _gtitleEN), 
                    new SqlParameter("@gaddr1", _gaddr1), 
                    new SqlParameter("@gaddr2", _gaddr2), 
                    new SqlParameter("@gIDN", _gIDN), 
                    new SqlParameter("@gurl", _gurl), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@gfax", _gfax), 
                    new SqlParameter("@glinker", _glinker),
                    new SqlParameter("@gjob", _gjob),
                    new SqlParameter("@gmobile", _gmobile), 
                    new SqlParameter("@gmail", _gmail), 
                    new SqlParameter("@gword", _gword), 
                    new SqlParameter("@gcause", _gcause), 
                    new SqlParameter("@gmap", _gmap), 
                    new SqlParameter("@gword2", _gword2)};

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
            string sql = "delete from B2C_mem_company where id=" + _cid + "";
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
                this.myInsert(cno, mID, gtitle, gcontent,  ggif, g_sort, g_hits, regtime,  cityID,gtitle_en,gaddr1,gaddr2,gIDN,gurl,gtel,gfax,glinker,gjob ,gmobile,gmail,gword,gcause,gmap,gword2);
            }
            else
            {
                this.myUpdate(id, cno, mID, gtitle, gcontent, ggif, g_sort, g_hits, regtime, cityID, gtitle_en, gaddr1, gaddr2, gIDN, gurl, gtel, gfax, glinker, gjob, gmobile, gmail, gword,gcause,gmap,gword2);
            }
        }
       
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;
            cno = "";
            mID = 0;
            gtitle = "";
            gtitle_en = "";
            gcontent = ""; 
            ggif = "";

            gaddr1 = "";
            gaddr2 = "";
            gIDN = "";
            gurl = "";
            gtel = "";
            gfax = "";
            glinker = "";
            gjob = "";
            gmobile = "";
            gmail = "";
            gword = "";
            gcause = "";
            gmap = "";

            g_sort = 99;
            g_hits = 0;
            regtime = DateTime.Now; 
            cityID = 1;  
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

            string sql = "select count(*) from B2C_mem_company where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_mem_company where " + _sql + " order by id desc");
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
