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
    public partial class goodsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pagesA();
            pagesB();
        }
        public static decimal total = 0;
        protected void pagesA()
        {
            string user_id = "";
            if (Session["UserId"] != null)
            {
                user_id = Session["UserId"].ToString();
            }
            string sql = "select 库位id from WP_用户权限 where 用户id='" + user_id + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            //表框架
            string search = @"
select min(convert(varchar(10),WP_出库表.操作日期,120)) as sj,商品id,品名, sum(数量) as 数量,cast(AVG (出价) as numeric(18, 2)) as 出价,sum(总出价额) as 总出价额 from WP_出库表
left join WP_库位表  on WP_出库表.库位id=WP_库位表.id
left join WP_商品表 on WP_出库表.商品id=WP_商品表.id
where 仓库id=79
group by 商品id,品名";
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            DataTable test = new DataTable();
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            for (int a_i = 0; a_i < dt.Rows.Count; a_i++)
            {
                string sql_sp = @"select min(convert(varchar(10),WP_出库表.操作日期,120)) as sj,商品id,品名, sum(数量) as 数量,cast(AVG (出价) as numeric(18, 2)) as 出价,sum(总出价额) as 总出价额 from WP_出库表
left join WP_库位表  on WP_出库表.库位id=WP_库位表.id
left join WP_商品表 on WP_出库表.商品id=WP_商品表.id
where 仓库id='" + dt.Rows[a_i]["库位id"].ObjToStr() + "'group by 商品id,品名";
                DataTable dt_sp = comfun.GetDataTableBySQL(sql_sp);
                if (dt_sp.Rows.Count > 0)
                {
                    for (int b_i = 0; b_i < dt_sp.Rows.Count; b_i++)
                    {
                        dt_sp.Rows[b_i].ItemArray.CopyTo(obj, 0);
                        test.Rows.Add(obj);//循环插入test 将结果
                    }
                }
            }
            total = 0;
            if (test.Rows.Count > 0)
            {
                    for (int c_i = 0; c_i < test.Rows.Count; c_i++)
                    {
                        total = total + test.Rows[c_i]["总出价额"].ObjToDecimal(0);
                    }
            }
            goods_rp.DataSource = test;
            goods_rp.DataBind();
        }
        protected void pagesB()
        {
            string user_id = "";
            if (Session["UserId"] != null)
            {
                user_id = Session["UserId"].ToString();
            }
            string sql = "select 库位id from WP_用户权限 where 用户id='" + user_id + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string search = @"
select 用户名,count(Wp_投放任务.id) as 次数 from WP_用户表
left join wp_投放任务 on Wp_投放任务.user_id=WP_用户表.id
where WP_用户表.id=6
group by 用户名";
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            DataTable test = new DataTable();
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            //表框架结束
            for (int a_i = 0; a_i < dt.Rows.Count; a_i++)
            {
                string ck_id = dt.Rows[a_i]["库位id"].ObjToStr();
                string sql_psymx = @"select 用户名,WP_用户表.id  as 用户id from WP_用户表 
left join WP_用户权限 on WP_用户表.id=Wp_用户权限.用户id
where   WP_用户权限.库位id='" + ck_id + "' and WP_用户表.角色id=3";//查询对应酒店下的配送员
                DataTable psymx = comfun.GetDataTableBySQL(sql_psymx);
                for (int b_i = 0; b_i < psymx.Rows.Count; b_i++)
                {
                    string sql_toufang = @"
select 用户名,count(Wp_投放任务.id) as 次数 from WP_用户表
left join wp_投放任务 on Wp_投放任务.user_id=WP_用户表.id
where WP_用户表.id='" + psymx.Rows[b_i]["用户id"].ObjToStr() + "' group by 用户名";
                    DataTable dt_toufang = comfun.GetDataTableBySQL(sql_toufang);
                    dt_toufang.Rows[0].ItemArray.CopyTo(obj, 0);
                    test.Rows.Add(obj);//循环插入test 将结果
                }
            }
            td_rp.DataSource = test;
            td_rp.DataBind();
        }
    }
}