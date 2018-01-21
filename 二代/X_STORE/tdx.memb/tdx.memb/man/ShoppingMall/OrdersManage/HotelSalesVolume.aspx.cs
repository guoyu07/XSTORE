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
    public partial class HotelSalesVolume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                sel_hotel("");
            }
        }

        //查询酒店的销量汇总
        protected DataTable sel_hotel(string where_sql) {
            //string sum_goods = @" select sum(A.数量) as 总量,A.库位id,sum(A.价格) as 总额 from WP_订单子表 A left join WP_库位表 B on A.库位id=B.id left join WP_仓库表 C on B.仓库id=C.id left join WP_酒店表 D on C.酒店id=D.id where 1=1 and 酒店id!=0 and 库位id is not null "+where_sql+" group by A.库位id order by sum(A.数量)";
            string ckid = @"select  仓库id from 订单列表 group by 仓库id";
            DataTable dt = comfun.GetDataTableBySQL(ckid);
            dt.Columns.Add("总数",typeof(string));
            dt.Columns.Add("总额", typeof(string));
            dt.Columns.Add("酒店名", typeof(string));
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = @" select sum(数量) as 总数,sum(支付金额) as 总额 from 订单列表 where 仓库id='"+dt.Rows[i]["仓库id"].ObjToStr()+" '";
                    DataTable dta = comfun.GetDataTableBySQL(sql);
                    string sel_sql = @"select 仓库名 from WP_仓库表 where id='" + dt.Rows[i]["仓库id"]+" '";
                    DataTable dtb = comfun.GetDataTableBySQL(sel_sql);
                    if(dta.Rows.Count>0){
                        dt.Rows[i]["总数"] = dta.Rows[0]["总数"];
                        dt.Rows[i]["总额"] = dta.Rows[0]["总额"];
                    }
                    if (dtb.Rows.Count > 0)
                    {
                        dt.Rows[i]["酒店名"] = dtb.Rows[0]["仓库名"];
                    }
                }
            }
            bound(dt);
            return dt;
        }
        //绑定分页
        protected void bound( DataTable dt) {
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


        //分页改变
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }

        //点击搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected string sousuo() {
            string hotle_name = txt_goods_name.Text;//酒店名
            string time_start = txt_start.Value;//开始时间
            string time_end = txt_end.Value;//结束时间
            string where_sql = "";
            if (hotle_name != "")
            {
                where_sql += " and D.酒店全称 like '%" + hotle_name + "%'";
            }
            if (time_start != "")
            {
                DateTime start = DateTime.ParseExact(time_start, "yyyy-MM-dd", null);
                
                where_sql += " and 支付时间> '" + start+ "'";
            }
            if (time_end != "")
            {
                DateTime end = DateTime.ParseExact(time_end, "yyyy-MM-dd", null);//转换格式

                where_sql += " and 支付时间< '" + end.AddDays(1) + "'";//加一天以后在比较
            }

            sel_hotel(where_sql);
            return where_sql;
        }

        /// <summary>
        /// 酒店销量汇总信息导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string str_sql = sousuo();
            string ckid = @"select 仓库id from 订单列表 where 1=1 and 仓库id is not null "+str_sql+" group by 仓库id";
            DataTable dt = comfun.GetDataTableBySQL(ckid);
            dt.Columns.Add("总数", typeof(string));
            dt.Columns.Add("总额", typeof(string));
            dt.Columns.Add("酒店名", typeof(string));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = @" select sum(数量) as 总数,sum(支付金额) as 总额 from 订单列表 where 仓库id=" + dt.Rows[i]["仓库id"].ObjToStr();
                    DataTable dta = comfun.GetDataTableBySQL(sql);
                    string sel_sql = @"select 仓库名 from WP_仓库表 where id=" + dt.Rows[i]["仓库id"];
                    DataTable dtb = comfun.GetDataTableBySQL(sel_sql);
                    if (dta.Rows.Count > 0)
                    {
                        dt.Rows[i]["总数"] = dta.Rows[0]["总数"];
                        dt.Rows[i]["总额"] = dta.Rows[0]["总额"];
                    }
                    if(dtb.Rows.Count>0){
                        dt.Rows[i]["酒店名"] = dtb.Rows[0]["仓库名"];
                    }
                }
            }
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "酒店销量汇总" + DateTime.Now.ToString("yyyy-MM-dd"));
        }


    }
}