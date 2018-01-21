using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.DBUtility;
using Creatrue.kernel;
using tdx.Weixin;
using tdx.database.Common_Pay.WeiXinPay;
using DTcms.Common;
using Creatrue.Common.Msgbox;
namespace Wx_NewWeb.Shop.Buyer
{
    public partial class myself : BasePage
    {

        string no_img = "/shop/img/no-image.jpg";//默认图片
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
            }
            goods();
        }

        protected void goods()
        {
            try
            {
                string sql = @"select 总金额,商品id,品名,本站价,位置,支付时间,图片路径,state from WP_订单表 A
left join wp_订单支付表 B on A.订单编号=b.订单编号
left join wp_订单子表 c on A.订单编号=c.订单编号
left join wp_商品表 D on C.商品id=d.id
left join wp_商品图片表 E on d.编号=e.商品编号
where A.openid='" + OpenId + "'and state in(2,5) and A.下单时间 > dateadd(day,-1,getdate()) and 是否开箱 is null";
                DTcms.Common.Log.WriteLog("类：myself", "方法：goods", "sql:" + sql);
                DataTable dt = comfun.GetDataTableBySQL(sql);
                mac_input.Value = Session["boxmac"].ObjToStr();
                if (dt.Rows.Count > 0)
                {
                    order_lbl.InnerText = OpenId;
                    My_self.DataSource = dt;
                    My_self.DataBind();
                    has.Style["display"] = "block";
                    empty.Style["display"] = "none";
                    title.Style["display"] = "block";
                }
                else
                {
                    has.Style["display"] = "none";
                    empty.Style["display"] = "block";
                    title.Style["display"] = "none";
                }
            }
            catch (Exception ex)
            {
                DTcms.Common.Log.WriteLog("类：myself", "方法：goods", "异常信息:" + ex.Message+";异常位置："+ex.StackTrace);
                throw;
            }
           
        }

//        protected void open_all_Click(object sender, EventArgs e)
//        {
//            //   Log.WriteLog("openbo_ashx", "orderno", orderno);
//            //   string openid = HttpContext.Current.Session["OpenId"].ObjToStr();
//            if (Session["OpenId"] != null)
//            {
//                openid = Session["OpenId"].ToString();
//            }

//            string sql = @"select A.订单编号,总金额,商品id,品名,本站价,位置,支付时间 from WP_订单表 A
//left join wp_订单支付表 B on A.订单编号=b.订单编号
//left join wp_订单子表 c on A.订单编号=c.订单编号
//left join wp_商品表 D on C.商品id=d.id
//where A.openid='" + openid + "'and state=2 and 支付时间> DATEADD(MINUTE,-15,GETDATE())";
//            DataTable dt = comfun.GetDataTableBySQL(sql);
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                string sql_wz = @"select 商品id,订单编号,价格,数量,库位id,wp_订单子表.仓库id,位置,箱子mac from wp_订单子表
//left join WP_库位表 on WP_库位表.id=WP_订单子表.库位id
//where 订单编号='" + dt.Rows[i]["订单编号"].ObjToStr() + "'";
//                DataTable dt_wz = comfun.GetDataTableBySQL(sql_wz);
//                var rbh = new RemoteBoxHelperNew();
//                try
//                {
//                    for (int b = 0; b < dt_wz.Rows.Count; b++)
//                    {

//                        rbh.OpenRemoteBox("" + dt_wz.Rows[b]["箱子MAC"].ObjToStr() + "", "" + (dt_wz.Rows[b]["位置"].ObjToInt(0) - 1).ObjToStr() + "");
//                        tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("开箱循环", dt_wz.Rows[b]["箱子MAC"].ObjToStr(),"实际位置:"+ dt_wz.Rows[b]["位置"].ObjToStr());

//                        tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("开箱循环", "update wp_箱子表 set 实际商品id=0,售出时间=getdate()  where 库位id='" + dt_wz.Rows[b]["库位id"].ObjToStr() + "' and 箱子位置='" + (dt_wz.Rows[b]["位置"].ObjToInt(0) - 1) + "'", "-----------------------------------------");

//                        //开箱失败=5，已开箱=3,操作id dt_manager id=8
//                        //插入出库表 
//                        tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("开箱循环", "insert wp_出库表 (单据编号,商品id,数量,出价,总出价额,操作日期,库位id,位置,操作id,出库类型,IsShow) values('" + dt.Rows[i]["订单编号"].ObjToStr() + "','" + dt_wz.Rows[b]["商品id"] + "','" + dt_wz.Rows[b]["数量"] + "','" + dt_wz.Rows[b]["价格"] + "','" + dt_wz.Rows[b]["价格"] + "',getdate(),'" + dt_wz.Rows[b]["库位id"] + "','" + dt_wz.Rows[b]["位置"] + "',8,1,1)", "");
//                        comfun.InsertBySQL("insert wp_出库表 (单据编号,商品id,数量,出价,总出价额,操作日期,库位id,位置,操作id,出库类型,IsShow) values('" + dt.Rows[i]["订单编号"].ObjToStr() + "','" + dt_wz.Rows[b]["商品id"] + "','" + dt_wz.Rows[b]["数量"] + "','" + dt_wz.Rows[b]["价格"] + "','" + dt_wz.Rows[b]["价格"] + "',getdate(),'" + dt_wz.Rows[b]["库位id"] + "','" + dt_wz.Rows[b]["位置"] + "',8,1,1)");
//                        comfun.UpdateBySQL("update wp_箱子表 set 实际商品id=0,售出时间=getdate()  where 库位id='" + dt_wz.Rows[b]["库位id"].ObjToStr() + "' and 位置='" + dt_wz.Rows[b]["位置"].ObjToStr() + "'");//修改箱子状态
//                    }
//                    comfun.UpdateBySQL("update WP_订单表 set state=3 where state=2");
//                    MessageBox.ShowAndRedirect(this, "开箱成功！", "../buyer/myself.aspx");

