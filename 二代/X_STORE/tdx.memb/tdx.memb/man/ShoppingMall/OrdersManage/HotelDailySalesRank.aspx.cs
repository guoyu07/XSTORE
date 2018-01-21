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
    public partial class HotelDailySalesRank : System.Web.UI.Page
    {
        public Dictionary<string, string> dic = new Dictionary<string, string>();
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
            var selectSql = string.Format(@"select 酒店名称,房间数,当日销售额,销量,Convert(decimal(18,2),日均房) as 日均房,日期 from View_HotelDailySaleRank");
            var pageSql = PagingHelper.CreatePagingSql(totalCount, this.fpgHistoryList.PageSize, this.fpgHistoryList.CurrentPageIndex, selectSql, " 日均房 desc");
            var dt = comfun.GetDataTableBySQL(pageSql);
            this.fpgHistoryList.RecordCount = totalCount;
            hotelSalesRankList.DataSource = dt;
            hotelSalesRankList.DataBind();
        }

        protected void fpgHistoryList_PageIndexChanged(object sender, EventArgs e)
        {
            PageInit();
        }

    }
}