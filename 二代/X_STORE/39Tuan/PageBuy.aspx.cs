using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using WxPayAPI;
using DTcms.DBUtility;
using System.Collections;

namespace Tuan
{
    public partial class PageBuy : System.Web.UI.Page
    {
        public string sjdz = "";
        public string title = "";
        public decimal price = 0;
        public string pic = "";
        public string ddbh = "";//订单编号
        public string spinfo = "";
        public static string wxJsApiParam { get; set; } //H5调起JS API参数
        public string pinopen = "";
        public string spbh = "";
        public string otheropenid = "";
        public string otherddbh = "";
        public string signature = "";
        public string timestamp = "";
        public string nonceStr = "";
        public string appid = "";
        public string picurl = "";
        public string unionid = "";

        public string lx = "";
        public int wxid = 0;


        protected void Page_Load(object sender, EventArgs e)
        {

            otheropenid = Request["otheropenid"].ToString();
            otherddbh = Request["otherddbh"].ToString();

            if (Request["ddbh"] != null && Request["openid"] != null && Request["price"] != null)
            {
                ddbh = Request["ddbh"].ToString();
                Session["wxddbh"] = ddbh;
                pinopen = Request.QueryString["openid"];
                #region 微信支付
                string openid = Request.QueryString["openid"];
                openid = "oSx_vssL7Ar0ycjvLlpOcIuVK0gc";//c测试用户。
                unionid = Request["unionid"].ToString();
                dizhi(Request["unionid"].ToString());
                string total_fee = Request.QueryString["price"];
                //检测是否给当前页面传递了相关参数
                if (string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(total_fee))
                {
                    Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面传参出错,请返回重试" + "</span>");

                    //submit = false;
                    return;
                }

                //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
                JsApiPay jsApiPay = new JsApiPay(this);
                jsApiPay.openid = openid;
                jsApiPay.total_fee = int.Parse(total_fee);
                // mon =Convert.ToInt32(money.Value);
                //JSAPI支付预处理
                try
                {

                    #region 获取页面信息
                    DataTable dtspbh = comfun.GetDataTableBySQL("select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and a.订单编号='" + Request["ddbh"].ToString() + "'");
                    if (dtspbh.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtspbh.Rows.Count; i++)
                        {
                            spbh = dtspbh.Rows[i]["商品编号"].ToString(); 

                            DataTable dtsp = comfun.GetDataTableBySQL("select b.wxid as 微信ID,* from TM_商品表 a,dt_manager b,wx_mp c where a.用户ID=b.id and b.wxid=c.id and 编号='" + dtspbh.Rows[i]["商品编号"].ToString() + "'");
                            if (dtsp.Rows.Count > 0)
                            {
                                lx = dtsp.Rows[0]["类型"].ToString();
                                if (i == 0)
                                {
                                    //Chat chat = new Chat();
                                    //chat.wxid = Convert.ToInt32(dtsp.Rows[0]["微信ID"].ToString());
                                    //wxid = Convert.ToInt32(dtsp.Rows[0]["微信ID"].ToString());
                                    //appid = chat.appid();
                                    //WXJSSDK jssdk = new WXJSSDK(chat.appid(), chat.secret());
                                    //Hashtable hs = jssdk.getSignPackage();
                                    //signature = hs["signature"].ToString();
                                    //timestamp = hs["timestamp"].ToString();
                                    //nonceStr = hs["nonceStr"].ToString();



                                    DataTable dtsj = comfun.GetDataTableBySQL("select * from dt_manager where id=" + Convert.ToInt32(dtsp.Rows[0]["用户ID"]) + "");
                                    if (dtsj.Rows.Count > 0)
                                    {
                                        sjdz = dtsj.Rows[0]["address"].ToString();
                                    }

                                }


                                price = Convert.ToDecimal(Request["price"].ToString()) / 100;
                                DataTable dtpic = comfun.GetDataTableBySQL("select top 1* from TM_商品图片表 where 商品编号='" + dtspbh.Rows[i]["商品编号"].ToString() + "'");
                                if (dtpic.Rows.Count > 0)
                                {
                                    picurl = dtpic.Rows[0]["图片路径"].ToString();
                                    pic = "<img src='" + dtpic.Rows[0]["图片路径"].ToString() + "' width='120'/>";
                                }
                                else
                                {

                                    pic = "<li><img src='images/03.jpg'></li>";   //没有图片
                                }
                                title = dtsp.Rows[0]["品名"].ToString();
                                spinfo += "<div class=\"content clear\"><div class=\"fl pic\">" + pic + "</div><div class=\"txt fl\">" + title + "</div></div>";
                                //Session["ddbh"] = ddbh;
                                //Session["openid"] = Request["openid"].ToString();
                                Session["body"] = title;

                                // Log.Debug(this.GetType().ToString(), "wxJsApiParam : " + wxJsApiParam);
                            }

                        }
                    }
                    //WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult();
                    //wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数    
                    #endregion

                    #region "处理支付方式"
                    //total_fee
                    string _sql = "select * from tm_jian where j_Tmoney<=" + price.ToString().Trim() + " and j_Bdate<=getDate() and j_Edate>=getDate() and cid=(select top 1 c_id from wp_category where c_no=' " + "') order by j_Tmoney desc";
                    _sql += "\r\n; select * from tm_quan where  q_Bdate<=getDate() and q_Edate>=getDate()";
                    _sql += " and id in (select qid from tm_quan_mem where openid='"+ openid + "' ";
                    _sql += " and qnum>(select count(id) from tm_quan_mem_log where tm_quan_mem_log.qmid=tm_quan_mem.id)";
                    _sql += ")";

                   // throw new Exception(_sql);
                    string result = "";
                    decimal _jMoney = 0;
                    decimal _qMoney = 0;
                    DataSet ds = comfun.GetDataSetBySQL(_sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "";
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            result += "<div class=\"we_buy title clear\"><a href=\"javascript:;\">" + dr["j_title"].ToString().Trim() + "</a>" + "<b>¥" + dr["j_dmoney"].ToString().Trim() + "</b>" + "</div>";

                            _jMoney += Convert.ToDecimal(dr["j_dmoney"].ToString().Trim());
                        }
                        lt_jian.Text = result;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        result = "";
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            result += "<div class=\"we_buy title clear\"><a href=\"javascript:;\">" + dr["q_title"].ToString().Trim() + "</a>" + "<b>¥" + dr["q_money"].ToString().Trim() + "</b>" + "</div>";
                            _qMoney += Convert.ToDecimal(dr["q_money"].ToString().Trim());
                        }
                        lt_quan.Text = result;

                        if (price - _jMoney - _qMoney > 0)
                        {
                            lt_wxpay.Text = "<div class=\"we_buy clear\"><a href=\"javascript:;\">微信支付</a>" + "<b>¥" + (price - _jMoney - _qMoney) + "</b>" + "</div>";
                        }
                    }
                    
