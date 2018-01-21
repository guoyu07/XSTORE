using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using tdx.database.Common_Pay.WeiXinPay;
using System.Linq;
using DTcms.Common.Helper;
using Newtonsoft.Json;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// openbox 的摘要说明
    /// </summary>
    public class openbox : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "进接口");
            string openid = context.Session["OpenId"].ObjToStr();
            string mac = context.Request["mac"].ObjToStr();
                try
                {
                    string sql = @"select c.仓库id,c.库位id,c.位置,d.箱子MAC,c.订单编号,c.id as 订单字表ID  from WP_订单表 A
left join wp_订单支付表 B on A.订单编号=b.订单编号
left join wp_订单子表 c on A.订单编号=c.订单编号
left join WP_库位表 d on d.id=c.库位id
where A.openid='" + openid + "'and a.state in(2,5) and A.下单时间 > dateadd(day,-1,getdate()) and d.箱子MAC='"+mac+"'  and c.是否开箱 is null";
                    DTcms.Common.Log.WriteLog("页面：openbox", "方法：ProcessRequest", "sql：" + sql);
                    DataTable dt_box = comfun.GetDataTableBySQL(sql);
                    var kuweiId = 0;
                    var rbh = new RemoteBoxHelper();
                    var order_list = new List<int>();
                    var postion_list = string.Empty;
                    var flag = true;
                    List<string> open_list = new List<string>();
                    var dis_open_list = new List<string>();
                    for (int i = 0; i < dt_box.Rows.Count; i++)
                    {
                        DTcms.Common.Log.WriteLog("页面：openbox", "方法：ProcessRequest", "dt_box.Rows.Count：" + dt_box.Rows.Count);
                        if (i == 0)
	                    {
		                     kuweiId = dt_box.Rows[i]["库位id"].ObjToInt(0);
	                    }
                        postion_list += (dt_box.Rows[i]["位置"].ObjToInt(0) - 1).ObjToStr() + ",";
                        DTcms.Common.Log.WriteLog("页面：openbox", "方法：ProcessRequest", "postion_list：" + postion_list);
                        order_list.Add(dt_box.Rows[i]["订单字表ID"].ObjToInt(0));
                    }
                    try
                    {
                        DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "mac：" + mac);
                        DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "position：" + postion_list.TrimEnd(','));
                        Dictionary<string, bool> dic = rbh.OpenRemoteBox("" + mac + "", "" + postion_list.TrimEnd(',') + "");

                        DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "dic：" + JsonConvert.SerializeObject(dic));
                        var p_list = postion_list.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in p_list)
                        {
                            //只要有一个开箱不成功，订单就为false;
                            if (!dic[item])
                            {
                                flag = false;
                                dis_open_list.Add(item);
                            }
                            else
                            {
                                open_list.Add(item);
                            }
                        }
                        int b = 0;
                        DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "open_list.Count：" + open_list.Count);
                        var begin_exsql = " Begin Tran ";
                        var final_sql = string.Empty;
                        var end_sql = @" If @@ERROR>0
                                                            Rollback Tran  
                                                        Else
                                                            Commit Tran
                                                        Go";
                        if (open_list.Count > 0)
                        {
                            
                            //开箱成功的在订单字表中记录开箱成功的信息
                            string sub_order_update_sql = string.Format(@"UPDATE wp_订单子表 SET 是否开箱 = 1 WHERE 库位id='{0}' AND 位置 IN({1})", kuweiId, open_list.Select(o => (int.Parse(o) + 1).ObjToStr()).Aggregate<string>((x, y) => x + "," + y).ObjToStr());
                            //根据库位id和位置获取对应信息
                            string sub_order_sql = string.Format(@"select 仓库id,酒店id,库位id,位置 from WP_箱子表 a 
left join WP_库位表 b on a.库位id = b.id
left join WP_仓库表 c on b.仓库id = c.id
left join WP_订单字表 d on d.库位id
where 库位id = {0} and 位置 in({1})", kuweiId, open_list.Select(o => (int.Parse(o) + 1).ObjToStr()).Aggregate<string>((x, y) => x + "," + y).ObjToStr());
                            var sub_order_dt = SqlDataHelper.GetDataTable(sub_order_sql);
                            for (int i = 0; i < sub_order_dt.Rows.Count; i++)
			                {
                                var dr = sub_order_dt.Rows[i];
                                var jituan_id = dr["酒店id"].ObjToStr();
                                var hotel_id = dr["仓库id"].ObjToStr();
                                var goods_id = 0;
                                var position = open_list[i];
			                    sub_order_update_sql += string.Format(@"  INSERT INTO [dbo].[WP_投放任务]
                                                                                               ([投放酒店id]
                                                                                               ,[投放仓库id]
                                                                                               ,[投放库位id]
                                                                                               ,[箱子位置]
                                                                                               ,[商品id]
                                                                                               ,[房间图片]
                                                                                               ,[时间]
                                                                                               ,[IsShow]
                                                                                               ,[是否投放]
                                                                                               ,[user_id])
                                                                                         VALUES
                                                                                               ({0}
                                                                                               ,{1}
                                                                                               ,{2}
                                                                                               ,{3}
                                                                                               ,{4}
                                                                                               ,'{5}'
                                                                                               ,{6}
                                                                                               ,{7}
                                                                                               ,{8}
                                                                                               ,{9})
                                                                                    ", jituan_id, hotel_id, kuweiId, position, goods_id, "", "getdate()", 1, 0, 0);
                            }
                           
                            b = SqlDataHelper.ExecuteCommand(sub_order_update_sql);
                        }
                        #region 检查判断所有的订单是否都已经开箱，完全开箱的吧订单状态设置为已开箱

                     

                        var find_sql = string.Format("SELECT 订单编号 FROM WP_订单子表 WHERE id IN({0}) AND 是否开箱 IS NULL",order_list.Select(o=>o.ObjToStr()).Aggregate<string>((x,y)=>x+","+y));
                        final_sql = string.Format(@"UPDATE WP_订单表 SET state = {3} WHERE 订单编号 IN(select c.订单编号  from WP_订单表 A
left join wp_订单支付表 B on A.订单编号=b.订单编号
left join wp_订单子表 c on A.订单编号=c.订单编号
left join WP_库位表 d on d.id=c.库位id
where A.openid='{0}'and a.state in(2,5) and d.箱子MAC='{1}' and c.订单编号 NOT IN({2}))", openid, mac, find_sql,3);
                        b = SqlDataHelper.ExecuteCommand(final_sql);
                        
                        #endregion
                    }
                    catch(Exception ex)
                    {
                        DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "异常信息："+ex.Message+",位置：" + ex.StackTrace);
                        context.Response.Write("信息异常：" + ex.StackTrace);
                        return;
                    }
                    //SqlDataHelper.ExecuteCommand("update wp_订单表 set state=" + state + " where 订单编号='" + order_no + "'");
                    //DataTable dt_select = comfun.GetDataTableBySQL("select * from wp_订单子表  where 订单编号='" + orderno + "'");
                    //DataTable dt_select_enter = comfun.GetDataTableBySQL("select * from wp_订单子表  where 订单编号='" + orderno + "' and 备注='已开箱'");
                    //if (dt_select.Rows.Count == dt_select_enter.Rows.Count)
                    //{
                    //    comfun.UpdateBySQL("update WP_订单表 set state=3 where 订单编号='" + orderno + "'");
                    //    context.Response.Write("开箱成功!");
                    //}
                    //else
                    //{
                    //    //Log.WriteLog("openbox", dt_select.Rows.Count.ObjToStr(), dt_select_enter.Rows.Count.ObjToStr());
                    //    comfun.UpdateBySQL("update WP_订单表 set state=5,备注='开箱未完成/开箱失败' where 订单编号='" + orderno + "'");
                    //    context.Response.Write("开箱失败,请联系客服!!");
                    //}
                    if (dis_open_list.Count > 1)
                    {
                        DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "dis_open_list：" + JsonConvert.SerializeObject(dis_open_list));
                       
                        context.Response.Write(dis_open_list.Select(o => (o.ObjToInt(0) + 1).ObjToStr()).Aggregate<string>((x, y) => x + ',' + y) + "号,开箱失败,请联系客服!!!");
                        return;
                    }
                    else if (dis_open_list.Count == 1)
                    {
                        context.Response.Write(dis_open_list[0] + "号,开箱失败,请联系客服!!!");
                    }
                    else
                    {
                        context.Response.Write("开箱成功");
                        return;
                    }
                    
                }
                catch
                {
                    //comfun.UpdateBySQL("update WP_订单表 set state=5,备注='开箱未完成/开箱失败' where 订单编号='" + orderno + "'");
                    context.Response.Write("开箱失败,请联系客服!!!");
                    return;
                }
