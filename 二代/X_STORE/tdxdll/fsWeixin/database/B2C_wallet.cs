using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.SessionState;
using tdx.kernel;

namespace tdx.database
{
    public class B2C_wallet
    {
        public int id = 0;
        public int payorcost = 1;//充值还是消费，默认1充值-1消费
        public int wid = 0;//公众号id
        public double amount = 0;//产生的费用;
        public double give_amount = 0; //赠送的费用
        public int is_add = 0;//是否累加,默认0不累加
        public DateTime create_time = DateTime.Now;
        public int isdel = 0;//1删除，0不删除
        public string des = "";//描述
        public int category = 1;//1代表积分2代表钱包暂时
        public int rankid = 1;//等级关联ID用于与特权关联默认1则为普通等级
        public DateTime star_time = new DateTime();//开始时间
        public DateTime end_time = new DateTime();//结束日期
        public int is_fandian = 0;//此字段只对钱包生效默认0不返点则赠送的费用就是钱，如果为1返点就为百分比

        public B2C_wallet() { }
        public B2C_wallet(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        public B2C_wallet(string _wid)
        {
            this.wid = int.Parse(_wid);
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_wallet where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (wid != 0)
            {
                _sql += " and wid=" + this.wid;
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if(dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                payorcost = Convert.IsDBNull(dr["payorcost"]) ? 1 : Convert.ToInt32(dr["payorcost"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                amount = Convert.IsDBNull(dr["amount"]) ? 0 : Convert.ToDouble(dr["amount"]);
                give_amount = Convert.IsDBNull(dr["give_amount"]) ? 0 : Convert.ToDouble(dr["give_amount"]);
                is_add = Convert.IsDBNull(dr["is_add"]) ? 0 : Convert.ToInt32(dr["is_add"]);
                create_time = Convert.IsDBNull(dr["create_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["create_time"]);
                isdel = Convert.IsDBNull(dr["isdel"]) ? 0 : Convert.ToInt32(dr["isdel"]);
                des = Convert.IsDBNull(dr["des"]) ? "" : Convert.ToString(dr["des"]);
                category = Convert.IsDBNull(dr["category"]) ? 1 : Convert.ToInt32(dr["category"]);
                rankid = Convert.IsDBNull(dr["rankid"]) ? 0 : Convert.ToInt32(dr["rankid"]);
                star_time = Convert.IsDBNull(dr["star_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["star_time"]);
                end_time = Convert.IsDBNull(dr["end_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["end_time"]);
                is_fandian = Convert.IsDBNull(dr["is_fandian"]) ? 0 : Convert.ToInt32(dr["is_fandian"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(int _payorcost, int _wid, double _amount, double _give_amount, int _is_add, DateTime _create_time, int _isdel, string _des, int _category, int _rankid, DateTime _star_time, DateTime _end_time, int _is_fandian)
        {
            string sql = "insert into B2C_wallet(payorcost,wid,amount,give_amount,is_add,create_time,isdel,des,category,rankid,star_time,end_time,is_fandian) values (@payorcost,@wid,@amount,@give_amount,@is_add,@create_time,@isdel,@des,@category,@rankid,@star_time,@end_time,@is_fandian)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@payorcost", _payorcost), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@amount", _amount), 
                    new SqlParameter("@give_amount", _give_amount), 
                    new SqlParameter("@is_add", _is_add), 
                    new SqlParameter("@create_time", _create_time), 
                    new SqlParameter("@isdel", _isdel), 
                    new SqlParameter("@des", _des), 
                    new SqlParameter("@category", _category), 
                    new SqlParameter("@rankid", _rankid), 
                    new SqlParameter("@star_time", _star_time), 
                    new SqlParameter("@end_time", _end_time),
                    new SqlParameter("@is_fandian", _is_fandian),      
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
        private void myUpdateMethod(int _id, int _payorcost, int _wid, double _amount, double _give_amount, int _is_add, int _isdel, string _des, int _category, int _rankid, DateTime _star_time, DateTime _end_time, int _is_fandian)
        {
            string sql = "update B2C_wallet set payorcost=@payorcost,wid=@wid,amount=@amount,give_amount=@give_amount,is_add=@is_add,isdel=@isdel,des=@des,category=@category,rankid=@rankid,star_time=@star_time,end_time=@end_time,is_fandian=@is_fandian where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@payorcost", _payorcost), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@amount", _amount), 
                    new SqlParameter("@give_amount", _give_amount), 
                    new SqlParameter("@is_add", _is_add), 
                    new SqlParameter("@isdel", _isdel), 
                    new SqlParameter("@des", _des), 
                    new SqlParameter("@category", _category), 
                    new SqlParameter("@rankid", _rankid),
                    new SqlParameter("@star_time", _star_time),
                    new SqlParameter("@end_time", _end_time),
                    new SqlParameter("@is_fandian", _is_fandian),
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
        private void myDeleteMethod(string _sql)
        {
            string sql = "delete from weixin_account where id in(" + _sql + ")";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //#endregion

        //#region "公有方法"
        public void AddNew()
        {
            id = 0;
            payorcost = 1;
            wid = 0;
            amount = 0;
            give_amount = 0;
            is_add = 0;
            create_time = DateTime.Now;
            isdel = 0;
            des = "";
            category = 1;
            rankid = 1;
            star_time = new DateTime();
            end_time = new DateTime();
            is_fandian = 0;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.payorcost, this.wid, this.amount, this.give_amount, this.is_add, this.isdel, this.des, this.category, this.rankid, this.star_time, this.end_time, this.is_fandian);
            }
            else
            {
                this.myInsertMethod(this.payorcost, this.wid, this.amount, this.give_amount, this.is_add, this.create_time, this.isdel, this.des, this.category, this.rankid, this.star_time, this.end_time, this.is_fandian);
            }
        }
        public void Delete(string _sql)
        {
            this.myDeleteMethod(_sql);
        }

        //public void updateHits()
        //{
        //    if (this.id != 0)
        //    {
        //        try
        //        {
        //            comfun.UpdateBySQL("update B2C_wallet set login_time=getDate() where id=" + this.id);
        //        }
        //        finally { }
        //    }
        //}
        //public void updateRights()
        //{
        //    if (this.u_id != 0)
        //    {
        //        try
        //        {
        //            comfun.UpdateBySQL("update weixin_account set u_rights='" + u_rights + "',u_area_rights='" + u_area_rights + "' where u_id=" + this.u_id);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
        //public Boolean checkRights(int _uid, string _rightsNeed)
        //{
        //    if (this.u_id != 0)
        //    {
        //        if (-1 == (this.u_rights.IndexOf("," + _rightsNeed + ",")))
        //            return false;
        //        else
        //            return true;
        //    }
        //    else
        //        return false;
        //}
        //public int checkLogon(string _pswNeed)
        //{
        //    int result = 0;
        //    if (this.id != 0)
        //    {
        //        if (comEncrypt.GetMD5(_pswNeed) != this.password)
        //            result = -2; //密码不不正确
        //        else
        //            result = 1;//密码正确，登录成功;
        //    }
        //    else
        //        result = -1;//用户名不存在

        //    if (result == 1)
        //    {//如果登录成功,则设置session
        //        string[] uInfo = { this.id.ToString(), this.username };
        //        System.Web.HttpContext.Current.Session["uInfo"] = uInfo;
        //        this.updateHits();
        //    }

        //    return result;

        //}
        //#endregion

        //#region "静态方法"
        /// <summary>
        /// 一次彻底删除一组用户
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;
            string sql = "delete from B2C_wallet where id in (" + _ids + ")";
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
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        public static int setIsActive(string _ids)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_wallet set u_isactive= -1 * (u_isActive - 1) where u_id in (" + _ids + ")");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_wallet where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static string GetWallet(int wid)
        {
            string result = " \r\n <div class='ru'>";
            string _sql = "select * from B2C_AccountConfig where wid=" + wid;
            _sql += "select * from B2C_wallet where wid=" + wid;
            _sql += "select * from B2C_rankinfo where cardid in(select top(1) id from B2C_vipcard where wid=" + wid + " and is_open=1) order by score";
            DataSet _ds = comfun.GetDataSetBySQL(_sql);
            if (_ds.Tables[2].Rows.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr0 in _ds.Tables[0].Rows)
                {
                    foreach (DataRow dr1 in _ds.Tables[2].Rows)
                    {
                        foreach (DataRow dr2 in _ds.Tables[1].Rows)
                        {
                            if (Convert.ToInt32(dr2["category"]) == 2 && Convert.ToInt32(dr2["is_fandian"]) == 0 && Convert.ToInt32(dr2["rankid"]) == Convert.ToInt32(dr1["id"]))
                            {
                                //判断是钱包并且不返点且等级匹配的列
                                if (Convert.ToInt32(dr2["payorcost"]) == 1 && Convert.ToInt32(dr0["category"]) == 2 && Convert.ToInt32(dr0["opened"]) == 1)
                                {
                                    //充值
                                    //result += "     \r\n    <p><span class=\"des\">" + dr1["name"] + " 充值" + Convert.ToDouble(dr2["amount"]).ToString("F2") + "元赠送" + Convert.ToDouble(dr2["give_amount"]).ToString("F2") + "元</span> </p>";
                                }
                                else if (Convert.ToInt32(dr0["category"]) == 2 && Convert.ToInt32(dr0["opened"]) == 1 && Convert.ToInt32(dr2["payorcost"]) == -1)
                                {
                                    //消费
                                    result += "     \r\n    <span class=\"des\">" + dr1["name"] + " 消费" + Convert.ToDouble(dr2["amount"]).ToString("F2") + "元赠送" + Convert.ToDouble(dr2["give_amount"]).ToString("F2") + "元</span><br/> ";
                                }
                            }
                            if (Convert.ToInt32(dr2["category"]) == 1 && Convert.ToInt32(dr2["rankid"]) == Convert.ToInt32(dr1["id"]))
                            {
                                //判断是钱包并且不返点且等级匹配的列
                                if (Convert.ToInt32(dr2["payorcost"]) == 1 && Convert.ToInt32(dr0["category"]) == 2 && Convert.ToInt32(dr0["opened"]) == 1)
                                {
                                    //充值
                                    //result += "     \r\n    <p><span class=\"des\">" + dr1["name"] + " 充值" + Convert.ToDouble(dr2["amount"]).ToString("F2") + "元赠送" + Convert.ToDouble(dr2["give_amount"]).ToString("F2") + "元</span> </p>";
                                }
                                else if (Convert.ToInt32(dr0["category"]) == 1 && Convert.ToInt32(dr0["opened"]) == 1 && Convert.ToInt32(dr2["payorcost"]) == -1)
                                {
                                    //消费
                                    result += "     \r\n    <span class=\"des\">" + dr1["name"] + " 消费" + Convert.ToDouble(dr2["amount"]).ToString("F2") + "元赠送" + Convert.ToInt32(dr2["give_amount"]) + "积分</span><br/> ";
                                }
                            }
                        }
                    }
                }
                return result + " \r\n </div>";
            }
            else
            {
                return result;
            }
        }
        public static string GetPrice(string id, string wid)
        {
            string result = "";
            //string result = "\r\n <div class='ru'>";
            DataSet _ds = new DataSet() ;
            int index = 0;
            if (!string.IsNullOrEmpty(wid))
            {
                string _sql = "select * from BJ_value where pro_id=" + id + ";";
                _sql += "select * from BJ_obj where wid=" + wid;
                _ds = comfun.GetDataSetBySQL(_sql);
                foreach (DataRow dr1 in _ds.Tables[1].Rows)
                {
                    foreach (DataRow dr0 in _ds.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr0["obj_id"]) == Convert.ToInt32(dr1["id"]) && Convert.ToDouble(dr0["price"]) > 0)
                        {
                            index++;
                            result += "\r\n" + dr1["name"]+":" + Convert.ToDouble(dr0["price"]).ToString("F2") + "￥\n";
                        }
                    }
                }
            }
            //result += "\r\n </div>";
            return index > 0 ? result : "";
        }
        //public static Boolean Auth()
        //{
        //    if (System.Web.HttpContext.Current.Session["uInfo"] == null)
        //        return false;

        //    string[] _username = (string[])System.Web.HttpContext.Current.Session["uInfo"];
        //    if (_username == null)
        //        return false;
        //    if (_username[0] == null || _username[0].ToString().Trim() == "" || _username[0].ToString() == String.Empty)
        //        return false;

        //    return true;

        //}
    }
}
