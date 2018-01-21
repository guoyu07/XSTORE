using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatrue.Common
{
    public class ConvertHelper
    {
        #region 16进制的格式转换相关的类
        private void Test()
        {
            byte[] data = { 0x3e, 0xfc, 0x23, 0xef };
            string ss = ByteToHexString(data);//3EFC23EF
            string bb = ByteToHexStringWith0X(data);//0X3E 0XFC 0X23 0XEF
            byte[] datanew = HexStringToByte(ss);//"3efc23ef"转成{62,252,35,239},即{ 0x3e,0xfc,0x23,0xef};//值是一样的，只是表示的进制不同
            byte[] data2 = System.Text.UTF8Encoding.ASCII.GetBytes("I Love You");//{73,32,76,111,118,101,32,89,111,117}得到对应的ASCII码值。
            string str = System.Text.UTF8Encoding.ASCII.GetString(data2);//还原为I Love You
        }
        /// <summary>
        /// 字节数组转换成大写的一组16进制形式的字符串。比如：{0x2C,0xD7}转换成"2CD7"
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteToHexString(byte[] data)
        {
            StringBuilder dataString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                dataString.AppendFormat("{0:x2}", data[i]);
            }
            return dataString.ToString().Trim().ToUpper();
        }
        /// <summary>
        /// 字节数组转换成大写的一组16进制形式的字符串。比如：{0x2C,0xD7}转换成"0X2C 0XD7"，加了分隔符方便查阅
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteToHexStringWith0X(byte[] data)
        {
            StringBuilder dataString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                dataString.AppendFormat("0X{0:x2} ", data[i]);
            }
            return dataString.ToString().Trim().ToUpper();
        }
        /// <summary>
        /// 大写的一组16进制形式的字符串转成字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexStringToByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 将string转换成指定编码格式的数组。目前支持HEX,ASCII,UTF8,GB2312。HEX需以空格隔开
        /// </summary>
        /// <param name="_EncodeType"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] ByteToStringWithEncoding(DataEncode _EncodeType, string str)
        {
            byte[] data = null;
            switch (_EncodeType)
            {
                case DataEncode.Hex:
                    string[] HexStr = str.Trim().Split(' ');
                    data = new byte[HexStr.Length];
                    for (int i = 0; i < HexStr.Length; i++)
                    {
                        data[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
                    }
                    break;
                case DataEncode.ASCII:
                    data = new ASCIIEncoding().GetBytes(str);
                    break;
                case DataEncode.UTF8:
                    data = new UTF8Encoding().GetBytes(str);
                    break;
                case DataEncode.GB2312:
                    data = Encoding.GetEncoding("GB2312").GetBytes(str);
                    break;
                default: break;
            }
            return data;
        }

        /// <summary>
        /// 将指定编码格式的数组转换成string。目前支持HEX,ASCII,UTF8,GB2312。HEX以空格隔开
        /// </summary>
        /// <param name="_EncodeType"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string StringToByteWithEncoding(DataEncode _EncodeType, byte[] data)
        {
            string strResult = "";
            switch (_EncodeType)
            {
                case DataEncode.Hex:
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.AppendFormat("{0:x2} ", data[i]);
                    }
                    strResult = sb.ToString().Trim().ToUpper();
                    break;
                case DataEncode.ASCII:
                    strResult = new ASCIIEncoding().GetString(data);
                    break;
                case DataEncode.UTF8:
                    strResult = new UTF8Encoding().GetString(data);
                    break;
                case DataEncode.GB2312:
                    strResult = Encoding.GetEncoding("GB2312").GetString(data);
                    break;
            }
            return strResult;
        }


        /// <summary>
        /// 获取6字节的时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static byte[] DateTimeToBytes()
        {
            DateTime dt = DateTime.Now;
            byte[] bytes = new byte[6];
            if (dt != null)
            {
                bytes[0] = Convert.ToByte(dt.Year.ToString().Substring(2, 2), 16);
                bytes[1] = Convert.ToByte(dt.Month.ToString(), 16);
                bytes[2] = Convert.ToByte(dt.Day.ToString(), 16);
                bytes[3] = Convert.ToByte(dt.Hour.ToString(), 16);
                bytes[4] = Convert.ToByte(dt.Minute.ToString(), 16);
                bytes[5] = Convert.ToByte(dt.Second.ToString(), 10);
            }
            return bytes;
        }
        static public char[] StringToCharArray(string str)
        {
            char[] result = new char[str.Length];
            int i = 0;
            foreach (char ch in str)
            {
                result[i] = ch;
                i++;
            }
            return result;
        }
        static public byte[] StringToByteArray(string str)
        {
            try
            {
                byte[] result = System.Text.Encoding.ASCII.GetBytes(str);
                return result;
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// char里的ASCII字符转成byte数组。即0<char<128时直接转byte,包含大于127的（非ASSIC码）则返回空
        /// </summary>
        /// <param name="chararr"></param>
        /// <returns></returns>
        static public byte[] CharArrayToByteArray(char[] chararr)
        {
            byte[] result = new byte[chararr.Length];
            int i = 0;
            foreach (char cha in chararr)
            {
                if (cha < 128)
                {
                    result[i] = (byte)cha; i++;
                }

                else
                    return null;
            }
            return result;

        }
        static public string CharArrayToString(char[] array)
        {
            string result;
            StringBuilder sbstr = new StringBuilder();
            foreach (char ch in array)
            {
                sbstr.Append(ch);
            }
            result = sbstr.ToString();
            return result;
        }
        static public string ByteArrayToString(byte[] array)
        {
            string result;
            StringBuilder sbstr = new StringBuilder();
            foreach (byte ch in array)
            {
                sbstr.Append((char)ch);
            }
            result = sbstr.ToString();
            return result;
        }
        public enum DataEncode
        {
            Hex,
            ASCII,
            UTF8,
            GB2312
        }
        #endregion
    }
}
