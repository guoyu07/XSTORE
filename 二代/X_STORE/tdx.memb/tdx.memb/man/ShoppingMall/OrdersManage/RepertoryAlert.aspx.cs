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
    public partial class RepertoryAlert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind("");
            }
        }
        protected void bind(string where_sql) {
//            string sql = @"select sum(数量) as 销量,仓库id,商品id 
//                        from WP_订单子表 a left join WP_订单支付表 b on a.订单编号=b.订单编号 left join WP_订单表 c on b.订单编号=c.订单编号 
//                        where state=3 group by 仓库id,商品id ";
            string sql = @"select sum(数量) as 销量,仓库id,商品id 
      from 订单列表 a left join WP_仓库表 b on a.仓库id =b.id left join WP_酒店表 c on b.酒店id=c.id 
                        where 支付状态=3 "+where_sql+" group by 仓库id,商品id ";
            DataTable dt = new comfun().GetDataTable(sql);
            dt.Columns.Add("酒店名",typeof(string));
            dt.Columns.Add("库存数",typeof(string));
            int number = 0;
            if(dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sel_sql = @"select 库存数,仓库名 from 视图在库表 a left join WP_库位表 b on a.库位id=b.id left join WP_仓库表 c on b.仓库id=c.id where 商品id="+dt.Rows[i]["商品id"]+" and c.id="+dt.Rows[i]["仓库id"];
                    DataTable dta = new comfun().GetDataTable(sel_sql);
                    if(dta.Rows.Count>0){
                        if(dta.Rows[0]["库存数"].ObjToInt(0)<dt.Rows[i]["销量"].ObjToInt(0))
                        {//警报
                            dt.Rows[number]["酒店名"]=dta.Rows[0]["仓库名"];
                            dt.Rows[number]["库存数"] = dta.Rows[0]["库存数"];
                            number += number;
                        }
                   }
                }            
            }
            rp_order.DataSource = dt;
            rp_order.DataBind();

        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }

        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo() {
            string hotel_name = txt_hotel_name.Text.ObjToStr();
            string goods_name = txt_goods_name.Text.ObjToStr();
            string where_sql = "";
            if(hotel_name!=""){
                where_sql += " and (酒店全称 like '%"+hotel_name+"%' or 仓库名 like '%"+hotel_name+"%')";
            }
            if(goods_name!=""){
                where_sql += " and 品名 like '%"+goods_name+"%'";
            }
            bind(where_sql);
        }

    }
}