//                    //Log.WriteLog("openbox", "openid", "openid");
//                    string sql_wz = @"select 商品id,WP_订单表.订单编号,价格,数量,库位id,wp_订单子表.仓库id,位置,箱子mac from wp_订单子表
//left join WP_库位表 on WP_库位表.id=WP_订单子表.库位id
//left join wp_订单表 on WP_订单表.订单编号=WP_订单子表.订单编号
//left join wp_订单支付表  on wp_订单支付表.订单编号=wp_订单子表.订单编号
//where wp_订单表.openid='" + openid + "' and (state=2 or state=5) and  支付时间 >=dateadd(MINUTE,-15,getdate())";
//                    DataTable dt_wz = comfun.GetDataTableBySQL(sql_wz);
//                    var rbh = new RemoteBoxHelperNew();
//                    var postion_list = string.Empty;
//                    var mac = string.Empty;
//                    var state = 0;
//                    //先获取开箱位置，统一开箱
//                    for (int i = 0; i < dt_wz.Rows.Count; i++)
//                    {
//                        if (i == 0)
//                        {
//                            mac = dt_wz.Rows[i]["箱子MAC"].ObjToStr();
//                        }
//                        postion_list += (dt_wz.Rows[i]["位置"].ObjToInt(0) - 1).ObjToStr() + ",";
//                    }
//                    try
//                    {
//                        Dictionary<string, bool> dic = rbh.OpenRemoteBox("" + mac + "", "" + postion_list.TrimEnd(',') + "");
//                        var flag = true;
//                        List<string> open_list = new List<string>();
//                        var dis_open_list = new List<string>();
//                        var p_list = postion_list.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
//                        foreach (string item in p_list)
//                        {
//                            //只要有一个开箱不成功，订单就为false;
//                            if (!dic[item])
//                            {
//                                flag = false;
//                                dis_open_list.Add(item);
//                            }
//                            else
//                            {
//                                open_list.Add(item);
//                            }
//                        }
//                        state = flag ? 3 : 5;
//                        //开箱成功的在订单字表中记录开箱成功的信息
//                        string sub_order_update_sql = string.Format(@"UPDATE wp_订单子表 SET 是否开箱 = 1 WHERE 订单编号='{0}' AND 位置 IN({1})", orderno, open_list.Aggregate<string>((x, y) => x + "," + y).ObjToStr());
//                        int b = SqlDataHelper.ExecuteCommand(sub_order_update_sql);
//                        //state = b ? 3 : 5; 
//                    }
//                    catch ( Exception ex)
//                    {
//                        DTcms.Common.Log.WriteLog("接口：openbox", "方法：ProcessRequest", "异常信息：" + ex.Message);
//                        state = 5;
//                    }
         
