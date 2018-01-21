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
    public class B2C_worker_sp
    {
        public int id = 0;
        public int wid = 0;
        public string cno = "";
        public string gids = "";
        public string gu_price = "";
        public int gu_year = 1;
        public double gu_amt = 0.00;
        public int uid = 0;
        public DateTime regtime = System.DateTime.Now;

        public B2C_worker_sp()
        {
        }
        public B2C_worker_sp(int _id)
        {
            this.id = _id;
            this.Load();
        }
        public void AddNew()
        {
            id = 0;
            wid = 0;
            cno = "";
            gids = "";
            gu_price = "";
            gu_amt = 0.00;
            uid = 0;
            regtime = System.DateTime.Now;
        }

        #region "私有方法"
        private void Load()
        {
            string _sql = "select * from B2C_worker_sp where 1=1";
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
                throw (new Exception("B2C_worker_sp取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_worker_sp没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]); 
                gids = Convert.IsDBNull(dr["gids"]) ? "" : Convert.ToString(dr["gids"]);
                gu_price = Convert.IsDBNull(dr["gu_price"]) ? "" : Convert.ToString(dr["gu_price"]);
                gu_year = Convert.IsDBNull(dr["gu_year"]) ? 1 : Convert.ToInt32(dr["gu_year"]); 
                gu_amt = Convert.IsDBNull(dr["gu_amt"]) ? 0.00 : Convert.ToDouble(dr["gu_amt"]); 
                uid = Convert.IsDBNull(dr["uid"]) ? 0 : Convert.ToInt32(dr["uid"]);
                regtime = Convert.IsDBNull(dr["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regtime"]);

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        private void myInsertMethod(int _wid, string _cno, string _gids, string _gu_price,int _gu_year,double _gu_amt, int _uid)
        { 
            string sql = "insert into B2C_worker_sp (wid,cno,gids,gu_price,gu_year,gu_amt,uid)";
            sql += "values (@wid,@cno,@gids,@gu_price,@gu_year,@gu_amt,@uid)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@cno",_cno),
                    new SqlParameter("@gids", _gids),
                    new SqlParameter("@gu_price", _gu_price), 
                    new SqlParameter("@gu_year", _gu_year), 
                    new SqlParameter("@gu_amt", _gu_amt),
                    new SqlParameter("@uid", _uid)
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
        private void myUpdateMethod(int _id, int _wid, string _cno, string _gids, string _gu_price, int _gu_year,double _gu_amt,int _uid)
        {
            string sql = "update B2C_worker_sp set wid=@wid,cno=@cno,gids=@gids,gu_price=@gu_price,gu_year=@gu_year,gu_amt=@gu_amt,uid=@uid where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@cno",_cno),
                    new SqlParameter("@gids", _gids),
                    new SqlParameter("@gu_price", _gu_price), 
                    new SqlParameter("@gu_year", _gu_year), 
                    new SqlParameter("@gu_amt", _gu_amt),
                    new SqlParameter("@uid", _uid), 
                    new SqlParameter("@id", _id)
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
        private void myDeleteMethod(int _id)
        {
            if (_id == 0)
            {
                throw new NotSupportedException("没有取得用户ID号");
            }
            else
            {
                string sql = "delete from B2C_worker_sp where id=" + _id;

                try
                {
                    comfun.UpdateBySQL(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        #endregion

        #region "公共方法"
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id,this.wid,this.cno,this.gids,this.gu_price,this.gu_year,this.gu_amt,this.uid);
            }
            else
            {
                this.myInsertMethod(this.wid, this.cno, this.gids, this.gu_price,this.gu_year, this.gu_amt, this.uid);
            }
        }
        public void Delete()
        {
            if (this.id != 0)
                this.myDeleteMethod(this.id);
        }
        #endregion

        #region "静态方法"
        /// <summary>
        /// 一次彻底删除一组监控
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_work_sp where id in (" + _ids + ")";
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
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(int currentpage, string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from b2c_worker_sp where " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from b2c_worker_sp where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select * from b2c_worker_sp order id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion
         
    }
}