//                }
//                catch
//                {
//                    comfun.UpdateBySQL("update WP_订单表 set state=5 where state=2");
//                    MessageBox.ShowAndRedirect(this, "开箱失败！请联系客服", "../buyer/myself.aspx");
//                }
//            }
//            goods();
//        }

//        protected void refund_Click(object sender, EventArgs e)
//        {
//            try
//            {
//            //    context.Response.ContentType = "text/plain";
//              //  string orderno = context.Request["orderno"].ToString();
//                if (Session["OpenId"] != null)
//                {
//                    openid = Session["OpenId"].ToString();
//                }
//                string sql = @"select A.订单编号,总金额,商品id,品名,本站价,位置,支付时间 from WP_订单表 A
//left join wp_订单支付表 B on A.订单编号=b.订单编号
//left join wp_订单子表 c on A.订单编号=c.订单编号
//left join wp_商品表 D on C.商品id=d.id
//where A.openid='" + openid + "'and state=2 and 支付时间> DATEADD(MINUTE,-15,GETDATE())";
//                DataTable dt_order = comfun.GetDataTableBySQL(sql);
//                for (int i = 0; i < dt_order.Rows.Count; i++)
//                {
//                    DTcms.Common.Log.WriteLog("orderno", dt_order.Rows[i]["订单编号"].ObjToStr(), "-----");
//                    DataTable dt = comfun.GetDataTableBySQL("select top 1 a.out_trade_no,b.应付款,a.订单编号 from  dbo.WP_订单支付表 a ,  WP_订单表  b where 1=1  and a.订单编号='" + dt_order.Rows[i]["订单编号"].ObjToStr() + "' and a.订单编号=b.订单编号");
//                    //微信付款数据
//                    DTcms.Common.Log.WriteLog("是否存在订单", dt.Rows.Count.ToString(), "-----");
//                    if (dt.Rows.Count > 0)
//                    {
//                        DTcms.Common.Log.WriteLog("out_trade_no", dt.Rows[0]["out_trade_no"].ToString(), "-----");
//                        DTcms.Common.Log.WriteLog("out_refund_no", dt.Rows[0]["订单编号"].ToString(), "-----");
//                        DTcms.Common.Log.WriteLog("total_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100).ToString(), "-----");
//                        DTcms.Common.Log.WriteLog("refund_fee", "", "-----");
//                        DTcms.Common.Log.WriteLog("op_user_id", WxPayConfig.MCHID, "-----");
//                        WxPayData payData = new WxPayData();
//                        payData.SetValue("out_trade_no", dt.Rows[0]["out_trade_no"].ToString());
//                        payData.SetValue("out_refund_no", dt.Rows[0]["订单编号"].ToString());
//                        payData.SetValue("total_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100));
//                        payData.SetValue("refund_fee", Convert.ToInt32(Utils.ObjToDecimal(dt.Rows[0]["应付款"].ToString(), 0) * 100));
//                        //操作员ID,默认商户号
//                        //payData.SetValue("op_user_id", "1340586301");
//                        payData.SetValue("op_user_id", WxPayConfig.MCHID);
//                        //返回订单结果
//                        WxPayData unifiedOrderResult = WxPayApi.Refund(payData);
//                        string result = unifiedOrderResult.GetValue("result_code").ToString();
//                        //Log.WriteLog("tuikuan", result, "数据异常");

//                        DTcms.Common.Log.WriteLog("返回结果", result, "-----");
//                        //Log.WriteLog("", "", result);
//                        if (result == "SUCCESS")
//                        {
//                            comfun.UpdateBySQL("update WP_订单表 set state='7' where 订单编号='" + dt_order.Rows[i]["订单编号"].ObjToStr() + "'");
//                          //  context.Response.Write("退款成功");
//                            tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("退款成功", "退款成功", "退款成功");
//                        }
//                        else
//                        {
//                          //  context.Response.Write("退款失败");
//                            tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("退款失败", "退款失败", "退款失败");
//                        }
//                    }
//                }
//                MessageBox.ShowAndRedirect(this, "退款成功！", "../buyer/myself.aspx");
//                goods();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.ShowAndRedirect(this, "退款失败！请联系客服", "../buyer/myself.aspx");
//                DTcms.Common.Log.WriteLog("tuikuan", ex.Message, "数据异常");
//            }
            
//        }
    }
}