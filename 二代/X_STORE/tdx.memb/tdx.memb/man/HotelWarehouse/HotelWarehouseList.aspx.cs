using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using DTcms.DBUtility;
using DTcms.Common;
using System.Text;
using System.Data.SqlClient;
using Wuqi.Webdiyer;

namespace tdx.memb.man.HotelWarehouse
{
    public partial class HotelWarehouseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind("");
            }
        }
        private void bind(string ss)
        {
            string sql = @"select c.名称,b.Logo,b.酒店简称,b.酒店全称,a.id,a.仓库名,a.详细地址,a.电话 
from WP_仓库表 a left join WP_酒店表 b on a.酒店id=b.id left join WP_地区表 c on b.区域id=c.id 
where a.id is not null and b.IsShow =1 and a.IsShow=1 "+ss+" order by a.仓库名 collate Chinese_PRC_CS_AS_KS_WS";
            //string sql = "select 仓库,酒店,仓库id,logo from 视图库位表";
            DataTable dt = comfun.GetDataTableBySQL(sql);
             PagedDataSource pdsList = new PagedDataSource();
             pdsList.DataSource = dt.DefaultView;
             pdsList.AllowPaging = true;//数据源允许分页
             pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
             pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
             //设置控件
             this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
             this.AspNetPager1.PageSize = 10;
             this.Rp_hotelwarehouse.DataSource = pdsList;
             this.Rp_hotelwarehouse.DataBind();


        }
        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Rp_hotelwarehouse.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_hotelwarehouse.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_hotelwarehouse.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DbHelperSQL.GetSingle(" update [dbo].[WP_仓库表] set IsShow=0 WHERE id=" + id + " ");
                    string sql = @" select 酒店id,仓库id,库位id from 视图酒店仓库库位表 where 仓库id=" + id;
                    DataTable dt = comfun.GetDataTableBySQL(sql);
                    if (dt.Rows.Count > 0)
                    {
                        DbHelperSQL.GetSingle(" update WP_库位表 set IsShow =0 where 酒店id=" + dt.Rows[0]["酒店id"].ObjToStr());
                        DbHelperSQL.GetSingle(" update WP_");
                    }
                    MessageBox.Show(this, "删除成功！");

                }
            }
            bind("");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='HotelWarehouseList.aspx'", true);
        }

        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo() {
            string ser = ckmjdm.Value;
            string sql = "";
            if (ser != "")
            {
                sql = " and (酒店全称 like '%" + ser + "%' or 酒店简称 like '%" + ser + "%' or 仓库名 like '%" + ser + "%')  ";
            }
            bind(sql);

        }

    }
}