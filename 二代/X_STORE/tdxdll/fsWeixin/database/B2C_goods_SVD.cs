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
    public class B2C_goods_SVD
    {
        #region 属性
        public int id = 0;          //编号
        public int gid = 0;         //商品ID
        public int sID = 0;         //搜索条件ID
        public int svID = 0;        //搜索属性ID
        public string svd_name = "";//搜索属性值
        #endregion

        #region 构造函数
        public B2C_goods_SVD() { }
        public B2C_goods_SVD(int _id)
        {
            id = _id;
            this.load();
        }
        public B2C_goods_SVD(string _svd_name)
        {
            svd_name = _svd_name;
            this.load();
        }
        #endregion

        #region SELECT
        public void load()
        {
            string sql = "select * from B2C_goods_SVD where id=" + id + "";
            if (id == 0)
            {
                if (string.IsNullOrEmpty(svd_name))
                {
                    sql = "select * from B2C_goods_SVD where svd_name='" + svd_name + "'";
                }
                else if(svID !=0){
                    sql = "select * from B2C_goods_SVD where svID=" + svID + "";
                }
                else
                {
                    throw new NotSupportedException("B2C_goods_SVD ID：" + id + "不存在");
                }
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_goods_SVD ID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    gid = Convert.IsDBNull(dt.Rows[0]["gid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["gid"]);
                    sID = Convert.IsDBNull(dt.Rows[0]["sID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["sID"]);
                    svID = Convert.IsDBNull(dt.Rows[0]["svID"]) ? 1 : Convert.ToInt32(dt.Rows[0]["svID"]);
                    svd_name = Convert.IsDBNull(dt.Rows[0]["svd_name"]) ? "" : Convert.ToString(dt.Rows[0]["svd_name"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_goods_SVD：" + id + ":" + svd_name + "不存在");
            }
        }
        #endregion

        #region INSERT
        private void myInsert(int _gid, int _sID, int _svID, string _svd_name)
        {
            //if (!string.IsNullOrEmpty(_svd_name))
            //{
            //    svd_name = _svd_name;
            //}
            //else
            //{
            //    throw new NotSupportedException("请输入名称");
            //}
            try
            {
                string sql = "insert into B2C_goods_SVD (gid,sID,svID,svd_name) values (@gid,@sID,@svID,@svd_name)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@gid", _gid), 
                    new SqlParameter("@sID", _sID),
                    new SqlParameter("@svID", _svID),
                    new SqlParameter("@svd_name", _svd_name)
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
        private void myUpdate(int _id, int _gid, int _sID, int _svID, string _svd_name)
        {
            id = _id;
            gid = _gid;
            sID = _sID;
            svID = _svID;
            svd_name = _svd_name;
            try
            {
                string sql = "update B2C_goods_SVD set gid=@gid,sID=@sID,svID=@svID,svd_name=@svd_name where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@gid", gid), 
                    new SqlParameter("@sID", sID), 
                    new SqlParameter("@svID", svID),
                    new SqlParameter("@svd_name", svd_name),
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
                throw new NotSupportedException("没有取得ID号");
            }
            else
            {
                //B2C_goods_SVD bc = new B2C_goods_SVD(_id);
                string sql = "delete from B2C_goods_SVD where id=" + _id + "";
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

        public void Addnew()
        {
            id = 0;
            gid = 0;
            sID = 0;
            svID = 0;
            svd_name = "";
        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(gid, sID, svID, svd_name);
            }
            else
            {
                this.myUpdate(id, gid, sID, svID, svd_name);
            }
        }
        #endregion

    }
}
