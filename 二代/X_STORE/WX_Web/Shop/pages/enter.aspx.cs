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
    public partial class enter : BasePage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["boxmac"] != null)
                {
                    Log.WriteLog("页面：mySpace", "方法：PageLoad", "进入2:" + Request.QueryString["boxmac"].ObjToStr());
                    Session["boxmac"] = "";
                    Session["boxmac"] = Request.QueryString["boxmac"].ObjToStr();
                    var mac = Request.QueryString["boxmac"].ObjToStr();
                    var macDt = comfun.GetDataTableBySQL(string.Format("select * from WP_库位表 where 箱子MAC ='{0}'", mac));
                    if (macDt.Rows.Count == 0)
                    {
                        Response.Redirect(string.Format(home_url + "/WebSite/Login/Welcome.aspx?boxmac={0}", mac), false);
                        return;
                    }
                }
                if (UserInfo == null)
                {
                    //Log.WriteLog("页面：enter", "方法：submit_button_ServerClick", "UserInfo是空");
                    //Response.Redirect(string.Format("~/Shop/Buyer/mySpace.aspx?boxmac={0}", BoxMac));
                }
                else
                {
                    var select_sql = string.Format(@"select id from WP_用户权限 where 用户id = {0} and 仓库id in(
select 仓库id from [dbo].[WP_库位表] where 箱子MAC = '{1}')", UserId, Session["boxmac"].ObjToStr());
                    Log.WriteLog("页面：enter", "方法：submit_button_ServerClick", "select_sql:" + select_sql);
                    var select_dt = SqlDataHelper.GetDataTable(select_sql);
                    if ((EnumCommon.角色权限)UserInfo["角色id"].ObjToInt(0) == EnumCommon.角色权限.测试员)
                    {
                        Response.Redirect(string.Format("~/Shop/pages/qaBoxCheck.aspx?boxmac={0}", BoxMac));
                        return;
                    }
                    if (select_dt.Rows.Count == 0)
                    {
                        Response.Redirect(string.Format("~/Shop/pages/NoAuth.aspx"));
                        return;
                    }
                    switch ((EnumCommon.角色权限)UserInfo["角色id"].ObjToInt(0))
                    {
                        case EnumCommon.角色权限.前台:
                        case EnumCommon.角色权限.经理:
                        case EnumCommon.角色权限.区域经理:
                            Response.Redirect(string.Format("~/Shop/Distributer/BindMac.aspx?boxmac={0}", BoxMac));
                            break;
                        case EnumCommon.角色权限.配水员:
                            Response.Redirect(string.Format("~/Shop/Distributer/WaterFillUp.aspx?boxmac={0}", BoxMac));
                            break;
                        case EnumCommon.角色权限.财务:

                        case EnumCommon.角色权限.集团经理:

                        case EnumCommon.角色权限.集团财务:

                        case EnumCommon.角色权限.后台财务:

                        case EnumCommon.角色权限.后台管理员:


                        default:
                            Response.Redirect(string.Format("~/Shop/Buyer/mySpace.aspx?boxmac={0}", BoxMac));
                            break;
                    }
                }

            }
        }


        protected void submit_button_ServerClick(object sender, EventArgs e)
        {
            //Log.WriteLog("页面：enter", "方法：submit_button_ServerClick","角色："+UserInfo["角色id"].ObjToInt(0));
            if (UserInfo == null)
            {
                Log.WriteLog("页面：enter", "方法：submit_button_ServerClick", "UserInfo是空");
                 Response.Redirect(string.Format("~/Shop/Buyer/mySpace.aspx?boxmac={0}", BoxMac));
            }
            else
            {
                var select_sql = string.Format(@"select id from WP_用户权限 where 用户id = {0} and 仓库id in(
select 仓库id from [dbo].[WP_库位表] where 箱子MAC = '{1}')", UserId, Session["boxmac"].ObjToStr());
                Log.WriteLog("页面：enter", "方法：submit_button_ServerClick", "select_sql:" + select_sql);
                var select_dt = SqlDataHelper.GetDataTable(select_sql);
                if ((EnumCommon.角色权限)UserInfo["角色id"].ObjToInt(0) == EnumCommon.角色权限.测试员)
                {
                    Response.Redirect(string.Format("~/Shop/pages/qaBoxCheck.aspx?boxmac={0}", BoxMac));
                    return;
                }
                if (select_dt.Rows.Count == 0)
                {
                    Response.Redirect(string.Format("~/Shop/pages/NoAuth.aspx"));
                    return;
                }
                switch ((EnumCommon.角色权限)UserInfo["角色id"].ObjToInt(0))
                {
                    case EnumCommon.角色权限.前台:
                    case EnumCommon.角色权限.经理:
                    case EnumCommon.角色权限.区域经理:
                        Response.Redirect(string.Format("~/Shop/Distributer/BindMac.aspx?boxmac={0}", BoxMac));
                        break;
                    case EnumCommon.角色权限.配水员:
                        Response.Redirect(string.Format("~/Shop/Distributer/WaterFillUp.aspx?boxmac={0}", BoxMac));
                        break;
                    case EnumCommon.角色权限.财务:

                    case EnumCommon.角色权限.集团经理:

                    case EnumCommon.角色权限.集团财务:

                    case EnumCommon.角色权限.后台财务:

                    case EnumCommon.角色权限.后台管理员:

                    
                    default:
                        Response.Redirect(string.Format("~/Shop/Buyer/mySpace.aspx?boxmac={0}", BoxMac));
                        break;
                }
            }
            
        }
    }
}