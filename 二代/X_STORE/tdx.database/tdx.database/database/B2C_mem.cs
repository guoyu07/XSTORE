using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Creatrue.kernel;
using System.Collections.Generic; 

namespace tdx.database
{
    public class B2C_mem
    {
        public int id = 0;
        public string M_no = "";
        public int M_vip = 1;
        public string M_vipname = "";
        public string M_name = "";
        public string M_psw = "";
        public string M_psw_old = "";
        public string M_psw2 = "";
        public string M_psw2_old = "";
        public string M_truename = "";
        public string M_IDCard = "";
        public string M_sex = "";
        public string M_mobile = "";
        public string M_bank = "";
        public string M_card = "";
        public string M_QQ = "";
        public string M_email = "";
        public string M_photo = "";
        public string M_addr = "";
        public string M_zip = "";
        public DateTime M_BirthDay = DateTime.Parse("1900-1-1");
        public string M_tags = "";
        public string ip = "";
        public int M_hits = 0;
        public int M_isactive = 1;
        public int M_isdel = 0;
        public int ParentID = 0;
        public string parentName = "";
        public string parentMobile = "";

        public int jieshaoID = 0;
        public string jieshaoName = "";
        public string jieshaoMobile = "";

        public int M_leve = 0;
        public int M_star = 0;
        public int cityID = 1;
        public string cityName = "";
        public decimal _amt = 0;
        public decimal _cent = 0;
        public decimal _dongjie = 0;
        public int _childs = 0;
        public decimal M_vipprice = 0;



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
            string sql = "select *,(select Mvip_name from b2c_memvip where b2c_memvip.mvip_id=b2c_mem.m_vip) as M_vipname,isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=1 order by id desc),0) as M_amt,isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=2 order by id desc),0) as M_cent";
            sql += ",isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=3 order by id desc),0) as M_dongjie";
            sql += ",(select m_truename from b2c_mem as m1 where m1.id = b2c_mem.parentID) as parentName";
            sql += ",(select m_truename from b2c_mem as m2 where m2.id = b2c_mem.jieshaoID) as jieshaoName";
            sql += ",(select m_name from b2c_mem as m1 where m1.id = b2c_mem.parentID) as parentMobile";
            sql += ",(select m_name from b2c_mem as m2 where m2.id = b2c_mem.jieshaoID) as jieshaoMobile";
            sql += ",(select real_name from dt_manager where dt_manager.id=b2c_mem.cityID) as cityName";
            sql += ",(select count(id) from b2c_mem as m3 where m3.parentID = b2c_mem.id) as childs";
            sql += ",(select Mvip_name from b2c_memvip where b2c_memvip.mvip_id=b2c_mem.m_vip) as M_vipprice";
            if (id != 0)
                sql += " from B2C_mem where id=" + id + "";
            else if (id == 0 && M_name != "")
                sql += " from b2c_mem where M_name='" + M_name + "' or M_mobile='" + M_name + "' or M_email='" + M_name + "'";
            else
                sql += " from B2C_mem where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_mem_id：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    M_no = Convert.IsDBNull(dt.Rows[0]["M_no"]) ? "" : Convert.ToString(dt.Rows[0]["M_no"]);
                    M_vip = Convert.IsDBNull(dt.Rows[0]["M_vip"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_vip"]);
                    M_vipname = Convert.IsDBNull(dt.Rows[0]["M_vipname"]) ? "" : Convert.ToString(dt.Rows[0]["M_vipname"]);
                    M_name = Convert.IsDBNull(dt.Rows[0]["M_name"]) ? "" : Convert.ToString(dt.Rows[0]["M_name"]);
                    //M_psw = Convert.IsDBNull(dt.Rows[0]["M_psw"]) ? "" : Convert.ToString(dt.Rows[0]["M_psw"]);
                    M_psw_old = Convert.IsDBNull(dt.Rows[0]["M_psw"]) ? "" : Convert.ToString(dt.Rows[0]["M_psw"]);
                    //M_psw2 = Convert.IsDBNull(dt.Rows[0]["M_psw2"]) ? "" : Convert.ToString(dt.Rows[0]["M_psw2"]);
                    M_psw2_old = Convert.IsDBNull(dt.Rows[0]["M_psw2"]) ? "" : Convert.ToString(dt.Rows[0]["M_psw2"]);
                    M_truename = Convert.IsDBNull(dt.Rows[0]["M_truename"]) ? "" : Convert.ToString(dt.Rows[0]["M_truename"]);
                    M_IDCard = Convert.IsDBNull(dt.Rows[0]["M_IDCard"]) ? "" : Convert.ToString(dt.Rows[0]["M_IDCard"]);
                    M_sex = Convert.IsDBNull(dt.Rows[0]["M_sex"]) ? "未知" : Convert.ToString(dt.Rows[0]["M_sex"]);
                    M_mobile = Convert.IsDBNull(dt.Rows[0]["M_mobile"]) ? "" : Convert.ToString(dt.Rows[0]["M_mobile"]);
                    M_bank = Convert.IsDBNull(dt.Rows[0]["M_bank"]) ? "" : Convert.ToString(dt.Rows[0]["M_bank"]);
                    M_card = Convert.IsDBNull(dt.Rows[0]["M_card"]) ? "" : Convert.ToString(dt.Rows[0]["M_card"]);
                    M_QQ = Convert.IsDBNull(dt.Rows[0]["M_QQ"]) ? "" : Convert.ToString(dt.Rows[0]["M_QQ"]);
                    M_email = Convert.IsDBNull(dt.Rows[0]["M_email"]) ? "" : Convert.ToString(dt.Rows[0]["M_email"]);
                    M_photo = Convert.IsDBNull(dt.Rows[0]["M_photo"]) ? "" : Convert.ToString(dt.Rows[0]["M_photo"]);
                    M_addr = Convert.IsDBNull(dt.Rows[0]["M_addr"]) ? "" : Convert.ToString(dt.Rows[0]["M_addr"]);
                    M_zip = Convert.IsDBNull(dt.Rows[0]["M_zip"]) ? "" : Convert.ToString(dt.Rows[0]["M_zip"]);
                    M_BirthDay = Convert.IsDBNull(dt.Rows[0]["M_BirthDay"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["M_BirthDay"]);
                    M_tags = Convert.IsDBNull(dt.Rows[0]["M_tags"]) ? "" : Convert.ToString(dt.Rows[0]["M_tags"]);
                    ip = Convert.IsDBNull(dt.Rows[0]["ip"]) ? "" : Convert.ToString(dt.Rows[0]["ip"]);
                    M_hits = Convert.IsDBNull(dt.Rows[0]["M_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_hits"]);
                    M_isactive = Convert.IsDBNull(dt.Rows[0]["M_isactive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["M_isactive"]);
                    M_isdel = Convert.IsDBNull(dt.Rows[0]["M_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_isdel"]);
                    ParentID = Convert.IsDBNull(dt.Rows[0]["ParentID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ParentID"]);
                    jieshaoID = Convert.IsDBNull(dt.Rows[0]["jieshaoID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["jieshaoID"]);
                    M_leve = Convert.IsDBNull(dt.Rows[0]["M_level"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_level"]);
                    M_star = Convert.IsDBNull(dt.Rows[0]["M_star"]) ? 0 : Convert.ToInt32(dt.Rows[0]["M_star"]);
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);

                    parentName = Convert.IsDBNull(dt.Rows[0]["parentName"]) ? "" : Convert.ToString(dt.Rows[0]["parentName"]);
                    jieshaoName = Convert.IsDBNull(dt.Rows[0]["jieshaoName"]) ? "" : Convert.ToString(dt.Rows[0]["jieshaoName"]);
                    cityName = Convert.IsDBNull(dt.Rows[0]["cityName"]) ? "" : Convert.ToString(dt.Rows[0]["cityName"]);
                    _amt = Convert.IsDBNull(dt.Rows[0]["M_amt"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["M_amt"]);
                    _cent = Convert.IsDBNull(dt.Rows[0]["M_cent"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["M_cent"]);
                    _dongjie = Convert.IsDBNull(dt.Rows[0]["M_dongjie"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["M_dongjie"]);
                    _childs = Convert.IsDBNull(dt.Rows[0]["childs"]) ? 1 : Convert.ToInt32(dt.Rows[0]["childs"]);

                    parentMobile = Convert.IsDBNull(dt.Rows[0]["parentMobile"]) ? "" : Convert.ToString(dt.Rows[0]["parentMobile"]);
                    jieshaoMobile = Convert.IsDBNull(dt.Rows[0]["jieshaoMobile"]) ? "" : Convert.ToString(dt.Rows[0]["jieshaoMobile"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_mem_id：" + id + "不存在");
            }
        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _M_no, int _M_vip, string _M_name, string _M_psw, string _M_psw2, string _M_truename, string _M_IDCard, string _M_sex, string _M_mobile, string _M_bank, string _M_card, string _M_QQ, string _M_photo, string _M_addr, string _M_zip, DateTime _M_BirthDay, string _M_tags, string _ip, int _M_isactive, int _ParentID, int _jieshaoID, int _cityID)
        {
            int _M_level = 0;
            int _child = 0;
            if (_M_no.Trim() == "") //通过取值，来把M_no和M_level一起获取到值
            {
                if (_ParentID != 0 && _ParentID != -1)
                {
                    B2C_mem bc = new B2C_mem(_ParentID);
                    _M_no = bc.M_no;
                    _M_level = bc.M_leve;
                    _child = bc._childs;

                    if (_child < 3) //其下还可以放
                    {
                        _M_no += (_child + 1).ToString();
                        _M_level += 1;
                    }
                    else
                    {
                        _ParentID = -1;
                    }
                }
                if (_ParentID == 0)
                {
                    string _sql = "select count(id) from b2c_mem where parentID=0";
                    DataTable dt = comfun.GetDataTableBySQL(_sql);
                    if (dt.Rows.Count > 0)
                    {
                        _M_no = (Convert.ToInt32(dt.Rows[0][0].ToString().Trim()) + 1).ToString().Trim();
                    }
                    else
                        _M_no = "0001";

                    while (_M_no.Length < 4)
                        _M_no = "0" + _M_no;
                }
                if (_ParentID == -1)
                {
                    string _sql = "select top 1 id from b2c_mem where (select count(id) from b2c_mem as m1 where m1.parentID=b2c_mem.id)<3 order by id";
                    DataTable dt = comfun.GetDataTableBySQL(_sql);
                    if (dt.Rows.Count > 0)
                    {
                        B2C_mem bc = new B2C_mem(Convert.ToInt32(dt.Rows[0][0]));
                        _M_no = bc.M_no;
                        _M_level = bc.M_leve;
                        _child = bc._childs;

                        if (_child < 3) //其下还可以放
                        {
                            _M_no += (_child + 1).ToString();
                            _M_level += 1;
                        }
                    }
                }
            }
            else//还需要获取M_level的值
            {
                if (_ParentID != 0 && _ParentID != -1)
                {
                    B2C_mem bc = new B2C_mem(_ParentID);
                    _M_level = bc.M_leve;
                    _M_level += 1;
                }
                else
                {
                    DataTable dt = comfun.GetDataTableBySQL("select id,M_level from b2c_mem where M_no='" + _M_no.Substring(0, _M_no.Length - 1) + "'");
                    if (dt.Rows.Count > 0)
                    {
                        _M_level = Convert.ToInt32(dt.Rows[0]["M_level"]) + 1;
                        _ParentID = Convert.ToInt32(dt.Rows[0]["id"]);
                    }
                }
            }


            try
            {
                string strSql = "insert into [B2C_mem] ";
                strSql += " ([M_no] ,[M_vip] ,[M_name],[M_psw],[M_psw2] ,[M_truename]";
                strSql += ",[M_IDCard] ,[M_sex] ,[M_mobile] ,[M_bank],[M_card] ,[M_QQ],";
                strSql += "[M_email],[M_photo],[M_addr],[M_zip],[M_tags]";
                strSql += " ,[M_isactive],[ParentID]";
                strSql += ",[jieshaoID],[M_level],[M_star],[cityID])";
                strSql += "values";
                strSql += "(@M_no,@M_vip,@M_name,@M_psw,@M_psw2,@M_truename,@M_IDCard,@M_sex,@M_mobile,";
                strSql += " @M_bank,@M_card,@M_QQ,@M_email,@M_photo,@M_addr,@M_zip,@M_tags,";
                strSql += "@M_isactive,@ParentID,@jieshaoID,@M_level,@M_star,@cityID)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@M_no",_M_no ),
					new SqlParameter("@M_vip", _M_vip),
					new SqlParameter("@M_name", _M_name),
					new SqlParameter("@M_psw", comEncrypt.GetMD5(_M_psw)),
					new SqlParameter("@M_psw2",comEncrypt.GetMD5(_M_psw2)),
					new SqlParameter("@M_truename", _M_truename),
					new SqlParameter("@M_IDCard", _M_IDCard),
					new SqlParameter("@M_sex", _M_sex),
					new SqlParameter("@M_mobile", _M_mobile),
					new SqlParameter("@M_bank", _M_bank),
					new SqlParameter("@M_card", _M_card),
					new SqlParameter("@M_QQ", _M_QQ),
					new SqlParameter("@M_email", M_email),
					new SqlParameter("@M_photo",_M_photo),
					new SqlParameter("@M_addr", _M_addr),
					new SqlParameter("@M_zip", _M_zip),
					new SqlParameter("@M_tags", _M_tags),
					new SqlParameter("@M_isactive",_M_isactive),
					new SqlParameter("@ParentID", _ParentID),
					new SqlParameter("@jieshaoID", _jieshaoID),
					new SqlParameter("@M_level", _M_level),
					new SqlParameter("@M_star","0"),
					new SqlParameter("@cityID",_cityID) 
                };

                comfun con = new comfun();
                con.ExecuteNonQuery(strSql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 修改一条新的记录
        /// </summary>
        private void myUpdate(int _id, string _M_no, int _M_vip, string _M_name, string _M_psw, string _M_psw2, string _M_truename, string _M_IDCard, string _M_sex, string _M_mobile, string _M_bank, string _M_card, string _M_QQ, string _M_photo, string _M_addr, string _M_zip, DateTime _M_BirthDay, string _M_tags, string _ip, int _M_hits, int _M_isactive, int _M_isdel, int _ParentID, int _jieshaoID, int M_level, int M_star, int _cityID)
        {
            try
            {
                string sql = "update B2C_mem set M_no=@M_no,M_vip=@M_vip,M_name=@M_name,M_psw=@M_psw,M_psw2=@M_psw2,M_truename=@M_truename,M_IDCard=@M_IDCard,M_sex=@M_sex,M_mobile=@M_mobile,M_bank=@M_bank,M_card=@M_card,M_QQ=@M_QQ,M_email=@M_email,M_photo=@M_photo,M_addr=@M_addr,M_zip=@M_zip,M_BirthDay=@M_BirthDay,M_tags=@M_tags,ip=@ip,ParentID=@ParentID,jieshaoID=@jieshaoID,M_level=@M_level,M_star=@M_star,cityID=@cityID,m_regtime=getDate() where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@M_no",_M_no ),
					new SqlParameter("@M_vip", _M_vip),
					new SqlParameter("@M_name", _M_name),  
					new SqlParameter("@M_psw", _M_psw.Trim()=="" ? M_psw_old : comEncrypt.GetMD5(_M_psw.Trim())),
					new SqlParameter("@M_psw2",_M_psw2.Trim()=="" ? M_psw2_old :comEncrypt.GetMD5(_M_psw2.Trim())),
					new SqlParameter("@M_truename", _M_truename),
					new SqlParameter("@M_IDCard", _M_IDCard),
					new SqlParameter("@M_sex", _M_sex),
					new SqlParameter("@M_mobile", _M_mobile),
					new SqlParameter("@M_bank", _M_bank),
					new SqlParameter("@M_card", _M_card),
					new SqlParameter("@M_QQ", _M_QQ),
					new SqlParameter("@M_email", M_email),
					new SqlParameter("@M_photo",_M_photo),
					new SqlParameter("@M_addr", _M_addr),
					new SqlParameter("@M_zip", M_zip),
					new SqlParameter("@M_BirthDay", _M_BirthDay),
					new SqlParameter("@M_tags", _M_tags),
                    new SqlParameter("@ip", _ip),
					new SqlParameter("@ParentID", ParentID),
					new SqlParameter("@jieshaoID", jieshaoID),
					new SqlParameter("@M_level", M_level),
					new SqlParameter("@M_star",M_star),
					new SqlParameter("@cityID", cityID),
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
                this.myInsert(M_no, M_vip, M_name, M_psw, M_psw2, M_truename, M_IDCard, M_sex, M_mobile, M_bank, M_card, M_QQ, M_photo, M_addr, M_zip, M_BirthDay, M_tags, ip, M_isactive, ParentID, jieshaoID, cityID);

            }
            else
            {

                this.myUpdate(id, M_no, M_vip, M_name, M_psw, M_psw2, M_truename, M_IDCard, M_sex, M_mobile, M_bank, M_card, M_QQ, M_photo, M_addr, M_zip, M_BirthDay, M_tags, ip, M_hits, M_isactive, M_isdel, ParentID, jieshaoID, M_leve, M_star, cityID);
            }
        }
        /// <summary>
        /// 添加默认方法
        /// </summary>
        public void AddNew()
        {
            id = 0;
            M_no = "";
            M_vip = 1;
            M_name = "";
            M_psw = "";
            M_psw2 = "";
            M_truename = "";
            M_IDCard = "";
            M_sex = "";
            M_mobile = "";
            M_bank = "";
            M_card = "";
            M_QQ = "";
            M_email = "";
            M_photo = "";
            M_addr = "";
            M_zip = "";
            DateTime M_BirthDay = DateTime.Parse("1900-1-1");
            M_tags = "";
            ip = "";
            M_hits = 0;
            M_isactive = 1;
            M_isdel = 0;
            ParentID = 0;
            jieshaoID = 0;
            M_leve = 0;
            M_star = 0;
            cityID = 1;
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
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        public static int setActive2(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_mem set M_isactive=1 where id in ('" + _cid + "')");
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


        public void GetDropListOfmem(DropDownList ddl, string text)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select * from B2C_mem where M_isactive=1 and M_isdel=0");

            DataSet ds = comfun.GetDataSetBySQL(strSql.ToString());

            //执行查询


            ListItem listItem = new ListItem();
            try
            {
                ddl.Items.Clear();
                listItem.Value = "";
                listItem.Text = ds.Tables[0].Rows.Count <= 0 ? "=无数据=" : text;
                listItem.Selected = true;
                ddl.Items.Add(listItem);
                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    listItem = new ListItem();
                    listItem.Text = (dataRow["M_truename"].ToString() + " [" + dataRow["M_name"].ToString() + "]");
                    listItem.Value = dataRow["id"].ToString();
                    ddl.Items.Add(listItem);
                }
            }
            catch
            {
            }
        }





        public static DataTable GetList(string _dzd, string _sql) //
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_mem " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
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
                _where = string.Format("where id not in (select uid from B2C_user_rank)", _wid); //cityID={0} and
                DataTable _dt = B2C_mem.GetList(_sql, _where);
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in _dt.Rows)
                    {
                        int _id = Convert.ToInt32(dr["id"]);
                        //int _cityID = Convert.ToInt32(dr["cityID"]);
                        B2C_rankinfo.OpenCard(_id); //, _cityID
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

       

    }
}
