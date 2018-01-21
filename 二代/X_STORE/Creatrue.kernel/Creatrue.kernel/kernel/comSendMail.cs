using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Web;

namespace Creatrue.kernel
{
    /// <summary>
    /// 发送邮件程序。
    /// </summary>
    /// <remarks></remarks>

    public class comSendMail
    {
        public static bool sendMail(string _server, string _to, string _subject, string _body, string _from, string _frompassword)
        {
            MailMessage mailObj = new MailMessage(_from, _to);
            SmtpClient smtp1 = new SmtpClient(_server);
            smtp1.Host = _server;
            smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp1.Credentials = new System.Net.NetworkCredential(_from, _frompassword);

            //  mailObj.CC.Add("40090508@qq.com");
            // mailObj.CC.Add("hollybird@126.com");
            mailObj.Subject = _subject;
            mailObj.Body = _body;
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
        public static bool tdxsendMail(string _to, string _subject, string _body)
        {
            MailMessage mailObj = new MailMessage("weixin@duoge.com.cn", _to);
            //  mailObj.Sender =  new MailAddress("baoshijieminhang@sina.com", "上海闵行保时捷中心服务号",Encoding.UTF8);
            mailObj.From = new MailAddress("weixin@duoge.com.cn", "天地行微信网站系统", Encoding.UTF8);
            //      SmtpClient smtp1 = new SmtpClient("smtp.sina.com.cn");
            SmtpClient smtp1 = new SmtpClient("smtp.exmail.qq.com ");
            //smtp1.Host = "smtp.sina.com.cn";
            //   smtp1.Port = 465;
            // smtp1.EnableSsl = true;
            smtp1.Host = "smtp.exmail.qq.com ";
            smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;

            // smtp1.Credentials = new System.Net.NetworkCredential("tdx_weixin@sina.com", "Aa123465");
            smtp1.Credentials = new System.Net.NetworkCredential("weixin@duoge.com.cn", "shenkai123");

            //  mailObj.CC.Add("40090508@qq.com");
            // mailObj.CC.Add("hollybird@126.com");
            mailObj.Subject = _subject;
            mailObj.Body = _body;
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
                comfun.ChuliException(ex, "comSendMailtdxsendMail", "000");
                return false;
            }
        }
        public static bool bsjsendMail(string _to, string _subject, string _body)
        {
            MailMessage mailObj = new MailMessage("baoshijieweixin@126.com", _to);
            //  mailObj.Sender =  new MailAddress("baoshijieminhang@sina.com", "上海闵行保时捷中心服务号",Encoding.UTF8);
            mailObj.From = new MailAddress("baoshijieweixin@126.com", "上海闵行保时捷中心服务号", Encoding.UTF8);
            SmtpClient smtp1 = new SmtpClient("smtp.126.com");
            smtp1.Host = "smtp.126.com";
            smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp1.Credentials = new System.Net.NetworkCredential("baoshijieweixin@126.com", "Aa123456");

            //  mailObj.CC.Add("40090508@qq.com");
            // mailObj.CC.Add("hollybird@126.com");
            mailObj.Subject = _subject;
            mailObj.Body = _body;
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
                comfun.ChuliException(ex, "comSendMailbsjsendMail", "000");
                return false;
            }
        }
        public static bool sendMail(string _server, string _to, string _subject, string _body, string _from, string _frompassword, string _replyto)
        {
            MailMessage mailObj = new MailMessage(_from, _to);

            SmtpClient smtp1 = new SmtpClient(_server);
            smtp1.Host = _server;
            smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp1.Credentials = new System.Net.NetworkCredential(_from, _frompassword);

            //mailObj.CC.Add("ad@wd-bearing.com");
            mailObj.CC.Add("hollybird@126.com");
            mailObj.ReplyTo = (new MailAddress(_replyto));
            mailObj.Subject = _subject;
            mailObj.Body = _body;
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

        public static string comSMS(string _tel, string _content)
        {
            try
            {
                string url = "http://notice.zuitu.com/sms?user=madaiwusi&pass=" + comEncrypt.GetMD5("zhaoguangtou") + "&phones=" + _tel + "&content=" + _content;
                HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                webRequest.Method = "GET";
                webRequest.ServicePoint.Expect100Continue = false;
                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                return responseData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static int comSMS(string _tel, string _content, int _uid, string _uname)
        {
            int resultI = 0;//发送错误信息的条数.如果result为0，则全部发送成功,最好的状态.
            string resultErr = ""; //错误信息
            //拆分号码:多个号码拆分开
            //拆分短信:如果短信字符超过67个,则分成几条
            int maxLen = 67;
            maxLen = maxLen - _uname.Length - 2;
            if ((_content.Length + _uname.Length + 2) > maxLen)
            {   //如果短信内容超出最大长度，则进行拆分
                maxLen = maxLen - 5;
                int totalcount = _content.Length;
                int totalpage = totalcount / maxLen;
                if (totalcount % maxLen != 0)
                    totalpage++;
                for (int tmpi = 0; tmpi < totalpage; tmpi++)
                {
                    string tmp_content = "";
                    if ((tmpi * maxLen + maxLen) < totalcount)
                    {
                        tmp_content = "(" + (tmpi + 1) + "/" + totalpage + ")" + _content.Substring(tmpi * maxLen, maxLen) + "【" + _uname + "】";
                    }
                    else
                    {
                        tmp_content = "(" + (tmpi + 1) + "/" + totalpage + ")" + _content.Substring(tmpi * maxLen, totalcount - tmpi * maxLen) + "【" + _uname + "】";
                    }
                    //然后再逐条执行写入日志,发送短信
                    string err_msg = comSMS(_tel, tmp_content);
                    if (err_msg == "+OK")
                    {
                        writeSMSLogs(_tel, tmp_content, _uid);
                    }
                    else
                    {
                        resultI = resultI + 1;
                        resultErr = resultErr + err_msg;
                    }
                }
            }
            else
            {//不超过长度直接发送
                string tmp_content = _content + "【" + _uname + "】";
                string err_msg = comSMS(_tel, tmp_content);
                if (err_msg == "+OK")
                {
                    writeSMSLogs(_tel, tmp_content, _uid);
                }
                else
                {
                    resultI = resultI + 1;
                    resultErr = resultErr + err_msg;
                }
            }
            return resultI;
        }

        public static int writeSMSLogs(string _tel, string _content, int _uid)
        {
            string sql = "insert into B2C_SMS_log(uid,sms_no,sms_content) values (@uid,@tel,@content)";
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection("Data Source=dx.creatrue.net,2005;Initial Catalog=fsxoom;Persist Security Info=True;User ID=fsxoom;Password=13912278478;Connect Timeout=100");
            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandText = sql;
            dbCommand.Connection = dbConnection;
            System.Data.IDataParameter dbParam_uid = new System.Data.SqlClient.SqlParameter();
            dbParam_uid.ParameterName = "@uid";
            dbParam_uid.Value = _uid;
            dbParam_uid.DbType = System.Data.DbType.Int32;
            dbCommand.Parameters.Add(dbParam_uid);
            System.Data.IDataParameter dbParam_tel = new System.Data.SqlClient.SqlParameter();
            dbParam_tel.ParameterName = "@tel";
            dbParam_tel.Value = _tel;
            dbParam_tel.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_tel);
            System.Data.IDataParameter dbParam_content = new System.Data.SqlClient.SqlParameter();
            dbParam_content.ParameterName = "@content";
            dbParam_content.Value = _content;
            dbParam_content.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_content);

            int rowsAffected = 0;
            dbConnection.Open();
            try
            {
                rowsAffected = dbCommand.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
            return rowsAffected;
        }
    }
}