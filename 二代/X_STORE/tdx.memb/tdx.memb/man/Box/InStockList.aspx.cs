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
using System.Globalization;
namespace tdx.memb.box
{
    public partial class InStockList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
                area();
                
            }
        }
        #region 加载数据
        protected void bind()
        {

            DataTable dt = sql_string("");
            bound(dt);
            
        }


        protected DataTable sql_string(string where_sql) {
            string instock = "";
            DataTable dt = comfun.GetDataTableBySQL("select 单据编号 from InsList where 1=1 " + where_sql + " group by 单据编号");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("公司名称", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("供应商id", typeof(string));
            dt.Columns.Add("操作日期", typeof(string));
            dt.Columns.Add("操作id", typeof(string));
            dt.Columns.Add("入库类型", typeof(string));
            dt.Columns.Add("用户名", typeof(string));
            dt.Columns.Add("酒店全称", typeof(string));
            dt.Columns.Add("仓库", typeof(string));
            dt.Columns.Add("库位", typeof(string));
            dt.Columns.Add("总数", typeof(string));
            dt.Columns.Add("总额", typeof(string));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    instock = "SELECT top 1 id,单据编号,公司名称 ,品名,供应商id, 操作日期, 操作id, 入库类型, 用户名,总数,总额, 酒店全称, 仓库, 库位 from InsList where 单据编号='" + dt.Rows[i]["单据编号"].ObjToStr() + "' ";
                    DataTable dt_sql = comfun.GetDataTableBySQL(instock);
                    if (dt_sql.Rows.Count > 0)
                    {
                        dt.Rows[i]["id"] = dt_sql.Rows[0]["id"];
                        dt.Rows[i]["公司名称"] = dt_sql.Rows[0]["公司名称"];
                        dt.Rows[i]["品名"] = dt_sql.Rows[0]["品名"];
                        dt.Rows[i]["供应商id"] = dt_sql.Rows[0]["供应商id"];
                        dt.Rows[i]["操作日期"] = dt_sql.Rows[0]["操作日期"];
                        dt.Rows[i]["操作id"] = dt_sql.Rows[0]["操作id"];
                        dt.Rows[i]["入库类型"] = dt_sql.Rows[0]["入库类型"];
                        dt.Rows[i]["用户名"] = dt_sql.Rows[0]["用户名"];
                        dt.Rows[i]["酒店全称"] = dt_sql.Rows[0]["酒店全称"];
                        dt.Rows[i]["仓库"] = dt_sql.Rows[0]["仓库"];
                        dt.Rows[i]["库位"] = dt_sql.Rows[0]["库位"];
                    }
                    string sql = "  select sum(总数) as 总数量,sum(总额) as 总金额 from InsList where 单据编号='" + dt.Rows[i]["单据编号"].ObjToStr() + "'";
                    DataTable dtb=comfun.GetDataTableBySQL(sql);
                    if(dtb.Rows.Count>0){
                        dt.Rows[i]["总数"]=dtb.Rows[0]["总数量"];
                        dt.Rows[i]["总额"] = dtb.Rows[0]["总金额"];
                    }
                }
            }
            DataTable dtc = comfun.GetDataTableBySQL("select sum(总数) as 总数,sum(总额) as 总额 from InsList where 1=1 " + where_sql);
            if(dtc.Rows.Count>0){
                lb_sum.Text = "总数:" + dtc.Rows[0]["总数"].ObjToStr() + "   总额:" + dtc.Rows[0]["总额"].ObjToStr();
                lb_sum.Style["color"] = "blue";
            }
            
            return dt;
        }
        protected void bound(DataTable dt) {

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


        //分页
        protected void AspNetPagerIn_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPagerIn.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
        #endregion

        #region 下拉数据绑定
        //shen
        private void area()
        {
            string gys_sql = "select 编号,公司名称 from WP_客户资料 where 是否供应商=1 and IsShow=1";
            DataTable dta=comfun.GetDataTableBySQL (gys_sql);
            gys.DataTextField = "公司名称";
            gys.DataValueField = "编号";
            gys.DataSource=dta;
            gys.DataBind();
          //  ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
            gys.Items.Insert(0, new ListItem("--请选择--","0"));

        }
        protected string sql(string where_sql){
            string instock = "SELECT   id,单据编号,公司名称 ,品名,供应商id, 操作日期, 操作id, 入库类型, 用户名,总数,总额, 酒店全称, 仓库, 库位 from InsList where 1=1 " + where_sql + " order by 操作日期 desc ";
            return instock;
        }
        #endregion


        protected void btnDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Rp_Instocklist.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_Instocklist.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_Instocklist.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DbHelperSQL.GetSingle("delete WP_入库表 where id='" + id + "'");
                    MessageBox.Show(this, "删除成功！");

                }
            }
            bind();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='InStockList.aspx'", true);

        }
        //导出
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string str= sousuo();

            DataTable dt = new comfun().GetDataTable(@"select 单据编号,公司名称 ,品名, 操作日期,( case 入库类型 when 0 then '正常入库' when 1 then '其他入库' when 2 then '转入库' end) as 入库类型, 用户名,总数,总额, 酒店全称, 仓库, 库位 from InsList");
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "入库信息" + DateTime.Now.ToString("yyyy-MM-dd"));
         
        }
        //点击搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected string sousuo() {
            string where_sql = "";

           // string goods_name = txt_pinming.Text.ObjToStr();//品名
            string number = rk_number.Text.Trim().ObjToStr();//入库号
            string hotelname = txt_hotel.Text.Trim().ObjToStr();
            string gysid = gys.SelectedValue;//供应商
            string start_time = Jxl.Value.ObjToStr();//开始时间
            string end_time = Jx2.Value.ObjToStr();//结束时间
            string rklx = rk_lx.SelectedValue;//入库类型
            //if(goods_name!=""){
            //    where_sql += " and 品名 like '%"+goods_name+"%'";
            //}
            if (number!="")
            {
                where_sql += " and 单据编号 like '%"+number+"%'";            
            }
            if(hotelname!=""){
                where_sql += " and (酒店全称 like '"+hotelname+"%' or 仓库 like '%"+hotelname+"%')";
            }
            if(gysid!="0"){
                where_sql += " and 供应商id="+gysid;
            }
            if(start_time!=""){
                where_sql += string.Format(" and 操作日期>convert(varchar(19),'{0}',120)", start_time);
            }
            if(end_time!=""){
                //DateTime det = DateTime.Parse(end_time);
                where_sql += string.Format(" and 操作日期<convert(varchar(19),'{0}',120)", end_time);
            }
            if (rklx!="0")
            {
                where_sql += " and 入库类型='" + rklx + "'";
            }
          DataTable dt= sql_string(where_sql);
            bound(dt);
            return where_sql;
        }
        public string getlx(string ss) {
            string re_str = "";
            switch(ss){
                case "1":
                    re_str= "正常入库";
                    break;
                case "2":
                    re_str= "其他入库";
                    break;
                default :
                    re_str= "转入库";
                    break;
            }
            return re_str;
        }

        protected DataTable dc(string where_sql) {
            string instock = "";
            DataTable dt = comfun.GetDataTableBySQL("select 单据编号 from InsList where 1=1 " + where_sql + " group by 单据编号");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("公司名称", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("操作日期", typeof(string));
            dt.Columns.Add("操作id", typeof(string));
            dt.Columns.Add("入库类型", typeof(string));
            dt.Columns.Add("用户名", typeof(string));
            dt.Columns.Add("酒店全称", typeof(string));
            dt.Columns.Add("仓库", typeof(string));
            dt.Columns.Add("库位", typeof(string));
            dt.Columns.Add("总数", typeof(string));
            dt.Columns.Add("总额", typeof(string));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    instock = "SELECT top 1 单据编号,公司名称 ,品名, 操作日期, 操作id,( case 入库类型 when 0 then '正常入库' when 1 then '其他入库' when 2 then '转入库' end) as 入库类型, 用户名,总数,总额, 酒店全称, 仓库, 库位 from InsList  where 单据编号='" + dt.Rows[i]["单据编号"].ObjToStr() + "' ";
                    DataTable dt_sql = comfun.GetDataTableBySQL(instock);
                    if (dt_sql.Rows.Count > 0)
                    {
                        dt.Rows[i]["公司名称"] = dt_sql.Rows[0]["公司名称"];
                        dt.Rows[i]["品名"] = dt_sql.Rows[0]["品名"];
                        dt.Rows[i]["操作日期"] = dt_sql.Rows[0]["操作日期"];
                        dt.Rows[i]["操作id"] = dt_sql.Rows[0]["操作id"];
                        dt.Rows[i]["入库类型"] = dt_sql.Rows[0]["入库类型"];
                        dt.Rows[i]["用户名"] = dt_sql.Rows[0]["用户名"];
                        dt.Rows[i]["酒店全称"] = dt_sql.Rows[0]["酒店全称"];
                        dt.Rows[i]["仓库"] = dt_sql.Rows[0]["仓库"];
                        dt.Rows[i]["库位"] = dt_sql.Rows[0]["库位"];
                    }
                    string sql = "  select sum(总数) as 总数量,sum(总额) as 总金额 from InsList where 单据编号='" + dt.Rows[i]["单据编号"].ObjToStr() + "'";
                    DataTable dtb = comfun.GetDataTableBySQL(sql);
                    if (dtb.Rows.Count > 0)
                    {
                        dt.Rows[i]["总数"] = dtb.Rows[0]["总数量"];
                        dt.Rows[i]["总额"] = dtb.Rows[0]["总金额"];
                    }
                }
            }
            return dt;
        }


    }
}