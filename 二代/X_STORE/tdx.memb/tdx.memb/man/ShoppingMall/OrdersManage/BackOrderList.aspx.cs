using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class BackOrderList : System.Web.UI.Page
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
        protected void PageInit()
        {
            var whereSql = " 1=1";
            var keyWord = txtKeywords.Text.ObjToStr();
            var beginTime = txtBeginTime.Value.ObjToStr();
            var endTime = txtEndTime.Value.ObjToStr();
            var orderState = orderStateDll.SelectedValue.ObjToInt(0);
            if (!string.IsNullOrEmpty(keyWord))
            {
                whereSql += string.Format(" and (OrderNo like '%{0}%' or 酒店名称 like '%{0}%' or 房间名称 like '%{0}%' or 用户名 like '%{0}%' or 手机号 like '%{0}%' or Mac like '%{0}%')", keyWord);
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                whereSql += string.Format(" and CreateTime >= '{0}'", beginTime);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                endTime = DateTime.Parse(endTime).AddDays(1).ToString("yyyy-MM-dd");
                whereSql += string.Format(" and CreateTime <= '{0}'", endTime);
            }
            if (orderState != 0)
            {
                whereSql += string.Format(" and Status = {0}", orderState);
            }
           
            var selectSql = string.Format(@" select * from (
  SELECT 
  a.OrderNo,
  b.用户名,
  b.手机号,
  (select 仓库名 from WP_仓库表 where id = a.HotelId) as 酒店名称,
  (select 库位名 from WP_库位表 where id=a.RoomId) as 房间名称,
  a.Mac,a.Position as 开箱位置,a.FailPosition as 失败位置,a.Status,a.CreateTime,a.ModifyTime
   FROM wp_补货单 a
   left join WP_用户表 b on a.Operator = b.id
   ) b where {0}", whereSql);
            var totalDt = comfun.GetDataTableBySQL(selectSql);
            var pageSql = PagingHelper.CreatePagingSql(totalDt.Rows.Count, this.fpgHistoryList.PageSize, this.fpgHistoryList.CurrentPageIndex, selectSql, " CreateTime desc");
            DataTable dt = comfun.GetDataTableBySQL(pageSql);
            this.fpgHistoryList.RecordCount = totalDt.Rows.Count;
            rptList1.DataSource = dt;
            rptList1.DataBind();
        }

        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PageInit();
        }
        #endregion

        protected void fpgHistoryList_PageIndexChanged(object sender, EventArgs e)
        {
            PageInit();
        }
        protected string FormatOrderState(string orderState)
        {
            switch ((EnumCommon.开箱单状态)(orderState.ObjToInt(0)))
            {
                case EnumCommon.开箱单状态.待开箱:
                    return "<span class='noopen'>待开箱<span>";
                case EnumCommon.开箱单状态.开箱成功:
                    return "<span class='successpay'>已开箱<span>";
                case EnumCommon.开箱单状态.开箱失败:
                    return "<span class='failopen'>开箱失败<span>";
            
                default:
                    return "<span class='nopay'>未付款<span>";
            }
        }
    }
}