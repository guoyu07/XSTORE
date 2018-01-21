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
    public class B2C_goods_SV
    {
        #region 属性
        public int id = 0;          //编号
        public int sid = 0;         //搜索条件ID
        public string sv_name = ""; //名称
        public string sv_gif = "";  //图片路径
        public int sv_sort = 99;    //排序
        public int sv_isActive = 1;//启用，暂停
        public int sv_isDel = 0;     //是否删除
        public int sv_isWeb = 1;     //是否显示于网上
        #endregion

        #region 构造函数
        public B2C_goods_SV() { }
        public B2C_goods_SV(int _id)
        {
            id = _id;
            this.load();
        }
        public B2C_goods_SV(string _sv_name)
        {
            sv_name = _sv_name;
            this.load();
        }
        #endregion

        #region SELECT
        public void load()
        {
            string sql = "select * from B2C_goods_SV where id=" + id + "";
            if (id == 0)
            {
                if (string.IsNullOrEmpty(sv_name))
                {
                    sql = "select * from B2C_goods_SV where sv_name='" + sv_name + "'";
                }
                else
                {
                    throw new NotSupportedException("B2C_goods_SV ID：" + id + "不存在");
                }
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_goods_SV ID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    sid = Convert.IsDBNull(dt.Rows[0]["sid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["sid"]);
                    sv_name = Convert.IsDBNull(dt.Rows[0]["sv_name"]) ? "" : Convert.ToString(dt.Rows[0]["sv_name"]);
                    sv_gif = Convert.IsDBNull(dt.Rows[0]["sv_gif"]) ? "" : Convert.ToString(dt.Rows[0]["sv_gif"]);
                    sv_sort = Convert.IsDBNull(dt.Rows[0]["sv_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["sv_sort"]);
                    sv_isActive = Convert.IsDBNull(dt.Rows[0]["sv_isActive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["sv_isActive"]);
                    sv_isDel = Convert.IsDBNull(dt.Rows[0]["sv_isDel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["sv_isDel"]);
                    sv_isWeb = Convert.IsDBNull(dt.Rows[0]["sv_isWeb"]) ? 1 : Convert.ToInt32(dt.Rows[0]["sv_isWeb"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_goods_SV：" + id + ":" + sv_name + "不存在");
            }
        }
        #endregion

        #region INSERT
        private void myInsert(int _sid, string _sv_name, string _sv_gif, int _sv_sort, int _sv_isActive, int _sv_isDel, int _sv_isWeb)
        {
            if (!string.IsNullOrEmpty(_sv_name))
            {
                sv_name = _sv_name;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            if (_sid != 0)
            {
                sid = _sid;
            }
            else
            {
                throw new NotSupportedException("请选择商品搜索条件");
            }
            try
            {
                string sql = "insert into B2C_goods_SV (sid,sv_name,sv_gif,sv_sort,sv_isActive,sv_isDel,sv_isWeb) values (@sid,@sv_name,@sv_gif,@sv_sort,@sv_isActive,@sv_isDel,@sv_isWeb)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@sid", _sid), 
                    new SqlParameter("@sv_name", _sv_name),
                    new SqlParameter("@sv_gif", _sv_gif),
                    new SqlParameter("@sv_sort", _sv_sort),
                    new SqlParameter("@sv_isActive", _sv_isActive),
                    new SqlParameter("@sv_isDel", _sv_isDel),
                    new SqlParameter("@sv_isWeb", _sv_isWeb),};

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
        private void myUpdate(int _id, int _sid, string _sv_name, string _sv_gif, int _sv_sort)
        {
            if (!string.IsNullOrEmpty(_sv_name))
            {
                sv_name = _sv_name;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            if (_sid != 0)
            {
                sid = _sid;
            }
            else
            {
                throw new NotSupportedException("请选择商品搜索条件");
            }
            id = _id;
            sid = _sid;
            sv_name = _sv_name;
            sv_gif = _sv_gif;
            sv_sort = _sv_sort;
            try
            {
                string sql = "update B2C_goods_SV set sid=@sid,sv_name=@sv_name,sv_gif=@sv_gif,sv_sort=@sv_sort where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@sid", sid), 
                    new SqlParameter("@sv_name", sv_name), 
                    new SqlParameter("@sv_gif", sv_gif),
                    new SqlParameter("@sv_sort", sv_sort),
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
                //B2C_goods_SV bc = new B2C_goods_SV(_id);
                string sql = "delete from B2C_goods_SV where id=" + _id + "";
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
            sid = 0;
            sv_name = "";
            sv_gif = "";
            sv_sort = 99;
            sv_isActive = 1;
            sv_isDel = 0;
            sv_isWeb = 1;
        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(sid, sv_name, sv_gif, sv_sort, sv_isActive, sv_isDel, sv_isWeb);
            }
            else
            {
                this.myUpdate(id, sid, sv_name, sv_gif, sv_sort);
            }
        }
        #endregion

        #region 设置按钮功能
        // 设置是否启用
        public static int setIsactive(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_goods_SV set s_isactive= -1 * (s_isactive - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        /// 设置是否删除
        public static int setIsdel(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_goods_SV set s_isdel= -1 * (s_isdel - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        //设置是否显示于网上
        public static int setIsWeb(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_goods_SV set s_isWeb= -1 * (s_isWeb - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

    }
}
