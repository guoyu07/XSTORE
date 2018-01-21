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
using System.Collections.Generic; 

namespace tdx.database
{
    public class B2C_mem
    {
        public int id = 0;
        public int M_vip = 1;
        public string M_card = "";
        public string M_name = "";
        public string M_psw = "";
        public string M_psw_old = "";
        public string M_question = "";
        public string M_answer = "";
        public DateTime M_logontime = DateTime.Now;
        public DateTime M_regtime = DateTime.Now;
        public int M_hits = 0;
        public string M_truename = "";
        public string M_sex = "";
        public int M_isactive = 1;
        public int M_isdel = 0;
        public int M_busi = 0;
        public int cityID = 1;
        public string surl = "";
        public string ip = "";
        public string M_photo = "";
        public string M_tags = "";
        public string M_xueli = "";
        public string M_addr = "";
        public string M_tel = "";
        public string M_fax = "";
        public string M_zip = "";
        public string M_mobile = "";
        public DateTime M_BirthDay = DateTime.Parse("1900-1-1");
        public string M_email = "";
        public string M_url = "";
        public string M_QQ = "";
        public int M_email_true = 0;
        public int M_mobile_true = 0;
        public string M_Guider = "";

        public string M_vipname = "";
        public decimal M_amt = 0;
        public decimal M_cent = 0;

        //2013-03-19日添加
        public string M_IDCard = ""; //身份证号码
        public string M_jobs = "";   //职业

        public string M_DPID = "";
        public string M_CarNo = "";

        public B2C_mem() { }
        public B2C_mem(int _id)
        {
            id = _id;
            this.load();
        }
        public B2C_mem(string _mname)
        {
            M_name = _mname;
            this.load();
        }

