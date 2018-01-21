using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTcpClient.Common
{
  public    class Delegates
    {
        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void DataReceivedHandler(object sender, byte[] data);


        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void DataReceivedStringHandler(string date);

        /// <summary>
        /// 发送数据事件
        /// </summary>
        /// <param name="data"></param>
        public delegate bool DataSendHandler(byte[] data);

    }
}
