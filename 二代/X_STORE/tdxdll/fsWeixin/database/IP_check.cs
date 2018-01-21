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
using System.Net;
using System.Collections.Generic;

namespace tdx.database
{
    public class IP_check
    {
        //定义允许的IP端，格式如下
        private string[] AllowIPRanges = { "10.0.0.0-10.255.255.255", "172.16.0.0-172.31.255.255", "192.168.0.0-192.168.255.255" };

        ////主函数，调用判断接口
        //static void Main(string[] args)
        //{

        //    //判断192.168.100.0这个ip是否在指定的IP范围段内
        //    //就这个范围而言，如果把IP转换成long型的 那么192.167.0.0这个IP 将在10.0.0.0-10.255.255.255这个范围内，但实际上这是错误的。还希望高手指点将ip转换为long的内幕
        //    Console.WriteLine(TheIpIsRange("192.169.100.0", AllowIPRanges));
        //    Console.WriteLine("Done");
        //    Console.Read();
        //}

        public void setAllowIPRanges(string[] _param)
        {
            AllowIPRanges = _param;
        }


        //接口函数 参数分别是你要判断的IP  和 你允许的IP范围
        //（已经重载）
        //（允许同时指定多个数组）

        public bool TheIpIsRange(string ip, params string[] ranges)
        {
            bool tmpRes = false;
            foreach (var item in ranges)
            {
                if (TheIpIsRange(ip, item))
                {
                    tmpRes = true; break;
                }
            }

            return tmpRes;
        }

        /// <summary>
        /// 判断指定的IP是否在指定的IP范围内   这里只能指定一个范围
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="ranges"></param>
        /// <returns></returns>
        private bool TheIpIsRange(string ip, string ranges)
        {
            bool result = false;

            int count;
            string start_ip, end_ip;
            //检测指定的IP范围 是否合法
            TryParseRanges(ranges, out count, out start_ip, out end_ip);//检测ip范围格式是否有效

            if (ip == "::1") ip = "127.0.0.1";

            try
            {
                IPAddress.Parse(ip);//判断指定要判断的IP是否合法
            }
            catch (Exception)
            {
                throw new ApplicationException("要检测的IP地址无效");
            }

            if (count == 1 && ip == start_ip) result = true;//如果指定的IP范围就是一个IP，那么直接匹配看是否相等
            else if (count == 2)//如果指定IP范围 是一个起始IP范围区间
            {
                byte[] start_ip_array = Get4Byte(start_ip);//将点分十进制 转换成 4个元素的字节数组
                byte[] end_ip_array = Get4Byte(end_ip);
                byte[] ip_array = Get4Byte(ip);

                bool tmpRes = true;
                for (int i = 0; i < 4; i++)
                {
                    //从左到右 依次比较 对应位置的 值的大小  ，一旦检测到不在对应的范围 那么说明IP不在指定的范围内 并将终止循环
                    if (ip_array[i] > end_ip_array[i] || ip_array[i] < start_ip_array[i])
                    {
                        tmpRes = false; break;
                    }
                }
                result = tmpRes;
            }

            return result;
        }

        //尝试解析IP范围  并获取闭区间的 起始IP   (包含)
        private void TryParseRanges(string ranges, out int count, out string start_ip, out string end_ip)
        {
            string[] _r = ranges.Split('-');
            if (!(_r.Count() == 2 || _r.Count() == 1))
                throw new ApplicationException("IP范围指定格式不正确，可以指定一个IP，如果是一个范围请用“-”分隔");

            count = _r.Count();

            start_ip = _r[0];
            end_ip = "";
            try
            {
                IPAddress.Parse(_r[0]);
            }
            catch (Exception)
            {
                throw new ApplicationException("IP地址无效");
            }

            if (_r.Count() == 2)
            {
                end_ip = _r[1];
                try
                {
                    IPAddress.Parse(_r[1]);
                }
                catch (Exception)
                {
                    throw new ApplicationException("IP地址无效");
                }
            }
        }
        
        /// <summary>
        /// 将IP四组值 转换成byte型
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        byte[] Get4Byte(string ip)
        {
            string[] _i = ip.Split('.');

            List<byte> res = new List<byte>();
            foreach (var item in _i)
            {
                res.Add(Convert.ToByte(item));
            }

            return res.ToArray();
        }
    }
}
