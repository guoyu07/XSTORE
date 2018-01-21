using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class RoomSalesRank : System.Web.UI.Page
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
            var keyWord = txtKeywords.Text;
            var beginAmount = txtBeginAmount.Text.ObjToInt(0);
            var endAmount = txtEndAmount.Text.ObjToInt(0);
            var beginRijun = txtBeginRijun.Text.ObjToInt(0);
            var endRijun = txtEndRijun.Text.ObjToInt(0);
            var beginTime = txtBeginTime.Value.ObjToStr();
            var endTime = txtEndTime.Value.ObjToStr();
            var orderSql = " 首次入驻 desc";
            if (!string.IsNullOrEmpty(sort))
            {
                orderSql = sort;
            }
            else if (!string.IsNullOrEmpty(ViewState["Sort"].ObjToStr()))
            {
                orderSql = ViewState["Sort"].ObjToStr();
            }

            var whereSql = " 1=1";
            var saleRankWhereSql = " 1=1";
            var amountRankWhereSql = " 1=1";
            if (!string.IsNullOrEmpty(keyWord))
            {
                whereSql += string.Format("and (酒店名称 like '%{0}%' or 房间名 like '%{0}%')", keyWord);
            }
            if (beginAmount != 0)
            {
                whereSql += string.Format("and 金额 >= {0}", beginAmount);
            }
            if (endAmount != 0)
            {
                whereSql += string.Format("and 金额 <= {0}", beginAmount);
            }
            if (beginRijun != 0)
            {
                whereSql += string.Format("and 日均房 >= {0}", beginRijun);
            }
            if (endRijun != 0)
            {
                whereSql += string.Format("and 日均房 <= {0}", endRijun);
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                saleRankWhereSql += string.Format(" and WP_订单表.下单时间 >= '{0}'", beginTime);
                amountRankWhereSql += string.Format(" and WP_订单表_2.下单时间 >= '{0}'", beginTime);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                endTime = DateTime.Parse(endTime).AddDays(1).ToString("yyyy-MM-dd");
                saleRankWhereSql += string.Format(" and WP_订单表.下单时间 <= '{0}'", endTime);
                amountRankWhereSql += string.Format(" and WP_订单表_2.下单时间 <= '{0}'", endTime);
            }
            var saleRankSql =
                string.Format(
                    @"SELECT   酒店名称, 库位名 as 房间名, ISNULL(销量, 0) AS 销量, ISNULL(金额, 0) AS 金额, ISNULL(日均房, 0) AS 日均房, 首次入驻
FROM      (SELECT   WP_仓库表.仓库名 AS 酒店名称,WP_库位表.库位名,
                                     (SELECT   SUM(dbo.WP_订单子表.数量) AS Expr1
                                      FROM      dbo.WP_订单子表 LEFT OUTER JOIN
                                                      dbo.WP_订单表 ON dbo.WP_订单子表.订单编号 = dbo.WP_订单表.订单编号
                                      WHERE   (dbo.WP_订单子表.库位id = WP_库位表.id) AND (dbo.WP_订单表.state IN (3, 5)) AND {0}) AS 销量,
                                     (SELECT   SUM(WP_订单子表_2.价格) AS Expr1
                                      FROM      dbo.WP_订单子表 AS WP_订单子表_2 LEFT OUTER JOIN
                                                      dbo.WP_订单表 AS WP_订单表_2 ON 
                                                      WP_订单子表_2.订单编号 = WP_订单表_2.订单编号
                                      WHERE   (WP_订单子表_2.库位id = WP_库位表.id) AND (WP_订单表_2.state IN (3, 5)) AND {3}) AS 金额, dbo.RoomDayAverage(WP_库位表.id,'{1}','{2}') 
                                 AS 日均房,
                                     (SELECT   TOP (1) WP_订单子表_1.下单时间
                                      FROM      dbo.WP_订单子表 AS WP_订单子表_1 LEFT OUTER JOIN
                                                      dbo.WP_订单表 AS WP_订单表_1 ON 
                                                      WP_订单子表_1.订单编号 = WP_订单表_1.订单编号
                                      WHERE   (WP_订单子表_1.库位id = WP_库位表.id) AND (WP_订单表_1.state IN (3, 5))
                                      ORDER BY WP_订单子表_1.下单时间) AS 首次入驻
                 FROM   dbo.WP_库位表 LEFT JOIN  dbo.WP_仓库表 ON WP_库位表.仓库id = WP_仓库表.id WHERE 库位名 NOT LIKE '%总台%' ) AS b", saleRankWhereSql, beginTime, endTime, amountRankWhereSql);


            var totalSql = string.Format(@"select * from ({1}) as c where {0} order by {2}", whereSql, saleRankSql, orderSql);
            ViewState["exportSql"] = totalSql;
            var totalDt = comfun.GetDataTableBySQL(totalSql);
            var totalCount = totalDt.Rows.Count;
            var selectSql = string.Format(@"select 酒店名称,房间名,销量,金额,日均房,首次入驻 from ({1}) as c  where {0}", whereSql, saleRankSql);
            var pageSql = PagingHelper.CreatePagingSql(totalCount, this.fpgHistoryList.PageSize, this.fpgHistoryList.CurrentPageIndex, selectSql, orderSql);
            var dt = comfun.GetDataTableBySQL(pageSql);

            var _sql = string.Format(@"select isnull(sum(销量),1) as 总销量,sum(金额) as 总金额,case sum(销量) when 0 then 0 else (sum(金额)/sum(销量)) end as 客单价 from ({1}) as c where {0}", whereSql, saleRankSql);
            var _dt = comfun.GetDataTableBySQL(_sql);
            dic["总金额"] = _dt.Rows[0]["总金额"].ObjToDecimal(0).ObjToStr();
            dic["总销量"] = _dt.Rows[0]["总销量"].ObjToInt(0).ObjToStr();
            dic["客单价"] = _dt.Rows[0]["客单价"].ObjToDecimal(0).ToString("F2");
            this.fpgHistoryList.RecordCount = totalCount;
            hotelSalesRankList.DataSource = dt;
            hotelSalesRankList.DataBind();
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["Sort"] = string.Empty;
            PageInit();
        }
        protected void fpgHistoryList_PageIndexChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected void SortImgBtn_OnClick(object sender, ImageClickEventArgs e)
        {
            var btn = (ImageButton)sender;
            var nextSort = string.Empty;
            var sortType = btn.Attributes["SortType"];
            if (btn.Attributes["Sort"].Equals("asc"))
            {
                nextSort = "desc";
                btn.Attributes["Sort"] = nextSort;
                btn.ImageUrl = "../../Image/sort37.png";
            }
            else
            {
                nextSort = "asc";
                btn.Attributes["Sort"] = nextSort;
                btn.ImageUrl = "../../Image/sort33.png";

            }
            ViewState["Sort"] = sortType + " " + nextSort;
            PageInit(sortType + " " + nextSort);
        }


        #region 订单导出
        protected void btnExport_OnClick(object sender, EventArgs e)
        {
            string sql = ViewState["exportSql"].ObjToStr();
            DataTable dt = comfun.GetDataTableBySQL(sql);
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "房间累计业绩" + DateTime.Now.ToString("yyyy-MM-dd"));
        }
        #endregion
    }
}