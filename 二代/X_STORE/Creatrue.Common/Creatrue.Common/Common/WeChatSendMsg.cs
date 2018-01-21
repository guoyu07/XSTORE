using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Creatrue.Common
{
    public class WeChatSendMsg
    {
        public string wxUname = ""; //微信登陆用户名
        public string wxUpsw = ""; //微信登陆密码
        public string wxMsgID=""; //微信素材ID
        //public string sendMsgParam = null;

        public WeChatSendMsg(string _wxUname,string _wxUpsw,string _wxMsgID)
        {
            wxUname = _wxUname;
            wxUpsw = _wxUpsw;
            wxMsgID = _wxMsgID;
            //sendMsgParam = _sendMsgParam;
        }

        //方法: 模拟微信登陆
        public int weChatLogon()
        {
            int result = 0;
            if (string.IsNullOrEmpty(this.wxUname))
                return -1;//用户名为空
            if (string.IsNullOrEmpty(this.wxUpsw))
                return -2;//密码为空

            string password = GetMd5Str32(this.wxUpsw).ToUpper(); 
            string padata = "username=" + this.wxUname + "&pwd=" + password + "&imgcode=&f=json"; 
           
            string url = WeiXinUrl.Denlu_Url;//请求登录的URL 
            try
            { 
                CookieContainer cc = new CookieContainer();//接收缓存
                byte[] byteArray = Encoding.UTF8.GetBytes(padata); // 转化
                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);  //新建一个WebRequest对象用来请求或者响应url
                webRequest2.CookieContainer = cc;                                      //保存cookie  
                webRequest2.Method = "POST";                                          //请求方式是POST
                webRequest2.ContentType = "application/x-www-form-urlencoded";       //请求的内容格式为application/x-www-form-urlencoded
                webRequest2.ContentLength = byteArray.Length; 
                webRequest2.Referer = WeiXinUrl.DenluLaiyuanUrl; //来源网址
                Stream newStream = webRequest2.GetRequestStream();           //返回用于将数据写入 Internet 资源的 Stream。
                // Send the data.
                newStream.Write(byteArray, 0, byteArray.Length);    //写入参数
                newStream.Close();
                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
                string text2 = sr2.ReadToEnd();
                //此处用到了newtonsoft来序列化
                LoginInfo.Err = text2;
                //{"base_resp":{"ret":0,"err_msg":"ok"},"redirect_url":"\/cgi-bin\/home?t=home\/index&lang=zh_CN&token=136331741"}
                // WeiXinRetInfo retinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<WeiXinRetInfo>(text2);


                string token = string.Empty;
                if (text2.Length > 0)
                {
                    if (text2.Contains("&token="))
                    {
                        token = text2.Split(new char[] { '&' })[2].Split(new char[] { '=' })[1].ToString().Replace("\"}", "").ToString();//取得token
                        //LoginInfo.LoginCookie = cc;
                        LoginInfo.LoginCookie = cc;
                        //LoginInfo.CreateDate = DateTime.Now;
                        LoginInfo.CreateDate = DateTime.Now; 
                        //LoginInfo.Token = token;
                        LoginInfo.Token = token; 
                        result = 1;
                    }
                }               
                response2.Close();
                webRequest2.Abort();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            finally
            {   } 

            return result;
        }
        //方法: 获取微信素材
        public string[] weChatMessge()
        {
            string[] result = null;

            return result;
        }
        //方法：模拟发送
        public string weChatSend(string _targetWeChat,string content)
        {
            string result = "false";
            //string _wid = HttpContext.Current.Session["Wid"].ToString();
            string vxname = _targetWeChat;
            string appid = this.wxMsgID; 
            //模拟构造访问单组资源
            try
            {
                CookieContainer cookie = null;
                string token = null;
                //cookie = WeiXinLogin.LoginInfo.LoginCookie;//取得cookie
                //token = WeiXinLogin.LoginInfo.Token;//取得token
                if (LoginInfo.LoginCookie != null)
                {
                    cookie = (CookieContainer)LoginInfo.LoginCookie;
                }
                else
                {
                    result = "请登录";
                    //throw new Exception("请登陆");
                }
                if (LoginInfo.Token != null)
                {
                    token = LoginInfo.Token.ToString();
                    if (string.IsNullOrEmpty(token))
                        token = LoginInfo.Token;
                }
                else
                {
                    result = "请登录";
                    //throw new Exception("请登录");
                }
                //Dictionary<string, int> tuwenlist = (Dictionary<string, int>)HttpContext.Current.Session["tuwenlist"];  //获取图文列表
                //if (string.IsNullOrEmpty())
                //{
                //}
                string Url = "https://mp.weixin.qq.com/cgi-bin/appmsg?t=media/appmsg_edit&action=edit&lang=zh_CN&token=" + token + "&type=10&appmsgid=" + appid + "&isMul=0";
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);//Url为获取用户信息的链接
                webRequest.CookieContainer = cookie;
                webRequest.ContentType = "text/html; charset=UTF-8";
                webRequest.Method = "GET";
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                webRequest.Referer = "https://mp.weixin.qq.com/cgi-bin/appmsg?begin=0&count=10&t=media/appmsg_list&type=10&action=list&token=" + token + "&lang=zh_CN";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string text = sr.ReadToEnd();
                LoginInfo.LoginCookie = webRequest.CookieContainer;  //回写COOK
                MatchCollection mc;
                Regex Rex = new Regex(@"(?<=\{""item"":).+(?=,""file_cnt"":)");
                mc = Rex.Matches(text);
                JArray ImgandTxt = new JArray();
                // Dictionary<string, List<Tuwen>> tuwenlist = new Dictionary<string, List<Tuwen>>();
                //  tuwenlist.Clear();
                if (mc.Count != 0)
                {
                    for (int i = 0; i < mc.Count; i++)
                    {
                        ImgandTxt = (JArray)JsonConvert.DeserializeObject(mc[i].Value);
                    }
                }
                StringBuilder pad = new StringBuilder();
                if (ImgandTxt.Count > 0)
                {
                    string appMsgid = ImgandTxt[0]["app_id"].ToString();
                    int coutMsg = ImgandTxt[0]["multi_item"].Count(); //总个数图文
                    pad.Append("AppMsgId=" + appMsgid + "&count=" + coutMsg);
                    for (int q = 0; q < (ImgandTxt[0]["multi_item"].Count()); q++)
                    {
                        //处理每一条信息的内容
                        pad.Append("&title" + q.ToString() + "=" + (ImgandTxt[0]["multi_item"])[q]["title"].ToString());
                        string ct = (ImgandTxt[0]["multi_item"])[q]["content"].ToString().Replace("&quot;", "\"").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ");
                        //string ct1 = "尊敬的{0}，您合同{1}项下的{2}已于{3}时间支付给{4}。由于系统自动生成，请以用户最终到账为准。";
                        pad.Append("&content" + q.ToString() + "=" + ct);//详细内容
                        pad.Append("&digest" + q.ToString() + "=" + content);//摘要
                        pad.Append("&author" + q.ToString() + "=" + (ImgandTxt[0]["multi_item"])[q]["author"].ToString());
                        pad.Append("&fileid" + q.ToString() + "=" + (ImgandTxt[0]["multi_item"])[q]["file_id"].ToString());
                        pad.Append("&show_cover_pic" + q.ToString() + "=" + (ImgandTxt[0]["multi_item"])[q]["show_cover_pic"].ToString());
                        string cu = (ImgandTxt[0]["multi_item"])[q]["content_url"].ToString().Replace("&quot;", "\"").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ");
                        pad.Append("&sourceurl" + q.ToString() + "=" + cu);

                    }
                    Random rd = new Random();
                    double dd = rd.NextDouble();
                    pad.Append("&preusername={0}");

                    pad.Append("&imgcode=&token=" + token + "&lang=zh_CN&random=" + dd.ToString() + "&f=json&ajax=1&sub=preview&t=ajax-appmsg-preview&type=10");

                }
                //////////////////////处理参数
                // string padata = "username=" + name + "&pwd=" + password + "&imgcode=&f=json";

                string url = "https://mp.weixin.qq.com/cgi-bin/operate_appmsg";//请求预览的URL
                //string url = WeiXinUrl.Denlu_Url;
                
                //执行发送操作
                    try
                    {

                        //  CookieContainer cc = new CookieContainer();//接收缓存
                        string das = string.Format(pad.ToString(), vxname);
                        byte[] byteArray = Encoding.UTF8.GetBytes(das); // 转化

                        HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);  //新建一个WebRequest对象用来请求或者响应url

                        webRequest2.CookieContainer = (CookieContainer)LoginInfo.LoginCookie;                                  //保存cookie  

                        webRequest2.Method = "POST";                                          //请求方式是POST

                        webRequest2.ContentType = "application/x-www-form-urlencoded";       //请求的内容格式为application/x-www-form-urlencoded

                        webRequest2.ContentLength = byteArray.Length;

                        // webRequest2.Referer = "https://mp.weixin.qq.com/";

                        webRequest2.Referer = "https://mp.weixin.qq.com/cgi-bin/appmsg?t=media/appmsg_edit&action=edit&lang=zh_CN&token=" + token + "&type=10&appmsgid=" + appid + "&isMul=0";// +tuwenlist[appid];

                        Stream newStream = webRequest2.GetRequestStream();           //返回用于将数据写入 Internet 资源的 Stream。

                        // Send the data.

                        newStream.Write(byteArray, 0, byteArray.Length);    //写入参数

                        newStream.Close();

                        HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();

                        StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);

                        string text2 = sr2.ReadToEnd();

                        //此处用到了newtonsoft来序列化
                        WeiXinYulan weiXinYulan = Newtonsoft.Json.JsonConvert.DeserializeObject<WeiXinYulan>(text2);

                        if (weiXinYulan.msg.Contains("success"))
                        {
                            result = "OK";
                            //context.Response.Write("发送成功");
                        }
                        else
                        {
                            if (weiXinYulan.msg.Contains("denied"))
                            {
                                result = "发送失败微信号不存在";
                                //context.Response.Write("发送失败微信号不存在");
                            }
                        }
                        LoginInfo.LoginCookie = webRequest2.CookieContainer;
                    }
                    catch (System.Exception ex)
                    {
                        result = "发送失败:" + ex.Message+"/r/n"+ex.StackTrace;
                        //context.Response.Write("发送失败:" + ex.Message);
                    }
                //执行发送操作结束
                //context.Response.Write("发送成功");
            }
            catch (System.Exception ex)
            {
                result = "发送失败:" + ex.Message + "/r/n" + ex.StackTrace; ;
                //context.Response.Write("发送失败:" + ex.Message);
            }
            return result;
        }
        
        //方法：模拟发送2
        public int weChatSends(string[] _targetWeChat)
        {
            int result = 0;

            return result;
        }

        //其他辅助方法
        private string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }
        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetMd5Str32(string str) //MD5摘要算法
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.  
            char[] temp = str.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data   
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.  
            return sBuilder.ToString();
        }
    }

    public class LoginUser
    {

        private string uid;

        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        public LoginUser()
        {
            Uid = null;
            Pwd = null;

        }
    }
    public class WeiXinUrl
    {
        /// <summary>
        /// 登陆的URL POST请求
        /// </summary>
        public static string Denlu_Url = "https://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN";
        /// <summary>
        /// 消息的URL Get 请求 需要 token 参数  和 随机数参数
        /// </summary>
        public static string Xiaoxi_Url = "https://mp.weixin.qq.com/cgi-bin/sysnotify?token={0}&lang=zh_CN&random={1}&f=json&ajax=1&begin=0&count=5";
        /// <summary>
        /// 普通来源  需要 toke参数
        /// </summary>
        public static string PutongLaiyuanUrl = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token={0}";
        /// <summary>
        /// 登陆用来源 不需要参数
        /// </summary>
        public static string DenluLaiyuanUrl = "https://mp.weixin.qq.com/";
        /// <summary>
        /// 获取用户分组 的信息  需要token参数
        /// </summary>
        public static string HuoquLibieUrl = "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&pagesize=10&pageidx=0&type=0&groupid=0&token={0}&lang=zh_CN";
    }
    public class WeiXinRetInfo//保存登录失败微信公众平台网页返回的信息
    {
        public string Ret { get; set; }
        public string ErrMsg { get; set; }
        public string ShowVerifyCode { get; set; }
        public string ErrCode { get; set; }
    }
    public class WeiXinYulan
    {
        public string ret { get; set; }
        public string msg { get; set; }
        public string appMsgId { get; set; }
        public string fakeid { get; set; }
    }
    public static class LoginInfo//保存登陆后返回的信息
    {

        /// <summary>

        /// 登录后得到的令牌

        /// </summary>        

        public static string Token { get; set; }

        /// <summary>

        /// 登录后得到的cookie

        /// </summary>

        public static CookieContainer LoginCookie { get; set; }

        /// <summary>

        /// 创建时间

        /// </summary>

        public static DateTime CreateDate { get; set; }


        public static string Err { get; set; }



    }
}