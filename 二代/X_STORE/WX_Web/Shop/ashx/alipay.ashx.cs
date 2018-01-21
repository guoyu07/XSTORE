using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tdx.database.Common_Pay.WeiXinPay;
using tdx.database.Common_Pay.Alipay;
using Aop.Api.Response;
using DTcms.Common;
using Aop.Api.Request;
using Aop.Api;
using System.Configuration;
//using tdx.database.Common_Pay

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// alipay 的摘要说明
    /// </summary>
    public class alipay : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                //subject = "商品描述";
                string order_no = context.Request["order"].ObjToStr();
              //  string order_no2 = context.Request["order_no"].ToString();
                decimal money = context.Request["money"].ObjToDecimal(0);
                string subject = "幸事多"; //context.Request["subject"].ObjToStr();
                //Log.WriteLog("order_no", order_no, "-----");
                //Log.WriteLog("money", money.ObjToStr(), "-----");
                //Log.WriteLog("subject", subject, "-----");
                string app_id = "2017061207475665";//Config.Partner;//合作伙伴id
                string merchant_private_key = "MIICXgIBAAKBgQDodWFjuFNVtk/8A7ZHrthI2dSbViu+BnwkjmTstPa9iyEPZ/3UotaPq+rG4sNo4aHlvG+eRV1wuEZdKmYUPhVqFTmQozIca8R7KzvW2ByZKWBCol9aElzGc5Ff49epTpIC2Au+VSbPs+V6kFNB3tCoKeoGie5vGxizXGZv38bouwIDAQABAoGBAMYFWBUurC7Tw4cXUmv2EeDdTzOUUGbr90zc0DSkY5xLrLoHCD/fB5AUD0elXHk33EZsI1lcFaE0GRy8RYDw8iNwPkwSwocpZzBYi9COpmJpI29WgE677rkZ3eXVLZS4agw74CeHdX+JpqGWjCM1oiKB9pewEh8PuI59ZanDRg+BAkEA/laYqH48Jz3y6nxZcmlc2WpkEg3RT5E3ZUzlfn1jCFGOLXwSjUXLYVH6KweuRLQoHi9UaxoJjuokgb9Y/FYScQJBAOn6MDFeTTOREiZQ/gTNzvDd5Oa2D7PI4Eo7dIfbUgp2XCu5YjG56o5OaRiLTqC1U1PTq4qw4/PaVuuU6pHbK+sCQQCCrugdm085MqGAToh/OxgUNpBYnnTwF0OJb2t0BOU/vvf48wltQXFw/fg25+lpL9B1Qgh0R5qlrjU33aPRdEBhAkEAxdcWHvhlAQBev2VmlLtNix+lKGuzdUqaVEpXq3SIt24DW7liTTeuHGwys10/u+X2sn/doeUWqp/pNUPy4CfZxwJAF1aK/7FTS48CLt0ep3tv84CEEnj2bt47P/+Y9OV0d1n/+dctoLPsKGr7kSK7w7fEFZE9WeBuk2+hxbEBGcV/5A==";
                string alipay_public_key = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDDI6d306Q8fIfCOaTXyiUeJHkrIvYISRcc73s3vF1ZT7XN8RNPwJxo8pWaJMmvyTn9N4HQ632qJBVHf8sxHi/fEsraprwCtzvzQETrNRwVxLO5jVmRGi60j8Ue1efIlzPXV9je9mkjzOmdssymZkh2QhUrCmZYI/FCEa3/cNMW0QIDAQAB";
                //decimal pay_money = 0;
                //Log.WriteLog("merchant_private_key", merchant_private_key, "-----");
                //Log.WriteLog("alipay_public_key", alipay_public_key, "-----");
                string timeout_express = "30m";//订单有效时间（分钟）
                string postUrl = "https://openapi.alipay.com/gateway.do";
                string sign_type = "RSA";//加签方式 有两种RSA和RSA2 我这里使用的RSA2（支付宝推荐的）
                string version = "1.0";//固定值 不用改
                string format = "json";//固定值
                string Amount = money.ObjToStr();//订单金额
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("", "moeny", money.ObjToStr());
                string method = "alipay.trade.wap.pay";//调用接口 固定值 不用改
                //Log.WriteLog("method", method, "-----");
                IAopClient client = new DefaultAopClient(postUrl, app_id, merchant_private_key, format, version, sign_type, alipay_public_key, "UTF-8", false);
                AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
                // var url = "http://x.x-store.com.cn/shop/";

                string notify_url = string.Format("{0}/shop/NotifyPay/alipaypc/notify_url.aspx", ConfigurationManager.AppSettings["HomeUrl"].ObjToStr());
                string return_url = string.Format("{0}/shop/NotifyPay/alipaypc/return_url.aspx",ConfigurationManager.AppSettings["HomeUrl"].ObjToStr());

                request.SetNotifyUrl(notify_url);
                request.SetReturnUrl(return_url);
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("", "notify_url", notify_url);
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("", "return_url", return_url);
                var bizcontent = "{" +
                "    \"body\":\"" + subject + "\"," +
                "    \"subject\":\"" + subject + "\"," +
                "    \"out_trade_no\":\"" + order_no + "\"," +
                "    \"timeout_express\":\"" + timeout_express + "\"," +
                "    \"total_amount\":\"" + Amount + "\"," +
                "    \"product_code\":\"" + method + "\"" +
                "  }";
                request.BizContent = bizcontent;
                AlipayTradeWapPayResponse response = client.pageExecute(request);
                string form = response.Body;
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("-------------------------------------------------", "++++++++++++++++++++++++++++++++++++++++++++++++",form);
                context.Response.Write(form);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}