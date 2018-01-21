using Tuan;
using Creatrue.kernel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;

namespace Tuan
{
    public partial class GetAll : System.Web.UI.Page
    {

        Chat chat = new Chat();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["openid"] != null && Request.Cookies["openid"].Value != "" && Request.Cookies["refresh_token"] != null && Request.Cookies["refresh_token"].Value != "")
            {

                try
                {

                    if (Request["back_url"] != null)
                    {
                        string pin = Request["back_url"];
                        string[] a = pin.Split(':');
                        if (a.Length > 3)
                        {
                            int wxid2 = Convert.ToInt32(a[3].ToString());
                            chat.wxid = wxid2;

                        }
                    }
                    else
                    {
                        chat.wxid = 0;
                    }
                    string ul2 = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid=" + chat.appid() + "&grant_type=refresh_token&refresh_token=" + Server.HtmlEncode(Request.Cookies["refresh_token"].Value) + "";
                    string r2 = string.Empty;
                    HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(ul2.ToString());
                    HttpWebResponse webResponse2 = (HttpWebResponse)webRequest2.GetResponse();
                    //从Internet资源返回数据流
                    Stream webStream2 = webResponse2.GetResponseStream();
                    //读取数据流
                    StreamReader webStreamReader2 = new StreamReader(webStream2, System.Text.Encoding.UTF8);
                    //读取数据
                    r2 = webStreamReader2.ReadToEnd();
                    webStreamReader2.Close();
                    webStream2.Close();
                    webResponse2.Close();
                    JObject j2 = (JObject)JsonConvert.DeserializeObject(r2);
                    Response.Cookies["openid"].Value = j2["openid"].ToString();
                    Response.Cookies["openid"].Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies["refresh_token"].Value = j2["refresh_token"].ToString();
                    Response.Cookies["refresh_token"].Expires = DateTime.Now.AddMonths(1);


                    string ul3 = "https://api.weixin.qq.com/sns/userinfo?access_token=" + j2["access_token"].ToString() + "&openid=" + Server.HtmlEncode(Request.Cookies["openid"].Value) + "&lang=zh_CN";
                    string r3 = string.Empty;
                    HttpWebRequest webRequest3 = (HttpWebRequest)WebRequest.Create(ul3.ToString());
                    HttpWebResponse webResponse3 = (HttpWebResponse)webRequest3.GetResponse();
                    //从Internet资源返回数据流
                    Stream webStream3 = webResponse3.GetResponseStream();
                    //读取数据流
                    StreamReader webStreamReader3 = new StreamReader(webStream3, System.Text.Encoding.UTF8);
                    //读取数据
                    r3 = webStreamReader3.ReadToEnd();
                    webStreamReader3.Close();
                    webStream3.Close();
                    webResponse3.Close();
                    JObject j3 = (JObject)JsonConvert.DeserializeObject(r3);
                   
                    if (Request["back_url"] != null)
                    {
                    //    HttpCookie zh = new HttpCookie("ziji");
                    //    zh.Values["open"] = j2["openid"].ToString();
                    //    zh.Values["name"] = j3["nickname"].ToString();
                    //    zh.Values["sex"]=j3["sex"].ToString().Equals("1") ? "男" : "女";
                    //    zh.Values["headimg"]=j3["headimgurl"].ToString();
                    //    zh.Expires = DateTime.Now.AddDays(14);
                    //    Response.Cookies.Add(zh);


                    //    Response.Write("<script>window.location=" + Request["back_url"].ToString() + "</script>");

                         Response.Redirect("" + Request["back_url"].ToString() + "&openid=" + j2["openid"].ToString() + "&name=" + j3["nickname"].ToString() + "&sex=" + (j3["sex"].ToString().Equals("1") ? "男" : "女") + "&headimg=" + j3["headimgurl"].ToString() + "");
                         
                    
                    
                    }
                    else
                    {
                    }
                }

                catch (Exception ex)
                {
                    Response.Write(ex);
                    //Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
                }
            }

