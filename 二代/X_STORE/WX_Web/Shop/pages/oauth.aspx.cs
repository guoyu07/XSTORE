using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class oauth : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Log.WriteLog("页面：oauth.aspx", "方法：Page_Load", "进入：" );
                PageInit();
            }
        }
        protected void PageInit() {
            try
            {
                var role_id = UserInfo["角色id"].ObjToInt(0);
                Log.WriteLog("页面：oauth.aspx", "方法：RedirectLogin", "role_id：" + role_id);
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
           ,getdate())", UserId, UserInfo["用户名"], OpenId, UserInfo["真实姓名"].ObjToStr(), UserInfo["手机号"].ObjToStr());
                comfun.InsertBySQL(loginLogSql);
                switch (role_id)
                {
                    case 1://酒店经理
                        Response.Redirect("../pages/hotelManager.aspx",false);
                        return;
                    case 2://财务
                        Response.Redirect("../pages/goodsList.aspx", false);
                        return;
                    case 3://配货员
                        Response.Redirect("../pages/disMyself.aspx", false);
                        return;
                    case 4://区域经理
                        Response.Redirect("../pages/areaManage.aspx", false);
                        return;
                    case 9://消费者
                        Response.Redirect("../pages/qaManage.aspx", false);
                        return;
                    case 10://消费者
                        Response.Redirect("../pages/fillManager.aspx", false);
                        return;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：oauth.aspx", "方法：RedirectLogin", "异常信息：" + ex.StackTrace);
                Response.Redirect(home_url + "/shop/pages/login.aspx", false);
            }
        
        }
    }
}