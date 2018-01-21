using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Text;
using Newtonsoft.Json;

namespace tdx.memb.man.weixinmoni
{
    /// <summary>
    /// GetWxtwList 的摘要说明
    /// </summary>
    public class GetWxtwList : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
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
                /* 1.token此参数为上面的token 2.pagesize此参数为每一页显示的记录条数

                3.pageid为当前的页数，4.groupid为微信公众平台的用户分组的组id*/
                string Url = "https://mp.weixin.qq.com/cgi-bin/appmsg?begin=0&count=200&t=media/appmsg_list&type=10&action=list&token=" + token + "&lang=zh_CN";
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);//Url为获取用户信息的链接
                webRequest.CookieContainer = cookie;
                webRequest.ContentType = "text/html; charset=UTF-8";
                webRequest.Method = "GET";
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string text = sr.ReadToEnd();
                MatchCollection mc;
                Regex Rex = new Regex(@"(?<=\{""item"":).+(?=,""file_cnt"":)");
                mc = Rex.Matches(text);
                JArray ImgandTxt = new JArray();
                Dictionary<string, int> tuwenlist = new Dictionary<string, int>();
                StringBuilder sbHtml = new StringBuilder();
                tuwenlist.Clear();
                if (mc.Count != 0)
                {
                    for (int i = 0; i < mc.Count; i++)
                    {
                        ImgandTxt = (JArray)JsonConvert.DeserializeObject(mc[i].Value);
                    }
                }
                if (ImgandTxt.Count > 0)
                {
                    //开始处理信息
                    if (context.Session["wid"] != null)
                    {

                        string _wid = context.Session["wid"].ToString();

                        sbHtml.Append("<div class=\"wxquanbu\">");
                        sbHtml.Append("<table class=\"wxlb\">");
                        for (int i = 0; i < ImgandTxt.Count; i++)  //第一层  图文组数
                        {
                            sbHtml.Append("<tr><td>");
                            string appid = ImgandTxt[i]["app_id"].ToString();//取组号
                            if ((ImgandTxt[i]["multi_item"]).Count() > 1)
                            {
                                tuwenlist.Add(appid, 1);
                            }
                            else
                            {
                                tuwenlist.Add(appid, 0);
                            }
                            if (i == 0)
                            {
                                sbHtml.Append("<input type=\"radio\" id=\"" + ImgandTxt[i]["app_id"].ToString() + "\" name=\"wz\" class=\"wxrd\" checked=\"checked\" value=\"" + ImgandTxt[i]["app_id"].ToString() + "\" /><label for=\"" + ImgandTxt[i]["app_id"].ToString() + "\">" + ImgandTxt[i]["title"].ToString() + "</label>");
                            }
                            else
                            {
                                sbHtml.Append("<input type=\"radio\" id=\"" + ImgandTxt[i]["app_id"].ToString() + "\" name=\"wz\" class=\"wxrd\"  value=\"" + ImgandTxt[i]["app_id"].ToString() + "\" /><label for=\"" + ImgandTxt[i]["app_id"].ToString() + "\">" + ImgandTxt[i]["title"].ToString() + "</label>");
                            }

                            sbHtml.Append("</td></tr>\r\n");


                        }

                        sbHtml.Append("</table></div>");
                        sbHtml.Append(" <script type=\"text/javascript\" language=\"javascript\">");
                        sbHtml.Append("   $(\"#wxfsanniu\").click(function () {");
                        sbHtml.Append("if ($(\"#weixinname\").val() == \"\") {");
                        sbHtml.Append(" alert(\"请输入微信号\");");
                        sbHtml.Append("  return;}");
                        sbHtml.Append(" $(\".wxrd\").each(function () {");
                        sbHtml.Append("if ($(this).checked == 'checked') {");
                        sbHtml.Append(" var rnd = Math.random();");
                        sbHtml.Append("  var vxname = $(\"#weixinname\").val();");
                        sbHtml.Append(" var appid = $(this).val();");
                        sbHtml.Append("$.get(\"SendWxtw.ashx?q=\" + $(th).val() + \"&r=\" + rnd + \"&vxname=\" + vxname + \"&appid=\" + appid, function (data) {");
                        sbHtml.Append(" alert(data);");
                        sbHtml.Append("}) }; }) }");
                        sbHtml.Append("  </script>");


                    }
                    HttpContext.Current.Session["tuwenlist"] = tuwenlist;
                    context.Response.Write(sbHtml.ToString());
                }
            }

            catch (System.Exception ex)
            {
                context.Response.Write(ex.Message + ex.StackTrace);
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