using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tdx.kernel
{
public static class comEncrypt
{
    ///'通用加密类，提供各种加密和解密方式

    /// <summary>
    /// 加密函数
    /// </summary>
    /// <param name="Text">未加密的字符串</param>
    /// <returns>已经加密的字符串</returns>
    /// <remarks></remarks>
    public static string jiami(string Text)
    {
        Text = Text.ToLower();
        string sKey = "creatrue.madaiwusi";//?
        System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
        byte[] inputByteArray = null;
        inputByteArray = System.Text.Encoding.Default.GetBytes(Text);
        des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring (8));
        des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring (8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        System.Text.StringBuilder ret = new System.Text.StringBuilder();
        byte b = 0;
        foreach (byte b_loopVariable in ms.ToArray())
        {
            b = b_loopVariable;
            ret.AppendFormat("{0:X2}", b);
        }
        return ret.ToString();
    }

    /// <summary>
    /// 解密函数
    /// </summary>
    /// <param name="Text">已经加密之后的字符串</param>
    /// <returns>解密的字符串</returns>
    /// <remarks></remarks>
    public static string jiemi(string Text)
    {
        if (string.IsNullOrEmpty(Text))
            return "";
        System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
        int len = 0;
        string sKey = "creatrue.madaiwusi";
        len = Text.Length / 2 - 1;
        byte[] inputByteArray = new byte[len + 1];
        int x = 0;
        int i = 0;
        for (x = 0; x <= len; x++)
        {
            i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
            inputByteArray[x] = Convert.ToByte(i);
        }
        des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring (8));
        des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring (8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return System.Text.Encoding.Default.GetString(ms.ToArray());
    }

    /// <summary>
    /// 获得MD5代码
    /// </summary>
    /// <param name="StrValue">要校验的字符串</param>
    /// <returns>36位的md5代码</returns>
    /// <remarks></remarks>
    public static string GetMD5(string StrValue)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(StrValue, "md5");
    }
    /// <summary>
    /// 获得16位md5值
    /// </summary>
    /// <param name="strvalue">要校验的字符串</param>
    /// <returns>16位的md5代码</returns>
    /// <remarks></remarks>
    public static string Get16MD5(string strvalue)
    {
        return GetMD5(strvalue).Substring(8, 16);
    }

    /// <summary>
    /// 获得随机Guid
    /// </summary>
    /// <returns>返回36位的Guid</returns>
    /// <remarks></remarks>
    public static string GetGuid()
    {
        return System.Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 获得32位的Guid
    /// </summary>
    public static string GetGuid32()
    {
        return System.Guid.NewGuid().ToString().Replace("-", "");
    }

    public static string GetDateRndNumber()
    {
        DateTime todayNow = System.DateTime.Now;
        Random rnd = new Random();
        string _rnd = rnd.Next(1000, rnd.Next(1000,9999)).ToString();
        return (todayNow.Year.ToString()) + (todayNow.Month < 10 ? ("0" + todayNow.Month.ToString()) : todayNow.Month.ToString()) + (todayNow.Day < 10 ? ("0" + todayNow.Day.ToString()) : todayNow.Day.ToString()) + (todayNow.Hour < 10 ? ("0" + todayNow.Hour.ToString()) : todayNow.Hour.ToString()) + (todayNow.Minute < 10 ? ("0" + todayNow.Minute.ToString()) : todayNow.Minute.ToString()) + (todayNow.Second < 10 ? ("0" + todayNow.Second.ToString()) : todayNow.Second.ToString()) + _rnd;
    }

    /// <summary>
    /// 返回8位小写+数字随机密码
    /// </summary>
    public static string GetRndPassword()
    {
        string[] s = {
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"a",
			"b",
			"c",
			"d",
			"e",
			"f",
			"g",
			"h",
			"i",
			"j",
			"k",
			"m",
			"n",
			"p",
			"q",
			"r",
			"s",
			"t",
			"u",
			"v",
			"w",
			"x",
			"y",
			"z"
		};
        Random r = new Random();
        return s[r.Next(0, s.Length)].ToString() + s[r.Next(0, s.Length)].ToString() + s[r.Next(0, s.Length)].ToString() + s[r.Next(0, s.Length)].ToString() + s[r.Next(0, s.Length)].ToString() + s[r.Next(0, s.Length)].ToString() + s[r.Next(0, s.Length)].ToString() + s[r.Next(0, s.Length)].ToString();
    }

    /// <summary>
    /// 执行Base64加密
    /// </summary>
    /// <param name="Text">需要加密的文本</param>
    public static string setBase64(string Text)
    {
        return Convert.ToBase64String(System.Text.Encoding.GetEncoding("utf-8").GetBytes(Text));
    }

    /// <summary>
    ///  执行Base64解密
    /// </summary>
    /// <param name="Text">需要解密的文本</param>
    public static string getBase64(string Text)
    {
        return System.Text.Encoding.GetEncoding("utf-8").GetString(Convert.FromBase64String(Text));
    }

    /// <summary>
    /// 执行Url的gb2312加密
    /// </summary>
    /// <param name="Text">需要加密的文本</param>
    public static string Url_jiami_gb2312(string Text)
    {
        return System.Web.HttpUtility.UrlEncode(Text, System.Text.Encoding.GetEncoding("GB2312"));
    }

    /// <summary>
    /// 执行Url的gb2312解密
    /// </summary>
    /// <param name="Text">需要解密的文本</param>
    public static string Url_jiemi_gb2312(string Text)
    {
        return System.Web.HttpUtility.UrlDecode(Text, System.Text.Encoding.GetEncoding("GB2312"));
    }
    /// <summary>
    /// 执行Url的utf-8加密
    /// </summary>
    /// <param name="Text">需要加密的文本</param>
    public static string Url_jiami_utf8(string Text)
    {
        return System.Web.HttpUtility.UrlEncode(Text, System.Text.Encoding.GetEncoding("utf-8"));
    }

    /// <summary>
    /// 执行Url的utf-8解密
    /// </summary>
    /// <param name="Text">需要解密的文本</param>
    public static string Url_jiemi_utf8(string Text)
    {
        return System.Web.HttpUtility.UrlDecode(Text, System.Text.Encoding.GetEncoding("utf-8"));
    }

}

}