using Creatrue.kernel;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using tdx.database.Common_Pay.WeiXinPay;

namespace Wx_NewWeb.Shop
{
    public class BasePage : System.Web.UI.Page
    {
        protected string  no_img = "/shop/img/no-image.jpg";//默认图片
        protected string home_url = ConfigurationManager.AppSettings["HomeUrl"].ObjToStr();
        protected bool debug = bool.Parse(ConfigurationManager.AppSettings["DEBUG"].ObjToStr());

        protected override void OnInit(EventArgs e)
        {
            var InitOpenid = OpenId;
            base.OnInit(e);
        }
        #region OpenId
        private string _openid;
        protected string OpenId 
        {
            get
            {
                if (debug)
                {
                    //return "o8eAHwM94iBA0GGYsh8tnJ1pmuM8";//袁益鹏
                    //return "o8eAHwM5_75X286k5teZThpp8ns8";//王琛
                    return "o8eAHwFadTw_pMf6lMyrjYqa4WyY";
                }
                Log.WriteLog("类：BasePage", "方法：OpenId", "_openid:" + _openid);
                if (_openid == null || string.IsNullOrEmpty(_openid))
                {
                    Log.WriteLog("类：BasePage", "方法：OpenId", "Session:" + Session["OpenId"]);
                    if (Session["OpenId"] == null || string.IsNullOrEmpty(Session["OpenId"].ObjToStr()))
	                {
                        Log.WriteLog("类：BasePage", "方法：OpenId", "_openid为空");
		                _openid = RedrectWeiXin();
                        Log.WriteLog("类：BasePage", "方法：OpenId", "重新获取_openid：" + _openid);
                        Session["OpenId"] = _openid;
                        Log.WriteLog("类：BasePage", "方法：OpenId", "赋值到session：" + Session["OpenId"]);
	                }
                    else
                    {
                       
                        Log.WriteLog("类：BasePage", "方法：OpenId", "_openid不为空：" + Session["OpenId"]);
                        _openid = Session["OpenId"].ObjToStr();
	                }
                }
                return _openid;
            }
        }
        #endregion

        #region 是否离线

        protected bool IsOffline
        {
            get
            {
                if (Session["is_offline"] == null || string.IsNullOrEmpty(Session["is_offline"].ObjToStr()))
	            {
                    if (Request.QueryString["is_offline"].ObjToInt(0) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        Session["is_offline"] = true;
                        Log.WriteLog("页面：BasePage", "方法：IsOffline", "Session['is_offline']" + Session["is_offline"]);
                        return true;
                    }
	            }
                return true;
            }
        }
        #endregion

        #region UserId
        private int _userid;
        protected int UserId
        {
            get
            {
                if (_userid == 0)
                {
                    if (string.IsNullOrEmpty(Session["UserId"].ObjToStr()))
                    {
                        var user_sql = string.Format("SELECT id FROM WP_用户表 WHERE openid='{0}' AND openid <> ''", OpenId);
                        Log.WriteLog("类：BasePage", "方法：UserId", "sql:" + user_sql);
                        var user_dt = comfun.GetDataTableBySQL(user_sql);
                        if (user_dt.Rows.Count > 0)
                        {
                            
                            _userid = user_dt.Rows[0]["id"].ObjToInt(0);
                            Log.WriteLog("类：BasePage", "方法：UserId", "_userid:" + _userid);
                            Session["UserId"] = _userid;
                        }
                        else
                        {
                            Log.WriteLog("类：BasePage", "方法：UserId", "tologin.aspx:");
                            Log.WriteLog("类：BasePage", "方法：UserId", "home_url:" + home_url);
                            Log.WriteLog("类：BasePage", "方法：UserId", "rul:" + home_url + "/shop/pages/login.aspx");
                            Response.Redirect(home_url+"/shop/pages/login.aspx",false);
                        }
                    }
                    else
                    {
                        _userid = Session["UserId"].ObjToInt(0);
                    }

                }
                return _userid;

            }
        }
        #endregion

