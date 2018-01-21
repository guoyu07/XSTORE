using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace tdx.Weixin.Weixin
{
    public class SendTempMessage
    {
        public string devlopID = ConfigurationManager.AppSettings["APPID"].ToString();  //"wx4b52212c5d5983ad";// 
        public string devlogPsw = ConfigurationManager.AppSettings["APPSecret"].ToString();  //"58954dc71e9ac0d51e142ecacb44b0ba";// 
        /// <summary>
        /// 模板推送
        /// </summary>
        /// <param name="bx_content"></param>
        /// <param name="bx_Address"></param>
        /// <param name="openid"></param>
        /// <param name="Remarks"></param>
        public bool Send_WX_Message(Object postDataObj, string openid,string template_id)
        {
            weixin wx = new weixin();
            //获取AccessToken
            string AccessToken = wx.GetAccessTokenByAppId(devlopID, devlogPsw);
            //第一步设置所属行业
            msgData msg = new msgData();
            msg.touser = openid;
            if (!string.IsNullOrEmpty(msg.touser))
            {
                msg.template_id = template_id;

                msg.url = "";

                msg.data = postDataObj;

                string postUrl = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", AccessToken);

                string postData = JsonSerialize(msg);

                string result = webRequestPost(postUrl, postData);
                if (result.Contains("ok"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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

        public static string JsonSerialize(object obj)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            IsoDateTimeConverter idtc = new IsoDateTimeConverter();
            idtc.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(idtc);
            JsonWriter jw = new JsonTextWriter(sw);
            jw.Formatting = Formatting.Indented;
            serializer.Serialize(jw, obj);
            return sb.ToString();
        }
        private struct msgData
        {
            public string touser;

            public string template_id;

            public string url;

            public Object data;
        }
        private struct alertData
        {
            public object first;
            public object keyword1;
            public object keyword2;
            public object keyword3;
            public object remark;
        }
        private struct msgfirst
        {
            public string value;
            public string color;
        }
        private struct msgkeyword
        {
            public string value;
            public string color;
        }

        private struct msgremark
        {
            public string value;
            public string color;
        }
    }
}