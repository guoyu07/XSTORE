using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using tdx.database;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Collections.Generic;
using Com.Alipay;
using Creatrue.kernel;

namespace tdx.appv
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class sureCart : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Session[orderAuth.getOrderCookieKey()] != null)
            {
                DataTable dt = (DataTable)context.Session[orderAuth.getOrderCookieKey()];
                //Button2.Enabled = true;
                try
                {
                    string _ono = comEncrypt.GetDateRndNumber();
                    int _mid = 0;
                    if (context.Session["mID"] != null)
                    {
                        _mid = Convert.ToInt32(context.Session["mID"].ToString());
                    }
                    string _gid = "";
                    string _oDes = "";
                    decimal _oamt = 0;
                    decimal _allcent = 0;

                    string _sql = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        _sql += ";\r\n" + B2C_orders.insertDetailSQL(_ono, Convert.ToInt32(dr["guid"]), Convert.ToDecimal(dr["g_price"]), Convert.ToDecimal(dr["g_num"]), Convert.ToDecimal(dr["g_amt"]), Convert.ToDecimal(dr["g_cent"]), Convert.ToDecimal(dr["g_allcent"]), dr["g_des"].ToString());
                        _gid += dr["guid"].ToString() + ",";
                        _oamt += Convert.ToDecimal(dr["g_amt"]);
                        _allcent += Convert.ToDecimal(dr["g_allcent"]);
                    }


                    _sql += ";\r\n" + B2C_orders.insertSQL(_mid, Convert.ToInt32(context.Session["wid"].ToString()), _gid, _oDes, 0, 0, _oamt, _oamt, _allcent, _ono);


                    string _name = context.Request["txtSHR"].ToString().Trim();
                    string _addr = context.Request["txtDZ"].ToString().Trim();
                    string _zip = "";
                    string _tel = context.Request["txtTel"].ToString().Trim();
                    string _mobile = "";
                    string _sendDate = context.Request["txtTime"].ToString().Trim();
                    string _des = context.Request["txtDes"].ToString().Trim();
                    string _stid = "6";
                    _sql += ";\r\n " + B2C_orders.insertAddrSQL(_ono, _name, "", _addr, _zip, _tel, _mobile, _sendDate, _des);

                    comfun.UpdateBySQL(_sql);
                    context.Session[orderAuth.getOrderCookieKey()] = null;

                    //打开支付宝支付功能  
                    string _ono2 =_mid.ToString().Trim() + "__" + _ono;

                    string _defaultBank = context.Request["txtBank"].ToString().Trim();
                    string _alipayHTML = ali_pay(_name, _tel, _ono2, _oamt.ToString(), _defaultBank);

                    errReg er;
                    er.errCode = "OK";
                    er.errMsg = _alipayHTML;
                    context.Response.ContentType = "text/Json";
                    context.Response.ContentType = "UTF-8";
                    context.Response.Write(JsonConvert.SerializeObject(er, Formatting.Indented));  
                   // context.Response.Write("<script language='javascript'>alert('感谢您的订购,请牢记您的订单号码：" + _ono + ".');location.href='../index.html';</script>");
                }
                catch (Exception ex)
                {
                    errReg er;
                    er.errCode = "err";
                    er.errMsg = "订单保存失败:" + ex.Message;
                    context.Response.ContentType = "text/Json";
                    context.Response.ContentType = "UTF-8";
                    context.Response.Write(JsonConvert.SerializeObject(er, Formatting.Indented));                    
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        struct errReg
        {
            public string errCode;
            public string errMsg;
        }

        private string ali_pay(string _uname, string _utel, string _ono, string _uamt, string _defaultbank)
        {
            string chongzhi_title = "";
            string chongzhi_ID = ""; 

            chongzhi_title = _ono;
            chongzhi_ID = "会员:" + _uname;

            string _amt = _uamt;
            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //必填参数//

            //请与贵网站订单系统中的唯一订单号匹配 
            string out_trade_no = comEncrypt.setBase64(_ono); //;
            //订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。
            string subject = comFunction.Guolv("果淘淘_" + chongzhi_title );
            //订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里
            string body = comFunction.Guolv("果淘淘_" + chongzhi_title + ":" + _amt + "元," + _utel);
            //订单总金额，显示在支付宝收银台里的“应付总额”里
            string total_fee = _amt;



            //扩展功能参数——默认支付方式//

            //默认支付方式，代码见“即时到帐接口”技术文档
            string paymethod = "";
            //默认网银代号，代号列表见“即时到帐接口”技术文档“附录”→“银行列表”
            string defaultbank = _defaultbank;

            //扩展功能参数——防钓鱼//

            //防钓鱼时间戳
            string anti_phishing_key = "";// bc.g_wdate.ToString();
            //获取客户端的IP地址，建议：编写获取客户端IP地址的程序
            string exter_invoke_ip = "";// Request.ServerVariables.Get("Remote_Addr");
            //注意：
            //请慎重选择是否开启防钓鱼功能
            //exter_invoke_ip、anti_phishing_key一旦被设置过，那么它们就会成为必填参数
            //建议使用POST方式请求数据
            //示例：
            //exter_invoke_ip = "";
            //Service aliQuery_timestamp = new Service();
            //anti_phishing_key = aliQuery_timestamp.Query_timestamp();               //获取防钓鱼时间戳函数

            //扩展功能参数——其他//

            //商品展示地址，要用http:// 格式的完整路径，不允许加?id=123这类自定义参数
            string show_url = "http://www.fsWeixin.com";
            //自定义参数，可存放任何内容（除=、&等特殊字符外），不会显示在页面上
            string extra_common_param = "";
            //默认买家支付宝账号
            string buyer_email = "";

            //扩展功能参数——分润(若要使用，请按照注释要求的格式赋值)//

            //提成类型，该值为固定值：10，不需要修改
            string royalty_type = "";
            //提成信息集
            string royalty_parameters = "";
            //注意：
            //与需要结合商户网站自身情况动态获取每笔交易的各分润收款账号、各分润金额、各分润说明。最多只能设置10条
            //各分润金额的总和须小于等于total_fee
            //提成信息集格式为：收款方Email_1^金额1^备注1|收款方Email_2^金额2^备注2
            //示例：
            //royalty_type = "10";
            //royalty_parameters = "111@126.com^0.01^分润备注一|222@126.com^0.01^分润备注二";

            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("payment_type", "1");
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("body", body);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("paymethod", paymethod);
            sParaTemp.Add("defaultbank", defaultbank);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);
            sParaTemp.Add("extra_common_param", extra_common_param);
            sParaTemp.Add("buyer_email", buyer_email);
            sParaTemp.Add("royalty_type", royalty_type);
            sParaTemp.Add("royalty_parameters", royalty_parameters);

            //构造即时到帐接口表单提交HTML数据，无需修改
            Service ali = new Service();
            string sHtmlText = ali.Create_direct_pay_by_user(sParaTemp);
            //Response.Write(sHtmlText);

            return sHtmlText;
        }
    }
}
