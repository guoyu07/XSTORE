using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_share
    {
        public int id = 0;
        public int cityID = 0;      //所属商家
        public int t_hits = 0;      //访问次数
        public int t_isactive = 0;    //是否可用
        public int t_ischead = 0;    //获得积分数
        public string t_title = "";//标题
        public string t_msg = "";           //内容
        public string t_gif = "";          //图片路径

        public DateTime t_bdate = DateTime.Now;//开始时间
        public DateTime t_edate = DateTime.Now.AddMonths(1);//结束时间

        public DateTime t_wdate = DateTime.Now;//更新时间
        public DateTime regdate = DateTime.Now;//创建时间

        public B2C_share() { }
        public B2C_share(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_share where 1=1";
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
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                cityID = Convert.IsDBNull(dr["cityID"]) ? 0 : Convert.ToInt32(dr["cityID"]);
                t_hits = Convert.IsDBNull(dr["t_hits"]) ? 0 : Convert.ToInt32(dr["t_hits"]);
                t_isactive = Convert.IsDBNull(dr["t_isactive"]) ? 0 : Convert.ToInt32(dr["t_isactive"]);
                t_ischead = Convert.IsDBNull(dr["t_ischead"]) ? 0 : Convert.ToInt32(dr["t_ischead"]);
                t_title = Convert.IsDBNull(dr["t_title"]) ? "" : Convert.ToString(dr["t_title"]);
                t_msg = Convert.IsDBNull(dr["t_msg"]) ? "" : Convert.ToString(dr["t_msg"]);
                t_gif = Convert.IsDBNull(dr["t_gif"]) ? "" : Convert.ToString(dr["t_gif"]);

                t_bdate = Convert.IsDBNull(dr["t_bdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["t_bdate"]);
                t_edate = Convert.IsDBNull(dr["t_edate"]) ? System.DateTime.Now.AddMonths(1) : Convert.ToDateTime(dr["t_edate"]); 
                t_wdate = Convert.IsDBNull(dr["t_wdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["t_wdate"]);
                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.cityID, this.t_hits, this.t_isactive, this.t_ischead, this.t_title, this.t_msg, this.t_gif, this.t_wdate,this.t_bdate,this.t_edate);
            }
            else
            {
                this.myInsertMethod(this.cityID, this.t_hits, this.t_isactive, this.t_ischead, this.t_title, this.t_msg, this.t_gif, this.t_wdate, this.t_bdate, this.t_edate);
            }
        }
        private void myUpdateMethod(int _id, int _cityID, int _t_hits, int _t_isactive, int _t_ischead, string _t_title, string _t_msg, string _t_gif, DateTime _t_wdate,DateTime _t_bdate,DateTime _t_edate)
        {
            string sql = "update B2C_share set cityID=@cityID,t_hits=@t_hits,t_isactive=@t_isactive,t_ischead=@t_ischead,t_title=@t_title,t_msg=@t_msg,t_gif=@t_gif,t_wdate=@t_wdate,t_bdate=@t_bdate,t_edate=@t_edate  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cityID", _cityID), 
                    new SqlParameter("@t_hits", _t_hits), 
                    new SqlParameter("@t_isactive", _t_isactive), 
                    new SqlParameter("@t_ischead", _t_ischead), 
                    new SqlParameter("@t_title", _t_title), 
                    new SqlParameter("@t_msg", _t_msg), 
                    new SqlParameter("@t_gif", _t_gif), 
                     new SqlParameter("@t_wdate", _t_wdate),                     
                     new SqlParameter("@t_bdate", _t_bdate),
                     new SqlParameter("@t_edate", _t_edate),
                    new SqlParameter("@id",_id)};

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
        private void myInsertMethod(int _cityID, int _t_hits, int _t_isactive, int _t_ischead, string _t_title, string _t_msg, string _t_gif, DateTime _t_wdate, DateTime _t_bdate, DateTime _t_edate)
        {
            string sql = "insert into B2C_share (cityID,t_hits,t_isactive,t_ischead,t_title,t_msg,t_gif,t_wdate,t_bdate,t_edate) values (@cityID,@t_hits,@t_isactive,@t_ischead,@t_title,@t_msg,@t_gif,@t_wdate,@t_bdate,@t_edate)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cityID", _cityID), 
                    new SqlParameter("@t_hits", _t_hits), 
                    new SqlParameter("@t_isactive", _t_isactive), 
                    new SqlParameter("@t_ischead", _t_ischead), 
                    new SqlParameter("@t_title", _t_title), 
                    new SqlParameter("@t_msg", _t_msg), 
                    new SqlParameter("@t_gif", _t_gif),
                     new SqlParameter("@t_wdate", _t_wdate),                     
                     new SqlParameter("@t_bdate", _t_bdate),
                     new SqlParameter("@t_edate", _t_edate),
                    };
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
        public void AddNew()
        {
            id = 0;
            cityID = 0;
            t_hits = 0;
            t_isactive = 0;
            t_ischead = 0;
            t_title = "";
            t_msg = "";
            t_gif = "";
            t_bdate = DateTime.Now;
            t_edate = DateTime.Now.AddMonths(1);
            t_wdate = DateTime.Now;
            regdate = DateTime.Now;
        }
        public static int IsNoactive(string _ids)
        {
            int result = 0;

            string sql = "update B2C_share  set t_isactive=-1 * (t_isactive -1)  where id in (" + _ids + ")";
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

        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_share where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