        #region 用户信息
        private DataRow _userinfo;
        public DataRow UserInfo
        {
            get
            {
                try
                {
                    Log.WriteLog("类：BasePage", "方法：UserInfo", "UserInfo进入:");
                    if (_userinfo == null)
                    {
                        string sql = @"select WP_用户表.id,用户名,密码,角色id,wx头像,ISNULL(真实姓名,'') AS 真实姓名,isnull(WP_用户表.手机号,'') as 手机号 from WP_用户表  left join wp_会员表  on WP_用户表.openid=wp_会员表.openid where WP_用户表.openid='" + OpenId + "' and wp_会员表.openid <> '' and  isshow=1";
                        Log.WriteLog("类：BasePage", "方法：UserInfo", "sql:" + sql);
                        DataTable dt = comfun.GetDataTableBySQL(sql);
                        if (dt.Rows.Count > 0)
                        {
                            Session["UserId"] = UserId;
                            _userinfo = dt.Rows[0];

                        }
                        else
                        {
                            //Session.Clear();
                            Log.WriteLog("类：BasePage", "方法：UserInfo", "_userinfo:" + 0);
                            //Response.Redirect(home_url + "/shop/pages/login.aspx", false);
                            _userinfo = null;
                        }
                    }
                   
                }
                catch (Exception)
                {
                    RedirectError("");
                }
                return _userinfo;
            }
        }
        #endregion

        #region 酒店id
        private int _hotelid;
        public int HotelId
        {
            get {
                try
                {
                    if (Session["hotel_id"].ObjToInt(0) == 0)
                    {
                        if (Request.QueryString["hotel_id"].ObjToInt(0) == 0)
                        {
                            string sql = @"SELECT 仓库id FROM [dbo].[WP_用户权限] WHERE 用户id =" + UserId;
                            DataTable dt = comfun.GetDataTableBySQL(sql);
                            if (dt.Rows.Count > 0)
                            {
                                _hotelid = dt.Rows[0][0].ObjToInt(0);
                            }
                            else
                            {
                                RedirectError("酒店不存在");
                            }
                        }
                        else
                        {
                            _hotelid = Request.QueryString["hotel_id"].ObjToInt(0);
                        }
                       
                        Session["hotel_id"] = _hotelid;
                    }
                    else
	                {
                        _hotelid = Session["hotel_id"].ObjToInt(0);
	                }
                   
                }
                catch (Exception)
                {
                    RedirectError("");
                   
                }
                return _hotelid;
            }
        }
        #endregion

        #region 酒店信息
        public DataRow _hotelinfo;
        public DataRow HotelInfo
        {
            get
            {
                try
                {
                    if (_hotelinfo == null)
                    {
                        string sql = @"SELECT B.id,isnull(B.仓库名,'') as 仓库名 FROM [tshop].[dbo].[WP_用户权限] A LEFT JOIN [dbo].[WP_仓库表] B ON A.仓库id = B.ID WHERE A.仓库id = "+HotelId+" AND  A.用户id =" + UserId;
                        DataTable dt = comfun.GetDataTableBySQL(sql);
                        if (dt.Rows.Count > 0)
                        {
                            _hotelinfo = dt.Rows[0];
                        }
                        else
                        {
                            RedirectError("酒店不存在");
                        }

                    }
                   
                }
                catch (Exception)
                {
                    
                   RedirectError("");
                }
                return _hotelinfo;
            }
        }
        #endregion

        #region 箱子号
        private string _boxmac;
        protected string BoxMac
        {
            get
            {
                //if (debug)
                //{
                //    return "861853032006603";
                //}
                if (string.IsNullOrEmpty(_boxmac))
                {
                
                    if (string.IsNullOrEmpty(Session["boxmac"].ObjToStr()))
                    {
                        if (Request.QueryString["boxmac"] == null || string.IsNullOrEmpty(Request.QueryString["boxmac"].ObjToStr()))
                        {
                            //Log.WriteLog("类：BasePage","方法：Boxmac","获取了mac");
                            RedirectError("");

                        }
                        else
                        {
                            _boxmac = Request.QueryString["boxmac"].ObjToStr();
                            Session["boxmac"] = _boxmac;
                        }
                    }
                    else
                    {
                        _boxmac = Session["boxmac"].ObjToStr();
                    }
                    
                }

                return _boxmac;
            }
        }
        #endregion

