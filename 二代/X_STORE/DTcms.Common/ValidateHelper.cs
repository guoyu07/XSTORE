using System;
using System.Collections.Generic;
using System.Data;
using System.IO; 
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DTcms.Common
{
    /// <summary>
    /// 数据验证类
    /// </summary>
    public  class ValidateHelper
    {
        
        static Regex regIsNum = new Regex("^[0-9]+$");
        #region 验证 参数是否为 整型数值
        /// <summary>
        /// 验证 参数是否为 整型数值
        /// </summary>
        /// <param name="strNum"></param>
        /// <returns></returns>
        public static bool IsNum(string strNum)
        {
            return regIsNum.IsMatch(strNum);
        }
        #endregion

        #region 验证ip
        ///// <summary>
        ///// 验证ip
        ///// </summary>
        ///// <param name="ip"></param>
        ///// <returns></returns>
        //public static string IsIpOK(string ip)
        //{
        //    string strSql = "select count(id) from b2c_order_addr where datediff(d,a_senddate,getdate())=0 and a_ip='" + ip + "'";
        //    DataTable dt = sqlHelper.Datadt(strSql);
        //    string msg = string.Empty;
        //    if (dt.Rows.Count > 10)
        //    {
        //        msg = "您的IP(" + ip + ")今天下单已经超过10单(提示：为防止恶意灌水,同一IP一天只能下10单),请联系管理员.";
        //    }
        //    return msg;
        //}
        #endregion

        #region 发送短信
        /// <summary>
        /// 发送短信
        /// </summary> 
        /// <param name="mobile"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string comSMS(string mobile, string content)
        {
            //string url = "http://116.213.72.20/SMSHttpService/send.aspx?username=frxx&password=frxx2014&mobile="+mobile+"&content="+content;
            //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url.ToString());
             
            //#region POST
            //try
            //{
            //    byte[] byteArray = Encoding.UTF8.GetBytes(content); // 转化   
            //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
            //    webRequest.Method = "POST";
            //    webRequest.ContentLength = byteArray.Length; 
            //    Stream newStream = webRequest.GetRequestStream();
            //    newStream.Write(byteArray, 0, byteArray.Length); //写入参数   
            //    newStream.Close();
            //    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            //    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
            //    return sr.ToString();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //#endregion

            try
            {
                string url = "http://116.213.72.20/SMSHttpService/send.aspx";
                string strUrl = "?username=frxx&password=frxx2014&mobile=" + mobile + "&content=" + content;
                UTF8Encoding encoding = new UTF8Encoding();
                string str = string.Format(strUrl, mobile, content);
                Byte[] PostUrl = encoding.GetBytes(str);
                HttpWebRequest webRequest = System.Net.WebRequest.Create(url+strUrl) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                webRequest.ContentLength = PostUrl.Length;
                Stream stream = webRequest.GetRequestStream();
                stream.Write(PostUrl, 0, PostUrl.Length);
                stream.Flush();
                stream.Close();
                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                return responseData;
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }


        }
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="_server"></param>
        /// <param name="_to"></param>
        /// <param name="_subject"></param>
        /// <param name="_body"></param>
        /// <param name="_from"></param>
        /// <param name="_frompassword"></param>
        /// <returns></returns>
        /// ValidateHelper.SendMail("smtp.exmail.qq.com", email, "无锡动物园·欢乐园", sbhtml.ToString(), "sdm@creatrue.com", "Ab123465");
        public static bool SendMail(string _server, string _to, string _subject, string _body, string _from, string _frompassword)
        {
            MailMessage mailObj = new MailMessage(_from, _to);

            SmtpClient smtp1 = new SmtpClient();
            smtp1.Host = _server;
            smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp1.Credentials = new System.Net.NetworkCredential(_from, _frompassword);
            //("mail.wxytz.com", "zyf@creatrue.com", "inquire", bodys, "web@wxytz.com", "Aa1234567980");
            mailObj.CC.Add("madaiwusi@126.com");
            mailObj.Subject = _subject;
            mailObj.Body = _body;
            mailObj.SubjectEncoding = System.Text.Encoding.UTF8;
            mailObj.BodyEncoding = System.Text.Encoding.UTF8;
            mailObj.IsBodyHtml = true;
            mailObj.Priority = MailPriority.High;
            try
            {
                smtp1.Send(mailObj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="toAddress"></param>
        /// <param name="content"></param>
        /// <param name="fromname"></param>
        /// <returns></returns>
        //public static string SendMail(string subject, string toAddress, string content, string fromname)
        //{
        //   object JMail = HttpContext.Current.Server.CreateObject("JMAIL.Message");
        //    JMail.Charset = "gb2312"; // 邮件字符集，默认为"US-ASCII"
        //    JMail.From = "web@wxytz.com"; // 发送者地址
        //    JMail.MailServerUserName = "web@wxytz.com"; // 身份验证的用户名
        //    JMail.MailServerPassWord = "Aa123567"; // 身份验证的密码
        //    JMail.FromName = fromname; // 发送者姓名
        //    JMail.Priority = 3; // 设置优先级，范围从1到5，越大的优先级越高，3为普通
        //    JMail.ContentType = "text/html";

        //    JMail.Subject = subject; // 邮件主题
        //    JMail.AddRecipient(toAddress); //收件人
        //    JMail.AddRecipient("madaiwusi@126.com"); //收件人
        //    JMail.AddRecipient("web@wxytz.com"); //收件人
        //    JMail.Body = content;

        //    JMail.Send("mail.wxytz.com");
        //    JMail.Close();
        //    JMail = Nothing;
        //    return "ok";
        //} 
     
        #endregion

        #region 发送邮件
        ///// <summary>
        ///// 发送邮件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="senderMail"></param>
        ///// <param name="receiver"></param>
        ///// <param name="subject"></param>
        ///// <param name="content"></param>
        ///// <returns></returns>
        //public static string SendMail(String sender, String senderMail, String receiver, String subject, String content)
        //{

        //    jmail.MessageClass jmMessage = new jmail.MessageClass();

        //    //设置字符集

        //    jmMessage.Charset = "gb2312";

        //    //发件人邮箱地址

        //    jmMessage.From = senderMail;

        //    //发件人姓名

        //    jmMessage.FromName = sender;

        //    //设置主题

        //    jmMessage.Subject = subject;

        //    //设置内容

        //    jmMessage.Body = content;

        //    // 设置收件人邮箱

        //    jmMessage.AddRecipient(receiver, "", "");

        //    // 设置登陆邮箱的用户名和密码

        //    jmMessage.MailServerUserName = "ss";

        //    jmMessage.MailServerPassWord = "ss";

        //    //设置smtp服务器地址

        //    if (jmMessage.Send("smtp.163.com", false))
        //    {

        //        //Response.Write("<script>alert('发送成功')</script>");

        //    }

        //    else { }
        //    return null;
        //    //Response.Write("<script>alert('发送失败')</script>");

        //} 
        #endregion

    }
}
