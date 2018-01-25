
using System;
using System.Data;
using System.Web.UI;
using System.Linq;


namespace XStore.Common.WeiXinPay
{
    public class ResultNotify : Notify 
    {
        public ResultNotify(Page page): base(page)
        {

        }
        public override void ProcessNotify()
        {
            try
            {
                string openid = string.Empty;
                Log.WriteLog("页面：ResultNotify", "方法：ProcessNotify", "openid" + openid);
                string is_offline = string.Empty;
                Log.WriteLog("页面：ResultNotify", "方法：ProcessNotify", "is_offline" + is_offline);

                WxPayData notifyData = GetNotifyData();

                //检查支付结果中transaction_id是否存在
                if (!notifyData.IsSet("transaction_id"))
                {
                    //若transaction_id不存在，则立即返回结果给微信支付后台
                    WxPayData res = new WxPayData();
                    res.SetValue("return_code", "FAIL");
                    res.SetValue("return_msg", "支付结果中微信订单号不存在");
                    //Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                    page.Response.Write(res.ToXml());
                    page.Response.End();
                }
                string transaction_id = notifyData.GetValue("transaction_id").ToString();
                //查询订单，判断订单真实性
                if (!QueryOrder(transaction_id))
                {
                    //若订单查询失败，则立即返回结果给微信支付后台
                    WxPayData res = new WxPayData();
                    res.SetValue("return_code", "FAIL");
                    res.SetValue("return_msg", "订单查询失败");
                    //Log.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
                    page.Response.Write(res.ToXml());
                    page.Response.End();
                }
                //查询订单成功
                else
                {
     //               string out_trade_no = notifyData.GetValue("out_trade_no").ToString();
     //               string tb_out_trade_no = notifyData.GetValue("out_trade_no").ToString();
     //               Log.WriteLog("页面：ResultNotify(微信回调)", "方法：ProcessNotify", "out_order_no" + out_trade_no);
     //               DataTable dt_wpmoney = new DataTable();
     //               out_trade_no = out_trade_no.Split('_')[0].ToString();
     //               dt_wpmoney = comfun.GetDataTableBySQL("select 应付款,openid,is_offline from WP_订单表 where 订单编号='" + out_trade_no + "'");
     //               openid = dt_wpmoney.Rows[0]["openid"].ObjToStr();
     //               if (Convert.ToInt32(Utils.ObjToDecimal(dt_wpmoney.Rows[0]["应付款"].ToString(), 0) * 100) == Utils.ObjToInt(notifyData.GetValue("total_fee"), 0))
     //               {
     //                   try
     //                   {
     //                       if (comfun.GetDataTableBySQL("select * from  WP_订单支付表 where 订单编号='" + out_trade_no + "'  ").Rows.Count == 0)
     //                       {

     //                           var begin_exsql = " Begin Tran ";
     //                           var exsql = string.Empty;
     //                           var end_sql = @" If @@ERROR>0
     //                                                       Rollback Tran  
     //                                                   Else
     //                                                       Commit Tran
     //                                                   Go";
     //                           double fee = Math.Round((double)Utils.ObjToInt(notifyData.GetValue("total_fee"), 0) / 100, 2);
     //                           DataTable dt_order = SqlDataHelper.GetDataTable("select * from WP_订单支付表 where 订单编号='" + out_trade_no + "' ");
     //                           int state = 0;
     //                           if (dt_order.Rows.Count == 0)
     //                           {
     //                               exsql += " update WP_订单表 set state='2' where 订单编号='" + out_trade_no + "' ";
     //                               exsql += @" INSERT INTO [dbo].[WP_订单支付表]
     //      ([订单编号]
     //      ,[支付方式]
     //      ,[支付金额]
     //      ,[openid]
     //      ,[支付时间]
     //      ,[支付方式id]
     //      ,[out_trade_no])
     //VALUES
     //      ('" + out_trade_no + "','微信','" + fee + "','" + openid + "','" + System.DateTime.Now + "','','" + out_trade_no + "')";
     //                               //Log.WriteLog("类：ResultNotify", "方法：ProcessNotify", "is_offline:" + is_offline);
     //                               if (!string.IsNullOrEmpty(is_offline) && bool.Parse(is_offline))
     //                               {
     //                                   //推送模板消息
     //                                   Log.WriteLog("类：ResultNotify", "方法：ProcessNotify", "推送模板消息:");
     //                                   //
     //                               }
     //                               else
     //                               {
     //                                   Log.WriteLog("类：ResultNotify", "方法：ProcessNotify", "is_offline:false;");
     //                                   DataTable dt_box = SqlDataHelper.GetDataTable("select 箱子MAC,位置 from WP_订单子表 left join wp_库位表 on wp_订单子表.库位id=WP_库位表.id  where 订单编号='" + out_trade_no + "'");
     //                                   var rbh = new RemoteBoxHelper();
     //                                   //var rbh = new RemoteBoxHelperNew();
     //                                   var mac = string.Empty;
     //                                   var postion_list = string.Empty;

     //                                   for (int i = 0; i < dt_box.Rows.Count; i++)
     //                                   {
     //                                       if (i == 0)
     //                                       {
     //                                           mac = dt_box.Rows[i]["箱子MAC"].ObjToStr();
     //                                       }
     //                                       postion_list += (dt_box.Rows[i]["位置"].ObjToInt(0) - 1).ObjToStr() + ",";
     //                                   }
     //                                   Log.WriteLog("类：ResultNotify", "订单编号：", out_trade_no.Substring(1, out_trade_no.Length - 1));
     //                                   rbh.OpenRemoteBox("" + mac + "", out_trade_no.Substring(1, out_trade_no.Length - 1), "" + postion_list.TrimEnd(',') + "");
     //                                   SqlDataHelper.ExecuteCommand(begin_exsql + exsql + end_sql);
     //                               }
     //                               WxPayData res = new WxPayData();
     //                               res.SetValue("return_code", "SUCCESS");
     //                               res.SetValue("return_msg", "订单成功");
     //                               page.Response.Write(res.ToXml());
     //                               page.Response.End();

     //                           }
     //                       }
     //                   }
     //                   catch (Exception e)
     //                   {
     //                       DbHelperSQL.GetSingle("insert into WP_订单支付表(订单编号,支付方式,支付金额,openid,支付时间,out_trade_no) values('" + out_trade_no + "','微信','" + e.Message + "','" + openid + "',getdate(),'" + tb_out_trade_no + "') ");
     //                       comfun.UpdateBySQL("update WP_订单子表 set 结算时间='" + DateTime.Now + "'");
     //                       Log.WriteLog("页面：ResultNotify", "方法：ProcessNotify", "异常信息：" + e.Message);
     //                       WxPayData res = new WxPayData();
     //                       res.SetValue("return_code", "FAIL");
     //                       res.SetValue("return_msg", "订单金额不对");
     //                       page.Response.Write(res.ToXml());
     //                       page.Response.End();
     //                   }
     //               }
     //               else
     //               {
     //                   Log.WriteLog("页面：ResultNotify", "方法：ProcessNotify", "金额不符：");
     //                   WxPayData res = new WxPayData();
     //                   res.SetValue("return_code", "FAIL");
     //                   res.SetValue("return_msg", "订单金额不对");
     //                   page.Response.Write(res.ToXml());
     //                   page.Response.End();

     //               }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：ResultNotify", "方法：ProcessNotify", "支付程序有错误：" + ex.Message + ";错误位置：" + ex.StackTrace);
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单已撤销");
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
           
        }
        //public string GetName(string openid)
        //{
        //    DataTable dt_memb = comfun.GetDataTableBySQL("select * from B2c_Mem where openid='" + openid + "'");
        //    if (dt_memb.Rows.Count > 0)
        //    {
        //        return dt_memb.Rows[0]["M_name"].ToString();
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}

        //查询订单
        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
