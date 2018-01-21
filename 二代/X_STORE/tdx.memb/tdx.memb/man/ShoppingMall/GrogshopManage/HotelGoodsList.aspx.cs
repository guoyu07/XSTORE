using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace tdx.memb.man.ShoppingMall.GrogshopManage
{
    public partial class HotelGoodsList : System.Web.UI.Page
    {
            public int totalcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindsql("");
                ddl_areachoose();
            }
        }
        private void bindsql(string where_sql)
        {
            string sql = @"select a.名称,b.Logo,b.酒店简称,b.酒店全称,c.id as 仓库id,c.仓库名,c.详细地址,c.电话 as 电话 from WP_地区表 a left join WP_酒店表 b on a.id=b.区域id left join WP_仓库表 c on b.id=c.酒店id where c.id is not null and b.IsShow=1 and c.IsShow=1 " + where_sql + " order by c.id desc";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            //dt.Columns.Add("酒店全称",typeof(string));
            //dt.Columns.Add("仓库名", typeof(string));
            //dt.Columns.Add("Logo", typeof(string));
            //dt.Columns.Add("名称", typeof(string));
            //if(dt.Rows.Count>0){
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //         string sql = "select 酒店全称,仓库名,Logo,名称 from 视图地区酒店仓库表  where 仓库id="+dt.Rows[i]["仓库id"] + where_sql;
            //        DataTable dtb = comfun.GetDataTableBySQL(sql);
            //        dt.Rows[i]["酒店全称"] = dtb.Rows[0]["酒店全称"];
            //        dt.Rows[i]["仓库名"] = dtb.Rows[0]["仓库名"];
            //        dt.Rows[i]["Logo"] = dtb.Rows[0]["Logo"];
            //        dt.Rows[i]["名称"] = dtb.Rows[0]["名称"];
            //    }
                
            //}
            
           
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize =10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.Rp_hotelInfo.DataSource = pdsList;
            this.Rp_hotelInfo.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
        
        protected void ddl_areachoose()
        {
            string sql = "select id,名称 from WP_地区表 where 父级id is null ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_area.DataTextField = "名称";
            ddl_area.DataValueField = "id";
            this.ddl_area.DataSource = dt;
            ddl_area.DataBind();
            ddl_area.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        //点击搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }

        protected void sousuo() {
            string jdm = txt_jdm.Text.ObjToStr();
            string asou = ddl_area.SelectedValue.ObjToStr();
            string sql = "";
            if (jdm != "")
            {
                sql += " and (b.酒店全称 like '%" + jdm + "%' or 仓库名 like '%" + jdm + "%') ";
            }
            if (asou != "0")
            {
                sql += " and a.id=" + asou;
            }

            bindsql(sql);
        }  


    }
}