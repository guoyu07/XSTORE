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
    public class B2C_ADBig
    {
        #region 属性
        public int id = 0;           //编号
        public string c_name = "";    //名称
        public string c_des = "";     //描述
        public int cityid = 1;        //城市编号
        #endregion

        #region 构造函数
        public B2C_ADBig() { }
        public B2C_ADBig(int _cid)
        {
            id = _cid;
            this.load();
        }
        #endregion

        #region SELECT

        private void load()
        {
            string sql = "select * from B2C_ADBig where id=" + id + "";
            if (id == 0)
            {
                throw new NotSupportedException("B2C_ADBigID：" + id + "不存在");
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_ADBigID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    c_name = Convert.IsDBNull(dt.Rows[0]["c_name"]) ? "" : Convert.ToString(dt.Rows[0]["c_name"]);
                    c_des = Convert.IsDBNull(dt.Rows[0]["c_des"]) ? "" : Convert.ToString(dt.Rows[0]["c_des"]);
                    cityid = Convert.IsDBNull(dt.Rows[0]["cityid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityid"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_ADBig：" + id + "不存在");
            }

        }
        #endregion

        #region INSERT
        private void myInsert(string _cname, string _cdes, int _ccityid)
        {
            if (!string.IsNullOrEmpty(_cname))
            {
                c_name = _cname;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            try
            {
                string sql = "insert into B2C_ADBig (c_name,c_des,cityid) values (@c_name,@c_des,@cityid)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@c_name", c_name), 
                    new SqlParameter("@c_des", _cdes),
                    new SqlParameter("@cityid", _ccityid)};

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
        private void myUpdate(int _cid, string _cname, string _cdes)
        {
            if (!string.IsNullOrEmpty(_cname))
            {
                c_name = _cname;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            c_des = _cdes;

            try
            {
                string sql = "update B2C_ADBig set c_name=@c_name,c_des=@c_des where id=" + _cid;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@c_name", c_name), 
                    new SqlParameter("@c_des", c_des),
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
        public static int myDel(int _cid)
        {
            int res = 0;
            if (_cid == 0)
            {
                throw new NotSupportedException("没有取得ID号");
            }
            else
            {
                B2C_ADBig btc = new B2C_ADBig(_cid);
                string sql = "delete from B2C_ADBig where id=" + _cid;
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

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(c_name, c_des, cityid);
            }
            else
            {
                this.myUpdate(id, c_name, c_des);
            }
        }
        #endregion

        public void Addnew()
        {
            id = 0;
            c_name = "";
            c_des = "";
            cityid = 1;
        }

        #region 条件查询
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_ADBig where " + _sql + "");
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
