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
namespace tdx.memb.man.Shop.GrogshopManage
{
    public partial class WP_HotelList : System.Web.UI.Page
    {
        public int totalcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindsql();
                ddl_areachoose();
            }
        }
        private void bindsql()
        {

            DTcms.BLL.WP_酒店表 jd = new DTcms.BLL.WP_酒店表();
            string sql = "select id,酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 where IsShow=1 order by 酒店全称 collate Chinese_PRC_CS_AS_KS_WS";
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





        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindsql();
        }
        //只加载数据库内容
        //public void bind()
        //{
        //    DTcms.BLL.WP_酒店表 jd = new DTcms.BLL.WP_酒店表();
        //    string sql = "select id,酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 where 是否删除='false'";
        //    DataTable dt = comfun.GetDataTableBySQL(sql);
        //    // totalcount = dt.Rows.Count;
        //    this.Rp_hotelInfo.DataSource = dt.DefaultView;
        //    this.Rp_hotelInfo.DataBind();
        //}
        //private void hotels(string where)
        //{
        //    //得出有多少行
        //    string sql = "select COUNT(*) from(select jd.Id,酒店全称,酒店简称,Logo,dq.名称 as 区域id,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 as jd left join WP_地区表 dq on jd.区域id=dq.id where jd.区域id=dq.id and jd.是否删除='false' ) as ss where 1=1 order by jd.Id asc ";
        //    #region 分页2015.6.25
        //    try
        //    {
        //        int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
        //        lb_catelist.Text = ClassList(where, _page);
        //        totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
        //        lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 8, Request.Form, Request.QueryString);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    #endregion
        //}
        //#region 读取分页数据2015.6.25
        //protected string ClassList(string _where, int page)
        //{
        //    //前8行
        //    string sql = " select top 8 *from(select jd.Id,酒店全称,酒店简称,Logo,dq.名称 as 区域id,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 as jd left join WP_地区表 dq on jd.区域id=dq.id where jd.区域id=dq.id and jd.是否删除='false' ) as ss where 1=1 ";
        //    DataTable dt = comfun.GetDataTableBySQL(sql);

        //    totalcount = dt.Rows.Count;
        //    string str = "";
        //    if (dt.Rows.Count > 0)
        //    {
        //        Rp_hotelInfo.DataSource = dt.DefaultView;
        //        Rp_hotelInfo.DataBind();
        //    }
        //    return str;
        //}
        //#endregion
        protected void ddl_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            string asou = ddl_area.SelectedItem.Value;
            string sql = "select jd.Id,酒店全称,酒店简称,Logo,dq.名称 as 区域id,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 as jd left join WP_地区表 dq on jd.区域id=dq.id where jd.IsShow=1 and jd.区域id='" + asou + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            Rp_hotelInfo.DataSource = dt.DefaultView;
            Rp_hotelInfo.DataBind();
        }
        protected void ddl_areachoose()
        {
            string sql = "select id,名称 from WP_地区表 where 父级id is null and 删除时间 is null";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_area.DataTextField = "名称";
            ddl_area.DataValueField = "id";
            this.ddl_area.DataSource = dt;
            ddl_area.DataBind();
        }
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            string jdm = txt_jdm.Text.ToString();
            string sql = "select jd.Id,酒店全称,酒店简称,Logo,dq.名称 as 区域id,地址,电话,总数,总额,区域管理id,酒店管理id from WP_酒店表 as jd left join WP_地区表 dq on jd.区域id=dq.id where jd.IsShow=1 and jd.酒店全称 like '%" + jdm + "%' or  jd.酒店简称 like '%" + jdm + "%' ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            Rp_hotelInfo.DataSource = dt.DefaultView;
            Rp_hotelInfo.DataBind();
        }
    }
}
