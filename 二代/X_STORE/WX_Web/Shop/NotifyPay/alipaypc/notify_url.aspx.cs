using Common.AliDayu;
using Creatrue.kernel;
using DTcms.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common.Helper;
using tdx.database.AiLiPay;

namespace Wx_NewWeb.Shop.NotifyPay.alipaypc
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log.WriteLog("not11ify_url", "page_load", "");
                SortedDictionary<string, string> sPara = GetRequestPost();
                bool verifyResult = false;
                //Log.WriteLog("notify_url", "page_load", "");
                if (sPara.Count > 0)//判断是否有带返回参数
                {
                    //Log.WriteLog("notify_url", "验证成功", "");
                    //Log.WriteLog("notify_url", "验证成功", sPara.ObjToStr());
                    Notify aliNotify = new Notify();
                    //Log.WriteLog("notify_url", "验证成功", "1");
                    try
                    {
                        //Log.WriteLog("notify_url", "验证成功", "1_try");
                        verifyResult = aliNotify.Verify(sPara, DTRequest.GetString("notify_id"), DTRequest.GetString("sign"));
                    }
                    catch (Exception ex)
                    {
                        //Log.WriteLog("notify_url", "验证成功", "1_catch");
                        LogHelper.WriteLog("", "", ex.ToString());

                    }
                    //Log.WriteLog("notify_url", "验证成功", "2");
                    if (verifyResult)//验证成功
                    {
                        //Log.WriteLog("notify_url", "验证成功", "2_if");
                        //Log.WriteLog("zfb_________________________________________________________________________________", "验证成功", "");
                        string trade_no = DTRequest.GetString("trade_no");
                        //Log.WriteLog("验证成功2_if", "trade_no", trade_no.ObjToStr());//支付宝交易号
                        string order_no = DTRequest.GetString("out_trade_no");
                        //Log.WriteLog("验证成功2_if", "order_no", order_no.ObjToStr());//获取订单号
                        string total_fee = DTRequest.GetString("total_amount");
                        //Log.WriteLog("验证成功2_if", "total_fee", total_fee.ObjToStr());//获取总金额
                        string trade_status = DTRequest.GetString("trade_status");          //交易状态

                        //Log.WriteLog("验证成功2_if", "trade_status", trade_status.ObjToStr());
                        //string hotel_name = string.Empty;
                        //string kw_name = string.Empty;
                        //string productNum = string.Empty;
                        var state = 0;
                        if (Config.Type == "1") //即时到帐接口处理方法
                        {

                            Log.WriteLog("Config.Type", "即时到帐接口处理方法", "1");
                            if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
                            {
                                var openid = string.Empty;
                                var begin_exsql = " Begin Tran ";
                                var exsql = string.Empty;
                                var end_sql = @" If @@ERROR>0
                                                            Rollback Tran  
                                                        Else
                                                            Commit Tran
                                                        Go";
                                DataTable dt_order = SqlDataHelper.GetDataTable("select * from WP_订单支付表 where 订单编号='" + order_no + "' ");
                                DataTable dt_open_order = SqlDataHelper.GetDataTable("select * from WP_订单表 where 订单编号='" + order_no + "' ");
                                if (dt_open_order.Rows.Count > 0)
                                {
                                    openid = dt_open_order.Rows[0]["openid"].ObjToStr();
                                }
                                if (dt_order.Rows.Count == 0)
                                {
                                    exsql += " update WP_订单表 set state='2' where 订单编号='" + order_no + "' ";
                                    exsql += @" INSERT INTO [dbo].[WP_订单支付表]
           ([订单编号]
           ,[支付方式]
           ,[支付金额]
           ,[openid]
           ,[支付时间]
           ,[支付方式id]
           ,[out_trade_no])
     VALUES
           ('" + order_no + "','支付宝','" + total_fee + "','"+openid+"','" + System.DateTime.Now + "','','" + trade_no + "')";
                                    DataTable dt_box = SqlDataHelper.GetDataTable("select 箱子MAC,位置 from WP_订单子表 left join wp_库位表 on wp_订单子表.库位id=WP_库位表.id  where 订单编号='" + order_no + "'");
                                    var rbh = new RemoteBoxHelper();
                                    var mac = string.Empty;

                                    var postion_list = string.Empty;
                                    for (int i = 0; i < dt_box.Rows.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                            mac = dt_box.Rows[i]["箱子MAC"].ObjToStr();
                                        }
                                        postion_list += (dt_box.Rows[i]["位置"].ObjToInt(0) - 1).ObjToStr() + ",";
                                    }
                                    rbh.OpenRemoteBox("" + mac + "", order_no.Substring(1, order_no.Length - 1), "" + postion_list.TrimEnd(',') + "");
                                    SqlDataHelper.ExecuteCommand(begin_exsql + exsql + end_sql);
                                }
                                Response.Write("Success");
                            }
                        }
                    }
                    Response.Write("Fails");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("类：Notify", "方法：PageLoad", "异常位置：" + ex.StackTrace + "异常信息：" + ex.Message);
                Response.Write("Fails");
            }
           
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            coll = Request.Form;

            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            return sArray;
        }
    }
}