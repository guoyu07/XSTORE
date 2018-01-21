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
    public partial class hotelManager : BasePage
    {
        public string state = string.Empty;
        public string state_num = string.Empty;
        private int _totalmoney;

        protected int TotalMoney
        {
            get {
                if (_totalmoney == 0)
                {
                    var box_sql = string.Format("SELECT * FROM WP_库位表 WHERE 仓库id = {0} AND IsShow=1 AND 箱子MAC IS NOT NULL AND 箱子MAC <> '' AND 库位名 not like '%总台%'", HotelInfo["id"].ObjToInt(0));
                    var box_dt = comfun.GetDataTableBySQL(box_sql);
                    if (box_dt.Rows.Count > 0)
	                {
                        _totalmoney = box_dt.Rows.Count.ObjToInt(0) * 1600;
	                }
                    else
                    {
                        _totalmoney = 0;
                    }
                }
                return _totalmoney;
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var d = Request.QueryString["hotel_id"].ObjToInt(0);
            state = FindState(d, "convert(varchar(10),下单时间,120) = CONVERT(varchar(10),DATEADD(DAY,-1,GETDATE()),120)","1", out state_num);
            if (!IsPostBack)
            {
                if ((EnumCommon.角色权限)UserInfo["角色id"] == EnumCommon.角色权限.区域经理)
                {
                    changeHotel.Visible = true;
                }
                else
                {
                    changeHotel.Visible = false;
                }
            }
        }
       
    }
}