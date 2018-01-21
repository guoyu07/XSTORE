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
using tdx.kernel;

namespace tdx.database
{
    public class B2C_SMS
    {
        public int id = 0;
        public int mid = 0;
        public string s_tel = "";
        public string s_code ="";
        public string s_ips = "";
        public int s_type = 0;
        public int s_isR = 0;
        public DateTime regtime = System.DateTime.Now;

        public B2C_SMS()
        { 
        }
        public B2C_SMS(int _id)
        {
            this.id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select * from B2C_SMS where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_SMSID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mid"]); 
                    s_tel = Convert.IsDBNull(dt.Rows[0]["s_tel"]) ? "" : Convert.ToString(dt.Rows[0]["s_tel"]);
                    s_code = Convert.IsDBNull(dt.Rows[0]["s_code"]) ? "" : Convert.ToString(dt.Rows[0]["s_code"]);
                    s_ips = Convert.IsDBNull(dt.Rows[0]["s_ips"]) ? "" : Convert.ToString(dt.Rows[0]["s_ips"]);
                    s_type = Convert.IsDBNull(dt.Rows[0]["s_type"]) ? 0 : Convert.ToInt32(dt.Rows[0]["s_type"]);
                    s_isR = Convert.IsDBNull(dt.Rows[0]["s_isR"]) ? 0 : Convert.ToInt32(dt.Rows[0]["s_isR"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_SMSID：" + id + "不存在");
            }

        }

        public static string insertSQL(int _mid,string _stel,string _scode,string _sips,int _stype)
        {
            string _sql = "insert into B2C_SMS(mid,s_tel,s_code,s_ips,s_type) values({0},'{1}','{2}','{3}',{4})";
            _sql = string.Format(_sql, _mid.ToString(), _stel,_scode, _sips, _stype.ToString());

            return _sql;
        }
        public static bool verify(int _mid, string _stel, string _scode, int _stype)
        {
            bool resultI = false;
            string _sql = "select top 1 * from b2c_sms where mid=" + _mid.ToString() + " and s_type=" + _stype.ToString() + " order by id desc";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string stel = dr["s_tel"].ToString().Trim();
                string scode = dr["s_code"].ToString().Trim();
                if ((stel == _stel) && (scode == _scode))
                    resultI = true;
            }
            dt.Dispose();

            return resultI;
        }
        public static bool check(int _mid, string _stel, string _sips, int _stype)
        {
            bool resultI = true;
            string _sql = "select count(id) from b2c_sms where mid=" + _mid.ToString() + " and DateDiff(n,regtime,getDate())<3";
            _sql += ";\r\n select count(id) from b2c_sms where s_tel='" + _stel + "' and DateDiff(n,regtime,getDate())<3";
            _sql += ";\r\n select count(id) from b2c_sms where s_ips='" + _sips + "' and DateDiff(n,regtime,getDate())<3";

            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0 || Convert.ToInt32(ds.Tables[1].Rows[0][0]) > 0 || Convert.ToInt32(ds.Tables[2].Rows[0][0]) > 0)
                resultI = false;
            ds.Dispose();

            return resultI;
        }

    }
}
