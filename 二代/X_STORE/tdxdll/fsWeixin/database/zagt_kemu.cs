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
    /// 可目表
    /// </summary>
    public class zagt_kemu
    {
        #region *****构造函数*****
        public zagt_kemu()
        { }
        public zagt_kemu(int _id)
        {
            c_id = _id;
            this.LoadData();
        }
        #endregion


        public int c_id = 0;
        public string c_no = string.Empty;
        public string c_name = string.Empty;
        public string c_gif = string.Empty;
        public string c_url = string.Empty;
        public int c_sort = 0;
        public string c_des = string.Empty;
        public int c_isactive = 0;
        public int c_isdel = 0;
        public DateTime regtime = System.DateTime.Now;
        public int c_parent = 0;
        public int c_level = 0;
        public int c_child = 0;
        public int c_math = 0;
        public int cityid = 0;


        private void LoadData()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from zagt_kemu where c_id={0}", c_id);

            DataTable dt = comfun.GetDataTableBySQL(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                c_id = Convert.IsDBNull(dt.Rows[0]["c_id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_id"]);
                c_no = Convert.IsDBNull(dt.Rows[0]["c_no"]) ? string.Empty : Convert.ToString(dt.Rows[0]["c_no"]);
                c_name = Convert.IsDBNull(dt.Rows[0]["c_name"]) ? string.Empty : Convert.ToString(dt.Rows[0]["c_name"]);
                c_gif = Convert.IsDBNull(dt.Rows[0]["c_gif"]) ? string.Empty : Convert.ToString(dt.Rows[0]["c_gif"]);
                c_url = Convert.IsDBNull(dt.Rows[0]["c_url"]) ? string.Empty : Convert.ToString(dt.Rows[0]["c_url"]);
                c_sort = Convert.IsDBNull(dt.Rows[0]["c_sort"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_sort"]);
                c_des = Convert.IsDBNull(dt.Rows[0]["c_des"]) ? string.Empty : Convert.ToString(dt.Rows[0]["c_des"]);
                c_isactive = Convert.IsDBNull(dt.Rows[0]["c_isactive"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_isactive"]);
                c_isdel = Convert.IsDBNull(dt.Rows[0]["c_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_isdel"]);
                regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                c_parent = Convert.IsDBNull(dt.Rows[0]["c_parent"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_parent"]);
                c_level = Convert.IsDBNull(dt.Rows[0]["c_level"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_level"]);
                c_child = Convert.IsDBNull(dt.Rows[0]["c_child"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_child"]);
                c_math = Convert.IsDBNull(dt.Rows[0]["c_math"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_math"]);
                cityid = Convert.IsDBNull(dt.Rows[0]["cityid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityid"]);
            }
            else
            {
                throw new NotSupportedException("zagt_kemu：" + c_id + "不存在");
            }
        }

        private void MyInsertMethod(string _c_no, string _c_name, string _c_gif, string _c_url, int _c_sort, string _c_des, int _c_isactive, int _c_isdel, int _c_parent, int _c_level, int _c_child, int _c_math, int _cityid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into zagt_kemu (c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child,c_math,cityid)");
            strSql.Append(" values (@c_no,@c_name,@c_gif,@c_url,@c_sort,@c_des,@c_isactive,@c_isdel,@c_parent,@c_level,@c_child,@c_math,@cityid)");
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@c_no",_c_no),
            new SqlParameter("@c_name",_c_name),
            new SqlParameter("@c_gif",_c_gif),
            new SqlParameter("@c_url",_c_url),
            new SqlParameter("@c_sort",_c_sort),
            new SqlParameter("@c_des",_c_des),
            new SqlParameter("@c_isactive",_c_isactive),
            new SqlParameter("@c_isdel",_c_isdel),
            new SqlParameter("@c_parent",_c_parent),
            new SqlParameter("@c_level",_c_level),
            new SqlParameter("@c_child",_c_child),
            new SqlParameter("@c_math",_c_math),
            new SqlParameter("@cityid",_cityid)
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

        private void MyUpdateMethod(int _c_id, string _c_no, string _c_name, string _c_gif, string _c_url, int _c_sort, string _c_des, int _c_isactive, int _c_isdel, int _c_parent, int _c_level, int _c_child, int _c_math)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"update zagt_kemu set c_no=@c_no ,c_name = @c_name,c_gif = @c_gif,c_url = @c_url,c_sort = @c_sort,c_des = @c_des,c_isactive = @c_isactive,c_isdel = @c_isdel
      ,regtime = @regtime
      ,c_parent = @c_parent
      ,c_level = @c_level
      ,c_child = @c_child
      ,c_math = @c_math  where c_id=@c_id");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@c_no", _c_no), 
                new SqlParameter("@c_name", _c_name),
                new SqlParameter("@c_gif", _c_gif),
                new SqlParameter("@c_url", _c_url),
                new SqlParameter("@c_sort", _c_sort),
                new SqlParameter("@c_des", _c_des),
                new SqlParameter("@c_isactive", _c_isactive),
                new SqlParameter("@_c_isdel", _c_isdel),
                new SqlParameter("@_c_parent", _c_parent),
                new SqlParameter("@_c_level", _c_level),
                new SqlParameter("@_c_child", _c_child),
                new SqlParameter("@_c_math", _c_math),
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
            c_id = 0;

            c_no = string.Empty;
            c_name = string.Empty;
            c_gif = string.Empty;
            c_url = string.Empty;
            c_sort = 0;
            c_des = string.Empty;
            c_isactive = 0;
            c_isdel = 0;
            regtime = System.DateTime.Now;
            c_parent = 0;
            c_level = 0;
            c_child = 0;
            c_math = 0;
            cityid = 0;
        }
        public void Update()
        {
            if (c_id == 0)
            {
                this.MyInsertMethod(c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,c_parent,c_level,c_child,c_math,cityid);
            }
            else
            {
                this.MyUpdateMethod(c_id,c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,c_parent,c_level,c_child,c_math);
            }
        }

        /// <summary>
        /// 更新c_isactive字段为0
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsactive(int _c_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_kemu set c_isactive=0 where c_id=@c_id");
            SqlParameter[] paras = new SqlParameter[]{new SqlParameter("@c_id",_c_id)};
            new comfun().ExecuteNonQuery(strSql.ToString(),paras);
        }


        /// <summary>
        /// 删除处理
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsdel(int _c_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_kemu set c_isdel=1 where c_id=@c_id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@c_id", _c_id) };
            new comfun().ExecuteNonQuery(strSql.ToString(), paras);
        }
        #endregion


     
    }
}