                    #endregion 
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('下单失败，请返回重试!');</script>");
                    tijiao.Disabled = true;
                    //submit.Visible = false;
                }
                #endregion


            }
            else
            {
                Response.Redirect("index.aspx");
            }
            //unionid = "o0rXMvgiHcLWIFgfvqcFzVZqe0YQ";
            //pinopen = "of8T9tqpdohEMcKV4jQ5i53ZDG0w";
            //dizhi("o0rXMvgiHcLWIFgfvqcFzVZqe0YQ");
         
        }


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    addaddress();
        //    adddingdan();
        //    Response.Redirect("CheckInfo.aspx?openid="+Request["openid"].ToString()+"::"+ddbh+"");
        //}
        public void dizhi(string unionid)
        {
            string sql = "select * from dbo.WP_订单地址表 where 订单编号 in(";
            sql += "select openid from WP_会员表 where unionid='"+unionid+"') order by 是否为默认地址 desc ";
            string s = String.Empty;
           
            string ss = String.Empty;
           
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                ss = "<li class=\"clear\"><div id=sp" + dt.Rows[0]["id"] + "><div class=\"address_list2\"><div class=\"padd_10 clear\"><a class=\"tc fl\" href='javascript:;' onclick=\"qiehuandizhi(" + dt.Rows[0]["id"] + ")\"><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[0]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[0]["手机号"].ToString() + "</span></div><div class=\"bot_a\"><span>[默认]</span>收货地址：" + dt.Rows[0]["省"].ToString() + dt.Rows[0]["市"].ToString() + dt.Rows[0]["区"].ToString() + dt.Rows[0]["详细地址"].ToString() + "</div></a><a class=\"fr mody\" href=\"javascript:;\" onclick=\"edit(" + dt.Rows[0]["id"].ToString() + ")\"><img src=\"images/edit01.png\"/></a></div></div></div></li>";
                s = "<div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[0]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[0]["手机号"].ToString() + "</span></div><div class=\"bot_a\">收货地址：" + dt.Rows[0]["省"].ToString() + dt.Rows[0]["市"].ToString() + dt.Rows[0]["区"].ToString() + dt.Rows[0]["详细地址"].ToString() + "</div></div></div></div>";
                ddddid.Value = dt.Rows[0]["id"].ToString();
                if (dt.Rows.Count > 1)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                       // s = "<div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[0]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[0]["手机号"].ToString() + "</span></div><div class=\"bot_a\">收货地址：" + dt.Rows[0]["省"].ToString() + dt.Rows[0]["市"].ToString() + dt.Rows[0]["区"].ToString() + dt.Rows[0]["详细地址"].ToString() + "</div></div></div></div>";
                        ss += "<li class=\"clear\"><div id=sp" + dt.Rows[i]["id"] + "><div class=\"address_list2\"><div class=\"padd_10 clear\"><a class=\"tc fl\" href='javascript:;' onclick=\"qiehuandizhi(" + dt.Rows[i]["id"] + ")\"><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[i]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[i]["手机号"].ToString() + "</span></div><div class=\"bot_a\">收货地址：" + dt.Rows[i]["省"].ToString() + dt.Rows[i]["市"].ToString() + dt.Rows[i]["区"].ToString() + dt.Rows[i]["详细地址"].ToString() + "</div></a><a class=\"fr mody\" href=\"javascript:;\" onclick=\"edit(" + dt.Rows[i]["id"].ToString() + ")\"><img src=\"images/edit01.png\"/></a></div></div></div></li>";
                     
                    }
                }
               
            }
            else 
            {
                s = "<div class=\"shr clear newadd\"><span class=\"fl\">新增收货地址信息</span></div>";
                ss = "";
            }

            lit_dizhi.Text = s;
            lit_dizhiall.Text = ss;
        }

    }
}