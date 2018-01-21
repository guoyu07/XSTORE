using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace tdx.memb.man.jiesuan
{
    /// <summary>
    /// 状态
    ///  1 配货完成
    ///  2 酒店经理申请配货
    ///  3 配货中(物流)
    ///  4 出库操作
    /// </summary>
    public partial class peihuoxinxi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind("");
            }
        }
        protected void bind(string where_sql)
        {
            string sql = @" select a.物流公司,a.物流单号,a.id,时间,user_name as 操作员,e.品名,操作员id, a.数量,b.id as 仓库id,
  b.仓库名,c.id as 酒店id,c.酒店全称,a.状态   
  from WP_配货信息表 a
  left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on b.酒店id=c.Id left join dt_manager d on a.操作员id=d.id 
  left join WP_商品表 e on e.id=a.商品id 
  where b.id is not null" + where_sql;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            AspNetPager1.PageSize = 10;
            Rp_phxx.DataSource = pdsList;
            Rp_phxx.DataBind();

        }
        protected string Getzt1(string zt) {//1  已完成,不可点击
            string boo = "none";
            switch (zt)
            {
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    boo = "true";
                    break;
            }
            return boo;
        }
        protected string Getzt2(string zt)//2  配货清单
        {
            string boo = "none";
            switch (zt)
            {
                case "1":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    boo = "true";
                    break;
            }
            return boo;
        }
        protected string Getzt3(string zt)//3  查看物流
        {
            string boo = "none";
            switch (zt)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "4":
                    break;
                default:
                    boo = "true";
                    break;
            }
            return boo;
        }

        protected string Getzt(string zt)
        {
            string boo = "";
            switch (zt)
            {
                case "1":
                    boo = "配货完成";
                    break;
                case "2":
                    boo = "同意申请";
                    break;
                case "3":
                    boo = "查看物流";
                    break;
                default:
                    boo = "出库";
                    break;
            }
            return boo;
        }
        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }


        protected void sousuo_Click(object sender, EventArgs e)
        {

            sousuo();
        }

        protected string sousuo() {
            string starttime = this.txt_start.Value.ObjToStr();
            string endtime = this.txt_end.Value.ObjToStr();
            string hotel = txt_hotel.Text.Trim().ObjToStr();
            string zt = ddl_zt.SelectedValue;
            string sql = "";
            if (starttime != "")
            {
                DateTime start = starttime.StrToDateTime(DateTime.MinValue);
                sql += " and 操作日期>'" + start + "'";
            }
            
            if (endtime != "")
            {
                DateTime end = endtime.StrToDateTime(DateTime.MinValue);
                sql += " and 操作日期<'" + end + "'";
            }
            if (hotel != "")
            {
                sql += " and (酒店全称 like '%" + hotel + "%' or 仓库名 like '%"+hotel+"%')";
            }
            if(zt!="0"){
                sql+=" and a.状态="+zt;
            }
            bind(sql);
            return sql;
        }

        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string where_sql = sousuo();
            string sql = @"select a.物流公司,a.物流单号,a.id,操作日期,user_name as 操作员,g.品名,操作员id, b.数量, 库位, 酒店名称,c.id as 库位id,库位名,d.id as 仓库id,仓库名,e.id as 酒店id,酒店全称,,case a.状态 when '1' then '配货完成' when '2' then '配货申请中' when '3' then '发货中' when '4' then '出库' end    
  from WP_配货信息表 a left join WP_出库表 b on a.出库编号=b.单据编号 left join WP_库位表 c on b.库位id=c.id 
  left join WP_仓库表 d on c.仓库id=d.id left join WP_酒店表 e on d.酒店id=e.Id left join dt_manager f on a.操作员id=f.id left join WP_商品表 g on g.id=b.商品id
  where c.id is not null" + where_sql;
            DataTable dt1 = comfun.GetDataTableBySQL(sql);

            if (dt1.Rows.Count > 0)
            {
                DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt1, "配货信息" + DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }
    }
}