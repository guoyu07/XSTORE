using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;
using System.Web.UI.HtmlControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class deal : BasePage
    {

        public string default_message = "暂未设置默认商品，补货时将为您推荐热销商品";

        private DataRow _hotelinfo;
        public DataRow HotelInfo
        {
            get
            {
                if (_hotelinfo == null)
                {
                    string sql = @"SELECT 仓库id FROM [tshop].[dbo].[WP_用户权限] A LEFT JOIN [dbo].[WP_仓库表] B ON A.仓库id = B.ID WHERE A.用户id =" + UserId;
                    DataTable dt = comfun.GetDataTableBySQL(sql);
                    if (dt.Rows.Count > 0)
                    {
                        _hotelinfo = dt.Rows[0];
                    }
                    else
                    {
                        RedirectError("酒店不存在");
                    }

                }
                return _hotelinfo;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        protected void PageInit() {

            BindPend();
            BindDeal();
        
        }
        private void BindPend() {
            var sql = string.Format("SELECT * FROM [视图前台送货] WHERE 仓库id = {0} AND 状态 = 0", HotelInfo["仓库id"].ObjToInt(0));
            DataTable dt = comfun.GetDataTableBySQL(sql);
            pend_repeater.DataSource = dt;
            pend_repeater.DataBind();
        }

        private void BindDeal() {
            var sql = string.Format("SELECT * FROM [视图前台送货] WHERE 仓库id = {0} AND 状态 = 1", HotelInfo["仓库id"].ObjToInt(0));
            DataTable dt = comfun.GetDataTableBySQL(sql);
            deal_repeater.DataSource = dt;
            deal_repeater.DataBind();

        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = sender as HtmlButton;
                var id = obj.Attributes["data-id"].ObjToInt(0);
                var sql = string.Format("UPDATE  WP_送货需求 SET 状态 = {0} WHERE id = {1}", 1, id);
                Log.WriteLog("类：deal", "方法：confirm_Click", "sql：" + sql);
                var b = SqlDataHelper.ExecuteCommand(sql);
                if (b > 0)
                {
                    BindPend();
                    BindDeal();
                }
                else
                {
                    Response.Write("<script>alert('更新失败')</script>");
                    return;
                }
                
            }
            catch (Exception ex)
            {
                Log.WriteLog("类：deal", "方法：confirm_Click", "异常信息：" + ex.Message);
                
            }
            

        }
//        protected void pagesA()
//        {
//            //             string sql_yingbuhuo = @"select 售出时间,库位名,默认商品id,品名,位置,库位id from wp_仓库表 A
//            //left join wp_库位表 b on b.仓库id=a.id
//            //left join wp_箱子表 c on c.库位id=b.id
//            //left join wp_商品表 d on d.id=c.默认商品id
//            //where A.id='"+hotel_id+"' and 实际商品id=0 and a.isshow=1 and c.isshow=1 and b.isshow=1 and d.IsShow=1 and datediff(day,售出时间,getdate())=0";
//            string sql_yingbuhuo = @"select 位置,库位名,品名,时间 from wp_送货需求 a
//left join wp_库位表 b on a.库位id=b.id
//where a.仓库id='"+hotel_id+"' and datediff(day,时间,getdate())=0";
//            DataTable dt_yingbuhuo = comfun.GetDataTableBySQL(sql_yingbuhuo);
//            totalA = dt_yingbuhuo.Rows.Count.ObjToInt(0);
//            for(int i = 0; i < dt_yingbuhuo.Rows.Count; i++)
//            {
//                if (string.IsNullOrEmpty(dt_yingbuhuo.Rows[i]["品名"].ObjToStr()))
//                {
//                    dt_yingbuhuo.Rows[i]["品名"] = default_message;
//                }
//            }
//            A_rp.DataSource = dt_yingbuhuo;
//            A_rp.DataBind();
//        }

//        protected void pagesB()
//        {
//            string sql_shijibuhuo = @"select 位置,库位名,品名,时间 from wp_送货需求 a
//left join wp_库位表 b on a.库位id=b.id
//where a.仓库id='" + hotel_id+"' and datediff(day,时间,getdate())=0 and a.状态=1";
//            DataTable dt_shiji = comfun.GetDataTableBySQL(sql_shijibuhuo);
//            totalB = dt_shiji.Rows.Count.ObjToInt(0);
//            for (int i = 0; i < dt_shiji.Rows.Count; i++)
//            {
//                if (string.IsNullOrEmpty(dt_shiji.Rows[i]["品名"].ObjToStr()))
//                {
//                    dt_shiji.Rows[i]["品名"] = default_message;
//                }
//            }
//            B_rp.DataSource = dt_shiji;
//            B_rp.DataBind();
//            pagesB_rp.DataSource = dt_shiji;
//            pagesB_rp.DataBind();

//        }
//        protected void pagesC()
//        {
//            string sql_weibuhuo = @"select 位置,库位名,品名,时间 from wp_送货需求 a
//left join wp_库位表 b on a.库位id=b.id
//where a.仓库id='" + hotel_id + "' and datediff(day,时间,getdate())=0 and a.状态=0";
//            DataTable dt_weibuhuo = comfun.GetDataTableBySQL(sql_weibuhuo);
//            totalC = dt_weibuhuo.Rows.Count.ObjToInt(0);
//            for (int i = 0; i < dt_weibuhuo.Rows.Count; i++)
//            {
//                if (string.IsNullOrEmpty(dt_weibuhuo.Rows[i]["品名"].ObjToStr()))
//                {
//                    dt_weibuhuo.Rows[i]["品名"] = default_message;
//                }
//            }
//            C_rp.DataSource = dt_weibuhuo;
//            C_rp.DataBind();
//        }
    }
}