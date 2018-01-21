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
    public class B2C_order_log
    {
        #region 属性
        public int id = 0;          //编号
        public string ono = "";         //商品编号
        public string ol_name = "";  //详细描述
        public int  ol_uid = 0;   //详细描述
        public DateTime  ol_date = DateTime.Now ;   //详细描述
        public string ol_des = "";
     
        #endregion

        #region 构造函数
        public B2C_order_log() { }
        public B2C_order_log(int id)
        {
            id = id;
            this.load();
        }
        #endregion

        #region SELECT



        public void load()
        {
            string sql = "select * from B2C_order_log where id=" + id + "";


            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_order_log ID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    ono = Convert.IsDBNull(dt.Rows[0]["ono"]) ? "" : Convert.ToString(dt.Rows[0]["ono"]);
                    ol_name = Convert.IsDBNull(dt.Rows[0]["ol_name"]) ? "" : Convert.ToString(dt.Rows[0]["ol_name"]);
                    ol_uid = Convert.IsDBNull(dt.Rows[0]["ol_uid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ol_uid"]);
                    ol_date = Convert.IsDBNull(dt.Rows[0]["ol_date"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["ol_date"]);
                    ol_des = Convert.IsDBNull(dt.Rows[0]["ol_des"]) ? "" : Convert.ToString(dt.Rows[0]["ol_des"]);
                
                }
            }
            else
            {
                throw new NotSupportedException("B2C_order_log：" + id + ":" + "不存在");
            }

        }


        #endregion

        #region INSERT
        private void myInsert( string _ono, string _ol_name, int _ol_uid, DateTime  _ol_date, string _ol_des)
        {
            try
            {
                string sql = "insert into B2C_order_log (ono,ol_name,ol_uid,ol_date,ol_des) values (@ono,@ol_name,@ol_uid,@ol_date,@ol_des)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@ol_name", _ol_name), 
                    new SqlParameter("@ol_uid", _ol_uid), 
                    new SqlParameter("@ol_date", _ol_date),  
                    new SqlParameter("@ol_des", ol_des) 

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
        private void myUpdate(int _id, string _ono, string _ol_name, int  _ol_uid, DateTime  _ol_date, string _ol_des)
        {
            if (_id == 0)
            {
                id = _id;
            }
            else
            {
                throw new NotSupportedException("请输入商品编号");
            }
            ono = _ono;
            ol_name = _ol_name;
            ol_uid = _ol_uid;
            ol_date = _ol_date;
            ol_des = _ol_des;
        
            try
            {
                string sql = "update B2C_order_log set ono=@ono,ol_name=@ol_name,ol_uid=@ol_uid,ol_date=@ol_date,ol_des=@ol_des where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ono", _ono), 
                    new SqlParameter("@ol_name", _ol_name), 
                    new SqlParameter("@ol_uid", _ol_uid), 
                    new SqlParameter("@ol_date", _ol_date),  
                    new SqlParameter("@ol_des", ol_des) 
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
                string sql = "delete from B2C_order_log where id=" + _id + "";
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
            ol_name = "";
            ol_uid = 0;
            ol_date = DateTime.Now;
            ol_des = "";
           

        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(ono, ol_name, ol_uid, ol_date, ol_des);
            }
            else
            {
                this.myUpdate(id, ono, ol_name, ol_uid, ol_date, ol_des);
            }
        }
        #endregion

        #region 条件查询
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_order_log where " + _sql + "");
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
