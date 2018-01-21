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
using tdx.database.Common_Pay.WeiXinPay;
namespace tdx.memb
{
    public partial class OutStockList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind("");
                //area();
                //ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
                //ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
                //ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
                //ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
                //ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));

            }
        }
        #region 加载数据
        protected DataTable bind(string where_sql)
        {
            DataTable dt = comfun.GetDataTableBySQL(@"SELECT 单据编号 
FROM [tshop].[dbo].[视图出库表] where 出库IsShow=1  "+where_sql+" group by 单据编号 ");
            dt.Columns.Add("仓库", typeof(string));
            dt.Columns.Add("操作日期", typeof(string));
            dt.Columns.Add("出库人", typeof(string));
            dt.Columns.Add("酒店全称", typeof(string));
            dt.Columns.Add("库位名", typeof(string));
            dt.Columns.Add("出库类型", typeof(string));
            dt.Columns.Add("总数", typeof(string));
            dt.Columns.Add("总额", typeof(string));
            dt.Columns.Add("位置", typeof(string));
            DataTable dt_sql_Ostock = new DataTable();
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql_Ostock = @"select 位置,仓库,操作日期,id,单据编号,出库人,酒店全称,库位名,出库类型  
                    from 视图出库表 where 单据编号='" + dt.Rows[i]["单据编号"].ObjToStr() + "' " + where_sql;
                    dt_sql_Ostock = new comfun().GetDataTable(sql_Ostock);
                    if (dt_sql_Ostock.Rows.Count>0)
                    {
                        dt.Rows[i]["仓库"] = dt_sql_Ostock.Rows[0]["仓库"];
                        dt.Rows[i]["操作日期"] = dt_sql_Ostock.Rows[0]["操作日期"];
                        dt.Rows[i]["出库人"] = dt_sql_Ostock.Rows[0]["出库人"];
                        dt.Rows[i]["酒店全称"]=dt_sql_Ostock.Rows[0]["酒店全称"];
                        dt.Rows[i]["库位名"] = dt_sql_Ostock.Rows[0]["库位名"];
                        dt.Rows[i]["出库类型"] = dt_sql_Ostock.Rows[0]["出库类型"];
                        dt.Rows[i]["位置"] = dt_sql_Ostock.Rows[0]["位置"];
                    }
                    string sql = "select sum(数量) as 总数,sum(总出价额) as 总额 from WP_出库表 where IsShow=1 and 单据编号='" + dt.Rows[i]["单据编号"].ObjToStr()+ "'";
                    DataTable dtc = new comfun().GetDataTable(sql);
                    if(dtc.Rows.Count>0){
                        dt.Rows[i]["总数"] = dtc.Rows[0]["总数"];
                        dt.Rows[i]["总额"] = dtc.Rows[0]["总额"];
                    }
                }
            }
            DataTable dtd = comfun.GetDataTableBySQL(@" SELECT sum(数量) as 总数,sum(总额) as 总额 FROM 视图出库表 where 出库IsShow=1 and 库位IsShow=1 and 仓库IsShow=1 and 酒店IsShow=1and 商品IsShow=1" + where_sql);
            lb_sum.Text = "总数:" + dtd.Rows[0]["总数"].ObjToStr() + "   总额:" + dtd.Rows[0]["总额"].ObjToStr();
            lb_sum.Style["color"] = "blue";
            bound(dt);
            return dt;

        }
        //分页值改变
        protected void AspNetPagerIn_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPagerIn.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
        #endregion
        //绑定分页控件
        protected void bound(DataTable dt)
        {
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPagerIn.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPagerIn.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPagerIn.RecordCount = dt.Rows.Count;//记录总数
            this.AspNetPagerIn.PageSize = 10;
            this.Rp_Instocklist.DataSource = pdsList;
            this.Rp_Instocklist.DataBind();
        }
        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Rp_Instocklist.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_Instocklist.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_Instocklist.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DbHelperSQL.GetSingle("delete WP_出库表 where id='" + id + "'");
                    MessageBox.Show(this, "删除成功！");
                }
            }
            bind("");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='OutStockList.aspx'", true);
        }
        //导出
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string where_sql= sousuo();
            DataTable dt = new comfun().GetDataTable(@"select 位置,仓库,操作日期,id,单据编号,出库人,酒店全称,库位名,出库类型 from 视图出库表 where 出库IsShow=1 "+where_sql);
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "出库信息" + DateTime.Now.ToString("yyyy-MM-dd"));
        }

        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected string sousuo()
        {
            string where_sql = "";
            //string where_sql2="";
            //string goods_name = txt_pinming.Text.ObjToStr();//品名
            string number = ck_number.Text.Trim().ObjToStr();//入库号
            string hotelname = txt_hotel.Text.Trim().ObjToStr();
            string start_time = Jxl.Value.ObjToStr();//开始时间
            string end_time = Jx2.Value.ObjToStr();//结束时间
            string cklx = ck_lx.SelectedValue;
            //if (goods_name != "")
            //{
            //    where_sql += " and 品名 like '%" + goods_name + "%'";
            //}
            if (number != "")
            {
                where_sql += " and 单据编号 like'%" + number + "%'";
            }
            if (hotelname!="")
            {
                where_sql += " and (酒店全称 like '%" + hotelname + "%' or 仓库名 like '%"+hotelname+"%')";
            }
            if (start_time!="")
            {
                where_sql += string.Format(" and 操作日期>convert(varchar(19),'{0}',120)", start_time);
            }
            if(end_time!=""){
                where_sql += string.Format(" and 操作日期<convert(varchar(19),'{0}',120)", end_time);
            }
            if(cklx!="0"){
                where_sql += " and 出库类型='"+cklx+"'";
            }
            DataTable dt=bind(where_sql);
            return where_sql;
        }

        protected string getlx(string ss) {
            string re_str = "";
            switch (ss)
            {
                case "1":
                    re_str = "正常出库";
                    break;
                case "2":
                    re_str = "其他出库";
                    break;
                default:
                    re_str = "转出库";
                    break;
            }
            return re_str;
        }

    }
}