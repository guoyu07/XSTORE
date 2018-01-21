using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace tdx.memb.tools
{
    /// <summary>
    /// GetMoreOrderHandler 的摘要说明
    /// </summary>
    public class GetMoreOrderHandler : IHttpHandler
    {
        int myindex=999;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string pageindex =context.Request.Params["pageindex"];
            string ordertype = context.Request.Params["ordertype"];
            string type = context.Request.Params["type"];
            int.TryParse(pageindex, out myindex);
            string myresult = Orderinfo(pageindex, ordertype, type);
            string mymessage = "true";
            if (string.IsNullOrEmpty(myresult))
            {
                mymessage = "没有更多数据了呦";
            }
            object obj = new { message = mymessage, result = myresult, index = (myindex + 1) };
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
        private string Orderinfo(string pageindex, string ordertype, string type)
        {
            StringBuilder sbhtml = new StringBuilder();
            string orderstate = ordertype;
            StringBuilder sborder = new StringBuilder();
            
            if (type.Equals("WP"))
            {
                //sborder.Append("\r\n select * from  (select  ROW_NUMBER() over (order by  id asc)  as rownum, id ");
                //sborder.Append("\r\n ,订单编号,总金额,[state] as 状态,convert(varchar(50),下单时间,23) as 下单时间 , ");
                //sborder.Append("\r\n (select  wx昵称  from  [dbo].[WP_会员表] where  openid=WP_订单表.openid ) as 收货人 ");
                //sborder.Append("\r\n from   WP_订单表 " + (string.IsNullOrEmpty(orderstate) ? "" : "where state='" + orderstate + "' ") + " ) t where rownum between " + (1 + 5 * (myindex - 1)) + " and " + 5 * myindex + " ");
                sborder.Append("\r\n select * from  (select ROW_NUMBER() over (order by  id asc)  as rownum,t1.*, (总金额+ 运费-isnull(优惠金额,0)) as 应付金额 from  (select   id  ");
                sborder.Append("\r\n ,订单编号,总金额,[state] as 状态,convert(varchar(50),下单时间,23) as 下单时间 , 运费 ");
                sborder.Append("\r\n ,(select  wx昵称  from  [dbo].[WP_会员表] where  openid=WP_订单表.openid ) as 收货人 from   WP_订单表 " + (string.IsNullOrEmpty(orderstate) ? "" : "where state='" + orderstate + "' ") + ") t1  left join  ");
                sborder.Append("\r\n ( select 订单编号,  sum(支付金额) as  优惠金额 from [dbo].[WP_订单支付表] where 支付方式!='微信' and 支付方式!='支付宝' group by 订单编号) t2 ");
                sborder.Append("\r\n on t1.订单编号=t2.订单编号) t3 where rownum  between  " + (1 + 5 * (myindex - 1)) + " and " + 5 * myindex + " ");
            }
            else
            {
                sborder.Append("\r\n select * from  (select ROW_NUMBER() over (order by  id asc)  as rownum,t1.*, (总金额+ 运费-isnull(优惠金额,0)) as 应付金额 from  (select   id  ");
                sborder.Append("\r\n ,订单编号,总金额,[state] as 状态,convert(varchar(50),下单时间,23) as 下单时间 , 运费 ");
                sborder.Append("\r\n ,(select  wx昵称  from  [dbo].[WP_会员表] where  openid=TM_订单表.openid ) as 收货人 from   TM_订单表 " + (string.IsNullOrEmpty(orderstate) ? "" : "where state='" + orderstate + "' ") + ") t1  left join  ");
                sborder.Append("\r\n ( select 订单编号,  sum(支付金额) as  优惠金额 from [dbo].[TM_订单支付表] where 支付方式!='微信' and 支付方式!='支付宝' group by 订单编号) t2 ");
                sborder.Append("\r\n on t1.订单编号=t2.订单编号) t3 where rownum  between  " + (1 + 5 * (myindex - 1)) + " and " + 5 * myindex + " ");
            }
            DataTable dt = comfun.GetDataTableBySQL(sborder.ToString());
            if (dt.Rows.Count > 0)
            {
                sbhtml.Append("\r\n  <tbody id='tb-15294420605'>                                                                                                          ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("\r\n select 订单编号,价格,数量 ,(select top 1 图片路径 from [dbo].[WP_商品图片表]     ");
                    sb.Append("\r\n where 商品编号=(select 编号  from WP_商品表 where WP_商品表.id=WP_订单子表.商品id) order by 序号 desc) as  商品图片 ");
                    sb.Append("\r\n ,(select top 1 品名 from  WP_商品表 where WP_商品表.id=WP_订单子表.商品id)+(select top 1 规格 from  WP_商品表 where WP_商品表.id=WP_订单子表.商品id) as  品名 ");
                    sb.Append("\r\n ,(select  convert(varchar(50),下单时间,23)  as 下单时间  from  WP_订单表 where WP_订单表.订单编号=WP_订单子表.订单编号)  as 下单时间 ");
                    sb.Append("\r\n   from [dbo].[WP_订单子表] ");
                    sb.Append("\r\n where 订单编号='" + dt.Rows[i]["订单编号"] + "' ");

                    StringBuilder sbsql = new StringBuilder();
                    sbsql.Append("\r\n     select * from  (select  订单编号,价格,数量 ,(select top 1 图片路径 from [dbo].[TM_商品图片表]  ");
                    sbsql.Append("\r\n where 商品编号=(select 编号  from TM_商品表 where TM_商品表.id=TM_订单子表.商品id) order by 序号 desc) as  商品图片");
                    sbsql.Append("\r\n ,(select top 1 品名 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)+(select top 1 规格 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id) as  品名  ");
                    sbsql.Append("\r\n     ,(select  convert(varchar(50),下单时间,23)  as 下单时间  from  TM_订单表 where TM_订单表.订单编号=TM_订单子表.订单编号)  as 下单时间    ");
                    sbsql.Append("\r\n     ,(select [state] from    [dbo].[TM_订单表] where   TM_订单表.订单编号  = TM_订单子表.订单编号 ) as 订单状态   ");
                    sbsql.Append("\r\n     from [dbo].[TM_订单子表] ) t    ");
                    sbsql.Append("\r\n     where 订单编号='" + dt.Rows[i]["订单编号"] + "' ");
                    DataTable dorder = comfun.GetDataTableBySQL(sbsql.ToString());
                    for (int j = 0; j < dorder.Rows.Count; j++)
                    {
                        if (j == 0)
                        {
                            sbhtml.Append("\r\n               <tr class='sep-row'>                                                                                                          ");
                            sbhtml.Append("\r\n                 <td colspan='5'></td>                                                                                                       ");
                            sbhtml.Append("\r\n               </tr>                                                                                                                         ");
                            sbhtml.Append("\r\n               <tr class='tr-th'>                                                                                                            ");
                            sbhtml.Append("\r\n                 <td colspan='5'><span class='gap'></span> <span class='dealtime' title='" + dt.Rows[i]["下单时间"].ToString() + "'>" + dt.Rows[i]["下单时间"].ToString() + "</span>     ");
                            sbhtml.Append("\r\n                   <input type='hidden' id='datasubmit-15294420605' value='2016-04-13 10:00:46'>                                                                                                   ");
                            sbhtml.Append("\r\n                   <span class='number'>订单号：<a name='orderIdLinks' id='idUrl15294420605' target='_blank' href='#' clstag='click|keycount|orderinfo|order_num'>" + dt.Rows[i]["订单编号"].ToString() + "</a> </span></td>  ");
                            sbhtml.Append("\r\n               </tr>                                                                                                                                                                               ");
                            sbhtml.Append("\r\n               <tr class='tr-bd' id='track15294420605' oty='22,4,70'>                                                                        ");
                            sbhtml.Append("\r\n                 <td><div class='goods-item p-10150917494'>                                                                                  ");
                            sbhtml.Append("\r\n                     <div class='p-img'> <a href='#' clstag='click|keycount|orderinfo|order_product' target='_blank'>");
                            sbhtml.Append("  <img class='' src='" + dorder.Rows[j]["商品图片"] + "' data-lazy-img='done' width='60' height='60'> </a> </div>         ");
                            sbhtml.Append("\r\n                     <div class='p-msg'>                                                                                                           ");
                            sbhtml.Append("\r\n                     <div class='p-name'> " + dorder.Rows[j]["品名"] + "</div> ");
                            sbhtml.Append("\r\n                   </div>                                                                                                                                                ");
                            sbhtml.Append("\r\n                   </div>                                                                                         ");
                            sbhtml.Append("\r\n                   <div class='goods-number'> x1 </div>                                                           ");
                            sbhtml.Append("\r\n                   <div class='goods-repair'> </div>                                                              ");
                            sbhtml.Append("\r\n                   <div class='clr'></div></td>                                                                   ");
                            sbhtml.Append("\r\n                 <td rowspan='" + dorder.Rows.Count + "'><div class='consignee tooltip'> <span class='txt'>" + dt.Rows[i]["收货人"].ToString() + "</span><b></b>                                ");
                            sbhtml.Append("\r\n                   </div></td>                                                                                                         ");
                            sbhtml.Append("\r\n                 <td rowspan='" + dorder.Rows.Count + "'><div class='amount'> <span>总额 ￥" + dt.Rows[i]["总金额"].ToString() + "</span> <br>                                                  ");
                            sbhtml.Append("\r\n                     <strong>应付</strong> <br>                                                                                        ");
                            sbhtml.Append("\r\n                     <strong>￥" + dt.Rows[i]["应付金额"].ToString() + "</strong> <br>                                                                                    ");
                            sbhtml.Append("\r\n                     <span class='ftx-13'>在线支付</span> </div></td>                                                                  ");
                            sbhtml.Append("\r\n                 <td rowspan='" + dorder.Rows.Count + "'><div class='status'> <span class='order-status ftx-04'> " + dt.Rows[i]["状态"].ToString() + " </span> <br>                         ");
                            sbhtml.Append("\r\n                     <a href='OederStatus.aspx?id=" + dt.Rows[i]["订单编号"].ToString() + "' clstag='click|keycountorderlisttdingdanxiangqing'rstarget='_blank'>订单详情</a> </div></td>            ");
                            sbhtml.Append("\r\n               </tr>                                                                                                                   ");
                        }
                        if (j > 0)
                        {
                            sbhtml.Append("\r\n               <tr class='tr-bd' id='track15294420605' oty='22,4,70'>                                                                        ");
                            sbhtml.Append("\r\n                 <td><div class='goods-item p-10150917494'>                                                                                  ");
                            sbhtml.Append("\r\n                     <div class='p-img'> <a href='#' clstag='click|keycount|orderinfo|order_product' target='_blank'>");
                            sbhtml.Append("  <img class='' src='" + dorder.Rows[j]["商品图片"] + "' data-lazy-img='done' width='60' height='60'> </a> </div>         ");
                            sbhtml.Append("\r\n                     <div class='p-msg'>                                                                                                           ");
                            sbhtml.Append("\r\n                     <div class='p-name'><a href='#' class='a-link' clstag='click|keycount|orderinfo|order_product' target='_blank'>" + dorder.Rows[j]["品名"] + "</a></div> ");
                            sbhtml.Append("\r\n                   </div>                                                                                                                                                ");
                            sbhtml.Append("\r\n                   </div>                                                                                         ");
                            sbhtml.Append("\r\n                   <div class='goods-number'> x1 </div>                                                           ");
                            sbhtml.Append("\r\n                   <div class='goods-repair'> </div>                                                              ");
                            sbhtml.Append("\r\n                   <div class='clr'></div></td>                                                                   ");
                            sbhtml.Append("\r\n               </tr>                                                                                                                   ");
                        }
                    }
                }
                sbhtml.Append("\r\n             </tbody>                                           ");
            }
           return  sbhtml.ToString();
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