using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using tdx.database.Common_Pay.WeiXinPay;

namespace tdx.memb.man.tuan.OrdersManage
{
    /// <summary>
    /// tuikuan 的摘要说明
    /// </summary>
    public class tuikuan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
         string orderno = context.Request["orderno"].ToString();

            DataTable dt = comfun.GetDataTableBySQL("select top 1 a.out_trade_no,b.应付款,a.订单编号 from  dbo.TM_订单支付表 a ,  TM_订单表  b where 1=1  and a.订单编号='" + orderno + "' and a.订单编号=b.订单编号");
            //微信付款数据
            if (dt.Rows.Count > 0)
            {
                WxPayData payData = new WxPayData();
                payData.SetValue("out_trade_no", dt.Rows[0]["out_trade_no"].ToString());
                payData.SetValue("out_refund_no", dt.Rows[0]["订单编号"].ToString());
                payData.SetValue("total_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100));
                payData.SetValue("refund_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100));
                //操作员ID,默认商户号
                payData.SetValue("op_user_id", "1325030101");
                //返回订单结果
                WxPayData unifiedOrderResult = WxPayApi.Refund(payData);
                string result = unifiedOrderResult.GetValue("result_code").ToString();
                if (result == "SUCCESS")
                {
                    comfun.UpdateBySQL("update TM_订单表 set state='退款成功' where 订单编号='" + orderno + "'");
                    context.Response.Write("退款成功");
                }
                else
                {
                    context.Response.Write("退款失败");
                }
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