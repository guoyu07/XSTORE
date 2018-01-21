using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Security;
using Newtonsoft.Json.Linq;
using tdx.database;
using System.Web.Script.Serialization;

namespace tdx.memb.man.config
{
    public class weixin
    {
        private string Token = "tdx8888889Z";
        private string devlopID = "wx752aa82143c09a8a";
        private string devlogPsw = "363e23b375797ad52fde0b829b6d41ff";
        public string AccessToken = "";

        #region"验证及初始化"
        public void Auth()
        {
            string echoStr = System.Web.HttpContext.Current.Request.QueryString["echoStr"];
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    System.Web.HttpContext.Current.Response.Write(echoStr);
                    System.Web.HttpContext.Current.Response.End();
                }
            }
        }

        public string GetAccessToken()
        {
            string url_token = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + devlopID + "&secret=" + devlogPsw;
            string result = func.webRequestGet(url_token);
            //return result;
            accessToken deserializedProduct = (accessToken)JsonConvert.DeserializeObject(result, typeof(accessToken));
            //return deserializedProduct.expires_in.ToString();
            this.AccessToken = deserializedProduct.access_token;
            return this.AccessToken;
        }
        /// <summary>
        /// 重载传入开发者ID和开发者密码信息
        /// </summary>
        /// <param name="devlopIDs"></param>
        /// <param name="devlogPsws"></param>
        /// <returns></returns>
        public string GetAccessToken(string devlopIDs, string devlogPsws)
        {
            string url_token = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + devlopIDs + "&secret=" + devlogPsws;
            string result = func.webRequestGet(url_token);
            //return result;
            accessToken deserializedProduct = (accessToken)JsonConvert.DeserializeObject(result, typeof(accessToken));
            //return deserializedProduct.expires_in.ToString();
            this.AccessToken = deserializedProduct.access_token;
            return this.AccessToken;
        }

        public string GetMenu()
        {
            string url_Menu_Get = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token=" + this.AccessToken;
            string output = func.webRequestGet(url_Menu_Get);
            //wxErr deserializedProduct = (wxErr)JsonConvert.DeserializeObject(output, typeof(wxErr));
            //return deserializedProduct.errmsg;
            return output;
        }

        //public string SetMenu()
        //{
        //    string url_Menu_Create = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + this.AccessToken;

        //    guotaotao gtt = new guotaotao();
        //    string postData = gtt.createMenuDate();
        //    string result = func.webRequestPost(url_Menu_Create, postData);

        //    return result;
        //}

        public string DelMenu()
        {
            string url_Menu_Delete = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + this.AccessToken;
            string result = func.webRequestGet(url_Menu_Delete);

            return result;
        }

        //public void Handle(string postStr)
        //{
        //    //封装请求类
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(postStr);
        //    XmlElement rootElement = doc.DocumentElement;

        //    RequestXML requestXML = new RequestXML();
        //    requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
        //    requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
        //    requestXML.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
        //    requestXML.MsgType = rootElement.SelectSingleNode("MsgType").InnerText;
        //    requestXML.msgID = rootElement.SelectSingleNode("MsgId") != null ? rootElement.SelectSingleNode("MsgId").InnerText : "";
        //    requestXML.Content = rootElement.SelectSingleNode("Content") != null ? rootElement.SelectSingleNode("Content").InnerText : "";
        //    requestXML.PicUrl = rootElement.SelectSingleNode("PicUrl") != null ? rootElement.SelectSingleNode("PicUrl").InnerText : "";
        //    requestXML.mediaId = rootElement.SelectSingleNode("MediaId") != null ? rootElement.SelectSingleNode("MediaId").InnerText : "";
        //    requestXML.format = rootElement.SelectSingleNode("Format") != null ? rootElement.SelectSingleNode("Format").InnerText : "";
        //    requestXML.thumbMediaId = rootElement.SelectSingleNode("ThumbMediaId") != null ? rootElement.SelectSingleNode("ThumbMediaId").InnerText : "";
        //    requestXML.Location_X = rootElement.SelectSingleNode("Location_X") != null ? rootElement.SelectSingleNode("Location_X").InnerText : "";
        //    requestXML.Location_Y = rootElement.SelectSingleNode("Location_Y") != null ? rootElement.SelectSingleNode("Location_Y").InnerText : "";
        //    requestXML.Scale = rootElement.SelectSingleNode("Scale") != null ? rootElement.SelectSingleNode("Scale").InnerText : "";
        //    requestXML.Label = rootElement.SelectSingleNode("Label") != null ? rootElement.SelectSingleNode("Label").InnerText : "";
        //    requestXML.Title = rootElement.SelectSingleNode("Title") != null ? rootElement.SelectSingleNode("Title").InnerText : "";
        //    requestXML.Description = rootElement.SelectSingleNode("Description") != null ? rootElement.SelectSingleNode("Description").InnerText : "";
        //    requestXML.Url = rootElement.SelectSingleNode("Url") != null ? rootElement.SelectSingleNode("Url").InnerText : "";
        //    requestXML.evEnt = rootElement.SelectSingleNode("Event") != null ? rootElement.SelectSingleNode("Event").InnerText : "";
        //    requestXML.eventKey = rootElement.SelectSingleNode("EventKey") != null ? rootElement.SelectSingleNode("EventKey").InnerText : "";
        //    requestXML.ticket = rootElement.SelectSingleNode("Ticket") != null ? rootElement.SelectSingleNode("Ticket").InnerText : "";
        //    requestXML.latitude = rootElement.SelectSingleNode("Latitude") != null ? rootElement.SelectSingleNode("Latitude").InnerText : "";
        //    requestXML.longitude = rootElement.SelectSingleNode("Longitude") != null ? rootElement.SelectSingleNode("Longitude").InnerText : "";
        //    requestXML.precision = rootElement.SelectSingleNode("Precision") != null ? rootElement.SelectSingleNode("Precision").InnerText : "";

        //    wx_logs.MyInsert("收到信息：" + postStr, requestXML.FromUserName, requestXML.ToUserName);
        //    //回复消息
        //    ResponseMsg(requestXML);
        //}

        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        /// <returns></returns>
        private bool CheckSignature()
        {
            string signature = System.Web.HttpContext.Current.Request.QueryString["signature"];
            string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"];
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        /// <summary>
        /// 返回回复信息的URl
        /// </summary>
        /// <param name="accToke"></param>
        /// <returns></returns>
        private string ReMessage(string accToke)
        {
            return "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + accToke;
        }
        /// <summary>
        /// 回复发送文本
        /// </summary>
        /// <param name="wwv"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int WxSendText(string wwv, string content, string pid, string pwd)
        {
            ///获取access 
            string ace = GetAccessToken(pid, pwd);
            string mess = func.webRequestPost(ReMessage(ace), TextJson(wwv, content));
            if (mess.IndexOf("ok") > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// 构造文本消息JSon
        /// </summary>
        /// <param name="wwv"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string TextJson(string wwv, string content)
        {
            JObject obj = JObject.Parse("{\"touser\":\"" + wwv + "\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + content + "\"}}");

            return obj.ToString();

        }
        ///// <summary>
        ///// 回复消息(微信信息返回)
        ///// </summary>
        ///// <param name="weixinXML"></param>
        //private void ResponseMsg(RequestXML requestXML)
        //{
        //    try
        //    {
        //        string resxml = "";
        //        switch (requestXML.MsgType)
        //        {
        //            case "text": //主要进行关键词回复功能
        //                resxml = GetRelXMLText(requestXML);
        //                break;
        //            case "event": //主要进行关注、取消关注、菜单点击等功能
        //                resxml = GetRelXMLEvent(requestXML);
        //                break;
        //            case "image": //暂时不知道处理什么
        //                resxml = GetRelXMLDefault("image", requestXML);
        //                break;
        //            case "voice": //暂时不知道处理什么
        //                resxml = GetRelXMLDefault("voice", requestXML);
        //                break;
        //            case "video": //暂时不知道处理什么
        //                resxml = GetRelXMLDefault("video", requestXML);
        //                break;
        //            case "location":  //接受地理位置,例如接受收货地址等

        //                break;
        //            case "link": //暂时不提供链接提交
        //                resxml = GetRelXMLDefault("link", requestXML);
        //                break;
        //            default:
        //                resxml = GetRelXMLDefault("default", requestXML);
        //                break;
        //        }

        //        System.Web.HttpContext.Current.Response.Write(resxml);

        //        //WriteToDB(requestXML, resxml,requestXML.FromUserName);
        //        wx_logs.MyInsert("收到信息：" + requestXML.MsgType + ",内容:" + requestXML.evEnt.ToString(), requestXML.FromUserName, requestXML.ToUserName);
        //    }
        //    catch (Exception ex)
        //    {
        //        //WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());
        //        wx_logs.MyInsert("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());
        //    }
        //}

        //private string GetRelXMLDefault(string _param, RequestXML requestXML)
        //{
        //    guotaotao mi = new guotaotao(requestXML.Content);
        //    mi._toUserName = requestXML.ToUserName;
        //    mi._FromUserName = requestXML.FromUserName;
        //    string resxml = mi.GetReMsg();

        //    resxml = GetRelXMLBase(requestXML, resxml);
        //    return resxml;
        //}
        //private string GetRelXMLText(RequestXML requestXML)
        //{
        //    string resxml = "";
        //    //在这里执行一系列操作，从而实现自动回复内容. 
        //    guotaotao mi = new guotaotao(requestXML.Content);
        //    mi._toUserName = requestXML.ToUserName;
        //    mi._FromUserName = requestXML.FromUserName;
        //    resxml = mi.GetReMsg();
        //    resxml = GetRelXMLBase(requestXML, resxml);

        //    return resxml;
        //}
        //private string GetRelXMLEvent(RequestXML requestXML)
        //{
        //    string resXML = "";
        //    guotaotao mi = new guotaotao();
        //    mi._toUserName = requestXML.ToUserName;
        //    mi._FromUserName = requestXML.FromUserName;
        //    switch (requestXML.evEnt)
        //    {
        //        case "subscribe": //关注事件,返回一个热烈的欢迎图像和文字介绍
        //            if (requestXML.eventKey == "qrscene_") //扫描二维码，后面应跟上自定义的二维码值
        //            {
        //                resXML = mi.GetFirst();
        //                resXML = GetRelXMLBase(requestXML, resXML);
        //            }
        //            else //纯关注
        //            {
        //                resXML = mi.GetFirst();
        //                resXML = GetRelXMLBase(requestXML, resXML);
        //            }
        //            break;
        //        case "unsubscrive"://取消关注事件，返回一个挥泪的惜别图像和文字说明
        //            resXML = mi.GetByebye();
        //            resXML = GetRelXMLBase(requestXML, resXML);
        //            break;
        //        case "scan"://扫描二维码。服务号认证后的功能
        //            break;
        //        case "LOCATION": //上报地理位置。服务好认证后的功能
        //            break;
        //        case "CLICK": //菜单。重点开发菜单的各项功能
        //            resXML = mi.GetMenuHandle(requestXML);
        //            //resXML = "";
        //            //resXML += "<xml>";
        //            //resXML += "<ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>";
        //            //resXML += "<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>";
        //            //resXML += "<CreateTime>" + func.ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
        //            //resXML += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[哈哈" + requestXML.eventKey + "]]></Content>";
        //            //resXML += "</xml>";
        //            resXML = GetRelXMLBase(requestXML, resXML);
        //            break;
        //        default:
        //            resXML = GetRelXMLDefault("", requestXML);
        //            break;
        //    }
        //    return resXML;
        //}

        private string GetRelXMLBase(RequestXML requestXML, string _RelXMLAdance)
        {
            string resxml = "";
            resxml += "<xml>";
            resxml += "<ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>";
            resxml += "<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>";
            resxml += "<CreateTime>" + func.ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";

            resxml += _RelXMLAdance;

            resxml += "</xml>";

            return resxml;
        }

        private void WriteToDB(RequestXML requestXML, string _xml, int _pid)
        {
            wx_tmsg wx = new wx_tmsg();
            wx.AddNew();
            wx.FromUserName = requestXML.FromUserName;
            wx.ToUserName = requestXML.ToUserName;
            wx.MsgType = requestXML.MsgType;
            wx.Msg = requestXML.Content;
            wx.Creatime = requestXML.CreateTime;
            wx.Location_X = requestXML.Location_X;
            wx.Location_Y = requestXML.Location_Y;
            wx.Label = requestXML.Label;
            wx.Scale = requestXML.Scale;
            wx.PicUrl = requestXML.PicUrl;
            wx.reply = _xml;
            wx.pid = _pid;
            try
            {
                wx.Update();
            }
            catch (Exception ex)
            {
                wx_logs.MyInsert(ex.Message);
                //ex.message;
            }

        }

        public string GetNichen(string _toUser, string _appID, string _appPSW)
        {
            string _result = "";

            this.devlopID = _appID;
            this.devlogPsw = _appPSW;
            string _accessToken = GetAccessToken();
            string url_Menu_Create = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + _accessToken + "&openid=" + _toUser + "&lang=zh_CN";

            _result = func.webRequestGet(url_Menu_Create);

            //_result = weixinUserHandle(_result).NiChen;

            return _result;
        }
        public weixinUser GetInfo(string _toUser, string _appID, string _appPSW)
        {
            string _result = "";

            this.devlopID = _appID;
            this.devlogPsw = _appPSW;
            string _accessToken = GetAccessToken();
            string url_Menu_Create = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + _accessToken + "&openid=" + _toUser + "&lang=zh_CN";

            _result = func.webRequestGet(url_Menu_Create);

            try
            {
                return weixinUserHandle(_result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private weixinUser weixinUserHandle(string _postData)
        {
            try
            {
                //XmlDocument doc = new XmlDocument();
                //doc.LoadXml(_postData);
                //XmlElement rootElement = doc.DocumentElement;

                weixinUser requestXML = new weixinUser();
                //_postData = _postData.Remove(_postData.LastIndexOf("}"), 1);
                //_postData = _postData.Remove(0, 1);

                //weixinUser requestXML = new weixinUser();
                //requestXML.ToUserName = rootElement.SelectSingleNode("openid").InnerText;
                //requestXML.NiChen = rootElement.SelectSingleNode("nickname").InnerText;
                //requestXML.Sex = rootElement.SelectSingleNode("nickname").InnerText;
                //requestXML.Language = rootElement.SelectSingleNode("nickname").InnerText;
                //requestXML.City = rootElement.SelectSingleNode("nickname").InnerText;
                //requestXML.Province = rootElement.SelectSingleNode("nickname").InnerText;
                //requestXML.Country = rootElement.SelectSingleNode("nickname").InnerText;
                //requestXML.Headimgurl = rootElement.SelectSingleNode("nickname").InnerText;
                //requestXML.Subscribe_time = rootElement.SelectSingleNode("nickname").InnerText;

                //使用JavaScriptSerializer对象来解析数据
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(_postData);
                if (json.ContainsKey("subscribe"))
                    requestXML.Subscribe = Convert.ToInt32(json["subscribe"]);
                if (json.ContainsKey("openid"))
                    requestXML.Openid = Convert.ToString(json["openid"]);
                if (json.ContainsKey("nickname"))
                    requestXML.Nickname = Convert.ToString(json["nickname"]);
                if (json.ContainsKey("sex"))
                    requestXML.Sex = Convert.ToInt32(json["sex"]);
                if (json.ContainsKey("language"))
                    requestXML.Language = Convert.ToString(json["language"]);
                if (json.ContainsKey("city"))
                    requestXML.City = Convert.ToString(json["city"]);
                if (json.ContainsKey("province"))
                    requestXML.Province = Convert.ToString(json["province"]);
                if (json.ContainsKey("country"))
                    requestXML.Country = Convert.ToString(json["country"]);
                if (json.ContainsKey("headimgurl"))
                    requestXML.Headimgurl = Convert.ToString(json["headimgurl"]);
                if (json.ContainsKey("subscribe_time"))
                    requestXML.Subscribe_time = Convert.ToString(json["subscribe_time"]);

                return requestXML;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ":" + _postData);
            }
        }
    }

    public class wxErr
    {
        private int Errcode;
        public int errcode
        {
            get { return Errcode; }
            set { Errcode = value; }
        }

        private string Errmsg;
        public string errmsg
        {
            get { return Errmsg; }
            set { Errmsg = value; }
        }
    }
    public class accessToken
    {
        private string _access_token;
        public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }
        private int _expires_in;
        public int expires_in
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }
    }
}