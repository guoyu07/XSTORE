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
    public class zagt_user
    {
        #region *****构造函数*****
        public zagt_user()
        { }
        public zagt_user(int _id)
        {
            u_id = _id;
            this.LoadData();
        }
        public zagt_user(string _user)
        {
            u_name = _user;
            this.LoadData();
        }
        #endregion

        public int u_id = 0;
        public string u_no = string.Empty;//代理商编号
        public int u_vip = 0;//代理商等级
        public string u_name = string.Empty;//用户名
        public string u_psw = string.Empty;//密码
        public string u_mail = string.Empty;//Email
        public string u_question = string.Empty;//找回密码的问题
        public string u_answer = string.Empty;//找回密码的答案
        public string u_rights = string.Empty;//代理商权限
        public string u_area_rights = string.Empty;
        public DateTime u_logontime = System.DateTime.Now;//最近登录时间
        public DateTime u_regtime = System.DateTime.Now;//注册时间
        public int u_hits = 0;//登录次数
        public int u_isactive = 1;//是否激活
        public double u_zhekou = 0;//给下级代理商的价格加价率
        public string u_remarks = string.Empty;//备注
        public string u_randrom = string.Empty;
        public int cityID = 0;//所属的代理商

        private void LoadData()
        {
            StringBuilder strSql = new StringBuilder();
            if (u_name != "")
                strSql.AppendFormat("select * from zagt_user where u_name='{0}'", u_name);
            else
                strSql.AppendFormat("select * from zagt_user where u_id={0}", u_id);

            DataTable dt = comfun.GetDataTableBySQL(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                u_id = Convert.IsDBNull(dt.Rows[0]["u_id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["u_id"]);
                u_no = Convert.IsDBNull(dt.Rows[0]["u_no"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_no"]);
                u_vip = Convert.IsDBNull(dt.Rows[0]["u_vip"]) ? 0 : Convert.ToInt32(dt.Rows[0]["u_vip"]);
                u_name = Convert.IsDBNull(dt.Rows[0]["u_name"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_name"]);
                u_psw = Convert.IsDBNull(dt.Rows[0]["u_psw"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_psw"]);
                u_mail = Convert.IsDBNull(dt.Rows[0]["u_mail"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_mail"]);
                u_question = Convert.IsDBNull(dt.Rows[0]["u_question"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_question"]);
                u_answer = Convert.IsDBNull(dt.Rows[0]["u_answer"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_answer"]);
                u_rights = Convert.IsDBNull(dt.Rows[0]["u_rights"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_rights"]);
                u_area_rights = Convert.IsDBNull(dt.Rows[0]["u_rights"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_area_rights"]);
                u_logontime = Convert.IsDBNull(dt.Rows[0]["u_logontime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["u_logontime"]);
                u_regtime = Convert.IsDBNull(dt.Rows[0]["u_regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["u_regtime"]);
                u_hits = Convert.IsDBNull(dt.Rows[0]["u_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["u_hits"]);
                u_isactive = Convert.IsDBNull(dt.Rows[0]["u_isactive"]) ? 0 : Convert.ToInt32(dt.Rows[0]["u_isactive"]);
                u_zhekou = Convert.IsDBNull(dt.Rows[0]["u_zhekou"]) ? 0 : Convert.ToDouble(dt.Rows[0]["u_zhekou"]);
                u_remarks = Convert.IsDBNull(dt.Rows[0]["u_remarks"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_remarks"]);
                u_randrom = Convert.IsDBNull(dt.Rows[0]["u_randrom"]) ? string.Empty : Convert.ToString(dt.Rows[0]["u_randrom"]);
                cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityID"]);
            }
            else
            {
                throw new NotSupportedException("zagt_user：" + u_id + "不存在");
            }
        }

        private void MyInsertMethod(string _u_no, int _u_vip, string _u_name, string _u_psw, string _u_mail, string _u_question, string _u_answer, string _u_rights, string _u_area_rights, DateTime _u_logontime, DateTime _u_regtime, int _u_hits, int _u_isactive, double _u_zhekou, string _u_remarks, int _cityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into zagt_user (u_no,u_vip,u_name,u_psw,u_mail,u_question,u_answer,u_rights,u_area_rights,u_logontime,u_regtime,u_hits,u_isactive,u_zhekou,u_remarks,cityID) values ");
            strSql.Append("(@u_no,@u_vip,@u_name,@u_psw,@u_mail,@u_question,@u_answer,@u_rights,@u_area_rights,@u_logontime,@u_regtime,@u_hits,@u_isactive,@u_zhekou,@u_remarks,@cityID)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@u_no",_u_no),
                new SqlParameter("@u_vip",_u_vip),
                new SqlParameter("@u_name",_u_name),
                new SqlParameter("@u_psw",_u_psw),
                new SqlParameter("@u_mail",_u_mail),
                new SqlParameter("@u_question",_u_question),
                new SqlParameter("@u_answer",_u_answer),
                new SqlParameter("@u_rights",_u_rights),
                new SqlParameter("@u_area_rights",_u_area_rights),
                new SqlParameter("@u_logontime",_u_logontime),
                new SqlParameter("@u_regtime",_u_regtime),
                new SqlParameter("@u_hits",_u_hits),
                new SqlParameter("@u_isactive",_u_isactive),
                new SqlParameter("@u_zhekou",_u_zhekou),
                new SqlParameter("@u_remarks",_u_remarks),
                new SqlParameter("@cityID",_cityID)
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

        private void MyUpdateMethod(int _u_id, int _u_vip, string _u_name, string _u_psw, string _u_mail, string _u_question, string _u_answer, string _u_rights, string _u_area_rights, DateTime _u_logontime, int _u_hits, int _u_isactive, double _u_zhekou, string _u_remarks)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update zagt_user set ");
            strSql.Append("u_vip=@u_vip,");
            strSql.Append("u_name=@u_name,");
            strSql.Append("u_psw=@u_psw,");
            strSql.Append("u_mail=@u_mail,");
            strSql.Append("u_question=@u_question,");
            strSql.Append("u_answer=@u_answer,");
            strSql.Append("u_rights=@u_rights,");
            strSql.Append("u_area_rights=@u_area_rights,");
            strSql.Append("u_logontime=@u_logontime,");
            strSql.Append("u_hits=@u_hits,");
            strSql.Append("u_isactive=@u_isactive,");
            strSql.Append("u_zhekou=@u_zhekou,");
            strSql.Append("u_remarks=@u_remarks");
            strSql.Append(" where u_id=@id");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@u_vip",_u_vip),
                new SqlParameter("@u_name",_u_name),
                new SqlParameter("@u_psw",_u_psw),
                new SqlParameter("@u_mail",_u_mail),
                new SqlParameter("@u_question",_u_question),
                new SqlParameter("@u_answer",_u_answer),
                new SqlParameter("@u_rights",_u_rights),
                new SqlParameter("@u_area_rights",_u_area_rights),
                new SqlParameter("@u_logontime",_u_logontime.ToString()),
                new SqlParameter("@u_hits",_u_hits),
                new SqlParameter("@u_isactive",_u_isactive),
                new SqlParameter("@u_zhekou",_u_zhekou),
                new SqlParameter("@u_remarks",_u_remarks),
                new SqlParameter("@id",_u_id)
        };
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
            u_id = 0;

            u_no = string.Empty;//代理商编号
            u_vip = 0;//代理商等级
            u_name = string.Empty;//用户名
            u_psw = string.Empty;//密码
            u_mail = string.Empty;//Email
            u_question = string.Empty;//找回密码的问题
            u_answer = string.Empty;//找回密码的答案
            u_rights = string.Empty;//代理商权限
            u_area_rights = string.Empty;
            u_logontime = System.DateTime.Now;//最近登录时间
            u_regtime = System.DateTime.Now;//注册时间
            u_hits = 0;//登录次数
            u_isactive = 0;//是否激活
            u_zhekou = 0;//给下级代理商的价格加价率
            u_remarks = string.Empty;//备注
        }
        public void Update()
        {
            if (u_id == 0)
            {
                this.MyInsertMethod(u_no, u_vip, u_name, u_psw, u_mail, u_question, u_answer, u_rights, u_area_rights, u_logontime, u_regtime, u_hits, u_isactive, u_zhekou, u_remarks, cityID);
            }
            else
            {

                this.MyUpdateMethod(u_id, u_vip, u_name, u_psw, u_mail, u_question, u_answer, u_rights, u_area_rights, u_logontime, u_hits, u_isactive, u_zhekou, u_remarks);
            }
        }

        public void Update(int _id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_user set u_logontime=getdate() where u_id=@u_id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@u_id", SqlDbType.Int) };
            paras[0].Value = _id;
            try
            {
                new comfun().ExecuteNonQuery(strSql.ToString(), paras);
            }
            catch (Exception ex)
            { throw new NotSupportedException(ex.Message); }
        }

        /// <summary>
        /// 更新pt_isactive字段为0
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsactive(int _c_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_user set u_isactive=-1*(u_isactive-1) where u_id=@c_id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@c_id", _c_id) };
            new comfun().ExecuteNonQuery(strSql.ToString(), paras);
        }

        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public bool Exists(string _name)
        {
            bool flag = false;
            StringBuilder safeSql = new StringBuilder();
            safeSql.AppendFormat("select count(u_id) from zagt_user where u_name='{0}'", _name);
            DataTable dt = comfun.GetDataTableBySQL(safeSql.ToString());
            if (Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 返回一个用户
        /// </summary>
        /// <param name="_name">用户名</param>
        /// <param name="_pwd">密码</param>
        /// <returns></returns>
        public DataTable GetTopUser(string _name, string _pwd)
        {
            StringBuilder safeSql = new StringBuilder();
            safeSql.AppendFormat("select * from (select row_number() over(order by u_id asc) as id ,zagt_user.* from zagt_user where u_name='{0}' and u_psw='{1}') where id=1", _name.Replace("'", ""), _pwd.Replace("'", ""));
            //SqlParameter[] paras = new SqlParameter[] {
            //new SqlParameter("@u_name",_name),
            //new SqlParameter("@u_psw",_pwd)
            //};
            DataTable dt = comfun.GetDataTableBySQL(safeSql.ToString());
            return dt;
        }

        /// <summary>
        /// 更新随机数
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_gid">Guid</param>
        public void UpdateRandom(int _id, string _gid)
        {
            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("update zagt_user set u_randrom=@u_randrom where u_id=@u_id");
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@u_randrom",_gid),
                new SqlParameter("@u_id",_id)
            };
            try
            {
                new comfun().ExecuteNonQuery(updateSql.ToString(), pars);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        /// <summary>
        /// 获取代理商的下级代理商
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_cno"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int _uid, string _uno)
        {
            StringBuilder safeSql = new StringBuilder();
            safeSql.AppendFormat("select * from zagt_user where u_no like '{0}%' and length(u_no)=length('{0}')+3 and u_id!={1}", _uno, _uid);
            DataTable dt = comfun.GetDataTableBySQL(safeSql.ToString());
            return dt;
        }

        public int checkLogon(string _pswNeed)
        {
            int result = 0;

            if (this.u_id != 0)
            {
                if (comEncrypt.GetMD5(_pswNeed) != this.u_psw)
                    result = -2; //密码不不正确
                else
                    result = 1;//密码正确，登录成功;
            }
            else
                result = -1;//用户名不存在   
            if (result == 1)
            {//如果登录成功,则设置session
                string[] uInfo = { this.u_id.ToString(), this.u_name, this.u_vip.ToString(), this.u_zhekou.ToString(), this.u_no.ToString() };
                System.Web.HttpContext.Current.Session["uInfo"] = uInfo;
                System.Web.HttpContext.Current.Session["uID"] = this.u_id.ToString();
                this.updateHits();
            }

            return result;

        }
        public void updateHits()
        {
            if (this.u_id != 0)
            {
                try
                {
                    comfun.UpdateBySQL("update zagt_user set u_hits=u_hits+1,u_logontime=getDate() where u_id=" + this.u_id);
                }
                finally { }
            }
        }
//我的下级代理数
        public int getMyAgentCount()
        {
            string _sql=" cityID="+this.u_id;
            return comfun.GetFieldCount("zagt_user", _sql);

        }
        //给下级增加产品并定价
        public void goodsFixPrice(int agentID,double agentZheKou)
        {
            string _sql = "select *, " + agentZheKou + "*zagt_user_price.gu_price as newguprice from zagt_user_price where uid=" + u_id + "";
            DataTable table = comfun.GetDataTableBySQL(_sql);
            foreach ( DataRow row in table.Rows)
            { 
             zagt_user_price user_price= new zagt_user_price();
                user_price.userid=agentID;
                user_price.gu_price = Convert.IsDBNull(row[4]) ? 0 : Convert.ToDouble(row[4]);
                user_price.gid = Convert.IsDBNull(row[0]) ? 0 : Convert.ToInt32(row[0]);//int.Parse(row["gid"].ToString());
                //string _newprice = row["newguprice"] == null ? "0" : row["newguprice"].ToString();
                //user_price.gu_price = double.Parse(_newprice);
                user_price.Update();
            }


        }

        #endregion
    }
}