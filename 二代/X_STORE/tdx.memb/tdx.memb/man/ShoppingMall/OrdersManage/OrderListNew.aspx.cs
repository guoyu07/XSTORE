using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data.SqlClient;
using Wuqi.Webdiyer;
using Creatrue.Common.Msgbox;
using DTcms.Common.Helper;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class OrderListNew : System.Web.UI.Page
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

        private void PageInit()
        {

            var whereSql = " 1=1 ";
            var keyWord = txtKeywords.Text.ObjToStr();
            var beginTime = txtBeginTime.Value.ObjToStr();
            var endTime = txtEndTime.Value.ObjToStr();
            var orderState = orderStateDll.SelectedValue.ObjToInt(0);
            if (!string.IsNullOrEmpty(keyWord))
            {
                whereSql += string.Format(" and (订单编号 like '%{0}%' or 酒店名称 like '%{0}%' or 房间名称 like '%{0}%')", keyWord);
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                whereSql += string.Format(" and 下单时间 >= '{0}'", beginTime);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                endTime = DateTime.Parse(endTime).AddDays(1).ToString("yyyy-MM-dd");
                whereSql += string.Format(" and 下单时间 <= '{0}'", endTime);
            }
            if (orderState != 0)
            {
                if (orderState == 1)
                {
                    whereSql += string.Format(" and 订单状态 in (0,1)");
                }
                else
                {
                    whereSql += string.Format(" and 订单状态 = {0}", orderState);
                }
               
            }
            else
            {
                whereSql += string.Format(" and 订单状态 not in(0,1)");
            }
            var totalSql = string.Format(@"select * from View_OrderList where {0}", whereSql);
            var totalDt = comfun.GetDataTableBySQL(totalSql);
            ViewState["exportSql"] = string.Format(@"select 订单编号,酒店名称,房间名称,商品信息,销量,总金额,
case 订单状态 when 0 then '待付款' when 1 then '待付款' when 3 then '已开箱' when 5 then '开箱失败' end as 订单状态,下单时间 from View_OrderList where {0}", whereSql);
            var totalCount = totalDt.Rows.Count;
            string orderSql = string.Format(@"select * from View_OrderList where {0}",whereSql);

            var pageSql = PagingHelper.CreatePagingSql(totalCount, this.fpgHistoryList.PageSize, this.fpgHistoryList.CurrentPageIndex, orderSql, "下单时间 desc");
            DataTable dt = comfun.GetDataTableBySQL(pageSql);
            decimal totalAmount = 0;
            int totalSale = 0;
            foreach (DataRow dr in totalDt.Rows)
            {
                totalAmount += dr["总金额"].ObjToDecimal(0);
                totalSale += dr["销量"].ObjToInt(0);
            }
            dic["总金额"] = totalAmount.ObjToStr();
            dic["销量"] = totalSale.ObjToStr();
            this.fpgHistoryList.RecordCount = totalCount;
            this.rptList1.DataSource = dt;
            this.rptList1.DataBind();
        }
        #region 分页
        protected void fpgHistoryList_PageIndexChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        #endregion

        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PageInit();
        }
        #endregion

        protected string FormatOrderState(string orderState)
        {
            switch ((EnumCommon.订单状态)(orderState.ObjToInt(0)))
            {
                case EnumCommon.订单状态.待付款:
                    return "<span class='nopay'>未付款<span>";
                case EnumCommon.订单状态.待开箱:
                    return "<span class='noopen'>待开箱<span>";
                case EnumCommon.订单状态.已开箱:
                    return "<span class='successpay'>已开箱<span>";
                case EnumCommon.订单状态.开箱失败:
                    return "<span class='failopen'>开箱失败<span>";
                case EnumCommon.订单状态.支付失败:
                    return "<span class='failpay'>支付失败<span>";
                case EnumCommon.订单状态.待处理:
                    return "<span class='refundpay'>待处理<span>";
                case EnumCommon.订单状态.退款完成:
                    return "<span class='refundsuccess'>退款完成<span>";
                default:
                    return "<span class='nopay'>未付款<span>";
            }
        }


        #region 订单导出
        protected void btnExport_OnClick(object sender, EventArgs e)
        {
            string sql = ViewState["exportSql"].ObjToStr();
            DataTable dt = comfun.GetDataTableBySQL(sql);
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "订单信息" + DateTime.Now.ToString("yyyy-MM-dd"));
        }
        #endregion

        protected void OpenBox_Click(object sender, EventArgs e)
        {

            var selectSql = string.Format(@"select 订单编号,mac, LEFT(位置,LEN(位置)-1) as 位置 from (
select top 1 
(select isnull(箱子MAC,'') from WP_库位表 where id = a.库位id) as mac,
(select convert(nvarchar(2),位置-1)+',' from WP_订单子表 where 订单编号 = a.订单编号 FOR XML PATH('')) as 位置,
a.订单编号
 from WP_订单子表 a left join WP_订单表 b on a.订单编号 = b.订单编号 where b.订单编号 = '{0}'
) as c", ((LinkButton)sender).Attributes["OrderNo"].ObjToStr());
            Log.WriteLog("_openboxTimer_Elapsed", "sql：" + selectSql, "------");

            DataTable selectDt = comfun.GetDataTableBySQL(selectSql);
            Log.WriteLog("_openboxTimer_Elapsed", "selectDtCount：" + selectDt.Rows.Count, "------");
            if (selectDt.Rows.Count != 0)
            {
                var begin_exsql = " Begin Tran ";
                var exsql = string.Empty;
                var end_sql = @" If @@ERROR>0
                                    Rollback Tran  
                                Else
                                    Commit Tran
                                Go";
                var orderNo = selectDt.Rows[0]["订单编号"].ToString();
                var position = selectDt.Rows[0]["位置"].ToString();
                var mac = selectDt.Rows[0]["mac"].ToString();
                OpenBox(orderNo, mac, position);
                PageInit();

            }
        }

        protected void ChangeState_Click(object sender, EventArgs e)
        {
            var orderNo = ((LinkButton)sender).Attributes["OrderNo"].ObjToStr();
            var updateSql = string.Format(@"update WP_订单表 set state = {0} where 订单编号 = '{1}'", (int)EnumCommon.订单状态.退款完成, orderNo);
            var b = comfun.UpdateBySQL(updateSql);
            PageInit();

        }
        private bool OpenBox(string orderNo, string mac, string postion_list)
        {

            var rbh = new RemoteBoxHelper();
            try
            {

                rbh.OpenRemoteBox("" + mac + "", orderNo.Substring(1, orderNo.Length - 1), "" + postion_list + "");
                return true;


            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：qaBoxCheck", "方法：qaBoxCheck", "异常信息：" + ex.Message);
                return false;
            }

        }
    }
}