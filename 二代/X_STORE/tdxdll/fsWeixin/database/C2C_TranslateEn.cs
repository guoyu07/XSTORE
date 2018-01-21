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
    public class C2C_TranslateEn
    {
        public int id = 0;//编号
        public string kw = "";//关键字
        public string app_user = "";//应用用户名
        public string app_father = "";//应用商户名
        public DateTime create_date = DateTime.Now;//创建时间
        public C2C_TranslateEn() { }
        //public B2C_Account(int _id)
        //{
        //    id = _id;
        //    this.load();
        //}

        //private void load()
        //{
        //    string sql = "select * from B2C_Account where id=" + id + "";
        //    DataTable dt = comfun.GetDataTableBySQL(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows.Count > 1)
        //        {
        //            throw new NotSupportedException("B2C_Accout_id：" + id + "不唯一");
        //        }
        //        else
        //        {
        //            id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
        //            mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["mid"]);
        //            ptid = Convert.IsDBNull(dt.Rows[0]["ptid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["ptid"]);
        //            cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
        //            orderNo = Convert.IsDBNull(dt.Rows[0]["orderNo"]) ? "" : Convert.ToString(dt.Rows[0]["orderNo"]);
        //            ac_money = Convert.IsDBNull(dt.Rows[0]["ac_money"]) ? 0 : Convert.ToDouble(dt.Rows[0]["ac_money"]);
        //            ac_AMT = Convert.IsDBNull(dt.Rows[0]["ac_AMT"]) ? 0 : Convert.ToDouble(dt.Rows[0]["ac_AMT"]);
        //            ac_update = Convert.IsDBNull(dt.Rows[0]["ac_update"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["ac_update"]);
        //            ac_regdate = Convert.IsDBNull(dt.Rows[0]["ac_regdate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["ac_regdate"]);
        //            ac_des = Convert.IsDBNull(dt.Rows[0]["ac_des"]) ? "" : Convert.ToString(dt.Rows[0]["ac_des"]);
        //            cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityID"]);
        //        }
        //    }
        //    else
        //    {
        //        throw new NotSupportedException("B2C_Account：" + id + "不存在");
        //    }
        //}
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _kw, string _app_user, string _app_father)
        {
            try
            {
                string sql = "";
                sql += " insert into C2C_TranslateEn (kw,app_user,app_father)";
                sql += " values (@kw,@app_user,@app_father)";
                SqlParameter[] paras = new SqlParameter[] 
                { 
                    new SqlParameter("@kw", _kw),
                    new SqlParameter("@app_user", _app_user),
                    new SqlParameter("@app_father", _app_father)
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
        //private void myUpdate(int _id, int _mid, int _ptid, string _cno, string _orderNo, double _ac_money, double _ac_AMT, DateTime _ac_update, DateTime _ac_regdate, string _ac_des, int _cityID)
        //{
        //    try
        //    {
        //        string sql = "update B2C_Account set mid=@mid,ptid=@ptid,cno=@cno,orderNo=@orderNo,ac_money=@ac_money,ac_AMT=@ac_AMT,ac_update=@ac_update,ac_regdate=@ac_regdate,ac_des=@ac_des,cityID=@cityID where id=" + _id;
        //        SqlParameter[] paras = new SqlParameter[] { 
        //            new SqlParameter("@mid", _mid), 
        //            new SqlParameter("@ptid", _ptid),
        //            new SqlParameter("@cno", _cno), 
        //            new SqlParameter("@orderNo", _orderNo), 
        //            new SqlParameter("@ac_money", _ac_money), 
        //            new SqlParameter("@ac_AMT", _ac_AMT), 
        //            new SqlParameter("@ac_update", _ac_update),
        //            new SqlParameter("@ac_regdate", _ac_regdate),
        //            new SqlParameter("@ac_des", _ac_des),
        //            new SqlParameter("@cityID", _cityID)};

        //        comfun con = new comfun();
        //        con.ExecuteNonQuery(sql, paras);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new NotSupportedException(ex.Message);
        //    }
        //}
        ///// <summary>
        ///// 删除一条数据
        ///// </summary> 
        //public static int myDel(int _id)
        //{
        //    string sql = "delete from B2C_Account where id=" + _id + "";
        //    try
        //    {
        //        return comfun.UpdateBySQL(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            //if (id == 0)
            //{
            this.myInsert(kw, app_user, app_father);
            //}
            //else
            //{
            //    this.myUpdate(id, mid, ptid, cno, orderNo, ac_money, ac_AMT, ac_update, ac_regdate, ac_des, cityID);
            //}
        }
        ///// <summary>
        ///// 添加方法
        ///// </summary>
        //public void AddNew()
        //{
        //    id = 0;//编号
        //    mid = 0;//会员ID
        //    ptid = 0;
        //    cno = "";
        //    orderNo = "";
        //    ac_money = 0;
        //    ac_AMT = 0;
        //    ac_update = DateTime.Now;
        //    ac_regdate = DateTime.Now;
        //    ac_des = "";
        //    cityID = 1;
        //}
        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataTable GetList(int _page, string _dzd, string _sql)
        {
            try
            {
                DataTable dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Account where " + _sql + " order by id desc");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string InsertSQL(string _amtName, int _mid, int _ptid, string _cno, string _orderNo, double _ac_money, string _ac_des)
        {
            string sql = "\n begin ";
            sql += "\n declare @" + _amtName + " float ";
            sql += "\n set @" + _amtName + " =(select top 1 ac_amt from b2c_account where mid=" + _mid + " and cno='" + _cno + "' order by ac_update desc,id desc)";
            sql += "\n insert into B2C_Account (mid,ptid,cno,orderNo,ac_money,ac_AMT,ac_des,cityID)";
            sql += "\n values (" + _mid + "," + _ptid + ",'" + _cno + "','" + _orderNo + "'," + _ac_money + ",(isnull(@" + _amtName + ",0)+" + _ac_money + "),'" + _ac_des + "',1)";
            sql += "\n end";

            return sql;
        }
    }
}
