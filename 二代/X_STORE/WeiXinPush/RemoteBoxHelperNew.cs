using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WeiXinPush
{
    public class RemoteBoxHelperNew
    {
         //private ILogger Logger { get; }

        //public RemoteBoxHelper(ILogger logger)
        //{
        //    Logger = logger;
        //}
        private int port = 2758;
        private string ipAddress = "119.29.94.189";

        public Dictionary<string,bool> OpenRemoteBox( string serialNumber,string warehouseIndexs)
        {
            Log.WriteLog("类：RemoteBoxHelperNew", "方法：OpenRemoteBox", "serialNumber：" + serialNumber);
            if(string.IsNullOrEmpty(serialNumber))
                throw new Exception("序列号无效");

            if(string.IsNullOrEmpty(warehouseIndexs))
                throw new Exception("货箱序号无效");
            var list = warehouseIndexs.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries).Select(o=>int.Parse(o)).ToList();
            byte[] byte_open = new byte[12] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            
			for (int i = 0; i < list.Count; i++)
			{
			    byte_open[list[i]] = 0x01;
			}
			
            var logger = new StringBuilder();
            byte[] ping = Encoding.UTF8.GetBytes(serialNumber);
            var sendMessage = string.Format("{0}{1}{2}", "02", ByteToHexString(ping), ByteToHexString(byte_open));
            Log.WriteLog("发送：" + sendMessage, "", "");
            Dictionary<string,bool> result = new Dictionary<string, bool>();
            using (var tcpClient = new TcpClient(ipAddress, port))
            using (var ns = tcpClient.GetStream())
            {
                try
                {
                    var ipEndPoint = tcpClient.Client.RemoteEndPoint as IPEndPoint;
                    tcpClient.SendTimeout = 20000;
                    tcpClient.ReceiveTimeout = 20000;

                    #region 发送数据
                    if (ns.CanWrite)
                    {
                        var sendBytes = StringToByte(sendMessage);
                        ns.Write(sendBytes, 0, sendBytes.Length);
                        ns.Flush();
                    }

                    #endregion

                    #region 接收数据

                    if (ns.CanRead)
                    {
                        var bytes = new byte[50];
                        var length = ns.Read(bytes, 0, bytes.Length);
                        if (length > 0)
                        {
                            var reviceMessage = GetTPandMac(bytes);
                            Log.WriteLog("接收：" + reviceMessage,"","");
                            //result =checkOk(reviceMessage);
                            return GetOpendStateByReviceMessage(reviceMessage, warehouseIndexs);
                        }
                    }

                    #endregion
                }
                catch (SocketException e)
                {
                   // Logger.Error(e.Message, e);

                    //result = false;
                }
                catch (Exception e)
                {
                    //result = false;
                    //Logger.Error(e.Message,e);
                    throw;
                }

                return result;
            }
        }
        private bool checkOk(string str) {
            Log.WriteLog("类：RemoteBoxHelperNew", "方法：checkOk", "substr:" + str.Substring(50, 24));
            Log.WriteLog("类：RemoteBoxHelperNew", "方法：checkOk", "subint:" + str.Substring(50, 24).IndexOf("1"));
            return str.Substring(50, 24).IndexOf("1") > 0 ? false : true;
        }
        private string ByteToHexString(byte[] data)
        {
            StringBuilder dataString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                dataString.AppendFormat("{0:x2}", data[i]);
            }
            return dataString.ToString().Trim().ToUpper();
        }
       
        //TODO
        private static Dictionary<string, bool> GetOpendStateByReviceMessage(string msg, string warehouseIndexs)
        {
            //EF022510091111281C038652E1CC31C988810E44787A020000000404000000000000004303
            byte[] byte_open = new byte[12] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var list = warehouseIndexs.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = new Dictionary<string, bool>();
            Log.WriteLog("类：RemoteBoxHelperNew", "方法：checkOk", "substr:" + msg.Substring(48, 24));
            Log.WriteLog("类：RemoteBoxHelperNew", "方法：checkOk", "substr:" + msg.Substring(50, 24));
            //命令字判断，是否当前操作
            if (msg.Substring(18, 2) != "03") return result;

            foreach (var i in list)
            {
                Log.WriteLog("类：RemoteBoxHelperNew", "方法：checkOk", "i:" + i);
                var number = int.Parse(i);
                var startIndex = 50 + number*2;
                Log.WriteLog("类：RemoteBoxHelperNew", "方法：checkOk", "startIndex:" + startIndex);
                var stateCode = msg.Substring(startIndex, 2);
                Log.WriteLog("类：RemoteBoxHelperNew", "方法：checkOk", "stateCode:" + stateCode);
                var isOpend = stateCode == "00" ? true : false;
                result.Add(i, isOpend);
            }

            return result;
        }

        private static byte[] StringToByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length%2) != 0)
                hexString += " ";
            var returnBytes = new byte[hexString.Length/2];
            for (var i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i*2, 2), 16);
            return returnBytes;
        }

        private static string GetTPandMac(IEnumerable<byte> arrays)
        {
            var mac = arrays.Aggregate("", (current, b) => current + string.Format("{0:X2}", b));
            mac = mac.TrimEnd();
            return mac;
        }
    }
}