        #region 获取酒店的手机号
        private string _hotelphone;
        public string HotelPhone {
            get {
                if (string.IsNullOrEmpty(_hotelphone) && Session["tel"] == null)
                {
                     string sql_tel = @"
                    select 电话 from wp_库位表
                    left join wp_仓库表 on wp_库位表.仓库id=WP_仓库表.id
                    where 箱子MAC='" + BoxMac + "'";
                    DataTable dt_tel = comfun.GetDataTableBySQL(sql_tel);
                    if (dt_tel.Rows.Count > 0)
                    {
                        _hotelphone = dt_tel.Rows[0]["电话"].ObjToStr();
                        Session["tel"] = _hotelphone;

                    }
                    else
                    {
                        //Log.WriteLog("类：BasePage", "方法：HotelPhone", "异常信息：酒店不存在"  );
                        RedirectError("酒店不存在");
                    }
                   
                }
                else if (Session["tel"] != null)
	            {
                    _hotelphone = Session["tel"].ObjToStr();
	            }
                return _hotelphone;
            }
        }
        #endregion

        #region openid为空，重新获取openid
        protected string RedrectWeiXin() {
            try
            {
                string root = HttpContext.Current.Request.Url.Host;
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                string query =  HttpContext.Current.Request.Url.Query;
                string RedirectUri ="http://"+ root + url + query;
                if (Session == null || string.IsNullOrEmpty(Session["OpenId"].ObjToStr()))
                {
                    tdx.Weixin.weixin _wx = new tdx.Weixin.weixin();
                    #region 根据code获取openid
                    if (Request.QueryString["code"] != null && !string.IsNullOrEmpty(Request.QueryString["code"]))
                    {
                        Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "code不为空" );
                        tdx.Weixin.Weixin.OAuth_Token web_Oatuth = new tdx.Weixin.Weixin.OAuth_Token();
                        string code = Request.QueryString["code"];
                        Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "code:" + code);
                        web_Oatuth = _wx.Get_WebOauthToken(code);//获取用户openid
                        Session["OpenId"] = web_Oatuth.openid;
                        Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "openid:" + web_Oatuth.openid);
                        #region 存入用户信息
                        string sql = "select * from wp_会员表 where openid='" + web_Oatuth.openid + "'";
                        DataTable dt = comfun.GetDataTableBySQL(sql);
                        weixinUser userinfo = _wx.GetWebUserInfo(web_Oatuth.access_token, web_Oatuth.openid);
                        string nickname = userinfo.Nickname;
                        string headpic = userinfo.Headimgurl;
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            comfun.UpdateBySQL("update WP_会员表 set wx昵称='" + SQLSafe(nickname) + "',wx头像='" + headpic + "' where openid='" + web_Oatuth.openid + "'");
                            comfun.UpdateBySQL("update B2C_mem set M_name='" + SQLSafe(nickname) + "'  where openid='" + web_Oatuth.openid + "'");
                           
                        }
                        else //将新用户加入用户表
                        {
                            //   comfun.InsertBySQL("insert into WP_用户表  (微信昵称,微信头像,openid) values('" + SQLSafe(nickname) + "','" + headpic + "','" + web_Oatuth.openid + "'");
                            comfun.InsertBySQL("insert into wp_会员表(openid,wx昵称,wx头像) values('" + web_Oatuth.openid + "','" +
                                             SQLSafe(nickname) + "','" + headpic + "')");
                            string _sql = "select count(id) from b2c_mem where parentID=0";
                            DataTable dts = comfun.GetDataTableBySQL(_sql);
                            string _M_no = "";
                            if (dts.Rows.Count > 0)
                            {
                                _M_no = (Convert.ToInt32(dts.Rows[0][0].ToString().Trim()) + 1).ToString().Trim();
                            }
                            else
                                _M_no = "0001";

                            while (_M_no.Length < 4)
                                _M_no = "0" + _M_no;

                            comfun.InsertBySQL(@"insert into B2C_mem(openid,M_name,M_truename,M_isactive,M_no) 
            values('" + web_Oatuth.openid +@"','" + SQLSafe(nickname) + "','" + SQLSafe(nickname) + "',-2,'" + _M_no + "')");
                           
                        }
                        Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "openid:" + web_Oatuth.openid);
                        return web_Oatuth.openid;
                        #endregion
                    }
                    else
                    {
                        Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "code为空" );

