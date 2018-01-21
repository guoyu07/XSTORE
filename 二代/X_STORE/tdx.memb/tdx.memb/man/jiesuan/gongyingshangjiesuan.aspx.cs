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
    public partial class gongyingshangjiesuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                list();
                ddl();
                ddl_gys.Items.Insert(0, new ListItem("--请选择--", "0"));
            }
        }
        protected void list() {
           //int gys_id=Convert.ToInt32( ddl_gys.SelectedValue.ToString());
            // string sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where 供应商id=2 and 操作日期>'2017-05-07' group by 供应商id,公司名称,操作日期,[user_name]";
            string sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id group by 供应商id,公司名称,操作日期,[user_name]";
           DataTable dt = comfun.GetDataTableBySQL(sql);
           PagedDataSource pdsList = new PagedDataSource();
           pdsList.DataSource = dt.DefaultView;
           pdsList.AllowPaging = true;//数据源允许分页
           pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
           pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
           //设置控件
           this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
           this.AspNetPager1.PageSize = 10;
           this.Rp_gys.DataSource = pdsList;
           this.Rp_gys.DataBind();
        }
        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            list();
        }
        protected void ddl()
        {
            string sql = "select 编号 as id,公司名称 from WP_客户资料 where 是否供应商 = 'true'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_gys.DataTextField = "公司名称";
            ddl_gys.DataValueField = "id";
            ddl_gys.DataSource = dt;
            ddl_gys.DataBind();
        }

        protected void ddl_gys_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gys_id = Convert.ToInt32(ddl_gys.SelectedValue.ToString());

          string  sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where 供应商id='" + gys_id + "'group by 供应商id,公司名称,操作日期,[user_name]";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.AspNetPager1.PageSize = 10;
            this.Rp_gys.DataSource = pdsList;
            this.Rp_gys.DataBind();
        }

        protected void sousuo_Click(object sender, EventArgs e)
        {
            string starttime = this.txt_start.Value;
            string endtime = this.txt_end.Value;
            string sql = "";
            int gys_id = Convert.ToInt32(ddl_gys.SelectedValue.ToString());
            if (starttime != "" && endtime != ""&&gys_id!=0)
            {
                sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where 供应商id='" + gys_id + "'and 操作日期 between '" + starttime + "' and '" + endtime + "'group by 供应商id,公司名称,操作日期,[user_name]";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                PagedDataSource pdsList = new PagedDataSource();
                pdsList.DataSource = dt.DefaultView;
                pdsList.AllowPaging = true;//数据源允许分页
                pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
                pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
                //设置控件
                this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
                this.AspNetPager1.PageSize = 10;
                this.Rp_gys.DataSource = pdsList;
                this.Rp_gys.DataBind();
            }
            else if (gys_id == 0 && starttime != "" && endtime != "")
            {
                sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where 操作日期 <'" + endtime + "'group by 供应商id,公司名称,操作日期,[user_name]";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                PagedDataSource pdsList = new PagedDataSource();
                pdsList.DataSource = dt.DefaultView;
                pdsList.AllowPaging = true;//数据源允许分页
                pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
                pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
                //设置控件
                this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
                this.AspNetPager1.PageSize = 10;
                this.Rp_gys.DataSource = pdsList;
                this.Rp_gys.DataBind();
            }
            else if (starttime != "" && gys_id != 0)
            {
                sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where 供应商id='" + gys_id + "'and 操作日期 >'" + starttime + "' group by 供应商id,公司名称,操作日期,[user_name]";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                PagedDataSource pdsList = new PagedDataSource();
                pdsList.DataSource = dt.DefaultView;
                pdsList.AllowPaging = true;//数据源允许分页
                pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
                pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
                AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
                AspNetPager1.PageSize = 10;
                Rp_gys.DataSource = pdsList;
                Rp_gys.DataBind();
            }
            else if (endtime != "" && gys_id != 0)
            {
                sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where 供应商id='" + gys_id + "'and 操作日期 < '" + endtime + "'group by 供应商id,公司名称,操作日期,[user_name]";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                PagedDataSource pdsList = new PagedDataSource();
                pdsList.DataSource = dt.DefaultView;
                pdsList.AllowPaging = true;//数据源允许分页
                pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
                pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
                AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
                AspNetPager1.PageSize = 10;
                Rp_gys.DataSource = pdsList;
                Rp_gys.DataBind();
            }
            else if (starttime != "" && gys_id == 0)
            {
                sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where  操作日期 > '" + starttime + "' group by 供应商id,公司名称,操作日期,[user_name]";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                PagedDataSource pdsList = new PagedDataSource();
                pdsList.DataSource = dt.DefaultView;
                pdsList.AllowPaging = true;//数据源允许分页
                pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
                pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
                AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
                AspNetPager1.PageSize = 10;
                Rp_gys.DataSource = pdsList;
                Rp_gys.DataBind();
            }
            else if (endtime != "" && gys_id == 0)
            {
                sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id where  操作日期 < '" + endtime + "'group by 供应商id,公司名称,操作日期,[user_name]";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                PagedDataSource pdsList = new PagedDataSource();
                pdsList.DataSource = dt.DefaultView;
                pdsList.AllowPaging = true;//数据源允许分页
                pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
                pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
                AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
                AspNetPager1.PageSize = 10;
                Rp_gys.DataSource = pdsList;
                Rp_gys.DataBind();
            }
          

        }

        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string sql = "select  sum(总进价额) as total,公司名称,供应商id,操作日期,[user_name] from WP_入库表 left join WP_客户资料 on WP_入库表.供应商id=WP_客户资料.编号 left join dt_manager on dt_manager.id=WP_入库表.操作id group by 供应商id,公司名称,操作日期,[user_name]";
            DataTable dt1 = comfun.GetDataTableBySQL(sql);

            if (dt1.Rows.Count > 0)
            {
                DTcms.Common.Excel.DataTable4Excel(dt1, "供应商结算表");
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }
    }
}