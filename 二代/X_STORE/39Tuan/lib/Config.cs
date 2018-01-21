using Tuan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.DBUtility;
using Creatrue.kernel;


namespace WxPayAPI
{
    /**
    * 	配置账号信息
    */
    public class WxPayConfig
    {
       
        //=======【基本信息设置】=====================================
        /* 微信公众号信息配置
        * APPID：绑定支付的APPID（必须配置）
        * MCHID：商户号（必须配置）
        * KEY：商户支付密钥，参考开户邮件设置（必须配置）
        * APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
        */

        //public static void main() 
        //{
        //    HttpContext.Current.Response.Write("<script>alert('apiconfig=" + index.wxid + "')</script>");
        //} 
        //static int wxid = index.wxid;
        //static int wxid2 = DingInfo.wxid;          
        //static int wxid = TestGetInfo.wxid;

        // public string  sql = "select * from wx_mp where id=" + (index.wxid == 0 ? (DingInfo.wxid == 0 ? 1 : DingInfo.wxid) : index.wxid) + "";
        //  DataTable dt = comfun.GetDataTableBySQL(sql);


        //public  string APPID = dt.Rows[0]["wx_DID"].ToString();//"wx752aa82143c09a8a";
        //public  string MCHID = dt.Rows[0]["MCHID"].ToString(); //"1248582501";
        //public  string KEY = dt.Rows[0]["APIKEY"].ToString();//"wuxishichuangkejiyouxiangongsi00";
        //public  string APPSECRET = dt.Rows[0]["wx_Dpsw"].ToString(); //"363e23b375797ad52fde0b829b6d41ff";

        public string APPID()
        { 
            string  sql = "select * from wx_mp where id=" + (index.wxid == 0 ? (DingInfo.wxid == 0 ? 1 : DingInfo.wxid) : index.wxid) + "";
          DataTable dt = comfun.GetDataTableBySQL(sql);
          if (dt.Rows.Count > 0)
          {
              return dt.Rows[0]["wx_DID"].ToString();
          }
          else
          {
              return "wx752aa82143c09a8a";
          }

        }

        public string MCHID()
        {
            string sql = "select * from wx_mp where id=" + (index.wxid == 0 ? (DingInfo.wxid == 0 ? 1 : DingInfo.wxid) : index.wxid) + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["MCHID"].ToString();
            }
            else
            {
                return "1248582501";
            }

        }

        public string KEY()
        {
            string sql = "select * from wx_mp where id=" + (index.wxid == 0 ? (DingInfo.wxid == 0 ? 1 : DingInfo.wxid) : index.wxid) + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["APIKEY"].ToString();
            }
            else
            {
                return "wuxishichuangkejiyouxiangongsi00";
            }

        }

        public string APPSECRET()
        {
            string sql = "select * from wx_mp where id=" + (index.wxid == 0 ? (DingInfo.wxid == 0 ? 1 : DingInfo.wxid) : index.wxid) + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["wx_Dpsw"].ToString();
            }
            else
            {
                return "363e23b375797ad52fde0b829b6d41ff";
            }

        }
   //public const string APPID = "wx752aa82143c09a8a";
   //public const string MCHID = "1248582501";
   //public const string KEY = "wuxishichuangkejiyouxiangongsi00";
   //public const string APPSECRET = "363e23b375797ad52fde0b829b6d41ff";

        //=======【证书路径设置】===================================== 
        /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
        */
        //public  string SSLCERT_PATH = dt.Rows[0]["SSLCERT_PATH"].ToString(); //"/tuan/cert/apiclient_cert.p12";
        //public  string SSLCERT_PASSWORD = dt.Rows[0]["SSLCERT_PASSWORD"].ToString();//"1248582501";

        public string SSLCERT_PATH()
        {
            string sql = "select * from wx_mp where id=" + (index.wxid == 0 ? (DingInfo.wxid == 0 ? 1 : DingInfo.wxid) : index.wxid) + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SSLCERT_PATH"].ToString();
            }
            else
            {
                return "/tuan/cert/certcn/apiclient_cert.p12";
            }

        }
        public string SSLCERT_PASSWORD()
        {
            string sql = "select * from wx_mp where id=" + (index.wxid == 0 ? (DingInfo.wxid == 0 ? 1 : DingInfo.wxid) : index.wxid) + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SSLCERT_PASSWORD"].ToString();
            }
            else
            {
                return "1248582501";
            }

        }
        //public const string SSLCERT_PATH = "/tuan/cert/apiclient_cert.p12";
        //public const string SSLCERT_PASSWORD = "1248582501";

        //=======【支付结果通知url】===================================== 
        /* 支付结果通知回调url，用于商户接收支付结果
        */
        public const string NOTIFY_URL = "http://hongdou.creatrue.net/tuan/Notity.aspx";

        //=======【商户系统后台机器IP】===================================== 
        /* 此参数可手动配置也可在程序中自动获取
        */
        public const string IP = "8.8.8.8";


        //=======【代理服务器设置】===================================
        /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
        */
        public const string PROXY_URL = "http://10.152.18.220:8080";

        //=======【上报信息配置】===================================
        /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
        */
        public const int REPORT_LEVENL = 1;

        //=======【日志级别】===================================
        /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
        */
        public const int LOG_LEVENL = 0;
    }
}