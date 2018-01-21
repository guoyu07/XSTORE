using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using tdx.database.Common_Pay.WeiXinPay;

namespace tdx.memb.man.Shop.OrdersManage
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
                DTcms.Common.Log.WriteLog("orderno", orderno, "-----");
                DataTable dt = comfun.GetDataTableBySQL("select top 1 a.out_trade_no,b.应付款,a.订单编号 from  dbo.WP_订单支付表 a ,  WP_订单表  b where 1=1  and a.订单编号='" + orderno + "' and a.订单编号=b.订单编号");
                //微信付款数据
                DTcms.Common.Log.WriteLog("是否存在订单", dt.Rows.Count.ToString(), "-----");
                if (dt.Rows.Count > 0)
                {
                    //Log.WriteLog("out_trade_no", dt.Rows[0]["out_trade_no"].ToString(), "-----");
                    //Log.WriteLog("out_refund_no", dt.Rows[0]["订单编号"].ToString(), "-----");
                    //Log.WriteLog("total_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100).ToString(), "-----");
                    //Log.WriteLog("refund_fee", "", "-----");
                    //Log.WriteLog("op_user_id", WxPayConfig.MCHID, "-----");
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
                    
                    //Log.WriteLog("返回结果", result, "-----");
                    //Log.WriteLog("", "", result);
                    if (result == "SUCCESS")
                    {
                        comfun.UpdateBySQL("update WP_订单表 set state='退款成功' where 订单编号='" + orderno + "'");
                        //更新T+状态
                        comfun.UpdateBySQL("update UFTData629131_000001.dbo.SA_SaleOrder set pubuserdefnvc1='退款成功' where code='" + orderno + "' ");
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
                DTcms.Common.Log.WriteLog("tuikuan",ex.Message,"数据异常");
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