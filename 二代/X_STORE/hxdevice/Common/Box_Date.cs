using AsyncTcpClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hxdevice.Common
{
    public class Box_Date
    {
        byte[] date_flg = new byte[1] { 0X01 };//协议标志位，标识是否为客户端操作

        public byte[] Date_flg
        {
            get { return date_flg; }

        }
        byte[] date_start = new byte[2] { 0xEF, 0X02 };//数据帧头码(2Bytes)

        public byte[] Date_start
        {
            get { return date_start; }

        }
        byte[] date_length = new byte[1] { 0x25 };//数据帧字节数（1Bytes)

        public byte[] Date_length
        {
            get { return date_length; }

        }
        byte[] date_datetime = Converts.DateTimeToBytes();//new byte[6];//时间戳（6个字节）

        public byte[] Date_datetime
        {
            get { return date_datetime; }

        }


        byte[] date_functioncommandword = new byte[1];//功能命令字（1Bytes)（下标9）

        public byte[] Date_functioncommandword
        {
            get { return date_functioncommandword; }
            set { date_functioncommandword = value; }
        }
        byte[] date_mac = new byte[12];//12字节机柜的MAC

        public byte[] Date_mac
        {
            get { return date_mac; }
            set { date_mac = value; }
        }
        byte[] date_command = new byte[13];//控制对象的数据区

        public byte[] Date_command
        {
            get { return date_command; }
            set { date_command = value; }
        }
    }
}
