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
    public class B2C_mem_law
    {
        public int id = 0;                     //编号，自增
        public string cno = "";                //关联B2C_lawcate的c_no
        public string cname = "";
        public int mID = 0;						//所属会员ID
		public string mName = "";                 //所属会员名称
        public string gtitle = "";             //单位名称
        public string gcontent = "";           //介绍       
        public string ggif = "";               //图片文件名 
        public int g_sort = 99;                 //排序,越小越靠前
        public int g_hits = 0;                 //浏览次数
        DateTime regtime = DateTime.Now;       //录入时间 
        public int cityID = 1;                 //城市ID，目前缺省为1，不用编辑

        //新增的律师字段
        public string m_nation = "";//民族
        public string m_xueli = "";//学历
        public string m_zhuanye = "";//专业
        public string m_byyx = "";//毕业院校
        public string m_bysj = "";//毕业时间
        public string m_sfks_date = "";//何时通过司法考试
        public string m_zyzs_date = "";//何时取得司法证书
        public string m_zyzs_num = "";//职业证书号码
        public string m_ID_num = "";//身份证号码
        public string gaddr = "";//工作地点
        public string g_chufen = "";//是否受过行政处分或当事人投诉
        public string g_jiaoda = "";//是否办理过较大影响力的案件
        public string g_sqyj = "";//对于果淘淘合作的意见
        public string r_msg = "";//果淘淘审核意见
        public DateTime rtime = DateTime.Parse("2000-1-1"); //审核时间

        public string gname = ""; //姓名
        public string gsex = ""; //性别
        public string gtel = ""; //电话
        public string gqq = ""; //QQ
        public string gbirth = ""; //生日 
        public int g_isA = 0;//审核标志

        public B2C_mem_law() { }
        public B2C_mem_law(int _id) {
            id = _id;
            this.load();
        }
        public B2C_mem_law(string _shopid)
        {
            this.mID = Convert.ToInt32(_shopid);
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select c_name from B2C_lawcate where c_no=cno) as cname,(select m_name from B2C_mem where b2c_mem.id=b2c_mem_law.mid) as mname from B2C_mem_law where";
            if(this.mID!=0)
            {
                sql += " mid=" + this.mID + "";
            }
            else
            {
                sql +=  " id=" + this.id + "";
            }
            
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_mem_lawID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    cname = Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]);
                    mID = Convert.IsDBNull(dt.Rows[0]["mID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mID"]);
                    mName = Convert.IsDBNull(dt.Rows[0]["mname"]) ? "" : Convert.ToString(dt.Rows[0]["mname"]);
                    gtitle = Convert.IsDBNull(dt.Rows[0]["gtitle"]) ? "" : Convert.ToString(dt.Rows[0]["gtitle"]);
                    gcontent = Convert.IsDBNull(dt.Rows[0]["gcontent"]) ? "" : Convert.ToString(dt.Rows[0]["gcontent"]);
                    ggif = Convert.IsDBNull(dt.Rows[0]["ggif"]) ? "" : Convert.ToString(dt.Rows[0]["ggif"]); 
                    g_sort = Convert.IsDBNull(dt.Rows[0]["g_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["g_sort"]);
                    g_hits = Convert.IsDBNull(dt.Rows[0]["g_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_hits"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); 
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);

                    m_nation = Convert.IsDBNull(dt.Rows[0]["m_nation"]) ? "" : Convert.ToString(dt.Rows[0]["m_nation"]);
                    m_xueli = Convert.IsDBNull(dt.Rows[0]["m_xueli"]) ? "" : Convert.ToString(dt.Rows[0]["m_xueli"]);
                    m_zhuanye = Convert.IsDBNull(dt.Rows[0]["m_zhuanye"]) ? "" : Convert.ToString(dt.Rows[0]["m_zhuanye"]);
                    m_byyx = Convert.IsDBNull(dt.Rows[0]["m_byyx"]) ? "" : Convert.ToString(dt.Rows[0]["m_byyx"]);
                    m_bysj = Convert.IsDBNull(dt.Rows[0]["m_bysj"]) ? "" : Convert.ToString(dt.Rows[0]["m_bysj"]);
                    m_sfks_date = Convert.IsDBNull(dt.Rows[0]["m_sfks_date"]) ? "" : Convert.ToString(dt.Rows[0]["m_sfks_date"]);
                    m_zyzs_date = Convert.IsDBNull(dt.Rows[0]["m_zyzs_date"]) ? "" : Convert.ToString(dt.Rows[0]["m_zyzs_date"]);
                    m_zyzs_num = Convert.IsDBNull(dt.Rows[0]["m_zyzs_num"]) ? "" : Convert.ToString(dt.Rows[0]["m_zyzs_num"]);
                    m_ID_num = Convert.IsDBNull(dt.Rows[0]["m_ID_num"]) ? "" : Convert.ToString(dt.Rows[0]["m_ID_num"]);
                    gaddr = Convert.IsDBNull(dt.Rows[0]["gaddr"]) ? "" : Convert.ToString(dt.Rows[0]["gaddr"]);
                    g_chufen = Convert.IsDBNull(dt.Rows[0]["g_chufen"]) ? "" : Convert.ToString(dt.Rows[0]["g_chufen"]);
                    g_jiaoda = Convert.IsDBNull(dt.Rows[0]["g_jiaoda"]) ? "" : Convert.ToString(dt.Rows[0]["g_jiaoda"]);
                    g_sqyj = Convert.IsDBNull(dt.Rows[0]["g_sqyj"]) ? "" : Convert.ToString(dt.Rows[0]["g_sqyj"]);
                    r_msg = Convert.IsDBNull(dt.Rows[0]["r_msg"]) ? "" : Convert.ToString(dt.Rows[0]["r_msg"]);
                    rtime = Convert.IsDBNull(dt.Rows[0]["rtime"]) ? DateTime.Parse("2000-1-1") : Convert.ToDateTime(dt.Rows[0]["rtime"]);

                    g_isA = Convert.IsDBNull(dt.Rows[0]["g_isA"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_isA"]);
                    gname = Convert.IsDBNull(dt.Rows[0]["gname"]) ? "" : Convert.ToString(dt.Rows[0]["gname"]);
                    gsex = Convert.IsDBNull(dt.Rows[0]["gsex"]) ? "" : Convert.ToString(dt.Rows[0]["gsex"]);
                    gtel = Convert.IsDBNull(dt.Rows[0]["gtel"]) ? "" : Convert.ToString(dt.Rows[0]["gtel"]);
                    gqq = Convert.IsDBNull(dt.Rows[0]["gQQ"]) ? "" : Convert.ToString(dt.Rows[0]["gQQ"]);
                    gbirth = Convert.IsDBNull(dt.Rows[0]["gbirth"]) ? "" : Convert.ToString(dt.Rows[0]["gbirth"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_mem_lawID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _cno, int _mID, string _gtitle, string _gcontent, string _ggif, int _g_sort, int _g_hits, DateTime _regtime, int _cityID, string _m_nation, string _m_xueli, string _m_zhuanye, string _m_byyx, string _m_bysj, string _m_sfks_date, string _m_zyzs_date, string _m_zyzs_num, string _m_ID_num, string _gaddr, string _g_chufen, string _g_jiaoda, string _g_sqyj, string _r_msg,DateTime _rtime,string _gname,string _gsex,string _gtel,string _gqq,string _gbirth)
        {
            try
            {
                string sql = "insert into B2C_mem_law (cno,mID,gtitle,gcontent,ggif,g_sort,g_hits,regtime,cityID,m_nation,m_xueli, m_zhuanye ,m_byyx,m_bysj ,m_sfks_date,m_zyzs_date,m_zyzs_num,m_ID_num , gaddr , g_chufen,g_jiaoda, g_sqyj ,r_msg , rtime,gname,gsex,gtel,gqq,gbirth,g_isA) values (@cno,@mID,@gtitle,@gcontent,@ggif,@g_sort,@g_hits,@regtime,@cityID,@m_nation,@m_xueli, @m_zhuanye ,@m_byyx,@m_bysj ,@m_sfks_date,@m_zyzs_date,@m_zyzs_num,@m_ID_num , @gaddr , @g_chufen,@g_jiaoda, @g_sqyj ,@r_msg , @rtime,@gname,@gsex,@gtel,@gqq,@gbirth,1)";
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
                    new SqlParameter("@m_nation", _m_nation), 
                    new SqlParameter("@m_xueli", _m_xueli), 
                    new SqlParameter("@m_zhuanye", _m_zhuanye), 
                    new SqlParameter("@m_byyx", _m_byyx), 
                    new SqlParameter("@m_bysj", _m_bysj), 
                    new SqlParameter("@m_sfks_date", _m_sfks_date), 
                    new SqlParameter("@m_zyzs_date", _m_zyzs_date), 
                    new SqlParameter("@m_zyzs_num", _m_zyzs_num), 
                    new SqlParameter("@m_ID_num", _m_ID_num), 
                    new SqlParameter("@gaddr", _gaddr), 
                    new SqlParameter("@g_chufen", _g_chufen), 
                    new SqlParameter("@g_jiaoda", _g_jiaoda), 
                    new SqlParameter("@g_sqyj", _g_sqyj), 
                    new SqlParameter("@r_msg", _r_msg), 
                    new SqlParameter("@rtime", _rtime), 
                    new SqlParameter("@gname", _gname), 
                    new SqlParameter("@gsex", _gsex), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@gqq", _gqq), 
                    new SqlParameter("@gbirth", _gbirth)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
                comfun.UpdateBySQL("update b2c_mem set m_busi=2 where id=" + _mID.ToString());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void myInsert2(string _cno, int _mID, string _gtitle, string _gcontent, string _ggif, int _g_sort, int _g_hits, DateTime _regtime, int _cityID, string _m_nation, string _m_xueli, string _m_zhuanye, string _m_byyx, string _m_bysj, string _m_sfks_date, string _m_zyzs_date, string _m_zyzs_num, string _m_ID_num, string _gaddr, string _g_chufen, string _g_jiaoda, string _g_sqyj, string _r_msg, DateTime _rtime,string _gname,string _gsex,string _gtel,string _gqq,string _gbirth)
        {
            try
            {
                string sql = "insert into B2C_mem_law (cno,mID,gtitle,gcontent,ggif,g_sort,g_hits,regtime,cityID,m_nation,m_xueli, m_zhuanye ,m_byyx,m_bysj ,m_sfks_date,m_zyzs_date,m_zyzs_num,m_ID_num , gaddr , g_chufen,g_jiaoda, g_sqyj ,r_msg , rtime,gname,gsex,gtel,gqq,gbirth) values (@cno,@mID,@gtitle,@gcontent,@ggif,@g_sort,@g_hits,@regtime,@cityID,@m_nation,@m_xueli, @m_zhuanye ,@m_byyx,@m_bysj ,@m_sfks_date,@m_zyzs_date,@m_zyzs_num,@m_ID_num , @gaddr , @g_chufen,@g_jiaoda, @g_sqyj ,@r_msg , @rtime,@gname,@gsex,@gtel,@gqq,@gbirth)";
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
                    new SqlParameter("@m_nation", _m_nation), 
                    new SqlParameter("@m_xueli", _m_xueli), 
                    new SqlParameter("@m_zhuanye", _m_zhuanye), 
                    new SqlParameter("@m_byyx", _m_byyx), 
                    new SqlParameter("@m_bysj", _m_bysj), 
                    new SqlParameter("@m_sfks_date", _m_sfks_date), 
                    new SqlParameter("@m_zyzs_date", _m_zyzs_date), 
                    new SqlParameter("@m_zyzs_num", _m_zyzs_num), 
                    new SqlParameter("@m_ID_num", _m_ID_num), 
                    new SqlParameter("@gaddr", _gaddr), 
                    new SqlParameter("@g_chufen", _g_chufen), 
                    new SqlParameter("@g_jiaoda", _g_jiaoda), 
                    new SqlParameter("@g_sqyj", _g_sqyj), 
                    new SqlParameter("@r_msg", _r_msg), 
                    new SqlParameter("@rtime", _rtime), 
                    new SqlParameter("@gname", _gname), 
                    new SqlParameter("@gsex", _gsex), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@gqq", _gqq), 
                    new SqlParameter("@gbirth", _gbirth)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
               // comfun.UpdateBySQL("update b2c_mem set m_busi=2 where id=" + _mID.ToString());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 修改一条新的记录
        /// </summary>
        private void myUpdate(int _id, string _cno, int _mID, string _gtitle, string _gcontent, string _ggif, int _g_sort, int _g_hits, DateTime _regtime, int _cityID, string _m_nation, string _m_xueli, string _m_zhuanye, string _m_byyx, string _m_bysj, string _m_sfks_date, string _m_zyzs_date, string _m_zyzs_num, string _m_ID_num, string _gaddr, string _g_chufen, string _g_jiaoda, string _g_sqyj, string _r_msg, DateTime _rtime, string _gname, string _gsex, string _gtel, string _gqq, string _gbirth)
        {
            try
            {
                string sql = "update B2C_mem_law set cno=@cno,mID=@mID,gtitle=@gtitle,gcontent=@gcontent,ggif=@ggif,g_sort=@g_sort,g_hits=@g_hits,regtime=@regtime,cityID=@cityID,m_nation=@m_nation,m_xueli=@m_xueli, m_zhuanye=@m_zhuanye ,m_byyx=@m_byyx,m_bysj=@m_bysj ,m_sfks_date=@m_sfks_date,m_zyzs_date=@m_zyzs_date,m_zyzs_num=@m_zyzs_num,m_ID_num=@m_ID_num , gaddr=@gaddr , g_chufen=@g_chufen,g_jiaoda=@g_jiaoda, g_sqyj=@g_sqyj ,r_msg=@r_msg , rtime=@rtime,gname=@gname,gsex=@gsex,gtel=@gtel,gqq=@gqq,gbirth=@gbirth,g_isa=1  where id=" + _id;
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
                    new SqlParameter("@m_nation", _m_nation), 
                    new SqlParameter("@m_xueli", _m_xueli), 
                    new SqlParameter("@m_zhuanye", _m_zhuanye), 
                    new SqlParameter("@m_byyx", _m_byyx), 
                    new SqlParameter("@m_bysj", _m_bysj), 
                    new SqlParameter("@m_sfks_date", _m_sfks_date), 
                    new SqlParameter("@m_zyzs_date", _m_zyzs_date), 
                    new SqlParameter("@m_zyzs_num", _m_zyzs_num), 
                    new SqlParameter("@m_ID_num", _m_ID_num), 
                    new SqlParameter("@gaddr", _gaddr), 
                    new SqlParameter("@g_chufen", _g_chufen), 
                    new SqlParameter("@g_jiaoda", _g_jiaoda), 
                    new SqlParameter("@g_sqyj", _g_sqyj), 
                    new SqlParameter("@r_msg", _r_msg), 
                    new SqlParameter("@rtime", _rtime), 
                    new SqlParameter("@gname", _gname), 
                    new SqlParameter("@gsex", _gsex), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@gqq", _gqq), 
                    new SqlParameter("@gbirth", _gbirth)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
                comfun.UpdateBySQL("update b2c_mem set m_busi=2 where id=" + _mID.ToString());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        private void myUpdate2(int _id, string _cno, int _mID, string _gtitle, string _gcontent, string _ggif, int _g_sort, int _g_hits, DateTime _regtime, int _cityID, string _m_nation, string _m_xueli, string _m_zhuanye, string _m_byyx, string _m_bysj, string _m_sfks_date, string _m_zyzs_date, string _m_zyzs_num, string _m_ID_num, string _gaddr, string _g_chufen, string _g_jiaoda, string _g_sqyj, string _r_msg, DateTime _rtime, string _gname, string _gsex, string _gtel, string _gqq, string _gbirth)
        {
            try
            {
                string sql = "update B2C_mem_law set cno=@cno,mID=@mID,gtitle=@gtitle,gcontent=@gcontent,ggif=@ggif,g_sort=@g_sort,g_hits=@g_hits,regtime=@regtime,cityID=@cityID,m_nation=@m_nation,m_xueli=@m_xueli, m_zhuanye=@m_zhuanye ,m_byyx=@m_byyx,m_bysj=@m_bysj ,m_sfks_date=@m_sfks_date,m_zyzs_date=@m_zyzs_date,m_zyzs_num=@m_zyzs_num,m_ID_num=@m_ID_num , gaddr=@gaddr , g_chufen=@g_chufen,g_jiaoda=@g_jiaoda, g_sqyj=@g_sqyj ,r_msg=@r_msg , rtime=@rtime,gname=@gname,gsex=@gsex,gtel=@gtel,gqq=@gqq,gbirth=@gbirth  where id=" + _id;
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
                    new SqlParameter("@m_nation", _m_nation), 
                    new SqlParameter("@m_xueli", _m_xueli), 
                    new SqlParameter("@m_zhuanye", _m_zhuanye), 
                    new SqlParameter("@m_byyx", _m_byyx), 
                    new SqlParameter("@m_bysj", _m_bysj), 
                    new SqlParameter("@m_sfks_date", _m_sfks_date), 
                    new SqlParameter("@m_zyzs_date", _m_zyzs_date), 
                    new SqlParameter("@m_zyzs_num", _m_zyzs_num), 
                    new SqlParameter("@m_ID_num", _m_ID_num), 
                    new SqlParameter("@gaddr", _gaddr), 
                    new SqlParameter("@g_chufen", _g_chufen), 
                    new SqlParameter("@g_jiaoda", _g_jiaoda), 
                    new SqlParameter("@g_sqyj", _g_sqyj), 
                    new SqlParameter("@r_msg", _r_msg), 
                    new SqlParameter("@rtime", _rtime), 
                    new SqlParameter("@gname", _gname), 
                    new SqlParameter("@gsex", _gsex), 
                    new SqlParameter("@gtel", _gtel), 
                    new SqlParameter("@gqq", _gqq), 
                    new SqlParameter("@gbirth", _gbirth)};

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
            string sql = "delete from B2C_mem_law where id=" + _cid + "";
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
                this.myInsert(cno, mID, gtitle, gcontent, ggif, g_sort, g_hits, regtime, cityID,m_nation, m_xueli, m_zhuanye, m_byyx, m_bysj, m_sfks_date, m_zyzs_date, m_zyzs_num, m_ID_num, gaddr, g_chufen, g_jiaoda, g_sqyj, r_msg, rtime,gname,gsex,gtel,gqq,gbirth);
            }
            else
            {
                this.myUpdate(id, cno, mID, gtitle, gcontent, ggif, g_sort, g_hits, regtime, cityID, m_nation, m_xueli, m_zhuanye, m_byyx, m_bysj, m_sfks_date, m_zyzs_date, m_zyzs_num, m_ID_num, gaddr, g_chufen, g_jiaoda, g_sqyj, r_msg, rtime, gname, gsex, gtel, gqq, gbirth);
            }
        }
        public void Update2()
        {
            if (id == 0)
            {
                this.myInsert2(cno, mID, gtitle, gcontent, ggif, g_sort, g_hits, regtime, cityID, m_nation, m_xueli, m_zhuanye, m_byyx, m_bysj, m_sfks_date, m_zyzs_date, m_zyzs_num, m_ID_num, gaddr, g_chufen, g_jiaoda, g_sqyj, r_msg, rtime, gname, gsex, gtel, gqq, gbirth);
            }
            else
            {
                this.myUpdate2(id, cno, mID, gtitle, gcontent, ggif, g_sort, g_hits, regtime, cityID, m_nation, m_xueli, m_zhuanye, m_byyx, m_bysj, m_sfks_date, m_zyzs_date, m_zyzs_num, m_ID_num, gaddr, g_chufen, g_jiaoda, g_sqyj, r_msg, rtime, gname, gsex, gtel, gqq, gbirth);
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
            gcontent = "";
            ggif = ""; 
            g_sort = 99;
            g_hits = 0;
            regtime = DateTime.Now; 
            cityID = 1;

            m_nation = "";//民族
            m_xueli = "";//学历
            m_zhuanye = "";//专业
            m_byyx = "";//毕业院校
            m_bysj = "";//毕业时间
            m_sfks_date = "";//何时通过司法考试
            m_zyzs_date = "";//何时取得司法证书
            m_zyzs_num = "";//职业证书号码
            m_ID_num = "";//身份证号码
            gaddr = "";//工作地点
            g_chufen = "";//是否受过行政处分或当事人投诉
            g_jiaoda = "";//是否办理过较大影响力的案件
            g_sqyj = "";//对于果淘淘合作的意见
            r_msg = "";//果淘淘审核意见
            rtime = DateTime.Parse("2000-1-1"); //审核时间

            gname = "";
            gsex = "";
            gtel = "";
            gqq = "";
            gbirth = "";
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

            string sql = "select count(*) from B2C_mem_law where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_mem_law where " + _sql + " order by id desc");
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
