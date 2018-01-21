using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.Common_Pay.WeiXinPay;
using System.Data;

namespace Wx_NewWeb.Shop.pages
{
    public partial class historyNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                new_list();
            }
        }
        protected void new_list()
        {
            //获取用户 所负责的酒店
            // int hotel_id = 15;
            //此时为唯一
            //     Response.Write("<Script Language=JavaScript>alert('"+hotel_id+"！');</Script>"); 
            // string sql = "select 用户权限 from WP_用户权限 where openid=111666 ";

            //openid 已写死
            string user_id = "";
            if (Session["UserId"] != null)
            {
                user_id = Session["UserId"].ObjToStr();
            }
            string sql = "select 仓库id from WP_用户权限 where 用户id='" + user_id + "' ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
           // string Jurisdiction = dt.Rows[0]["用户权限"].ObjToStr();
           // string[] J = Jurisdiction.Split(new Char[] { ',' });
           // int new_J = J.GetUpperBound(J.Rank - 1);

            string search = @"select 箱子id,库位id,位置,默认商品id,WP_补货通知.status,实际商品id,WP_补货通知.IsShow,WP_商品表.品名,售出时间,WP_补货通知.库位名 
from WP_补货通知 
left join WP_库位表 on WP_补货通知.库位id=WP_库位表.id 
left join WP_商品表 on WP_补货通知.默认商品id=WP_商品表.id  ";
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            DataTable test = new DataTable();
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            //复制表框架
            //读取热销商品
            string rexiao = "select 商品id,品名 from 视图出库表  group by 商品id,品名 order by count(商品id) desc,max(操作日期) desc ";
            DataTable dt_rexiao = comfun.GetDataTableBySQL(rexiao);
            string rexiao_id = dt_rexiao.Rows[0]["商品id"].ObjToStr();
            string rexiao_name = dt_rexiao.Rows[0]["品名"].ObjToStr();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int hotel_id = Convert.ToInt32(dt.Rows[i]["仓库id"]);//酒店id
                //查询酒店下所有库位  即房间除总仓外
                string sql_Jurisdiction = "select id as 房间id,仓库id,库位名,箱子号,箱子MAC,IsShow   from WP_库位表 where IsShow=1 and 库位名 not like '%总台%' and 仓库id='" + hotel_id + "'";
                DataTable dt_J = comfun.GetDataTableBySQL(sql_Jurisdiction);
                for (int r = 0; r < dt_J.Rows.Count; r++)
                {
                    string history_sql = @"select 箱子id,库位id,位置,默认商品id,WP_补货通知.status,实际商品id,WP_补货通知.IsShow,WP_商品表.品名,售出时间,WP_补货通知.库位名 
from WP_补货通知 
left join WP_库位表 on WP_补货通知.库位id=WP_库位表.id 
left join WP_商品表 on WP_补货通知.默认商品id=WP_商品表.id  
where  WP_补货通知.IsShow=1 and WP_补货通知.status=1  and 库位id='" + dt_J.Rows[r]["房间id"].ObjToInt(0) + "'";

                    // AND 售出时间>DATEADD(day, -3, GetDate())
                    DataTable dt_history_sql = comfun.GetDataTableBySQL(history_sql);
                    for (int b = 0; b < dt_history_sql.Rows.Count; b++)
                    {
                        dt_history_sql.Rows[b].ItemArray.CopyTo(obj, 0);
                        test.Rows.Add(obj);
                        ViewState["test"] = test;
                    }
                }
            }

            for (int c = 0; c < test.Rows.Count; c++)
            {
                if (test.Rows[c]["默认商品id"].ObjToInt(0) == 0)
                {
                    test.Rows[c]["默认商品id"] = rexiao_id;
                    test.Rows[c]["品名"] = rexiao_name;
                }
            }
            rp_historynews.DataSource = (DataTable)ViewState["test"];
            rp_historynews.DataBind();
        }
    
    }
}