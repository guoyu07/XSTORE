using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.HotelWarehouse
{
    public partial class HotelGoodsInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind();
            }
        }

        protected void bind() {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);//仓库id
            string sql = @" select 库位id,商品id 
   from 视图在库表 a left join WP_库位表 b on a.库位id=b.id left join WP_仓库表 c on b.仓库id=c.id  
   where c.id="+id+" group by 库位id,商品id";
            DataTable dt=new comfun().GetDataTable(sql);
            dt.Columns.Add("库存数",typeof(string));
            dt.Columns.Add("品名", typeof(string));
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sel_sql = @"select sum(库存数) as 库存数 from 视图在库表 where 库位id="+dt.Rows[i]["库位id"]+" and 商品id="+dt.Rows[i]["商品id"];
                    DataTable dta = new comfun().GetDataTable(sel_sql);
                    if(dta.Rows.Count>0){
                        dt.Rows[i]["库存数"] = dta.Rows[0]["库存数"];
                    }
                    string sql2 = @"select 品名 from 视图在库表 where 库位id=" + dt.Rows[i]["库位id"] + " and 商品id=" + dt.Rows[i]["商品id"];
                    DataTable dtb = new comfun().GetDataTable(sql2);
                    if (dta.Rows.Count > 0)
                    {
                        dt.Rows[i]["品名"] = dtb.Rows[0]["品名"];
                    }

                }
            }
            Rp_hotelGoodsInventory.DataSource = dt;
            Rp_hotelGoodsInventory.DataBind();
        }



    }
}