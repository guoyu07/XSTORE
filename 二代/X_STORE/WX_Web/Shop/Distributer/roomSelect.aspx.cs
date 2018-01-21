using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.Distributer
{
    public partial class roomSelect : BasePage
    {
        public string redirect_url = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        protected void PageInit()
        {
            try
            {
                switch ((EnumCommon.角色权限)UserInfo["角色id"].ObjToInt(0))
                {
                    case EnumCommon.角色权限.经理:
                    case EnumCommon.角色权限.区域经理:
                        redirect_url = "../pages/hotelManager.aspx";
                        break;
                    case EnumCommon.角色权限.财务:
                        break;
                    case EnumCommon.角色权限.前台:
                        redirect_url = "../Distributer/disMyself.aspx";
                        break;
                    case EnumCommon.角色权限.集团经理:
                        break;
                    case EnumCommon.角色权限.集团财务:
                        break;
                    case EnumCommon.角色权限.后台财务:
                        break;
                    case EnumCommon.角色权限.后台管理员:
                        break;
                    default:
                        break;
                };

                string sql_kw = string.Format(@"
SELECT id,库位名 FROM [WP_库位表] WHERE id IN(SELECT 投放库位id FROM [视图获取投放商品id] WHERE  投放库位id NOT IN(SELECT [补货的房间id] FROM [tshop].[dbo].[WP_取货记录表] WHERE 用户id ={1} AND 是否补货完成 = 0)) AND IsShow=1 AND  库位名  NOT LIKE '%总台%' AND  仓库id={0}
", HotelInfo["id"].ObjToInt(0),UserId);
                Log.WriteLog("页面：PickUp", "方法：PageInit", "sql_kw：" + sql_kw);
                var dt = comfun.GetDataTableBySQL(sql_kw);
                rooms_rp.DataSource = dt;
                rooms_rp.DataBind();
                if (dt.Rows.Count > 0)
                {
                    roomSelectDiv.Visible = true;
                    empty_div.Visible = false;
                }
                else
                {
                    roomSelectDiv.Visible = false;
                    empty_div.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //Log.WriteLog("页面：PickUp", "方法：PageInit", "异常信息：" + ex.Message);
                RedirectError(ex.Message);
            }
        }
    }
}