using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using DTcms.DBUtility;
using Creatrue.Common.Msgbox;
using DTcms.Common;

namespace Wx_NewWeb.Shop.pages
{
    public partial class detail : BasePage
    {
        public int good_id = 0;
        public string goods_name = "";
        public string goods_miaoshu = "";
        public string goods_guige = "";
        public decimal goods_benzhanjia = 0;

        public string goods_img = "";
        string no_img = "/shop/img/no-image.jpg";//默认图片           
        int weizhi = 0;
        int kwid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                goods_news();
            }
        }


        #region  加载选中的商品详情
        protected void goods_news()
        {                //商品id 由上级页面传送
            good_id = Request["goods_id"].ObjToInt(0);
            weizhi = Request["weizhi"].ObjToInt(0);
            kwid = Request["kwid"].ObjToInt(0);
            Log.WriteLog("页面：details", "方法：goods_news", "kwid:" + Request["kwid"]);
            goods_info_id.InnerText = good_id.ObjToStr();
            goods_info_weizhi.InnerText = weizhi.ObjToStr();
            goods_info_kw.InnerText = kwid.ObjToStr();
            openid_span.InnerText = OpenId;
            Log.WriteLog("页面：details", "方法：goods_news", "OpenId:" + OpenId);
            string sql_goods_img = "select 图片路径 from wp_商品表 left join wp_商品图片表 on wp_商品图片表.商品编号=wp_商品表.编号 where wp_商品表.id='" + good_id + "'";
            DataTable dt_goods_img = comfun.GetDataTableBySQL(sql_goods_img);

            if (!string.IsNullOrEmpty(dt_goods_img.Rows[0]["图片路径"].ObjToStr()))
            {
                goods_img = dt_goods_img.Rows[0]["图片路径"].ObjToStr();
            }
            else
            {
                goods_img = no_img;
            }

            string sql_zuhe = @"select A.id,A.品名,A.规格,A.单位,A.重量,A.市场价,A.本站价,A.库存数量,A.限购数量,A.是否单样,B.描述,C.图片路径,d.商品id as 子商品id,e.品名 as 子商品品名,f.描述 as 子商品描述,g.图片路径 as 子商品图片路径 from WP_商品表  A
left join WP_商品详情表 B on A.编号=B.商品编号
left join WP_商品图片表 C on A.编号=C.商品编号
left join wp_商品表组 D on a.id=d.商品组合id
left join wp_商品表 e on e.id=d.商品id
left join WP_商品详情表 f on f.商品编号=e.编号
left join WP_商品图片表 g on e.编号=g.商品编号 
where A.isshow=1 and d.isshow=1 and A.id='" + good_id + "'";
            DataTable dt_zu = comfun.GetDataTableBySQL(sql_zuhe);
            if (dt_zu.Rows.Count > 0)
            {
                goods_guige = dt_zu.Rows[0]["品名"].ObjToStr() + ":";
                for (int i = 0; i < dt_zu.Rows.Count; i++)
                {
                    if (i == dt_zu.Rows.Count - 1)
                    {
                        goods_guige += dt_zu.Rows[i]["子商品品名"].ObjToStr();
                        goods_miaoshu += dt_zu.Rows[i]["子商品描述"].ObjToStr();
                    }
                    else
                    {
                        goods_guige += dt_zu.Rows[i]["子商品品名"].ObjToStr() + "+";
                        goods_miaoshu += dt_zu.Rows[i]["子商品描述"].ObjToStr();
                    }
                }
                goods_name = dt_zu.Rows[0]["品名"].ToString();
                goods_benzhanjia = dt_zu.Rows[0]["本站价"].ObjToDecimal(0);
                zuhe_rp.DataSource = dt_zu;
                zuhe_rp.DataBind();
            }
            else
            {
                string sql = @"select A.id,A.品名,A.规格,A.单位,A.重量,A.市场价,A.本站价,A.库存数量,A.限购数量,A.是否单样,B.描述,C.图片路径 from WP_商品表  A
left join WP_商品详情表 B on A.编号=B.商品编号
left join WP_商品图片表 C on A.编号=C.商品编号
where A.id='" + good_id + "'";

                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count > 0)
                {
                    goods_name = dt.Rows[0]["品名"].ObjToStr();
                    goods_miaoshu = dt.Rows[0]["描述"].ObjToStr();
                    goods_guige = dt.Rows[0]["规格"].ObjToStr();
                    goods_benzhanjia = dt.Rows[0]["本站价"].ObjToDecimal(0);
                }
                else
                {
                    goods_name = string.Empty;
                    goods_miaoshu = string.Empty;
                    goods_guige = string.Empty;
                    goods_benzhanjia = new decimal(0);
                }

            }

        }
        #endregion

        public static int click_times = 0;//定义一个参数 为0
        public static int new_goods_id = 0;

        //protected void join_car_Click(object sender, EventArgs e)
        //{
        //    if (Session["OpenId"] != null)
        //    {

        //        openid = Session["OpenId"].ToString();
        //    }
        //    good_id = Request["goods_id"] != null ? Convert.ToInt32(Request["goods_id"]) : 0;
        //    weizhi = Request["weizhi"] != null ? Convert.ToInt32(Request["weizhi"]) : 0;
        //    kwid = Request["kwid"] != null ? Convert.ToInt32(Request["kwid"]) : 0;
        //    string sql_ck = "select id as 库位id,仓库id from WP_库位表 where id='" + kwid + "'";
        //    DataTable dt_ck_sql = comfun.GetDataTableBySQL(sql_ck);
        //    string ck_id = dt_ck_sql.Rows[0]["仓库id"].ObjToStr();
        //    tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("----------------", "details-join_car_Click", "" + good_id + "&weizhi=" + weizhi + "&kwid=" + kwid + "");
        //    goods_news();

        //    if (good_id != new_goods_id)
        //    {
        //        click_times = 0;//判断是否同一个商品
        //    }
        //    if (click_times == 0)//首次点击向数据库插入数据
        //    {
        //        string jointhecar = "insert into WP_购物车 (openid,商品id,单价,数量,是否结算,仓库id,库位id,位置)values('" + openid + "','" + good_id + "','" + goods_benzhanjia + "',1,0,'"+ck_id+"','" + kwid + "','" + (weizhi.ObjToInt(0) - 1) + "')";
        //        //  goods_news();
        //        MessageBox.ShowAndRedirect(this, "加入购物车成功！", "");
        //        comfun.InsertBySQL(jointhecar);
        //        new_goods_id = good_id;
        //        //若微信打开则openid 始终存在 此处为测试
        //        click_times = 12312;
        //    }
        //    else//多次点击 不做任何事情
        //    {
        //        Response.Write("<Script Language=JavaScript>alert('购物车已存在！');</Script>");
        //    }
        //}
        //    public static int buy_nowclick = 0;
        //      public static int buy_nowtimes = 0;
        //       public static string order2 = "";
        //        protected void buyNow_Click(object sender, EventArgs e)
        //        {
        //            if (Session["OpenId"] != null)
        //            {

        //                openid = Session["OpenId"].ToString();
        //            }
        //            good_id = Request["goods_id"] != null ? Convert.ToInt32(Request["goods_id"]) : 0;
        //            weizhi = Request["weizhi"] != null ? Convert.ToInt32(Request["weizhi"]) : 0;
        //            kwid = Request["kwid"] != null ? Convert.ToInt32(Request["kwid"]) : 0;
        //            string sql_ck = "select id as 库位id,仓库id from WP_库位表 where id='" + kwid + "'";
        //            DataTable dt_ck_sql = comfun.GetDataTableBySQL(sql_ck);
        //            string ck_id = dt_ck_sql.Rows[0]["仓库id"].ObjToStr();
        //            tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("----------------", "details-buyNow_Click", "" + good_id + "&weizhi=" + weizhi + "&kwid=" + kwid + "");
        //            string order_no = "S" + DateTime.Now.ToString("yyyyMMdd") + DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) from (select count(1) as num from [dbo].[WP_订单表] where CONVERT(varchar(100),下单时间,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ObjToStr();
        //            string sql = @"select A.id,A.品名,A.规格,A.单位,A.重量,A.市场价,A.本站价,A.库存数量,A.限购数量,A.是否单样,B.描述,C.图片路径 from WP_商品表  A
        //left join WP_商品详情表 B on A.编号=B.商品编号
        //left join WP_商品图片表 C on A.编号=C.商品编号
        //where A.id='" + good_id + "'";
        //            DataTable dt = comfun.GetDataTableBySQL(sql);
        //            goods_name = dt.Rows[0]["品名"].ToString();
        //            goods_miaoshu = dt.Rows[0]["描述"].ToString();
        //            goods_guige = dt.Rows[0]["规格"].ToString();
        //            goods_benzhanjia = dt.Rows[0]["本站价"].ObjToDecimal(0);
        //            //查询购物车中商品
        //            //插入订单子表
        //            comfun.InsertBySQL("insert into wp_订单子表 (商品id,订单编号,价格,数量,库位id,仓库id,位置,下单时间,结算状态) values ('" + good_id + "','" + order_no + "','" + goods_benzhanjia + "',1,'" + kwid + "','" + ck_id + "','" + weizhi + "',getdate(),0)");

        //            tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("---------提交成功-------", "detail", good_id.ObjToStr());
        //            MessageBox.ShowAndRedirect(this, "提交成功！", "../pages/payCenter.aspx?goods_id=" + good_id.ObjToStr() + "&order=" + order_no + "");

        //        }
    }
}