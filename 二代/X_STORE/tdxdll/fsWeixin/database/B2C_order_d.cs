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
    public class B2C_order_d
    {
        #region 属性
        public int id = 0;          //编号
        public string  ono = "";         //商品编号
        public double  od_price = 0.0;  //详细描述
        public int od_hits = 0;   //详细描述
        public double od_amt = 0.0;   //详细描述
        public string od_ip = "";
        public string od_from = "";
        public DateTime  od_date = DateTime .Now ;
        public string od_des = "";
    

        #endregion

        #region 构造函数
        public B2C_order_d() { }
        public B2C_order_d(int id)
        {
            id = id;
            this.load();
        }
        #endregion

        #region SELECT



        public void load()
        {
            string sql = "select * from B2C_order_d where id=" + id + "";

         
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_order_d ID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    ono = Convert.IsDBNull(dt.Rows[0]["ono"]) ? "" : Convert.ToString(dt.Rows[0]["ono"]);
                    od_price = Convert.IsDBNull(dt.Rows[0]["od_price"]) ? 0.00 : Convert.ToDouble(dt.Rows[0]["od_price"]);
                    od_hits = Convert.IsDBNull(dt.Rows[0]["od_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["od_hits"]);
                    od_amt = Convert.IsDBNull(dt.Rows[0]["od_amt"]) ? 0.00 : Convert.ToDouble(dt.Rows[0]["od_amt"]);
                    od_ip = Convert.IsDBNull(dt.Rows[0]["od_ip"]) ? "" : Convert.ToString(dt.Rows[0]["od_ip"]);
                    od_from = Convert.IsDBNull(dt.Rows[0]["od_from"]) ? "" : Convert.ToString(dt.Rows[0]["od_from"]);
                    od_date = Convert.IsDBNull(dt.Rows[0]["od_date"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["od_date"]);
                    od_des = Convert.IsDBNull(dt.Rows[0]["od_des"]) ? "" : Convert.ToString(dt.Rows[0]["od_des"]);
                  
                }
            }
            else
            {
                throw new NotSupportedException("B2C_order_d：" + id + ":" + "不存在");
            }

        }


        #endregion

        #region INSERT
        private void myInsert(string _ono, double  _od_price,int _od_hits, double  _od_amt, string _od_ip, string  _od_from, DateTime  _od_date,string _od_des)
        {
            try
            {
                string sql = "insert into B2C_order_d (ono,od_price,od_hits,od_amt,od_ip,od_from,od_date,od_des) values (@ono,@od_price,@od_hits,@od_amt,@od_ip,@od_from,@od_date,@od_des)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@od_price", _od_price), 
                    new SqlParameter("@od_hits", _od_hits), 
                    new SqlParameter("@od_amt", _od_amt),  
                    new SqlParameter("@od_ip", od_ip), 
                    new SqlParameter("@od_from", od_from), 
                    new SqlParameter("@od_date", od_date),
                    new SqlParameter("@od_des", od_des)  
                   
             
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
        private void myUpdate(int _id, string _ono, double  _od_price, int _od_hits, double  _od_amt, string _od_ip, string _od_from, DateTime  _od_date, string _od_des)
        {
            if (id == 0)
            {
                id = _id;
            }
            else
            {
                throw new NotSupportedException("请输入商品编号");
            }
            ono = _ono;
            od_price = _od_price;
            od_hits = _od_hits;
            od_amt = _od_amt;
            od_ip = _od_ip;
            od_from = _od_from;
            od_date = _od_date;
            od_des = _od_des;


            try
            {
                string sql = "update B2C_order_d set ono=@ono,od_price=@od_price,od_hits=@od_hits,od_amt=@od_amt,od_ip=@od_ip,od_from=@od_from,od_date=@od_date,od_des=@od_des where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@od_price", _od_price), 
                    new SqlParameter("@od_hits", _od_hits), 
                    new SqlParameter("@od_amt", _od_amt),  
                    new SqlParameter("@od_ip", od_ip), 
                    new SqlParameter("@od_from", od_from), 
                    new SqlParameter("@od_date", od_date),
                    new SqlParameter("@od_des", od_des)  
                     
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
                string sql = "delete from B2C_order_d where id=" + _id + "";
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
                string sql = "delete from B2C_order_d where ono='" + _ono + "'";
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
            id = 0;
            ono = "";
            od_price = 0.00;
            od_hits = 0;
            od_amt = 0.00;
            od_ip = "";
            od_from = "";
            od_date = DateTime.Now;
            od_des = "";
           
        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(ono, od_price,od_hits, od_amt, od_ip, od_from,od_date,od_des);
            }
            else
            {
                this.myUpdate(id, ono, od_price, od_hits, od_amt, od_ip, od_from, od_date, od_des);
            }
        }
        #endregion

        #region 条件查询
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_order_d where " + _sql + "");
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
