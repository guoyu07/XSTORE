using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class employeeManager : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        protected void PageInit() {
            try
            {
                var hotel_id = HotelInfo["id"].ObjToStr();
                var select_sql = string.Format("SELECT * FROM 视图获取配货员 WHERE 仓库id = {0} AND 角色id = {1}", hotel_id, (int)EnumCommon.角色权限.前台);
                var select_dt = comfun.GetDataTableBySQL(select_sql);
                people_repeater.DataSource = select_dt;
                people_repeater.DataBind();
            }
            catch (Exception ex)
            {
                Log.WriteLog("类：employeeManager", "方法：pageinit", "异常信息：" + ex.Message);
                throw;
            }
            
        }
    }
}