            else
            {
                if (Request["code"] != null)
                {

                    if (Request["back_url"] != null)
                    {
                        string pin = Request["back_url"];
                        string[] a = pin.Split(':');
                        if (a.Length > 3)
                        {
                            int wxid2 = Convert.ToInt32(a[3].ToString());
                            chat.wxid = wxid2;
                        }
                        else
                        {
                            chat.wxid = 0;
                        }
                    }
                    else
                    {
                        chat.wxid = 0;
                    }

                    string ul = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + chat.appid() + "&secret=" + chat.secret() + "&code=" + Request["code"].ToString() + "&grant_type=authorization_code";
                    string r = string.Empty;
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(ul.ToString());
                    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                    //从Internet资源返回数据流
                    Stream webStream = webResponse.GetResponseStream();
                    //读取数据流
                    StreamReader webStreamReader = new StreamReader(webStream, System.Text.Encoding.UTF8);
                    //读取数据
                    r = webStreamReader.ReadToEnd();
                    webStreamReader.Close();
                    webStream.Close();
                    webResponse.Close();

                    JObject j = (JObject)JsonConvert.DeserializeObject(r);
                    Response.Cookies["openid"].Value = j["openid"].ToString();
                    Response.Cookies["openid"].Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies["refresh_token"].Value = j["refresh_token"].ToString();
                    Response.Cookies["refresh_token"].Expires = DateTime.Now.AddMonths(1);

                    string ul3 = "https://api.weixin.qq.com/sns/userinfo?access_token=" + j["access_token"].ToString() + "&openid=" + j["openid"].ToString() + "&lang=zh_CN";
                    string r3 = string.Empty;
                    HttpWebRequest webRequest3 = (HttpWebRequest)WebRequest.Create(ul3.ToString());
                    HttpWebResponse webResponse3 = (HttpWebResponse)webRequest3.GetResponse();
                    //从Internet资源返回数据流
                    Stream webStream3 = webResponse3.GetResponseStream();
                    //读取数据流
                    StreamReader webStreamReader3 = new StreamReader(webStream3, System.Text.Encoding.UTF8);
                    //读取数据
                    r3 = webStreamReader3.ReadToEnd();
                    webStreamReader3.Close();
                    webStream3.Close();
                    webResponse3.Close();
                    JObject j3 = (JObject)JsonConvert.DeserializeObject(r3);
                   
                    if (Request["back_url"] != null)
                    {
                        //HttpCookie zh = new HttpCookie("ziji");
                        //zh.Values["open"] = j["openid"].ToString();
                        //zh.Values["name"] = j3["nickname"].ToString();
                        //zh.Values["sex"] = j3["sex"].ToString().Equals("1") ? "男" : "女";
                        //zh.Values["headimg"] = j3["headimgurl"].ToString();
                        //zh.Expires = DateTime.Now.AddDays(14);
                        //Response.Cookies.Add(zh);
                        

                        //Response.Write("<script>window.location=" + Request["back_url"].ToString() + "</script>");

                        Response.Redirect("" + Request["back_url"].ToString() + "&openid=" + j["openid"].ToString() + "&name=" + j3["nickname"].ToString() + "&sex=" + (j3["sex"].ToString().Equals("1") ? "男" : "女") + "&headimg=" + j3["headimgurl"].ToString() + "");
                    
                    }
                    else
                    {
                    }
                }

                else
                {


                    if (Request["back_url"] != null)
                    {
                        string pin = Request["back_url"];
                        string[] a = pin.Split(':');
                        if (a.Length > 3)
                        {
                            int wxid2 = Convert.ToInt32(a[3].ToString());
                            chat.wxid = wxid2;
                        }
                        else
                        {
                            chat.wxid = 0;
                        }
                    }
                    else
                    {
                        chat.wxid = 0;
                    }
                    string _url = "";
                    _url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + chat.appid() + "&redirect_uri=" + Request.Url.AbsoluteUri + "&response_type=code&scope=snsapi_userinfo&state=1#wechat_redirect";
                    Response.Redirect(_url, false);
                }
            }
        }
    }
}

