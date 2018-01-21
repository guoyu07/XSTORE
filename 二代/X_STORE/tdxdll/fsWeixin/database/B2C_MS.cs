using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public  class B2C_MS
    {

        public int id = 0;
        public int wID = 0; //所属商户
        public string ms_title = "";//秒杀项目名称
        public int ms_tiaojian = 0;//成团条件限制
        public double ms_price_m = 0;//市场价
        public double ms_price_t = 0;//团购价
        public int ms_AMT_xn = 0; //虚拟购买人数
        public int ms_AMT_max = 0; //最多可购买数量
        public double ms_AMT_per = 0;//每人限购数量
        public double ms_AMT_have = 0;//每人限购数量
        public DateTime ms_Bdate = System.DateTime.Now;//开始时间
        public DateTime ms_Edate = System.DateTime.Now.AddDays(1);//结束时间     
        public DateTime ms_Qdate = System.DateTime.Now.AddDays(1);//券有效期
        public string ms_des = "";//简介
        public string ms_tip = "";//提示
        public string ms_Gname = "";//品名
        public string ms_gif = "";//图片1地址
        public string ms_gif2 = "";//图片2地址
        public string ms_gif3 = "";//图片3地址
        public string ms_flv = "";//视频地址
        public string ms_msg = "";//本单详情
        public string ms_dp = "";//网友点评
        public string ms_tg = "";//推广辞
        /// <summary>
        /// //////////////////////////////////
        /// </summary>
        public int ms_isactive = 1;//启动/停止  
        public int ms_isdel = 0;//是否删除      
        public int ms_isHead = 0;//是否首页推荐
        public int ms_isCHead = 0;//是否类别推荐
        public int ms_sort = 99;//同类排序
        public int ms_hits = 0;//点击次数ID
        public DateTime regdate = System.DateTime.Now;//录入时间
        public int cityID = 1;//城市ID
        public B2C_MS() { }
        public B2C_MS(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        //public B2C_worker(string _uname)
        //{
        //    this.M_name = _uname;
        //    this.id = 0;
        //    this.LoadData();
        //}

        //#region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select * from B2C_MS where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 1)
            {
                throw (new Exception("B2C_MS取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_MS没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                wID = Convert.IsDBNull(dr["wID"]) ? 0 : Convert.ToInt32(dr["wID"]);
                ms_title = Convert.IsDBNull(dr["ms_title"]) ? "" : Convert.ToString(dr["ms_title"]);
                ms_tiaojian = Convert.IsDBNull(dr["ms_tiaojian"]) ? 0 : Convert.ToInt32(dr["ms_tiaojian"]);
                ms_price_m = Convert.IsDBNull(dr["ms_price_m"]) ? 0 : Convert.ToDouble(dr["ms_price_m"]);
                ms_price_t = Convert.IsDBNull(dr["ms_price_t"]) ? 0 : Convert.ToDouble(dr["ms_price_t"]);
                ms_AMT_xn = Convert.IsDBNull(dr["ms_AMT_xn"]) ? 0 : Convert.ToInt32(dr["ms_AMT_xn"]);
                ms_AMT_max = Convert.IsDBNull(dr["ms_AMT_max"]) ? 0 : Convert.ToInt32(dr["ms_AMT_max"]);
                ms_AMT_per = Convert.IsDBNull(dr["ms_AMT_per"]) ? 0 : Convert.ToDouble(dr["ms_AMT_per"]);
                ms_AMT_have = Convert.IsDBNull(dr["ms_AMT_have"]) ? 0 : Convert.ToDouble(dr["ms_AMT_have"]);
                ms_Bdate = Convert.IsDBNull(dr["ms_Bdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["ms_Bdate"]);
                ms_Edate = Convert.IsDBNull(dr["ms_Edate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["ms_Edate"]);
                ms_Qdate = Convert.IsDBNull(dr["ms_Qdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["ms_Qdate"]);


                ms_des = Convert.IsDBNull(dr["ms_des"]) ? "" : Convert.ToString(dr["ms_des"]);
                ms_tip = Convert.IsDBNull(dr["ms_tip"]) ? "" : Convert.ToString(dr["ms_tip"]);
                ms_Gname = Convert.IsDBNull(dr["ms_Gname"]) ? "" : Convert.ToString(dr["ms_Gname"]);
                ms_gif = Convert.IsDBNull(dr["ms_gif"]) ? "" : Convert.ToString(dr["ms_gif"]);
                ms_gif2 = Convert.IsDBNull(dr["ms_gif2"]) ? "" : Convert.ToString(dr["ms_gif2"]);
                ms_gif3 = Convert.IsDBNull(dr["ms_gif3"]) ? "" : Convert.ToString(dr["ms_gif3"]);
                ms_flv = Convert.IsDBNull(dr["ms_flv"]) ? "" : Convert.ToString(dr["ms_flv"]);
                ms_msg = Convert.IsDBNull(dr["ms_msg"]) ? "" : Convert.ToString(dr["ms_msg"]);
                ms_dp = Convert.IsDBNull(dr["ms_dp"]) ? "" : Convert.ToString(dr["ms_dp"]);
                ms_tg = Convert.IsDBNull(dr["ms_tg"]) ? "" : Convert.ToString(dr["ms_tg"]);

                ms_isactive = Convert.IsDBNull(dr["ms_isactive"]) ? 1 : Convert.ToInt32(dr["ms_isactive"]);
                ms_isdel = Convert.IsDBNull(dr["ms_isdel"]) ? 0 : Convert.ToInt32(dr["ms_isdel"]);
                ms_isHead = Convert.IsDBNull(dr["ms_isHead"]) ? 0 : Convert.ToInt32(dr["ms_isHead"]);
                ms_isCHead = Convert.IsDBNull(dr["ms_isCHead"]) ? 0 : Convert.ToInt32(dr["ms_isCHead"]);
                ms_sort = Convert.IsDBNull(dr["ms_sort"]) ? 0 : Convert.ToInt32(dr["ms_sort"]);
                ms_hits = Convert.IsDBNull(dr["ms_hits"]) ? 0 : Convert.ToInt32(dr["ms_hits"]);
                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);
                cityID = Convert.IsDBNull(dr["cityID"]) ? 0 : Convert.ToInt32(dr["cityID"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(int _wID, string _ms_title, int _ms_tiaojian,double _ms_price_m, double _ms_price_t, int _ms_AMT_xn, int _ms_AMT_max, double _ms_AMT_per, double _ms_AMT_have, DateTime _ms_Bdate, DateTime _ms_Edate, DateTime _ms_Qdate, string _ms_des, string _ms_tip, string _ms_Gname, string _ms_gif, string _ms_gif2, string _ms_gif3, string _ms_flv, string _ms_msg, string _ms_dp, string _ms_tg)
        {
            string sql = "insert into B2C_MS (wID,ms_title,ms_tiaojian,ms_price_m,ms_price_t,ms_AMT_xn,ms_AMT_max,ms_AMT_per,ms_AMT_have,ms_Bdate,ms_Edate,ms_Qdate,ms_des,ms_tip,ms_Gname,ms_gif,ms_gif2,ms_gif3,ms_flv,ms_msg,ms_dp,ms_tg)";
            sql += "values (@wID,@ms_title,@ms_tiaojian,@ms_price_m,@ms_price_t,@ms_AMT_xn,@ms_AMT_max,@ms_AMT_per,@ms_AMT_have,@ms_Bdate,@ms_Edate,@ms_Qdate,@ms_des,@ms_tip,@ms_Gname,@ms_gif,@ms_gif2,@ms_gif3,@ms_flv,@ms_msg,@ms_dp,@ms_tg)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wID", _wID), 
                    new SqlParameter("@ms_title", _ms_title),
                    new SqlParameter("@ms_tiaojian", _ms_tiaojian),
                    new SqlParameter("@ms_price_m", _ms_price_m), 
                    new SqlParameter("@ms_price_t", _ms_price_t), 
                    new SqlParameter("@ms_AMT_xn", _ms_AMT_xn), 
                    new SqlParameter("@ms_AMT_max", _ms_AMT_max), 
                    new SqlParameter("@ms_AMT_per", _ms_AMT_per), 
                    new SqlParameter("@ms_AMT_have", _ms_AMT_have), 
                    new SqlParameter("@ms_Bdate", _ms_Bdate), 
                    new SqlParameter("@ms_Edate", _ms_Edate), 
                    new SqlParameter("@ms_Qdate", _ms_Qdate), 
                    new SqlParameter("@ms_des", _ms_des), 
                    new SqlParameter("@ms_tip", _ms_tip), 
                    new SqlParameter("@ms_Gname", _ms_Gname), 
                    new SqlParameter("@ms_gif", _ms_gif), 
                    new SqlParameter("@ms_gif2", _ms_gif2), 
                    new SqlParameter("@ms_gif3", _ms_gif3), 
                    new SqlParameter("@ms_flv", _ms_flv), 
                    new SqlParameter("@ms_msg", _ms_msg), 
                    new SqlParameter("@ms_dp", _ms_dp),
                    new SqlParameter("@ms_tg", _ms_tg)};

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="_typeid"></param>
        /// <param name="_ac_title"></param>
        /// <param name="_ac_des"></param>
        /// <param name="_ac_dj_info"></param>
        /// <param name="_ac_end_title"></param>
        /// <param name="_ac_jp_one"></param>
        /// <param name="_ac_bdate"></param>
        /// <param name="_ac_edate"></param>
        /// <param name="_wid"></param>
        /// <param name="_ac_jp_two"></param>
        /// <param name="_ac_jp_three"></param>
        /// <param name="_ac_b_gif"></param>
        /// <param name="_ac_zj_info"></param>
        /// <param name="_ac_end_des"></param>
        /// <param name="_ac_e_gif"></param>
        /// <param name="_ac_cf_info"></param>
        /// <param name="_ac_totlenum"></param>
        /// <param name="_ac_men_num"></param>
        /// <param name="_ac_jp_one_num"></param>
        /// <param name="_ac_jp_two_num"></param>
        /// <param name="_ac_jp_three_num"></param>
        /// <param name="_hits"></param>
        /// <param name="_views"></param>
        private void myUpdateMethod(int _id, int _wID, string _ms_title, int _ms_tiaojian, double _ms_price_m, double _ms_price_t, int _ms_AMT_xn,  int _ms_AMT_max, double _ms_AMT_per, double _ms_AMT_have, DateTime _ms_Bdate, DateTime _ms_Edate, DateTime _ms_Qdate, string _ms_des, string _ms_tip, string _ms_Gname, string _ms_gif, string _ms_gif2, string _ms_gif3, string _ms_flv, string _ms_msg, string _ms_dp, string _ms_tg)
        {
            string sql = "update B2C_MS set wID=@wID,ms_title=@ms_title,ms_tiaojian=@ms_tiaojian,ms_price_m=@ms_price_m,ms_price_t=@ms_price_t,ms_AMT_xn=@ms_AMT_xn,ms_AMT_max=@ms_AMT_max,ms_AMT_per=@ms_AMT_per,ms_AMT_have=@ms_AMT_have,ms_Bdate=@ms_Bdate,ms_Edate=@ms_Edate,ms_Qdate=@ms_Qdate,ms_des=@ms_des,ms_tip=@ms_tip,ms_Gname=@ms_Gname,ms_gif=@ms_gif,ms_gif2=@ms_gif2,ms_gif3=@ms_gif3,ms_flv=@ms_flv,ms_msg=@ms_msg,ms_dp=@ms_dp,ms_tg=@ms_tg where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@id", _id), 
                    new SqlParameter("@wID", _wID), 
                    new SqlParameter("@ms_title", _ms_title),
                    new SqlParameter("@ms_tiaojian", _ms_tiaojian),
                    new SqlParameter("@ms_price_m", _ms_price_m), 
                    new SqlParameter("@ms_price_t", _ms_price_t), 
                    new SqlParameter("@ms_AMT_xn", _ms_AMT_xn), 
                    new SqlParameter("@ms_AMT_max", _ms_AMT_max), 
                    new SqlParameter("@ms_AMT_per", _ms_AMT_per), 
                    new SqlParameter("@ms_AMT_have", _ms_AMT_have), 
                    new SqlParameter("@ms_Bdate", _ms_Bdate), 
                    new SqlParameter("@ms_Edate", _ms_Edate), 
                    new SqlParameter("@ms_Qdate", _ms_Qdate), 
                    new SqlParameter("@ms_des", _ms_des), 
                    new SqlParameter("@ms_tip", _ms_tip), 
                    new SqlParameter("@ms_Gname", _ms_Gname), 
                    new SqlParameter("@ms_gif", _ms_gif), 
                    new SqlParameter("@ms_gif2", _ms_gif2), 
                    new SqlParameter("@ms_gif3", _ms_gif3), 
                    new SqlParameter("@ms_flv", _ms_flv), 
                    new SqlParameter("@ms_msg", _ms_msg), 
                    new SqlParameter("@ms_dp", _ms_dp),
                    new SqlParameter("@ms_tg", _ms_tg)};

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        //private void myDeleteMethod(int _id)
        //{
        //    if (_id == 0)
        //    {
        //        throw new NotSupportedException("没有取得用户ID号");
        //    }
        //    else
        //    {
        //        string sql = "delete from B2C_worker where id=" + _id;

        //        try
        //        {
        //            comfun.UpdateBySQL(sql);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //    }
        //}
        //#endregion

        //#region "公有方法"
        public void AddNew()
        {
            id = 0;
            wID = 0; //所属商户
            ms_title = "";//团购项目名称
            ms_tiaojian = 0;//成团条件限制1
            ms_price_m = 0;//市场价
            ms_price_t = 0;//团购价
            ms_AMT_xn = 0; //虚拟购买人数
            ms_AMT_max = 0; //最多可购买数量
            ms_AMT_per = 0;//每人限购数量
            ms_AMT_have = 0;//每人限购数量
            ms_Bdate = System.DateTime.Now;//开始时间
            ms_Edate = System.DateTime.Now.AddDays(1);//结束时间     
            ms_Qdate = System.DateTime.Now.AddDays(1);//券有效期
            ms_des = "";//简介
            ms_tip = "";//提示
            ms_Gname = "";//品名
            ms_gif = "";//图片1地址
            ms_gif2 = "";//图片2地址
            ms_gif3 = "";//图片3地址
            ms_flv = "";//视频地址
            ms_msg = "";//本单详情
            ms_dp = "";//网友点评
            ms_tg = "";//推广辞
            ms_isactive = 1;//启动/停止  
            ms_isdel = 0;//是否删除      
            ms_isHead = 0;//是否首页推荐
            ms_isCHead = 0;//是否类别推荐
            ms_sort = 99;//同类排序
            ms_hits = 0;//点击次数ID
            regdate = System.DateTime.Now;//录入时间
            cityID = 1;//城市ID
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.wID, this.ms_title, this.ms_tiaojian, this.ms_price_m, this.ms_price_t, this.ms_AMT_xn,  this.ms_AMT_max, this.ms_AMT_per, this.ms_AMT_have, this.ms_Bdate, this.ms_Edate, this.ms_Qdate, this.ms_des, this.ms_tip, this.ms_Gname, this.ms_gif, this.ms_gif2, this.ms_gif3, this.ms_flv, this.ms_msg, this.ms_dp, this.ms_tg);
            }
            else
            {
                this.myInsertMethod(this.wID, this.ms_title, this.ms_tiaojian, this.ms_price_m, this.ms_price_t, this.ms_AMT_xn,  this.ms_AMT_max, this.ms_AMT_per, this.ms_AMT_have, this.ms_Bdate, this.ms_Edate, this.ms_Qdate, this.ms_des, this.ms_tip, this.ms_Gname, this.ms_gif, this.ms_gif2, this.ms_gif3, this.ms_flv, this.ms_msg, this.ms_dp, this.ms_tg);
            }
        }
        //}
        //public void Delete()
        //{
        //    if (this.id != 0)
        //        this.myDeleteMethod(this.id);
        //}

        //public void updateHits()
        //{
        //    if (this.id != 0)
        //    {
        //        try
        //        {
        //            comfun.UpdateBySQL("update B2C_worker set M_hits=M_hits+1,M_logontime=getDate() where id=" + this.id);
        //        }
        //        finally { }
        //    }
        //}

        //public int checkLogon(string _pswNeed)
        //{
        //    int result = 0;
        //    if (System.DateTime.Now.CompareTo(this.M_Bdate) == 1 && System.DateTime.Now.CompareTo(this.M_Edate) == -1)
        //    {
        //        if (this.id != 0)
        //        {
        //            if (comEncrypt.GetMD5(_pswNeed) != this.M_psw_old)
        //                result = -2; //密码不不正确
        //            else
        //                result = 1;//密码正确，登录成功;
        //        }
        //        else
        //            result = -1;//用户名不存在

        //    }
        //    else
        //        result = -3; //超出使用范围

        //    if (result == 1)
        //    {//如果登录成功,则设置session
        //        string[] uInfo = { this.id.ToString(), this.M_name, this.M_vip.ToString(), this.wx_theme.ToString(),this.wx_ID };
        //        System.Web.HttpContext.Current.Session["wInfo"] = uInfo;
        //        System.Web.HttpContext.Current.Session["wID"] = this.id.ToString();
        //        this.updateHits();
        //    }

        //    return result;

        //}
        //#endregion
        /// <summary>
        /// 更新购买数量
        /// </summary>
        /// <returns></returns>
        public string updateNum(int num)
        {
            string sql = "";
            ms_AMT_have += num;
            sql = string.Format("update B2C_MS set ms_AMT_have={0}where id={1}", ms_AMT_have, this.id);
            return sql;

        }
       
        /// <summary>
        /// 一次彻底删除一组用户
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_MS where id in (" + _ids + ")";
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
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        //public static int setIsActive(string _ids)
        //{
        //    int res = 0;
        //    try
        //    {
        //        res = comfun.UpdateBySQL("update B2C_worker set M_isactive= -1 * (M_isActive - 1) where id in (" + _ids + ")");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return res;
        //}        

        //#endregion

        ///// <summary>
        ///// 此处为条件查询
        ///// </summary>
        //public static DataTable GetList(int currentpage, string _dzd, string _sql)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_MS where " + _sql + "");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}
        /// <summary>
        /// 获取信息列表
        /// </summary>
        /// <param name="_dzd">查询内容</param>
        /// <param name="_sql">查询条件</param>
        /// <returns></returns>
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_MS where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //public static DataTable GetList()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = comfun.GetDataTableBySQL("select * from B2C_worker order id desc");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}

        //public static Boolean Auth()
        //{
        //    if (System.Web.HttpContext.Current.Session["wInfo"] == null)
        //        return false;

        //    string[] _username = (string[])System.Web.HttpContext.Current.Session["wInfo"];
        //    if (_username == null)
        //        return false;
        //    if (_username[0] == null || _username[0].ToString().Trim() == "" || _username[0].ToString() == String.Empty)
        //        return false;

        //    return true;

        //}
    }
}