using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class operateReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageA();

                pageB();
                pageC();
            }

        }
        #region 商品
        public decimal total_price = 0;
        protected void pageA()
        {
            int user_id = Session["UserId"].ObjToInt(0);
            string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
            //表框架
            DataTable search = comfun.GetDataTableBySQL("select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A left join wp_库位表 b on a.库位id=b.id  left join wp_商品表 c on c.id=A.商品id where b.仓库id='79' and b.IsShow=1 and c.IsShow=1 and a.IsShow=1  group by c.品名,c.本站价,c.id");
            DataTable testA = new DataTable();
            testA = search.Clone();
            object[] objA = new object[testA.Columns.Count];
            //框架结束
            int first_times = 0;
            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_goods = @"select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where b.仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToInt(0) + "' and b.IsShow=1 and c.IsShow=1 and a.IsShow=1  group by c.品名,c.本站价,c.id";
                DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                if (first_times == 0)//第一次进入 直接插入数据到testA
                {
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        dt_goods.Rows[b].ItemArray.CopyTo(objA, 0);
                        testA.Rows.Add(objA);
                    }
                }
                else
                {//不是第一次进入 进行比较
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        for (int c = 0; c < testA.Rows.Count; c++)
                        {
                            //判断是否有这个商品有就累加 
                            if (dt_goods.Rows[b]["goodsId"].ObjToInt(0) == testA.Rows[c]["goodsId"].ObjToInt(0))
                            {
                                testA.Rows[c]["总数"] = testA.Rows[c]["总数"].ObjToInt(0) + dt_goods.Rows[b]["总数"].ObjToInt(0);
                                testA.Rows[c]["总价"] = testA.Rows[c]["总价"].ObjToInt(0) + dt_goods.Rows[b]["总价"].ObjToInt(0);
                            }
                            else
                            {
                                //此时这个商品不存在或者不相等
                                DataView dv = new DataView(testA);
                                dv.RowFilter = "goodsId = '%" + dt_goods.Rows[b]["goodsId"].ObjToInt(0) + "%'";
                                if (dv.Table.Rows.Count > 0)
                                {//不相等
                                    break;
                                }
                                else
                                {//不存在
                                    dt_goods.Rows[b].ItemArray.CopyTo(objA, 0);
                                    testA.Rows.Add(objA);
                                }
                            }
                        }
                    }


                }
            }



            //DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
            //if (total_price == 0)
            //{
            //    for (int i = 0; i < dt_goods.Rows.Count; i++)
            //    {
            //        total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
            //    }
            //}
            if (total_price == 0)
            {
                for (int i = 0; i < testA.Rows.Count; i++)
                {
                    total_price = total_price + testA.Rows[i]["总价"].ObjToDecimal(0);
                }
            }
            A_rp.DataSource = testA;
            A_rp.DataBind();
        }
        #endregion
        


        #region 销售
        public decimal total_sale = 0;
        protected void pageB()
        {
            //  int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            int user_id = Session["UserId"].ObjToInt(0);
           //string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限 left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
           // DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
            string sql_hotels = @"select 仓库id from wp_用户权限 where 用户id='" + user_id + "'";
         DataTable dt_hotels=comfun.GetDataTableBySQL(sql_hotels);
            //表框架
            DataTable search = comfun.GetDataTableBySQL("select sum(总价) as 总价 ,仓库名,真实姓名 from 实际销售 where 仓库id=79 and 角色id=1  group by 仓库名,真实姓名");
            DataTable testB = new DataTable();
            testB = search.Clone();
            object[] objB = new object[testB.Columns.Count];
            //框架结束

            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_list = @"select sum(总价) as 总价,仓库名,真实姓名 from 实际销售 where 仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToStr() + "' and 角色id=1 group by 仓库名,真实姓名";
                DataTable dt_list = comfun.GetDataTableBySQL(sql_list);
                for (int b = 0; b < dt_list.Rows.Count; b++)
                {
                    dt_list.Rows[b].ItemArray.CopyTo(objB, 0);
                    testB.Rows.Add(objB);
                }
            }
          //  string sql_sale = @"select sum(总价) as 总价,仓库名,真实姓名 from 酒店销售 where 用户id='"+user_id+"' group by 仓库名,真实姓名";
         //   DataTable dt_sale = comfun.GetDataTableBySQL(sql_sale);








            B_rp.DataSource = testB;
            B_rp.DataBind();
        }
        #endregion


        #region 补货
        protected void pageC()
        {
            int user_id = Session["UserId"].ObjToInt(0);
            string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);

            DataTable search = comfun.GetDataTableBySQL("select b.id as psy_id,真实姓名,count(是否投放) as 投放 from WP_用户权限 A left join WP_用户表 B on B.id=A.用户id left join wp_投放任务 c on c.user_id=A.用户id where A.仓库id='79' and 是否投放=1 group by 真实姓名,b.id ");
            DataTable testA = new DataTable();
            testA = search.Clone();
            object[] objA = new object[testA.Columns.Count];
            //框架结束
            int first_times = 0;
            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_goods = @"select b.id as psy_id,真实姓名,count(是否投放) as 投放 from WP_用户权限 A left join WP_用户表 B on B.id=A.用户id left join wp_投放任务 c on c.user_id=A.用户id where A.仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToInt(0) + "' and 是否投放=1 group by 真实姓名,b.id ";
                DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                if (first_times == 0)//第一次进入 直接插入数据到testA
                {
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        dt_goods.Rows[b].ItemArray.CopyTo(objA, 0);
                        testA.Rows.Add(objA);
                    }
                }
                else
                {//不是第一次进入 进行比较
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        for (int c = 0; c < testA.Rows.Count; c++)
                        {
                            //判断是否有这个商品有就累加 
                            if (dt_goods.Rows[b]["psy_id"].ObjToInt(0) == testA.Rows[c]["psy_id"].ObjToInt(0))
                            {
                                testA.Rows[c]["投放"] = testA.Rows[c]["投放"].ObjToInt(0) + dt_goods.Rows[b]["投放"].ObjToInt(0); ;
                            }
                            else
                            {
                                //此时这个商品不存在或者不相等
                                DataView dv = new DataView(testA);
                                dv.RowFilter = "psy_id = '%" + dt_goods.Rows[b]["psy_id"].ObjToInt(0) + "%'";
                                if (dv.Table.Rows.Count > 0)
                                {//不相等
                                    break;
                                }
                                else
                                {//不存在
                                    dt_goods.Rows[b].ItemArray.CopyTo(objA, 0);
                                    testA.Rows.Add(objA);
                                }
                            }
                        }
                    }


                }
            }

//            string sql_psy = @" select 真实姓名,count(是否投放) as 投放 from WP_用户权限 A
// left join WP_用户表 B on B.id=A.用户id
// left join wp_投放任务 c on c.user_id=A.用户id
// where A.仓库id='79' and 是否投放=1 group by 真实姓名";
//            DataTable dt_psy = comfun.GetDataTableBySQL(sql_psy);

            C_rp.DataSource = testA;
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
//where b.仓库id='" + hotel_id + "' and A.操作日期 between '" + start_time_str + "' and'" + end_time_str + "' group by c.品名,c.本站价";
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
//                    string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
//left join wp_库位表 b on a.库位id=b.id 
//left join wp_商品表 c on c.id=A.商品id
//where b.仓库id='" + hotel_id + "' and A.操作日期 between '" + start_time_str + "' and'" + end_time_str + "' group by c.品名,c.本站价";
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
//           // string x = "";
//        }
    }
}