using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tuan;
using System.Net;
using System.IO;

namespace Tuan
{
   public class MoBanMessage
    {
        #region 订单状态更新
       public string updateDing(string template_id, int wxid,string openid, string name, string ddbh, string zt)
        {
            Chat chat = new Chat();
            chat.wxid = wxid;
            string token = chat.access_token();
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token + "";

            string param = "";
            //string openid = "of8T9tqpdohEMcKV4jQ5i53ZDG0w";
    
            //string template_id3 = "ygOYQ3Y59oI0TQvHP5z4vOhlfeoLzl0aRAf8TsJvjGo";

            param = "{\"touser\" : \"" + openid + "\",    \"template_id\" : \"" + template_id + "\",    \"url\" : \"\",    \"topcolor\" : \"#FF0000\" , ";
            param += "\"data\" : {\"first\":{\"value\":\"尊敬的"+name+"：\",\"color\":\"#173177\"},";
            param += "\"OrderSn\":{\"value\":\""+ddbh+"\",\"color\":\"#173177\" },  ";
            param += "\"OrderStatus\":{\"value\":\""+zt+"\",\"color\":\"#173177\" },  ";
            param += "\"remark\":{\"value\":\"请注意查收！\", \"color\":\"#173177\"}}  }";
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(param); // 转化   
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
                webRequest.Method = "POST";
                webRequest.ContentType = "text/xml";
                webRequest.ContentLength = byteArray.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数   

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);

                //Response.Write(sr.ReadToEnd());
                newStream.Close();
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 退款通知
        public string TuiInfo(string template_id,int wxid, string openid, int ren, double yuan)
        {
            Chat chat = new Chat();
            chat.wxid = wxid;
            string token = chat.access_token();
           
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token + "";

            string param = "";
          //  string openid = "of8T9tqpdohEMcKV4jQ5i53ZDG0w";
         
         //   string template_id2 = "d77uIYr_YmMDbxexz_2aZeQhyeM-jIwL6Zf9ba3cN3M";

            param = "{\"touser\" : \"" + openid + "\",    \"template_id\" : \"" + template_id + "\",    \"url\" : \"\",    \"topcolor\" : \"#FF0000\" , ";
            param += "\"data\" : {\"first\":{\"value\":\"您已符合规则，请注意查收退款金额！\",\"color\":\"#173177\"},";
            param += "\"reason\":{\"value\":\"参与您团购的人数已达到"+ren+"人，符合规则\",\"color\":\"#173177\" },  ";
            param += "\"refund\":{\"value\":\""+yuan+"元\",\"color\":\"#173177\" },  ";
            param += "\"remark\":{\"value\":\"请加油哦！\", \"color\":\"#173177\"}}  }";

           
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(param); // 转化   
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
                webRequest.Method = "POST";
                webRequest.ContentType = "text/xml";
                webRequest.ContentLength = byteArray.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数   

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);

                //Response.Write(sr.ReadToEnd());
                newStream.Close();
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region 支付通知
        public string payinfo(string template_id,int wxid, string openid, string title, double yuan)
        {
            Chat chat = new Chat();
            chat.wxid = wxid;
            string token = chat.access_token();
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token + "";

            string param = "";
           // string openid = "of8T9tqpdohEMcKV4jQ5i53ZDG0w";
          //  string template_id = "d2AH3CdEGf2WMiHfLzegk19S5_BdGK3TAhV8HutUNng";
            param = "{\"touser\" : \"" + openid + "\",    \"template_id\" : \"" + template_id + "\",    \"url\" : \"\",    \"topcolor\" : \"#FF0000\" , ";
            param += "\"data\" : {\"first\":{\"value\":\"恭喜您支付成功，请核对以下信息！\",\"color\":\"#173177\"},";
            param += "\"orderMoneySum\":{\"value\":\""+yuan+"元\",\"color\":\"#173177\" },  ";
            param += "\"orderProductName\":{\"value\":\""+title+"\",\"color\":\"#173177\" },  ";
            param += "\"Remark\":{\"value\":\"欢迎再次购买！\", \"color\":\"#173177\"}}  }";
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(param); // 转化   
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
                webRequest.Method = "POST";
                webRequest.ContentType = "text/xml";
                webRequest.ContentLength = byteArray.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数   

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);

               // Response.Write(sr.ReadToEnd());
                newStream.Close();
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 新订单通知
        public string newding(string template_id,int wxid, string openid, string ddbh, string type, double yuan, string time, string tel, string name)
        {
            Chat chat = new Chat();
            chat.wxid = wxid;
            string token = chat.access_token();
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token + "";

            string param = "";
            // string openid = "of8T9tqpdohEMcKV4jQ5i53ZDG0w";
           // string template_id = "I0J7ZqPMESIdeBHoFelyNRnfUEcX6pdnQsLYUSg8_Dc";
            param = "{\"touser\" : \"" + openid + "\",    \"template_id\" : \"" + template_id + "\",    \"url\" : \"\",    \"topcolor\" : \"#FF0000\" , ";
            param += "\"data\" : {\"first\":{\"value\":\"商家请注意！，收到已支付订单\",\"color\":\"#173177\"},";
            param += "\"keyword1\":{\"value\":\"" + ddbh + "\",\"color\":\"#173177\" },  ";
            param += "\"keyword2\":{\"value\":\"" + type + "\",\"color\":\"#173177\" },  ";
            param += "\"keyword3\":{\"value\":\"" + yuan + "元\",\"color\":\"#173177\" },  ";
            param += "\"keyword4\":{\"value\":\"" + time + "\",\"color\":\"#173177\" },  ";
            param += "\"keyword5\":{\"value\":\"" + name + "\",\"color\":\"#173177\" },  ";
            param += "\"remark\":{\"value\":\"联系电话："+tel+"\", \"color\":\"#173177\"}}  }";
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(param); // 转化   
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
                webRequest.Method = "POST";
                webRequest.ContentType = "text/xml";
                webRequest.ContentLength = byteArray.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数   

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);

                // Response.Write(sr.ReadToEnd());
                newStream.Close();
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
