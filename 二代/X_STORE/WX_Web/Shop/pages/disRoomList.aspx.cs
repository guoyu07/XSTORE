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
    public partial class disRoomList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pages();
        }
        public static string jd_name = "";
        public static string jd_rooms = "";
        protected void pages()
        {
            int ck_id = Request["ckid"] != null ? Convert.ToInt32(Request["ckid"]) : 0;
            string sql_ps = @"select 库位名,仓库名,WP_仓库表.id from WP_库位表
left join WP_箱子表 on WP_箱子表.库位id=WP_库位表.id
left join WP_仓库表 on WP_库位表.仓库id=WP_仓库表.id
where 实际商品id=0 and 库位名 not like '%总台%' and 仓库id='" + ck_id + "'group by 库位名,仓库名,WP_仓库表.id";
            DataTable dt_ps = comfun.GetDataTableBySQL(sql_ps);
            jd_name = dt_ps.Rows[0]["仓库名"].ObjToStr();
            jd_rooms = (dt_ps.Rows.Count).ObjToStr();
            string sql=@"select 库位名,仓库名,WP_仓库表.id,count(WP_箱子表.id)as 总数 from WP_库位表
left join WP_箱子表 on WP_箱子表.库位id=WP_库位表.id
left join WP_仓库表 on WP_库位表.仓库id=WP_仓库表.id
where 实际商品id=0 and 库位名 not like '%总台%' and 仓库id='"+ck_id+"' group by 库位名,仓库名,WP_仓库表.id";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            rooms_rp.DataSource = dt;
            rooms_rp.DataBind();
            
        }
    }
}