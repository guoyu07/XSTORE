using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Creatrue.Common;
using System.Threading;
using hxdevice.Common;

namespace hxdevice.Units
{
    public partial class TCPConnecter : UserControl
    {
        TcpClient client = new TcpClient();

        public delegate void TCPConnecter_ShowLog(string stemsg);
        public event TCPConnecter_ShowLog TCPConnecter_ShowLog_Handler;

        public delegate void TCPConnecter_Connect();
        public event TCPConnecter_Connect TCPConnecter_Connect_Handler;

        public delegate void TCPConnecter_Receive(object sender, byte[] data);
        public event TCPConnecter_Receive TCPConnecter_Receive_Handler;

        byte[] buffer = new byte[4096];
        private  void ShowLog(string strmsg)
        {
            if (TCPConnecter_ShowLog_Handler != null)
            {
                TCPConnecter_ShowLog_Handler(strmsg);
            }
        }

        public TCPConnecter()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public bool TCPSend(byte [] cmd)
        {
            bool result = false;
            try
            {
                if (client != null)
                {
                        NetworkStream netstream =client.GetStream();
                        if (netstream != null && netstream.CanWrite)
                        {
                            netstream.Write(cmd, 0, cmd.Length);
                            ShowLog("向服务器" + client.GetStrSocket() + "，发送的数据:" + ConvertHelper.ByteToHexString(cmd));
                            result = true;
                        }
                   
                }
                else
                {
                    client = new TcpClient();
                    client.BeginConnect(txtServerIP.Text.Trim(), (int)nmServerPort.Value, new AsyncCallback(ConnectCallback), client);
                }
            }
            catch (Exception e)
            {
                ShowLog("程序异常:"+e.Message+";位置"+e.StackTrace);
            }

            return result;
   
        }
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            TcpClose();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (client==null||!client.Connected || !client.Client.Connected)
            {
                client = new TcpClient();
                client.BeginConnect(txtServerIP.Text.Trim(), (int)nmServerPort.Value, new AsyncCallback(ConnectCallback), client);
                if (TCPConnecter_Connect_Handler != null)
                {
                    TCPConnecter_Connect_Handler();
                }
                ShowLog("与服务器的连接已建立;");
            } 
        }
        /// <summary>
        /// 执行完异步建立连接后的动作
        /// </summary>
        /// <param name="ar"></param>
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                if (ar.AsyncState != null)
                {
                 
                    client = (TcpClient)ar.AsyncState;
                    client.EndConnect(ar);
                    btn_constatus.BeginInvoke(new EventHandler(delegate
                    {
                        btn_constatus.Text = "已连接";
                    }));
                    ShowLog("与服务器：" + client.GetStrSocket() + "，已建立连接");
                    client.GetStream().BeginRead(buffer, 0, buffer.Length, new AsyncCallback(TCPCallBack), client);
                }
            }
            catch (Exception e)
            {
                ShowLog("与服务器：" + client.GetStrSocket() + "，建立连接失败");
                ShowLog("出现错误："+e.Message+"；位置："+e.StackTrace);
            }
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void TCPCallBack(IAsyncResult ar)
        {
            try
            {
                if (ar.AsyncState != null)
                {
                    client = (TcpClient)ar.AsyncState;
                    if (client.Connected)
                    {
                        NetworkStream nstream = client.GetStream();//【释放（nstream.close()），会产生奇怪的后果(丢失socket连接信息)】
                        byte[] recdata = new byte[nstream.EndRead(ar)];
                        Array.Copy(buffer, recdata, recdata.Length);
                        if (recdata != null && recdata.Length > 0)
                        {
                            string strmsg = ConvertHelper.ByteToHexStringWith0X(recdata);
                            ShowLog(client.GetStrSocket() + "，服务器返回的数据:" + strmsg);
                            TCPConnecter_Receive_Handler(client, recdata);
                            nstream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(TCPCallBack), client);//此处使得下一次的连接依然能收到数据【不明觉厉，注释掉你会后悔的】
                        }
                        else//断开连接
                        {
                            nstream.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TcpClose();
                ShowLog("出现错误：" + ex.Message + "；位置：" + ex.StackTrace);
            }
        }


        private void TcpClose()
        {
            try
            {
                if (client != null&&client.Connected&&client.Client.Connected)
                {
                    client.Client.Shutdown(SocketShutdown.Both);//关闭Socket之前，首选需要把双方的Socket Shutdown掉
                    Thread.Sleep(20);
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                ShowLog("出现错误：" + ex.Message + "；位置：" + ex.StackTrace);
            }
            finally
            {
                ShowLog("与服务器：" + client.GetStrSocket() + "，断开连接");
                btn_constatus.Text = "已断开";
                btn_constatus.BackColor = Color.Red;
            }
            
        }
    }

   
}
