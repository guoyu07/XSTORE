using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using Wuqi.Webdiyer;
namespace tdx.memb.man.jiesuan
{
    public partial class Hoteljiesuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind("");
            }
        }
        protected DataTable bind(string ss)
        {
            string sql = @"select id,仓库名,仓库id,结算金额,结算日期,经办人 from WP_酒店结算表 where 1=1 "+ss+" order by 结算日期 desc";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            AspNetPager1.PageSize = 10;
            Rp_jdjs.DataSource = pdsList;
            Rp_jdjs.DataBind();
            return dt;
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
            string starttime = this.txt_start.Value;
            string endtime = this.txt_end.Value;
            string hotel = hotel_name.Text.Trim();
            string sql = "";
            if (starttime != "")
            {
                DateTime start = starttime.StrToDateTime(DateTime.MinValue);
                sql += " and 结算日期 >'" + start + "'";
            }
            if (endtime != "")
            {
                DateTime end = endtime.StrToDateTime(DateTime.MinValue);
                sql += " and 结算日期<'" + end.AddDays(1) + "'";
            }
            if (hotel != "")
            {
                sql += " and 仓库名 like '%" + hotel + "%'";
            }
            bind(sql);
            return sql;
        }

        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string where_sql=sousuo();
            DataTable dt = bind(where_sql);

            if (dt.Rows.Count > 0)
            {
                DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "酒店结算清单表" + DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }
    }
}