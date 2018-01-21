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
    public class B2C_orders
    {
        #region 属性
        public int id = 0;          //编号
        public int mid = 0;         //商品编号
        public int wid = 0;
        public string mname = "";   //名称
        public DateTime o_date = DateTime.Now;
        public string o_no = "";   //详细描述
        public string gid = "";

        public string o_Des = "";
        public int o_isdel = 0;
        public int aid = 0;
        public string aname = "";
        public DateTime o_lastDate = DateTime.Now;
        public decimal o_amt = 0;
        public int o_stid = 0;
        public decimal o_st_amt = 0;
        public decimal o_allamt = 0;
        public string stname = "";

        public decimal o_allnum = 0;
        public decimal o_cent = 0;//积分
        #endregion

        #region 构造函数
        public B2C_orders() { }
        public B2C_orders(int id)
        {
            this.id = id;
            this.load();
        }
        public B2C_orders(string _ono)
        {
            o_no = _ono;
            this.load();
        }
        #endregion

        #region SELECT
        public void load()
        {
            string sql = "select *,(select M_name from b2c_mem where id=b2c_orders.mid) as mname,(select st_name from b2c_sendtype where id=b2c_orders.o_stid) as stname,(select a_name from b2c_order_active where id=b2c_orders.aid) as aname,(select sum(od_num) from b2c_order_d where b2c_order_d.ono=b2c_orders.o_no) as o_allnum from B2C_orders where id=" + id + "";
            if (id != 0)
            {
                sql = "select *,(select M_name from b2c_mem where id=b2c_orders.mid) as mname,(select st_name from b2c_sendtype where id=b2c_orders.o_stid) as stname,(select a_name from b2c_order_active where id=b2c_orders.aid) as aname,(select sum(od_num) from b2c_order_d where b2c_order_d.ono=b2c_orders.o_no) as o_allnum  from b2c_orders where id=" + id + "";
            }
            else if (o_no != "")
            {
                sql = "select *,(select M_name from b2c_mem where id=b2c_orders.mid) as mname,(select st_name from b2c_sendtype where id=b2c_orders.o_stid) as stname,(select a_name from b2c_order_active where id=b2c_orders.aid) as aname,(select sum(od_num) from b2c_order_d where b2c_order_d.ono=b2c_orders.o_no) as o_allnum  from b2c_orders where o_no='" + o_no + "'";
            }

            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_orders ID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mid"]);
                    wid = Convert.IsDBNull(dt.Rows[0]["wid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["wid"]);
                    mname = Convert.IsDBNull(dt.Rows[0]["mname"]) ? "" : dt.Rows[0]["mname"].ToString();
                    o_date = Convert.IsDBNull(dt.Rows[0]["o_date"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["o_date"]);
                    o_no = Convert.IsDBNull(dt.Rows[0]["o_no"]) ? "" : Convert.ToString(dt.Rows[0]["o_no"]);
                    gid = Convert.IsDBNull(dt.Rows[0]["gid"]) ? "" : dt.Rows[0]["gid"].ToString();
                    o_Des = Convert.IsDBNull(dt.Rows[0]["o_Des"]) ? "" : dt.Rows[0]["o_Des"].ToString();
                    o_isdel = Convert.IsDBNull(dt.Rows[0]["o_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["o_isdel"]);
                    aid = Convert.IsDBNull(dt.Rows[0]["aid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["aid"]);
                    aname = Convert.IsDBNull(dt.Rows[0]["aname"]) ? "" : Convert.ToString(dt.Rows[0]["aname"]);
                    o_lastDate = Convert.IsDBNull(dt.Rows[0]["o_lastDate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["o_lastDate"]);
                    o_amt = Convert.IsDBNull(dt.Rows[0]["o_amt"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["o_amt"]);
                    o_stid = Convert.IsDBNull(dt.Rows[0]["o_stid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["o_stid"]);
                    stname = Convert.IsDBNull(dt.Rows[0]["stname"]) ? "" : Convert.ToString(dt.Rows[0]["stname"]);
                    o_st_amt = Convert.IsDBNull(dt.Rows[0]["o_st_amt"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["o_st_amt"]);
                    o_allamt = Convert.IsDBNull(dt.Rows[0]["o_allamt"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["o_allamt"]);
                    o_cent = Convert.IsDBNull(dt.Rows[0]["o_cent"]) ? 0 : Convert.ToInt32(dt.Rows[0]["o_cent"]);
                    o_allnum = Convert.IsDBNull(dt.Rows[0]["o_allnum"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["o_allnum"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_orders：" + id + ":" + "不存在");
            }
        }
        #endregion

        #region INSERT
        private void myInsert(int _mid, int _wid, string _gid, string _o_Des, int _o_stid, decimal _o_st_amt, decimal _o_amt, decimal _o_allamt, decimal _o_cent)
        {
            try
            {
                this.o_no = comEncrypt.GetDateRndNumber();
                string sql = "insert into B2C_orders (mid,wid,gid,o_des,o_stid,o_st_amt,o_amt,o_allamt,o_cent,o_no,aid) values (@mid,@wid,@gid,@o_des,@o_stid,@o_st_amt,@o_amt,@o_allamt,@o_cent,@o_no,0)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mid", _mid), 
                     new SqlParameter("@wid", _wid), 
                    new SqlParameter("@gid", _gid), 
                    new SqlParameter("@o_des", _o_Des), 
                    new SqlParameter("@o_stid", _o_stid),  
                    new SqlParameter("@o_st_amt", _o_st_amt), 
                    new SqlParameter("@o_amt", _o_amt), 
                    new SqlParameter("@o_allamt", _o_allamt), 
                    new SqlParameter("@o_cent", _o_cent), 
                    new SqlParameter("@o_no", this.o_no)              
                    };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region UPDATE
        private void myUpdate(string _ono, int _mid, int _wid, string _gid, string _o_Des, int _o_stid, decimal _o_st_amt, decimal _o_amt, decimal _o_allamt, decimal _o_cent)
        {
            if (_ono != "")
            {
                this.o_no = _ono;
            }
            mid = _mid;
            gid = _gid;
            wid = _wid;
            o_Des = _o_Des;
            o_stid = _o_stid;
            o_st_amt = _o_st_amt;
            o_amt = _o_amt;
            o_allamt = _o_allamt;

            o_cent = 0;

            try
            {
                string sql = "update B2C_orders set mid=@mid,wid=@wid,gid=@gid,o_des=@o_des,o_stid=@o_stid,o_st_amt=@o_stamt,o_amt=@o_amt,o_allamt=@o_allamt,o_cent=@o_cent where o_no=" + _ono;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mid", _mid), 
                      new SqlParameter("@wid", _wid),
                    new SqlParameter("@gid", _gid), 
                    new SqlParameter("@o_des", _o_Des), 
                    new SqlParameter("@o_stid", _o_stid),  
                    new SqlParameter("@o_st_amt", _o_st_amt), 
                    new SqlParameter("@o_amt", _o_amt), 
                    new SqlParameter("@o_allamt", _o_allamt),
                    new SqlParameter("@o_cent", _o_cent) 
                    };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region 设置按钮功能
        /// 设置是否删除
        public static int setIsdel(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_orders set g_isdel= -1 * (g_isdel - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion


        #region DELETE
        public static int myDel(int _id)
        {
            int res = 0;
            if (_id == 0)
            {
                throw new NotSupportedException("没有ID号");
            }
            else
            {

                string sql = "delete from B2C_orders where id=" + _id + "";
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
        }
        public static int myDel(string _ono)
        {
            int res = 0;
            if (string.IsNullOrEmpty(_ono))
            {
                throw new NotSupportedException("没有订单号");
            }
            else
            {
                string sql = "delete from B2C_orders where o_no='" + _ono + "'";
                sql += ";delete from b2c_order_d where ono='" + _ono + "'";
                sql += ";delete from b2c_order_addr where ono='" + _ono + "'";
                sql += ";delete from b2c_order_log where ono='" + _ono + "'";
                sql += ";delete from b2c_order_pay where ono='" + _ono + "'";
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
        }
        #endregion

        public void AddNew()
        {
            id = 0;          //编号
            mid = 0;         //商品编号
            mname = "";   //名称
            o_date = DateTime.Now;
            o_no = "";   //详细描述
            gid = "";
            wid = 0;
            o_Des = "";
            o_isdel = 0;
            aid = 0;
            aname = "";
            o_lastDate = DateTime.Now;
            o_amt = 0;
            o_stid = 0;
            o_st_amt = 0;
            o_allamt = 0;
            o_allnum = 0;
            stname = "";
        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(mid,wid, gid, o_Des, o_stid, o_st_amt, o_amt, o_allamt, o_cent);
            }
            else
            {
                this.myUpdate(o_no, mid,wid, gid, o_Des, o_stid, o_st_amt, o_amt, o_allamt, o_cent);
            }
        }
        #endregion

        #region 条件查询
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_orders where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        public static string insertSQL(int _mid,int _wid, string _gid, string _o_Des, int _o_stid, decimal _o_st_amt, decimal _o_amt, decimal _o_allamt, decimal _o_cent, string _ono)
        {
            string _sql = "insert into B2C_orders (mid,wid,gid,o_des,o_stid,o_st_amt,o_amt,o_allamt,o_cent,o_no,aid) values (" + _mid +","+ _wid+",'" + _gid + "','" + _o_Des + "'," + _o_stid + "," + _o_st_amt + "," + _o_amt + "," + _o_allamt + "," + _o_cent + ",'" + _ono + "'," + "0)";

            return _sql;
        }

        #region  "订单日志表"
        //订单日志表
        /****************************************** 
         * 不需要自己的单独类，只需要获取本商品下的日志记录
         * 或写入本商品下的日志记录即可。         *
         *******************************************/
        public static void insertLogs(string _ono, string _glname, string _gldes, int _aid)
        {
            if (_ono == "")
            {
                throw new Exception("订单编号不能为空");
            }

            try
            {
                string sql = "insert into b2c_order_log (ono,ol_name,ol_des,aid) values (@ono,@glname,@gldes,@aid)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@glname", _glname),
                    new SqlParameter("@gldes", _gldes), 
                    new SqlParameter("@aid", _aid)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static string insertLogsSQL(string _ono, string _glname, string _gldes, int _aid)
        {
            string sql = "";
            sql = "insert into b2c_order_log (ono,ol_name,ol_des,aid) values ('" + _ono + "','" + _glname + "','" + _gldes.Replace("'", "") + "'," + _aid + ")";

            return sql;
        }
        public static DataTable GetLogsList(string _ono)
        {
            string sql = "select *,(select a_name from b2c_order_active where id=b2c_order_log.aid) as aname from b2c_order_log where ono='" + _ono + "' order by id";
            return comfun.GetDataTableBySQL(sql);
        }
        public static void deleteLogsAtGoods(string _ono)
        {
            string sql = "delete from b2c_order_log where ono='" + _ono + "'";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static void deleteLogs(string _ids)
        {
            string sql = "delete from b2c_order_log where id in (" + _ids + ")";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        #endregion

        #region "商品明细"
        public static void insertDetail(string _ono, int _gid, decimal _gprice, decimal _gnum, decimal _gamt, decimal _gcent, decimal _gallcent, string _gdes)
        {
            if (_ono == "")
            {
                throw new Exception("订单编号不能为空");
            }

            try
            {
                string sql = "insert into b2c_order_d (ono,gid,od_price,od_num,od_amt,od_cent,od_allcent,od_des) values (@ono,@gid,@odprice,@odnum,@odamt,@odcent,@odallcent,@oddes)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@gid", _gid), 
                    new SqlParameter("@odprice", _gprice),
                    new SqlParameter("@odnum", _gnum),
                    new SqlParameter("@odamt", _gamt),
                    new SqlParameter("@odcent", _gcent),
                    new SqlParameter("@odallcent", _gallcent),
                    new SqlParameter("@oddes", _gdes)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static string insertDetailSQL(string _ono, int _gid, decimal _gprice, decimal _gnum, decimal _gamt, decimal _gcent, decimal _gallcent, string _gdes)
        {
            string sql = "";
            sql = "insert into b2c_order_d (ono,gid,od_price,od_num,od_amt,od_cent,od_allcent,od_des) values ('" + _ono + "'," + _gid + "," + _gprice + "," + _gnum + "," + _gamt + "," + _gcent + "," + _gallcent + ",'" + _gdes.Replace("'", "") + "')";
            return sql;
        }
        public static DataTable GetDetailList(string _ono)
        {
            string sql = "select *,(select g_name from b2c_goods where id=b2c_order_d.gid) as gname from b2c_order_D where ono='" + _ono + "' order by id";
            return comfun.GetDataTableBySQL(sql);
        }
        public static void deleteDetailAtGoods(string _ono)
        {
            string sql = "delete from b2c_order_D where ono='" + _ono + "'";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        public static void deleteDetail(string _ids)
        {
            string sql = "delete from b2c_order_D where id in (" + _ids + ")";
            //删除一个商品
            //重新计算商品总金额
            sql += ";update b2c_orders set o_amt=(select sum(od_amt) from b2c_order_d where ono=b2c_orders.o_no) where o_no in (select ono from b2c_order_d where id in (" + _ids + ")  group by ono)";
            //重新计算包含运费在内的订单总金额
            sql += ";update b2c_orders set o_allamt=o_amt+o_st_amt where o_no in (select ono from b2c_order_d where id in (" + _ids + ")  group by ono)";
            //重新计算商品总积分
            sql += ";update b2c_orders set o_cent=(select sum(od_allcent) from b2c_order_d where ono=b2c_orders.o_no) where o_no in (select ono from b2c_order_d where id in (" + _ids + ")  group by ono)";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region "订单地址"
        public static void insertAddr(string _ono, string _name, string _addr, string _addr2, string _zip, string _tel, string _mobile, string _senddate, string _des)
        {
            if (_ono == "")
            {
                throw new Exception("订单编号不能为空");
            }

            try
            {
                string sql = "insert into b2c_order_addr (ono,a_name,a_addr,a_addr2,a_zip,a_tel,a_mobile,a_senddate,a_des) values (@ono,@name,@addr,@addr2,@zip,@tel,@mobile,@senddate,@des)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@name", _name), 
                    new SqlParameter("@addr", _addr),
                    new SqlParameter("@addr2", _addr2),
                    new SqlParameter("@zip", _zip),
                    new SqlParameter("@tel", _tel),
                    new SqlParameter("@mobile", _mobile),
                    new SqlParameter("@senddate", _senddate),
                    new SqlParameter("@des", _des)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static string insertAddrSQL(string _ono, string _name, string _addr, string _addr2, string _zip, string _tel, string _mobile, string _senddate, string _des)
        {
            string sql = "";
            sql = "insert into b2c_order_addr (ono,a_name,a_addr,a_addr2,a_zip,a_tel,a_mobile,a_senddate,a_des) values ('" + _ono + "','" + _name + "','" + _addr + "','" + _addr2 + "','" + _zip + "','" + _tel + "','" + _mobile + "','" + _senddate + "','" + _des + "')";
            return sql;
        }
        public static DataTable GetAddr(string _ono)
        {
            string sql = " select top 1 * from b2c_order_addr where ono in (select o_no from  b2c_orders where mid=(select top 1 mid from b2c_orders where o_no='" + _ono + "')) order by id desc";
            return comfun.GetDataTableBySQL(sql);
        }
        public static DataTable GetSureAddr(string _ono)
        {
            string sql = " select top 1 * from b2c_order_addr where ono='" + _ono + "' order by id desc";
            return comfun.GetDataTableBySQL(sql);
        }
        public static DataTable GetAddr(int _mid)
        {
            string sql = " select top 1 * from b2c_order_addr where ono in (select o_no from  b2c_orders where mid=" + _mid.ToString() + ") order by id desc";
            return comfun.GetDataTableBySQL(sql);
        }
        public static void deleteAddrAtGoods(string _ono)
        {
            string sql = "delete from b2c_order_addr where ono='" + _ono + "'";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static void deleteDetail(int _ids)
        {
            string sql = "delete from b2c_order_addr where id=" + _ids.ToString();
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region "支付"
        public static void insertPay(string _ono, int _pid, decimal _pamt, string _pdes)
        {
            if (_ono == "")
            {
                throw new Exception("订单编号不能为空");
            }

            try
            {
                string sql = "insert into b2c_order_pay (ono,pid,p_amt,p_des) values (@ono,@pid,@pamt,@pdes)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@pid", _pid), 
                    new SqlParameter("@pamt", _pamt),
                    new SqlParameter("@pdes", _pdes)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static string insertPaySQL(string _ono, int _pid, decimal _pamt, string _pdes)
        {
            string sql = "";
            sql = "insert into b2c_order_pay (ono,pid,p_amt,p_des) values ('" + _ono + "'," + _pid.ToString() + "," + _pamt.ToString() + ",'" + _pdes.Replace("'", "") + "')";
            return sql;
        }
        public static DataTable GetPayList(string _ono)
        {
            string sql = "select * from b2c_order_pay where ono='" + _ono + "' order by id";
            return comfun.GetDataTableBySQL(sql);
        }
        public static void deletePayAtGoods(string _ono)
        {
            string sql = "delete from b2c_order_pay where ono='" + _ono + "'";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static void deletePay(string _ids)
        {
            string sql = "delete from b2c_order_pay where id in (" + _ids + ")";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion
    }
}
