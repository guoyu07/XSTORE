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
    public partial class operation : System.Web.UI.Page
    {
        public string wz = "";
        public string goods_name = "";
        public string box_id = "";
        public string goods_img = "";
        public int room_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int room_id = Request["room_id"] != null ? Convert.ToInt32(Request["room_id"]) : 0;
            int boxid = Request["boxid"] != null ? Convert.ToInt32(Request["boxid"]) : 0;
           // int kw_id = Request["kwid"] != null ? Convert.ToInt32(Request["kwid"]) : 0;
            box_id = boxid.ObjToStr();
          //  kw = kw_id.ObjToStr();
            string sql = @"select 品名,位置,箱子MAC,图片路径 from wp_箱子表 
left join wp_商品表  on wp_箱子表.实际商品id=wp_商品表.id
left join wp_库位表 on Wp_箱子表.库位id=wp_库位表.id
left join wp_商品图片表  on wp_商品表.编号=wp_商品图片表.商品编号
where wp_箱子表.id='" + boxid + "'";
            DataTable dt_sql = comfun.GetDataTableBySQL(sql);
            wz = dt_sql.Rows[0]["位置"].ObjToStr();
            goods_name = dt_sql.Rows[0]["品名"].ObjToStr();
            goods_img = dt_sql.Rows[0]["图片路径"].ObjToStr();
        }
    }
}