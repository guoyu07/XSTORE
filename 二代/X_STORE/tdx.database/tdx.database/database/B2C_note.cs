using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Creatrue.kernel;

namespace tdx.database
{
    public class B2C_note
    {
        public int id = 0;
        public string n_tab = "";//关联表名
        public string n_row = "";//关联字段
        public string n_title = "";//留言标题
        public string n_msg = "";//留言内容
        public string n_link = "";//留言联系方式
        public string n_ip = "";//留言IP       
        public int n_isactive = 1;//是否启用
        public int n_isdel = 0;//是否删除
        public int n_isR = 0;//是否恢复
        public string n_reply = "";//回复内容
        public DateTime regdate = System.DateTime.Now;//留言时间
        public DateTime n_rdate = System.DateTime.Now;//回复时间
        //public int cityID = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());//网站区分

        //便于显示的字段内容
        public string isactivename = "启动";
        public string isdelname = "否";

        public B2C_note() { }
        public B2C_note(int _id)
        {
            id = _id;
            this.LoadData();
        }      

        #region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select * ";
            _sql += " from B2C_note where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }           
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 1)
            {
                throw (new Exception("B2C_note取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_note没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                n_tab = Convert.IsDBNull(dr["n_tab"]) ? "" : Convert.ToString(dr["n_tab"]);
                n_row = Convert.IsDBNull(dr["n_row"]) ? "" : Convert.ToString(dr["n_row"]);
                n_title = Convert.IsDBNull(dr["n_title"]) ? "" : Convert.ToString(dr["n_title"]);
                n_msg = Convert.IsDBNull(dr["n_msg"]) ? "" : Convert.ToString(dr["n_msg"]);
                n_link = Convert.IsDBNull(dr["n_link"]) ? "" : Convert.ToString(dr["n_link"]);
                n_ip = Convert.IsDBNull(dr["n_ip"]) ? "" : Convert.ToString(dr["n_ip"]);
                n_reply = Convert.IsDBNull(dr["n_reply"]) ? "" : Convert.ToString(dr["n_reply"]);
                n_isR = Convert.IsDBNull(dr["n_isR"]) ? 0 : Convert.ToInt32(dr["n_isR"]);

               
                n_isactive = Convert.IsDBNull(dr["n_isactive"]) ? 1 : Convert.ToInt32(dr["n_isactive"]);
                n_isdel = Convert.IsDBNull(dr["n_isdel"]) ? 0 : Convert.ToInt32(dr["n_isdel"]);
               
                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);
                n_rdate = Convert.IsDBNull(dr["n_rdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["n_rdate"]);
                //cityID = Convert.IsDBNull(dr["cityID"]) ? Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString()) : Convert.ToInt32(dr["cityID"]);
                //
                isactivename = (n_isactive == 1 ? "启动" : "停止");
                isdelname = (n_isdel == 1 ? "是" : "否");

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(string _wtab, string _wrow, string _wtitle, string _wmsg, string _wlink, string _wip, int _wisR, string _wreply) //,int _cityID
        {
            if (!string.IsNullOrEmpty(_wtitle))
            {
                n_title = _wtitle;
            }
            else
            {
                throw new NotSupportedException("请输入留言标题");
            }
            string sql = "insert into B2C_note (n_tab,n_row,n_title,n_msg,n_link,n_ip,n_isR,n_reply)"; //,cityID
            sql = sql + " values (@n_tab,@n_row,@n_title,@n_msg,@n_link,@n_ip,@n_isR,@n_replay)"; //,@cityID
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@n_tab", _wtab), 
                    new SqlParameter("@n_row", _wrow), 
                    new SqlParameter("@n_title", _wtitle), 
                    new SqlParameter("@n_msg", _wmsg),
                    new SqlParameter("@n_link", _wlink),
                    new SqlParameter("@n_ip", _wip),
                    new SqlParameter("@n_isR", _wisR),
                    new SqlParameter("@n_replay", _wreply)}; //,new SqlParameter("@cityID", _cityID)

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        private void myUpdateMethod(string _wtab, string _wrow, string _wtitle, string _wmsg, string _wlink, string _wip, int _wisR, string _wreply, int _id) //,int _cityID
        {
            if (!string.IsNullOrEmpty(_wtitle))
            {
                n_title = _wtitle;
            }
            else
            {
                throw new NotSupportedException("请输入文档名称");
            }
            string sql = "update B2C_note set n_tab=@n_tab,n_row=@n_row,n_title=@n_title,n_msg=@n_msg,n_link=@n_link,n_ip=@n_ip,n_isR=@n_isR,n_reply=@n_reply where id=@id"; //,cityID=@cityID
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@n_tab", _wtab), 
                    new SqlParameter("@n_row", _wrow), 
                    new SqlParameter("@n_title", _wtitle), 
                    new SqlParameter("@n_msg", _wmsg),
                    new SqlParameter("@n_link", _wlink),
                    new SqlParameter("@n_ip", _wip),
                    new SqlParameter("@n_isR", _wisR),
                    new SqlParameter("@n_replay", _wreply),
                    //new SqlParameter("@cityID", _cityID),
                    new SqlParameter("@id",_id)};

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        private void myDeleteMethod(int _id)
        {
            if (_id == 0)
            {
                throw new NotSupportedException("没有取得留言ID号");
            }
            else
            {
                string sql = "delete from B2C_note where id=" + _id;

                try
                {
                    comfun.UpdateBySQL(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region "公有方法"
        public void AddNew()
        {
            id = 0;
            n_tab = "";
            n_row = "";
            n_title = "";
            n_msg = "";
            n_link = "";
            n_ip = "";
            n_isR = 0;
            n_reply = "";

            n_rdate = System.DateTime.Now;

            n_isactive = 1;
            n_isdel = 0;
            regdate = System.DateTime.Now;
            //cityID = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());

            isactivename = "启动";
            isdelname = "未";
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.n_tab, this.n_row, this.n_title, this.n_msg, this.n_link, this.n_ip, this.n_isR, this.n_reply, this.id); //,this.cityID
            }
            else
            {
                this.myInsertMethod(this.n_tab, this.n_row, this.n_title, this.n_msg, this.n_link, this.n_ip, this.n_isR, this.n_reply); //, this.cityID
            }
        }
        public void Delete()
        {
            if (this.id != 0)
                this.myDeleteMethod(this.id);
        }
        public void updateReply()
        {
            if (this.id != 0)
            {
                try
                {
                    this.n_isR = 1;
                    this.n_reply = n_reply;
                    this.n_rdate = System.DateTime.Now;
                    this.Update();
                    //comfun.UpdateBySQL("update B2C_note set n_hits=n_hits+1 where id=" + this.id);
                }
                finally { }
            }
        }
        #endregion

        #region "静态方法"
        /// <summary>
        /// 一次彻底删除一组文档资料
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_note where id in (" + _ids + ")";
            try
            {
                comfun.UpdateBySQL(sql);
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        public static int setIsActive(string _ids)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_note set n_isactive= -1 * (n_isActive - 1) where id in (" + _ids + ")");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 设置是否删除
        /// </summary>
        /// <param name="_cid"></param>
        public static int setIsDel(string _ids)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_note set n_isdel= -1 * (n_isdel - 1) where id in ('" + _ids + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

        /// <summary>
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_note where " + _sql + " order by id desc"); // and cityID=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select * from B2C_note order by id desc"); // where cityid=0
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable GetList(string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select * from B2C_note where "+_sql+" order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable GetList(int _currentpage, string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_note where " + _sql + " order by id desc"); // and cityID=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


    }

}
