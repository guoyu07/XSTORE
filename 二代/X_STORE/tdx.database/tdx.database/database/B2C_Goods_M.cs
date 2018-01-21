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
    public class B2C_Goods_M
    {
        #region 属性
        public int id = 0;          //编号
        public int gid = 0;         //商品编号
        public string g_msg = "";   //详细描述
        #endregion

        #region 构造函数
        public B2C_Goods_M() { }
        public B2C_Goods_M(int _gid)
        {
            gid = _gid;
            this.load();
        }
        #endregion

        #region SELECT
        public void load()
        {
            string sql = "select * from B2C_Goods_M where gid=" + gid + " order by id desc";
            //if (id == 0)
            //{
            //    throw new NotSupportedException("B2C_Goods_M ID：" + id + "不存在");
            //}
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                //if (dt.Rows.Count > 1)
                //{
                //    throw new NotSupportedException("B2C_Goods_M ID：" + id + "不唯一");
                //}
                //else
                //{
                id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                gid = Convert.IsDBNull(dt.Rows[0]["gid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["gid"]);
                g_msg = Convert.IsDBNull(dt.Rows[0]["g_msg"]) ? "" : Convert.ToString(dt.Rows[0]["g_msg"]);
                //}
            }
            else
            {
                throw new NotSupportedException("B2C_Goods_M：" + id + "不存在");
            }
        }
        #endregion

        #region INSERT
        private void myInsert(int _gid, string _g_msg)
        {
            try
            {
                string sql = "insert into B2C_Goods_M (gid,g_msg) values (@gid,@g_msg)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@gid", gid), 
                    new SqlParameter("@g_msg", g_msg), 
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
        private void myUpdate(int _id, int _gid, string _g_msg)
        {
            if (_gid != 0)
            {
                gid = _gid;
            }
            else
            {
                throw new NotSupportedException("请输入商品编号");
            }
            gid = _gid;
            g_msg = _g_msg;
            try
            {
                string sql = "update B2C_Goods_M set gid=@gid,g_msg=@g_msg where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@gid", gid), 
                    new SqlParameter("@g_msg", g_msg), 
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
        public static int myDel(int _gid)
        {
            int res = 0;
            if (_gid == 0)
            {
                throw new NotSupportedException("没有取得商品ID号");
            }
            else
            {
                //B2C_Goods_M bg = new B2C_Goods_M(_gid);
                string sql = "delete from B2C_Goods_M where gid=" + _gid + "";
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
            gid = 0;
            g_msg = "";
        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(gid, g_msg);
            }
            else
            {
                this.myUpdate(id, gid, g_msg);
            }
        }
        #endregion

        #region 条件查询
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Goods_M where " + _sql + "");
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
