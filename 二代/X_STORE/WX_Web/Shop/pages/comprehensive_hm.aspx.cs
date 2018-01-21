using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Jayrock.Json.Conversion;

namespace Wx_NewWeb.Shop.pages
{
    public partial class comprehensive_hm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoom();
                try
                {
                    BindGoods();
                }
                catch (Exception ex)
                {
                    Log.WriteLog("页面：comprehensive", "方法：BindGoods", "异常信息：" + ex.Message);
                }
               
                BindUser();
                //pagesA();
                // pagesB();
                //pagesC();
                //pagesD();
            }


        }
        protected void BindRoom()
        {
            try
            {
                //表框架
                string sql = string.Format(@"select WP_库位表.id,WP_库位表.仓库id,库位名,isnull(离线时长,99) as 离线时长,
(select top 1 时间  from [tshop].[dbo].[视图投放记录] where 投放库位id = WP_库位表.id order by 时间 desc) as 补货时间
from WP_库位表 
where WP_库位表.IsShow=1 and WP_库位表.仓库id={0} and 库位名 not like '%总台库%' and 库位名 not like '%总台%'", HotelInfo["id"].ObjToStr());
                DataTable dt = comfun.GetDataTableBySQL(sql);
                psy_rp.DataSource = dt;
                psy_rp.DataBind();
                room_count.InnerHtml = dt.Rows.Count.ObjToStr();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：comprehensive","方法：BindRoom","异常信息："+ex.Message);
                RedirectError("");
            }
            
        
        }

        protected void BindGoods()
        {
            var all_sql = string.Format(@" 
declare @s int
  set @s = {0}
  select b.本站价,b.编码,b.品名,isnull(c.图片路径,'') as 图片路径,
    (select (sum(isnull(WP_入库表.数量,0))-sum(isnull(WP_出库表.数量,0))) as kucuncount from WP_入库表 left join WP_出库表 on WP_入库表.库位id = WP_出库表.库位id and WP_入库表.商品id =WP_出库表.商品id where WP_入库表.库位id in (SELECT id FROM [tshop].[dbo].[WP_库位表] where 库位名 = '总台' and 仓库id = @s ) and WP_入库表.商品id = b.id group by WP_入库表.商品id,WP_出库表.商品id ) as 前台库存
  ,(select 
  sum(isnull(WP_入库表.数量,0)) as rukucount 
  from WP_入库表 
  left join WP_出库表 
  on WP_入库表.库位id = WP_出库表.库位id 
  and WP_入库表.商品id =WP_出库表.商品id 
  where WP_入库表.库位id in 
  (SELECT id FROM [tshop].[dbo].[WP_库位表] where 库位名 not in('总台','总台库') and 仓库id = @s) 
  and WP_入库表.商品id = b.id) as 房间库存
    ,(select 
  sum(isnull(WP_出库表.数量,0)) as chukucount 
  from WP_入库表 
  left join WP_出库表 
  on WP_入库表.库位id = WP_出库表.库位id 
  and WP_入库表.商品id =WP_出库表.商品id 
  where WP_出库表.库位id in 
  (SELECT id FROM [tshop].[dbo].[WP_库位表] where 库位名 not in('总台','总台库') and 仓库id = @s) 
  and WP_出库表.商品id = b.id) as 销量
  from  WP_商品表 b left join WP_商品图片表 c on b.编号 =c.商品编号
  where b.id in(select 商品id from [dbo].[视图在库表] a where a.库位id in(select id from WP_库位表 where 仓库id = @s))
", HotelInfo["id"].ObjToInt(0));
            Log.WriteLog("类：comprehensive_hm", "方法：BindGoods", "all_sql：" + all_sql);
            var dt = comfun.GetDataTableBySQL(all_sql);

            var room_product_count = 0;

            Log.WriteLog("类：comprehensive_hm", "方法：BindGoods", "dt："+Newtonsoft.Json.JsonConvert.SerializeObject(dt));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                Log.WriteLog("类：comprehensive_hm", "方法：BindGoods", "dr"+i+ "：");
                
                //qiantai_product_count += dr["前台库存"].ObjToInt(0);
                room_product_count += dr["房间库存"].ObjToInt(0);
                //sale_count += dr["销量"].ObjToInt(0);
            }

            goods_rp.DataSource = dt;
            goods_rp.DataBind();
            goods_count.InnerText = (dt.Rows.Count).ObjToStr();
        }

        protected void BindUser()
        {
            try
            {
                var sql = string.Format(@"
SELECT A.用户名,A.手机号,A.真实姓名,B.角色类型 FROM [dbo].[WP_用户表] A LEFT JOIN WP_用户角色 B ON A.角色id = B.id WHERE A.id IN(
SELECT 用户id FROM [dbo].[WP_用户权限] WHERE 仓库id ={0})",HotelId);
                var dt = comfun.GetDataTableBySQL(sql);
                hm_user_item_rp.DataSource = dt;
                hm_user_item_rp.DataBind();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：comprehensive","方法：BindUser","异常信息："+ex.Message);
                RedirectError(ex.Message);
            }
        }
        #region -----废弃-----
        protected void pagesA()
        {

            DataTable dt_kw = new DataTable();
            #region 房间
            //表框架
            string search = string.Format(@"select WP_库位表.id,WP_库位表.仓库id,库位名,用户名,cast(0 as int) 数量 
from WP_库位表 
left join WP_用户权限 on WP_用户权限.仓库id=WP_库位表.仓库id
left join WP_用户表 on WP_用户表.id=WP_用户权限.用户id
where WP_库位表.IsShow=1 and WP_库位表.仓库id={0} and WP_用户表.id={1} and 库位名 not like '%总台库%' and 库位名 not like '%总台%'",HotelInfo["id"].ObjToStr(),UserId);
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            DataTable test = new DataTable();
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            //表框架结束
            #region 插入配送员姓名

            string sql_psymx = @"select 用户名,WP_用户表.id  as 用户id from WP_用户表 
left join WP_用户权限 on WP_用户表.id=Wp_用户权限.用户id
where   WP_用户权限.仓库id='" + HotelInfo["id"] + "' and WP_用户表.角色id=3";//查询对应酒店下的配送员
            DataTable psymx = comfun.GetDataTableBySQL(sql_psymx);
            string psy_name = "";
            if (psymx.Rows.Count > 0)
            {
                for (int b_i = 0; b_i < psymx.Rows.Count; b_i++)
                {
                    if (b_i == 0)
                    {
                        psy_name += psymx.Rows[b_i]["用户名"];
                    }
                    else
                    {
                        psy_name += "、" + psymx.Rows[b_i]["用户名"];
                    }
                }
                string sql_kw = @"select WP_库位表.id,WP_库位表.仓库id,库位名,用户名,cast(0 as int) 数量  from WP_库位表 
left join WP_用户权限 on WP_用户权限.仓库id=WP_库位表.仓库id
left join WP_用户表 on WP_用户表.id=WP_用户权限.用户id
where (库位名 like '%[0-9][0-9][0-9][0-9]' or 库位名 like '%[0-9][0-9][0-9]' or 库位名 like '%[0-9][0-9][0-9][0-9][0-9]' ) and WP_库位表.IsShow=1 and 库位名 not like '%总台库%' and 库位名 not like '%总台%' and WP_用户权限.仓库id='" + HotelInfo["id"] + "' and WP_用户表.id='" + psymx.Rows[0]["用户id"].ObjToStr() + "'";
                dt_kw = comfun.GetDataTableBySQL(sql_kw);
                for (int c_i = 0; c_i < dt_kw.Rows.Count; c_i++)
                {
                    dt_kw.Rows[c_i]["用户名"] = psy_name;
                    dt_kw.Rows[c_i].ItemArray.CopyTo(obj, 0);
                    test.Rows.Add(obj);//循环插入test 将结果
                }
            }
            #endregion
            #region 插入每个房间的数量
            //第一步 查询所有库位id
            string sql_rooms = @"select WP_库位表.id,WP_库位表.仓库id,库位名,用户名,cast(0 as int) 数量 from WP_库位表 
left join WP_用户权限 on WP_用户权限.仓库id=WP_库位表.仓库id
left join WP_用户表 on WP_用户表.id=WP_用户权限.用户id
where (库位名 like '%[0-9][0-9][0-9][0-9]' or 库位名 like '%[0-9][0-9][0-9]' or 库位名 like '%[0-9][0-9][0-9][0-9][0-9]' ) and 库位名 not like '%总台库%' and 库位名 not like '%总台%' and WP_库位表.IsShow=1 and WP_库位表.仓库id='" + HotelInfo["id"] + "' and WP_用户表.id='" + UserId + "'";
            DataTable dt_rooms = comfun.GetDataTableBySQL(sql_rooms);
            for (int c_i = 0; c_i < dt_rooms.Rows.Count; c_i++)
            {
                //第二步把查询结果插入test
                string kw_id = dt_rooms.Rows[c_i]["id"].ObjToStr();
                string sql_nums = @"select sum(数量) as 数量 from wp_箱子表
left join wp_库位表 on wp_库位表.id=WP_箱子表.库位id
where 实际商品id=0 and 库位id='" + kw_id + "' and 位置 between 1 and 12 ";
                DataTable dt_nums = comfun.GetDataTableBySQL(sql_nums);
                if (dt_nums.Rows.Count > 0)
                {
                    test.Rows[c_i]["数量"] = dt_nums.Rows[0]["数量"].ObjToInt(0);
                }
            }
            #endregion
            psy_rp.DataSource = test;
            psy_rp.DataBind();
            #endregion
        }
        //        protected void pagesB()
        //        {
        //            string user_id = "";
        //            if (Session["UserId"] != null)
        //            {
        //                user_id = Session["UserId"].ToString();
        //            }
        //            string sql = "select 仓库id from WP_用户权限 where 用户id='" + user_id + "'";
        //            DataTable dt = comfun.GetDataTableBySQL(sql);
        //            #region 配送员
        //            //表框架
        //            string search2 = @"select count(库位名) as 总数,仓库名,WP_仓库表.id,cast(0 as int) 数量 from WP_库位表
        //left join WP_箱子表 on WP_箱子表.库位id=WP_库位表.id
        //left join WP_仓库表 on WP_库位表.仓库id=WP_仓库表.id
        //where 实际商品id=0 and 库位名 not like '%总台%' and 仓库id=79
        //group by 仓库名,WP_仓库表.id";
        //            DataTable search2_dt = comfun.GetDataTableBySQL(search2);
        //            DataTable test2 = new DataTable();
        //            test2 = search2_dt.Clone();
        //            object[] obj2 = new object[test2.Columns.Count];
        //            //表框架结束
        //            for (int d_i = 0; d_i < dt.Rows.Count; d_i++)
        //            {
        //                string sql_ps = @"select 库位名,仓库名,WP_仓库表.id from WP_库位表
        //left join WP_箱子表 on WP_箱子表.库位id=WP_库位表.id
        //left join WP_仓库表 on WP_库位表.仓库id=WP_仓库表.id
        //where 实际商品id=0 and 库位名 not like '%总台%' and 仓库id='" + dt.Rows[d_i]["仓库id"].ObjToStr() + "' group by 库位名,仓库名,WP_仓库表.id";
        //                DataTable dt_ps = comfun.GetDataTableBySQL(sql_ps);

        //                string sql_nums = @"select sum(数量) as 数量 from wp_箱子表
        //left join wp_库位表 on wp_库位表.id=WP_箱子表.库位id
        //where 实际商品id=0 and 库位名 not like '%总台%' and 仓库id='" + dt.Rows[d_i]["仓库id"].ObjToStr() + "' and 位置 between 1 and 12";
        //                DataTable dt_nums = comfun.GetDataTableBySQL(sql_nums);

        //                //     dt_ps.Rows[c_i]["用户名"] = psy_name;
        //                if (dt_ps.Rows.Count > 0) {
        //                    dt_ps.Rows[0].ItemArray.CopyTo(obj2, 0);
        //                    test2.Rows.Add(obj2);//循环插入test 将结果
        //                    test2.Rows[d_i]["总数"] = dt_ps.Rows.Count;
        //                }
        //                if (dt_nums.Rows.Count > 0)
        //                {
        //                    test2.Rows[d_i]["数量"] = dt_nums.Rows[0]["数量"].ObjToInt(0);
        //                }
        //            }
        //            qhjd_rp.DataSource = test2;
        //            qhjd_rp.DataBind();
        //            #endregion
        //        }
        protected void pagesC()
        {
            string sql = @"select WP_用户权限.仓库id as 子酒店id,wp_库位表.id as 总台库id  from WP_用户权限 
left join wp_库位表 on WP_库位表.仓库id=WP_用户权限.仓库id
where 用户id='" + UserId + "' and wp_库位表.库位名 like '%总台%'";
            DataTable dt_ztk = comfun.GetDataTableBySQL(sql);
            //框架表
            //  string search3 = @"select a.本站价,a.品名,a.本站价,b.图片路径,c.库存数,d.总数 as 出库数 from WP_商品表 a
            //left join wp_商品图片表 b on a.编号=b.商品编号
            //left join 视图在库表 c on c.商品id=a.id
            //left join 视图出库列表 d on d.商品id=a.id
            //where 库位id=75";
            string search3 = @"
select a.id as 商品id,a.本站价,a.品名,a.本站价,b.图片路径,c.库存数,cast(0 as int) 出库数 from WP_商品表 a
left join wp_商品图片表 b on a.编号=b.商品编号
left join 视图在库表 c on c.商品id=a.id
where 库位id=75";
            DataTable search3_dt = comfun.GetDataTableBySQL(search3);
            DataTable test3 = new DataTable();
            test3 = search3_dt.Clone();
            object[] obj3 = new object[test3.Columns.Count];
            //
            for (int i = 0; i < dt_ztk.Rows.Count; i++)
            {
                string sql_xiangqing = @"
select a.id as 商品id,a.本站价,a.品名,a.本站价,b.图片路径,c.库存数,cast(0 as int) 出库数 from WP_商品表 a
left join wp_商品图片表 b on a.编号=b.商品编号
left join 视图在库表 c on c.商品id=a.id
where 库位id='" + dt_ztk.Rows[i]["总台库id"].ObjToStr() + "'";
                DataTable dt_xiangqing = comfun.GetDataTableBySQL(sql_xiangqing);
                for (int b = 0; b < dt_xiangqing.Rows.Count; b++)
                {
                    dt_xiangqing.Rows[b].ItemArray.CopyTo(obj3, 0);
                    test3.Rows.Add(obj3);//循环插入test 将结果
                }
                string sql_outstock = @"select 总数,商品id,库位id,仓库id from 视图出库列表
where 库位id='" + dt_ztk.Rows[i]["总台库id"].ObjToStr() + "'";
                DataTable dt_outstock = comfun.GetDataTableBySQL(sql_outstock);
                if (dt_outstock.Rows.Count > 0)
                {
                    for (int c = 0; c < test3.Rows.Count; c++)
                    {
                        for (int d = 0; dt_outstock.Rows.Count > d; d++)
                        {
                            if (dt_outstock.Rows[d]["商品id"].ObjToInt(0) == test3.Rows[c]["商品id"].ObjToInt(0))
                            {
                                test3.Rows[c]["出库数"] = dt_outstock.Rows[d]["总数"].ObjToInt(0);
                            }
                        }
                    }
                }
            }
            //goods_rp.DataSource = test3;
            //goods_rp.DataBind();
        }



        protected void pagesD()
        {
            string user_id = "";
            if (Session["UserId"] != null)
            {
                user_id = Session["UserId"].ToString();
            }
            string sql_hotels = @"select 仓库id from wp_用户权限 where 用户id ='" + user_id + "'";
            DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);

            string sql_users = @"select 真实姓名,仓库id,角色类型 from wp_用户表 a
left join wp_用户权限 b on b.用户id=a.id
left join wp_仓库表 c on b.仓库id=c.id
left join WP_用户角色 d on d.id=a.角色id
where (角色id=1 or 角色id=3 or 角色id=2) and a.IsShow=1 and c.IsShow=1 and c.id='" + dt_hotels.Rows[0]["仓库id"].ObjToStr() + "' order by d.id";
            DataTable dt_users = comfun.GetDataTableBySQL(sql_users);
            //hm_user_item_rp.DataSource = dt_users;
            //hm_user_item_rp.DataBind();

        }
//        protected void search_rooms_TextChanged(object sender, EventArgs e)
//        {
//            string user_id = "";
//            if (Session["UserId"] != null)
//            {
//                user_id = Session["UserId"].ToString();
//            }
//            string sql = "select 仓库id from WP_用户权限 where 用户id='" + user_id + "'";
//            DataTable dt = comfun.GetDataTableBySQL(sql);
//            DataTable dt_kw = new DataTable();
//            #region 房间
//            //表框架
//            string search = @"select WP_库位表.id,WP_库位表.仓库id,库位名,用户名,cast(0 as int) 数量 from WP_库位表 
//left join WP_用户权限 on WP_用户权限.仓库id=WP_库位表.仓库id
//left join WP_用户表 on WP_用户表.id=WP_用户权限.用户id
//where (库位名 like '%[0-9][0-9][0-9][0-9]' or 库位名 like '%[0-9][0-9][0-9]' or 库位名 like '%[0-9][0-9][0-9][0-9][0-9]' ) and WP_库位表.IsShow=1 and WP_库位表.仓库id=79 and WP_用户表.id=17";
//            DataTable search_dt = comfun.GetDataTableBySQL(search);
//            DataTable test = new DataTable();
//            test = search_dt.Clone();
//            object[] obj = new object[test.Columns.Count];
//            //表框架结束
//            for (int a_i = 0; a_i < dt.Rows.Count; a_i++)
//            {
//                #region 插入配送员姓名
//                string ck_id = dt.Rows[a_i]["仓库id"].ObjToStr();
//                string sql_psymx = @"select 用户名,WP_用户表.id  as 用户id from WP_用户表 
//left join WP_用户权限 on WP_用户表.id=Wp_用户权限.用户id
//where   WP_用户权限.仓库id='" + ck_id + "' and WP_用户表.角色id=3";//查询对应酒店下的配送员
//                DataTable psymx = comfun.GetDataTableBySQL(sql_psymx);
//                string psy_name = "";
//                if (psymx.Rows.Count > 0)
//                {
//                    for (int b_i = 0; b_i < psymx.Rows.Count; b_i++)
//                    {
//                        if (b_i == 0)
//                        {
//                            psy_name += psymx.Rows[b_i]["用户名"];
//                        }
//                        else
//                        {
//                            psy_name += "、" + psymx.Rows[b_i]["用户名"];
//                        }
//                    }
//                    string sql_kw = @"select WP_库位表.id,WP_库位表.仓库id,库位名,用户名,cast(0 as int) 数量  from WP_库位表 
//left join WP_用户权限 on WP_用户权限.仓库id=WP_库位表.仓库id
//left join WP_用户表 on WP_用户表.id=WP_用户权限.用户id
//where (库位名 like '%" + (search_rooms.Text).ObjToStr() + "%' ) and WP_库位表.IsShow=1 and WP_用户权限.仓库id='" + ck_id + "' and WP_用户表.id='" + psymx.Rows[0]["用户id"].ObjToStr() + "'";
//                    dt_kw = comfun.GetDataTableBySQL(sql_kw);
//                    for (int c_i = 0; c_i < dt_kw.Rows.Count; c_i++)
//                    {
//                        dt_kw.Rows[c_i]["用户名"] = psy_name;
//                        dt_kw.Rows[c_i].ItemArray.CopyTo(obj, 0);
//                        test.Rows.Add(obj);//循环插入test 将结果
//                    }
//                }
//                #endregion
//                #region 插入每个房间的数量
//                //第一步 查询所有库位id
//                string sql_rooms = @"select WP_库位表.id,WP_库位表.仓库id,库位名,用户名,cast(0 as int) 数量 from WP_库位表 
//left join WP_用户权限 on WP_用户权限.仓库id=WP_库位表.仓库id
//left join WP_用户表 on WP_用户表.id=WP_用户权限.用户id
//where (库位名 like '%" + (search_rooms.Text).ObjToStr() + "%'  ) and WP_库位表.IsShow=1 and WP_库位表.仓库id='" + ck_id + "' and WP_用户表.id='" + user_id + "'";
//                DataTable dt_rooms = comfun.GetDataTableBySQL(sql_rooms);
//                for (int c_i = 0; c_i < dt_rooms.Rows.Count; c_i++)
//                {
//                    //第二步把查询结果插入test
//                    string kw_id = dt_rooms.Rows[c_i]["id"].ObjToStr();
//                    string sql_nums = @"select sum(数量) as 数量 from wp_箱子表
//left join wp_库位表 on wp_库位表.id=WP_箱子表.库位id
//where 实际商品id=0 and 库位id='" + kw_id + "' and 位置 between 1 and 12 ";
//                    DataTable dt_nums = comfun.GetDataTableBySQL(sql_nums);
//                    if (dt_nums.Rows.Count > 0)
//                    {
//                        test.Rows[c_i]["数量"] = dt_nums.Rows[0]["数量"].ObjToInt(0);
//                    }

//                }

//                #endregion
//            }
            //psy_rp.DataSource = test;
            //psy_rp.DataBind();

            //#endregion

        //}
        #endregion

        #region 判断在线还是离线
        public string GetOnline(int kuweiid) {
            var sql = string.Format("SELECT 状态 FROM WP_库位表 WHERE id = {0}",kuweiid);
            var dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ObjToInt(0) == 1)
                {
                    return " <span class=\"online\">在线</span>";
                }
                else
                {
                    return "<span class=\"offline\">离线</span>";
                }
            }
            else
            {
                return "<span class=\"offline\">离线</span>";
                
            }
        }
        #endregion
    }
}