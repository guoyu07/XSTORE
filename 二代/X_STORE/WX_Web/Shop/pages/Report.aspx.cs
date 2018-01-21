using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Creatrue.kernel;


namespace Wx_NewWeb.Shop.pages
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageA();

             //   pageB();
                pageC();
            }
        }
        #region 商品
        public decimal total_price=0;
        protected void pageA()
        {
            int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            Session["hotelId"] = hotel_id;
            int user_id = Session["UserId"].ObjToInt(0);
            string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where b.仓库id='"+hotel_id+"' group by c.品名,c.本站价 ";
            DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
            if (total_price == 0)
            {
                for (int i = 0; i < dt_goods.Rows.Count; i++)
                {
                    total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
                }
            }
            A_rp.DataSource = dt_goods;
            A_rp.DataBind();
        }
        #endregion
        //#region 销售
        //public decimal total_sale = 0;
        //protected void pageB()
        //{
        //  //  int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
        //    string user_id = "";
        //    if (Session["UserId"] != null)
        //    {
        //        user_id = Session["UserId"].ToString();
        //    }
            
        //    string sql_sale = @"select sum(总价) as 总价,仓库名,真实姓名 from 酒店销售 where 用户id='"+user_id+"' group by 仓库名,真实姓名";
        //    DataTable dt_sale = comfun.GetDataTableBySQL(sql_sale);
        //    B_rp.DataSource = dt_sale;
        //    B_rp.DataBind();
        //}
        //#endregion


        #region 补货
        protected void pageC()
        {
            int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            string sql_psy = @" select 真实姓名,count(是否投放) as 投放 from WP_用户权限 A
 left join WP_用户表 B on B.id=A.用户id
 left join wp_投放任务 c on c.user_id=A.用户id
 where A.仓库id='"+hotel_id+"' and 是否投放=1 group by 真实姓名";
            DataTable dt_psy = comfun.GetDataTableBySQL(sql_psy);
            C_rp.DataSource = dt_psy;
            C_rp.DataBind();
        }
        #endregion



//        protected void search_Click(object sender, EventArgs e)
//        {
//            int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
//            string start_time_str = (start_time.Value).ObjToStr();
//            string end_time_str = (end_time.Value).ObjToStr();
//            if (!string.IsNullOrEmpty(start_time_str))
//            {
//                if (!string.IsNullOrEmpty(end_time_str))
//                {
//                    string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
//left join wp_库位表 b on a.库位id=b.id 
//left join wp_商品表 c on c.id=A.商品id
//where b.仓库id='" + hotel_id + "' and A.操作日期 between '"+start_time_str+"' and'"+end_time_str+"' group by c.品名,c.本站价";
//                    DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
//                    if (total_price == 0)
//                    {
//                        for (int i = 0; i < dt_goods.Rows.Count; i++)
//                        {
//                            total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
//                        }
//                    }
//                    A_rp.DataSource = dt_goods;
//                    A_rp.DataBind();
//                }
//                else
//                {
//                    string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
//left join wp_库位表 b on a.库位id=b.id 
//left join wp_商品表 c on c.id=A.商品id
//where b.仓库id='" + hotel_id + "' and A.操作日期 >'" + start_time_str + "' group by c.品名,c.本站价";
//                    DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
//                    if (total_price == 0)
//                    {
//                        for (int i = 0; i < dt_goods.Rows.Count; i++)
//                        {
//                            total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
//                        }
//                    }
//                    A_rp.DataSource = dt_goods;
//                    A_rp.DataBind();
//                }
//            }
//            else if (!string.IsNullOrEmpty(end_time_str))
//            {
//                if (!string.IsNullOrEmpty(start_time_str))
//                {
//                     string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
//left join wp_库位表 b on a.库位id=b.id 
//left join wp_商品表 c on c.id=A.商品id
//where b.仓库id='" + hotel_id + "' and A.操作日期 between '"+start_time_str+"' and'"+end_time_str+"' group by c.品名,c.本站价";
//                    DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
//                    if (total_price == 0)
//                    {
//                        for (int i = 0; i < dt_goods.Rows.Count; i++)
//                        {
//                            total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
//                        }
//                    }
//                    A_rp.DataSource = dt_goods;
//                    A_rp.DataBind();
//                }
//                else{
//                     string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
//left join wp_库位表 b on a.库位id=b.id 
//left join wp_商品表 c on c.id=A.商品id and A.操作日期 < '" + end_time_str + "' group by c.品名,c.本站价";
//                    DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
//                    if (total_price == 0)
//                    {
//                        for (int i = 0; i < dt_goods.Rows.Count; i++)
//                        {
//                            total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
//                        }
//                    }
//                    A_rp.DataSource = dt_goods;
//                    A_rp.DataBind();
//                }
//            }
//            else
//            {
//                Response.Write("<script>alert('未知错误');</script>");
//            }
//            string x = "";
//        }
    }
}