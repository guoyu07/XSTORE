using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using tdx.Weixin;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using DTcms.Common;
using tdx.database.Common_Pay.WeiXinPay;



namespace Wx_NewWeb.Shop.pages
{
    public partial class payCenter : BasePage // System.Web.UI.Page 
    {
        public static string wxJsApiParam { get; set; }
        public string no_img = string.Empty;
        protected static string url_fenxiang = "";
        protected string shareurl = string.Empty;
        protected string jsdkSignature = string.Empty;

        #region 订单编号
        private string _orderno;
        protected string OrderNo
        {
            get
            {
                if (string.IsNullOrEmpty(_orderno))
                {
                    _orderno = Request["order"] != null ? Convert.ToString(Request["order"]) : string.Empty;
                }
                Session["order_no"] = _orderno;
                return _orderno;
            }
        }
        #endregion

        #region 订单总价
        private decimal _totalprice;
        public decimal TotalPrice
        {
            get
            {
                if (_totalprice == new decimal())
                {
                    string sql_price = "select isnull(sum( 价格*数量),0) as 总价  from WP_订单子表 where 订单编号='" + OrderNo + "'";
                    DataTable dt_price = comfun.GetDataTableBySQL(sql_price);
                    _totalprice = dt_price.Rows[0]["总价"].ObjToDecimal(0);
                }
                return _totalprice;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("页面：payCenter", "方法：Page_Load", "进入payCenter页面" );
                    //绑定订单商品
                    BindGoods();
                    //绑定总金额
                    total_price.InnerText = TotalPrice.ObjToStr();
                    hid_order.Value = OrderNo;
                    //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
                    JsApiPay jsApiPay = new JsApiPay(this);
                    jsApiPay.openid = OpenId;
                    jsApiPay.total_fee = Convert.ToInt32(Utils.ObjToDecimal(TotalPrice, 0) * 100);
                    //JSAPI支付预处理
                    try
                    {
                        WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(OrderNo);
                        wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数   

                        comfun.UpdateBySQL("update wp_购物车 set 是否结算=1 where openid='" + OpenId + "'");

                    }
                    catch (Exception ex)
                    {
                        tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("页面：payCenter", "方法：Page_Load", "异常："+ex.Message);
                        RedirectError("");
                    }
                }
                catch (Exception ex)
                {
                    tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("页面：payCenter", "方法：Page_Load", "异常：" + ex.Message);
                    RedirectError(ex.Message);
                }
            }
        }
       

        protected void BindGoods() {
            shareurl = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
            url_fenxiang = Server.HtmlEncode(shareurl + "&sponsor=" + OpenId);
            jsdkSignature = GetJsdkSignature(HttpContext.Current.Request.Url.AbsoluteUri.ToString());

            //string sql_good = "";
//            if (GoodsId != 0)
//            {
//                sql_good = @"select 品名,本站价 as 单价,图片路径 from WP_商品表 left join WP_商品图片表  on WP_商品表.编号=WP_商品图片表.商品编号 where WP_商品表.id='" + GoodsId + "'";
//                DataTable dt_good = comfun.GetDataTableBySQL(sql_good);
//                total_price.InnerText = TotalPrice.ObjToStr();
//                car_rp.DataSource = dt_good;
//                car_rp.DataBind();
//            }
//            else
//            {
//                sql_good = @"select WP_购物车.id,商品id,品名,单价,数量,图片路径 
//from WP_购物车 
//left join WP_商品表 on WP_商品表.id=WP_购物车.商品id
//left join WP_商品图片表  on WP_商品表.编号=WP_商品图片表.商品编号
//where openid='" + OpenId + "' and 是否结算=0";


            //DataTable dt_good = comfun.GetDataTableBySQL(sql_good);

            //if (insert_order == 0)
            //{
            //    comfun.InsertBySQL("insert into wp_订单表 (订单编号,总金额,应付款,下单时间,openid,state) values('" + OrderNo + "','" + TotalPrice + "','" + TotalPrice + "',getdate(),'" + OpenId + "','1')");
            //}
            //car_rp.DataSource = dt_good;
            //car_rp.DataBind();
//          }
            var sql = string.Format(@"SELECT ISNULL(B.品名,'') AS 品名,ISNULL(B.编号new,'') AS 编号,B.本站价 as 单价,C.图片路径 FROM [dbo].[WP_订单子表] A 
LEFT JOIN [dbo].[WP_商品表] B ON A.商品id = B.id
LEFT JOIN [dbo].[WP_商品图片表] C ON B.编号 = C.商品编号 WHERE 订单编号 = '{0}'", OrderNo);
            var dt_good = comfun.GetDataTableBySQL(sql);
            car_rp.DataSource = dt_good;
            car_rp.DataBind();
        
        }
        #region 订单内的商品展示
        #endregion

        public string GetJsdkSignature(string url)
        {
            string noncestr = "9hKgyCLgGZOgQmEI";
            int timestamp = 1421142450;
            Chat ch = new Chat();
            string ticket = ch.GetJsapi_Ticket();
            string string1 = "jsapi_ticket=" + ticket + "&noncestr=" + noncestr + "&timestamp=" + timestamp + "&url=" + url;
            string signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(string1, "SHA1");
            return signature.ToLower();
        }


    }
}