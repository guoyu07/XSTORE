using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.weixinmoni
{
    /// <summary>
    /// SendWxtw 的摘要说明
    /// </summary>
    public class SendWxtw : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string _wid = HttpContext.Current.Session["Wid"].ToString();
            int isQ = 0;
            string vxname = context.Request["vxname"] != null ? context.Request["vxname"].ToString() : "";
            string appid = context.Request["appid"] != null ? context.Request["appid"].ToString() : "";
            if (string.IsNullOrEmpty(vxname))
            {
                isQ = 1;  //是否是群发
            }
            //模拟构造访问单组资源
            try
            {
                CookieContainer cookie = null;
                string token = null;
                //cookie = WeiXinLogin.LoginInfo.LoginCookie;//取得cookie
                //token = WeiXinLogin.LoginInfo.Token;//取得token
                if (HttpContext.Current.Session["weixinCookie"] != null)
                {
                    cookie = (CookieContainer)HttpContext.Current.Session["weixinCookie"];
                }
                else
                {
                    throw new Exception("请登陆");
                }
                if (HttpContext.Current.Session["weixinToken"] != null)
                {
                    token = HttpContext.Current.Session["weixinToken"].ToString();
                }
                else
                {
                    throw new Exception("请登录");
                }
                Dictionary<string, int> tuwenlist = (Dictionary<string, int>)HttpContext.Current.Session["tuwenlist"];  //获取图文列表
                string Url = "https://mp.weixin.qq.com/cgi-bin/appmsg?t=media/appmsg_edit&action=edit&lang=zh_CN&token=" + token + "&type=10&appmsgid=" + appid + "&isMul=" + tuwenlist[appid];
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
                HttpContext.Current.Session["weixinCookie"] = webRequest.CookieContainer;  //回写COOK
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
                        pad.Append("&content" + q.ToString() + "=" + ct);
                        pad.Append("&digest" + q.ToString() + "=" + (ImgandTxt[0]["multi_item"])[q]["digest"].ToString());
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
                List<string> wxnames = new List<string>();
                if (isQ == 1)
                {
                    DataTable dt = comfun.GetDataTableBySQL("select weixinID  from wx_userinfo where weixinID <> '' and cityid=" + _wid);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            wxnames.Add(dt.Rows[i]["weixinID"].ToString());
                        }
                    }
                    else
                    {
                        context.Response.Write("发送结束。");
                        return;
                    }

                }
                else
                {
                    wxnames.Add(vxname);
                }
                for (int j = 0; j < wxnames.Count; j++)
                {


                    try
                    {

                        //  CookieContainer cc = new CookieContainer();//接收缓存
                        string das = string.Format(pad.ToString(), wxnames[j]);
                        byte[] byteArray = Encoding.UTF8.GetBytes(das); // 转化

                        HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);  //新建一个WebRequest对象用来请求或者响应url

                        webRequest2.CookieContainer = (CookieContainer)HttpContext.Current.Session["weixinCookie"];                                  //保存cookie  

                        webRequest2.Method = "POST";                                          //请求方式是POST

                        webRequest2.ContentType = "application/x-www-form-urlencoded";       //请求的内容格式为application/x-www-form-urlencoded

                        webRequest2.ContentLength = byteArray.Length;

                        // webRequest2.Referer = "https://mp.weixin.qq.com/";
                        webRequest2.Referer = "https://mp.weixin.qq.com/cgi-bin/appmsg?t=media/appmsg_edit&action=edit&lang=zh_CN&token=" + token + "&type=10&appmsgid=" + appid + "&isMul=" + tuwenlist[appid];

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
                            context.Response.Write("发送成功");
                        }
                        else
                        {
                            if (weiXinYulan.msg.Contains("denied"))
                            {
                                context.Response.Write("发送失败微信号不存在");
                            }
                        }
                        HttpContext.Current.Session["weixinCookie"] = webRequest2.CookieContainer;
                    }
                    catch (System.Exception ex)
                    {
                        context.Response.Write("发送失败:" + ex.Message);
                    }
                }
                //context.Response.Write("发送成功");
            }
            catch (System.Exception ex)
            {
                context.Response.Write("发送失败:" + ex.Message);
            }
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