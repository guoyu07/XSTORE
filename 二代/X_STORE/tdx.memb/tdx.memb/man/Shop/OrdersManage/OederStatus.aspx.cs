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
using DTcms.DBUtility;

namespace tdx.memb.man.Shop.OrdersManage
{
    public partial class OederStatus : System.Web.UI.Page
    {
        public string 订单编号, 总金额, 运费, 应付款, 优惠券, 优惠总金额, 余额, 状态, 收货地址, 手机号, 收货人;
        protected void Page_Load(object sender, EventArgs e)
        {
              订单编号 = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                StringBuilder sb=new StringBuilder();
                //sb.Append(" select  WP_订单表.订单编号,总金额,[state] as 状态, 省+','+市+','+区+','+商圈+','+详细地址 as 收货地址 ,手机号,收货人 ");
                //sb.Append("\r\n from  [dbo].[WP_订单表] left join WP_订单地址表 on  WP_订单地址表.订单编号= WP_订单表.订单编号 ");
                sb.Append(" \r\n select WP_订单表.订单编号,总金额,运费,应付款,[state] as 状态 ,手机号,收货人,                                                                      ");
                sb.Append(" \r\n isnull(省,'')+','+isnull(市,'')+','+isnull(区,'')+','+isnull(商圈,'')+','+isnull(详细地址,'') as 收货地址                             ");
                sb.Append(" \r\n from  WP_订单表 left  join WP_地址表 on WP_订单表.订单编号 =WP_地址表.订单编号 left  join WP_订单地址表 on WP_订单地址表.id=地址ID  where WP_订单表.订单编号='" + 订单编号 + "'  ");        
                DataTable dt = comfun.GetDataTableBySQL(sb.ToString());
                if (dt != null&&dt.Rows.Count>0)
                {
                    订单编号 = dt.Rows[0]["订单编号"] != null ? dt.Rows[0]["订单编号"].ToString() : "";
                    总金额 = dt.Rows[0]["总金额"] != null ? dt.Rows[0]["总金额"].ToString() : "";
                    运费 = dt.Rows[0]["运费"] != null ? dt.Rows[0]["运费"].ToString() : "";
                    应付款 = dt.Rows[0]["应付款"] != null ? dt.Rows[0]["应付款"].ToString() : "";
                    优惠券 = GetYouHuiQuan(订单编号);
                    优惠总金额 = GetYouHuiZongE(订单编号);
                    余额 = GetYue(订单编号);
                    状态 = dt.Rows[0]["状态"] != null ? dt.Rows[0]["状态"].ToString() : "";
                    收货地址 = dt.Rows[0]["收货地址"] != null ? dt.Rows[0]["收货地址"].ToString() : "";
                    手机号 = dt.Rows[0]["手机号"] != null ? dt.Rows[0]["手机号"].ToString() : "";
                    收货人 = dt.Rows[0]["收货人"] != null ? dt.Rows[0]["收货人"].ToString() : "";
                    loadInfo();
                    if (状态 == "已支付"||状态 == "已发货"||状态 == "已完成")
                    {
                        DataTable dts1=comfun.GetDataTableBySQL("select top 1 支付时间 from [dbo].[WP_订单支付表] where 订单编号='"+订单编号+"'");
                        if (dts1.Rows.Count>0)
	                    {
		                    if (!Convert.IsDBNull(dts1.Rows[0][0]))
	                        {
                                支付时间.Text = "支付时间：" + dts1.Rows[0][0].ToString();
	                        }
	                    }

                    }

                }
        }

        public string GetYouHuiQuan(string _订单编号)
        {
            string a = "0.00";
            DataTable dt = DbHelperSQL.Query("  select isnull(sum(b.q_money),0) from  [TM_quan_mem_log] a left join  [TM_Quan_mem] c on a.qmid=c.id left join  [TM_Quan] b on b.id=c.qid where a.orderNo='" + _订单编号 + "' ")
                .Tables[0];
            if (dt.Rows.Count > 0)
            {
                a = Utils.ObjToDecimal(dt.Rows[0][0], 0).ToString("f2");
            }
            return a;
        }

        public string GetYouHuiZongE(string _订单编号)
        {
            string a = "0.00";
            decimal t = 0;
            DataTable dt = DbHelperSQL.Query(" select isnull(sum(b.j_Dmoney),0) from  [TM_Jian_log] a left join  [TM_Jian] b on a.jid=b.id where a.orderNo='" + _订单编号 + "'")
                .Tables[0];
            if (dt.Rows.Count > 0)
            {
                string p1 = GetYouHuiQuan(_订单编号);
                t = Utils.StrToDecimal(p1, 0);
                a = (Utils.ObjToDecimal(dt.Rows[0][0], 0) + t).ToString("f2");
            }
            else
            {
                a = GetYouHuiQuan(_订单编号);
            }
            return a;
        }

