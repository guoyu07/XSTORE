using Tuan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tuan
{
    public partial class TestMo : System.Web.UI.Page
    {
        Chat chat = new Chat();
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = chat.access_token();
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token + "";
           
            string param = "";
            string openid = "of8T9tqpdohEMcKV4jQ5i53ZDG0w";
          
            string template_id3 = "ygOYQ3Y59oI0TQvHP5z4vOhlfeoLzl0aRAf8TsJvjGo";

            param = "{\"touser\" : \"" + openid + "\",    \"template_id\" : \"" + template_id3 + "\",    \"url\" : \"\",    \"topcolor\" : \"#FF0000\" , ";
            param += "\"data\" : {\"first\":{\"value\":\"尊敬的XXX：\",\"color\":\"#173177\"},";
            param += "\"OrderSn\":{\"value\":\"12485825012015070114564477\",\"color\":\"#173177\" },  ";
            param += "\"OrderStatus\":{\"value\":\"已发货\",\"color\":\"#173177\" },  ";
            param += "\"remark\":{\"value\":\"请注意查收哦！\", \"color\":\"#173177\"}}  }";

            //param = "{\"touser\" : \"" + openid + "\",    \"template_id\" : \"" + template_id2 + "\",    \"url\" : \"\",    \"topcolor\" : \"#FF0000\" , ";
            //param += "\"data\" : {\"first\":{\"value\":\"您已符合规则，请注意查收退款金额！\",\"color\":\"#173177\"},";
            //param += "\"reason\":{\"value\":\"参与您团购的人数已达到3人，符合规则\",\"color\":\"#173177\" },  ";
            //param += "\"refund\":{\"value\":\"0.01元\",\"color\":\"#173177\" },  ";
            //param += "\"remark\":{\"value\":\"请加油哦！\", \"color\":\"#173177\"}}  }";

            // param = "{\"touser\" : \"" + openid + "\",    \"template_id\" : \"" + template_id + "\",    \"url\" : \"\",    \"topcolor\" : \"#FF0000\" , ";
            //param+="\"data\" : {\"first\":{\"value\":\"恭喜您支付成功，请核对以下信息！\",\"color\":\"#173177\"},";
            //param+="\"orderMoneySum\":{\"value\":\"0.03元\",\"color\":\"#173177\" },  ";
            //param+="\"orderProductName\":{\"value\":\"专柜正品 法国进口男士香水持久清新淡香古龙水 香奈儿蔚蓝同香味\",\"color\":\"#173177\" },  ";
            //param+="\"Remark\":{\"value\":\"欢迎再次购买！\", \"color\":\"#173177\"}}  }";
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

                Response.Write(sr.ReadToEnd());
                newStream.Close();
                //return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}