        private void load()
        {
            string sql = "select *,(select Mvip_name from b2c_memvip where b2c_memvip.mvip_id=b2c_mem.m_vip) as M_vipname,isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and cno='001' order by id desc),0) as M_amt,isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and cno='002' order by id desc),0) as M_cent from B2C_mem where id=" + id + "";
            if (id == 0 && M_name != "")
                sql = "select top 1 *,(select Mvip_name from b2c_memvip where b2c_memvip.mvip_id=b2c_mem.m_vip) as M_vipname,isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and cno='001'  order by id desc),0) as M_amt,isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and cno='002' order by id desc),0) as M_cent from b2c_mem where M_name='" + M_name + "' or M_mobile='" + M_name + "' or M_email='" + M_name + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {

                id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                M_vip = Convert.IsDBNull(dt.Rows[0]["M_vip"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_vip"]);
                M_card = Convert.IsDBNull(dt.Rows[0]["M_card"]) ? "" : Convert.ToString(dt.Rows[0]["M_card"]);
                M_name = Convert.IsDBNull(dt.Rows[0]["M_name"]) ? "" : Convert.ToString(dt.Rows[0]["M_name"]);
                M_psw = Convert.IsDBNull(dt.Rows[0]["M_psw"]) ? "" : Convert.ToString(dt.Rows[0]["M_psw"]);
                M_question = Convert.IsDBNull(dt.Rows[0]["M_question"]) ? "" : Convert.ToString(dt.Rows[0]["M_question"]);
                M_answer = Convert.IsDBNull(dt.Rows[0]["M_answer"]) ? "" : Convert.ToString(dt.Rows[0]["M_answer"]);
                M_logontime = Convert.IsDBNull(dt.Rows[0]["M_logontime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["M_logontime"]);
                M_regtime = Convert.IsDBNull(dt.Rows[0]["M_regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["M_regtime"]);
                M_hits = Convert.IsDBNull(dt.Rows[0]["M_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_hits"]);
                M_truename = Convert.IsDBNull(dt.Rows[0]["M_truename"]) ? "" : Convert.ToString(dt.Rows[0]["M_truename"]);
                M_sex = Convert.IsDBNull(dt.Rows[0]["M_sex"]) ? "未知" : Convert.ToString(dt.Rows[0]["M_sex"]);
                M_isactive = Convert.IsDBNull(dt.Rows[0]["M_isactive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["M_isactive"]);
                M_isdel = Convert.IsDBNull(dt.Rows[0]["M_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_isdel"]);
                M_busi = Convert.IsDBNull(dt.Rows[0]["M_busi"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_busi"]);
                cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);
                surl = Convert.IsDBNull(dt.Rows[0]["surl"]) ? "" : Convert.ToString(dt.Rows[0]["surl"]);
                ip = Convert.IsDBNull(dt.Rows[0]["ip"]) ? "" : Convert.ToString(dt.Rows[0]["ip"]);
                M_photo = Convert.IsDBNull(dt.Rows[0]["M_photo"]) ? "" : Convert.ToString(dt.Rows[0]["M_photo"]);
                M_tags = Convert.IsDBNull(dt.Rows[0]["M_tags"]) ? "" : Convert.ToString(dt.Rows[0]["M_tags"]);
                M_xueli = Convert.IsDBNull(dt.Rows[0]["M_xueli"]) ? "" : Convert.ToString(dt.Rows[0]["M_xueli"]);
                M_addr = Convert.IsDBNull(dt.Rows[0]["M_addr"]) ? "" : Convert.ToString(dt.Rows[0]["M_addr"]);
                M_tel = Convert.IsDBNull(dt.Rows[0]["M_tel"]) ? "" : Convert.ToString(dt.Rows[0]["M_tel"]);
                M_fax = Convert.IsDBNull(dt.Rows[0]["M_fax"]) ? "" : Convert.ToString(dt.Rows[0]["M_fax"]);
                M_zip = Convert.IsDBNull(dt.Rows[0]["M_zip"]) ? "" : Convert.ToString(dt.Rows[0]["M_zip"]);
                M_mobile = Convert.IsDBNull(dt.Rows[0]["M_mobile"]) ? "" : Convert.ToString(dt.Rows[0]["M_mobile"]);
                M_BirthDay = Convert.IsDBNull(dt.Rows[0]["M_BirthDay"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["M_BirthDay"]);
                M_email = Convert.IsDBNull(dt.Rows[0]["M_email"]) ? "" : Convert.ToString(dt.Rows[0]["M_email"]);
                M_url = Convert.IsDBNull(dt.Rows[0]["M_url"]) ? "" : Convert.ToString(dt.Rows[0]["M_url"]);
                M_QQ = Convert.IsDBNull(dt.Rows[0]["M_QQ"]) ? "" : Convert.ToString(dt.Rows[0]["M_QQ"]);
                M_email_true = Convert.IsDBNull(dt.Rows[0]["M_email_true"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_email_true"]);
                M_mobile_true = Convert.IsDBNull(dt.Rows[0]["M_mobile_true"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_mobile_true"]);
                M_Guider = Convert.IsDBNull(dt.Rows[0]["M_Guider"]) ? "" : Convert.ToString(dt.Rows[0]["M_Guider"]);

                M_vipname = Convert.IsDBNull(dt.Rows[0]["M_vipname"]) ? "" : Convert.ToString(dt.Rows[0]["M_vipname"]);
                M_amt = Convert.IsDBNull(dt.Rows[0]["M_amt"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["M_amt"]);
                M_cent = Convert.IsDBNull(dt.Rows[0]["M_cent"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["M_cent"]);

                M_IDCard = Convert.IsDBNull(dt.Rows[0]["M_IDCard"]) ? "" : Convert.ToString(dt.Rows[0]["M_IDCard"]);
                M_jobs = Convert.IsDBNull(dt.Rows[0]["M_jobs"]) ? "" : Convert.ToString(dt.Rows[0]["M_jobs"]);
                M_DPID = Convert.IsDBNull(dt.Rows[0]["M_DPID"]) ? "" : Convert.ToString(dt.Rows[0]["M_DPID"]);
                M_CarNo = Convert.IsDBNull(dt.Rows[0]["M_CarNo"]) ? "" : Convert.ToString(dt.Rows[0]["M_CarNo"]);
            }
            else
            {
                id = 0;
                //throw new NotSupportedException("B2C_mem_id：" + id + "不存在");
            }
        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _M_vip, string _M_card, string _M_name, string _M_psw, string _M_question, string _M_answer, DateTime _M_logontime, DateTime _M_regtime, int _M_hits, string _M_truename, string _M_sex, int _M_isactive, int _M_isdel, int _M_busi, int _cityID, string _surl, string _ip, string _M_photo, string _M_tags, string _M_xueli, string _M_addr, string _M_tel, string _M_fax, string _M_zip, string _M_mobile, DateTime _M_BirthDay, string _M_email, string _M_url, string _M_QQ, int _M_email_true, int _M_mobile_true, string _M_Guider, string _M_IDCard, string _M_jobs, string _M_DPID, string _M_CarNo)
        {

            try
            {
                string sql = "insert into B2C_mem (M_vip,M_card,M_name,M_psw,M_question,M_answer,M_logontime,M_regtime,M_hits,M_truename,M_sex,M_isactive,M_isdel,M_busi,cityID,surl,ip,M_photo,M_tags,M_xueli,M_addr,M_tel,M_fax,M_zip,M_mobile,M_BirthDay,M_email,M_url,M_QQ,M_email_true,M_mobile_true,M_Guider,M_IDCard,M_jobs,M_DPID,M_CarNo) values (@M_vip,@M_card,@M_name,@M_psw,@M_question,@M_answer,@M_logontime,@M_regtime,@M_hits,@M_truename,@M_sex,@M_isactive,@M_isdel,@M_busi,@cityID,@surl,@ip,@M_photo,@M_tags,@M_xueli,@M_addr,@M_tel,@M_fax,@M_zip,@M_mobile,@M_BirthDay,@M_email,@M_url,@M_QQ,@M_email_true,@M_mobile_true,@M_Guider,@M_IDCard,@M_jobs,@M_DPID,@M_CarNo)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@M_vip", _M_vip), 
                     new SqlParameter("@M_card", _M_card),
                    new SqlParameter("@M_name", _M_name), 
                    new SqlParameter("@M_psw", comEncrypt.GetMD5(_M_psw)),
                    new SqlParameter("@M_question", _M_question),
                    new SqlParameter("@M_answer", _M_answer),
                    new SqlParameter("@M_logontime", _M_logontime),
                    new SqlParameter("@M_regtime", _M_regtime),
                    new SqlParameter("@M_hits", _M_hits),
                    new SqlParameter("@M_truename", _M_truename),
                    new SqlParameter("@M_sex", _M_sex),
                    new SqlParameter("@M_isactive", _M_isactive),
                    new SqlParameter("@M_isdel", _M_isdel),
                    new SqlParameter("@M_busi", _M_busi),
                    new SqlParameter("@cityID", _cityID),
                    new SqlParameter("@surl", _surl),
                    new SqlParameter("@ip", _ip),
                     new SqlParameter("@M_photo", _M_photo),
                      new SqlParameter("@M_tags", _M_tags),
                       new SqlParameter("@M_xueli", _M_xueli),
                       new SqlParameter("@M_addr", _M_addr),
                       new SqlParameter("@M_tel", _M_tel),
                       new SqlParameter("@M_fax", _M_fax),
                       new SqlParameter("@M_zip", _M_zip),
                       new SqlParameter("@M_mobile", _M_mobile),
                       new SqlParameter("@M_BirthDay", _M_BirthDay),
                        new SqlParameter("@M_email", _M_email),
                       new SqlParameter("@M_url", _M_url),
                       new SqlParameter("@M_QQ", _M_QQ),
                       new SqlParameter("@M_email_true", _M_email_true),
                       new SqlParameter("@M_mobile_true", _M_mobile_true),
                       new SqlParameter("@M_Guider", _M_Guider),
                       new SqlParameter("@M_IDCard", _M_IDCard),
                       new SqlParameter("@M_jobs", _M_jobs),
                       new SqlParameter("@M_DPID", _M_DPID),
                       new SqlParameter("@M_CarNo", _M_CarNo)
                };

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
        private void myUpdate(int _id, int _M_vip, string _M_card, string _M_name, string _M_psw, string _M_question, string _M_answer, DateTime _M_logontime, DateTime _M_regtime, int _M_hits, string _M_truename, string _M_sex, int _M_isactive, int _M_isdel, int _M_busi, int _cityID, string _surl, string _ip, string _M_photo, string _M_tags, string _M_xueli, string _M_addr, string _M_tel, string _M_fax, string _M_zip, string _M_mobile, DateTime _M_BirthDay, string _M_email, string _M_url, string _M_QQ, int _M_email_true, int _M_mobile_true, string _M_Guider, string _M_IDCard, string _M_jobs, string _M_DPID, string _M_CarNo)
        {
            try
            {
                string sql = "update B2C_mem set M_vip=@M_vip,M_card=@M_card,M_name=@M_name,M_psw=@M_psw,M_question=@M_question,M_answer=@M_answer,M_logontime=@M_logontime,M_regtime=@M_regtime,M_hits=@M_hits,M_truename=@M_truename,M_sex=@M_sex,M_isactive=@M_isactive,M_isdel=@M_isdel,M_busi=@M_busi,cityID=@cityID,surl=@surl,ip=@ip,M_photo=@M_photo,M_tags=@M_tags,M_xueli=@M_xueli,M_addr=@M_addr,M_tel=@M_tel,M_fax=@M_fax,M_zip=@M_zip,M_mobile=@M_mobile,M_BirthDay=@M_BirthDay,M_email=@M_email,M_url=@M_url,M_QQ=@M_QQ,M_email_true=@M_email_true,M_mobile_true=@M_mobile_true,M_Guider=@M_Guider,M_IDCard=@M_IDCard,M_jobs=@M_jobs,M_DPID=@M_DPID,M_CarNo=@M_CarNo  where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@M_vip", _M_vip), 
                     new SqlParameter("@M_card", _M_card),
                    new SqlParameter("@M_name", _M_name), 
                    new SqlParameter("@M_psw", (_M_psw.Length > 0 ? comEncrypt.GetMD5(_M_psw.Trim()): M_psw_old.Trim()) ),
                    new SqlParameter("@M_question", _M_question),
                    new SqlParameter("@M_answer", _M_answer),
                    new SqlParameter("@M_logontime", _M_logontime),
                    new SqlParameter("@M_regtime", _M_regtime),
                    new SqlParameter("@M_hits", _M_hits),
                    new SqlParameter("@M_truename", _M_truename),
                    new SqlParameter("@M_sex", _M_sex),
                    new SqlParameter("@M_isactive", _M_isactive),
                    new SqlParameter("@M_isdel", _M_isdel),
                    new SqlParameter("@M_busi", _M_busi),
                    new SqlParameter("@cityID", _cityID),
                    new SqlParameter("@surl", _surl),
                     new SqlParameter("@ip", _ip),
                      new SqlParameter("@M_photo", _M_photo),
                      new SqlParameter("@M_tags", _M_tags),
                       new SqlParameter("@M_xueli", _M_xueli),
                       new SqlParameter("@M_addr", _M_addr),
                       new SqlParameter("@M_tel", _M_tel),
                       new SqlParameter("@M_fax", _M_fax),
                       new SqlParameter("@M_zip", _M_zip),
                       new SqlParameter("@M_mobile", _M_mobile),
                       new SqlParameter("@M_BirthDay", _M_BirthDay),
                        new SqlParameter("@M_email", _M_email),
                       new SqlParameter("@M_url", _M_url),
                       new SqlParameter("@M_QQ", _M_QQ),
                       new SqlParameter("@M_email_true", _M_email_true),
                       new SqlParameter("@M_mobile_true", _M_mobile_true),
                       new SqlParameter("@M_Guider", _M_Guider),
                       new SqlParameter("@M_IDCard", _M_IDCard),
                       new SqlParameter("@M_jobs", _M_jobs),
                       new SqlParameter("@M_DPID", _M_DPID),
                       new SqlParameter("@M_CarNo", _M_CarNo),
                };

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
        public static void myUpdateemail(int _id, int _M_email_true)
        {
            try
            {
                string sql = "update B2C_mem set M_email_true=@M_email_true  where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@M_email_true", _M_email_true)
                };

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
        public static void myUpdatemobile(int _id, int _M_mobile_true)
        {
            try
            {
                string sql = "update B2C_mem set M_mobile_true=@M_mobile_true  where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@M_mobile_true", _M_mobile_true)  
                };

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
            string sql = "delete from B2C_mem where id=" + _id + "";
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
                this.myInsert(M_vip, M_card, M_name, M_psw, M_question, M_answer, M_logontime, M_regtime, M_hits, M_truename, M_sex, M_isactive, M_isdel, M_busi, cityID, surl, ip, M_photo, M_tags, M_xueli, M_addr, M_tel, M_fax, M_zip, M_mobile, M_BirthDay, M_email, M_url, M_QQ, M_email_true, M_mobile_true, M_Guider, M_IDCard, M_jobs,M_DPID,M_CarNo);
            }
            else
            {
                this.myUpdate(id, M_vip, M_card, M_name, M_psw, M_question, M_answer, M_logontime, M_regtime, M_hits, M_truename, M_sex, M_isactive, M_isdel, M_busi, cityID, surl, ip, M_photo, M_tags, M_xueli, M_addr, M_tel, M_fax, M_zip, M_mobile, M_BirthDay, M_email, M_url, M_QQ, M_email_true, M_mobile_true, M_Guider, M_IDCard, M_jobs, M_DPID, M_CarNo);
            }
        }
        /// <summary>
        /// 添加默认方法
        /// </summary>
        public void AddNew()
        {
            id = 0;
            M_vip = 1;
            M_card = "";
            M_name = "";
            M_psw = "";
            M_question = "";
            M_answer = "";
            M_logontime = DateTime.Now;
            M_regtime = DateTime.Now;
            M_hits = 0;
            M_truename = "";
            M_sex = "";
            M_isactive = 1;
            M_isdel = 0;
            M_busi = 0;
            cityID = 1;
            surl = "";

            M_IDCard = "";
            M_jobs = "";
            M_DPID="";
            M_CarNo = "";
        }
        #region 按钮功能
        /// <summary>
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        public static int setActive(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_mem set M_isactive= -1 * (M_isactive - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 设置是否放入回收站
        /// </summary>
        /// <param name="_cid"></param>
        public static int setDel(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_mem set M_isdel= -1 * (M_isdel - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 设置是否开通商户
        /// </summary>
        /// <param name="_cid"></param>
        public static int setBusi(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_mem set M_busi= -1 * (M_busi - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="_cid"></param>
        public static int UpdatePwd(int _id, string _uname, string _npwd)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_mem set M_psw='" + comEncrypt.GetMD5(_npwd) + "' where id=" + _id + " and M_name='" + _uname + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        public static int UpdateLogon(int _id, string _ips)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_mem set M_hits=M_hits+1,ip='" + _ips + "',M_logontime=getDate() where id=" + _id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_mem where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataTable GetList(int _page, string _dzd, string _tname, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;
            if (_page <= 0)
            {
                _page = 0 + 1;
            }
            string sql = "select count(*) from B2C_mem where 1=1 and " + _sql + "";
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalcount % pagesize != 0)
            {
                totalpage = totalpage + 1;
            }
            else if (totalpage == 0)
            {
                totalpage = 1;
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
                DataTable dt = comfun.GetDataTableBySQL("select " + _dzd + " from " + _tname + " where " + _sql + " order by id desc");
                DataTable dt2 = dt.Clone();
                if (dt.Rows.Count > 0)
                {
                    for (int i = beginItem; i <= endItem; i++)
                    {
                        dt2.ImportRow(dt.Rows[i]);
                    }
                }
                return dt2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 如会员卡设置为开启，则遍历会员中未有等级的会员，对其进行赋等级操作
        /// 
        /// </summary>
        /// <param name="_wid"></param>
        /// <returns></returns>
        public static int CheckRankID(int _wid)
        {
            int _return = 0;
            string _sql = "*";
            string _where = string.Format(" wid={0}", _wid);
            DataTable dt = B2C_vipcard.GetList(_sql, _where);
            if (dt.Rows[0]["is_open"].ToString() == "1")
            {
                _sql = string.Format("*");
                _where = string.Format("cityID={0} and id not in (select uid from B2C_user_rank)", _wid);
                DataTable _dt = B2C_mem.GetList(_sql, _where);
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in _dt.Rows)
                    {
                        int _id = Convert.ToInt32(dr["id"]);
                        int _cityID = Convert.ToInt32(dr["cityID"]);
                        B2C_rankinfo.OpenCard(_id, _cityID);
                    }
                    _return = 1;
                }
                else
                {
                    _return = 0;
                }
            }
            return _return;
        }

        public static weixinUser GetWeiXinRequest(string _wwv,string _developID,string _developPsw)
        {
           
                weixin _weixin = new weixin();
                weixinUser _user = new weixinUser();
               
                _user = _weixin.GetInfo(_wwv, _developID, _developPsw);
                return _user;
           

        }

    }
}
