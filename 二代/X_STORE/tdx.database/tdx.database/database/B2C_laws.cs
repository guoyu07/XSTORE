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
    public class B2C_laws
    {
        public int id = 0;                     //编号，自增
        public string cno = "";                //关联B2C_lawcate的c_no
        public string cname = "";
        public int mID = 0;                 //所属会员ID
        public string Mname = "";           //所属会员号
        public string mTel = "";            //会员手机号码
        public int shopID = 0;                 //所属律师ID
        public string shopName = "";           //律师姓名
        public string shopTel = "";            //律师电话
        public string gtitle = "";             //页面标题
        public string gcontent = "";           //页面内容 
        public string ggif = "";               //图片文件名  
        public int g_hits = 0;                 //浏览次数
        public DateTime regtime = DateTime.Now;       //录入时间 
        //public int cityID = 1;                 //城市ID，目前缺省为1，不用编辑

        public string gtel = "";// 委托人联系电话
        public string dsrname = "";//当事人姓名
        public string dfdsrname = "";//对方当事人姓名
        public string cljgname = "";//处理机关

        //2013-1-19更新
        public string dsr_IDCard = "";//当事人ID
        public string dsr_frIDCard = "";//法人身份证号
        public string dsr_yingye = "";//营业执照号码
        public string ht_no = "";//合同编号
        public string gno = "";//案件编号
        public string dsr_IDC_gif = "";//当事人身份证扫描件
        public string dsr_fr_gif = "";//当事人法人身份证扫描件
        public string ht_gif = "";//合同扫描件
        public string dsr_yingye_gif = "";//当事人营业执照扫描件
        public decimal g_money = 0;//代理费

        public string aname = "";//当前状态
        public int aid = 0;//当前状态

        public int qID = 0;//咨询ID号

        public B2C_laws() { }
        public B2C_laws(int _id) {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select c_name from B2C_lawcate where c_no=cno) as cname,(select (m_name+'['+m_truename+']') from b2c_mem where b2c_mem.id=b2c_laws.mid) as mname,(select m_mobile from b2c_mem where b2c_mem.id=b2c_laws.mid) as mTel,(select (m_name+'['+m_truename+']') from b2c_mem where b2c_mem.id=b2c_laws.shopid) as shopname,(select (m_tel+'/'+m_mobile) from b2c_mem where b2c_mem.id=b2c_laws.shopid) as shoptel,(select a_name from b2c_laws_active where id=(select top 1 aid from b2c_laws_logs where tid=b2c_laws.id order by b2c_laws_logs.id desc)) as aname,(select top 1 aid from b2c_laws_logs where tid=b2c_laws.id order by b2c_laws_logs.id desc) as aid from B2C_laws where id=" + id;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_lawsID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    cname = Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]);
                    mID = Convert.IsDBNull(dt.Rows[0]["mID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mID"]);
                    Mname = Convert.IsDBNull(dt.Rows[0]["mname"]) ? "" : Convert.ToString(dt.Rows[0]["mname"]);
                    mTel = Convert.IsDBNull(dt.Rows[0]["mTel"]) ? "" : Convert.ToString(dt.Rows[0]["mTel"]);
                    shopID = Convert.IsDBNull(dt.Rows[0]["shopID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["shopID"]);
                    shopName = Convert.IsDBNull(dt.Rows[0]["shopname"]) ? "" : Convert.ToString(dt.Rows[0]["shopname"]);
                    shopTel = Convert.IsDBNull(dt.Rows[0]["shopTel"]) ? "" : Convert.ToString(dt.Rows[0]["shopTel"]);
                    gtitle = Convert.IsDBNull(dt.Rows[0]["gtitle"]) ? "" : Convert.ToString(dt.Rows[0]["gtitle"]);
                    gcontent = Convert.IsDBNull(dt.Rows[0]["gcontent"]) ? "" : Convert.ToString(dt.Rows[0]["gcontent"]); 
                    ggif = Convert.IsDBNull(dt.Rows[0]["ggif"]) ? "" : Convert.ToString(dt.Rows[0]["ggif"]);  
                    g_hits = Convert.IsDBNull(dt.Rows[0]["g_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_hits"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); 
                    //cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);

                    //新加字段
                    gtel = Convert.IsDBNull(dt.Rows[0]["gtel"]) ? "" : Convert.ToString(dt.Rows[0]["gtel"]);
                    dsrname = Convert.IsDBNull(dt.Rows[0]["dsrname"]) ? "" : Convert.ToString(dt.Rows[0]["dsrname"]);
                    dfdsrname = Convert.IsDBNull(dt.Rows[0]["dfdsrname"]) ? "" : Convert.ToString(dt.Rows[0]["dfdsrname"]);
                    cljgname = Convert.IsDBNull(dt.Rows[0]["cljgname"]) ? "" : Convert.ToString(dt.Rows[0]["cljgname"]);

                    //2013-1-19 修改
                    dsr_IDCard = Convert.IsDBNull(dt.Rows[0]["dsr_IDCard"]) ? "" : Convert.ToString(dt.Rows[0]["dsr_IDCard"]);
                    dsr_frIDCard = Convert.IsDBNull(dt.Rows[0]["dsr_frIDCard"]) ? "" : Convert.ToString(dt.Rows[0]["dsr_frIDCard"]);
                    dsr_yingye = Convert.IsDBNull(dt.Rows[0]["dsr_yingye"]) ? "" : Convert.ToString(dt.Rows[0]["dsr_yingye"]);
                    ht_no = Convert.IsDBNull(dt.Rows[0]["ht_no"]) ? "" : Convert.ToString(dt.Rows[0]["ht_no"]);
                    gno = Convert.IsDBNull(dt.Rows[0]["gno"]) ? "" : Convert.ToString(dt.Rows[0]["gno"]);
                    g_money = Convert.IsDBNull(dt.Rows[0]["g_money"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["g_money"]);
                    dsr_IDC_gif = Convert.IsDBNull(dt.Rows[0]["dsr_IDC_gif"]) ? "" : Convert.ToString(dt.Rows[0]["dsr_IDC_gif"]);
                    dsr_fr_gif = Convert.IsDBNull(dt.Rows[0]["dsr_fr_gif"]) ? "" : Convert.ToString(dt.Rows[0]["dsr_fr_gif"]);
                    ht_gif = Convert.IsDBNull(dt.Rows[0]["ht_gif"]) ? "" : Convert.ToString(dt.Rows[0]["ht_gif"]);
                    dsr_yingye_gif = Convert.IsDBNull(dt.Rows[0]["dsr_yingye_gif"]) ? "" : Convert.ToString(dt.Rows[0]["dsr_yingye_gif"]);
                    aname = Convert.IsDBNull(dt.Rows[0]["aname"]) ? "未分配" : Convert.ToString(dt.Rows[0]["aname"]);
                    aid = Convert.IsDBNull(dt.Rows[0]["aid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["aid"]);

                    //2013-05-04修改
                    qID = Convert.IsDBNull(dt.Rows[0]["qID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["qID"]); //对应的咨询ID号
                }
            }
            else
            {
                throw new NotSupportedException("B2C_lawsID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _cno, int _mID, int _shopID, string _gtitle, string _gcontent, string _ggif, int _g_hits, DateTime _regtime, string _gtel, string _dsrname, string _dfdsrname, string _cljgname, string _dsrIDCard, string _dsrfrIDCard, string _dsryingye, string _htno, string _gno, decimal _gmoney, string _dsrIDCardGif, string _dsrfrIDCardGif, string _htGif, string _dsrYingyeGif, int _qid)//, int _cityID
        {
            try
            {//                                                                                                                    ,cityID                                                                                                                                                          ,@cityID
                string sql = "insert into B2C_laws (cno,mid,shopID,gtitle,gcontent,ggif,g_hits,regtime,gtel,dsrname,dfdsrname,cljgname,dsr_IDCard,dsr_frIDCard,dsr_yingye,ht_no,gno,g_money,dsr_IDC_gif,dsr_fr_gif,ht_gif,dsr_yingye_gif,qid) values (@cno,@mid,@shopID,@gtitle,@gcontent,@ggif,@g_hits,@regtime,@gtel,@dsrname,@dfdsrname,@cljgname,@dsrIDCard,@dsrFrIDCard,@dsrYingye,@htno,@gno,@gmoney,@dsrIDCardGif,@dsrFrIDCardGif,@htGif,@dsrYingyeGif,@qid)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@mID", _mID), 
                    new SqlParameter("@shopID", _shopID), 
                    new SqlParameter("@gtitle", _gtitle),
                    new SqlParameter("@gcontent", _gcontent), 
                    new SqlParameter("@ggif", _ggif), 
                    new SqlParameter("@g_hits", _g_hits),
                    new SqlParameter("@regtime", _regtime), 
                    //new SqlParameter("@cityID", _cityID), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@dsrname", _dsrname), 
                    new SqlParameter("@dfdsrname", _dfdsrname), 
                    new SqlParameter("@cljgname", _cljgname), 
                    new SqlParameter("@dsrIDCard", _dsrIDCard), 
                    new SqlParameter("@dsrFrIDCard", _dsrfrIDCard), 
                    new SqlParameter("@dsrYingye", _dsryingye), 
                    new SqlParameter("@htno", _htno), 
                    new SqlParameter("@gno", _gno), 
                    new SqlParameter("@gmoney", _gmoney), 
                    new SqlParameter("@dsrIDCardGif", _dsrIDCardGif), 
                    new SqlParameter("@dsrFrIDCardGif", _dsrfrIDCardGif), 
                    new SqlParameter("@htGif", _htGif), 
                    new SqlParameter("@dsrYingyeGif", _dsrYingyeGif), 
                    new SqlParameter("@qid", _qid)};

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
        private void myUpdate(int _id, string _cno, int _mID, int _shopID, string _gtitle, string _gcontent, string _ggif, int _g_hits, DateTime _regtime, string _gtel, string _dsrname, string _dfdsrname, string _cljgname, string _dsrIDCard, string _dsrfrIDCard, string _dsryingye, string _htno, string _gno, decimal _gmoney, string _dsrIDCardGif, string _dsrfrIDCardGif, string _htGif, string _dsrYingyeGif, int _qid)//, int _cityID
        {
            try
            {
                string sql = "update B2C_laws set cno=@cno,mid=@mid,shopID=@shopID,gtitle=@gtitle,gcontent=@gcontent,ggif=@ggif,g_hits=@g_hits,regtime=@regtime,gtel=@gtel,dsrname=@dsrname,dfdsrname=@dfdsrname,cljgname=@cljgname,dsr_IDCard=@dsrIDCard,dsr_frIDCard=@dsrFrIDCard,dsr_yingye=@dsrYingye,ht_no=@htno,gno=@gno,g_money=@gmoney,dsr_idc_gif=@dsrIDCardGif,dsr_fr_gif=@dsrFrIDCardGif,ht_gif=@htGif,dsr_yingye_gif=@dsrYingyeGif,qid=@qid where id=" + _id;//,cityID=@cityID
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@mID", _mID), 
                    new SqlParameter("@shopID", _shopID), 
                    new SqlParameter("@gtitle", _gtitle),
                    new SqlParameter("@gcontent", _gcontent), 
                    new SqlParameter("@ggif", _ggif), 
                    new SqlParameter("@g_hits", _g_hits),
                    new SqlParameter("@regtime", _regtime), 
                    //new SqlParameter("@cityID", _cityID), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@dsrname", _dsrname), 
                    new SqlParameter("@dfdsrname", _dfdsrname), 
                    new SqlParameter("@cljgname", _cljgname), 
                    new SqlParameter("@dsrIDCard", _dsrIDCard), 
                    new SqlParameter("@dsrFrIDCard", _dsrfrIDCard), 
                    new SqlParameter("@dsrYingye", _dsryingye), 
                    new SqlParameter("@htno", _htno), 
                    new SqlParameter("@gno", _gno), 
                    new SqlParameter("@gmoney", _gmoney), 
                    new SqlParameter("@dsrIDCardGif", _dsrIDCardGif), 
                    new SqlParameter("@dsrFrIDCardGif", _dsrfrIDCardGif), 
                    new SqlParameter("@htGif", _htGif), 
                    new SqlParameter("@dsrYingyeGif", _dsrYingyeGif), 
                    new SqlParameter("@qid", _qid)};

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
            string sql = "delete from B2C_laws where id=" + _cid + "";
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
                this.myInsert(cno, mID, shopID, gtitle, gcontent, ggif, g_hits, regtime, gtel, dsrname, dfdsrname, cljgname, dsr_IDCard, dsr_frIDCard, dsr_yingye, ht_no, gno, g_money, dsr_IDC_gif, dsr_fr_gif, ht_gif, dsr_yingye_gif, qID);//,  cityID
            }
            else
            {
                this.myUpdate(id, cno, mID, shopID, gtitle, gcontent, ggif, g_hits, regtime, gtel, dsrname, dfdsrname, cljgname, dsr_IDCard, dsr_frIDCard, dsr_yingye, ht_no, gno, g_money, dsr_IDC_gif, dsr_fr_gif, ht_gif, dsr_yingye_gif, qID);//, cityID
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
            Mname = "";
            shopID = 0;
            shopName = "";
            gtitle = "";
            gcontent = ""; 
            ggif = ""; 
            g_hits = 0;
            regtime = DateTime.Now; 
            //cityID = 1;
            gtel = "";
            dsrname = "";
            dfdsrname = "";
            cljgname = "";

            //2013-1-19更新
            dsr_frIDCard = "";
            dsr_frIDCard = "";
            dsr_yingye = "";
            ht_no = "";
            gno = "";
            g_money = 0;
            dsr_IDC_gif = "";
            dsr_fr_gif = "";
            dsr_yingye_gif = "";
            ht_gif = ""; 

            //2013-05-04添加
            qID = 0;
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

            string sql = "select count(*) from B2C_laws where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_laws where " + _sql + " order by id desc");
                DataTable dt2 = proTable.Clone();
                for (int i = beginItem; i <= endItem; i++)
                {
                    dt2.ImportRow(proTable.Rows[i]);
                }
                //throw (new Exception("select " + _dzd + " from B2C_laws where " + _sql + " order by id desc"));
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
