using System;
using System.Web;
using tdx.database.Common_Pay.WeiXinPay;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// tuikuan 的摘要说明
    /// </summary>
    public class tuikuan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string orderno = context.Request["orderno"].ToString();
                //DTcms.Common.Log.WriteLog("orderno", orderno, "-----");
                DataTable dt = comfun.GetDataTableBySQL("select top 1 a.out_trade_no,b.应付款,a.订单编号 from  dbo.WP_订单支付表 a ,  WP_订单表  b where 1=1  and a.订单编号='" + orderno + "' and a.订单编号=b.订单编号");
                //微信付款数据
                //DTcms.Common.Log.WriteLog("是否存在订单", dt.Rows.Count.ToString(), "-----");
                if (dt.Rows.Count > 0)
                {
                    //DTcms.Common.Log.WriteLog("out_trade_no", dt.Rows[0]["out_trade_no"].ToString(), "-----");
                    //DTcms.Common.Log.WriteLog("out_refund_no", dt.Rows[0]["订单编号"].ToString(), "-----");
                    //DTcms.Common.Log.WriteLog("total_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100).ToString(), "-----");
                    //DTcms.Common.Log.WriteLog("refund_fee", "", "-----");
                    //DTcms.Common.Log.WriteLog("op_user_id", WxPayConfig.MCHID, "-----");
                    WxPayData payData = new WxPayData();
                    payData.SetValue("out_trade_no", dt.Rows[0]["out_trade_no"].ToString());
                    payData.SetValue("out_refund_no", dt.Rows[0]["订单编号"].ToString());
                    payData.SetValue("total_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100));
                    payData.SetValue("refund_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100));
                    //操作员ID,默认商户号
                    //payData.SetValue("op_user_id", "1340586301");
                    payData.SetValue("op_user_id", WxPayConfig.MCHID);
                    //返回订单结果
                    WxPayData unifiedOrderResult = WxPayApi.Refund(payData);
                    string result = unifiedOrderResult.GetValue("result_code").ToString();
                    //Log.WriteLog("tuikuan", result, "数据异常");

                    //DTcms.Common.Log.WriteLog("返回结果", result, "-----");
                    //Log.WriteLog("", "", result);
                    if (result == "SUCCESS")
                    {
                        comfun.UpdateBySQL("update WP_订单表 set state='7' where 订单编号='" + orderno + "'");                  
                        context.Response.Write("退款成功");
                    }
                    else
                    {
                        context.Response.Write("退款失败");
                    }
                }
            }
            catch (Exception ex)
            {
                DTcms.Common.Log.WriteLog("接口：tuikuan", "方法：ProcessRequest", "异常信息：" + ex.Message);
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