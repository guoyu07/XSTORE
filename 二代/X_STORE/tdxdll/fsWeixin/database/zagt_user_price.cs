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
    /// 代理商价格表
    /// </summary>
    public class zagt_user_price
    {
        #region *****构造函数*****
        public zagt_user_price()
        { }
        public zagt_user_price(int _id)
        {
            id = _id;
            this.LoadData();
        }
        public zagt_user_price(int _uid, int _gid)
        {
            this.userid = _uid;
            this.gid = _gid;
            this.LoadData();
        }
        #endregion

        public int id = 0;
        public int userid = 0;//关联zagt_user表ID
        public int gid = 0;//关联zagt_Goods表ID
        public double gu_price = 0;//价格


        private void LoadData()
        {
            StringBuilder strSql = new StringBuilder();
            if (id != 0)
            {
                strSql.AppendFormat("select * from zagt_user_price where id={0}", id);
            }
            else
            {
                strSql.AppendFormat("select * from zagt_user_price where uid={0} and gid={1}", userid,gid);
            }

            DataTable dt = comfun.GetDataTableBySQL(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                userid = Convert.IsDBNull(dt.Rows[0]["uid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["uid"]);
                gid = Convert.IsDBNull(dt.Rows[0]["gid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["gid"]);
                gu_price = Convert.IsDBNull(dt.Rows[0]["gu_price"]) ? 0 : Convert.ToDouble(dt.Rows[0]["gu_price"]);
            }
            //else
            //{
            //    throw new NotSupportedException("zagt_user_price：" + id + "不存在");
            //}
        }

        private void MyInsertMethod(int _uid, int _gid, double _gu_price)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into zagt_user_price (uid,gid,gu_price)");
            strSql.Append(" values (@uid,@gid,@gu_price)");
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@uid",_uid),
            new SqlParameter("@gid",_gid),
            new SqlParameter("@gu_price",_gu_price)
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

        private void MyUpdateMethod(int _id, int _uid, int _gid, double _gu_price)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"update zagt_user_price set uid=@uid,gid=@gid,gu_price=@gu_price where id=@id");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@uid",_uid),
                new SqlParameter("@gid",_gid),
                new SqlParameter("@gu_price",_gu_price),
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

            userid = 0;//关联zagt_user表ID
            gid = 0;//关联zagt_Goods表ID
            gu_price = 0;//价格
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(userid,gid,gu_price);
            }
            else
            {
                this.MyUpdateMethod(id, userid, gid, gu_price);
            }
        }
        #endregion

        /// <summary>
        /// 根据代理商id和商品id获取数据
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_goodID"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int _userID,int _goodID)
        {
            StringBuilder selectSql = new StringBuilder();
            selectSql.AppendFormat("select * from zagt_user_price where userid={0} and gid={1}",_userID,_goodID);
            DataTable dt = comfun.GetDataTableBySQL(selectSql.ToString());
            return dt;
        }
    }
}