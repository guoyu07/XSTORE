using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class kwSalesVolume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                sel_kw("");
            }
        }


        protected DataTable sel_kw(string where_sql)
        {
            string kw_sql = @"select sum(A.数量) as 总量,A.库位id,sum(价格) as 总额 from WP_订单子表 A left join WP_库位表 B on A.库位id=B.id where 1=1 and  库位id!=0 and 库位id is not null " + where_sql + " group by A.库位id";
            DataTable dt = comfun.GetDataTableBySQL(kw_sql);
            dt.Columns.Add("库位名",typeof(string));
            dt.Columns.Add("酒店名", typeof(string));
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ss = @"select 库位名,酒店全称 from 视图酒店仓库库位表 where 库位id=" + dt.Rows[i]["库位id"];
                    DataTable dta = comfun.GetDataTableBySQL(ss);
                    if(dta.Rows.Count>0){
                        dt.Rows[i]["库位名"]=dta.Rows[0]["库位名"];
                        dt.Rows[i]["酒店名"] = dta.Rows[0]["酒店全称"];
                    }
                }
            }
            bound(dt);
            return dt;

        }
        //绑定分页
        protected void bound(DataTable dt)
        {
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数

            rp_order.DataSource = pdsList;//绑定数据
            rp_order.DataBind();
        }

        //点击搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected string sousuo() {
            string kw_name = txt_kw_name.Text;//品名
            string time_start = txt_start.Value;//开始时间
            string time_end = txt_end.Value;//结束时间
            string where_sql = "";
            if (kw_name != "")
            {

                //time_start = DateTime.ParseExact(time_start, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                where_sql += " and B.库位名 like '%" + kw_name + "%'";
            }
            if (time_start != "")
            {
                DateTime start = DateTime.ParseExact(time_start, "yyyy-MM-dd", null);
                where_sql += " and A.下单时间> '" + start + "'";
            }
            if (time_end != "")
            {
                DateTime end = DateTime.ParseExact(time_end, "yyyy-MM-dd", null);//转换格式

                where_sql += " and A.下单时间< '" + end.AddDays(1) + "'";//加一天以后在比较
            }

            sel_kw(where_sql);
            return where_sql;
        }

        //分页值改变
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }

        public string GetName(string id)
        {
            string goods_name = @" select 库位名 from WP_库位表 where id=" + id;
            DataTable dt_name = comfun.GetDataTableBySQL(goods_name);
            if (dt_name.Rows.Count > 0)
            {
                return dt_name.Rows[0]["库位名"].ObjToStr();
            }
            return "";
        }

        public string GetMoney(string id)
        {
            string money_sql = @"select sum(价格) as sum_money from WP_订单子表 where 库位id=" + id;
            DataTable dt = comfun.GetDataTableBySQL(money_sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["sum_money"].ObjToStr();
            }
            return "";
        }

        /// <summary>
        /// 库位销量汇总信息导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string str_sql = sousuo();
            string kw_sql = @"select sum(A.数量) as 总量,sum(价格) as 总额 from WP_订单子表 A left join WP_库位表 B on A.库位id=B.id where 1=1 and  库位id!=0 and 库位id is not null " + str_sql + " group by A.库位id";
            DataTable dt = comfun.GetDataTableBySQL(kw_sql);
            dt.Columns.Add("库位名", typeof(string));
            dt.Columns.Add("酒店名", typeof(string));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ss = @"select 库位名,酒店全称 from 视图酒店仓库库位表 where 库位id=" + dt.Rows[i]["库位id"];
                    DataTable dta = comfun.GetDataTableBySQL(ss);
                    if (dta.Rows.Count > 0)
                    {
                        dt.Rows[i]["库位名"] = dta.Rows[0]["库位名"];
                        dt.Rows[i]["酒店名"] = dta.Rows[0]["酒店全称"];
                    }
                }
            }
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "库位销量汇总" + DateTime.Now.ToString("yyyy-MM-dd"));
        }

    }
}