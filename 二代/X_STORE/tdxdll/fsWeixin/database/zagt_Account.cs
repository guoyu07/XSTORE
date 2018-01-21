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
using System.Text;
using tdx.kernel;

namespace tdx.database
{
    /// <summary>
    /// 代理商账户日志表
    /// </summary>
    public class zagt_Account
    {
        #region *****构造函数*****
        public zagt_Account()
        { }
        public zagt_Account(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        public int id = 0;
        public int mid=0;//代理商id
        public int ptid=0;//支付方式
        public string cno=string.Empty;//科目编号
        public string orderNo = string.Empty;//订单编号
        public double ac_money = 0;//发生金额
        public double ac_Amt = 0;//本次发生金额
        public DateTime ac_update = System.DateTime.Now;//发生时间
        public DateTime ac_regdate = System.DateTime.Now;//录入时间
        public string ac_des = string.Empty;//摘要
        public int cityID = 0;

        private void LoadData()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from zagt_Account where id={0}",id);

            DataTable dt = comfun.GetDataTableBySQL(strSql.ToString());
            if(dt.Rows.Count>0)
            {
                id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mid"]);
                ptid = Convert.IsDBNull(dt.Rows[0]["ptid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ptid"]);
                cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? string.Empty : Convert.ToString(dt.Rows[0]["cno"]);
                orderNo = Convert.IsDBNull(dt.Rows[0]["orderNo"]) ? string.Empty : Convert.ToString(dt.Rows[0]["orderNo"]);
                ac_money = Convert.IsDBNull(dt.Rows[0]["ac_money"]) ? 0 : Convert.ToDouble(dt.Rows[0]["ac_money"]);
                ac_Amt = Convert.IsDBNull(dt.Rows[0]["ac_Amt"]) ? 0 : Convert.ToDouble(dt.Rows[0]["ac_Amt"]);
                ac_update = Convert.IsDBNull(dt.Rows[0]["ac_update"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["ac_update"]);
                ac_regdate = Convert.IsDBNull(dt.Rows[0]["ac_regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["ac_regdate"]);
                ac_des = Convert.IsDBNull(dt.Rows[0]["ac_des"]) ? string.Empty : Convert.ToString(dt.Rows[0]["ac_des"]);
                cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityID"]);
            }
            else
            {
                throw new NotSupportedException("zagt_Account：" + id + "不存在");
            }
        }

        private void MyInsertMethod(int _mid,int _ptid,string _cno,string _orderNo,double _ac_money,double _ac_Amt,string _ac_desc,int _cityID)
        {
             
            string sql = "declare @lastAmt float ";
            sql += "\n set @lastAmt =(select top 1 ac_amt from zagt_Account where mid=@mid and cno=@cno order by ac_update desc,id desc)";
            sql += "\n insert into zagt_Account (mid,ptid,cno,orderNo,ac_money,ac_AMT,ac_des,cityID)";
            sql += " values (@mid,@ptid,@cno,@orderNo,@ac_money,(isnull(@lastAmt,0)+@ac_money),@ac_des,@cityID)"; 
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@mid",_mid),
            new SqlParameter("@ptid",_ptid),
            new SqlParameter("@cno",_cno),
            new SqlParameter("@orderNo",_orderNo),
            new SqlParameter("@ac_money",_ac_money), 
            new SqlParameter("@ac_des",_ac_desc),
            new SqlParameter("@cityID",_cityID)
            };
            try
            {
                new comfun().ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void MyUpdateMethod(int _id, int _mid,int _ptid,string _cno,string _orderNo,double _ac_money,double _ac_Amt,string _ac_desc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_Account set mid=@mid,ptid=@ptid,cno=@cno,orderNo=@orderNo,ac_money=@ac_money,ac_Amt=@ac_Amt,ac_des=@ac_desc where id=@id");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@mid", _mid), 
                new SqlParameter("@ptid", _ptid),
                new SqlParameter("@cno", _cno),
                new SqlParameter("@orderNo", _orderNo),
                new SqlParameter("@ac_money", _ac_money),
                new SqlParameter("@ac_Amt", _ac_Amt),
                new SqlParameter("@ac_desc", _ac_desc),
                new SqlParameter("@id", _id) };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(strSql.ToString(), paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }


        #region " 添加、修改、删除 "
        public void AddNew()
        {
            id = 0;

            mid = 0;
            ptid = 0;
            cno = string.Empty; ;
            orderNo = string.Empty;
            ac_money = 0;
            ac_Amt = 0;
            ac_update = System.DateTime.Now;
            ac_regdate = System.DateTime.Now;
            ac_des = string.Empty;
            cityID = 0;
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(mid, ptid, cno, orderNo, ac_money, ac_Amt, ac_des, cityID);
            }
            else
            {
                this.MyUpdateMethod(id, mid, ptid, cno, orderNo, ac_money, ac_Amt, ac_des);
            }
        }
        #endregion

        /// <summary>
        /// 统计代理商日志
        /// </summary>
        /// <param name="_mid"></param>
        /// <returns></returns>
        public static int GetMsgCount(int _mid)
        {
            DataTable dt = comfun.GetDataTableBySQL("select count(id) from zagt_Account where mid='" + _mid + "'");
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        /// <summary>
        /// 代理商日志列表
        /// </summary>
        /// <param name="_mid"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int _mid)
        {
            DataTable dt = comfun.GetDataTableBySQL("select * from zagt_Account where mid='" + _mid + "' order by ac_update desc");
            return dt;
        }

        public DataTable GetTopAccount(int _mid)
        {
            DataTable dt = comfun.GetDataTableBySQL(@"select * from 
(select row_number() over(order by id desc) as rid,zagt_account.* 
from zagt_account where mid="+_mid+") where rid=1");
            return dt;
        }
    }
}