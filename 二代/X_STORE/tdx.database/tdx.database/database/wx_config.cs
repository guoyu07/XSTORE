using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Creatrue.kernel;

namespace tdx.database.database
{
    public class wx_config
    {

            public int id = 0;
            public string M_company = "";//公司
            public string M_tel = "";//电话
            public string M_mobile = "";//电话
            public string M_email = "";//Email地址
            public string M_QQ = "";//QQ
            public string M_map = "";//百度地图地址
            public string wx_name = "";//微信号
            public string wx_nichen = "";//昵称
            public int wx_theme = 1;//模板  
            public string wx_GNTheme = "appv";//功能模板

            public wx_config()
            {
                this.LoadData();
            }
            public wx_config(string _uname)
            {
                this.id = 0;
                this.LoadData();
            }

            #region "私有方法"
            private void LoadData() //获取数值
            {
                string _sql = "select * from wx_config";

                DataTable dt = comfun.GetDataTableBySQL(_sql);
                if (dt.Rows.Count > 1)
                {
                    throw (new Exception("wx_config取值不唯一."));
                }
                else if (dt.Rows.Count < 1)
                {
                    throw (new Exception("wx_config没有找到."));
                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                    M_company = Convert.IsDBNull(dr["M_company"]) ? "" : Convert.ToString(dr["M_company"]);
                    M_tel = Convert.IsDBNull(dr["M_tel"]) ? "" : Convert.ToString(dr["M_tel"]);
                    M_mobile = Convert.IsDBNull(dr["M_mobile"]) ? "" : Convert.ToString(dr["M_mobile"]);
                    M_email = Convert.IsDBNull(dr["M_email"]) ? "" : Convert.ToString(dr["M_email"]);
                    M_QQ = Convert.IsDBNull(dr["M_QQ"]) ? "" : Convert.ToString(dr["M_QQ"]);
                    M_map = Convert.IsDBNull(dr["M_map"]) ? "" : Convert.ToString(dr["M_map"]);
                    wx_name = Convert.IsDBNull(dr["wx_name"]) ? "" : Convert.ToString(dr["wx_name"]);
                    wx_nichen = Convert.IsDBNull(dr["wx_nichen"]) ? "" : Convert.ToString(dr["wx_nichen"]);
                    wx_theme = Convert.IsDBNull(dr["wx_theme"]) ? 1 : Convert.ToInt32(dr["wx_theme"]);
                    wx_GNTheme = Convert.IsDBNull(dr["wx_GNTheme"]) ? "appv" : Convert.ToString(dr["wx_GNTheme"]);

                    dr = null;
                }
                dt.Dispose();
                dt = null;
            }

