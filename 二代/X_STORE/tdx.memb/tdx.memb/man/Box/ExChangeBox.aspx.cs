using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace tdx.memb.man.Box
{
    public partial class ExChangeBox : System.Web.UI.Page
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
            string sql = @"select a.id,mac,原库位id,新库位id,申请时间,操作时间,用户名,a.状态 from WP_换箱表 a left join WP_用户表 b on a.openid=b.openid where 1=1 "+where_sql+" order by 申请时间 desc";
            DataTable dt = new comfun().GetDataTable(sql);
            dt.Columns.Add("原库位名", typeof(string));
            dt.Columns.Add("新库位名", typeof(string));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dtb = new comfun().GetDataTable(@"select 库位名 from WP_库位表 where id=" + dt.Rows[i]["原库位id"]);
                    if (dtb.Rows.Count > 0)
                    {
                        dt.Rows[i]["原库位名"] = dtb.Rows[0]["库位名"];
                    }
                    DataTable dtc = new comfun().GetDataTable(@"select 库位名 from WP_库位表 where id=" + dt.Rows[i]["新库位id"]);
                    if (dtc.Rows.Count > 0)
                    {
                        dt.Rows[i]["新库位名"] = dtc.Rows[0]["库位名"];
                    }

                }
            }
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPagerIn.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPagerIn.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPagerIn.RecordCount = dt.Rows.Count;//记录总数
            this.AspNetPagerIn.PageSize = 10;
            Rp_changeGoods.DataSource = pdsList;
            Rp_changeGoods.DataBind();

        }
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo()
        {
            string kwname = mac_name.Text.ObjToStr();
            string ztlx = zt_lx.SelectedValue;
            string start_time = Jxl.Value.ObjToStr();
            string end_time = Jx2.Value.ObjToStr();
            string where_sql = "";
            if (kwname != "")
            {
                where_sql += " and mac like '%" + kwname + "%'";
            }
            if (ztlx != "0")
            {
                where_sql += " and a.状态=" + ztlx;
            }
            if (start_time != "")
            {
                where_sql += " and 申请时间> '" + start_time + "'";
            }
            if (end_time != "")
            {
                where_sql += " and 申请时间<'" + end_time + "'";
            }
            bind(where_sql);
        }
        protected void AspNetPagerIn_PageChanged(object sender, PageChangingEventArgs e)
        {
            AspNetPagerIn.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }

        protected string Getzt(string zt)
        {
            string zz = "show";
            switch (zt)
            {
                case "1":
                    break;
                case "2":
                    zz = "none";
                    break;
                case "3":
                    zz = "none";
                    break;
            }
            return zz;
        }
        protected string Getzt2(string zt)
        {
            string zz = "show";
            switch (zt)
            {
                case "1":
                    zz = "none";
                    break;
                case "2":
                    break;
                case "3":
                    zz = "none";
                    break;
            }
            return zz;
        }
        protected string Getzt3(string zt)
        {
            string zz = "show";
            switch (zt)
            {
                case "1":
                    zz = "none";
                    break;
                case "2":
                    zz = "none";
                    break;
                case "3":
                    break;
            }
            return zz;
        }
        protected string GetztName(string zt)
        {
            string zz = "";
            switch (zt)
            {
                case "1":
                    zz = "申请审核中";
                    break;
                case "2":
                    zz = "申请通过";
                    break;
                case "3":
                    zz = "申请未通过";
                    break;
            }
            return zz;
        }

    }
}