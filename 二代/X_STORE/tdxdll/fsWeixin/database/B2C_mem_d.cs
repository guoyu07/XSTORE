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
    public class B2C_mem_d
    {
        public int id = 0;
        public int Mid = 0;
        public int pid = 0;
        public string pname = "";
        public string purl = "";
        public string pkey = "";
        public string psecret = "";
        public string wid = "";
        public string wfans = "";
        public DateTime wdate = Convert.ToDateTime("2011-08-01");
        public string Mname = "";
     

        public B2C_mem_d() { }
        public B2C_mem_d(int _id)
        {
            id = _id;
            this.load();
        }
        public B2C_mem_d(int _mid, int _pid)
        {
            this.Mid = _mid;
            this.pid = _pid;
            this.load();
        }

        private void load()
        {
            string sql = "select top 1 *,(select M_name from b2c_mem where b2c_mem.id=b2c_mem_d.mid) as Mname from B2C_mem_d where id=" + id + " order by id desc";
            if(Mid!=0 && pid!=0)
                sql = "select top 1 *,(select M_name from b2c_mem where b2c_mem.id=b2c_mem_d.mid) as Mname from B2C_mem_d where mid=" + Mid + " and pid=" + pid + " order by id desc";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_mem_d_id：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    Mid = Convert.IsDBNull(dt.Rows[0]["Mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Mid"]);
                    Mname = Convert.IsDBNull(dt.Rows[0]["Mname"]) ? "" : Convert.ToString(dt.Rows[0]["Mname"]);
                    pid = Convert.IsDBNull(dt.Rows[0]["pid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["pid"]);
                    pname = Convert.IsDBNull(dt.Rows[0]["pname"]) ? "" : Convert.ToString(dt.Rows[0]["pname"]);
                    purl = Convert.IsDBNull(dt.Rows[0]["purl"]) ? "" : Convert.ToString(dt.Rows[0]["purl"]);
                    pkey = Convert.IsDBNull(dt.Rows[0]["pkey"]) ? "" : Convert.ToString(dt.Rows[0]["pkey"]);
                    psecret = Convert.IsDBNull(dt.Rows[0]["psecret"]) ? "" : Convert.ToString(dt.Rows[0]["psecret"]);
                    wid = Convert.IsDBNull(dt.Rows[0]["wid"]) ? "" : Convert.ToString(dt.Rows[0]["wid"]);
                    wfans =  Convert.IsDBNull(dt.Rows[0]["wfans"]) ? "" : Convert.ToString(dt.Rows[0]["wfans"]);
                    wdate = Convert.IsDBNull(dt.Rows[0]["wdate"]) ? Convert.ToDateTime("2011-08-01") : Convert.ToDateTime(dt.Rows[0]["wdate"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_mem_d_id：" + id + "不存在");
            }
        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _Mid, int _pid, string _pname, string _purl,string _pkey,string _psecret,string _wid,string _wfans)
        {
            try
            {
                string sql = "insert into B2C_mem_d (Mid,pid,pname,purl,pkey,psecret,wid,wfans) values (@Mid,@pid,@pname,@purl,@pkey,@psecret,@wid,@wfans)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@Mid", _Mid),
                    new SqlParameter("@pid", _pid), 
                    new SqlParameter("@pname", _pname), 
                    new SqlParameter("@purl", _purl), 
                    new SqlParameter("@pkey", _pkey), 
                    new SqlParameter("@psecret", _psecret), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@wfans", _wfans)
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
        private void myUpdate(int _id, int _Mid, int _pid, string _pname, string _purl, string _pkey, string _psecret, string _wid, string _wfans)
        {
            string sql = "";
            try
            {
                sql = "update B2C_mem_d set Mid=" + _Mid + ",pid=" + _pid + ",pname=@pname,purl=@purl,pkey=@pkey,psecret=@psecret,wid=@wid,wfans=@wfans where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] {                     
                    new SqlParameter("@pname", _pname), 
                    new SqlParameter("@purl", _purl), 
                    new SqlParameter("@pkey", _pkey), 
                    new SqlParameter("@psecret", _psecret), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@wfans", _wfans)
                   };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message + sql);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary> 
        public static int myDel(int _id)
        {
            string sql = "delete from B2C_mem_d where id=" + _id + "";
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
        /// 删除数据
        /// </summary> 
        public static int myMidDel(int _id)
        {
            string sql = "delete from B2C_mem_d where Mid=" + _id + "";
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
                this.myInsert(Mid, pid, pname, purl,pkey,psecret ,wid,wfans);
            }
            else
            {
                this.myUpdate(id, Mid, pid, pname, purl,pkey,psecret,wid,wfans);
            }
        }
        /// <summary>
        /// 添加默认方法
        /// </summary>
        public void AddNew()
        {
            id = 0;
            Mid = 0;
            pid = 0;
            pname = "";
            purl = "";
            pkey = "";
            psecret = "";
            wid = "";
            wfans = "";
          
        }
        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataTable GetList(int _page,string _dzd,string _sql)
        {
            try
            {
                DataTable dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_mem_d where " + _sql + "");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetList(int _mid)
        {
            DataTable dt = comfun.GetDataTableBySQL("select * from b2c_mem_d where mid=" + _mid + " order by id");

            return dt;
        }
        //public static int UpHp(int _mid,string _hp)
        //{
        //    int isup = 0;
        //    string sql = "update B2C_mem_d set M_photo='" + _hp + "' where mid=(select top 1 mid from B2C_mem_d where mid=" + _mid + " order by id asc)";
        //    try
        //    {
        //        isup = comfun.UpdateBySQL(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new NotSupportedException("头像上传出错啦！");
        //    }
        //    return isup;
        //}
    }
}
