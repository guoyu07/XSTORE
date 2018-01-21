using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;

namespace Wx_NewWeb.Shop.pages
{
    public partial class roomsPickUp : BasePage
    {
        public string redirect_url = string.Empty;
        string kwid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        #region
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
                }
               
                //var quhuo_sql = string.Format(@"select 补货的房间id from WP_取货记录表 where 用户id ={0} and 是否补货完成={1}", UserId,0);
                //var quhuo_dt = comfun.GetDataTableBySQL(quhuo_sql);
                //string where_sql = string.Empty;
                //if (quhuo_dt.Rows.Count > 0)
                //{
                //   where_sql = string.Format(" AND id IN({0})", quhuo_sql);
                //}
                //else
                //{
                //    where_sql = string.Format(" AND id IN({0})", quhuo_sql);
                //}
                string sql_kw = string.Format(@"
SELECT a.id,a.库位名 FROM  WP_取货记录表 b left join  [WP_库位表] a on a.id = b.补货的房间id WHERE a.IsShow=1 AND  a.库位名  NOT LIKE '%总台%' AND  a.仓库id={0} AND b.用户id ={1} and b.是否补货完成=0", HotelInfo["id"].ObjToInt(0), UserId);
                Log.WriteLog("页面：PickUp", "方法：PageInit", "sql_kw：" + sql_kw);
	            var dt = comfun.GetDataTableBySQL(sql_kw);
                rooms_rp.DataSource = dt;
                rooms_rp.DataBind();
                if (dt.Rows.Count > 0)
                {
                    list_div.Visible = true;
                    empty_div.Visible = false;
                }
                else
                {
                    list_div.Visible = false;
                    empty_div.Visible = true;
                }
            }
	        catch (Exception ex)
            {
                Log.WriteLog("页面：roomPickUp", "方法：PageInit", "异常信息：" + ex.Message);
                RedirectError(ex.Message);
            }
        
        }
//        protected void rooms()
//        {
//            #endregion
//            string sql_kw = "select id as 房间id,仓库id,库位名,箱子号,箱子MAC,IsShow  from WP_库位表 where IsShow=1 and 库位名  not like '%总台%' and 仓库id='" + KuWeiId + "'";
//            DataTable dt_kw = comfun.GetDataTableBySQL(sql_kw);
//            int a = 0;
//            string where = "";
//            for (int i=0;i<dt_kw.Rows.Count;i++)//遍历选出所有库位id
//            {
//                if (a == 0)
//                {
//                    where += " 库位id='" + dt_kw.Rows[i]["房间id"].ObjToInt(0) + "'";
//                    a = 3;
//                }
//                else {
//                    where += " or 库位id='" + dt_kw.Rows[i]["房间id"].ObjToInt(0) + "'";
//                }
//            }
//            //对所有库位进行筛选 如需补货则显示
//            string sql_quehuo = @"select 库位名,库位id  from  WP_箱子表 
//left join WP_商品表 on WP_箱子表.默认商品id=WP_商品表.id 
//left join WP_库位表 on WP_箱子表.库位id=WP_库位表.id
//where WP_箱子表.IsShow=1 and 实际商品id=0 and (" + where + ") group by 库位名,库位id order by 库位名 asc";
//            DataTable dt_box = comfun.GetDataTableBySQL(sql_quehuo);
//            rooms_rp.DataSource = dt_box;
//            rooms_rp.DataBind();
//            if (dt_box.Rows.Count > 0)
//            {
//                list_div.Visible = true;
//                empty_div.Visible = false;
//            }
//            else
//            {
//                list_div.Visible = false;
//                empty_div.Visible = true;
//            }
        //}
        #endregion
    }
}