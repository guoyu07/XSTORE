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
namespace tdx.memb.man.ShoppingMall.GrogshopManage
{
    public partial class WP_HotelList : System.Web.UI.Page
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
     
            string sql = "select jd.id,酒店全称,酒店简称,Logo,dq.名称,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 jd left join WP_地区表 dq on jd.区域id=dq.id where  jd.IsShow=1 "+where_sql+" order by jd.id desc ";
         // SqlDataAdapter sqlda = new SqlDataAdapter("select * from customers", jd);
            DataTable dt = comfun.GetDataTableBySQL(sql);
      //  sql.Fill(ds);
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


//分页值改变
        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }


        protected void ddl_areachoose()
        {
            string sql = "select id,名称 from WP_地区表 where 删除时间 is null";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_area.DataTextField = "名称";
            ddl_area.DataValueField = "id";
            this.ddl_area.DataSource = dt;
            ddl_area.DataBind();
            ddl_area.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();

        }
        protected void sousuo() {
            string jdm = txt_jdm.Text.ObjToStr();
            string asou = ddl_area.SelectedValue;
            string this_sql = "";
            if ( asou != "0")
            {
                this_sql += "  and " + asou + " in ( dq.父级id,dq.id) ";
            }
            if (jdm != "")
            {
                this_sql += " and (jd.酒店全称 like '%" + jdm + "%' or jd.酒店简称 like '%" + jdm + "%')";
            }
            string sql = "select jd.id,酒店全称,酒店简称,Logo,dq.名称,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 jd left join WP_地区表 dq on jd.区域id=dq.id where  jd.IsShow=1 " + this_sql + " order by jd.id desc ";
            // SqlDataAdapter sqlda = new SqlDataAdapter("select * from customers", jd);
            DataTable dt = comfun.GetDataTableBySQL(sql);
            //  sql.Fill(ds);
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.Rp_hotelInfo.DataSource = pdsList;
            this.Rp_hotelInfo.DataBind();
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int flag1= 0;
            int flag2 = 0;
            int flag3 = 0;
            for (int i = 0; i < Rp_hotelInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_hotelInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_hotelInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    
                    flag1=new comfun().Update(" Update WP_酒店表 set IsShow=0 where id=" + id + " ");
                    
                    flag2 = new comfun().Update(" Update WP_仓库表 set IsShow =0 where 酒店id =" + id);
                    string sql = @" select 酒店id,仓库id,库位id from 视图酒店仓库库位表 where 酒店id="+id;
                    DataTable dt=comfun.GetDataTableBySQL(sql);
                    if(dt.Rows.Count>0){
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            flag1 = new comfun().Update(" update WP_库位表 set IsShow =0 where 库位id=" + dt.Rows[j]["库位id"].ObjToStr());
                        }
                       
                    }

                   

                }
            }
                MessageBox.ShowAndRedirect(this, "删除成功！", "WP_HotelList.aspx");
        }

    }
}
