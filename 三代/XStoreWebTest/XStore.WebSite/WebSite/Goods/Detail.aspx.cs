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

        }

        protected void buy_ServerClick(object sender, EventArgs e)
        {
            var requestUrl = string.Format("http://139.199.160.173:9119/test/create?openId={0}&mac={1}&pos={2}", Session[Constant.OpenId], cabinet.mac, position);

        }
        #endregion

    }
}