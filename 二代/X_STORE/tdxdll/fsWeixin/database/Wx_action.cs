using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class Wx_action
    {

        public int id = 0;
        public int typeid = 0; //类别
        public string ac_title = "";//活动标题
        public string ac_des = "";//简介
        public string ac_dj_info = "";//兑奖显示信息
        public string ac_end_title = "";//结束显示标题
        public string ac_jp_one = "";//一等奖名称
        public DateTime ac_bdate = System.DateTime.Now;//开始时间
        public DateTime ac_edate = System.DateTime.Now.AddDays(1);//结束时间     
        public DateTime regdate = System.DateTime.Now;//发布时间
        public int wid = 0;//所属会员ID
        public string ac_jp_two = "";//二等奖名称
        public string ac_jp_three = "";//三等奖名称
        public string ac_b_gif = "";//开始图片地址
        public string ac_zj_info = "";//中奖显示信息
        public string ac_end_des = "";//结束显示简介
        public string ac_e_gif = "";//结束图片地址
        public string ac_cf_info = "";//重复信息
        public int ac_totlenum = 0;//预计参加人数
        public int ac_men_num = 0;//每人最大次数
        public int ac_jp_one_num = 0;//一等奖数量  
        public int ac_jp_two_num = 0;//二等奖数量      
        public int ac_jp_three_num = 0;//三等奖数量


        public int hits = 0;//转发次数
        public int views = 0;//浏览次数
        public Wx_action() { }
        public Wx_action(int _id)
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

        #region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select * from Wx_action where 1=1";
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
                throw (new Exception("B2C_worker取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_worker没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                typeid = Convert.IsDBNull(dr["typeid"]) ? 0 : Convert.ToInt32(dr["typeid"]);
                ac_title = Convert.IsDBNull(dr["ac_title"]) ? "" : Convert.ToString(dr["ac_title"]);
                ac_des = Convert.IsDBNull(dr["ac_des"]) ? "" : Convert.ToString(dr["ac_des"]);
                ac_dj_info = Convert.IsDBNull(dr["ac_dj_info"]) ? "" : Convert.ToString(dr["ac_dj_info"]);
                ac_end_title = Convert.IsDBNull(dr["ac_end_title"]) ? "" : Convert.ToString(dr["ac_end_title"]);
                ac_jp_one = Convert.IsDBNull(dr["ac_jp_one"]) ? "" : Convert.ToString(dr["ac_jp_one"]);
                ac_bdate = Convert.IsDBNull(dr["ac_bdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["ac_bdate"]);
                ac_edate = Convert.IsDBNull(dr["ac_edate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["ac_edate"]);
                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);
                ac_jp_two = Convert.IsDBNull(dr["ac_jp_two"]) ? "" : Convert.ToString(dr["ac_jp_two"]);
                ac_jp_three = Convert.IsDBNull(dr["ac_jp_three"]) ? "" : Convert.ToString(dr["ac_jp_three"]);
                ac_b_gif = Convert.IsDBNull(dr["ac_b_gif"]) ? "" : Convert.ToString(dr["ac_b_gif"]);
                ac_zj_info = Convert.IsDBNull(dr["ac_zj_info"]) ? "" : Convert.ToString(dr["ac_zj_info"]);
                ac_end_des = Convert.IsDBNull(dr["ac_end_des"]) ? "" : Convert.ToString(dr["ac_end_des"]);
                ac_e_gif = Convert.IsDBNull(dr["ac_e_gif"]) ? "" : Convert.ToString(dr["ac_e_gif"]);
                ac_cf_info = Convert.IsDBNull(dr["ac_cf_info"]) ? "" : Convert.ToString(dr["ac_cf_info"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                ac_totlenum = Convert.IsDBNull(dr["ac_totlenum"]) ? 0 : Convert.ToInt32(dr["ac_totlenum"]);
                ac_men_num = Convert.IsDBNull(dr["ac_men_num"]) ? 0: Convert.ToInt32(dr["ac_men_num"]);
                ac_jp_one_num = Convert.IsDBNull(dr["ac_jp_one_num"]) ? 0 : Convert.ToInt32(dr["ac_jp_one_num"]);
                ac_jp_two_num = Convert.IsDBNull(dr["ac_jp_two_num"]) ? 0 : Convert.ToInt32(dr["ac_jp_two_num"]);
                ac_jp_three_num = Convert.IsDBNull(dr["ac_jp_three_num"]) ? 0 : Convert.ToInt32(dr["ac_jp_three_num"]);
                hits = Convert.IsDBNull(dr["hits"]) ? 0 : Convert.ToInt32(dr["hits"]);
                views = Convert.IsDBNull(dr["views"]) ? 0 : Convert.ToInt32(dr["views"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(int _typeid, string _ac_title, string _ac_des, string _ac_dj_info, string _ac_end_title, string _ac_jp_one, DateTime _ac_bdate, DateTime _ac_edate, int _wid, string _ac_jp_two, string _ac_jp_three, string _ac_b_gif, string _ac_zj_info, string _ac_end_des, string _ac_e_gif, string _ac_cf_info, int _ac_totlenum, int _ac_men_num, int _ac_jp_one_num, int _ac_jp_two_num,int _ac_jp_three_num,int _hits,int _views)
        {
            //if (!string.IsNullOrEmpty(_M_name) && !string.IsNullOrEmpty(_M_psw))
            //{
            //    M_name = _M_name;
            //    M_psw = _M_psw;
            //}
            //else
            //{
            //    throw new NotSupportedException("请输入用户名和密码");
            //}
            string sql = "insert into Wx_action (typeid,ac_title,ac_des,ac_dj_info,ac_end_title,ac_jp_one,ac_bdate,ac_edate,wid,ac_jp_two,ac_jp_three,ac_b_gif,ac_zj_info,ac_end_des,ac_e_gif,ac_cf_info,ac_totlenum,ac_men_num,ac_jp_one_num,ac_jp_two_num,ac_jp_three_num,hits,views)";
            sql += "values (@typeid,@ac_title,@ac_des,@ac_dj_info,@ac_end_title,@ac_jp_one,@ac_bdate,@ac_edate,@wid,@ac_jp_two,@ac_jp_three,@ac_b_gif,@ac_zj_info,@ac_end_des,@ac_e_gif,@ac_cf_info,@ac_totlenum,@ac_men_num,@ac_jp_one_num,@ac_jp_two_num,@ac_jp_three_num,@hits,@views)"; 
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@typeid", _typeid), 
                    new SqlParameter("@ac_title", _ac_title),
                    new SqlParameter("@ac_des", _ac_des),
                    new SqlParameter("@ac_dj_info", _ac_dj_info), 
                    new SqlParameter("@ac_end_title", _ac_end_title), 
                    new SqlParameter("@ac_jp_one", _ac_jp_one), 
                    new SqlParameter("@ac_bdate", _ac_bdate), 
                    new SqlParameter("@ac_edate", _ac_edate), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@ac_jp_two", _ac_jp_two), 
                    new SqlParameter("@ac_jp_three", _ac_jp_three), 
                    new SqlParameter("@ac_b_gif", _ac_b_gif), 
                    new SqlParameter("@ac_zj_info", _ac_zj_info), 
                    new SqlParameter("@ac_end_des", _ac_end_des), 
                    new SqlParameter("@ac_e_gif", _ac_e_gif), 
                    new SqlParameter("@ac_cf_info", _ac_cf_info), 
                    new SqlParameter("@ac_totlenum", _ac_totlenum), 
                    new SqlParameter("@ac_men_num", _ac_men_num), 
                    new SqlParameter("@ac_jp_one_num", _ac_jp_one_num), 
                    new SqlParameter("@ac_jp_two_num", _ac_jp_two_num), 
                    new SqlParameter("@ac_jp_three_num", _ac_jp_three_num), 
                    new SqlParameter("@hits", _hits), 
                    new SqlParameter("@views", _views)};

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
        private void myUpdateMethod(int _id,int _typeid, string _ac_title, string _ac_des, string _ac_dj_info, string _ac_end_title, string _ac_jp_one, DateTime _ac_bdate, DateTime _ac_edate, int _wid, string _ac_jp_two, string _ac_jp_three, string _ac_b_gif, string _ac_zj_info, string _ac_end_des, string _ac_e_gif, string _ac_cf_info, int _ac_totlenum, int _ac_men_num, int _ac_jp_one_num, int _ac_jp_two_num, int _ac_jp_three_num, int _hits, int _views)
        {
            string sql = "update Wx_action set typeid=@typeid,ac_title=@ac_title,ac_des=@ac_des,ac_dj_info=@ac_dj_info,ac_end_title=@ac_end_title,ac_jp_one=@ac_jp_one,ac_bdate=@ac_bdate,ac_edate=@ac_edate,wid=@wid,ac_jp_two=@ac_jp_two,ac_jp_three=@ac_jp_three,ac_b_gif=@ac_b_gif,ac_zj_info=@ac_zj_info,ac_end_des=@ac_end_des,ac_e_gif=@ac_e_gif,ac_cf_info=@ac_cf_info,ac_totlenum=@ac_totlenum,ac_men_num=@ac_men_num,ac_jp_one_num=@ac_jp_one_num,ac_jp_two_num=@ac_jp_two_num,ac_jp_three_num=@ac_jp_three_num,hits=@hits,views=@views where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@typeid", _typeid), 
                    new SqlParameter("@ac_title",_ac_title ),
                    new SqlParameter("@ac_des", _ac_des),
                    new SqlParameter("@ac_dj_info", _ac_dj_info), 
                    new SqlParameter("@ac_end_title", _ac_end_title), 
                    new SqlParameter("@ac_jp_one", _ac_jp_one), 
                    new SqlParameter("@ac_bdate", _ac_bdate), 
                    new SqlParameter("@ac_edate", _ac_edate), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@ac_jp_two", _ac_jp_two), 
                    new SqlParameter("@ac_jp_three", _ac_jp_three), 
                    new SqlParameter("@ac_b_gif", _ac_b_gif), 
                    new SqlParameter("@ac_zj_info", _ac_zj_info), 
                    new SqlParameter("@ac_end_des", _ac_end_des), 
                    new SqlParameter("@ac_e_gif", _ac_e_gif),
                    new SqlParameter("@id",_id), 
                    new SqlParameter("@ac_cf_info", _ac_cf_info), 
                    new SqlParameter("@ac_totlenum", _ac_totlenum), 
                    new SqlParameter("@ac_men_num", _ac_men_num), 
                    new SqlParameter("@ac_jp_one_num", _ac_jp_one_num), 
                    new SqlParameter("@ac_jp_two_num", _ac_jp_two_num), 
                    new SqlParameter("@ac_jp_three_num", _ac_jp_three_num), 
                    new SqlParameter("@hits", _hits),
                    new SqlParameter("@views", _views)};

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
        #endregion

        #region "公有方法"
        public void AddNew()
        {
            id = 0;
            typeid = 0;
            ac_title = "";
            ac_des = "";
            ac_dj_info = "";
            ac_end_title = "";
            ac_jp_one = "";
            ac_bdate = DateTime.Now;
            ac_edate = DateTime.Now;
            regdate = DateTime.Now;
            wid = 0;
            ac_jp_two = "";
            ac_jp_three = "";
            ac_b_gif = "";
            ac_zj_info = "";
            ac_end_des = "";
            ac_e_gif = "";
            ac_cf_info = "";
            ac_totlenum = 0;
            ac_men_num = 0;
            ac_jp_one_num = 0;
            ac_jp_two_num = 0;
            ac_jp_three_num = 0;
            hits = 0;
            views = 0;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id,this.typeid, this.ac_title, this.ac_des, this.ac_dj_info, this.ac_end_title, this.ac_jp_one, this.ac_bdate, this.ac_edate, this.wid, this.ac_jp_two, this.ac_jp_three, this.ac_b_gif, this.ac_zj_info, this.ac_end_des, this.ac_e_gif, this.ac_cf_info, this.ac_totlenum, this.ac_men_num, this.ac_jp_one_num, this.ac_jp_two_num, this.ac_jp_three_num, this.hits, this.views);
            }
            else
            {
                this.myInsertMethod(this.typeid, this.ac_title, this.ac_des, this.ac_dj_info, this.ac_end_title, this.ac_jp_one, this.ac_bdate, this.ac_edate, this.wid, this.ac_jp_two, this.ac_jp_three, this.ac_b_gif, this.ac_zj_info, this.ac_end_des, this.ac_e_gif, this.ac_cf_info, this.ac_totlenum, this.ac_men_num, this.ac_jp_one_num, this.ac_jp_two_num, this.ac_jp_three_num, this.hits, this.views);
            }
        }
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
        #endregion

        #region "静态方法"
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

        #endregion

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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from Wx_action where " + _sql + "");
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