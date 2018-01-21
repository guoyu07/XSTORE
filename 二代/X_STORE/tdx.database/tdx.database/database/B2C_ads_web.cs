using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Creatrue.kernel;
using System.Data.SqlClient;
using System.Data;

namespace tdx.database.database
{
    public class B2C_ads_web
    {
        public int id = 0;
        public string cno = "";
        public string cname = "";
        public string a_name = "";
        public string a_gif = "";
        public string a_url = "";
        public DateTime a_btime = DateTime.Now;
        public DateTime a_etime = DateTime.Now;
        public int a_sort = 1;
        public string a_des = "";
        public int a_isactive = 1;
        public int a_isdel = 0;
        public DateTime regtime = DateTime.Now;
        public string a_adgif = "";
        public int a_isSys = 0; //是否系统广告
        //public int cityID = 0;      //城市编号

        public B2C_ads_web()
        {
        }
        public B2C_ads_web(int _id)
        {
            id = _id;
            this.loaddata();
        }
        private void loaddata()
        {
            System.Data.DataTable dt = comfun.GetDataTableBySQL("select *,(select c_name from b2c_adclass_web where c_no=cno) as cname from b2c_ads_web where id=" + id);//+ " and (cityid in (select id from wx_mp where wid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + ") or cityID=" + System.Web.HttpContext.Current.Session["wID"].ToString() + ")"
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("b2c_adsID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    cname = Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]);
                    a_name = Convert.IsDBNull(dt.Rows[0]["a_name"]) ? "" : Convert.ToString(dt.Rows[0]["a_name"]);
                    a_gif = Convert.IsDBNull(dt.Rows[0]["a_gif"]) ? "" : Convert.ToString(dt.Rows[0]["a_gif"]);
                    a_url = Convert.IsDBNull(dt.Rows[0]["a_url"]) ? "" : Convert.ToString(dt.Rows[0]["a_url"]);
                    a_btime = Convert.IsDBNull(dt.Rows[0]["a_btime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["a_btime"]);
                    a_etime = Convert.IsDBNull(dt.Rows[0]["a_etime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["a_etime"]);
                    a_sort = Convert.IsDBNull(dt.Rows[0]["a_sort"]) ? 0 : Convert.ToInt32(dt.Rows[0]["a_sort"]);
                    a_des = Convert.IsDBNull(dt.Rows[0]["a_des"]) ? "" : Convert.ToString(dt.Rows[0]["a_des"]);
                    a_isactive = Convert.IsDBNull(dt.Rows[0]["a_isactive"]) ? 0 : Convert.ToInt32(dt.Rows[0]["a_isactive"]);
                    a_isdel = Convert.IsDBNull(dt.Rows[0]["a_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["a_isdel"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                    a_adgif = Convert.IsDBNull(dt.Rows[0]["a_adgif"]) ? "" : Convert.ToString(dt.Rows[0]["a_adgif"]);
                    a_isSys = Convert.IsDBNull(dt.Rows[0]["a_isSys"]) ? 0 : Convert.ToInt32(dt.Rows[0]["a_isSys"]);
                    //cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityID"]);
                }
            }
            else
            {
                throw new NotSupportedException("读取错误!");
            }
        }


        //插入数据库一条记录
        private void myInsertMethod(string _cno, string _a_name, string _a_gif, string _a_url, DateTime _a_btime, DateTime _a_etime, int _a_sort, string _a_des, int _a_isactive, int _a_isdel, DateTime _regtime, string _a_adgif)//,int _cityID
        {
            try
            {
                //注：ID号要进行是否重复验证                                                                                    ,cityID                                                                                                           ,@cityID
                string sql = "insert into b2c_ads_web (cno,a_name,a_gif,a_url,a_btime,a_etime,a_sort,a_des,a_isactive,a_isdel,regtime,a_adgif) values (@cno,@a_name,@a_gif,@a_url,@a_btime,@a_etime,@a_sort,@a_des,@a_isactive,@a_isdel,@regtime,@a_adgif)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@a_name", _a_name), 
                    new SqlParameter("@a_gif", _a_gif),
                    new SqlParameter("@a_url", _a_url),
                    new SqlParameter("@a_btime", _a_btime),
                    new SqlParameter("@a_etime", _a_etime),
                    new SqlParameter("@a_sort", _a_sort),
                    new SqlParameter("@a_des", _a_des),
                    new SqlParameter("@a_isactive", _a_isactive),
                    new SqlParameter("@a_isdel", _a_isdel),
                    new SqlParameter("@regtime", _regtime), 
                    new SqlParameter("@a_adgif", _a_adgif)};//, new SqlParameter("@cityID", _cityID)

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras); ;

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }


        //修改一条记录
        private void myUpdateMethod(int _id, string _cno, string _a_name, string _a_gif, string _a_url, DateTime _a_btime, DateTime _a_etime, int _a_sort, string _a_des, int _a_isactive, int _a_isdel, DateTime _regtime, string _a_adgif)
        {
            try
            {
                string sql = "update b2c_ads_web set cno=@cno,a_name=@a_name,a_gif=@a_gif,a_url=@a_url,a_btime=@a_btime,a_etime=@a_etime,a_sort=@a_sort,a_des=@a_des,a_isactive=@a_isactive,a_isdel=@a_isdel,regtime=@regtime,a_adgif=@a_adgif  where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@a_name", _a_name), 
                    new SqlParameter("@a_gif", _a_gif),
                    new SqlParameter("@a_url", _a_url),
                    new SqlParameter("@a_btime", _a_btime),
                    new SqlParameter("@a_etime", _a_etime),
                    new SqlParameter("@a_sort", _a_sort),
                    new SqlParameter("@a_des", _a_des),
                    new SqlParameter("@a_isactive", _a_isactive),
                    new SqlParameter("@a_isdel", _a_isdel),
                    new SqlParameter("@regtime", _regtime), 
                    new SqlParameter("@a_adgif", _a_adgif)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        //删除一条记录
        public static int myDeleteMethod(int _id)
        {
            try
            {

                return comfun.DelbySQL("delete from b2c_ads_web where id=" + _id);// + " and cityid in (select id from wx_mp where wid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + ")"
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static int myDeleteMethod2(int _id)
        {
            try
            {

                return comfun.DelbySQL("delete from b2c_ads_web where id=" + _id);// + " and cityid in (" + System.Web.HttpContext.Current.Session["wID"].ToString() + ")"
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public void addNew()
        {
            id = 0;
            cno = "";
            cname = "";
            a_name = "";
            a_gif = "";
            a_url = "";
            a_btime = DateTime.Now;
            a_etime = DateTime.Now;
            a_sort = 9;
            a_des = "";
            a_isactive = 1;
            a_isdel = 0;
            regtime = DateTime.Now;
            a_adgif = "";
            a_isSys = 0;
            //cityID = 0; 
        }


        //如果ID==0，表示当前没数据可更新，那么就添加一条新数据
        //否则就更新数据
        public void Update()
        {
            if (id == 0)
            {
                this.myInsertMethod(cno, a_name, a_gif, a_url, a_btime, a_etime, a_sort, a_des, a_isactive, a_isdel, regtime, a_adgif);//,cityID
            }
            else
            {
                this.myUpdateMethod(id, cno, a_name, a_gif, a_url, a_btime, a_etime, a_sort, a_des, a_isactive, a_isdel, regtime, a_adgif);
            }
        }

        public static int setActive(string _ids)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_ads_web set a_isactive= -1 * (a_isactive - 1) where id in ('" + _ids + "')");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static int setIsdel(string _ids)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_ads_web set a_isdel= -1 * (a_isdel - 1) where id in ('" + _ids + "')");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static DataTable getlist(string _dzd, string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from b2c_ads_web where " + sql + " order by a_sort asc");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

