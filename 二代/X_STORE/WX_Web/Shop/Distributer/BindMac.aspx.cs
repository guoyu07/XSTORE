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
    public partial class BindMac : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        protected void PageInit()
        {
  
            //判断如果当前的酒店已经绑定，那么跳到配货页面
            var room_sql = string.Format("SELECT * FROM WP_库位表 WHERE 箱子MAC='{0}'", BoxMac);
            Log.WriteLog("页面：BindMac", "方法：PageInit", "room_sql:" + room_sql);
            var room_dt = comfun.GetDataTableBySQL(room_sql);
            if (room_dt.Rows.Count >0)
            {
                if (room_dt.Rows[0]["状态"].ObjToInt(0) == 2)
                {
                    Response.Redirect(string.Format("../pages/noPower.aspx?boxmac = {0}", BoxMac), false);
                    return;
                }
                else
                {
                    Response.Redirect(string.Format("../pages/roomDetail.aspx?kwid={0}", room_dt.Rows[0]["id"].ObjToInt(0)), false);
                    return;
                }
              
            }
            else
            {
                //Log.WriteLog("页面：BindMac", "方法：PageInit", "进入了Pageinit:" );
                var sql = string.Format("SELECT id,库位名 FROM WP_库位表 WHERE 仓库id = {0} AND (箱子MAC IS NULL OR 箱子MAC = '') AND 库位名 NOT LIKE '%总台%'", HotelInfo["id"].ObjToInt(0));
                Log.WriteLog("页面：BindMac", "方法：PageInit", "sql:" + sql);
                var dt = comfun.GetDataTableBySQL(sql);
                mac_input.Value = BoxMac;
                hotel_repeater.DataSource = dt;
                hotel_repeater.DataBind();
            }
           
        }
    }
}