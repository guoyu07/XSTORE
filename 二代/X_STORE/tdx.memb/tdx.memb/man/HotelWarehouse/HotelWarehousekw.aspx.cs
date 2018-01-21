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
using DTcms.Model;
using System.Text;
using System.Data.SqlClient;
using Wuqi.Webdiyer ;

namespace tdx.memb.man.HotelWarehouse
{
    public partial class HotelWarehousekw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.fpgHistoryList.CurrentPageIndex = 1;
                this.fpgHistoryList.PageSize = 20;
                PageInit();
                //bind("");
                //area();
                //ddl_hotel.Items.Insert(0,new ListItem("--请选择--","0"));
                //ddl_warehouse.Items.Insert(0,new ListItem("--请选择--","0"));
                //ddl_box.Items.Insert(0,new ListItem("--请选择--","0"));
            }
        }

        private void PageInit()
        {
            var whereSql = " a.IsShow=1 and b.IsShow=1 and c.IsShow=1 and a.库位名 not like '%总台%'";
            var keyWords = txtKeywords.Text.ObjToStr();
            if (!string.IsNullOrEmpty(keyWords))
            {
                whereSql += string.Format(" and (c.酒店全称 like '%{0}%' or b.仓库名 like '%{0}%' or a.库位名 like '%{0}%' or 箱子MAC like '%{0}%')",
                    keyWords);
            }
            string sql = @"select a.id as 库位id,a.库位名 as 库位,c.酒店全称 as 酒店全称,b.仓库名 as 仓库,箱子MAC 
              from WP_库位表 a left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on b.酒店id=c.id 
              where " + whereSql;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            var totalCount = dt.Rows.Count;
            var pageSql = PagingHelper.CreatePagingSql(totalCount, this.fpgHistoryList.PageSize, this.fpgHistoryList.CurrentPageIndex, sql, " 库位id desc");
            DataTable pageDt = comfun.GetDataTableBySQL(pageSql);
            this.fpgHistoryList.RecordCount = dt.Rows.Count;
            Rp_hotelwarehousebox.DataSource = pageDt;
            Rp_hotelwarehousebox.DataBind();
            // bdkj(dt);
        }
        //绑定控件
        //protected void bdkj(DataTable dt)
        //{
        //    PagedDataSource pdsList = new PagedDataSource();
        //    pdsList.DataSource = dt.DefaultView;
        //    pdsList.AllowPaging = true;//数据源允许分页
        //    pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
        //    pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
        //    //设置控件
        //    AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
        //    AspNetPager1.PageSize = 10;
        //    Rp_hotelwarehousebox.DataSource = pdsList;
        //    Rp_hotelwarehousebox.DataBind();
        //}
        //shen
        //private void area()
        //{
        //    string sql = "select id,名称 from WP_地区表 where 父级id is null"; //or 名称='全国'";
        //    DataTable dt = comfun.GetDataTableBySQL(sql);
        //    ddl_shen.DataTextField = "名称";
        //    ddl_shen.DataValueField = "id";
        //    ddl_shen.DataSource = dt;
        //    ddl_shen.DataBind();
        //}

        //private void jd()
        //{
        //    string shenid = ddl_shen.SelectedValue;
        //    //绑定酒店下拉框
        //    string jd = "select id,酒店全称 from WP_酒店表  where 区域id=" + shenid + " and IsShow=1";
        //    DataTable dt = comfun.GetDataTableBySQL(jd);
        //    ddl_hotel.DataTextField = "酒店全称";
        //    ddl_hotel.DataValueField = "id";
        //    ddl_hotel.DataSource = dt;
        //    ddl_hotel.DataBind();
        //}

        ////仓库
        //private void warehouse()
        //{
        //    string jdid =ddl_hotel.SelectedItem.Value;
        //    string warehouse = "select id,仓库名 from WP_仓库表 where 酒店id="+jdid+" and IsShow=1";
        //    DataTable dt = comfun.GetDataTableBySQL(warehouse);
        //    ddl_warehouse.DataTextField = "仓库名";
        //    ddl_warehouse.DataValueField = "id";
        //    ddl_warehouse.DataSource = dt;
        //    ddl_warehouse.DataBind();
        //}
        ////库位
        //private void box()
        //{
        //    string warehouseid = ddl_warehouse.SelectedItem.Value;
        //    string box = "select id,库位名 from WP_库位表 where 仓库id="+warehouseid+" and IsShow=1";
        //    DataTable dt = comfun.GetDataTableBySQL(box);
        //    ddl_box.DataTextField = "库位名";
        //    ddl_box.DataValueField = "id";
        //    ddl_box.DataSource = dt;
        //    ddl_box.DataBind();
        //}

        //protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddl_hotel.Items.Clear();
        //    ddl_warehouse.Items.Clear();
        //    ddl_box.Items.Clear();
        //    jd();
        //    ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
        //    ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
        //    ddl_box.Items.Insert(0, new ListItem("--请选择--", "0"));

        //}

        //protected void ddl_hotel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddl_warehouse.Items.Clear();
        //    ddl_box.Items.Clear();
        //    warehouse();
        //    ddl_warehouse.Items.Insert(0,new ListItem("--请选择--","0"));
        //    ddl_box.Items.Insert(0, new ListItem("--请选择--", "0"));


        //}

        //protected void ddl_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    ddl_box.Items.Clear();
        //    box();
        //    ddl_box.Items.Insert(0,new ListItem("--请选择--","0"));


        //}
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Rp_hotelwarehousebox.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_hotelwarehousebox.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_hotelwarehousebox.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //DbHelperSQL.GetSingle(" DELETE FROM [dbo].[WP_库位表] WHERE id='" + id + " '");
                    string up_sql=@"update WP_库位表 set IsShow=0 where id="+id;
                    comfun.UpdateBySQL(up_sql);
                }
            }
            MessageBox.Show(this, "删除成功！");
            //bind("");
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='HotelWarehousekw.aspx'", true);
        }

        //protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        //{
        //    AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        //    sousuo();
        //}

        //控件的显示与隐藏
        public bool getdisplay(string ss)
        {
            if (ss.IndexOf("总台") == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //protected void LBtn_sousuo_Click(object sender, EventArgs e)
        //{
        //    sousuo();
        //}
        //protected void sousuo() {
        //    string where_sql = "";
        //    if (ddl_shen.SelectedValue != "1")
        //    {
        //        where_sql += @" and c.区域id=" + ddl_shen.SelectedValue;
        //    }
        //    if (ddl_hotel.SelectedItem.Value.ToString() != "0")
        //    {
        //        where_sql += @" and c.id=" + ddl_hotel.SelectedValue;
        //    }

        //    if (ddl_warehouse.SelectedValue != "0")
        //    {
        //        where_sql += @" and b.id=" + ddl_warehouse.SelectedValue;
        //    }

        //    if (ddl_box.SelectedValue != "0")
        //    {
        //        where_sql += @" and a.id=" + ddl_box.SelectedValue;
        //    }
        //    bind(where_sql);
        //}
        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PageInit();
        }
        #endregion

        #region 分页事件
        protected void fpgHistoryList_PageIndexChanged(object sender, EventArgs e)
        {
            PageInit();
        }
        #endregion
    }
}