using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTcpClient.Common
{
    public class EnumType
    {
        /// <summary>
        /// 命令编码格式
        /// </summary>
        public enum DataEncode
        {
            Hex,
            ASCII,
            UTF8,
            GB2312
        }
        const bool isTest = true;
       public static string GetIP(bool withTitle)
        {
            if (isTest)
            {
                if (withTitle)
                    return "测试版(139.199.160.173)";
                else
                    return "139.199.160.173";
            }
            else
            {
                if (withTitle)
                    return "运营版(119.29.94.189)";
                else
                    return "119.29.94.189";
            }
        }
       public static string GetUrl()
       {
           if (isTest)
                return "http://x.x-store.com.cn?serialNumber=";
           else
                return "http://wx.x-store.com.cn?serialNumber=";
       }
    }
}
