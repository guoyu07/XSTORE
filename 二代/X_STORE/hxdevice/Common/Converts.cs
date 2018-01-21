﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTcpClient.Common
{
    public class Converts
    {
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

        /// <summary>
        /// 字符串转ascii
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] GetASSIC(string bytes)
        {
            byte[] _tpandmac = null;
            bytes = bytes.Replace("：", "");//去除16进制数据中所有冒号
            bytes = bytes.Replace(":", "");//去除16进制数据中所有冒号
            bytes = bytes.Replace(" ", "");//去除16进制数据中所有空格
            bytes = bytes.Replace(".", "");//去除16进制数据中所有冒号
            bytes = bytes.Replace("\r", "");//去除16进制数据中所有换行
            bytes = bytes.Replace("\n", "");//去除16进制数据中所有换行
            if (bytes.Length == 1)//数据长度为1的时候，在数据前补0
            {
                bytes = "0" + bytes;
            }
            else if (bytes.Length % 2 != 0)//数据长度为奇数位时，去除最后一位数据
            {
                bytes = bytes.Remove(bytes.Length - 1, 1);
            }

            List<string> sendData16 = new List<string>();//将发送的数据，2个合为1个，然后放在该缓存里 如：123456→12,34,56
            for (int i = 0; i < bytes.Length; i += 2)
            {
                sendData16.Add(bytes.Substring(i, 2));
            }
            _tpandmac = new byte[sendData16.Count];//sendBuffer的长度设置为：发送的数据2合1后的字节数
            for (int i = 0; i < sendData16.Count; i++)
            {
                _tpandmac[i] = (byte)(System.Convert.ToInt32(sendData16[i], 16));//发送数据改为16进制
            }

            return _tpandmac;

        }


        #region CRC16查表法

        #region CRC对应表
        //高位表
        readonly static byte[] CRCHigh = new byte[]{
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 
            0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 
            0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 
            0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 
            0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40};
        //低位表
        readonly static byte[] CRCLow = new byte[]{
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 
            0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 
            0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 
            0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4, 
            0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3, 
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 
            0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 
            0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 
            0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED, 
            0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26, 
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 
            0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 
            0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 
            0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 
            0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5, 
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 
            0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 
            0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 
            0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B, 
            0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C, 
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 
            0x43, 0x83, 0x41, 0x81, 0x80, 0x40};
        #endregion

        /// <summary>
        /// 计算CRC16循环校验码
        /// </summary>
        /// <param name="Cmd">命令数组</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns>高低位校验码</returns>
        public static byte[] GetCRC16(byte[] Cmd, bool IsHighBefore)
        {
            int index;
            int crc_Low = 0xFF;
            int crc_High = 0xFF;
            for (int i = 0; i < Cmd.Length; i++)
            {
                index = crc_High ^ (char)Cmd[i];
                crc_High = crc_Low ^ CRCHigh[index];
                crc_Low = (byte)CRCLow[index];
            }
            if (IsHighBefore == true)
            {
                return new byte[2] { (byte)crc_High, (byte)crc_Low };
            }
            else
            {
                return new byte[2] { (byte)crc_Low, (byte)crc_High };
            }
        }

        /// <summary>
        /// 计算CRC16循环校验码（返回包含校验码的完整命令数组）
        /// </summary>
        /// <param name="Cmd">命令数组</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns></returns>
        public static byte[] GetCRC16Full(byte[] Cmd, bool IsHighBefore)
        {
            byte[] check = GetCRC16(Cmd, IsHighBefore);
            List<byte> newCmd = new List<byte>();
            newCmd.AddRange(Cmd);
            newCmd.AddRange(check);
            return newCmd.ToArray();
        }
        #endregion

        #region 多项式参数 CRC16计算
        /// <summary>
        /// 多项式参数 CRC16计算
        /// </summary>
        /// <param name="Cmd">命令</param>
        /// <param name="Poly">多项式</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns></returns>
        public static byte[] GetCRC16ByPoly(byte[] Cmd, ushort Poly, bool IsHighBefore)
        {
            byte[] CRC = new byte[2];
            ushort CRCValue = 0xFFFF;
            for (int i = 0; i < Cmd.Length; i++)
            {
                CRCValue = (ushort)(CRCValue ^ Cmd[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((CRCValue & 0x0001) != 0)
                    {
                        CRCValue = (ushort)((CRCValue >> 1) ^ Poly);
                    }
                    else
                    {
                        CRCValue = (ushort)(CRCValue >> 1);
                    }
                }
            }
            byte[] Check = BitConverter.GetBytes(CRCValue);
            if (IsHighBefore == true)
            {
                return new byte[2] { Check[1], Check[0] };
            }
            else
            {
                return Check;
            }
        }

        /// <summary>
        /// 多项式参数 CRC16计算
        /// </summary>
        /// <param name="Cmd">命令</param>
        /// <param name="Poly">多项式</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns></returns>
        public static byte[] GetCRC16ByPolyFull(byte[] Cmd, ushort Poly, bool IsHighBefore)
        {
            byte[] check = GetCRC16ByPoly(Cmd, Poly, IsHighBefore);
            List<byte> newCmd = new List<byte>();
            newCmd.AddRange(Cmd);
            newCmd.AddRange(check);
            return newCmd.ToArray();
        }
        #endregion
        public static byte[] StringToByte(string hexString)
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
        /// 相加取和，得到两个字节的字节数组"EF3DD6FFA6"=》"3A7"
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] GetCRCSUM(byte[] data)
        {
            byte[] result = new byte[2];
            Int32 intsum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                intsum += data[i];
            }
            int height = (intsum % 65536) / 256;
            int low = (intsum % 65536) % 256;
            result[0] = (byte)(height);
            result[1] = (byte)(low);
            return result;
        }
    }
}
