using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace tdx.memb.man.HotelWarehouse
{
    public partial class Region : System.Web.UI.Page
    {
        /// <summary>
        /// 0 未删除
        /// 1 删除
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind("");       
            }
        }

        protected void bind(string where_sql) {
            string sql = @"select id,名称,区号 from WP_地区表 where 是否删除=0 "+where_sql;
            DataTable dt = new comfun().GetDataTable(sql);
            Rp_region.DataSource = dt;
            Rp_region.DataBind();


        }

        //搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo() {
            string name = Region_Name.Value.ObjToStr();
            string where_sql = "";
            if (name != "")
            {
                where_sql += @" and 名称 like '%" + name + "%'";
            }
            bind(where_sql);
        }

        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}