//                    var sql = "update wp_订单表 set state=" + state + " where 订单编号='" + orderno + "'";
                    //for (int i = 0; i < dt_wz.Rows.Count; i++)
                    //{
                    //    rbh.OpenRemoteBox("" + dt_wz.Rows[i]["箱子MAC"].ObjToStr() + "", "" + (dt_wz.Rows[i]["位置"].ObjToInt(0) - 1).ObjToStr() + "");
                    //    string sql_outstock = @"select 单据编号,位置 from wp_出库表 where 单据编号='" + orderno + "' and 位置='" + dt_wz.Rows[i]["位置"] + "'and 库位id='" + dt_wz.Rows[i]["库位id"] + "' ";
                    //    DataTable dt_outstock = comfun.GetDataTableBySQL(sql_outstock);
                    //    if (dt_outstock.Rows.Count > 0)//判断是否是刷新页面重置开箱按钮  若出库表已存在，说明时刷新进入
                    //    {
                    //        comfun.UpdateBySQL("update wp_箱子表 set 实际商品id=0,售出时间=getdate()  where 库位id='" + dt_wz.Rows[i]["库位id"].ObjToStr() + "' and 位置='" + dt_wz.Rows[i]["位置"].ObjToStr() + "'");//修改箱子状态
                    //    }
                    //    else
                    //    {
                    //        //插入出库表
                    //        comfun.InsertBySQL("insert wp_出库表 (单据编号,商品id,数量,出价,总出价额,操作日期,库位id,位置,操作id,出库类型,IsShow) values('" + orderno + "','" + dt_wz.Rows[i]["商品id"] + "','" + dt_wz.Rows[i]["数量"] + "','" + dt_wz.Rows[i]["价格"] + "','" + dt_wz.Rows[i]["价格"] + "',getdate(),'" + dt_wz.Rows[i]["库位id"] + "','" + dt_wz.Rows[i]["位置"] + "',8,1,1)");

                    //        comfun.UpdateBySQL("update wp_箱子表 set 实际商品id=0,售出时间=getdate()  where 库位id='" + dt_wz.Rows[i]["库位id"].ObjToStr() + "' and 位置='" + dt_wz.Rows[i]["位置"].ObjToStr() + "'");//修改箱子状态
                    //    }
                    //}
                    //rbh.OpenRemoteBox("" + dt_wz.Rows[i]["箱子MAC"].ObjToStr() + "", "" + (dt_wz.Rows[i]["位置"].ObjToInt(0) - 1).ObjToStr() + "");
                    //comfun.UpdateBySQL("update WP_订单表 set state=3 where 订单编号='" + orderno + "'");
                    //SqlDataHelper.ExecuteCommand(sql);
                    //context.Response.Write("开箱成功");
                //}
                //catch
                //{
                //    comfun.UpdateBySQL("update WP_订单表 set state=5 where 订单编号='" + orderno + "'");
                //    context.Response.Write("开箱失败,请联系客服");
                //}

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