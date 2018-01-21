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
    public class B2C_worker
    {
        //public int id = 0;
        //public int M_vip = 0; //等级
        //public string Mvipname = "";//等级名称
        //public string M_name = "";//用户名
        //public string M_psw = "";//密码
        //public string M_question = "";//问题
        //public string M_answer = "";//答案
        //public DateTime M_logontime = System.DateTime.Now;//最近登录时间
        //public DateTime regtime = System.DateTime.Now;//注册时间

        //public int M_hits = 0;//登录次数
        //public DateTime M_Bdate = System.DateTime.Now;
        //public DateTime M_Edate = System.DateTime.Now;
        //public DateTime M_Udate = System.DateTime.Now;

        //public string M_company = "";//公司
        //public string M_tel = "";//电话
        //public string M_mobile = "";//电话
        //public string M_email = "";//Email地址
        //public string M_url = "";//网址
        //public string M_QQ = "";//QQ
        //public string M_map = "";//百度地图地址

        //public string wx_name = "";//微信号
        //public string wx_nichen = "";//昵称
        //public string wx_2wm = "";//二维码
        //public string wx_ID = "";//原始码
        //public string wx_DID = "";//开发者ID
        //public string wx_Dpsw = "";//开发者密码
        //public int wx_theme = 1;//模板  
        //public int wx_theme2 = 1;
        //public int wx_theme3 = 1;
        //public int wx_theme4 = 1;//快捷方式模板

        //public string wx_GNTheme = "appv";//功能模板
        //public int wx_FirstIsGif = 1;//关键词回复模式 
        //public int M_lx = 2;//默认商城模板
        //public int M_isactive = 0;//是否启用
        //public int M_isdel = 0;//是否删除
        ////public int cityID = 0;//所属的代理商

        //public string hy_no = "";//行业编码
        //public string area_no = "";//所属地区
        ////便于显示的字段内容
        //public string isactivename = "启动";
        //public string isdelname = "未删";
        ////用于密码修改或验证
        //private string M_psw_old = "";

        //public B2C_worker() { }
        //public B2C_worker(int _id)
        //{
        //   this.id = _id;
        //   this.LoadData();
        //}
        //public B2C_worker(string _uname)
        //{
        //    this.M_name = _uname;
        //    this.id = 0;
        //    this.LoadData();
        //}

        //#region "私有方法"
        //private void LoadData() //获取数值
        //{
        //    string _sql = "select *,(select mvip_name from b2c_memvip where b2c_memvip.mvip_id=wx_mp.m_vip) as Mvipname";
        //    _sql += ",(select top 1 wx_name from wx_mp where id=wx_mp.id) as wx_name2";
        //    _sql += ",(select top 1 wx_nichen from wx_mp where id=wx_mp.id) as wx_nichen2";
        //    _sql += ",(select top 1 wx_2wm from wx_mp where id=wx_mp.id) as wx_2wm2";
        //    _sql += ",(select top 1 wx_ID from wx_mp where id=wx_mp.id) as wx_ID2";
        //    _sql += ",(select top 1 wx_DID from wx_mp where id=wx_mp.id) as wx_DID2";
        //    _sql += ",(select top 1 wx_Dpsw from wx_mp where id=wx_mp.id) as wx_Dpsw2";
        //    _sql += " from wx_mp where 1=1";
        //    if (this.id != 0)
        //    {
        //        _sql += " and id=" + this.id;
        //    }
        //    else if (this.M_name != "")
        //    {
        //        _sql += " and M_name='" + this.M_name.Trim() + "'";
        //    }
        //    else
        //    {
        //        //跳出函数前，初始化一下所有字段值
        //        this.AddNew();
        //        return;
        //    }

        //    DataTable dt = comfun.GetDataTableBySQL(_sql);
        //    if (dt.Rows.Count > 1)
        //    {
        //        throw (new Exception("wx_mp取值不唯一."));
        //    }
        //    else if (dt.Rows.Count < 1)
        //    {
        //        throw (new Exception("wx_mp没有找到."));
        //    }
        //    else
        //    {
        //        DataRow dr = dt.Rows[0];
        //        id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
        //        //M_lx = Convert.IsDBNull(dr["M_lx"]) ? 0 : Convert.ToInt32(dr["M_lx"]);
        //        M_name = Convert.IsDBNull(dr["wx_name"]) ? "" : Convert.ToString(dr["wx_name"]);
        //        //M_psw_old = Convert.IsDBNull(dr["M_psw"]) ? "" : Convert.ToString(dr["M_psw"]);
        //        //M_question = Convert.IsDBNull(dr["M_question"]) ? "" : Convert.ToString(dr["M_question"]);
        //        //M_answer = Convert.IsDBNull(dr["M_answer"]) ? "" : Convert.ToString(dr["M_answer"]);
        //        //M_logontime = Convert.IsDBNull(dr["M_logontime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["M_logontime"]);
        //        //regtime = Convert.IsDBNull(dr["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regtime"]);
        //        //M_Bdate = Convert.IsDBNull(dr["M_Bdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["M_Bdate"]);
        //        //M_Udate = Convert.IsDBNull(dr["M_Udate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["M_Udate"]);
        //        //M_Edate = Convert.IsDBNull(dr["M_Edate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["M_Edate"]);

        //        //M_company = Convert.IsDBNull(dr["M_company"]) ? "" : Convert.ToString(dr["M_company"]);
        //        //M_tel = Convert.IsDBNull(dr["M_tel"]) ? "" : Convert.ToString(dr["M_tel"]);
        //        //M_mobile = Convert.IsDBNull(dr["M_mobile"]) ? "" : Convert.ToString(dr["M_mobile"]);
        //        //M_email = Convert.IsDBNull(dr["M_email"]) ? "" : Convert.ToString(dr["M_email"]);
        //        //M_url = Convert.IsDBNull(dr["M_url"]) ? "" : Convert.ToString(dr["M_url"]);
        //        //M_QQ = Convert.IsDBNull(dr["M_QQ"]) ? "" : Convert.ToString(dr["M_QQ"]);
        //        //M_map = Convert.IsDBNull(dr["M_map"]) ? "" : Convert.ToString(dr["M_map"]);

        //        //hy_no = Convert.IsDBNull(dr["hy_no"]) ? "" : Convert.ToString(dr["hy_no"]);
        //        //area_no = Convert.IsDBNull(dr["area_no"]) ? "" : Convert.ToString(dr["area_no"]);

        //        //wx_name = Convert.IsDBNull(dr["wx_name2"]) ? "" : Convert.ToString(dr["wx_name2"]);
        //        //wx_nichen = Convert.IsDBNull(dr["wx_nichen2"]) ? "" : Convert.ToString(dr["wx_nichen2"]);
        //        //wx_2wm = Convert.IsDBNull(dr["wx_2wm2"]) ? "" : Convert.ToString(dr["wx_2wm2"]);
        //        //wx_ID = Convert.IsDBNull(dr["wx_ID2"]) ? "" : Convert.ToString(dr["wx_ID2"]);
        //        //wx_DID = Convert.IsDBNull(dr["wx_DID2"]) ? "" : Convert.ToString(dr["wx_DID2"]);
        //        //wx_Dpsw = Convert.IsDBNull(dr["wx_Dpsw2"]) ? "" : Convert.ToString(dr["wx_Dpsw2"]);
        //        //wx_theme = Convert.IsDBNull(dr["wx_theme"]) ? 1 : Convert.ToInt32(dr["wx_theme"]);
        //        //wx_theme2 = Convert.IsDBNull(dr["wx_theme2"]) ? 1 : Convert.ToInt32(dr["wx_theme2"]);
        //        //wx_theme3 = Convert.IsDBNull(dr["wx_theme3"]) ? 1 : Convert.ToInt32(dr["wx_theme3"]);
        //        //wx_theme4 = Convert.IsDBNull(dr["wx_theme4"]) ? 1 : Convert.ToInt32(dr["wx_theme4"]);

        //        //wx_FirstIsGif = Convert.IsDBNull(dr[wx_FirstIsGif]) ? 1 : Convert.ToInt32(dr["wx_FirstIsGif"]);

        //        //M_isactive = Convert.IsDBNull(dr["M_isactive"]) ? 1 : Convert.ToInt32(dr["M_isactive"]);
        //        //M_isdel = Convert.IsDBNull(dr["M_isdel"]) ? 0 : Convert.ToInt32(dr["M_isdel"]);
        //        //M_hits = Convert.IsDBNull(dr["M_hits"]) ? 0 : Convert.ToInt32(dr["M_hits"]);
        //        //cityID = Convert.IsDBNull(dr["cityID"]) ? 0 : Convert.ToInt32(dr["cityID"]);

        //        //M_vip = Convert.IsDBNull(dr["M_vip"]) ? 0 : Convert.ToInt32(dr["M_vip"]);
        //        //Mvipname = Convert.IsDBNull(dr["Mvipname"]) ? "" : Convert.ToString(dr["Mvipname"]);
        //         //
        //        //isactivename = (M_isactive == 1 ? "启动" : "停止");
        //        //isdelname = (M_isdel == 1 ? "已删" : "未删");

        //        //wx_GNTheme = Convert.IsDBNull(dr["wx_GNTheme"]) ? "apps" : Convert.ToString(dr["wx_GNTheme"]);

        //        dr = null;
        //    }
        //    dt.Dispose();
        //    dt = null;
        //}

        //private void myInsertMethod(string _M_name, string _M_psw, string _M_question, string _M_answer, string _M_company, string _M_tel, string _M_mobile, string _M_email, string _M_url, string _M_QQ, string _wx_name, string _wx_2wm, string _wx_ID, int _wx_theme, int _wx_theme2, int _wx_theme3, int _wx_theme4, int _M_vip, string _M_nichen, string _M_DID, string _M_Dpsw, DateTime _M_Bdate, DateTime _M_Edate, DateTime _M_Udate, int _wx_FirstIsGif, string _wx_GNtheme, string _hy_no, string _area_no, string _m_map, int _M_isactive = 1)//, int _cityID
        //{
        //    if (!string.IsNullOrEmpty(_M_name) && !string.IsNullOrEmpty(_M_psw))
        //    {
        //        M_name = _M_name;
        //        M_psw = _M_psw;
        //    }
        //    else
        //    {
        //        throw new NotSupportedException("请输入用户名和密码");
        //    }
        //    string sql = "insert into B2C_worker (M_name,M_psw,M_question,M_answer,M_company,M_tel,M_mobile,M_email,M_url,M_QQ,wx_name,wx_2wm,wx_ID,wx_theme,wx_theme2,wx_theme3,wx_theme4,M_vip," + //,cityID
        //        "wx_nichen,wx_DID,wx_Dpsw,M_Bdate,M_Edate,M_Udate,wx_FirstIsGif,wx_GNtheme,hy_no,area_no,M_isactive,M_map)";
        //    sql += "values (@M_name,@M_psw,@M_question,@M_answer,@M_company,@M_tel,@M_mobile,@M_email,@M_url,@M_QQ,@wx_name,@wx_2wm,@wx_ID,@wx_theme,@wx_theme2,@wx_theme3,@wx_theme4,@M_vip," +//@cityID,
        //        "@wx_nichen,@wx_DID,@wx_Dpsw,@M_Bdate,@M_Edate,@M_Udate,@wx_FirstIsGif,@wx_GNtheme,@hy_no,@area_no,@M_isactive,@M_map)";
        //    SqlParameter[] paras = new SqlParameter[] { 
        //            new SqlParameter("@M_name", _M_name), 
        //            new SqlParameter("@M_psw", comEncrypt.GetMD5 (_M_psw)),
        //            new SqlParameter("@M_question", _M_question),
        //            new SqlParameter("@M_answer", _M_answer), 
        //            new SqlParameter("@M_company", _M_company), 
        //            new SqlParameter("@M_tel", _M_tel), 
        //            new SqlParameter("@M_mobile", _M_mobile), 
        //            new SqlParameter("@M_email", _M_email), 
        //            new SqlParameter("@M_url", _M_url), 
        //            new SqlParameter("@M_QQ", _M_QQ), 
        //            new SqlParameter("@wx_name", _wx_name), 
        //            new SqlParameter("@wx_2wm", _wx_2wm), 
        //            new SqlParameter("@wx_ID", _wx_ID), 
        //            new SqlParameter("@wx_theme", _wx_theme), 
        //            new SqlParameter("@wx_theme2", _wx_theme2),
        //            new SqlParameter("@wx_theme3", _wx_theme3),
        //            new SqlParameter("@wx_theme4", _wx_theme4),
        //            new SqlParameter("@M_vip", _M_vip), 
        //            //new SqlParameter("@cityID", _cityID), 
        //            new SqlParameter("@wx_nichen", _M_nichen), 
        //            new SqlParameter("@wx_DID", _M_DID), 
        //            new SqlParameter("@wx_Dpsw", _M_Dpsw), 
        //            new SqlParameter("@M_Bdate", _M_Bdate), 
        //            new SqlParameter("@M_Edate", _M_Edate), 
        //            new SqlParameter("@M_Udate", _M_Udate), 
        //            new SqlParameter("@wx_FirstIsGif", _wx_FirstIsGif), 
        //            new SqlParameter("@wx_GNtheme", _wx_GNtheme),
        //            new SqlParameter("@hy_no", _hy_no),
        //            new SqlParameter("@area_no", _area_no),
        //            new SqlParameter("@M_isactive",_M_isactive),
        //            new SqlParameter("@M_map",_m_map)
        //    };

        //    try
        //    {
        //        comfun con = new comfun();
        //        con.ExecuteNonQuery(sql, paras);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new NotSupportedException(ex.Message);
        //    }
        //}
        //private void myUpdateMethod(string _M_name, string _M_psw, string _M_question, string _M_answer, string _M_company, string _M_tel, string _M_mobile, string _M_email, string _M_url, string _M_QQ, string _wx_name, string _wx_2wm, string _wx_ID, int _wx_theme, int _wx_theme2, int _wx_theme3, int _wx_theme4, int _M_vip, int _id, string _M_nichen, string _M_DID, string _M_Dpsw, DateTime _M_Bdate, DateTime _M_Edate, DateTime _M_Udate, int _wx_FirstIsGif, string _wx_GNtheme, string _hy_no, string _area_no, int _M_lx, string _m_map, int _M_isactive = 1) //, int _cityID
        //{
        //    string sql = "update B2C_worker set M_name=@M_name,M_psw=@M_psw,M_question=@M_question,M_answer=@M_answer,M_company=@M_company,M_tel=@M_tel,M_mobile=@M_mobile,M_email=@M_email,M_url=@M_url,M_QQ=@M_QQ,wx_name=@wx_name,wx_2wm=@wx_2wm,wx_ID=@wx_ID,wx_theme=@wx_theme,wx_theme2=@wx_theme2,wx_theme3=@wx_theme3,wx_theme4=@wx_theme4,M_vip=@M_vip," + //cityID=@cityID,
        //        "wx_nichen=@wx_nichen,wx_DID=@wx_DID,wx_Dpsw=@wx_Dpsw,M_Bdate=@M_Bdate,M_Edate=@M_Edate,M_Udate=@M_Udate,wx_FirstIsGif=@wx_FirstIsGif,wx_GNtheme=@wxGNtheme,hy_no=@hy_no,area_no=@area_no,M_isactive=@M_isactive,M_lx=@M_lx,M_map=@M_map  where id=@id";
        //    SqlParameter[] paras = new SqlParameter[] { 
        //            new SqlParameter("@M_name", _M_name), 
        //            new SqlParameter("@M_psw", (_M_psw.Trim()==""?M_psw_old : comEncrypt.GetMD5 (_M_psw))),
        //            new SqlParameter("@M_question", _M_question),
        //            new SqlParameter("@M_answer", _M_answer), 
        //            new SqlParameter("@M_company", _M_company), 
        //            new SqlParameter("@M_tel", _M_tel), 
        //            new SqlParameter("@M_mobile", _M_mobile), 
        //            new SqlParameter("@M_email", _M_email), 
        //            new SqlParameter("@M_url", _M_url), 
        //            new SqlParameter("@M_QQ", _M_QQ), 
        //            new SqlParameter("@wx_name", _wx_name), 
        //            new SqlParameter("@wx_2wm", _wx_2wm), 
        //            new SqlParameter("@wx_ID", _wx_ID), 
        //            new SqlParameter("@wx_theme", _wx_theme), 
        //            new SqlParameter("@wx_theme2", _wx_theme2), 
        //            new SqlParameter("@wx_theme3", _wx_theme3),
        //            new SqlParameter("@wx_theme4", _wx_theme4),
        //            new SqlParameter("@M_vip", _M_vip), 
        //            //new SqlParameter("@cityID", _cityID),
        //            new SqlParameter("@id",_id), 
        //            new SqlParameter("@wx_nichen", _M_nichen), 
        //            new SqlParameter("@wx_DID", _M_DID), 
        //            new SqlParameter("@wx_Dpsw", _M_Dpsw), 
        //            new SqlParameter("@M_Bdate", _M_Bdate), 
        //            new SqlParameter("@M_Edate", _M_Edate), 
        //            new SqlParameter("@M_Udate", _M_Udate), 
        //            new SqlParameter("@wx_FirstIsGif", _wx_FirstIsGif), 
        //            new SqlParameter("@wxGNtheme", _wx_GNtheme),
        //            new SqlParameter("@hy_no", _hy_no),
        //            new SqlParameter("@area_no", _area_no),
        //            new SqlParameter("@M_isactive",_M_isactive),
        //            new SqlParameter("@M_lx",_M_lx),
        //            new SqlParameter("@M_map",_m_map)
        //    };  
        //    try
        //    {
        //        comfun con = new comfun();
        //        con.ExecuteNonQuery(sql, paras);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new NotSupportedException(ex.Message);
        //    }
        //}
        //private void myDeleteMethod(int _id)
        //{
        //    if (_id == 0)
        //    {
        //        throw new NotSupportedException("没有取得用户ID号");
        //    }
        //    else
        //    {
        //        string sql = "delete from B2C_worker where id=" + _id;

        //        try
        //        {
        //            comfun.UpdateBySQL(sql);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
                
        //    }
        //}
        //#endregion

        //#region "公有方法"
        //public void AddNew()
        //{
        //    id = 0;
        //    M_name = "";
        //    M_psw = "";

        //    M_psw_old = "";

        //    M_question = "";
        //    M_answer = "";

        //    M_company = "";
        //    M_email = "";
        //    M_tel = "";
        //    M_mobile = "";
        //    M_url = "";
        //    M_QQ = "";
        //    M_map = "";

        //    M_logontime = System.DateTime.Now;
        //    regtime = System.DateTime.Now;
        //    M_hits = 0;
        //    M_Bdate = System.DateTime.Now;
        //    M_Edate = System.DateTime.Now;
        //    M_Udate = System.DateTime.Now;
        //    M_lx = 2;
        //    wx_name = "";
        //    wx_nichen = "";
        //    wx_2wm = "";
        //    wx_ID = "";
        //    wx_theme = 1;
        //    wx_theme2 = 1;
        //    wx_theme3 = 1;
        //    wx_theme4 = 1;
        //    wx_GNTheme = "apps";
        //    wx_FirstIsGif = 1;
        //    wx_DID = "";
        //    wx_Dpsw = "";

        //    M_isactive = 1;
        //    M_isdel = 0;
        //    //cityID = 0;
        //    hy_no = "";
        //    area_no = "";
        //    isactivename = "启动";
        //    isdelname = "未删";

        //    M_vip = 0;
        //    Mvipname = "";
        //}
        //public void Update()
        //{
        //    if (this.id != 0)
        //    {
        //        this.myUpdateMethod(this.M_name, this.M_psw, this.M_question, this.M_answer, this.M_company, this.M_tel, this.M_mobile, this.M_email, this.M_url, this.M_QQ, this.wx_name, this.wx_2wm, this.wx_ID, this.wx_theme, this.wx_theme2, this.wx_theme3, this.wx_theme4, this.M_vip, this.id, this.wx_nichen, this.wx_DID, this.wx_Dpsw, this.M_Bdate, this.M_Edate, this.M_Udate, this.wx_FirstIsGif, this.wx_GNTheme, this.hy_no, this.area_no, this.M_lx, this.M_map, this.M_isactive);// this.cityID,
        //    }
        //    else
        //    {
        //        this.myInsertMethod(this.M_name, this.M_psw, this.M_question, this.M_answer, this.M_company, this.M_tel, this.M_mobile, this.M_email, this.M_url, this.M_QQ, this.wx_name, this.wx_2wm, this.wx_ID, this.wx_theme, this.wx_theme2, this.wx_theme3, this.wx_theme4, this.M_vip, this.wx_nichen, this.wx_DID, this.wx_Dpsw, this.M_Bdate, this.M_Edate, this.M_Udate, this.wx_FirstIsGif, this.wx_GNTheme, this.hy_no, this.area_no, this.M_map, this.M_isactive);// this.cityID,
        //    }
        //}
        //public void Delete()
        //{
        //    if (this.id != 0)
        //        this.myDeleteMethod(this.id);
        //}

        //public void updateHits()
        //{
        //    if (this.id != 0)
        //    {
        //        try
        //        {
        //            comfun.UpdateBySQL("update B2C_worker set M_hits=M_hits+1,M_logontime=getDate() where id=" + this.id);
        //        }
        //        finally { }
        //    }
        //}
        
        //public int checkLogon(string _pswNeed)
        //{
        //    int result = 0;
        //    if (System.DateTime.Now.CompareTo(this.M_Bdate) == 1 && System.DateTime.Now.CompareTo(this.M_Edate) == -1)
        //    {
        //        if (this.id != 0)
        //        {
        //            if (comEncrypt.GetMD5(_pswNeed) != this.M_psw_old)
        //                result = -2; //密码不不正确
        //            else
        //                result = 1;//密码正确，登录成功;
        //        }
        //        else
        //            result = -1;//用户名不存在

        //    }
        //    else
        //        result = -3; //超出使用范围
            
        //    if (result == 1)
        //    {//如果登录成功,则设置session
        //        //                    id(0)          用户名()             等级(0)                 模板(1)            原始码()       功能模板("appv")
        //        string[] uInfo = { this.id.ToString(), this.M_name, this.M_vip.ToString(), this.wx_theme.ToString(),this.wx_ID ,this.wx_GNTheme};
        //        System.Web.HttpContext.Current.Session["wInfo"] = uInfo;
        //        System.Web.HttpContext.Current.Session["wID"] = this.id.ToString();
        //        this.updateHits();
        //    }

        //    return result;

        //}
        //#endregion

        //#region "静态方法"
        ///// <summary>
        ///// 一次彻底删除一组用户
        ///// </summary>
        ///// <param name="_ids"></param>
        ///// <returns></returns>
        //public static int delete(string _ids)
        //{
        //    int result = 0;

        //    string sql = "delete from B2C_worker where id in (" + _ids + ")";
        //    try
        //    {
        //        comfun.UpdateBySQL(sql);
        //        result = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = 0;
        //        throw ex;
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 设置是否启用
        ///// </summary>
        ///// <param name="_cid"></param>
        //public static int setIsActive(string _ids)
        //{
        //    int res = 0;
        //    try
        //    {
        //        res = comfun.UpdateBySQL("update B2C_worker set M_isactive= -1 * (M_isActive - 1) where id in (" + _ids + ")");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return res;
        //}

        //public static int currentWID()
        //{
        //    int _wid = 0;
        //    if (System.Web.HttpContext.Current.Session["wInfo"] != null)
        //    {
        //        string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
        //        _wid = Convert.ToInt32(wInfo[0]);
        //    }
        //    return _wid;
        //}
        //public static string currentTheme()
        //{
        //    string _theme = "black";
        //    if (System.Web.HttpContext.Current.Session["wInfo"] != null)
        //    {
        //        string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
        //        _theme = wInfo[3].ToString();
        //    }
        //    return _theme;
        //}
        //public static string currentGNTheme()
        //{
        //    string _theme = "appv";
        //    if (System.Web.HttpContext.Current.Session["wInfo"] != null)
        //    {
        //        string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
        //        _theme = wInfo[5].ToString();
        //    }
        //    return _theme;
        //}
        //public static string currentWWX()
        //{
        //    string _theme = "appv";
        //    if (System.Web.HttpContext.Current.Session["wInfo"] != null)
        //    {
        //        string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
        //        _theme = wInfo[4].ToString();
        //    }
        //    return _theme;
        //}
        //public static string currentName()
        //{
        //    string _theme = "appv";
        //    if (System.Web.HttpContext.Current.Session["wInfo"] != null)
        //    {
        //        string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
        //        _theme = wInfo[1].ToString();
        //    }
        //    return _theme;
        //}
        //#endregion

        ///// <summary>
        ///// 此处为条件查询
        ///// </summary>
        //public static DataTable GetList(int currentpage,string _dzd, string _sql)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_worker where " + _sql + " order by id desc");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}
        //public static DataTable GetList(string _dzd, string _sql)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_worker where " + _sql + "");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}
        //public static DataTable GetList()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = comfun.GetDataTableBySQL("select * from B2C_worker order id desc");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}

        //public static Boolean Auth()
        //{
        //    if (System.Web.HttpContext.Current.Session["wInfo"] == null)
        //        return false;

        //    string[] _username = (string[])System.Web.HttpContext.Current.Session["wInfo"];
        //    if (_username == null)
        //        return false;
        //    if (_username[0] == null || _username[0].ToString().Trim() == "" || _username[0].ToString() == String.Empty)
        //        return false;

        //    return true;

        //}
        
    }
}