                        //Url转发获取微信信息
                        string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri.ToLower() + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                        Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "URL："+URL);
                        //HttpContext.Current.Response.Redirect(URL);
                        Response.Redirect(URL,false);
                        return string.Empty;
                    }
                    #endregion
                    
                }
                else
                {
                    return Session["OpenId"].ObjToStr();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "异常信息：" + ex.StackTrace);
                RedirectError("");
                return string.Empty;
            }

        }
        public static string SQLSafe(string Parameter)
        {
            Parameter = Parameter.Replace("'", "");
            Parameter = Parameter.Replace(">", ">");
            Parameter = Parameter.Replace("<", "<");
            Parameter = Parameter.Replace("\n", "<br>");
            Parameter = Parameter.Replace("\0", "·");
            return Parameter;
        }
        #endregion

        #region 跳转错误页面
        protected void RedirectError(string msg) {
            var url = string.Format("~/error.Html?message = {0}", msg);
            Response.Redirect(url,false);
            return;
        }
        #endregion

        #region 获取订单编号
//        protected string GetOrderNo() {
//           return @"S" + DateTime.Now.ToString("yyyyMMdd") + 
//            DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) 
//            from (select count(1) as num from [dbo].[WP_订单表] 
//            where CONVERT(varchar(100),下单时间,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ObjToStr();
//        }
        public static string GetOrderNo()
        {
            string OrderNo = string.Empty;
            Random rd = new Random();
            int num1 = rd.Next(100, 1000);
            DateTime dtnow = DateTime.Now;
            OrderNo = "S" + System.DateTime.Now.Year.ToString().PadRight(4, '0') + System.DateTime.Now.Month.ToString().PadRight(2, '0') + System.DateTime.Now.Minute.ToString().PadRight(2, '0') + System.DateTime.Now.Second.ToString().PadRight(2, '0') + System.DateTime.Now.Millisecond.ToString().PadRight(2, '0') + num1;
            OrderNo = OrderNo.PadRight(16, '9');
            if (OrderNo.Length>16)
            {
                OrderNo = OrderNo.Substring(0, 16);
            }
           
            return OrderNo;
        }

        public static string GetBackNo() {

            string OrderNo = string.Empty;
            Random rd = new Random();
            int num1 = rd.Next(100, 1000);
            DateTime dtnow = DateTime.Now;
            OrderNo = "B" + System.DateTime.Now.Year.ToString().PadRight(4, '0') + System.DateTime.Now.Month.ToString().PadRight(2, '0') + System.DateTime.Now.Minute.ToString().PadRight(2, '0') + System.DateTime.Now.Second.ToString().PadRight(2, '0') + System.DateTime.Now.Millisecond.ToString().PadRight(2, '0') + num1;
            OrderNo = OrderNo.PadRight(16, '9');
            if (OrderNo.Length > 16)
            {
                OrderNo = OrderNo.Substring(0, 16);
            }

            return OrderNo;
        }

        #endregion

        #region
        public string FindState(int hotel_id,string where_sql,string daycount, out string num)
        {
            var select_sql = string.Format(@"select
(sum(应付款)/((select count(id) from WP_库位表 where 仓库id = {0} and 箱子MAC is not null and 箱子MAC <> '')*({1}))) as 日均房 
from WP_订单表
where {2} and 订单编号 in(select 订单编号 from WP_订单子表 where 仓库id = {0}) and state >= 3 ", HotelId, daycount, where_sql);
            var select_dt = comfun.GetDataTableBySQL(select_sql);
            if (select_dt.Rows.Count > 0)
            {
                var rijun = select_dt.Rows[0][0].ObjToDecimal(0);
                num = Math.Round(rijun, 2).ObjToStr();
                if (rijun > 5)
                {
                    return "normal";
                }
                else if (rijun >= 2 && rijun < 5)
                {
                    return "warning";
                }
                else
                {
                    return "error";
                }
            }
            else
            {
                num = "0";
                return string.Empty;
            }
        }
        #endregion
    }
}