        public string GetYue(string _订单编号)
        {
            string a = "0.00";
            DataTable dt = DbHelperSQL.Query("  select isnull(sum(ac_money),0) from B2C_Account where orderNo='" + _订单编号 + "' and cno='017' ")
                .Tables[0];
            if (dt.Rows.Count > 0)
            {
                a = Utils.ObjectToStr(dt.Rows[0][0]);
            }
            return a;
        }


        private void loadInfo()
        {
            订单编号 = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (!string.IsNullOrEmpty(订单编号))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\r\n select 商品id,订单编号,价格,数量 ,(select top 1 图片路径 from [dbo].[WP_商品图片表] where 商品编号=(select 编号  from WP_商品表 where WP_商品表.id=WP_订单子表.商品id) order by 序号 desc) as  商品图片    ");
                sb.Append("\r\n ,(select top 1 品名 from  WP_商品表 where WP_商品表.id=WP_订单子表.商品id)+'('+(select top 1 规格 from  WP_商品表 where WP_商品表.id=WP_订单子表.商品id)+')' as  品名 ");
                sb.Append("\r\n ,(select top 1 编号new from  WP_商品表 where WP_商品表.id=WP_订单子表.商品id) as  编号new ");
                sb.Append("\r\n ,(select  convert(varchar(50),下单时间,23)  as 下单时间  from  WP_订单表 where WP_订单表.订单编号=WP_订单子表.订单编号)  as 下单时间 ");
                sb.Append("\r\n   from [dbo].[WP_订单子表] ");
                sb.Append("\r\n where 订单编号='" + 订单编号 + "' ");
                DataTable dorder = comfun.GetDataTableBySQL(sb.ToString());
                StringBuilder sbhtml = new StringBuilder();
                for (int j = 0; j < dorder.Rows.Count; j++)
                {
                    sbhtml.Append("\r\n                    ");

                    sbhtml.Append("\r\n            <tr>                                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n      <td>" + dorder.Rows[j]["编号new"] + "</td>                                                                                                                                                                                                                                ");
                    sbhtml.Append("\r\n                                                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n      <td>                                                                                                                                                                                                                                                ");
                    sbhtml.Append("\r\n          <div class='img-list'>                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n              <a class='img-box' target='_blank' href='#'>                                                                                                                                                              ");
                    sbhtml.Append("\r\n                  <img width='50' height='50' src='" + dorder.Rows[j]["商品图片"] + "' title=''>                                                                                       ");
                    sbhtml.Append("\r\n              </a>                                                                                                                                                                                                                                        ");
                    sbhtml.Append("\r\n          </div>                                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n      </td>                                                                                                                                                                                                                                               ");
                    sbhtml.Append("\r\n                                                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n      <td>                                                                                                                                                                                                                                                ");
                    sbhtml.Append("\r\n 		<div class='al fl'>                                                                                                                                                                                                                             ");
                    sbhtml.Append("\r\n 		<a class='flk13' target='_blank' onclick=\"window.open('/shop/chanpin.aspx?gid=" + dorder.Rows[j]["商品id"] + "&WHC=123', '', 'height=543,width=376,scrollbars=yes,status=yes');\" clstag='click|keycount|orderinfo|product_name'>" + dorder.Rows[j]["品名"] + " </a>                                        ");
                    sbhtml.Append("\r\n 		          </div>                                                                                                                                                                                                                                ");
                    sbhtml.Append("\r\n        <div class='clr'></div>                                                                                                                                                                                                                           ");
                    sbhtml.Append("\r\n        <div id='coupon_10150917494' class='fl'></div>                                                                                                                                                                                                    ");
                    sbhtml.Append("\r\n 	</td>                                                                                                                                                                                                                                               ");
                    sbhtml.Append("\r\n                                                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n      <td><span class='ftx04'> ￥" + dorder.Rows[j]["价格"] + "</span></td>                                                                                                                                                                                                        ");
                    sbhtml.Append("\r\n                                                                                                                                                                                                                                                          ");
                    //sbhtml.Append("\r\n      <td id='jingdou-10150917494'>0</td>                                                                                                                                                                                                                 ");
                    sbhtml.Append("\r\n      <td>" + dorder.Rows[j]["数量"] + "</td>                                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n                                                                                                                                                                                                                                                          ");
                    sbhtml.Append("\r\n                <td>                                                                                                                                                                                                                                      ");
                    sbhtml.Append("\r\n       <!-- 根据订单类型屏蔽pop延保商品操作,只显示评价 -->                                                                                                                                                                                                ");
                    sbhtml.Append("\r\n                 	有货              ");
                    sbhtml.Append("\r\n                  </td>     </tr>          ");

                }
                orderdetail.Text = sbhtml.ToString();
            }
        }
    }
}