using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DTcms.DBUtility;
using Creatrue.kernel;
using System.Data.SqlClient;
using Wuqi.Webdiyer;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class saleChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if(!IsPostBack){
                loadinfo();
            }

        }
        PagedDataSource pdsList = new PagedDataSource();
        private void loadinfo()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(@"SELECT 订单编号,支付方式 ,支付金额,支付时间 FROM WP_订单支付表");
            DataTable dt = comfun.GetDataTableBySQL(sbsql.ToString());

            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.rptList1.DataSource = pdsList;//绑定数据源
            this.rptList1.DataBind();
        }
        //分页数改变
        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            loadinfo();
        }
    }


}