            private void myInsertMethod(string _M_company, string _M_tel, string _M_mobile, string _M_email, string _M_QQ, string _wx_name, int _wx_theme, string _M_nichen, string _wx_GNtheme, string _m_map)//, int _cityID
            {

                string sql = "insert into B2C_worker (M_company,M_tel,M_mobile,M_email,M_QQ,wx_name,wx_theme,wx_nichen,wx_GNtheme,M_map)";
                sql += "values (@M_company,@M_tel,@M_mobile,@M_email,@M_QQ,@wx_name,@wx_theme,@wx_nichen,@wx_GNtheme,@M_map)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@M_company", _M_company), 
                    new SqlParameter("@M_tel", _M_tel), 
                    new SqlParameter("@M_mobile", _M_mobile), 
                    new SqlParameter("@M_email", _M_email), 
                    new SqlParameter("@M_QQ", _M_QQ), 
                    new SqlParameter("@wx_name", _wx_name), 
                    new SqlParameter("@wx_theme", _wx_theme), 
                    new SqlParameter("@wx_nichen", _M_nichen), 
                    new SqlParameter("@wx_GNtheme", _wx_GNtheme),
                    new SqlParameter("@M_map",_m_map)
            };

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
            private void myUpdateMethod(string _M_company, string _M_tel, string _M_mobile, string _M_email, string _M_QQ, string _wx_name, int _wx_theme,  string _M_nichen, string _wx_GNtheme,  string _m_map) //, int _cityID
            {
                string sql = "update B2C_worker set M_company=@M_company,M_tel=@M_tel,M_mobile=@M_mobile,M_email=@M_email,M_QQ=@M_QQ,wx_name=@wx_name,wx_theme=@wx_theme," + //cityID=@cityID,
                    "wx_nichen=@wx_nichen,wx_GNtheme=@wxGNtheme,M_map=@M_map";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@M_company", _M_company), 
                    new SqlParameter("@M_tel", _M_tel), 
                    new SqlParameter("@M_mobile", _M_mobile), 
                    new SqlParameter("@M_email", _M_email), 
                    new SqlParameter("@M_QQ", _M_QQ), 
                    new SqlParameter("@wx_name", _wx_name), 
                    new SqlParameter("@wx_theme", _wx_theme), 
                    new SqlParameter("@wx_nichen", _M_nichen), 
                    new SqlParameter("@wxGNtheme", _wx_GNtheme),
                    new SqlParameter("@M_map",_m_map)
            };
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
                    string sql = "delete from B2C_worker where id=" + _id;

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
                M_company = "";
                M_email = "";
                M_tel = "";
                M_mobile = "";
                M_QQ = "";
                M_map = "";
                wx_name = "";
                wx_nichen = "";
                wx_theme = 1;
                wx_GNTheme = "apps";
            }
            public void Update()
            {
                if (this.id != 0)
                {
                    this.myUpdateMethod(this.M_company, this.M_tel, this.M_mobile, this.M_email,this.M_QQ, this.wx_name, this.wx_theme,this.wx_nichen, this.wx_GNTheme, this.M_map);// this.cityID,
                }
                else
                {
                    this.myInsertMethod(this.M_company, this.M_tel, this.M_mobile, this.M_email, this.M_QQ, this.wx_name, this.wx_theme, this.wx_nichen, this.wx_GNTheme, this.M_map);// this.cityID,
                }
            }
            public void Delete()
            {
                if (this.id != 0)
                    this.myDeleteMethod(this.id);
            }
            #endregion





            #region "静态方法"

            public static string currentTheme()
            {
                string _theme = "black";
                if (System.Web.HttpContext.Current.Session["wInfo"] != null)
                {
                    string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
                    _theme = wInfo[3].ToString();
                }
                return _theme;
            }
            public static string currentGNTheme()
            {
                string _theme = "appv";
                if (System.Web.HttpContext.Current.Session["wInfo"] != null)
                {
                    string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
                    _theme = wInfo[5].ToString();
                }
                return _theme;
            }
            public static string currentWWX()
            {
                string _theme = "appv";
                if (System.Web.HttpContext.Current.Session["wInfo"] != null)
                {
                    string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
                    _theme = wInfo[4].ToString();
                }
                return _theme;
            }
            public static string currentName()
            {
                string _theme = "appv";
                if (System.Web.HttpContext.Current.Session["wInfo"] != null)
                {
                    string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
                    _theme = wInfo[1].ToString();
                }
                return _theme;
            }
            #endregion

            /// <summary>
            /// 此处为条件查询
            /// </summary>
            public static DataTable GetList(int currentpage, string _dzd, string _sql)
            {
                DataTable dt = new DataTable();
                try
                {
                    dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_worker where " + _sql + " order by id desc");
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
                    dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_worker where " + _sql + "");
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
                    dt = comfun.GetDataTableBySQL("select * from B2C_worker order id desc");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }

            public static Boolean Auth()
            {
                if (System.Web.HttpContext.Current.Session["wInfo"] == null)
                    return false;

                string[] _username = (string[])System.Web.HttpContext.Current.Session["wInfo"];
                if (_username == null)
                    return false;
                if (_username[0] == null || _username[0].ToString().Trim() == "" || _username[0].ToString() == String.Empty)
                    return false;

                return true;

            }

        }

    
}
