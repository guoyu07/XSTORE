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
    public partial class saleReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            salereports();
        }
        public static string manger = "";
        protected void salereports()
        {
            //通过用户openid 读取相应数据
            //酒店负责人，目前不知从何处查暂定为 openid的用户名
            string user_id = "";
            if (Session["UserId"] != null)
            {

                user_id = Session["UserId"].ToString();
            }
            string name_sql = "select 用户名 from WP_用户表 where id='"+user_id+"'";
            DataTable dt_name = comfun.GetDataTableBySQL(name_sql);
            manger = dt_name.Rows[0]["用户名"].ObjToStr();
            //管辖范围
            string qy_sql = "select 库位id from WP_用户权限 where 用户id='" + user_id + "'";
            DataTable dt_qylist = comfun.GetDataTableBySQL(qy_sql);
           // string[] qy = dt_qylist.Rows[0]["用户权限"].ToString().Split(new Char[] { ',' });
           // int new_qy = qy.GetUpperBound(qy.Rank - 1);
            #region  //表结构框架赋值
            string search = @"select sum(数量) as 总数,avg(出价) as 平均价,SUM(总出价额) as 出价总额,酒店全称
from WP_出库表 
left join WP_商品表 on WP_商品表.id=WP_出库表.商品id
left join WP_库位表 on WP_库位表.id=WP_出库表.库位id
left join WP_仓库表 on WP_仓库表.id=WP_出库表.库位id
left join WP_酒店表 on WP_酒店表.Id=WP_仓库表.酒店id
group by 酒店全称";
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            DataTable test = new DataTable();
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            #endregion
            for (int a = 0; a < dt_qylist.Rows.Count; a++)//通过权限查酒店
            {
                string sql_a = @"select  仓库名,库位名,WP_库位表.id as 库位id
from WP_仓库表
left join WP_库位表 on WP_库位表.仓库id=WP_仓库表.id
where WP_仓库表.id ='" + dt_qylist.Rows[a]["库位id"] + "'  and WP_仓库表.IsShow=1 and (库位名  like '%总台%')";
                DataTable dt_a = comfun.GetDataTableBySQL(sql_a);
                for (int b=0;b< dt_a.Rows.Count; b++)
                {
                    string total_sql = @"select sum(数量) as 总数,avg(出价) as 平均价,SUM(总出价额) as 出价总额,酒店全称
from WP_出库表 
left join WP_商品表 on WP_商品表.id=WP_出库表.商品id
left join WP_库位表 on WP_库位表.id=WP_出库表.库位id
left join WP_仓库表 on WP_仓库表.id=WP_出库表.库位id
left join WP_酒店表 on WP_酒店表.Id=WP_仓库表.酒店id
where 库位id='" +dt_a.Rows[b]["库位id"]+"' group by 酒店全称";
                    DataTable dt_total_sql = comfun.GetDataTableBySQL(total_sql);
                    for (int c = 0; c < dt_total_sql.Rows.Count; c++)
                    {
                        dt_total_sql.Rows[a].ItemArray.CopyTo(obj, 0);
                        test.Rows.Add(obj);
                    }                 
                }
            }
            sale_rp.DataSource = test;
            sale_rp.DataBind();
        }
    }
}