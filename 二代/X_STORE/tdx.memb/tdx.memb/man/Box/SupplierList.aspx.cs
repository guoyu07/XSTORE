using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Box
{
    public partial class SupplierList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bound("");
            }
        }
        protected void bound( string where_sql) {
            string sql = @"select * from WP_客户资料 where IsShow=1 and 是否供应商=1 "+where_sql;
            DataTable dt=comfun.GetDataTableBySQL(sql);

            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPagerIn.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPagerIn.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPagerIn.RecordCount = dt.Rows.Count;//记录总数
            this.AspNetPagerIn.PageSize = 10;
            Rp_supplier.DataSource = pdsList;
            Rp_supplier.DataBind();
        }


        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Rp_supplier.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_supplier.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_supplier.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //DbHelperSQL.GetSingle(" update [dbo].[WP_入库表] set IsShow=0 WHERE id=" + id + " ");
                    new comfun().Update(" update WP_客户资料 set IsShow=0 where 编号='" + id + "'");
                    MessageBox.Show(this, "删除成功！");

                }
            }
            bound("");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='SupplierList.aspx'", true);

        }

        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo(){
        string where_sql="";
            string company_name = txt_company_name.Text.Trim();
            string phono = txt_phono.Text.Trim();
            if(company_name!=""){
                where_sql+=" and 公司名称 like '%"+company_name+"%'";
            }
            if(phono!=""){
                where_sql += " and 电话 like '%"+phono+"%'";
            }
            bound(where_sql);
        }

        protected void AspNetPagerIn_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPagerIn.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }

    }
}