using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages.Manager
{
    public partial class UserInfoList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            try
            {
                var sql = string.Format(@"
SELECT A.用户名,A.手机号,A.真实姓名,B.角色类型,
(select top 1 Convert(nvarchar(10),LastLoginTime,120) from WP_登陆记录表 where UserId = A.id order by LastLoginTime desc ) as LastLoginTime
FROM [dbo].[WP_用户表] A LEFT JOIN WP_用户角色 B ON A.角色id = B.id WHERE A.id IN(
SELECT 用户id FROM [dbo].[WP_用户权限] WHERE 仓库id ={0})", HotelId);
                var dt = comfun.GetDataTableBySQL(sql);
                hm_user_item_rp.DataSource = dt;
                hm_user_item_rp.DataBind();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：comprehensive", "方法：BindUser", "异常信息：" + ex.Message);
                RedirectError(ex.Message);
            }
        }
    }
}