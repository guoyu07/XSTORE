using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_Team
    {

        public int id = 0;
        public int wID = 0; //所属商户
        public string tm_title = "";//团购项目名称
        public int tm_tiaojian = 0;//成团条件限制1
        public int tm_tiaojian2 = 0;//成团条件限制2
        public double tm_price_m = 0;//市场价
        public double tm_price_t = 0;//团购价
        public int tm_AMT_xn = 0; //虚拟购买人数
        public int tm_AMT_min = 0; //最少成团人数
        public int tm_AMT_max = 0; //最多可购买数量
        public double tm_AMT_per = 0;//每人限购数量
        public double tm_AMT_have = 0;//每人限购数量
        public DateTime tm_Bdate = System.DateTime.Now;//开始时间
        public DateTime tm_Edate = System.DateTime.Now.AddDays(1);//结束时间     
        public DateTime tm_Qdate = System.DateTime.Now.AddDays(1);//券有效期
        public string tm_des = "";//简介
        public string tm_tip = "";//提示
        public string tm_Gname = "";//品名
        public string tm_gif = "";//图片1地址
        public string tm_gif2 = "";//图片2地址
        public string tm_gif3 = "";//图片3地址
        public string tm_flv = "";//视频地址
        public string tm_msg = "";//本单详情
        public string tm_dp = "";//网友点评
        public string tm_tg = "";//推广辞
        /// <summary>
        /// //////////////////////////////////
        /// </summary>
        public int tm_isactive = 1;//启动/停止  
        public int tm_isdel = 0;//是否删除      
        public int tm_isHead = 0;//是否首页推荐
        public int tm_isCHead = 0;//是否类别推荐
        public int tm_sort = 99;//同类排序
        public int tm_hits = 0;//点击次数ID
        public DateTime regdate = System.DateTime.Now;//录入时间
        //public int cityID = 1;//城市ID

        public B2C_Team() { }
        public B2C_Team(int _id)
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
            string _sql = "select * from B2C_Team where 1=1";
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
                throw (new Exception("B2C_Team取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_Team没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                wID = Convert.IsDBNull(dr["wID"]) ? 0 : Convert.ToInt32(dr["wID"]);
                tm_title = Convert.IsDBNull(dr["tm_title"]) ? "" : Convert.ToString(dr["tm_title"]);
                tm_tiaojian = Convert.IsDBNull(dr["tm_tiaojian"]) ? 0 : Convert.ToInt32(dr["tm_tiaojian"]);
                tm_tiaojian2 = Convert.IsDBNull(dr["tm_tiaojian2"]) ? 0 : Convert.ToInt32(dr["tm_tiaojian2"]);
                tm_price_m = Convert.IsDBNull(dr["tm_price_m"]) ? 0 : Convert.ToDouble(dr["tm_price_m"]);
                tm_price_t = Convert.IsDBNull(dr["tm_price_t"]) ? 0 : Convert.ToDouble(dr["tm_price_t"]);
                tm_AMT_xn = Convert.IsDBNull(dr["tm_AMT_xn"]) ? 0 : Convert.ToInt32(dr["tm_AMT_xn"]);
                tm_AMT_min = Convert.IsDBNull(dr["tm_AMT_min"]) ? 0 : Convert.ToInt32(dr["tm_AMT_min"]);
                tm_AMT_max = Convert.IsDBNull(dr["tm_AMT_max"]) ? 0 : Convert.ToInt32(dr["tm_AMT_max"]);
                tm_AMT_per = Convert.IsDBNull(dr["tm_AMT_per"]) ? 0 : Convert.ToDouble(dr["tm_AMT_per"]);
                tm_AMT_have = Convert.IsDBNull(dr["tm_AMT_have"]) ? 0 : Convert.ToDouble(dr["tm_AMT_have"]);
                tm_Bdate = Convert.IsDBNull(dr["tm_Bdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["tm_Bdate"]);
                tm_Edate = Convert.IsDBNull(dr["tm_Edate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["tm_Edate"]);
                tm_Qdate = Convert.IsDBNull(dr["tm_Qdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["tm_Qdate"]);


                tm_des = Convert.IsDBNull(dr["tm_des"]) ? "" : Convert.ToString(dr["tm_des"]);
                tm_tip = Convert.IsDBNull(dr["tm_tip"]) ? "" : Convert.ToString(dr["tm_tip"]);
                tm_Gname = Convert.IsDBNull(dr["tm_Gname"]) ? "" : Convert.ToString(dr["tm_Gname"]);
                tm_gif = Convert.IsDBNull(dr["tm_gif"]) ? "" : Convert.ToString(dr["tm_gif"]);
                tm_gif2 = Convert.IsDBNull(dr["tm_gif2"]) ? "" : Convert.ToString(dr["tm_gif2"]);
                tm_gif3 = Convert.IsDBNull(dr["tm_gif3"]) ? "" : Convert.ToString(dr["tm_gif3"]);
                tm_flv = Convert.IsDBNull(dr["tm_flv"]) ? "" : Convert.ToString(dr["tm_flv"]);
                tm_msg = Convert.IsDBNull(dr["tm_msg"]) ? "" : Convert.ToString(dr["tm_msg"]);
                tm_dp = Convert.IsDBNull(dr["tm_dp"]) ? "" : Convert.ToString(dr["tm_dp"]);
                tm_tg = Convert.IsDBNull(dr["tm_tg"]) ? "" : Convert.ToString(dr["tm_tg"]);

                tm_isactive = Convert.IsDBNull(dr["tm_isactive"]) ? 1 : Convert.ToInt32(dr["tm_isactive"]);
                tm_isdel = Convert.IsDBNull(dr["tm_isdel"]) ? 0 : Convert.ToInt32(dr["tm_isdel"]);
                tm_isHead = Convert.IsDBNull(dr["tm_isHead"]) ? 0 : Convert.ToInt32(dr["tm_isHead"]);
                tm_isCHead = Convert.IsDBNull(dr["tm_isCHead"]) ? 0 : Convert.ToInt32(dr["tm_isCHead"]);
                tm_sort = Convert.IsDBNull(dr["tm_sort"]) ? 0 : Convert.ToInt32(dr["tm_sort"]);
                tm_hits = Convert.IsDBNull(dr["tm_hits"]) ? 0 : Convert.ToInt32(dr["tm_hits"]);
                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);
                //cityID = Convert.IsDBNull(dr["cityID"]) ? 0 : Convert.ToInt32(dr["cityID"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(int _wID, string _tm_title, int _tm_tiaojian, int _tm_tiaojian2, double _tm_price_m, double _tm_price_t, int _tm_AMT_xn, int _tm_AMT_min, int _tm_AMT_max, double _tm_AMT_per, double _tm_AMT_have, DateTime _tm_Bdate, DateTime _tm_Edate, DateTime _tm_Qdate, string _tm_des, string _tm_tip, string _tm_Gname, string _tm_gif, string _tm_gif2, string _tm_gif3, string _tm_flv, string _tm_msg, string _tm_dp, string _tm_tg)
        {
            string sql = "insert into B2C_Team (wID,tm_title,tm_tiaojian,tm_tiaojian2,tm_price_m,tm_price_t,tm_AMT_xn,tm_AMT_min,tm_AMT_max,tm_AMT_per,tm_AMT_have,tm_Bdate,tm_Edate,tm_Qdate,tm_des,tm_tip,tm_Gname,tm_gif,tm_gif2,tm_gif3,tm_flv,tm_msg,tm_dp,tm_tg)";
            sql += "values (@wID,@tm_title,@tm_tiaojian,@tm_tiaojian2,@tm_price_m,@tm_price_t,@tm_AMT_xn,@tm_AMT_min,@tm_AMT_max,@tm_AMT_per,@tm_AMT_have,@tm_Bdate,@tm_Edate,@tm_Qdate,@tm_des,@tm_tip,@tm_Gname,@tm_gif,@tm_gif2,@tm_gif3,@tm_flv,@tm_msg,@tm_dp,@tm_tg)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wID", _wID), 
                    new SqlParameter("@tm_title", _tm_title),
                    new SqlParameter("@tm_tiaojian", _tm_tiaojian),
                    new SqlParameter("@tm_tiaojian2", _tm_tiaojian2), 
                    new SqlParameter("@tm_price_m", _tm_price_m), 
                    new SqlParameter("@tm_price_t", _tm_price_t), 
                    new SqlParameter("@tm_AMT_xn", _tm_AMT_xn), 
                    new SqlParameter("@tm_AMT_min", _tm_AMT_min), 
                    new SqlParameter("@tm_AMT_max", _tm_AMT_max), 
                    new SqlParameter("@tm_AMT_per", _tm_AMT_per), 
                    new SqlParameter("@tm_AMT_have", _tm_AMT_have), 
                    new SqlParameter("@tm_Bdate", _tm_Bdate), 
                    new SqlParameter("@tm_Edate", _tm_Edate), 
                    new SqlParameter("@tm_Qdate", _tm_Qdate), 
                    new SqlParameter("@tm_des", _tm_des), 
                    new SqlParameter("@tm_tip", _tm_tip), 
                    new SqlParameter("@tm_Gname", _tm_Gname), 
                    new SqlParameter("@tm_gif", _tm_gif), 
                    new SqlParameter("@tm_gif2", _tm_gif2), 
                    new SqlParameter("@tm_gif3", _tm_gif3), 
                    new SqlParameter("@tm_flv", _tm_flv), 
                    new SqlParameter("@tm_msg", _tm_msg), 
                    new SqlParameter("@tm_dp", _tm_dp),
                    new SqlParameter("@tm_tg", _tm_tg)};

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
        private void myUpdateMethod(int _id, int _wID, string _tm_title, int _tm_tiaojian, int _tm_tiaojian2, double _tm_price_m, double _tm_price_t, int _tm_AMT_xn, int _tm_AMT_min, int _tm_AMT_max, double _tm_AMT_per, double _tm_AMT_have, DateTime _tm_Bdate, DateTime _tm_Edate, DateTime _tm_Qdate, string _tm_des, string _tm_tip, string _tm_Gname, string _tm_gif, string _tm_gif2, string _tm_gif3, string _tm_flv, string _tm_msg, string _tm_dp, string _tm_tg)
        {
            string sql = "update B2C_Team set wID=@wID,tm_title=@tm_title,tm_tiaojian=@tm_tiaojian,tm_tiaojian2=@tm_tiaojian2,tm_price_m=@tm_price_m,tm_price_t=@tm_price_t,tm_AMT_xn=@tm_AMT_xn,tm_AMT_min=@tm_AMT_min,tm_AMT_max=@tm_AMT_max,tm_AMT_per=@tm_AMT_per,tm_AMT_have=@tm_AMT_have,tm_Bdate=@tm_Bdate,tm_Edate=@tm_Edate,tm_Qdate=@tm_Qdate,tm_des=@tm_des,tm_tip=@tm_tip,tm_Gname=@tm_Gname,tm_gif=@tm_gif,tm_gif2=@tm_gif2,tm_gif3=@tm_gif3,tm_flv=@tm_flv,tm_msg=@tm_msg,tm_dp=@tm_dp,tm_tg=@tm_tg where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@id", _id), 
                    new SqlParameter("@wID", _wID), 
                    new SqlParameter("@tm_title", _tm_title),
                    new SqlParameter("@tm_tiaojian", _tm_tiaojian),
                    new SqlParameter("@tm_tiaojian2", _tm_tiaojian2), 
                    new SqlParameter("@tm_price_m", _tm_price_m), 
                    new SqlParameter("@tm_price_t", _tm_price_t), 
                    new SqlParameter("@tm_AMT_xn", _tm_AMT_xn), 
                    new SqlParameter("@tm_AMT_min", _tm_AMT_min), 
                    new SqlParameter("@tm_AMT_max", _tm_AMT_max), 
                    new SqlParameter("@tm_AMT_per", _tm_AMT_per), 
                    new SqlParameter("@tm_AMT_have", _tm_AMT_have), 
                    new SqlParameter("@tm_Bdate", _tm_Bdate), 
                    new SqlParameter("@tm_Edate", _tm_Edate), 
                    new SqlParameter("@tm_Qdate", _tm_Qdate), 
                    new SqlParameter("@tm_des", _tm_des), 
                    new SqlParameter("@tm_tip", _tm_tip), 
                    new SqlParameter("@tm_Gname", _tm_Gname), 
                    new SqlParameter("@tm_gif", _tm_gif), 
                    new SqlParameter("@tm_gif2", _tm_gif2), 
                    new SqlParameter("@tm_gif3", _tm_gif3), 
                    new SqlParameter("@tm_flv", _tm_flv), 
                    new SqlParameter("@tm_msg", _tm_msg), 
                    new SqlParameter("@tm_dp", _tm_dp),
                    new SqlParameter("@tm_tg", _tm_tg)};

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
            tm_title = "";//团购项目名称
            tm_tiaojian = 0;//成团条件限制1
            tm_tiaojian2 = 0;//成团条件限制2
            tm_price_m = 0;//市场价
            tm_price_t = 0;//团购价
            tm_AMT_xn = 0; //虚拟购买人数
            tm_AMT_min = 0; //最少成团人数
            tm_AMT_max = 0; //最多可购买数量
            tm_AMT_per = 0;//每人限购数量
            tm_AMT_have = 0;//每人限购数量
            tm_Bdate = System.DateTime.Now;//开始时间
            tm_Edate = System.DateTime.Now.AddDays(1);//结束时间     
            tm_Qdate = System.DateTime.Now.AddDays(1);//券有效期
            tm_des = "";//简介
            tm_tip = "";//提示
            tm_Gname = "";//品名
            tm_gif = "";//图片1地址
            tm_gif2 = "";//图片2地址
            tm_gif3 = "";//图片3地址
            tm_flv = "";//视频地址
            tm_msg = "";//本单详情
            tm_dp = "";//网友点评
            tm_tg = "";//推广辞
            tm_isactive = 1;//启动/停止  
            tm_isdel = 0;//是否删除      
            tm_isHead = 0;//是否首页推荐
            tm_isCHead = 0;//是否类别推荐
            tm_sort = 99;//同类排序
            tm_hits = 0;//点击次数ID
            regdate = System.DateTime.Now;//录入时间
            //cityID = 1;//城市ID
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.wID, this.tm_title, this.tm_tiaojian, this.tm_tiaojian2, this.tm_price_m, this.tm_price_t, this.tm_AMT_xn, this.tm_AMT_min, this.tm_AMT_max, this.tm_AMT_per, this.tm_AMT_have, this.tm_Bdate, this.tm_Edate, this.tm_Qdate, this.tm_des, this.tm_tip, this.tm_Gname, this.tm_gif, this.tm_gif2, this.tm_gif3, this.tm_flv, this.tm_msg, this.tm_dp, this.tm_tg);
            }
            else
            {
                this.myInsertMethod(this.wID, this.tm_title, this.tm_tiaojian, this.tm_tiaojian2, this.tm_price_m, this.tm_price_t, this.tm_AMT_xn, this.tm_AMT_min, this.tm_AMT_max, this.tm_AMT_per, this.tm_AMT_have, this.tm_Bdate, this.tm_Edate, this.tm_Qdate, this.tm_des, this.tm_tip, this.tm_Gname, this.tm_gif, this.tm_gif2, this.tm_gif3, this.tm_flv, this.tm_msg, this.tm_dp, this.tm_tg);
            }
        }
        //public void Delete()
        //{
        //    if (this.id != 0)
        //        this.myDeleteMethod(this.id);
        //}
        /// <summary>
        /// 更新购买数量
        /// </summary>
        /// <returns></returns>
        public string updateNum(int num)
        {
            string sql = "";
            tm_AMT_have += num;
            sql = string.Format("update B2C_Team set tm_AMT_have={0}where id={1}", tm_AMT_have, this.id);
            return sql;

        }

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

        //#endregion

        //#region "静态方法"
        ///// <summary>
        ///// 一次彻底删除一组用户
        ///// </summary>
        ///// <param name="_ids"></param>
        ///// <returns></returns>
        //public static int delete(string _ids)
        //{
        //    int result = 0;

        //    string sql = "delete from B2C_worker where id in (" + _ids + ")";
        //    try
        //    {
        //        comfun.UpdateBySQL(sql);
        //        result = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = 0;
        //        throw ex;
        //    }
        //    return result;
        //}
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
        //public static DataTable GetList(int currentpage,string _dzd, string _sql)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_worker where " + _sql + "");
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Team where " + _sql + "");
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

        /// <summary>
        /// 删除一条数据
        /// </summary> 
        public static int myDel(int _cid)
        {
            int res = 0;
            string sql = "delete from B2C_Team where wID=" + System.Web.HttpContext.Current.Session["wID"].ToString() + " and id=" + _cid + "";
            try
            {
                comfun.DelbySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}