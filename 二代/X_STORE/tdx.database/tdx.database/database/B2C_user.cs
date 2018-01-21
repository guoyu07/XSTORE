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
using System.Web.SessionState;
using Creatrue.kernel;

namespace tdx.database
{
    public class B2C_user 
    {
        public int u_id = 0;
        public int u_vip=0;
        public string u_name = "";//用户名
        public string u_psw = "";//密码
        public string u_mail = "";//Email地址
        public string u_question = ""; //密码问题
        public string u_answer = ""; //密码答案
        public string u_rights = "";//权限记录
        public string u_area_rights = "";//地区权限
         
        public DateTime  u_logontime = System.DateTime.Now;//最近登录时间
        public DateTime u_regtime = System.DateTime.Now;//注册时间
        public int u_isactive = 1;//是否启用
        public int u_hits = 0;//浏览次数
        public string u_remarks = "";//备注信息

        //便于显示的字段内容
        public string isactivename = "启动";
        //用于密码修改或验证
        private string u_psw_old = "";

        public B2C_user() { }
        public B2C_user(int _id)
        {
            u_id = _id;
            this.LoadData();
        }
        public B2C_user(string _uname)
        {
            this.u_name = _uname;
            this.u_id = 0;
            this.LoadData();
        }

        #region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select *";           
            _sql += " from b2c_user where 1=1";
            if (this.u_id != 0)
            {
                _sql += " and u_id=" + this.u_id;
            }
            else if (this.u_name != "")
            {
                _sql += " and u_name='" + this.u_name.Trim() + "'";
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
                throw (new Exception("B2C_user取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_user没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                u_id = Convert.IsDBNull(dr["u_id"]) ? 0 : Convert.ToInt32(dr["u_id"]);
                u_vip = Convert.IsDBNull(dr["u_vip"]) ? 0 : Convert.ToInt32(dr["u_vip"]);
                u_name = Convert.IsDBNull(dr["u_name"]) ? "" : Convert.ToString(dr["u_name"]);
                u_psw_old = Convert.IsDBNull(dr["u_psw"]) ? "" : Convert.ToString(dr["u_psw"]);
                u_mail = Convert.IsDBNull(dr["u_mail"]) ? "" : Convert.ToString(dr["u_mail"]);
                u_question = Convert.IsDBNull(dr["u_question"]) ? "" : Convert.ToString(dr["u_question"]);
                u_answer = Convert.IsDBNull(dr["u_answer"]) ? "" : Convert.ToString(dr["u_answer"]);
                u_rights = Convert.IsDBNull(dr["u_rights"]) ? "" : Convert.ToString(dr["u_rights"]);
                u_area_rights = Convert.IsDBNull(dr["u_area_rights"]) ? "" : Convert.ToString(dr["u_area_rights"]);

                u_logontime = Convert.IsDBNull(dr["u_logontime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["u_logontime"]);
                u_regtime = Convert.IsDBNull(dr["u_regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["u_regtime"]);

                u_isactive = Convert.IsDBNull(dr["u_isactive"]) ? 1 : Convert.ToInt32(dr["u_isactive"]);
                u_hits = Convert.IsDBNull(dr["u_hits"]) ? 0 : Convert.ToInt32(dr["u_hits"]);

                 //
                isactivename = (u_isactive == 1 ? "启动" : "停止");

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(int _uvip,string _uname, string _upsw, string _uquestion, string _uanswer, string _umail,string _uremarks)
        {
            if (!string.IsNullOrEmpty(_uname) && !string.IsNullOrEmpty (_upsw))
            {
                u_name = _uname;
                u_psw = _upsw;
            }
            else
            {
                throw new NotSupportedException("请输入用户名和密码");
            }
            string sql = "insert into B2C_user (u_vip,u_name,u_psw,u_mail,u_question,u_answer,u_remarks) values (@u_vip,@u_name,@u_psw,@u_mail,@u_question,@u_answer,@u_remarks)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@u_vip", _uvip), 
                    new SqlParameter("@u_name", _uname), 
                    new SqlParameter("@u_psw", comEncrypt.GetMD5 (_upsw)),
                    new SqlParameter("@u_mail", _umail),
                    new SqlParameter("@u_question", _uquestion),
                    new SqlParameter("@u_answer", _uanswer),
                    new SqlParameter("@u_remarks", _uremarks)};

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
        private void myUpdateMethod(int _uvip, string _uname, string _upsw, string _uquestion, string _uanswer, string _umail, string _uremarks, int _id)
        {
            //if (!string.IsNullOrEmpty(_uname) && !string.IsNullOrEmpty(_upsw))
            //{
            //    u_name = _uname;
            //    u_psw = _upsw;
            //}
            //else
            //{
            //    throw new NotSupportedException("请输入用户名和密码");
            //}
            string sql = "update B2C_user set u_vip=@u_vip,u_name=@u_name,u_psw=@u_psw,u_mail=@u_mail,u_question=@u_question,u_answer=@u_answer,u_remarks=@u_remarks where u_id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@u_vip", _uvip), 
                    new SqlParameter("@u_name", _uname), 
                    new SqlParameter("@u_psw", (_upsw.Trim()==""?u_psw_old : comEncrypt.GetMD5 (_upsw))),
                    new SqlParameter("@u_mail", _umail),
                    new SqlParameter("@u_question", _uquestion),
                    new SqlParameter("@u_answer", _uanswer),
                    new SqlParameter("@u_remarks", _uremarks),
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
                throw new NotSupportedException("没有取得用户ID号");
            }
            else
            {
                string sql = "delete from B2C_user where u_id=" + _id;

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
            u_id = 0;
            u_vip = 0;
            u_name = "";
            u_psw = "";

            u_psw_old = "";

            u_mail = "";
            u_question = ""; 
            u_answer = "";
            u_rights = "";
            u_area_rights = "";

            u_logontime = System.DateTime.Now;
            u_regtime = System.DateTime.Now;
            u_isactive = 1;
            u_hits = 0;
            u_remarks = "";

            isactivename = "启动";
        }
        public void Update()
        {
            if (this.u_id != 0)
            {
                this.myUpdateMethod(this.u_vip, this.u_name, this.u_psw, this.u_question, this.u_answer, this.u_mail, this.u_remarks, this.u_id);
            }
            else
            {
                this.myInsertMethod(this.u_vip,this.u_name,this.u_psw,this.u_question ,this.u_answer ,this.u_mail,this.u_remarks );
            }
        }
        public void Delete()
        {
            if (this.u_id != 0)
                this.myDeleteMethod(this.u_id);
        }

        public void updateHits()
        {
            if (this.u_id != 0)
            {
                try
                {
                    comfun.UpdateBySQL("update b2c_user set u_hits=u_hits+1,u_logontime=getDate() where u_id=" + this.u_id);
                }
                finally { }
            }
        }
        public void updateRights()
        {
            if (this.u_id != 0)
            {
                try
                {
                    comfun.UpdateBySQL("update b2c_user set u_rights='" + u_rights + "',u_area_rights='" + u_area_rights + "' where u_id=" + this.u_id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Boolean checkRights(int _uid, string _rightsNeed)
        {
            if (this.u_id != 0)
            {
                if (-1 == (this.u_rights.IndexOf("," + _rightsNeed + ",")))
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        public int checkLogon(string _pswNeed)
        {
            int result = 0;
            if (this.u_id != 0)
            {
                if (comEncrypt.GetMD5(_pswNeed) != this.u_psw_old)
                    result = -2; //密码不不正确
                else
                    result = 1;//密码正确，登录成功;
            }
            else
                result = -1;//用户名不存在

            if (result == 1)
            {//如果登录成功,则设置session
                string[] uInfo = { this.u_id.ToString(), this.u_name, this.u_rights, this.u_area_rights };
                System.Web.HttpContext.Current.Session["uInfo"] = uInfo;
                this.updateHits();
            }

            return result;

        }
        #endregion

        #region "静态方法"
        /// <summary>
        /// 一次彻底删除一组用户
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_user where u_id in (" + _ids + ")";
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
                res = comfun.UpdateBySQL("update B2C_user set u_isactive= -1 * (u_isActive - 1) where u_id in (" + _ids + ")");
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
        public static DataTable GetList(int currentpage,string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_user where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_user where " + _sql + "");
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
                dt = comfun.GetDataTableBySQL("select * from B2C_user order u_id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static Boolean Auth()
        {
            if (System.Web.HttpContext.Current.Session["uInfo"] == null)
                return false;

            string[] _username = (string[])System.Web.HttpContext.Current.Session["uInfo"];
            if (_username == null)
                return false;
            if (_username[0] == null || _username[0].ToString().Trim() == "" || _username[0].ToString() == String.Empty)
                return false;

            return true;

        }        
    }
}
