using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Common;
using XStore.Entity;

namespace XStore.WebSite.WebSite.Goods
{
    public partial class Detail : BasePage
    {
        //public int good_id = 0;
        //public string goods_name = "";
        //public string goods_miaoshu = "";
        //public string goods_guige = "";
        //public decimal goods_benzhanjia = 0;

        //public string goods_img = "";
        //string no_img = "/shop/img/no-image.jpg";//默认图片           
        //int weizhi = 0;
        private Cabinet _cabinet;
        protected Cabinet cabinet
        {
            get
            {
                if (_cabinet == null)
                {
                    var boxMac = Request.QueryString[Constant.IMEI].ObjToStr();

                    _cabinet = context.Query<Cabinet>().FirstOrDefault(o => o.mac.Equals(boxMac));
                }
                return _cabinet;
            }
        }
        private int _position = -1;
        public int position
        {
            get
            {
                if (_position == -1)
                {
                    _position = Request.QueryString[Constant.Position].ObjToInt(0);
                }
                return _position;
            }
        }
        private Product _product;
        public Product product
        {
            get
            {
                if (_product == null)
                {
                    var product_id = Request.QueryString[Constant.ProductId].ObjToInt(0);
                    _product = context.Query<Product>().FirstOrDefault(o => o.id == product_id);
                }
                return _product;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-商品详情";
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        #region  加载选中的商品详情
        protected void PageInit()
        {
            if (product == null)
            {
                MessageBox.Show(this, "system_alert", "商品不存在");
                return;
            }

//            good_id = Request["goods_id"].ObjToInt(0);
//            weizhi = Request["weizhi"].ObjToInt(0);

//            goods_info_id.InnerText = good_id.ObjToStr();
//            goods_info_weizhi.InnerText = weizhi.ObjToStr();
//            goods_info_kw.InnerText = kwid.ObjToStr();
//            openid_span.InnerText = OpenId;
//            string sql_goods_img = "select 图片路径 from wp_商品表 left join wp_商品图片表 on wp_商品图片表.商品编号=wp_商品表.编号 where wp_商品表.id='" + good_id + "'";
//            DataTable dt_goods_img = comfun.GetDataTableBySQL(sql_goods_img);

//            if (!string.IsNullOrEmpty(dt_goods_img.Rows[0]["图片路径"].ObjToStr()))
//            {
//                goods_img = dt_goods_img.Rows[0]["图片路径"].ObjToStr();
//            }
//            else
//            {
//                goods_img = no_img;
//            }

//            string sql_zuhe = @"select A.id,A.品名,A.规格,A.单位,A.重量,A.市场价,A.本站价,A.库存数量,A.限购数量,A.是否单样,B.描述,C.图片路径,d.商品id as 子商品id,e.品名 as 子商品品名,f.描述 as 子商品描述,g.图片路径 as 子商品图片路径 from WP_商品表  A
//left join WP_商品详情表 B on A.编号=B.商品编号
//left join WP_商品图片表 C on A.编号=C.商品编号
//left join wp_商品表组 D on a.id=d.商品组合id
//left join wp_商品表 e on e.id=d.商品id
//left join WP_商品详情表 f on f.商品编号=e.编号
//left join WP_商品图片表 g on e.编号=g.商品编号 
//where A.isshow=1 and d.isshow=1 and A.id='" + good_id + "'";
//            DataTable dt_zu = comfun.GetDataTableBySQL(sql_zuhe);
//            if (dt_zu.Rows.Count > 0)
//            {
//                goods_guige = dt_zu.Rows[0]["品名"].ObjToStr() + ":";
//                for (int i = 0; i < dt_zu.Rows.Count; i++)
//                {
//                    if (i == dt_zu.Rows.Count - 1)
//                    {
//                        goods_guige += dt_zu.Rows[i]["子商品品名"].ObjToStr();
//                        goods_miaoshu += dt_zu.Rows[i]["子商品描述"].ObjToStr();
//                    }
//                    else
//                    {
//                        goods_guige += dt_zu.Rows[i]["子商品品名"].ObjToStr() + "+";
//                        goods_miaoshu += dt_zu.Rows[i]["子商品描述"].ObjToStr();
//                    }
//                }
//                goods_name = dt_zu.Rows[0]["品名"].ToString();
//                goods_benzhanjia = dt_zu.Rows[0]["本站价"].ObjToDecimal(0);
//                zuhe_rp.DataSource = dt_zu;
//                zuhe_rp.DataBind();
//            }
//            else
//            {
//                string sql = @"select A.id,A.品名,A.规格,A.单位,A.重量,A.市场价,A.本站价,A.库存数量,A.限购数量,A.是否单样,B.描述,C.图片路径 from WP_商品表  A
//left join WP_商品详情表 B on A.编号=B.商品编号
//left join WP_商品图片表 C on A.编号=C.商品编号
//where A.id='" + good_id + "'";

//                DataTable dt = comfun.GetDataTableBySQL(sql);
//                if (dt.Rows.Count > 0)
//                {
//                    goods_name = dt.Rows[0]["品名"].ObjToStr();
//                    goods_miaoshu = dt.Rows[0]["描述"].ObjToStr();
//                    goods_guige = dt.Rows[0]["规格"].ObjToStr();
//                    goods_benzhanjia = dt.Rows[0]["本站价"].ObjToDecimal(0);
//                }
//                else
//                {
//                    goods_name = string.Empty;
//                    goods_miaoshu = string.Empty;
//                    goods_guige = string.Empty;
//                    goods_benzhanjia = new decimal(0);
//                }

//            }

        }
        #endregion

        public static int click_times = 0;//定义一个参数 为0
        public static int new_goods_id = 0;

    }
}