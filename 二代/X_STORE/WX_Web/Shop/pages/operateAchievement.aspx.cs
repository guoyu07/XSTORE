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
    public partial class operateAchievement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pagesA();
                pagesB();
                pagesC();
                pagesD();
                pagesE();
            }

        }
        public decimal Atoatal = 0;
        public decimal Btoatal = 0;
        public decimal Ctoatal = 0;
        public decimal Dtoatal = 0;
        public decimal Etoatal = 0;
        public int user_id = 0;
        DataTable search = comfun.GetDataTableBySQL("select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A left join wp_库位表 b on a.库位id=b.id  left join wp_商品表 c on c.id=A.商品id where DateDiff(hh,操作日期,getDate())<=24 and b.仓库id='79' group by c.品名,c.本站价,c.id");
        DataTable testA = new DataTable();
        DataTable testB = new DataTable();
        DataTable testC = new DataTable();
        DataTable testD = new DataTable();
        DataTable testE = new DataTable();
        protected void pagesA()
        {
            testA = search.Clone();
            object[] objA = new object[testA.Columns.Count];
            user_id = Session["UserId"].ObjToInt(0);
            //int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
            int first_times = 0;
            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_goods = @"select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where DateDiff(hh,操作日期,getDate())<=24 and b.仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToInt(0) + "' group by c.品名,c.本站价,c.id";
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
                                //for (int d = 0; d < testA.Rows.Count; d++)
                                //{
                                //    if (dt_goods.Rows[b]["goodsId"].ObjToInt(0) == testA.Rows[d]["goodsId"].ObjToInt(0))
                                //    {
                                //        break;
                                //    }
                                //    else
                                //    {

                                //    }
                                //}
                            }
                        }
                    }

                }

            }

            if (Atoatal == 0)
            {
                for (int i = 0; i < testA.Rows.Count; i++)
                {
                    Atoatal = Atoatal + testA.Rows[i]["总价"].ObjToDecimal(0);
                }
            }
            //if (Atoatal == 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        Atoatal = Atoatal + dt.Rows[i]["总价"].ObjToDecimal(0);
            //    }
            //}
            Today.DataSource = testA;
            Today.DataBind();

        }
        //aweek
        protected void pagesB()
        {
            testB = search.Clone();
            object[] objB = new object[testB.Columns.Count];
            user_id = Session["UserId"].ObjToInt(0);
            //int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
            int first_times = 0;
            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_goods = @"select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where  DateDiff(dd,操作日期,getDate())<=7  and b.仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToInt(0) + "' group by c.品名,c.本站价,c.id";
                DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                if (first_times == 0)//第一次进入 直接插入数据到testB
                {
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        dt_goods.Rows[b].ItemArray.CopyTo(objB, 0);
                        testB.Rows.Add(objB);
                    }
                }
                else
                {//不是第一次进入 进行比较
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        for (int c = 0; c < testB.Rows.Count; c++)
                        {
                            //判断是否有这个商品有就累加 
                            if (dt_goods.Rows[b]["goodsId"].ObjToInt(0) == testB.Rows[c]["goodsId"].ObjToInt(0))
                            {
                                testB.Rows[c]["总数"] = testB.Rows[c]["总数"].ObjToInt(0) + dt_goods.Rows[b]["总数"].ObjToInt(0);
                            }
                            else
                            {
                                //此时这个商品不存在或者不相等
                                DataView dv = new DataView(testB);
                                dv.RowFilter = "goodsId = '%" + dt_goods.Rows[b]["goodsId"].ObjToInt(0) + "%'";
                                if (dv.Table.Rows.Count > 0)
                                {//不相等
                                    break;
                                }
                                else
                                {//不存在
                                    dt_goods.Rows[b].ItemArray.CopyTo(objB, 0);
                                    testB.Rows.Add(objB);
                                }
                            }
                        }
                    }

                }

            }
            if (Btoatal == 0)
            {
                for (int i = 0; i < testB.Rows.Count; i++)
                {
                    Btoatal = Btoatal + testB.Rows[i]["总价"].ObjToDecimal(0);
                }
            }
            AWeek.DataSource = testB;
            AWeek.DataBind();
        }
        //amounth
        protected void pagesC()
        {
            testC = search.Clone();
            object[] objC = new object[testC.Columns.Count];
            user_id = Session["UserId"].ObjToInt(0);
            //int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
            int first_times = 0;
            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_goods = @"select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where DateDiff(mm,操作日期,getDate())<=0  and b.仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToInt(0) + "' group by c.品名,c.本站价,c.id";
                DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                if (first_times == 0)//第一次进入 直接插入数据到testC
                {
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        dt_goods.Rows[b].ItemArray.CopyTo(objC, 0);
                        testC.Rows.Add(objC);
                    }
                }
                else
                {//不是第一次进入 进行比较
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        for (int c = 0; c < testC.Rows.Count; c++)
                        {
                            //判断是否有这个商品有就累加 
                            if (dt_goods.Rows[b]["goodsId"].ObjToInt(0) == testC.Rows[c]["goodsId"].ObjToInt(0))
                            {
                                testC.Rows[c]["总数"] = testC.Rows[c]["总数"].ObjToInt(0) + dt_goods.Rows[b]["总数"].ObjToInt(0);
                            }
                            else
                            {
                                //此时这个商品不存在或者不相等
                                DataView dv = new DataView(testC);
                                dv.RowFilter = "goodsId = '%" + dt_goods.Rows[b]["goodsId"].ObjToInt(0) + "%'";
                                if (dv.Table.Rows.Count > 0)
                                {//不相等
                                    break;
                                }
                                else
                                {//不存在
                                    dt_goods.Rows[b].ItemArray.CopyTo(objC, 0);
                                    testC.Rows.Add(objC);
                                }
                            }
                        }
                    }

                }

            }
            if (Ctoatal == 0)
            {
                for (int i = 0; i < testC.Rows.Count; i++)
                {
                    Ctoatal = Ctoatal + testC.Rows[i]["总价"].ObjToDecimal(0);
                }
            }
            Amounth.DataSource = testC;
            Amounth.DataBind();
        }
        //ayear
        protected void pagesD()
        {
            testD = search.Clone();
            object[] objD = new object[testD.Columns.Count];
            user_id = Session["UserId"].ObjToInt(0);
            //int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
            int first_times = 0;
            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_goods = @"select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where DateDiff(yy,操作日期,getDate())<=0  and b.仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToInt(0) + "' group by c.品名,c.本站价,c.id";
                DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                if (first_times == 0)//第一次进入 直接插入数据到testD
                {
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        dt_goods.Rows[b].ItemArray.CopyTo(objD, 0);
                        testD.Rows.Add(objD);
                    }
                }
                else
                {//不是第一次进入 进行比较
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        for (int c = 0; c < testD.Rows.Count; c++)
                        {
                            //判断是否有这个商品有就累加 
                            if (dt_goods.Rows[b]["goodsId"].ObjToInt(0) == testD.Rows[c]["goodsId"].ObjToInt(0))
                            {
                                testD.Rows[c]["总数"] = testD.Rows[c]["总数"].ObjToInt(0) + dt_goods.Rows[b]["总数"].ObjToInt(0);
                            }
                            else
                            {
                                //此时这个商品不存在或者不相等
                                DataView dv = new DataView(testD);
                                dv.RowFilter = "goodsId = '%" + dt_goods.Rows[b]["goodsId"].ObjToInt(0) + "%'";
                                if (dv.Table.Rows.Count > 0)
                                {//不相等
                                    break;
                                }
                                else
                                {//不存在
                                    dt_goods.Rows[b].ItemArray.CopyTo(objD, 0);
                                    testD.Rows.Add(objD);
                                }
                            }
                        }
                    }

                }

            }
            if (Dtoatal == 0)
            {
                for (int i = 0; i < testD.Rows.Count; i++)
                {
                    Dtoatal = Dtoatal + testD.Rows[i]["总价"].ObjToDecimal(0);
                }
            }
            Ayear.DataSource = testD;
            Ayear.DataBind();
        }
        //all
        protected void pagesE()
        {
            testE = search.Clone();
            object[] objE = new object[testE.Columns.Count];
            user_id = Session["UserId"].ObjToInt(0);
            //int hotel_id = Request["hotelid"] != null ? Convert.ToInt32(Request["hotelid"]) : 0;
            string sql_hotels = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' ";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
            int first_times = 0;
            for (int i = 0; i < dt_hotels.Rows.Count; i++)
            {
                string sql_goods = @"select c.品名,c.id as goodsId,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where  b.仓库id='" + dt_hotels.Rows[i]["仓库id"].ObjToInt(0) + "' group by c.品名,c.本站价,c.id";
                DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                if (first_times == 0)//第一次进入 直接插入数据到testE
                {
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        dt_goods.Rows[b].ItemArray.CopyTo(objE, 0);
                        testE.Rows.Add(objE);
                    }
                }
                else
                {//不是第一次进入 进行比较
                    for (int b = 0; b < dt_goods.Rows.Count; b++)
                    {
                        for (int c = 0; c < testE.Rows.Count; c++)
                        {
                            //判断是否有这个商品有就累加 
                            if (dt_goods.Rows[b]["goodsId"].ObjToInt(0) == testE.Rows[c]["goodsId"].ObjToInt(0))
                            {
                                testE.Rows[c]["总数"] = testE.Rows[c]["总数"].ObjToInt(0) + dt_goods.Rows[b]["总数"].ObjToInt(0);
                            }
                            else
                            {
                                //此时这个商品不存在或者不相等
                                DataView dv = new DataView(testE);
                                dv.RowFilter = "goodsId = '%" + dt_goods.Rows[b]["goodsId"].ObjToInt(0) + "%'";
                                if (dv.Table.Rows.Count > 0)
                                {//不相等
                                    break;
                                }
                                else
                                {//不存在
                                    dt_goods.Rows[b].ItemArray.CopyTo(objE, 0);
                                    testE.Rows.Add(objE);
                                }
                            }
                        }
                    }

                }

            }
            if (Etoatal == 0)
            {
                for (int i = 0; i < testE.Rows.Count; i++)
                {
                    Etoatal = Etoatal + testE.Rows[i]["总价"].ObjToDecimal(0);
                }
            }
            AllGoods.DataSource = testE;
            AllGoods.DataBind();
        }

    }
}