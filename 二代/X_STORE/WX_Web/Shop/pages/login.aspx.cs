using Creatrue.Common.Msgbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using tdx.Weixin;
using DTcms.Common;

namespace Wx_NewWeb.Shop.pages
{
    public partial class login : System.Web.UI.Page
    {
        protected string jsdkSignature = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
         {
            if(!IsPostBack)
            {
                Log.WriteLog("页面：login.aspx", "方法：Page_Load", "进入：");
            }
            jsdkSignature = GetJsdkSignature(HttpContext.Current.Request.Url.AbsoluteUri.ToString());
               
        }
   
        public string GetJsdkSignature(string url)
        {
            string noncestr = "9hKgyCLgGZOgQmEI";
            int timestamp = 1421142450;
            Chat ch = new Chat();
            string ticket = ch.GetJsapi_Ticket();
            Log.WriteLog("页面：login.aspx", "方法：Page_Load", "ticket：" + ticket);
            string string1 = "jsapi_ticket=" + ticket + "&noncestr=" + noncestr + "&timestamp=" + timestamp + "&url=" + url;
            Log.WriteLog("页面：login.aspx", "方法：Page_Load", "string1：" + string1);
            string signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(string1, "SHA1");
            return signature.ToLower();
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string user_name = username.Value;
                string password = pswd.Value;
                string sql = @"select id,用户名,密码,角色id,openid,手机号,真实姓名 from WP_用户表 where 用户名='" + user_name + "'and 密码='" + password + "' and isshow=1";
                Log.WriteLog("页面：login.aspx", "方法：login_btn_Click", "sql：" + sql);
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["openid"].ObjToStr()))
                    {
                        MessageBox.Show(this, "当前用户已绑定！");
                        return;
                    }
                    else
                    {
                        int role_id = dt.Rows[0]["角色id"].ObjToInt(0);
                        int user_id = dt.Rows[0]["id"].ObjToInt(0);
                        bool is_same = string.IsNullOrEmpty(dt.Rows[0]["openid"].ObjToStr()) ? false : dt.Rows[0]["openid"].ObjToStr().Equals(Session["OpenId"].ObjToStr());
                        Session["UserId"] = user_id;
                        Log.WriteLog("页面：login.aspx", "方法：login_btn_Click", "is_same：" + is_same);
                        if (is_same)
                        {
                            var loginLogSql = string.Format(@"INSERT INTO [dbo].[WP_登陆记录表]
           ([UserId]
           ,[Account]
           ,[OpenId]
           ,[Name]
           ,[Phone]
           ,[LastLoginTime])
     VALUES
           ({0}
           ,'{1}'
           ,'{2}'
           ,'{3}'
           ,'{4}'
           ,getdate())", user_id, dt.Rows[0]["用户名"].ObjToStr(), Session["OpenId"].ObjToStr(), dt.Rows[0]["真实姓名"].ObjToStr(), dt.Rows[0]["手机号"].ObjToStr());
                            comfun.InsertBySQL(loginLogSql);
                        }
                        RedirectByRole(role_id, is_same);
                    }
                   
                }
                else
                {
                    MessageBox.Show(this, "登陆失败！");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：login.aspx", "方法：login_btn_Click", "异常信息：" + ex.Message);
                RedirectError("");
            }
            

        }
        #region 跳转错误页面
        protected void RedirectError(string msg)
        {
            var url = string.Format("~/error.Html?message = {0}", msg);
            Response.Redirect(url, false);
            return;
        }
        #endregion
        protected void RedirectByRole(int role_id,bool is_same)
        {

            switch (role_id)
            {
                case 1://酒店经理
                    Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "酒店经理");
                    MessageBox.ShowAndRedirect(this, is_same ? "登录成功" : "登陆成功，请修改初始密码！", is_same ? "../pages/hotelManager.aspx" : "../pages/changePsd.aspx");
                    break;
                case 2://财务
                    Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "财务");
                    MessageBox.ShowAndRedirect(this, is_same ? "登录成功" : "登陆成功，请修改初始密码！", is_same ? "../pages/goodsList.aspx" : "../pages/changePsd.aspx");
                    break;
                case 3://配货员
                    Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "配货员");
                    MessageBox.ShowAndRedirect(this, is_same ? "登录成功" : "登陆成功，请修改初始密码！", is_same ? "../pages/disMyself.aspx" : "../pages/changePsd.aspx");
                    break;
                case 4://区域经理
                    Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "区域经理");
                    MessageBox.ShowAndRedirect(this, is_same ? "登录成功" : "登陆成功，请修改初始密码！", is_same ? "../pages/areaManage.aspx" : "../pages/changePsd.aspx");
                    break;
                case 9:
                    Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "测试员");
                    MessageBox.ShowAndRedirect(this, is_same ? "登录成功" : "登陆成功，请修改初始密码！", is_same ? "../pages/qaManage.aspx" : "../pages/changePsd.aspx");
                    break;
                case 10:
                    Log.WriteLog("类：BasePage", "方法：RedrectWeiXin", "促销补货员");
                    MessageBox.ShowAndRedirect(this, is_same ? "登录成功" : "登陆成功，请修改初始密码！", is_same ? "../Distributer/WaterFillUp.aspx" : "../pages/changePsd.aspx");
                    break;
            }
        }
    }
}