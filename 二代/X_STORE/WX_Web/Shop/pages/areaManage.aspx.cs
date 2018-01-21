using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using Creatrue.kernel;

namespace Wx_NewWeb.Shop.pages
{
    public partial class areaManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        protected void PageInit() {
            //Session.Clear();
            Session["hotel_id"] = null;
            //Session["UserId"] = null;
            //Session["OpenId"] = null;
            if ((EnumCommon.角色权限)UserInfo["角色id"] == EnumCommon.角色权限.区域经理)
            {
                var select_sql = string.Format(@"  select b.* from WP_用户权限 a left join  WP_仓库表 b on a.仓库id = b.id where a.用户id = {0}", UserId);
                var select_dt = SqlDataHelper.GetDataTable(select_sql);
                hotel_rp.DataSource = select_dt;
                hotel_rp.DataBind();
            }
        }
    }
}