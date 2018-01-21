using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace tdx.memb.man.tuan.OrdersManage
{
    public partial class OrderListNew : System.Web.UI.Page
    {
        public string currenturl;
        private string where = "";

        public int all = 0;
        public int topay = 0;
        public int tosend = 0;
        public int hadsend = 0;
        public int finish = 0;
        public int cancel = 0;

        public int daituikuan = 0;
        public int tuikuanwancheng = 0;
        public int tuikuanshibai = 0;



        protected void Page_Load(object sender, EventArgs e)
        {
            this.ordertype.Value = Request.QueryString["ordertype"] == null ? "" : Request.QueryString["ordertype"].ToString();
            string opid = string.IsNullOrEmpty(Request["openid"]) ? "0" : Request["openid"];

            currenturl = "./OrderListNew.aspx";
            //StringBuilder sbsql = new StringBuilder();
            //sbsql.Append("\r\n   select * from                                                                          ");
            //sbsql.Append("\r\n     (select count(1) as 全部  from  [dbo].[TM_订单表]  ) as 全部                         ");
            //sbsql.Append("\r\n   ,(select count(1) as 未支付 from  [dbo].[TM_订单表] where [state]='未支付') as 未支付  ");
            //sbsql.Append("\r\n   ,(select count(1) as 待发货 from  [dbo].[TM_订单表] where [state]='已支付') as 待发货  ");
            //sbsql.Append("\r\n   ,(select count(1) as 已发货 from  [dbo].[TM_订单表] where [state]='已发货') as 已发货  ");
            //sbsql.Append("\r\n   ,(select count(1) as 已完成 from  [dbo].[TM_订单表] where [state]='已完成') as 已完成  ");
            //sbsql.Append("\r\n   ,(select count(1) as 已取消 from  [dbo].[TM_订单表] where [state]='已取消') as 已取消  ");

            //sbsql.Append("\r\n   ,(select count(1) as 退款中 from  [dbo].[TM_订单表] where [state]='退款中') as 退款中  ");
            //sbsql.Append("\r\n   ,(select count(1) as 退款成功 from  [dbo].[TM_订单表] where [state]='退款成功') as 退款成功  ");
            ////sbsql.Append("\r\n   ,(select count(1) as 退款失败 from  [dbo].[TM_订单表] where [state]='退款失败') as 退款失败  ");

            //DataTable dtnumbers = comfun.GetDataTableBySQL(sbsql.ToString());
            //if (dtnumbers != null && dtnumbers.Rows.Count > 0)
            //{
            //    all = dtnumbers.Rows[0]["全部"] == null ? 0 : (int)dtnumbers.Rows[0]["全部"];
            //    topay = dtnumbers.Rows[0]["未支付"] == null ? 0 : (int)dtnumbers.Rows[0]["未支付"];
            //    tosend = dtnumbers.Rows[0]["待发货"] == null ? 0 : (int)dtnumbers.Rows[0]["待发货"];
            //    hadsend = dtnumbers.Rows[0]["已发货"] == null ? 0 : (int)dtnumbers.Rows[0]["已发货"];
            //    finish = dtnumbers.Rows[0]["已完成"] == null ? 0 : (int)dtnumbers.Rows[0]["已完成"];
            //    cancel = dtnumbers.Rows[0]["已取消"] == null ? 0 : (int)dtnumbers.Rows[0]["已取消"];

            //    daituikuan = dtnumbers.Rows[0]["退款中"] == null ? 0 : (int)dtnumbers.Rows[0]["退款中"];
            //    tuikuanwancheng = dtnumbers.Rows[0]["退款成功"] == null ? 0 : (int)dtnumbers.Rows[0]["退款成功"];
            //    //tuikuanshibai = dtnumbers.Rows[0]["退款失败"] == null ? 0 : (int)dtnumbers.Rows[0]["退款失败"];
            //}
            loadinfo(opid);
            // }
        }
        private void loadinfo(string opid)
        {
            string starttime = this.txt_start.Value;
            string endtime = this.txt_end.Value;
            string shouhuo = this.txt_下单人.Text;
            string code = this.txt_订单号.Text;
            string wherenew = " ";
            if (!string.IsNullOrEmpty(starttime))
                wherenew += " and 下单时间 >'" + starttime + "'";
            if (!string.IsNullOrEmpty(endtime))
                wherenew += " and 下单时间 <'" + endtime + "'";
            //if (!string.IsNullOrEmpty(shouhuo))
            //    wherenew += "  and  下单人 like '%" + shouhuo + "%' ";
            if (!string.IsNullOrEmpty(code))
                wherenew += " and  订单编号 ='" + code + "'   ";

            StringBuilder sbsql_total = new StringBuilder();
            sbsql_total.Append("\r\n   select * from                                                                          ");
            sbsql_total.Append("\r\n     (select count(1) as 全部  from  [dbo].[TM_订单表] where 1=1  " + wherenew + " ) as 全部                         ");
            sbsql_total.Append("\r\n   ,(select count(1) as 未支付 from  [dbo].[TM_订单表] where [state]='未支付' " + wherenew + ") as 未支付  ");
            sbsql_total.Append("\r\n   ,(select count(1) as 待发货 from  [dbo].[TM_订单表] where [state]='已支付' " + wherenew + ") as 待发货  ");
            sbsql_total.Append("\r\n   ,(select count(1) as 已发货 from  [dbo].[TM_订单表] where [state]='已发货' " + wherenew + ") as 已发货  ");
            sbsql_total.Append("\r\n   ,(select count(1) as 已完成 from  [dbo].[TM_订单表] where [state]='已完成' " + wherenew + ") as 已完成  ");
            sbsql_total.Append("\r\n   ,(select count(1) as 已取消 from  [dbo].[TM_订单表] where [state]='已取消' " + wherenew + ") as 已取消  ");

            sbsql_total.Append("\r\n   ,(select count(1) as 退款中 from  [dbo].[TM_订单表] where [state]='退款中' " + wherenew + ") as 退款中  ");
            sbsql_total.Append("\r\n   ,(select count(1) as 退款成功 from  [dbo].[TM_订单表] where [state]='退款成功' " + wherenew + ") as 退款成功  ");
            //sbsql.Append("\r\n   ,(select count(1) as 退款失败 from  [dbo].[WP_订单表] where [state]='退款失败') as 退款失败  ");

            DataTable dtnumbers = comfun.GetDataTableBySQL(sbsql_total.ToString());
            if (dtnumbers != null && dtnumbers.Rows.Count > 0)
            {
                all = dtnumbers.Rows[0]["全部"] == null ? 0 : (int)dtnumbers.Rows[0]["全部"];
                topay = dtnumbers.Rows[0]["未支付"] == null ? 0 : (int)dtnumbers.Rows[0]["未支付"];
                tosend = dtnumbers.Rows[0]["待发货"] == null ? 0 : (int)dtnumbers.Rows[0]["待发货"];
                hadsend = dtnumbers.Rows[0]["已发货"] == null ? 0 : (int)dtnumbers.Rows[0]["已发货"];
                finish = dtnumbers.Rows[0]["已完成"] == null ? 0 : (int)dtnumbers.Rows[0]["已完成"];
                cancel = dtnumbers.Rows[0]["已取消"] == null ? 0 : (int)dtnumbers.Rows[0]["已取消"];

                daituikuan = dtnumbers.Rows[0]["退款中"] == null ? 0 : (int)dtnumbers.Rows[0]["退款中"];
                tuikuanwancheng = dtnumbers.Rows[0]["退款成功"] == null ? 0 : (int)dtnumbers.Rows[0]["退款成功"];
                //tuikuanshibai = dtnumbers.Rows[0]["退款失败"] == null ? 0 : (int)dtnumbers.Rows[0]["退款失败"];
            }


            int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
            StringBuilder sbhtml = new StringBuilder();
            string orderstate = Request.QueryString["ordertype"] == null ? "" : Request.QueryString["ordertype"].ToString();
            StringBuilder sborder = new StringBuilder();
            sborder.Append("\r\n select * from  (select ROW_NUMBER() over (order by  id desc)  as rownum,t1.* from  (select   id  ");
            sborder.Append("\r\n ,订单编号,总金额,应付款  as  应付金额,[state] as 状态,物流公司,物流单号,下单时间 , 运费 ");
            sborder.Append("\r\n ,(select 收货人 from [dbo].[WP_订单地址表] where id in (select 地址id from WP_地址表 where WP_地址表.订单编号=TM_订单表.订单编号) ) as 收货人 from   TM_订单表 " + (string.IsNullOrEmpty(orderstate) ? "" : "where state='" + orderstate + "' ") + ") t1  left join  ");
            sborder.Append("\r\n ( select 订单编号,  sum(支付金额) as  优惠金额 from [dbo].[TM_订单支付表] where 支付方式!='微信' and 支付方式!='支付宝' group by 订单编号) t2 ");
            sborder.Append("\r\n on t1.订单编号=t2.订单编号 " + where + ") t3 where rownum  between  " + ((_page - 1) * 10 + 1) + " and " + _page * 10 + "  ");
            DataTable dt = comfun.GetDataTableBySQL(sborder.ToString());
            if (dt.Rows.Count > 0)
            {
                sbhtml.Append("\r\n  <tbody id='tb-15294420605'>                                                                                                          ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("\r\n select 订单编号,价格,数量 ,(select top 1 图片路径 from [dbo].[TM_商品图片表]     ");
                    sb.Append("\r\n where 商品编号=(select 编号  from TM_商品表 where TM_商品表.id=TM_订单子表.商品id) order by 序号 desc) as  商品图片 ");
                    sb.Append("\r\n ,(select top 1 品名 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)+'('+(select top 1 规格 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)+')' as  品名 ");
                    sb.Append("\r\n ,(select  convert(varchar(50),下单时间,23)  as 下单时间  from  TM_订单表 where TM_订单表.订单编号=TM_订单子表.订单编号)  as 下单时间 ");
                    sb.Append("\r\n   from [dbo].[TM_订单子表] ");
                    sb.Append("\r\n where 订单编号='" + dt.Rows[i]["订单编号"] + "' ");

                    StringBuilder sbsql = new StringBuilder();
                    sbsql.Append("\r\n     select * from  (select  订单编号,价格,数量 ,(select top 1 图片路径 from [dbo].[TM_商品图片表]  ");
                    sbsql.Append("\r\n where 商品编号=(select 编号  from TM_商品表 where TM_商品表.id=TM_订单子表.商品id) order by 序号 desc) as  商品图片");
                    sbsql.Append("\r\n ,(select top 1 编号new from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)+'-'+(select top 1 品名 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)+'('+(select top 1 规格 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)+')' as  品名  ");
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
                            sbhtml.Append("\r\n               <tr class='tr-bd' id='track15294420605' oty='22,4,70'>  <td rowspan='" + dorder.Rows.Count + "' style=\"width:10%px\" ><input class='multi' type='checkbox' value='" + dt.Rows[i]["订单编号"].ToString() + "'   /></td>                                                                      ");
                            sbhtml.Append("\r\n                 <td><div class='goods-item p-10150917494'>                                                                                  ");
                            sbhtml.Append("\r\n                     <div class='p-img'> <a href='#' clstag='click|keycount|orderinfo|order_product' target='_blank'>");
                            sbhtml.Append("  <img class='' src='" + dorder.Rows[j]["商品图片"] + "' data-lazy-img='done' width='60' height='60'> </a> </div>         ");
                            sbhtml.Append("\r\n                     <div class='p-msg'>                                                                                                           ");
                            sbhtml.Append("\r\n                     <div class='p-name'> " + dorder.Rows[j]["品名"] + "</div> ");
                            sbhtml.Append("\r\n                   </div>                                                                                                                                                ");
                            sbhtml.Append("\r\n                   </div>                                                                                         ");
                            sbhtml.Append("\r\n                   <div class='goods-number'> x " + dorder.Rows[j]["数量"] + " </div>                                                           ");
                            sbhtml.Append("\r\n                   <div class='goods-repair'> </div>                                                              ");
                            sbhtml.Append("\r\n                   <div class='clr'></div></td>                                                                   ");
                            sbhtml.Append("\r\n                 <td rowspan='" + dorder.Rows.Count + "'><div class='consignee tooltip'> <span class='txt'>" + dt.Rows[i]["收货人"].ToString() + "</span><b></b>                                ");
                            sbhtml.Append("\r\n                   </div></td>                                                                                                         ");
                            sbhtml.Append("\r\n                 <td rowspan='" + dorder.Rows.Count + "'><div class='amount'> <span>总额 ￥" + dt.Rows[i]["总金额"].ToString() + "</span> <br>                                                  ");
                            sbhtml.Append("\r\n                     <strong>应付</strong> <br>                                                                                        ");
                            sbhtml.Append("\r\n                     <strong>￥" + dt.Rows[i]["应付金额"].ToString() + "</strong> <br>                                                                                    ");
                            sbhtml.Append("\r\n                     <span>(含运费:" + dt.Rows[i]["运费"].ToString() + "元)</span> <br>                                                                                    ");
                            DataTable dt_real = comfun.GetDataTableBySQL("select * from WP_订单支付表 where 订单编号='" + dt.Rows[i]["订单编号"].ToString() + "' and 支付方式='微信' ");
                            if (dt_real.Rows.Count > 0)
                            {
                                sbhtml.Append("\r\n                  <span>实付 ￥" + dt_real.Rows[0]["支付金额"].ToString() + "</span> <br>                                                  ");
                            }
                            sbhtml.Append("\r\n                     <span class='ftx-13'>在线支付</span> </div></td>                                                                  ");
                            sbhtml.Append("\r\n                 <td rowspan='" + dorder.Rows.Count + "'><div class='status'> <span class='order-status ftx-04'> " + dt.Rows[i]["状态"].ToString() + " </span> <br>                         ");
                            sbhtml.Append("\r\n                     <a href='OederStatus.aspx?id=" + dt.Rows[i]["订单编号"].ToString() + "' clstag='click|keycountorderlisttdingdanxiangqing'rstarget='_blank'>订单详情</a> <span onclick='fahuo()'> </div>           ");
                            if (dt.Rows[i]["状态"].ToString() == "已支付")
                            {
                                sbhtml.Append("\r\n    <a href=\"../../PrintSheet/ShowPrintInfo.aspx?orderNO=" + dt.Rows[i]["订单编号"].ToString() + "&orderType=TM\" >打印订单</a><br/>");
                                sbhtml.Append("\r\n    <input type=button id=fahuo  value='发货' onclick=\"popupDiv('pop-div',this);\"/>");
                            }
                            if (dt.Rows[i]["状态"].ToString() == "未支付")
                            {
                                sbhtml.Append("\r\n    <input type=button id=fahuo  value='价格修改' onclick=\"popupDiv('popyunfei',this);\"/>");
                            }

                            if (dt.Rows[i]["状态"].ToString() == "已发货" || dt.Rows[i]["状态"].ToString() == "已完成")
                            {
                                //sbhtml.Append("\r\n    <input type=button id=wuliu  value='查看物流信息' onclick=\"popupDiv('pop-wuliu',this);\"/><br/>");
                                //Text1.Value = Utils.ObjectToStr(dt.Rows[i]["物流公司"]);//物流公司
                                //Text2.Value = Utils.ObjectToStr(dt.Rows[i]["物流单号"]);//物流单号

                                Text3.Value = Utils.ObjectToStr(dt.Rows[i]["物流公司"]);//物流公司
                                string gs = Utils.ObjectToStr(dt.Rows[i]["物流公司"]);//物流公司
                                Text4.Value = Utils.ObjectToStr(dt.Rows[i]["物流单号"]);//物流单号
                                string dh = Utils.ObjectToStr(dt.Rows[i]["物流单号"]);//物流单号
                                sbhtml.Append("\r\n    <input type=button id=wuliu  value='查看修改物流信息' onclick=\"popupDiv('pop-div1',this);\" gs=\"" + gs + "\" dh=\"" + dh + "\"/>");
                                Text3.Value = Utils.ObjectToStr(dt.Rows[i]["物流公司"]);//物流公司
                                Text4.Value = Utils.ObjectToStr(dt.Rows[i]["物流单号"]);//物流单号
                            }
                            if (dt.Rows[i]["状态"].ToString() == "退款中")
                            {
                                sbhtml.Append("\r\n    <input type=button id=\"tk\"  value='确认退款' onclick=\"tuikuan('" + dt.Rows[i]["订单编号"].ToString() + "')\"/>");
                            }
                            sbhtml.Append("\r\n    <input  class='yunfei'  type='hidden' value='" + dt.Rows[i]["运费"].ToString() + "' />");
                            sbhtml.Append("\r\n    <input  class='yingfu'  type='hidden' value='" + dt.Rows[i]["应付金额"].ToString() + "' />");
                            sbhtml.Append("\r\n    <input  class='bianhao' type='hidden' value='" + dt.Rows[i]["订单编号"].ToString() + "' </td>  ");
                            sbhtml.Append("\r\n               </tr>                                                                                                                   ");
                        }
                        if (j > 0)
                        {
                            sbhtml.Append("\r\n               <tr class='tr-bd' id='track15294420605' oty='22,4,70'>                                                                        ");
                            sbhtml.Append("\r\n                 <td><div class='goods-item p-10150917494'>                                                                                  ");
                            sbhtml.Append("\r\n                     <div class='p-img'> <a href='#' clstag='click|keycount|orderinfo|order_product' target='_blank'>");
                            sbhtml.Append("  <img class='' src='" + dorder.Rows[j]["商品图片"] + "' data-lazy-img='done' width='60' height='60'> </a> </div>         ");
                            sbhtml.Append("\r\n                     <div class='p-msg'>                                                                                                           ");
                            sbhtml.Append("\r\n                     <div class='p-name'>" + dorder.Rows[j]["品名"] + "</div> ");
                            sbhtml.Append("\r\n                   </div>                                                                                                                                                ");
                            sbhtml.Append("\r\n                   </div>                                                                                         ");
                            sbhtml.Append("\r\n                   <div class='goods-number'> x" + dorder.Rows[j]["数量"] + "  </div>                                                           ");
                            sbhtml.Append("\r\n                   <div class='goods-repair'> </div>                                                              ");
                            sbhtml.Append("\r\n                   <div class='clr'></div></td>                                                                   ");
                            sbhtml.Append("\r\n               </tr>                                                                                                                   ");
                        }
                    }

                }
                sbhtml.Append("\r\n             </tbody>                                           ");
            }
            this.orderinfo.Text = sbhtml.ToString();



            if (orderstate.Equals(""))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, all, 10, Request.Form, Request.QueryString);
            if (orderstate.Equals("未支付"))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, topay, 10, Request.Form, Request.QueryString);
            if (orderstate.Equals("已支付"))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, tosend, 10, Request.Form, Request.QueryString);
            if (orderstate.Equals("已发货"))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, hadsend, 10, Request.Form, Request.QueryString);
            if (orderstate.Equals("已完成"))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, finish, 10, Request.Form, Request.QueryString);
            if (orderstate.Equals("已取消"))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, cancel, 10, Request.Form, Request.QueryString);

            if (orderstate.Equals("退款中"))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, daituikuan, 10, Request.Form, Request.QueryString);
            if (orderstate.Equals("退款成功"))
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, tuikuanwancheng, 10, Request.Form, Request.QueryString);
            //if (orderstate.Equals("退款失败"))
            //    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, tuikuanshibai, 10, Request.Form, Request.QueryString);

        }

        protected void lbtn_Export_Click(object sender, EventArgs e)
        {
            string orderstate = Request.QueryString["ordertype"] == null ? "" : Request.QueryString["ordertype"].ToString();
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("\r\n     select 条形码,商品名称, 商品规格,sum(数量) as 总数量,订单状态 from  (select 数量,  ");
            sbsql.Append("\r\n     (select top 1 品名 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)  as  商品名称   ");
            sbsql.Append("\r\n     ,(select top 1 编号new from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)  as  条形码  ");
            sbsql.Append("\r\n     ,(select top 1 规格 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id)  as  商品规格 ");
            sbsql.Append("\r\n     ,(select [state] from    [dbo].[TM_订单表] where   TM_订单表.订单编号  = TM_订单子表.订单编号 ) as 订单状态    ");
            sbsql.Append("\r\n     from [dbo].[TM_订单子表])   t ");
            if (!string.IsNullOrEmpty(orderstate))
            {
                sbsql.Append("  where  订单状态 ='" + orderstate + "'    ");
            }
            sbsql.Append("group by  商品名称,数量,条形码,商品规格,订单状态 ");

            DataTable dorder = comfun.GetDataTableBySQL(sbsql.ToString());
            //DTcms.Common.Excel.DataTable4Excel(dorder, "订单信息");
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dorder, "订单信息");
        }

        protected void lbtn_ExpsortSum_Click(object sender, EventArgs e)
        {
            string orderstate = Request.QueryString["ordertype"] == null ? "" : Request.QueryString["ordertype"].ToString();
            string starttime = this.txt_start.Value;
            string endtime = this.txt_end.Value;
            string shouhuo = this.txt_下单人.Text;
            string code = this.txt_订单号.Text;
            string wherenew = "  where  ";
            string wherenew2 = " where  1=1 ";
            if (!string.IsNullOrEmpty(starttime))
                wherenew += " 下单时间 >'" + starttime + "'";
            else
                wherenew += " 1=1 ";
            if (!string.IsNullOrEmpty(endtime))
                wherenew += " and 下单时间 <'" + endtime + "'";
            else
                wherenew += "  and 1=1 ";
            if (!string.IsNullOrEmpty(shouhuo))
                wherenew2 += "  and  下单人 like '%" + shouhuo + "%' ";
            if (!string.IsNullOrEmpty(orderstate))
                wherenew += " and  订单状态 ='" + orderstate + "'   ";
            if (!string.IsNullOrEmpty(code))
                wherenew += " and  订单编号 ='" + code + "'   ";
            StringBuilder sbsql = new StringBuilder();

            sbsql.Append("\r\n  select  ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.订单编号 else NULL end as 订单编号, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.下单人 else NULL end as 下单人, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.下单时间 else NULL end as 下单时间, ");
            sbsql.Append("\r\n  下单时间 as 下单时间1, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.收货人 else NULL end as 收货人, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.手机号 else NULL end as 手机号, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.收货地址 else NULL end as 收货地址, ");
            sbsql.Append("\r\n  条形码,商品名称, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.备注 else NULL end as 备注, ");
            sbsql.Append("\r\n  规格,数量,单价, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.运费 else NULL end as 运费, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.订单金额 else NULL end as 订单金额, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.优惠金额 else NULL end as 优惠金额, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.订单总金额 else NULL end as 订单总金额, ");
            sbsql.Append("\r\n  订单状态, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.支付方式 else NULL end as 支付方式, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.支付金额 else NULL end as 支付金额, ");
            sbsql.Append("\r\n  case when t7.RN = 1 then t7.支付时间 else NULL end as 支付时间  ");
            sbsql.Append("\r\n  from ( ");
            sbsql.Append("\r\n      select ROW_NUMBER()OVER(PARTITION BY 下单时间   ORDER BY 下单时间 desc ) AS RN, t3.订单编号,下单人,下单时间,收货人,手机号,收货地址,条形码,商品名称,备注                                                                     ");
            sbsql.Append("\r\n      ,规格,数量,单价,运费,订单金额,订单总金额,订单状态,t6.支付方式,t6.支付金额,t6.支付时间 ,cast(isnull(优惠金额,0) as decimal(9,2))  as 优惠金额                                     ");
            sbsql.Append("\r\n      from                                                                                                                                         ");
            sbsql.Append("\r\n      (select  条形码,商品名称,规格,数量,订单编号,订单状态,单价,运费,优惠金额,订单金额,订单总金额,订单金额+运费-优惠金额 as 总支付金额                               ");
            sbsql.Append("\r\n      from  (                                                                                                                                      ");
            sbsql.Append("\r\n      select 商品名称,条形码,订单编号, 运费,单价,订单金额,订单总金额,订单状态,规格,优惠金额,数量 from                                               ");
            sbsql.Append("\r\n       	(select 数量,                                                                                                                                  ");
            sbsql.Append("\r\n       		(select top 1 品名 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id) as  商品名称 ,订单编号                                      ");
            sbsql.Append("\r\n       		,(select top 1 编号new from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id) as  条形码                                                   ");
            sbsql.Append("\r\n       		,(select top 1 规格 from  TM_商品表 where TM_商品表.id=TM_订单子表.商品id) as  规格                                                   ");
            sbsql.Append("\r\n       		,价格 as 单价,(select  运费  from TM_订单表 where TM_订单表.订单编号=TM_订单子表.订单编号) as 运费                                    ");
            sbsql.Append("\r\n       		,(select [state] from    [dbo].[TM_订单表] where   TM_订单表.订单编号  = TM_订单子表.订单编号 ) as 订单状态                           ");
            sbsql.Append("\r\n                ,(select 下单时间 from    [dbo].[TM_订单表] where   TM_订单表.订单编号  = TM_订单子表.订单编号 ) as 下单时间                        ");
            sbsql.Append("\r\n       		,(select  总金额  from TM_订单表 where TM_订单表.订单编号=TM_订单子表.订单编号) as 订单金额  ");
            sbsql.Append("\r\n       					,(select  应付款  from TM_订单表 where TM_订单表.订单编号=TM_订单子表.订单编号) as 订单总金额 ");
            sbsql.Append("\r\n      		,( select 优惠金额  from  (select isnull(sum(q_money),0) as 优惠金额,orderNo as 订单编号 from TM_quan_mem_log a left join TM_Quan_mem b on a.qmid=b.id left join TM_Quan c on b.qid=c.id group by orderNo) t where t.订单编号=TM_订单子表.订单编号) as 优惠金额          ");
            sbsql.Append("\r\n       		from [dbo].[TM_订单子表]                                                                                                              ");
            sbsql.Append("\r\n       	) t1    " + wherenew + "                                                                                                               ");
            sbsql.Append("\r\n       		group by  商品名称,数量,条形码,规格,单价,运费,订单金额,优惠金额,订单编号,订单状态,订单总金额                                                          ");
            sbsql.Append("\r\n      ) t2                                                                                                                                         ");
            sbsql.Append("\r\n      ) t3                                                                                                                                         ");
            sbsql.Append("\r\n      left join                                                                                                                                    ");
            sbsql.Append("\r\n      (select  TM_订单表.订单编号,t4.手机号,t4.收货人,t4.收货地址,下单时间,备注,'商品链接' as 商品链接,                                            ");
            sbsql.Append("\r\n      (select top 1 M_name from B2C_mem where openid=TM_订单表.openid) as 下单人                                                                   ");
            sbsql.Append("\r\n      from  [dbo].[TM_订单表]   left join                                                                                                          ");
            sbsql.Append("\r\n      (select   WP_地址表.订单编号, 手机号,收货人, 省+市+区+isnull(商圈,'')+详细地址 as 收货地址                                                   ");
            sbsql.Append("\r\n      from [dbo].[WP_订单地址表]  left join [dbo].[WP_地址表] on WP_订单地址表.id=WP_地址表.地址id                                                     ");
            sbsql.Append("\r\n      ) t4 on  TM_订单表.订单编号=t4.订单编号) t5                                                                                                  ");
            sbsql.Append("\r\n      on t5.订单编号=t3.订单编号                                                                                                                   ");
            sbsql.Append("\r\n      left join                                                                                                                                    ");
            sbsql.Append("\r\n      (                                                                                                                                            ");
            sbsql.Append("\r\n      select  订单编号,支付方式,支付金额 ,convert( varchar(50),支付时间,21) as 支付时间                                                            ");
            sbsql.Append("\r\n      from  TM_订单支付表          where  支付方式='微信' or 支付方式='支付宝'                                                                  ");
            sbsql.Append("\r\n      )t6 on t6.订单编号=t3.订单编号   " + wherenew2 + "     ) t7 order by 下单时间1 desc                                                                     ");
            DataTable dorder = comfun.GetDataTableBySQL(sbsql.ToString());
            dorder.Columns.Remove("下单时间1");
            //DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dorder, "订单管理导出");
            DTcms.Common.Excel.DataTable4Excel(dorder, "订单管理导出");
        }
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            where += "where ";
            string starttime = this.txt_start.Value;
            string endtime = this.txt_end.Value;
            string shouhuo = this.txt_下单人.Text;
            string code = this.txt_订单号.Text;
            if (!string.IsNullOrEmpty(starttime))
                where += " 下单时间 >'" + starttime + "'";
            else
                where += " 1=1 ";
            if (!string.IsNullOrEmpty(endtime))
                where += " and 下单时间 <'" + endtime + "'";
            else
                where += "  and 1=1 ";
            if (!string.IsNullOrEmpty(shouhuo))
                where += "  and  收货人 like '%" + shouhuo + "%' ";
            if (!string.IsNullOrEmpty(code))
                where += "  and  t1.订单编号 like '%" + code + "%' ";
            string opid = string.IsNullOrEmpty(Request["openid"]) ? "0" : Request["openid"];
            loadinfo(opid);
        }
    }
}