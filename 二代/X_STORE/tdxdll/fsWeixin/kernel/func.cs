using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.Net;
using System.IO;

namespace tdx.kernel
{
    public class func
    {
        /// <summary>
        /// unix时间转换为datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeToTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        public static string GetEmailByWeixinGhID(string _ghID)
        {
            DataTable dt = comfun.GetDataTableBySQL("select m_email from b2c_worker where id in (select wid from wx_mp where wx_id='" + _ghID + "') ");
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString().Trim();
            else
                return "";
        }

        /// <summary>
        /// 调用百度地图，返回坐标信息
        /// </summary>
        /// <param name="y">经度</param>
        /// <param name="x">纬度</param>
        /// <returns></returns>
        public static string GetMapInfo(string x, string y)
        {
            try
            {
                string res = string.Empty;
                string parame = string.Empty;
                string url = "http://maps.googleapis.com/maps/api/geocode/xml";
                parame = "latlng=" + x + "," + y + "&language=zh-CN&sensor=false";//此key为个人申请
                res = webRequestPost(url, parame);

                XmlDocument doc = new XmlDocument();

                doc.LoadXml(res);
                XmlElement rootElement = doc.DocumentElement;
                string Status = rootElement.SelectSingleNode("status").InnerText;
                if (Status == "OK")
                {
                    //仅获取城市
                    XmlNodeList xmlResults = rootElement.SelectSingleNode("/GeocodeResponse").ChildNodes;
                    for (int i = 0; i < xmlResults.Count; i++)
                    {
                        XmlNode childNode = xmlResults[i];
                        if (childNode.Name == "status")
                        {
                            continue;
                        }

                        string city = "0";
                        for (int w = 0; w < childNode.ChildNodes.Count; w++)
                        {
                            for (int q = 0; q < childNode.ChildNodes[w].ChildNodes.Count; q++)
                            {
                                XmlNode childeTwo = childNode.ChildNodes[w].ChildNodes[q];

                                if (childeTwo.Name == "long_name")
                                {
                                    city = childeTwo.InnerText;
                                }
                                else if (childeTwo.InnerText == "locality")
                                {
                                    return city;
                                }
                            }
                        }
                        return city;
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteTxt("map异常:" + ex.Message.ToString() + "Struck:" + ex.StackTrace.ToString());
                return "0";
            }

            return "0";
        }

        /// <summary>
        /// Post 提交调用抓取
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="param">参数</param>
        /// <returns>string</returns>
        public static string webRequestPost(string url, string param)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(param);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "Post";
            req.Timeout = 120 * 1000;
            req.ContentType = "application/x-www-form-urlencoded;";
            req.ContentLength = bs.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Flush();
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 

                Stream strm = wr.GetResponseStream();

                StreamReader sr = new StreamReader(strm, System.Text.Encoding.UTF8);

                string line;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line + System.Environment.NewLine);
                }
                sr.Close();
                strm.Close();
                return sb.ToString();
            }
        }

        /// <summary>
        /// Get 提交调用抓取
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="param">参数</param>
        /// <returns>string</returns>
        public static string webRequestGet(string url)
        {
            //byte[] bs = System.Text.Encoding.UTF8.GetBytes("");

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "Get";
            req.Timeout = 120 * 1000;
            //req.ContentType = "application/x-www-form-urlencoded;";
            //req.ContentLength = bs.Length;

            //using (Stream reqStream = req.GetRequestStream())
            //{
            //    reqStream.Write(bs, 0, bs.Length);
            //    reqStream.Flush();
            //}
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 

                Stream strm = wr.GetResponseStream();

                StreamReader sr = new StreamReader(strm, System.Text.Encoding.UTF8);

                string line;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line + System.Environment.NewLine);
                }
                sr.Close();
                strm.Close();
                return sb.ToString();
            }
        }
         
    }
    //微信请求类
    public class RequestXML
    {
        private string msgId = "";
        public string msgID
        {
            get { return msgId; }
            set { msgId = value; }
        }
        private string toUserName = "";
        /// <summary>
        /// 消息接收方微信号，一般为公众平台账号微信号
        /// </summary>
        public string ToUserName
        {
            get { return toUserName; }
            set { toUserName = value; }
        }

        private string fromUserName = "";
        /// <summary>
        /// 消息发送方微信号
        /// </summary>
        public string FromUserName
        {
            get { return fromUserName; }
            set { fromUserName = value; }
        }

        private string createTime = "";
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private string msgType = "";
        /// <summary>
        /// 信息类型 地理位置:location,文本消息:text,消息类型:image
        /// </summary>
        public string MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }

        private string content = "";
        /// <summary>
        /// 信息内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string location_X = "";
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Location_X
        {
            get { return location_X; }
            set { location_X = value; }
        }

        private string location_Y = "";
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y
        {
            get { return location_Y; }
            set { location_Y = value; }
        }

        private string scale = "";
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private string label = "";
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        private string picUrl = "";
        /// <summary>
        /// 图片链接，开发者可以用HTTP GET获取
        /// </summary>
        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }

        private string MediaId = "";
        public string mediaId
        {
            set { MediaId = value; }
            get { return MediaId; }
        }

        private string Format = "";
        public string format
        {
            set { Format = value; }
            get { return Format; }
        }

        private string ThumbMediaId = "";
        public string thumbMediaId
        {
            set { ThumbMediaId = value; }
            get { return ThumbMediaId; }
        }

        private string title = "";
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        private string description = "";
        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        private string url = "";
        public string Url
        {
            set { url = value; }
            get { return url; }
        }

        private string Event= "";
        public string evEnt
        {
            get { return Event; }
            set { Event = value; }
        }

        private string EventKey = "";
        public string eventKey
        {
            get { return EventKey; }
            set { EventKey = value; }

        }

        private string Ticket = "";
        public string ticket
        {
            get { return Ticket; }
            set { Ticket = value; }

        }

        private string Latitude = "";
        public string latitude
        {
            get { return Latitude; }
            set { Latitude = value; }
        }

        private string Longitude = "";
        public string longitude
        {
            get { return Longitude; }
            set { Longitude = value; }
        }

        private string Precision = "";
        public string precision
        {
            get { return Precision; }
            set { Precision = value; }
        }
    }

    //用户信息类
    public class weixinUser 
    {
        private int subscribe = 0;

        public int Subscribe
        {
            get { return subscribe; }
            set { subscribe = value; }
        }

        private string openid = "";

        public string Openid
        {
            get { return openid; }
            set { openid = value; }
        }
        private int sex = 0;

        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string language;

        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        private string city = "";

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string province = "";

        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        private string country = "";

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private string headimgurl = "";

        public string Headimgurl
        {
            get { return headimgurl; }
            set { headimgurl = value; }
        }
        private string subscribe_time = "";

        public string Subscribe_time
        {
            get { return subscribe_time; }
            set { subscribe_time = value; }
        }
        private string toUserName = "";
        /// <summary>
        /// 消息接收方微信号，一般为公众平台账号微信号
        /// </summary>
        public string ToUserName
        {
            get { return toUserName; }
            set { toUserName = value; }
        }

        private string nichen="";
        public string Nickname
        {
            get{return nichen;}
            set{nichen = value;}
        }
          
    }
}
