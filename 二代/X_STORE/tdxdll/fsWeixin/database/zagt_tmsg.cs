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
    /// 代理商通知信息表
    /// </summary>
    public class zagt_tmsg
    {
        #region *****构造函数*****
        public zagt_tmsg()
        { }
        public zagt_tmsg(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        public int id = 0;
        public string cno = string.Empty;
        public string t_title = string.Empty;
        public string t_author = string.Empty;
        public string t_source = string.Empty;
        public string t_gif = string.Empty;
        public string t_msg = string.Empty;
        public int t_isurl = 0;
        public string t_url = string.Empty;
        public int t_sort = 0;
        public int t_iflag = 0;
        public int t_cflag = 0;
        public int t_hits = 0;
        public DateTime t_wdate = System.DateTime.Now;
        public DateTime regdate = System.DateTime.Now;
        public int t_isactive = 0;
        public int t_isdel = 0;
        public int t_isF = 0;
        public int cityID = 0;



        private void LoadData()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from zagt_tmsg where id={0}", id);

            DataTable dt = comfun.GetDataTableBySQL(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? string.Empty : Convert.ToString(dt.Rows[0]["cno"]);
                t_title = Convert.IsDBNull(dt.Rows[0]["t_title"]) ? string.Empty : Convert.ToString(dt.Rows[0]["t_title"]);
                t_author = Convert.IsDBNull(dt.Rows[0]["t_author"]) ? string.Empty : Convert.ToString(dt.Rows[0]["t_author"]);
                t_source = Convert.IsDBNull(dt.Rows[0]["t_source"]) ? string.Empty : Convert.ToString(dt.Rows[0]["t_source"]);
                t_gif = Convert.IsDBNull(dt.Rows[0]["t_gif"]) ? string.Empty : Convert.ToString(dt.Rows[0]["t_gif"]);
                t_msg = Convert.IsDBNull(dt.Rows[0]["t_msg"]) ? string.Empty : Convert.ToString(dt.Rows[0]["t_msg"]);
                t_isurl = Convert.IsDBNull(dt.Rows[0]["t_isurl"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_isurl"]);
                t_url = Convert.IsDBNull(dt.Rows[0]["t_url"]) ? string.Empty : Convert.ToString(dt.Rows[0]["t_url"]);
                t_sort = Convert.IsDBNull(dt.Rows[0]["t_sort"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_sort"]);
                t_iflag = Convert.IsDBNull(dt.Rows[0]["t_iflag"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_iflag"]);
                t_cflag = Convert.IsDBNull(dt.Rows[0]["t_cflag"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_cflag"]);
                t_hits = Convert.IsDBNull(dt.Rows[0]["t_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_hits"]);
                t_wdate = Convert.IsDBNull(dt.Rows[0]["t_wdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["t_wdate"]);
                regdate = Convert.IsDBNull(dt.Rows[0]["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regdate"]);
                t_isactive = Convert.IsDBNull(dt.Rows[0]["t_isactive"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_isactive"]);
                t_isdel = Convert.IsDBNull(dt.Rows[0]["t_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_isdel"]);
                t_isF = Convert.IsDBNull(dt.Rows[0]["t_isF"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_isF"]);
                cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityID"]);
            }
            else
            {
                throw new NotSupportedException("zagt_tmsg：" + id + "不存在");
            }
        }

        private void MyInsertMethod(string _cno, string _t_title, string _t_author, string _t_source, string _t_gif, string _t_msg, int _t_isurl, string _t_url, int _t_sort, int _t_iflag, int _t_cflag, int _t_hits, int _t_isactive, int _t_isdel, int _t_isF, int cityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into zagt_tmsg (cno,t_title,t_author,t_source,t_gif ,t_msg ,t_isurl ,t_url ,t_sort ,t_iflag ,t_cflag ,t_hits ,t_isactive,t_isdel ,t_isF ,cityID)");
            strSql.Append(" values (@cno,@t_title,@t_author,@t_source,@t_gif,@t_msg,@t_isurl,@t_url,@t_sort,@t_iflag,@t_cflag,@t_hits,@t_isactive,@t_isdel,@t_isF,@cityID)");
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@cno",_cno),
            new SqlParameter("@t_title",_t_title),
            new SqlParameter("@t_author",_t_author),
            new SqlParameter("@t_source",_t_source),
            new SqlParameter("@t_gif",_t_gif),
            new SqlParameter("@t_msg",_t_msg),
            new SqlParameter("@t_isurl",_t_isurl),
            new SqlParameter("@t_url",_t_url),
            new SqlParameter("@t_sort",_t_sort),
            new SqlParameter("@t_iflag",_t_iflag),
            new SqlParameter("@t_cflag",_t_cflag),
            new SqlParameter("@t_hits",_t_hits),
            new SqlParameter("@t_isactive",_t_isactive),
            new SqlParameter("@t_isdel",_t_isdel),
            new SqlParameter("@t_isF",_t_isF),
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

        private void MyUpdateMethod(int _id, string _cno, string _t_title, string _t_author, string _t_source, string _t_gif, string _t_msg, int _t_isurl, string _t_url, int _t_sort, int _t_iflag, int _t_cflag, int _t_hits, int _t_isactive, DateTime _t_wdate, int _t_isdel, int _t_isF)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"update zagt_tmsg set cno =@cno
      ,t_title = @t_title
      ,t_author = @t_author
      ,t_source = @t_source
      ,t_gif = @t_gif
      ,t_msg = @t_msg
      ,t_isurl = @t_isurl
      ,t_url = @t_url
      ,t_sort = @t_sort
      ,t_iflag = @t_iflag
      ,t_cflag = @t_cflag
      ,t_hits = @t_hits
      ,t_wdate = @t_wdate
      ,t_isactive = @t_isactive
      ,t_isdel = @t_isdel
      ,t_isF = @t_isF
        where id=@id");
            SqlParameter[] paras = new SqlParameter[] { 
                 new SqlParameter("@cno",_cno),
            new SqlParameter("@t_title",_t_title),
            new SqlParameter("@t_author",_t_author),
            new SqlParameter("@t_source",_t_source),
            new SqlParameter("@t_gif",_t_gif),
            new SqlParameter("@t_msg",_t_msg),
            new SqlParameter("@t_isurl",_t_isurl),
            new SqlParameter("@t_url",_t_url),
            new SqlParameter("@t_sort",_t_sort),
            new SqlParameter("@t_iflag",_t_iflag),
            new SqlParameter("@t_cflag",_t_cflag),
            new SqlParameter("@t_hits",_t_hits),
            new SqlParameter("@t_isactive",_t_isactive),
            new SqlParameter("@t_wdate",_t_wdate),
            new SqlParameter("@t_isdel",_t_isdel),
            new SqlParameter("@t_isF",_t_isF),
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

            cno = string.Empty;
            t_title = string.Empty;
            t_author = string.Empty;
            t_source = string.Empty;
            t_gif = string.Empty;
            t_msg = string.Empty;
            t_isurl = 0;
            t_url = string.Empty;
            t_sort = 0;
            t_iflag = 0;
            t_cflag = 0;
            t_hits = 0;
            t_wdate = System.DateTime.Now;
            regdate = System.DateTime.Now;
            t_isactive = 0;
            t_isdel = 0;
            t_isF = 0;
            cityID = 0;
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(cno,t_title,t_author,t_source,t_gif,t_msg,t_isurl,t_url,t_sort,t_iflag,t_cflag,t_hits,t_isactive,t_isdel,t_isF,cityID);
            }
            else
            {
                this.MyUpdateMethod(id, cno, t_title, t_author, t_source, t_gif, t_msg, t_isurl, t_url, t_sort, t_iflag, t_cflag, t_hits, t_isactive,t_wdate, t_isdel, t_isF);
            }
        }

        /// <summary>
        /// 更新t_isactive字段为0
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsactive(int _c_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_tmsg set t_isactive=0 where id=@c_id");
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
            strSql.Append("update zagt_tmsg set t_isdel=1 where id=@c_id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@c_id", _c_id) };
            new comfun().ExecuteNonQuery(strSql.ToString(), paras);
        }
        #endregion
    }
}