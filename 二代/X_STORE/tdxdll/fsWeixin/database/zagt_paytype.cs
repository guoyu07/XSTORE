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
    /// 支付方式表
    /// </summary>
    public class zagt_paytype
    {
        #region *****构造函数*****
        public zagt_paytype()
        { }
        public zagt_paytype(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion


        public int id = 0;
        public string pt_name = string.Empty;
        public int pt_isactive = 0;
        public int pt_isdel = 0;
        public int pt_isYN = 0;
        public int pt_isWEB = 0;
        public int pt_isBank = 0;
        public double pt_AMT = 0;
        public int cityID = 0;

        private void LoadData()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from zagt_paytype where id={0}", id);

            DataTable dt = comfun.GetDataTableBySQL(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                pt_name = Convert.IsDBNull(dt.Rows[0]["pt_name"]) ? string.Empty : Convert.ToString(dt.Rows[0]["pt_name"]);
                pt_isactive = Convert.IsDBNull(dt.Rows[0]["pt_isactive"]) ? 0 : Convert.ToInt32(dt.Rows[0]["pt_isactive"]);
                pt_isdel = Convert.IsDBNull(dt.Rows[0]["pt_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["pt_isdel"]);
                pt_isYN = Convert.IsDBNull(dt.Rows[0]["pt_isYN"]) ? 0 : Convert.ToInt32(dt.Rows[0]["pt_isYN"]);
                pt_isWEB = Convert.IsDBNull(dt.Rows[0]["pt_isWEB"]) ? 0 : Convert.ToInt32(dt.Rows[0]["pt_isWEB"]);
                pt_isBank = Convert.IsDBNull(dt.Rows[0]["pt_isBank"]) ? 0 : Convert.ToInt32(dt.Rows[0]["pt_isBank"]);
                pt_AMT = Convert.IsDBNull(dt.Rows[0]["pt_AMT"]) ? 0 : Convert.ToDouble(dt.Rows[0]["pt_AMT"]);
                cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityID"]);
            }
            else
            {
                throw new NotSupportedException("zagt_paytype：" + id + "不存在");
            }
        }

        private void MyInsertMethod(string _pt_name, int _pt_isactive, int _pt_isdel, int _pt_isYN, int _pt_isWEB, int _pt_isBank, double _pt_AMT, int cityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into zagt_kemu (pt_name,pt_isActive ,pt_isdel ,pt_isYN ,pt_isWEB ,pt_isBank ,pt_AMT ,cityID)");
            strSql.Append(" values (@pt_name,@pt_isactive,@pt_isdel,@pt_isYN,@pt_isWEB,@pt_isBank,@pt_AMT,@cityID)");
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@pt_name",_pt_name),
            new SqlParameter("@pt_isactive",_pt_isactive),
            new SqlParameter("@pt_isdel",_pt_isdel),
            new SqlParameter("@pt_isYN",_pt_isYN),
            new SqlParameter("@pt_isWEB",_pt_isWEB),
            new SqlParameter("@pt_isBank",_pt_isBank),
            new SqlParameter("@pt_AMT",_pt_AMT),
            new SqlParameter("@cityID",cityID)
            };
            try
            {
                new comfun().ExecuteNonQuery(strSql.ToString(), paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void MyUpdateMethod(int _c_id, string _pt_name, int _pt_isactive, int _pt_isdel, int _pt_isYN, int _pt_isWEB, int _pt_isBank, double _pt_AMT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"update zagt_paytype set pt_name = @pt_name
      ,pt_isActive = @pt_isActive
      ,pt_isdel = @pt_isdel
      ,pt_isYN = @pt_isYN
      ,pt_isWEB = @pt_isWEB
      ,pt_isBank = @pt_isBank
      ,pt_AMT = @pt_AMT
        where id=@c_id");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@pt_name", _pt_name), 
                new SqlParameter("@pt_isActive", _pt_isactive),
                new SqlParameter("@pt_isdel", _pt_isdel),
                new SqlParameter("@pt_isYN", _pt_isYN),
                new SqlParameter("@pt_isWEB", _pt_isWEB),
                new SqlParameter("@pt_isBank", _pt_isBank),
                new SqlParameter("@pt_AMT", _pt_AMT),
                new SqlParameter("@c_id", _c_id) };

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

            pt_name = string.Empty;
            pt_isactive = 0;
            pt_isdel = 0;
            pt_isYN = 0;
            pt_isWEB = 0;
            pt_isBank = 0;
            pt_AMT = 0;
            cityID = 0;
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(pt_name,pt_isactive,pt_isdel,pt_isYN,pt_isWEB,pt_isBank,pt_AMT,cityID);
            }
            else
            {
                this.MyUpdateMethod(id, pt_name, pt_isactive, pt_isdel, pt_isYN, pt_isWEB, pt_isBank, pt_AMT);
            }
        }

        /// <summary>
        /// 更新pt_isactive字段为0
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsactive(int _c_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_paytype set pt_isactive=0 where id=@c_id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@c_id", _c_id) };
            new comfun().ExecuteNonQuery(strSql.ToString(), paras);
        }


        /// <summary>
        /// 删除处理
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsdel(int _c_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_paytype set pt_isdel=1 where id=@c_id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@c_id", _c_id) };
            new comfun().ExecuteNonQuery(strSql.ToString(), paras);
        }
        #endregion


    }
}