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
    public class B2C_memvip
    { 
        public int Mvip_id = 0;//编号
        public string Mvip_name = "";//名称
        public decimal Mvip_price = 1;//享受折扣
        public decimal Mvip_total = 0;//升级条件
        public string Mvip_des = "";//描述
        public int cityID = 1;//所属城市

        public B2C_memvip() { }
        public B2C_memvip(int _id)
        {
            Mvip_id = _id;
            this.load();
        }
        private void load()
        {
            string sql = "select * from B2C_memvip where Mvip_id=" + Mvip_id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_Mvip_id：" + Mvip_id + "不唯一");
                }
                else
                {
                    Mvip_id = Convert.IsDBNull(dt.Rows[0]["Mvip_id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["Mvip_id"]);
                    Mvip_name = Convert.IsDBNull(dt.Rows[0]["Mvip_name"]) ? "" : Convert.ToString(dt.Rows[0]["Mvip_name"]);
                    Mvip_price = Convert.IsDBNull(dt.Rows[0]["Mvip_price"]) ? 1 : Convert.ToDecimal(dt.Rows[0]["Mvip_price"]);
                    Mvip_total = Convert.IsDBNull(dt.Rows[0]["Mvip_total"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Mvip_total"]);
                    Mvip_des = Convert.IsDBNull(dt.Rows[0]["Mvip_des"]) ? "" : Convert.ToString(dt.Rows[0]["Mvip_des"]);
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_Mvip_id：" + Mvip_id + "不存在");
            }
        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _Mvip_name, decimal _Mvip_price, decimal _Mvip_total,string _Mvip_des, int _cityID)
        {
            try
            {
                string sql = "insert into B2C_memvip (Mvip_name,Mvip_price,Mvip_total,Mvip_des,cityID) values (@Mvip_name,@Mvip_price,@Mvip_total,@Mvip_des,@cityID)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@Mvip_name", _Mvip_name), 
                    new SqlParameter("@Mvip_price", _Mvip_price),
                    new SqlParameter("@Mvip_total", _Mvip_total),
                    new SqlParameter("@Mvip_des", _Mvip_des),
                    new SqlParameter("@cityID", _cityID)};

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
        private void myUpdate(int _Mvip_id,string _Mvip_name, decimal _Mvip_price, decimal _Mvip_total, string _Mvip_des, int _cityID)
        {
            try
            {
                string sql = "update B2C_memvip set Mvip_name=@Mvip_name,Mvip_price=@Mvip_price,Mvip_total=@Mvip_total,Mvip_des=@Mvip_des,cityID=@cityID where Mvip_id=" + _Mvip_id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@Mvip_name", _Mvip_name), 
                    new SqlParameter("@Mvip_price", _Mvip_price),
                    new SqlParameter("@Mvip_total", _Mvip_total),
                    new SqlParameter("@Mvip_des", _Mvip_des),
                    new SqlParameter("@cityID", _cityID)};

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
            string sql = "delete from B2C_memvip where id=" + _id + "";
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
            if (Mvip_id == 0)
            {
                this.myInsert(Mvip_name, Mvip_price, Mvip_total, Mvip_des, cityID);
            }
            else
            {
                this.myUpdate(Mvip_id, Mvip_name, Mvip_price, Mvip_total, Mvip_des, cityID);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void AddNew()
        {
            Mvip_name = "";
            Mvip_price = 1;
            Mvip_total = 0;
            Mvip_des = "";
            cityID = 1;
        }
        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataTable GetList(string _dzd,string _sql)
        {
            try
            {
                DataTable dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_memvip where " + _sql + " order by Mvip_id desc");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
