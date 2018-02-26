using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Timers;
using Newtonsoft.Json;
using WeiXinPush.Model;

namespace WeiXinPush
{
    public partial class WeiXinPushServices : ServiceBase
    {

        private Timer _timer;
        private Timer __timer;
        private Timer _exceptionTimer;
        private Timer _openBoxTimer;
        private Timer _fillUpTimer;
        private Timer _fixedTimer;
        private int pushHour = int.Parse(ConfigurationManager.AppSettings["PUSHHOUR"]);
        private string root = ConfigurationManager.AppSettings["HomeUrl"].ObjToStr();
        public WeiXinPushServices()
        {
            InitializeComponent(); 
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _timer = new Timer(15000);
                _timer.Elapsed += timer_Elapsed;
                _timer.Start();

                __timer = new Timer(10000);
                __timer.Elapsed += _timer_Elapsed;
                __timer.Start();

                _exceptionTimer = new Timer(1000);
                _exceptionTimer.Elapsed += _exceptionTimer_Elapsed;
                _exceptionTimer.Start();

                _openBoxTimer = new Timer(5000);
                _openBoxTimer.Elapsed += _openboxTimer_Elapsed;
                _openBoxTimer.Start();

                _fillUpTimer = new Timer(1000);
                _fillUpTimer.Elapsed += _fillUpTimer_Elapsed;
                _fillUpTimer.Start();

                _fixedTimer = new Timer(4000);
                _fixedTimer.Elapsed += _fixedTime_Elapsed;
                _fixedTimer.Start();

            }
            catch (Exception ex)
            {
                Log.WriteLog("微信推送", "数据异常", ex.Message + ";异常位置：" + ex.StackTrace);
            }
        }
        //检测开箱失败订单，兵进行重新开箱操作
        private void _openboxTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var selectSql = string.Format(@"select 订单编号,mac, LEFT(位置,LEN(位置)-1) as 位置 from (
select top 1 
(select isnull(箱子MAC,'') from WP_库位表 where id = a.库位id) as mac,
(select convert(nvarchar(2),位置-1)+',' from WP_订单子表 where 订单编号 = a.订单编号 FOR XML PATH('')) as 位置,
a.订单编号
 from WP_订单子表 a left join WP_订单表 b on a.订单编号 = b.订单编号 where b.state in (2,5) and (a.是否开箱 = 0 or a.是否开箱 is null) and datediff(MINUTE,b.下单时间,getdate()) <= 30
) as c");
            Log.WriteLog("_openboxTimer_Elapsed", "sql："+ selectSql, "------" );
            DataTable selectDt = comfun.GetDataTableBySQL(selectSql);
            Log.WriteLog("_openboxTimer_Elapsed", "selectDtCount：" + selectDt.Rows.Count, "------");
            if (selectDt.Rows.Count != 0)
            {
                var orderNo = selectDt.Rows[0]["订单编号"].ToString();
                var position = selectDt.Rows[0]["位置"].ToString();
                var mac = selectDt.Rows[0]["mac"].ToString();
                OpenBox(orderNo, mac, position); 
            }
        }
        private void _fixedTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            var selectSql = string.Format(@"select top 1 * from WP_补货单 where Status in(1,3) and datediff(MINUTE,CreateTime,getdate()) <= 30");
            DataTable selectDt = comfun.GetDataTableBySQL(selectSql);
            if (selectDt.Rows.Count > 0)
            {
                var orderNo = selectDt.Rows[0]["OrderNo"].ToString();
                var position = selectDt.Rows[0]["Position"].ToString();
                var mac = selectDt.Rows[0]["Mac"].ToString();
                OpenBox(orderNo, mac, position, 0x02);
            }
        }
        private void _fillUpTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Minute > 30)
            {
                if (DateTime.Now.Second == 0)
                {
                    FillUpGoodsPush();
                }
            }
        }

        private void _exceptionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SystemExceptionPush();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SummarizingOrderInfoPush();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OrderInfoPush();
            FailOrderPush();
        }

        protected override void OnStop()
        {
            _timer.Stop();
            _timer.Close();
            Log.WriteLog("微信推送", "服务器停止时间", "服务器已停止");
        }

        #region 开箱失败订单推送

        public void FailOrderPush()
        {
            try
            {
                string orderSql = string.Format(@"SELECT top 1 订单编号,酒店名,库位名,下单时间,总金额,支付方式,数量,LEFT(品名,LEN(品名)-1) 品名 
        FROM (
        select  c.订单编号,
        (select top 1 仓库名 from WP_仓库表 where id=d.仓库id) as 酒店名,
        (select top 1 库位名 from WP_库位表 where id=d.库位id) as 库位名,
        (SELECT top 1 支付方式 FROM WP_订单支付表 WHERE 订单编号 = c.订单编号) as 支付方式,
        c.下单时间,
        c.总金额,
        (select sum(a.数量) from WP_订单子表 a left join WP_商品表 b on a.商品id = b.id where a.订单编号 = c.订单编号) as 数量,
        (select (b.品名+'('+convert(nvarchar(2),a.位置)+'号),') from WP_订单子表 a left join WP_商品表 b on a.商品id = b.id where a.订单编号 = c.订单编号 FOR XML PATH('')) as 品名 
        from WP_订单表 c left join WP_订单子表 d on c.订单编号 = d.订单编号 where c.hasPush is null and c.state in (5)
        ) e");

                Log.WriteLog("微信推送", "orderSql:", orderSql);
                DataTable orderDt = comfun.GetDataTableBySQL(orderSql);
                if (orderDt.Rows.Count == 0)
                {
                    //Log.WriteLog("微信推送", "无销售订单", "----------");
                    return;
                }
                var orderDr = orderDt.Rows[0];
                var color = "#D74C29";
                var title = string.Format("{0}-{1}于 {2} 发生一笔开箱失败交易订单。", orderDr["酒店名"], orderDr["库位名"], ((DateTime)orderDr["下单时间"]).ToString("yyyy-MM-dd HH:mm:ss"));
                var keyword1 = orderDr["订单编号"];
                var keyword2 = orderDr["品名"];
                var keyword3 = orderDr["数量"] + "件";
                var keyword4 = orderDr["总金额"] + " 元";
                var remark = "特此告知！！！";
                //var tempId = "wtVzjV2wJpVekxHYYwR3MGKdjDbjDt9vnRZUu_vFywM";
                var tempId = "aenuM_UsdJ_RixaKWnGEFGTlwuFQqHIyhq6OwhzvcWw";
                dynamic postData = new ExpandoObject();
                dynamic first = new ExpandoObject();
                first.value = title;
                first.color = color;

                dynamic keyword1Obj = new ExpandoObject();
                keyword1Obj.value = keyword1;
                keyword1Obj.color = color;

                dynamic keyword2Obj = new ExpandoObject();
                keyword2Obj.value = keyword2;
                keyword2Obj.color = color;

                dynamic keyword3Obj = new ExpandoObject();
                keyword3Obj.value = keyword3;
                keyword3Obj.color = color;

                dynamic keyword4Obj = new ExpandoObject();
                keyword4Obj.value = keyword4;
                keyword4Obj.color = color;

                dynamic remarkObj = new ExpandoObject();
                remarkObj.value = remark;
                remarkObj.color = color;

                postData.first = first;
                postData.keyword1 = keyword1Obj;
                postData.keyword2 = keyword2Obj;
                postData.keyword3 = keyword3Obj;
                postData.keyword4 = keyword4Obj;
                postData.remark = remarkObj;
                //Log.WriteLog("微信推送", "postData", JsonConvert.SerializeObject(postData));
                var url = root + "Shop/pages/AssistOpenBox.aspx?OrderNo=" + orderDr["订单编号"].ObjToStr(); ;
                var pushSql = string.Format(@"select openid from View_WechatPushAdmin where FailSendAuth = 1", orderDr["订单编号"]);
                var pushDt = comfun.GetDataTableBySQL(pushSql);

                foreach (DataRow pushDr in pushDt.Rows)
                {
                    var openId = pushDr["openid"].ToString();
                    var responseBool = Send_WX_Message(postData, openId, tempId, url);
                    if (responseBool)
                    {
                        string updateOrderSql = string.Format("update WP_订单表 set hasPush = 1 where 订单编号 = '{0}'", orderDr["订单编号"]);
                        var updateBool = comfun.UpdateBySQL(updateOrderSql);
                        if (updateBool == 0)
                        {
                            Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "更新发送状态失败");
                        }
                        else
                        {
                            Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "发送模板成功!!!");
                        }
                    }
                    else
                    {
                        Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "发送模板失败!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("微信推送", "数据异常：" + ex.Message, ";异常位置：" + ex.StackTrace);
            }
        }

        #endregion

        #region 订单推送
        protected void OrderInfoPush()
        {
            try
            {
                string orderSql = string.Format(@"SELECT top 1 订单编号,酒店名,库位名,下单时间,总金额,数量,LEFT(品名,LEN(品名)-1) 品名 
        FROM (
        select  c.订单编号,
        (select top 1 仓库名 from WP_仓库表 where id=d.仓库id) as 酒店名,
        (select top 1 库位名 from WP_库位表 where id=d.库位id) as 库位名,
        c.下单时间,
        c.总金额,
        (select sum(a.数量) from WP_订单子表 a left join WP_商品表 b on a.商品id = b.id where a.订单编号 = c.订单编号) as 数量,
        (select b.品名+',' from WP_订单子表 a left join WP_商品表 b on a.商品id = b.id where a.订单编号 = c.订单编号 FOR XML PATH('')) as 品名 
        from WP_订单表 c left join WP_订单子表 d on c.订单编号 = d.订单编号 where (c.hasPush is null or c.hasPush = 0) and c.state in (3)
        ) e");
                //Log.WriteLog("微信推送", "orderSql:", orderSql);
                DataTable orderDt = comfun.GetDataTableBySQL(orderSql);
                if (orderDt.Rows.Count == 0)
                {
                    //Log.WriteLog("微信推送", "无销售订单", "----------");
                    return;
                }
                var orderDr = orderDt.Rows[0];


                var color = "#173177";
                var title = string.Format("{0}-{1}于 {2} 发生一笔订单交易。", orderDr["酒店名"], orderDr["库位名"], ((DateTime)orderDr["下单时间"]).ToString("yyyy-MM-dd HH:mm:ss"));
                var keyword1 = orderDr["订单编号"];
                var keyword2 = orderDr["品名"];
                var keyword3 = orderDr["数量"] + "件";
                var keyword4 = orderDr["总金额"] + " 元";
                var remark = "感谢您的使用" + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var tempId = "aenuM_UsdJ_RixaKWnGEFGTlwuFQqHIyhq6OwhzvcWw";
                dynamic postData = new ExpandoObject();
                dynamic first = new ExpandoObject();
                first.value = title;
                first.color = color;

                dynamic keyword1Obj = new ExpandoObject();
                keyword1Obj.value = keyword1;
                keyword1Obj.color = color;

                dynamic keyword2Obj = new ExpandoObject();
                keyword2Obj.value = keyword2;
                keyword2Obj.color = color;

                dynamic keyword3Obj = new ExpandoObject();
                keyword3Obj.value = keyword3;
                keyword3Obj.color = color;

                dynamic keyword4Obj = new ExpandoObject();
                keyword4Obj.value = keyword4;
                keyword4Obj.color = color;

                dynamic remarkObj = new ExpandoObject();
                remarkObj.value = remark;
                remarkObj.color = color;

                postData.first = first;
                postData.keyword1 = keyword1Obj;
                postData.keyword2 = keyword2Obj;
                postData.keyword3 = keyword3Obj;
                postData.keyword4 = keyword4Obj;
                postData.remark = remarkObj;
                Log.WriteLog("微信推送", "postData", JsonConvert.SerializeObject(postData));

                var pushSql = string.Format(@"  select distinct(openid) from (
          select b.openid from (select WP_用户权限.* from WP_用户权限 left join WP_订单子表 on WP_用户权限.仓库id=WP_订单子表.仓库id where 订单编号 = '{0}') as a left join WP_用户表 b on a.用户id = b.id where (openid is not null and openid <> '' and 推送开关 = 1  and 角色id in (1,3,4))
          union all
          select openid from View_WechatPushAdmin where SendAuth = 1) d", orderDr["订单编号"]);
                var pushDt = comfun.GetDataTableBySQL(pushSql);
                //零时解决方案，直接修改发送状态，不管有没有发送成功
                string updateOrderSql = string.Format("update WP_订单表 set hasPush = 1 where 订单编号 = '{0}'", orderDr["订单编号"]);
                var updateBool = comfun.UpdateBySQL(updateOrderSql);
                if (updateBool == 0)
                {
                    Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "更新发送状态失败");
                }
                else
                {
                    Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "发送模板成功!!!");
                }
                foreach (DataRow pushDr in pushDt.Rows)
                {
                    var openId = pushDr["openid"].ToString();
                    Log.WriteLog("微信推送", "openId:", openId);
                    var responseBool = Send_WX_Message(postData, openId, tempId);
                    
                    //if (responseBool)
                    //{
                    //    string updateOrderSql = string.Format("update WP_订单表 set hasPush = 1 where 订单编号 = '{0}'", orderDr["订单编号"]);
                    //    var updateBool = comfun.UpdateBySQL(updateOrderSql);
                    //    if (updateBool == 0)
                    //    {
                    //        Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "更新发送状态失败");
                    //    }
                    //    else
                    //    {
                    //        Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "发送模板成功!!!");
                    //    }
                    //}
                    //else
                    //{
                    //    Log.WriteLog("微信推送", "订单：" + orderDr["订单编号"], "发送模板失败!!!");
                    //}
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("微信推送", "数据异常：" + ex.Message, ";异常位置：" + ex.StackTrace);

            }
        }
        #endregion

        #region 统计推送
        protected void SummarizingOrderInfoPush()
        {
            try
            {
                if (DateTime.Now.Hour == pushHour && DateTime.Now.Minute == 58)
                {
                    Log.WriteLog("微信推送", "进入了统计存入：", "");
                    var selectSql = string.Format("SELECT * FROM WP_StatisticsLog WHERE convert(nvarchar(10),[CreateTime],120) =convert(nvarchar(10),getdate(),120)");
                    var selectDt = comfun.GetDataTableBySQL(selectSql);
                    if (selectDt.Rows.Count == 0)
                    {
                        var orderSql =
                    @"select sum(WP_订单子表.价格) as 金额,sum(数量) as 销量 from WP_订单表 LEFT JOIN WP_订单子表 on WP_订单表.订单编号 = WP_订单子表.订单编号 where convert(nvarchar(10),WP_订单表.下单时间,120) = convert(nvarchar(10),dateadd(day,-1,getdate()),120) and state in(3,5)";
                        //Log.WriteLog("微信推送", "selectSql:", selectSql);
                        var orderDt = comfun.GetDataTableBySQL(orderSql);
                        var insertSql = string.Format(@"INSERT INTO [dbo].[WP_StatisticsLog]([TotalAmount],SaleNum)VALUES({0},{1})", orderDt.Rows[0]["金额"].ObjToDecimal(0), orderDt.Rows[0]["销量"].ObjToInt(0));
                        comfun.InsertBySQL(insertSql);
                    }
                }
                else if (DateTime.Now.Hour == pushHour && DateTime.Now.Minute == 59)
                {
                    Log.WriteLog("微信推送", "进入了统计推送：", "");
                    var selectSql = @"select * from WP_StatisticsLog WHERE convert(nvarchar(10),[CreateTime],120) =convert(nvarchar(10),getdate(),120) and IsSend = 0";
                    //Log.WriteLog("微信推送", "selectSql:", selectSql);
                    var selectDt = comfun.GetDataTableBySQL(selectSql);
                    if (selectDt.Rows.Count == 0)
                    {
                        return;
                    }
                    var title = "尊敬的管理员，昨日销售业绩如下：";
                    var keyword1 = DateTime.Now.AddDays(-1).ToString("yyyy年MM月dd日");
                    var keyword2 = string.Format("销售商品共 {1}件，总计 {0}元", selectDt.Rows[0]["TotalAmount"].ObjToDecimal(0), selectDt.Rows[0]["SaleNum"].ObjToInt(0));
                    var keyword3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    var remark = "感谢您的使用";
                    var tempId = "hO8PfzQOEve1m_XXRlkmJot0S-u5ca3_XodnymasYhc";
                    var color = "#173177";

                    dynamic postData = new ExpandoObject();
                    dynamic first = new ExpandoObject();
                    first.value = title;
                    first.color = color;

                    dynamic keyword1Obj = new ExpandoObject();
                    keyword1Obj.value = keyword1;
                    keyword1Obj.color = color;

                    dynamic keyword2Obj = new ExpandoObject();
                    keyword2Obj.value = keyword2;
                    keyword2Obj.color = color;

                    dynamic keyword3Obj = new ExpandoObject();
                    keyword3Obj.value = keyword3;
                    keyword3Obj.color = color;


                    dynamic remarkObj = new ExpandoObject();
                    remarkObj.value = remark;
                    remarkObj.color = color;

                    postData.first = first;
                    postData.keyword1 = keyword1Obj;
                    postData.keyword2 = keyword2Obj;
                    postData.keyword3 = keyword3Obj;
                    postData.remark = remarkObj;

                    foreach (string openId in GetOpenId((int)EnumCommon.推送权限.业绩统计推送))
                    {
                        Send_WX_Message(postData, openId, tempId);
                    };
                    var updateSql = string.Format(@"update WP_StatisticsLog set IsSend = 1  WHERE convert(nvarchar(10),[CreateTime],120) =convert(nvarchar(10),getdate(),120) and IsSend = 0 ");
                    comfun.UpdateBySQL(updateSql);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("微信推送", "数据异常：" + ex.Message, ";异常位置：" + ex.StackTrace);
            }

        }
        #endregion

        #region 系统异常推送

        protected void SystemExceptionPush()
        {
            var selectSql = string.Format(@"SELECT TOP 1 mac, datediff(MINUTE,createtime,getdate()) as offset
        FROM [tshop].[dbo].[WP_设备心跳记录表]
        order by createtime desc");
            var selectDt = comfun.GetDataTableBySQL(selectSql);
            if (selectDt.Rows.Count > 0)
            {
                Log.WriteLog("微信推送", "SystemExceptionPush:", "");
                //系统已经发生故障
                if (selectDt.Rows[0]["offset"].ObjToInt(0) >= 3)
                {
                    Log.WriteLog("微信推送", "系统已经发生故障:", "");
                    var exceptionSql = string.Format(@"select * from WP_SystemExceptionLog where IsException =1");
                    var exceptionDt = comfun.GetDataTableBySQL(exceptionSql);
                    //说明没有待处理的系统异常，是第一次趴窝或者是恢复后又再次趴窝
                    if (exceptionDt.Rows.Count == 0)
                    {
                        Log.WriteLog("微信推送", "说明没有待处理的系统异常，是第一次趴窝或者是恢复后又再次趴窝", "");
                        var insertSql = string.Format(@" insert into WP_SystemExceptionLog(IsException) values(1)");
                        comfun.InsertBySQL(insertSql);
                        ExceptionPush(DateTime.Now);
                    }
                    else if (DateTime.Now.Minute == 59 && DateTime.Now.Second == 59)
                    {
                        Log.WriteLog("微信推送", "一小时发一次", "");
                        ExceptionPush(exceptionDt.Rows[0]["ExceptionTime"].ObjToDateTime());
                    }
                }
                //说明系统已经恢复
                else
                {
                    Log.WriteLog("微信推送", "说明系统已经恢复", "");
                    var exceptionSql = string.Format(@"select count(*) from WP_SystemExceptionLog where IsException =1");
                    var exceptionDt = comfun.GetDataTableBySQL(exceptionSql);
                    //说明没有待处理的系统异常，是第一次趴窝或者是恢复后又再次趴窝
                    if (exceptionDt.Rows.Count > 0 && int.Parse(exceptionDt.Rows[0][0].ToString()) != 0)
                    {
                        Log.WriteLog("微信推送", "说明没有待处理的系统异常，是第一次趴窝或者是恢复后又再次趴窝", "");
                        var updateSql = string.Format(@" update WP_SystemExceptionLog set IsException = 0,RecoveryTime = getdate() where IsException = 1");
                        comfun.UpdateBySQL(updateSql);
                        return;
                    }

                }
            }
        }

        private void ExceptionPush(DateTime time)
        {
            Log.WriteLog("微信推送", "开始发送异常推送", "");
            var title = "尊敬的陈总：";
            var keyword1 = "酒店智能售货机";
            var keyword2 = time.ToString("yyyy-MM-dd HH:mm:ss");
            var keyword3 = "所有设备已全部停止工作，可能需要重启系统";
            var keyword4 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var remark = "请尽快处理！！！";

            //Log.WriteLog("微信推送", "openId:", openId);
            var tempId = "FWNdGDiTWYD4JrNPumPqbR_0AwiShQesxFN8kLAD8Bw";
            var color = "#D74C29";

            dynamic postData = new ExpandoObject();
            dynamic first = new ExpandoObject();
            first.value = title;
            first.color = color;

            dynamic keyword1Obj = new ExpandoObject();
            keyword1Obj.value = keyword1;
            keyword1Obj.color = color;

            dynamic keyword2Obj = new ExpandoObject();
            keyword2Obj.value = keyword2;
            keyword2Obj.color = color;

            dynamic keyword3Obj = new ExpandoObject();
            keyword3Obj.value = keyword3;
            keyword3Obj.color = color;

            dynamic keyword4Obj = new ExpandoObject();
            keyword4Obj.value = keyword4;
            keyword4Obj.color = color;


            dynamic remarkObj = new ExpandoObject();
            remarkObj.value = remark;
            remarkObj.color = color;

            postData.first = first;
            postData.keyword1 = keyword1Obj;
            postData.keyword2 = keyword2Obj;
            postData.keyword3 = keyword3Obj;
            postData.keyword4 = keyword4Obj;
            postData.remark = remarkObj;

            foreach (string openId in GetOpenId((int)EnumCommon.推送权限.系统异常推送))
            {
                Send_WX_Message(postData, openId, tempId);
            };
        }

        #endregion

        #region 补货推送
        protected void FillUpGoodsPush()
        {

            var selectSql = string.Format(@"select  [仓库id],[酒店名称],[补货房间数],[补货商品数],[openid] from View_FillUpGoodsLog where 仓库id in(select top 1 仓库id from WP_FillUpGoodsLog where 是否推送 = 0 and 补货商品数 > 10 and 仓库id in(select 仓库id from View_FillUpGoodsLog))");
            var selectDt = comfun.GetDataTableBySQL(selectSql);
            foreach (DataRow selectDr in selectDt.Rows)
            {
                var color = "#865FC5";
                var openId = selectDr["openid"].ObjToStr();
                var title = string.Format("尊敬的酒店经理，今日补货信息如下。");
                var keyword1 = selectDr["酒店名称"].ObjToStr();
                var keyword2 = selectDr["补货房间数"].ObjToInt(0) + " 间";
                var keyword3 = selectDr["补货商品数"].ObjToInt(0) + "件";
                var remark = "截止至 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Substring(0, 10) + " 08:00:00;\n请尽快安排补货任务;";
                var tempId = "8A2OZkYnac3yv0oO8iNkSz_lwfp_clVfagm_AQpFB_o";
                dynamic postData = new ExpandoObject();
                dynamic first = new ExpandoObject();
                first.value = title;
                first.color = color;

                dynamic keyword1Obj = new ExpandoObject();
                keyword1Obj.value = keyword1;
                keyword1Obj.color = color;

                dynamic keyword2Obj = new ExpandoObject();
                keyword2Obj.value = keyword2;
                keyword2Obj.color = color;

                dynamic keyword3Obj = new ExpandoObject();
                keyword3Obj.value = keyword3;
                keyword3Obj.color = color;

                dynamic remarkObj = new ExpandoObject();
                remarkObj.value = remark;
                remarkObj.color = color;

                postData.first = first;
                postData.keyword1 = keyword1Obj;
                postData.keyword2 = keyword2Obj;
                postData.keyword3 = keyword3Obj;
                postData.remark = remarkObj;
                //Log.WriteLog("微信推送", "postData", JsonConvert.SerializeObject(postData));
                var responseBool = Send_WX_Message(postData, openId, tempId);

            }
            if (selectDt.Rows.Count > 0)
            {
                string updateOrderSql = string.Format("update WP_FillUpGoodsLog set 是否推送 = 1 where 仓库id = {0}", selectDt.Rows[0]["仓库id"].ObjToInt(0));
                var updateBool = comfun.UpdateBySQL(updateOrderSql);
                if (updateBool == 0)
                {
                    Log.WriteLog("微信推送", "酒店id：" + selectDt.Rows[0]["仓库id"], "更新发送状态失败");
                }
                else
                {
                    Log.WriteLog("微信推送", "酒店id：" + selectDt.Rows[0]["订单编号"], "发送模板成功!!!");
                }
            }

        }

        #endregion

        protected List<string> GetOpenId(int _enum)
        {
            string sql = string.Empty;
            switch ((EnumCommon.推送权限)_enum)
            {
                case EnumCommon.推送权限.正常订单推送:
                    sql = string.Format(@"select openid from View_WechatPushAdmin where SendAuth = 1");
                    break;
                case EnumCommon.推送权限.异常订单推送:
                    sql = string.Format(@"select openid from View_WechatPushAdmin where FailSendAuth = 1");
                    break;
                case EnumCommon.推送权限.业绩统计推送:
                    sql = string.Format(@"select openid from View_WechatPushAdmin where StatisticsAuth = 1");
                    break;
                case EnumCommon.推送权限.系统异常推送:
                    sql = string.Format(@"select openid from View_WechatPushAdmin where SystemExceptionAuth = 1");
                    break;
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count == 0)
            {
                return new List<string>();
            }
            else
            {
                var openIdList = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    openIdList.Add(dr["openid"].ToString());
                }
                return openIdList;
            }
        }

        /// <summary>
        /// 模板推送
        /// </summary>
        /// <param name="bx_content"></param>
        /// <param name="bx_Address"></param>
        /// <param name="openid"></param>
        /// <param name="Remarks"></param>
        public bool Send_WX_Message(Object postDataObj, string openid, string template_id, string url = "")
        {
            try
            {
                //获取AccessToken
                string accessToken = WeiXin.GetAccess_token().access_token;
                //Log.WriteLog("微信推送", "access_token:", accessToken);
                //第一步设置所属行业
                msgData msg = new msgData();
                msg.touser = openid;
                if (!string.IsNullOrEmpty(msg.touser))
                {
                    msg.template_id = template_id;

                    msg.url = url;

                    msg.data = postDataObj;

                    string postUrl = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", accessToken);

                    string postData = JsonConvert.SerializeObject(msg);
                    //Log.WriteLog("微信推送", "模板发送postData:", JsonConvert.SerializeObject(postData));
                    string result = webRequestPost(postUrl, postData);
                    //Log.WriteLog("微信推送", "result:", result);
                    if (result.Contains("ok"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Log.WriteLog("微信推送", "模板发送异常:" + ex.Message, ";发送异常的位置：" + ex.StackTrace);
                return false;
            }

        }
        /// <summary>
        /// Post 提交调用抓取
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="param">参数</param>
        /// <returns>string</returns>
        public static string webRequestPost(string url, string param)
        {

            //Log.WriteLog("微信推送", "开始发送模板消息:", "-------");
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(param);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "Post";
            req.Timeout = 120 * 1000;
            req.ContentType = "application/x-www-form-urlencoded;";
            req.ContentLength = bs.Length;
            //Log.WriteLog("微信推送", "开始请求。。。:", "-------");
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Flush();
                reqStream.Close();

            }
            //Log.WriteLog("微信推送", "发送模板消息成功:", "-------");
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                try
                {
                    Stream strm = wr.GetResponseStream();
                    //Log.WriteLog("微信推送", " req.GetResponse():", strm.ToString());
                    StreamReader sr = new StreamReader(strm, System.Text.Encoding.UTF8);
                    string line;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    while ((line = sr.ReadLine()) != null)
                    {
                        sb.Append(line + System.Environment.NewLine);
                    }
                    req.Abort();
                    sr.Close();
                    strm.Close();
                    return sb.ToString();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool OpenBox(string orderNo,string mac,string postion_list,byte type=0x01)
        {
            var rbh = new RemoteBoxHelper();
            try
            {
                rbh.OpenRemoteBox("" + mac + "", orderNo.Substring(1,orderNo.Length-1), "" + postion_list + "",type);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：qaBoxCheck", "方法：qaBoxCheck", "异常信息：" + ex.Message);
                return false;
            }

        }

    }

}


public struct msgData
{
    public string touser;

    public string template_id;

    public string url;

    public Object data;
}