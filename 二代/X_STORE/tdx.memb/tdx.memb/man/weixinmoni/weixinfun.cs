using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace tdx.memb.man.weixinmoni
{
    public class weixinfun
    {

        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }
        public static bool SendMessage(string Message, string fakeid, int flag)//发送消息
        {
            bool result = false;
            CookieContainer cookie = null;
            string token = null;
            cookie = weixinmoni.LoginInfo.LoginCookie;//取得cookie
            token = weixinmoni.LoginInfo.Token;//取得token
            string strMsg = "";
            string padate = "";
            if (flag == 0)//发送文字
            {
                strMsg = Message;
                padate = "type=1&content=" + strMsg + "&tofakeid=" + fakeid + "&imgcode=&token=" + token + "&lang=zh_CN&random=0.4486911059357226&t=ajax-response";

            }
            if (flag == 1)//发送图文
            {

                padate = "type=10&app_id=" + Message + "&tofakeid=" + fakeid + "&appmsgid=" + Message + "&imgcode=&token=" + token + "&lang=zh_CN&random=0.22518408996984363&f=json&ajax=1&t=ajax-response";

            }


            string url = "https://mp.weixin.qq.com/cgi-bin/singlesend";

            byte[] byteArray = Encoding.UTF8.GetBytes(padate); // 转化

            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);

            webRequest2.CookieContainer = cookie; //登录时得到的缓存

            //webRequest2.Referer = "https://mp.weixin.qq.com/cgi-bin/singlemsgpage?fromfakeid=" + fakeid + "&count=20&t=wxm-singlechat&token=" + token + "&token=" + token + "&lang=zh_CN";
            webRequest2.Referer = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?t=message/send&action=index&tofakeid=" + fakeid + "&token=" + token + "&lang=zh_CN";
            webRequest2.Method = "POST";

            webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";

            webRequest2.ContentType = "application/x-www-form-urlencoded";

            webRequest2.ContentLength = byteArray.Length;

            Stream newStream = webRequest2.GetRequestStream();

            // Send the data.            
            newStream.Write(byteArray, 0, byteArray.Length);    //写入参数    

            newStream.Close();

            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();

            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.GetEncoding("UTF-8"));

            string text2 = sr2.ReadToEnd();
            if (text2.Contains("ok"))
            {
                result = true;
            }
            return result;
        }
        public static string fanwenhomeye()
        {
            try
            {
                ///////////////访问以下首页
                //////////////////////
                CookieContainer cookie = null;
                string token = null;

                // cookie = weixinmoni.LoginInfo.LoginCookie;//取得cookie
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
                //token = weixinmoni.LoginInfo.Token;//取得token

                /* 1.token此参数为上面的token 2.pagesize此参数为每一页显示的记录条数

                3.pageid为当前的页数，4.groupid为微信公众平台的用户分组的组id*/
                Random rd = new Random();
                double dd = rd.NextDouble();
                // string Url = "https://mp.weixin.qq.com/cgi-bin/sysnotify?token=" + token + "&lang=zh_CN&random=" + dd.ToString() + "&f=json&ajax=1&begin=0&count=5";
                string Url = string.Format(WeiXinUrl.PutongLaiyuanUrl, token);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);//Url为获取用户信息的链接
                webRequest.CookieContainer = cookie;
                //  webRequest.ContentType = "text/html; charset=UTF-8";
                webRequest.Method = "GET";
                //  webRequest.Referer = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token=" + token;
                // webRequest.Referer = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token=" + token;
                webRequest.Referer = WeiXinUrl.DenluLaiyuanUrl;
                // webRequest.KeepAlive = true;
                //  webRequest.Timeout = 6000000;
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                //  webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.72 Safari/537.36";
                webRequest.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                weixinmoni.LoginInfo.LoginCookie = webRequest.CookieContainer;
                string text = sr.ReadToEnd();
                HttpContext.Current.Session["weixinCookie"] = webRequest.CookieContainer;
                //清理
                response.Close();
                webRequest.Abort();

                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //throw new Exception(ex.StackTrace);
            }

        }
        public static string fanwenShouye()
        {
            try
            {
                ///////////////访问以下首页
                weixinfun.fanwenhomeye();   //规则改了。
                //////////////////////
                CookieContainer cookie = null;
                string token = null;

                // cookie = weixinmoni.LoginInfo.LoginCookie;//取得cookie
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
                //token = weixinmoni.LoginInfo.Token;//取得token

                /* 1.token此参数为上面的token 2.pagesize此参数为每一页显示的记录条数

                3.pageid为当前的页数，4.groupid为微信公众平台的用户分组的组id*/
                Random rd = new Random();
                double dd = rd.NextDouble();
                // string Url = "https://mp.weixin.qq.com/cgi-bin/sysnotify?token=" + token + "&lang=zh_CN&random=" + dd.ToString() + "&f=json&ajax=1&begin=0&count=5";
                string Url = string.Format(WeiXinUrl.Xiaoxi_Url, token, dd);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);//Url为获取用户信息的链接
                webRequest.CookieContainer = cookie;
                //  webRequest.ContentType = "text/html; charset=UTF-8";
                webRequest.Method = "GET";
                //  webRequest.Referer = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token=" + token;
                // webRequest.Referer = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token=" + token;
                webRequest.Referer = string.Format(WeiXinUrl.PutongLaiyuanUrl, token);
                // webRequest.KeepAlive = true;
                //  webRequest.Timeout = 6000000;
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                //  webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.72 Safari/537.36";
                webRequest.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                HttpContext.Current.Session["weixinCookie"] = webRequest.CookieContainer;
                string text = sr.ReadToEnd();
                //清理
                response.Close();
                webRequest.Abort();

                return "";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.StackTrace);
            }

        }
        ////////////
        public static List<SingleGroup> getGroupInfo(ref ListItemCollection lc)//获取所有分组数据存储在List里
        {

            try
            {
                ///////////////访问以下首页
                weixinfun.fanwenShouye();
                //////////////////////
                CookieContainer cookie = null;
                string token = null;
                //cookie = weixinmoni.LoginInfo.LoginCookie;//取得cookie
                //token = weixinmoni.LoginInfo.Token;//取得token
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
                // string Url = "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&pagesize=10&pageidx=0&type=0&groupid=0&token=" + token + "&lang=zh_CN";
                string Url = string.Format(WeiXinUrl.HuoquLibieUrl, token);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);//Url为获取用户信息的链接
                webRequest.CookieContainer = cookie;
                //  webRequest.ContentType = "text/html; charset=UTF-8";
                webRequest.Method = "GET";
                webRequest.Referer = string.Format(WeiXinUrl.PutongLaiyuanUrl, token);
                // webRequest.Referer = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token=" + token;
                webRequest.KeepAlive = true;
                webRequest.Timeout = 6000000;
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                //  webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.72 Safari/537.36";
                webRequest.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string text = sr.ReadToEnd();
                HttpContext.Current.Session["weixinCookie"] = webRequest.CookieContainer;
                MatchCollection mcGroup;
                Regex GroupRex = new Regex(@"(?<=""groups"":).*(?=\}\).groups)");
                mcGroup = GroupRex.Matches(text);
                List<SingleGroup> allgroupinfo = new List<SingleGroup>();
                if (mcGroup.Count != 0)
                {
                    JArray groupjarray = (JArray)JsonConvert.DeserializeObject(mcGroup[0].Value);
                    // HttpContext.Current.Session[""]
                    Dictionary<string, ListItem> dsl = new Dictionary<string, ListItem>();
                    for (int i = 0; i < groupjarray.Count; i++)
                    {
                        try
                        {

                            ListItem sid = new ListItem();
                            sid.Text = groupjarray[i]["name"].ToString() + "(" + groupjarray[i]["cnt"].ToString() + ")";
                            sid.Value = groupjarray[i]["id"].ToString();
                            sid.Attributes.Add("name", sid.Text);
                            sid.Attributes.Add("count", groupjarray[i]["cnt"].ToString());
                            ListItem name = new ListItem();
                            name.Text = groupjarray[i]["name"].ToString();
                            name.Value = groupjarray[i]["cnt"].ToString();
                            dsl.Add(groupjarray[i]["id"].ToString(), name);
                            lc.Add(sid);
                            //   getEachGroupInfo(groupjarray[i]["id"].ToString(), groupjarray[i]["cnt"].ToString(), groupjarray[i]["name"].ToString(), ref allgroupinfo);
                        }
                        catch (System.Exception ex)
                        {
                            throw new Exception("获取分组失败请重新获取");

                        }



                    }
                    HttpContext.Current.Session["weixinlistitem"] = dsl;
                }
                return allgroupinfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// //////////////////////////////////////////////////////////////////////////////
        public static List<SingleGroup> getAllGroupInfo()//获取所有分组数据存储在List里
        {

            try
            {
                ///////////////访问以下首页
                weixinfun.fanwenShouye();
                //////////////////////
                CookieContainer cookie = null;
                string token = null;
                //cookie = weixinmoni.LoginInfo.LoginCookie;//取得cookie
                //token = weixinmoni.LoginInfo.Token;//取得token
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
                string Url = "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&pagesize=10&pageidx=0&type=0&groupid=0&token=" + token + "&lang=zh_CN";
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);//Url为获取用户信息的链接
                webRequest.CookieContainer = cookie;
                //  webRequest.ContentType = "text/html; charset=UTF-8";
                webRequest.Method = "GET";
                webRequest.Referer = "https://mp.weixin.qq.com/cgi-bin/home?t=home/index&lang=zh_CN&token=" + token;
                webRequest.KeepAlive = true;
                webRequest.Timeout = 6000000;
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                //  webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.72 Safari/537.36";
                webRequest.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string text = sr.ReadToEnd();
                MatchCollection mcGroup;
                Regex GroupRex = new Regex(@"(?<=""groups"":).*(?=\}\).groups)");
                mcGroup = GroupRex.Matches(text);
                List<SingleGroup> allgroupinfo = new List<SingleGroup>();
                if (mcGroup.Count != 0)
                {
                    JArray groupjarray = (JArray)JsonConvert.DeserializeObject(mcGroup[0].Value);
                    //    ListItemCollection lt = new ListItemCollection();
                    for (int i = 0; i < groupjarray.Count; i++)
                    {
                        try
                        {

                            getEachGroupInfo(groupjarray[i]["id"].ToString(), groupjarray[i]["cnt"].ToString(), groupjarray[i]["name"].ToString(), ref allgroupinfo);
                        }
                        catch
                        {
                            throw new Exception("获取分组信息失败请重新登陆");
                        }
                        //finally
                        //{
                        //    getEachGroupInfo(groupjarray[i]["id"].ToString(), groupjarray[i]["cnt"].ToString(), groupjarray[i]["name"].ToString(), ref allgroupinfo);
                        //}


                    }
                }
                return allgroupinfo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.StackTrace);
            }

        }
        public static void getEachGroupInfo(string groupid, string count, string group_name, ref List<SingleGroup> groupdata)//获取单个分组数据
        {


            CookieContainer cookie = null;
            string token = null;
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
            //cookie = weixinmoni.LoginInfo.LoginCookie;//取得cookie
            //token = weixinmoni.LoginInfo.Token;//取得token    
            SingleGroup obj_single = new SingleGroup();
            obj_single.group_name = group_name;
            string TotalUser;
            if (count != "0")
            {
                TotalUser = count;
            }
            else
            {

                return;

            }


            string Url = "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&pagesize=" + TotalUser + "&pageidx=" + 0 + "&type=0&groupid=" + groupid.Trim() + "&token=" + token + "&lang=zh_CN";
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(Url);
            webRequest2.CookieContainer = cookie;
            webRequest2.ContentType = "text/html; charset=UTF-8";
            webRequest2.Method = "GET";
            webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string text2 = sr2.ReadToEnd();
            MatchCollection mcJsonData;
            Regex rexJsonData = new Regex(@"(?<=friendsList : \({""contacts"":).*(?=}\).contacts)");
            mcJsonData = rexJsonData.Matches(text2);
            if (mcJsonData.Count != 0)
            {
                JArray JsonArray = (JArray)JsonConvert.DeserializeObject(mcJsonData[0].Value);

                obj_single.groupdata = JsonArray;
                groupdata.Add(obj_single);

            }
            System.Threading.Thread.Sleep(10000);
            sr2.Close();
            webRequest2.Abort();
            //}



        }
    }
    public class SingleGroup//存储一个分组的信息的类
    {
        public string group_name;

        public JArray groupdata;

    }
    public class Tuwen
    {
        public string cover;
        public string title;
        public string digest;
        public string content_url;
        public string author;
        public string source_url;
        public string file_id;
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
        public static string Denlu_Url = "https://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN ";
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
}