using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.Common_Pay.WeiXinPay;
using System.Data;
namespace Wx_NewWeb.Shop.Distributer
{
    public partial class news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                new_list();
            }
        }
        public string user_id = "";
        protected void new_list()
        {
            string sql_rexiao = "select 商品id,品名 from 视图出库表  group by 商品id,品名 order by count(商品id) desc,max(操作日期) desc ";
            DataTable dt_rexiao = comfun.GetDataTableBySQL(sql_rexiao);
            string rexiao_id = dt_rexiao.Rows[0]["商品id"].ObjToStr();
            string rexiao_name = dt_rexiao.Rows[0]["品名"].ObjToStr();
            //获取用户 所负责的酒店
            // int hotel_id = 15;
            //此时为唯一
            //     Response.Write("<Script Language=JavaScript>alert('"+hotel_id+"！');</Script>"); 
            // string sql = "select 用户权限 from WP_用户权限 where openid=111666 ";
            if (Session["UserId"] != null)
            {

                user_id = Session["UserId"].ToString();
            }
            //openid 已写死
            string sql = "select id,用户id,仓库id from WP_用户权限 where 用户id='" + user_id + "' ";
          //  string sql = "select id,用户id,库位id from WP_用户权限 where 用户id='6' ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
        //    string Jurisdiction = dt.Rows[0]["用户权限"].ObjToStr();
          //  string[] J = Jurisdiction.Split(new Char[] { ',' });
            //int c = p.Rank;
            //查询结果框架
            string search = @"select WP_箱子表.id as 箱子id,库位id,位置,默认商品id,WP_箱子表.status,实际商品id,WP_箱子表.IsShow,WP_商品表.品名,售出时间,库位名  
from WP_箱子表 
left join WP_库位表 on WP_箱子表.库位id=WP_库位表.id 
left join WP_商品表 on WP_箱子表.默认商品id=WP_商品表.id  
where  WP_箱子表.IsShow=1 and WP_箱子表.status=1 and 实际商品id=0";
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            DataTable test = new DataTable();
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            //复制表框架
          //  int new_J = J.GetUpperBound(J.Rank - 1);
            for (int a_i = 0; a_i < dt.Rows.Count; a_i++)
            {
                string sql_hoetl = "select id as 房间id,仓库id,库位名,箱子号,箱子MAC,IsShow   from WP_库位表 where IsShow=1 and 仓库id='" + dt.Rows[a_i]["仓库id"].ObjToInt(0) + "'";
                DataTable dt_hotel = comfun.GetDataTableBySQL(sql_hoetl);
                for (int b_i = 0; b_i < dt_hotel.Rows.Count; b_i++)
                {

                    string sql_kw = @"select WP_箱子表.id as 箱子id,库位id,位置,默认商品id,WP_箱子表.status,实际商品id,WP_箱子表.IsShow,WP_商品表.品名,售出时间,库位名 
from WP_箱子表 
left join WP_库位表 on WP_箱子表.库位id=WP_库位表.id 
left join WP_商品表 on WP_箱子表.默认商品id=WP_商品表.id  
where  WP_箱子表.IsShow=1 and WP_箱子表.status=1 and 实际商品id=0 and 库位id='" + dt_hotel.Rows[b_i]["房间id"].ObjToInt(0) + "'";
                    DataTable dt_box = comfun.GetDataTableBySQL(sql_kw);
                    for (int c_i = 0; c_i < dt_box.Rows.Count; c_i++)
                    {
                        dt_box.Rows[c_i].ItemArray.CopyTo(obj, 0);
                        test.Rows.Add(obj);
                        ViewState["test"] = test;
                    }

                }
            }
            for (int d_i = 0; d_i < test.Rows.Count; d_i++)
            {
                if (test.Rows[d_i]["默认商品id"].ObjToInt(0) == 0)
                {
                    test.Rows[d_i]["默认商品id"] = rexiao_id;
                    test.Rows[d_i]["品名"] = rexiao_name;
                }
            }
                //                for (int i = 0; i < new_J; i++)
                //                {
                //                    int hotel_id = Convert.ToInt32(J[i]);//酒店id
                //                    //查询酒店下所有库位  即房间除总仓外
                //                    string sql_Jurisdiction = "select id as 房间id,仓库id,库位名,箱子号,箱子MAC,IsShow   from WP_库位表 where IsShow=1 and 仓库id='" + hotel_id + "'";
                //                    DataTable dt_J = comfun.GetDataTableBySQL(sql_Jurisdiction);
                //                    for (int r = 0; r < dt_J.Rows.Count; r++)
                //                    {
                //                        string sql_kw = @"select WP_箱子表.id as 箱子id,库位id,位置,默认商品id,WP_箱子表.status,实际商品id,WP_箱子表.IsShow,WP_商品表.品名,售出时间,库位名 
                //from WP_箱子表 
                //left join WP_库位表 on WP_箱子表.库位id=WP_库位表.id 
                //left join WP_商品表 on WP_箱子表.默认商品id=WP_商品表.id  
                //where  WP_箱子表.IsShow=1 and WP_箱子表.status=1 and 实际商品id=0 and 库位id='" + dt_J.Rows[r]["房间id"].ObjToInt(0) + "'";
                //                        DataTable dt_box = comfun.GetDataTableBySQL(sql_kw);
                //                        for (int b = 0; b < dt_box.Rows.Count; b++)
                //                        {
                //                            dt_box.Rows[b].ItemArray.CopyTo(obj, 0);
                //                            test.Rows.Add(obj);
                //                            ViewState["test"] = test;
                //                        }

                //                    }

                //                }

                news_rp.DataSource = (DataTable)ViewState["test"];
            news_rp.DataBind();
            //将查询记录插入到数据库中 进行历史记录查询测试
//            DataTable ls = (DataTable)ViewState["test"];
//            string sql_sq = "select 售出时间 from WP_补货通知 ";
//            DataTable dt_sql_sq = comfun.GetDataTableBySQL(sql_sq);
//            for (int lsi = 0; lsi < ls.Rows.Count; lsi++)
//            {
//                //将记录插入到表里面 
//                if (dt_sql_sq.Rows.Count == 0)
//                {
//                    string ls_sql = @"INSERT INTO WP_补货通知(箱子id, 库位id, 位置, 默认商品id, [status], 实际商品id, IsShow, 品名, 售出时间, 库位名)
//VALUES   ('" + ls.Rows[lsi]["箱子id"].ObjToInt(0) + "','" + ls.Rows[lsi]["库位id"].ObjToInt(0) + "','" + ls.Rows[lsi]["位置"].ObjToInt(0) + "','" + ls.Rows[lsi]["默认商品id"].ObjToInt(0) + "','" + ls.Rows[lsi]["status"].ObjToInt(0) + "','" + ls.Rows[lsi]["实际商品id"].ObjToInt(0) + "','" + ls.Rows[lsi]["IsShow"].ObjToInt(0) + "','" + ls.Rows[lsi]["品名"].ObjToStr() + "','" + ls.Rows[lsi]["售出时间"].ObjToDateTime() + "','" + ls.Rows[lsi]["库位名"].ObjToStr() + "')";
//                    comfun.InsertBySQL(ls_sql);
//                }

//                for (int search_time = 0; search_time < dt_sql_sq.Rows.Count; search_time++)
//                {


////                    else if (dt_sql_sq.Rows[search_time]["售出时间"].ToString() == null || dt_sql_sq.Rows[search_time]["售出时间"].ToString() == string.Empty)
////                    {
////                        string ls_sql = @"INSERT INTO WP_补货通知(箱子id, 库位id, 位置, 默认商品id, [status], 实际商品id, IsShow, 品名, 售出时间, 库位名)
////VALUES   ('" + ls.Rows[lsi]["箱子id"].ObjToInt(0) + "','" + ls.Rows[lsi]["库位id"].ObjToInt(0) + "','" + ls.Rows[lsi]["位置"].ObjToInt(0) + "','" + ls.Rows[lsi]["默认商品id"].ObjToInt(0) + "','" + ls.Rows[lsi]["status"].ObjToInt(0) + "','" + ls.Rows[lsi]["实际商品id"].ObjToInt(0) + "','" + ls.Rows[lsi]["IsShow"].ObjToInt(0) + "','" + ls.Rows[lsi]["品名"].ObjToStr() + "','" + ls.Rows[lsi]["售出时间"].ObjToDateTime() + "','" + ls.Rows[lsi]["库位名"].ObjToStr() + "')";
////                        comfun.InsertBySQL(ls_sql);
////                    }
//                    if (ls.Rows[lsi]["售出时间"].ToString() != dt_sql_sq.Rows[search_time]["售出时间"].ToString())
//                    {
//                        string ls_sql = @"INSERT INTO WP_补货通知(箱子id, 库位id, 位置, 默认商品id, [status], 实际商品id, IsShow, 品名, 售出时间, 库位名)
//VALUES   ('" + ls.Rows[lsi]["箱子id"].ObjToInt(0) + "','" + ls.Rows[lsi]["库位id"].ObjToInt(0) + "','" + ls.Rows[lsi]["位置"].ObjToInt(0) + "','" + ls.Rows[lsi]["默认商品id"].ObjToInt(0) + "','" + ls.Rows[lsi]["status"].ObjToInt(0) + "','" + ls.Rows[lsi]["实际商品id"].ObjToInt(0) + "','" + ls.Rows[lsi]["IsShow"].ObjToInt(0) + "','" + ls.Rows[lsi]["品名"].ObjToStr() + "','" + ls.Rows[lsi]["售出时间"].ObjToDateTime() + "','" + ls.Rows[lsi]["库位名"].ObjToStr() + "')";
//                        comfun.InsertBySQL(ls_sql);
//                    }

//                }

//            }



        }
    }
}