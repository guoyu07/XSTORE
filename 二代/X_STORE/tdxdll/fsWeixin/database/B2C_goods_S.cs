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
    public class B2C_goods_S
    {
        #region 属性
        public int id = 0;          //编号
        public string cno = "";         //类别
        public string s_name = ""; //名称
        public int s_flag = 1;  //1：平铺方式;2:输入框;3:下拉方式
        public int s_isPhoto = 0; //是否用图片显示.0:用文字;1:用图片
        public int s_sort = 99;    //排序
        public int s_isActive = 1;//启用，暂停
        public int s_isDel = 0;     //是否删除
        public int s_isWeb = 1;     //是否显示于网上
        public int s_isSearch = 1;  //是否显示为搜索项
        public int cityid = 1;                      //城市ID
        #endregion

        #region 构造函数
        public B2C_goods_S() { }
        public B2C_goods_S(int _id)
        {
            id = _id;
            this.load();
        }
        public B2C_goods_S(string _s_name)
        {
            s_name = _s_name;
            this.load();
        }
        #endregion

        #region SELECT
        public void load()
        {
            string sql = "select * from B2C_goods_S where id=" + id + "";
            if (id == 0)
            {
                if (string.IsNullOrEmpty(s_name))
                {
                    sql = "select * from B2C_goods_S where s_name='" + s_name + "'";
                }
                else
                {
                    throw new NotSupportedException("B2C_goods_S ID：" + id + "不存在");
                }
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_goods_S ID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    s_name = Convert.IsDBNull(dt.Rows[0]["s_name"]) ? "" : Convert.ToString(dt.Rows[0]["s_name"]);
                    s_flag = Convert.IsDBNull(dt.Rows[0]["s_flag"]) ? 1 : Convert.ToInt32(dt.Rows[0]["s_flag"]);
                    s_isPhoto = Convert.IsDBNull(dt.Rows[0]["s_isPhoto"]) ? 0 : Convert.ToInt32(dt.Rows[0]["s_isPhoto"]);
                    s_sort = Convert.IsDBNull(dt.Rows[0]["s_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["s_sort"]);
                    s_isActive = Convert.IsDBNull(dt.Rows[0]["s_isActive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["s_isActive"]);
                    s_isDel = Convert.IsDBNull(dt.Rows[0]["s_isDel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["s_isDel"]);
                    s_isWeb = Convert.IsDBNull(dt.Rows[0]["s_isWeb"]) ? 1 : Convert.ToInt32(dt.Rows[0]["s_isWeb"]);
                    s_isSearch = Convert.IsDBNull(dt.Rows[0]["s_isSearch"]) ? 1 : Convert.ToInt32(dt.Rows[0]["s_isSearch"]);
                    cityid = Convert.IsDBNull(dt.Rows[0]["cityid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityid"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_goods_S：" + id + ":" + s_name + "不存在");
            }
        }
        #endregion

        #region INSERT
        private void myInsert(string _cno, string _s_name, int _s_flag, int _s_isPhoto, int _s_sort, int _s_isActive, int _s_isDel, int _s_isWeb, int _s_isSearch, int _cityid)
        {
            if (!string.IsNullOrEmpty(_s_name))
            {
                s_name = _s_name;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            try
            {
                string sql = "insert into B2C_goods_S (cno,s_name,s_flag,s_isPhoto,s_sort,s_isActive,s_isDel,s_isWeb,s_isSearch,cityid) values (@cno,@s_name,@s_flag,@s_isPhoto,@s_sort,@s_isActive,@s_isDel,@s_isWeb,@s_isSearch,@cityid)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@s_name", _s_name),
                    new SqlParameter("@s_flag", _s_flag),
                    new SqlParameter("@s_isPhoto", _s_isPhoto),
                    new SqlParameter("@s_sort", _s_sort),
                    new SqlParameter("@s_isActive", _s_isActive),
                    new SqlParameter("@s_isDel", _s_isDel),
                    new SqlParameter("@s_isWeb", _s_isWeb),
                    new SqlParameter("@s_isSearch", _s_isSearch),
                    new SqlParameter("@cityid", _cityid)};

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
        private void myUpdate(int _id, string _cno, string _s_name, int _s_flag, int _s_sort)
        {
            if (!string.IsNullOrEmpty(_s_name))
            {
                s_name = _s_name;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            id = _id;
            cno = _cno;
            s_flag = _s_flag;
            s_sort = _s_sort;
            try
            {
                string sql = "update B2C_goods_S set cno=@cno,s_name=@s_name,s_flag=@s_flag,s_sort=@s_sort where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", cno), 
                    new SqlParameter("@s_flag", s_flag), 
                    new SqlParameter("@s_sort", s_sort),
                    new SqlParameter("@s_name", s_name),
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
                B2C_goods_S bc = new B2C_goods_S(_id);
                string sql = "delete from B2C_goods_S where id=" + _id + "";
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
            cno = "";
            s_name = "";
            s_flag = 1;
            s_isPhoto = 0;
            s_sort = 99;
            s_isActive = 1;
            s_isDel = 0;
            s_isWeb = 1;
            s_isSearch = 1;
            cityid = 1;
        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(cno, s_name, s_flag, s_isPhoto, s_sort, s_isActive, s_isDel, s_isWeb, s_isSearch, cityid);
            }
            else
            {
                this.myUpdate(id, cno, s_name, s_flag, s_sort);
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
                res = comfun.UpdateBySQL("update B2C_goods_S set s_isactive= -1 * (s_isactive - 1) where id in ('" + _id + "')");
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
                res = comfun.UpdateBySQL("update B2C_goods_S set s_isdel= -1 * (s_isdel - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        //设置是否用图片显示
        public static int setIsPhoto(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_goods_S set s_isPhoto= -1 * (s_isPhoto - 1) where id in ('" + _id + "')");
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
                res = comfun.UpdateBySQL("update B2C_goods_S set s_isWeb= -1 * (s_isWeb - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        //设置是否显示为搜索项
        public static int setIsSearch(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_goods_S set s_isSearch= -1 * (s_isSearch - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

        #region 类别树形结构
        public static void getCategoryClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect cid)
        {
            string texts = "";
            string values = "";

            B2C_category cate = new B2C_category(classid);
            int depth = cate.c_level;
            while (depth > 0)
            {
                texts += "　";
                depth = depth - 1;
            }
            values = cate.c_no;
            if (cate.c_child < 1)
            {
                texts += " - " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = comfun.GetDataTableBySQL("select * from B2C_category where c_parent=" + classid + " order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getCategoryClassTree(Convert.ToInt32(dr["c_id"]), cid);
                }
            }
        }
        #endregion
    }
}
