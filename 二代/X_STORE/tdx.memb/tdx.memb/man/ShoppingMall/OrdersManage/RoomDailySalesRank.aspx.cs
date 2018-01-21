using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class RoomDailySalesRank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.fpgHistoryList.CurrentPageIndex = 1;
                this.fpgHistoryList.PageSize = 20;
                PageInit();
            }
        }

        protected void PageInit(string sort = "")
        {


            var totalCount = 50;
            var selectSql = string.Format(@"select 酒店名称,房间名,当日销售额,销量,日期 from View_RoomDailySaleRank");
            var pageSql = PagingHelper.CreatePagingSql(totalCount, this.fpgHistoryList.PageSize, this.fpgHistoryList.CurrentPageIndex, selectSql, " 当日销售额 desc");
            var dt = comfun.GetDataTableBySQL(pageSql);
            this.fpgHistoryList.RecordCount = totalCount;
            roomSalesRankList.DataSource = dt;
            roomSalesRankList.DataBind();
        }

        protected void fpgHistoryList_PageIndexChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}