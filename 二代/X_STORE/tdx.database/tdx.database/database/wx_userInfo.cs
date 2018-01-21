using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class wx_userInfo
    {
        public string fake_id = "";//微信唯一码
        public string nick_name = "";//昵称
        public string remark_name = "";//备注
        public string group_name = "";//分组名
        public string image_url = "";//头像地址
        public int cityID = 0;//对应关注公众号
        public string weixinID = "";//微信号
        public wx_userInfo() { }
        public wx_userInfo(string _fake_id, int _cityID)
        {
            this.fake_id = _fake_id;
            this.cityID = _cityID;
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from wx_userInfo where 1=1";
            if (!string.IsNullOrEmpty(this.fake_id) && cityID != 0)
            {
                _sql += " and fake_id='" + this.fake_id;
                _sql += "' and cityID=" + cityID;
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
                fake_id = Convert.IsDBNull(dr["fake_id"]) ? "" : Convert.ToString(dr["fake_id"]);
                nick_name = Convert.IsDBNull(dr["nick_name"]) ? "" : Convert.ToString(dr["nick_name"]);
                remark_name = Convert.IsDBNull(dr["remark_name"]) ? "" : Convert.ToString(dr["remark_name"]);
                group_name = Convert.IsDBNull(dr["group_name"]) ? "" : Convert.ToString(dr["group_name"]);
                image_url = Convert.IsDBNull(dr["image_url"]) ? "" : Convert.ToString(dr["image_url"]);
                cityID = Convert.IsDBNull(dr["cityID"]) ? 0 : Convert.ToInt32(dr["cityID"]);
                weixinID = Convert.IsDBNull(dr["weixinID"]) ? "" : Convert.ToString(dr["weixinID"]);
                dr = null;
            }
            else
            {
                AddNew();
            }
            dt.Dispose();
            dt = null;
        }
        public void AddNew()
        {
            fake_id = "";
            nick_name = "";//公众号id
            remark_name = "";//名称
            group_name = "";//创建时间
            image_url = "";
            cityID = 0;
            weixinID = "";
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from wx_userInfo where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void Update()
        {
            if (!this.fake_id.Equals(""))
            {
                this.myUpdateMethod(this.fake_id, this.weixinID);
            }
            //else
            //{
            //    this.myInsertMethod(this.fake_id, this.weixinID);
            //}
        }
        private void myUpdateMethod(string _fake_id, string _weixinID)
        {
            string sql = "update wx_userInfo set weixinID=@weixinID where fake_id=@fake_id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@fake_id", _fake_id), 
                    new SqlParameter("@weixinID",_weixinID)};
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
        //private void myInsertMethod(string _fake_id, string _weixinID)
        //{
        //    string sql = "insert into B2C_group_fran (wid,name) values (@wid,@name)";
        //    SqlParameter[] paras = new SqlParameter[] { 
        //            new SqlParameter("@wid", _wid), 
        //             new SqlParameter("@name", _name)
        //            };
        //    try
        //    {
        //        comfun con = new comfun();
        //        con.ExecuteNonQuery(sql, paras);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new NotSupportedException(ex.Message);
        //    }
        //}
    }
}