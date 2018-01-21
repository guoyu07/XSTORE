using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class GoodsSalesVolume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                sel_sum("");
            }
        }

        //查询商品总量
        protected DataTable sel_sum(string where_sql) {
            //string sum_goods = @"   select sum(A.数量) as 总量,A.商品id from WP_订单子表 A left join WP_商品表 B on A.商品id=B.id where 1=1 and 库位id!=0 and 库位id is not null " + where_sql + "  group by A.商品id order by sum(A.数量) desc";
            string sum_goods = @"   select sum(A.数量) as 总量,A.商品id from WP_订单子表 A left join WP_商品表 B on A.商品id=B.id where 1=1 and 库位id!=0 and 库位id is not null " + where_sql + "  group by A.商品id order by sum(A.数量) desc";
            DataTable dt=comfun.GetDataTableBySQL(sum_goods);
            dt.Columns.Add("品名",typeof(string));
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ss = @"select 品名 from WP_商品表 where id="+dt.Rows[i]["商品id"].ObjToStr();
                    DataTable dta=comfun.GetDataTableBySQL(ss);
                    if(dta.Rows.Count>0){
                        dt.Rows[i]["品名"]=dta.Rows[0]["品名"];
                    }
                }
            }

            bound(dt);
            return dt;

        }
        //绑定分页控件
        protected void bound(DataTable dt) {
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数

            rp_order.DataSource = pdsList;
            rp_order.DataBind();
        }

        
        public string GetName(string id)
        {
            string goods_name = @" select 品名 from WP_商品表 where id="+id;
            DataTable dt_name = comfun.GetDataTableBySQL(goods_name);
            if (dt_name.Rows.Count > 0)
            {
                return dt_name.Rows[0]["品名"].ObjToStr();
            }
            return "";
        }

        //总额
        public string GetMoney(string id)
        {
            string money_sql = @"select sum(价格) as sum_money from WP_订单子表 where 商品id="+id;
            DataTable dt = comfun.GetDataTableBySQL(money_sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["sum_money"].ObjToStr();
            }
            return "";
        }

        //点击搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();         
        }
        protected string sousuo() {
            string goods_name = txt_goods_name.Text;//品名
            string time_start = txt_start.Value;//开始时间
            string time_end = txt_end.Value;//结束时间
            string where_sql = "";
            if (goods_name != "")
            {

                //time_start = DateTime.ParseExact(time_start, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                where_sql += " and B.品名 like '%" + goods_name + "%'";
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

            sel_sum(where_sql);
            return where_sql;
        }


        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
        /// <summary>
        /// 商品销量汇总信息导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string str_sql = sousuo();
            string sum_goods = @"   select sum(A.数量) as 总量,sum(A.价格) as 总价 from WP_订单子表 A left join WP_商品表 B on A.商品id=B.id where 1=1 and 库位id!=0 and 库位id is not null " + str_sql + "  group by A.商品id order by sum(A.数量) desc";
            DataTable dt = comfun.GetDataTableBySQL(sum_goods);
            dt.Columns.Add("品名", typeof(string));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ss = @"select 品名 from WP_商品表 where id=" + dt.Rows[i]["商品id"].ObjToStr();
                    DataTable dta = comfun.GetDataTableBySQL(ss);
                    if (dta.Rows.Count > 0)
                    {
                        dt.Rows[i]["品名"] = dta.Rows[0]["品名"];
                    }
                }
            }

            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "商品销量汇总" + DateTime.Now.ToString("yyyy-MM-dd"));
        }
    }
}