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
using tdx.kernel;

namespace tdx.database
{
    public class B2C_Cards
    {
        public int id = 0;
        public string c_no = "";//卡号
        public string c_psw = "";//密码
        public string c_name = "";//姓名
        public DateTime c_wdate = System.DateTime.Now;//发卡时间
        public DateTime c_rdate = DateTime.Parse("1900-01-01");//激活时间
        public string c_rip = "";//激活IP  
        public string c_rway = "";//激活途径
        public int c_rflag=0;//标志
        public DateTime regdate = System.DateTime.Now;//信息添加时间  

        public B2C_Cards() { }
        public B2C_Cards(int _id)
        {
            id = _id;
            this.LoadData();
        }
        public B2C_Cards(string _cno)
        {
            c_no = _cno;
            this.LoadData();
        }

        #region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select * from B2C_Cards where 1=1";
            if (this.c_no.Trim() != "")
            {
                _sql += " and c_no='" + this.c_no + "'";
            }
            else if (this.id != 0)
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
                throw (new Exception("B2C_Cards取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_Cards没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                c_no = Convert.IsDBNull(dr["c_no"]) ? "" : Convert.ToString(dr["c_no"]);
                c_psw = Convert.IsDBNull(dr["c_psw"]) ? "" : Convert.ToString(dr["c_psw"]);
                c_name = Convert.IsDBNull(dr["c_name"]) ? "" : Convert.ToString(dr["c_name"]);
                c_wdate = Convert.IsDBNull(dr["c_wdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["c_wdate"]);
                c_rdate = Convert.IsDBNull(dr["c_rdate"]) ? DateTime.Parse("1900-01-01") : Convert.ToDateTime(dr["c_rdate"]);
                c_rip = Convert.IsDBNull(dr["c_rip"]) ? "" : Convert.ToString(dr["c_rip"]);
                c_rway = Convert.IsDBNull(dr["c_rway"]) ? "" : Convert.ToString(dr["c_rway"]);
                c_rflag = Convert.IsDBNull(dr["c_rflag"]) ? 0 : Convert.ToInt32(dr["c_rflag"]);  
               
                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);
              
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(string _cno, string _cpsw, string _cname, DateTime _cwdate, DateTime _crdate, string _crip, string _crway)
        {
            if (!string.IsNullOrEmpty(_cno))
            {
                c_no = _cno;
            }
            else
            {
                throw new NotSupportedException("请输入卡号");
            }
            string sql = "insert into B2C_Cards (c_no,c_psw,c_name,c_wdate,c_rdate,c_rip,c_rway)";
            sql = sql + " values (@c_no,@c_psw,@c_name,@c_wdate,@c_rdate,@c_rip,@c_rway)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@c_no", _cno), 
                    new SqlParameter("@c_psw", _cpsw), 
                    new SqlParameter("@c_name", _cname), 
                    new SqlParameter("@c_wdate", _cwdate),
                    new SqlParameter("@c_rdate", _crdate),
                    new SqlParameter("@c_rip", _crip),
                    new SqlParameter("@c_rway", _crway) };

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
        private void myUpdateMethod(string _cno, string _cpsw, string _cname, DateTime _cwdate, DateTime _crdate, string _crip, string _crway, int _id)
        {
            if (!string.IsNullOrEmpty(_cno))
            {
                c_no = _cno;
            }
            else
            {
                throw new NotSupportedException("请输入卡号");
            }
            string sql = "update B2C_Cards set c_no=@c_no,c_psw=@c_psw,c_name=@c_name,c_wdate=@c_wdate,c_rdate=@c_rdate,c_rip=@c_rip,c_rway=@c_rway where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@c_no", _cno), 
                    new SqlParameter("@c_psw", _cpsw), 
                    new SqlParameter("@c_name", _cname), 
                    new SqlParameter("@c_wdate", _cwdate),
                    new SqlParameter("@c_rdate", _crdate),
                    new SqlParameter("@c_rip", _crip),
                    new SqlParameter("@c_rway", _crway),
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
                throw new NotSupportedException("没有取得卡号ID号");
            }
            else
            {
                string sql = "delete from B2C_Cards where id=" + _id;

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
            c_no = "";
            c_psw = "";
            c_name = "";
            c_wdate = System.DateTime.Now;
            c_rdate = DateTime.Parse("1900-01-01");
            c_rip = "";
            c_rway = "";
            c_rflag = 0;
            regdate = System.DateTime.Now;   
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.c_no, this.c_psw, this.c_name, this.c_wdate, this.c_rdate, this.c_rip, this.c_rway,this.id);
            }
            else
            {
                this.myInsertMethod(this.c_no, this.c_psw, this.c_name, this.c_wdate, this.c_rdate, this.c_rip, this.c_rway);
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
                    comfun.UpdateBySQL("update B2C_Cards set c_rdate=getDate(),c_rflag=1 where id=" + this.id);
                }
                finally { }
            }
        }
        public void updateReply(DateTime _rdate, string _rip, string _rway)
        {
            if (this.id != 0)
            {
                try
                {
                    comfun.UpdateBySQL("update B2C_Cards set c_rdate='" + _rdate + "',c_rip='" + _rip + "',c_rway='" + _rway + "',c_rflag=1 where id=" + this.id);
                }
                catch (Exception ex)
                {
                   // throw new Exception("update B2C_Cards set c_rdate=" + _rdate + ",c_rip='" + _rip + "',c_rway='" + _rway + "',c_rflag=1 where id=" + this.id);
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

            string sql = "delete from B2C_Cards where id in (" + _ids + ")";
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
                res = comfun.UpdateBySQL("update B2C_Cards set c_rflag= -1 * (c_rflag - 1),c_rdate=getDate() where id in (" + _ids + ")");
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Cards where " + _sql + " order by id desc");
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Cards where " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(int _currentpage, string _dzd, string _sql,int pagesize)
        {
            DataTable dt = new DataTable();
            try
            {
                string _sql2 = "select " + _dzd + ",(row_number() over(order by id)) as rown from B2C_Cards where " + _sql ;
                _sql2 = "with a as (" + _sql2 + ") select top " + pagesize + " * from a where rown>" + (_currentpage - 1) * pagesize + " order by rown";
                dt = comfun.GetDataTableBySQL(_sql2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


    }

}
