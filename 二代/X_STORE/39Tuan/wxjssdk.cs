using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using DTcms.DBUtility;
using Tuan;
using Newtonsoft.Json.Linq;
using System.Web.Security;
/// 

/// WXJSSDK 的摘要说明
/// 
public class WXJSSDK
{
    private string appId;
    private string appSecret;
    private DataTable DT;
    Chat chat = new Chat();
    public WXJSSDK(string appId, string appSecret)
    {
        this.appId = appId;
        this.appSecret = appSecret;
    }
    //得到数据包，返回使用页面  
    public System.Collections.Hashtable getSignPackage()
    {
        //string urlquerystring = HttpContext.Current.Request.Url.Query;
        //string urlpath = HttpContext.Current.Request.Url.AbsoluteUri;
        string jsapiTicket = getJsApiTicket();
        string url = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
        
            // //"http://hongdou.creatrue.net/tuan/index.aspx?attach=::"+""+index.spbhurl+"";
        string timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
        string nonceStr = createNonceStr();
        // 这里参数的顺序要按照 key 值 ASCII 码升序排序  
        string rawstring = "jsapi_ticket=" + jsapiTicket + "&noncestr=" + nonceStr + "&timestamp=" + timestamp + "&url=" + url + "";
        string signature = SHA1_Hash(rawstring);
        System.Collections.Hashtable signPackage = new System.Collections.Hashtable();
        signPackage.Add("appId", appId);
        signPackage.Add("nonceStr", nonceStr);
        signPackage.Add("timestamp", timestamp);
        signPackage.Add("url", url);
        signPackage.Add("signature", signature);
        signPackage.Add("rawString", rawstring);
        return signPackage;
    }
    //创建随机字符串  
    private string createNonceStr()
    {
        int length = 16;
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string str = "";
        Random rad = new Random();
        for (int i = 0; i < length; i++)
        {
            str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
        }
        return str;
    }
    //得到ticket 如果文件里时间 超时则重新获取
    //注：jsapi_ticket使用规则（有过期时间）类似access_token, oauth的access_token与基础access_token不同
    private string getJsApiTicket()
    {
        //这里我从数据库读取
        int wxid = index.wxid;
        chat.wxid = index.wxid;
        DT = DbHelperSQL.Query("select jsapi_ticket,ticket_expires from TM_Ticket where wxid=" + wxid + "").Tables[0];
        string accessToken = chat.access_token();//获取系统的全局token 
        string ticket = "";
        int expire_time = 0;
        if (DT.Rows.Count > 0)
        {
             expire_time = (int)DT.Rows[0]["ticket_expires"];
             ticket = DT.Rows[0]["jsapi_ticket"].ToString();
            if (expire_time < ConvertDateTimeInt(DateTime.Now))
            {
                string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + accessToken + "";
                JObject  api =(JObject)JsonConvert.DeserializeObject(httpGet(url));
                ticket = api["ticket"].ToString();
                if (ticket != "")
                {
                    expire_time = ConvertDateTimeInt(DateTime.Now) + 7000;
                    //存入数据库操作

                    DbHelperSQL.ExecuteSql("update  TM_Ticket set jsapi_ticket='" + ticket + "',ticket_expires='" + expire_time + "' where wxid=" + wxid + "");
                }
            }
        }
        else
        {
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + accessToken + "";
            JObject api = (JObject)JsonConvert.DeserializeObject(httpGet(url));
            ticket = api["ticket"].ToString();
            if (ticket != "")
            {
                 expire_time = ConvertDateTimeInt(DateTime.Now) + 7000;
                //存入数据库操作

                 DbHelperSQL.ExecuteSql("insert into  TM_Ticket values('" + ticket + "','" + expire_time + "'," + wxid + ")");
            }
        }
        return ticket;
    }

    //发起一个http请球，返回值  
    private string httpGet(string url)
    {
        try
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据  
            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据  
            string pageHtml = System.Text.Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句              
            return pageHtml;
        }
        catch (WebException webEx)
        {
            Console.WriteLine(webEx.Message.ToString());
            return null;
        }
    }
    //SHA1哈希加密算法  
    public string SHA1_Hash(string str_sha1_in)
    {
        //SHA1 sha1 = new SHA1CryptoServiceProvider();
        //byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
        //byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
        //string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
        //str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
        //return str_sha1_out;
        
        string addrSign = FormsAuthentication.HashPasswordForStoringInConfigFile(str_sha1_in, "SHA1");
       addrSign= addrSign.ToLower();
        return addrSign;
    }
    /// 
  
    /// StreamWriter写入文件方法  
    /// 
  
    private void StreamWriterMetod(string str, string patch)
    {
        try
        {
            FileStream fsFile = new FileStream(patch, FileMode.OpenOrCreate);
            StreamWriter swWriter = new StreamWriter(fsFile);
            swWriter.WriteLine(str);
            swWriter.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    /// 
  
    /// 将c# DateTime时间格式转换为Unix时间戳格式  
    /// 
  
    /// 时间  
    /// double  
    public int ConvertDateTimeInt(System.DateTime time)
    {
        int intResult = 0;
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        intResult = Convert.ToInt32((time - startTime).TotalSeconds);
        return intResult;
    }
}
//创建Json序列化 及反序列化类目  
#region
//创建JSon类 保存文件 jsapi_ticket.json  
public class JSTicket
{
    public string jsapi_ticket { get; set; }
    public double expire_time { get; set; }
}
//创建 JSon类 保存文件 access_token.json  
public class AccToken
{
    public string access_token { get; set; }
    public double expires_in { get; set; }
}
//创建从微信返回结果的一个类 用于获取ticket  
public class Jsapi
{
    public int errcode { get; set; }
    public string errmsg { get; set; }
    public string ticket { get; set; }
    public string expires_in { get; set; }
}
#endregion  