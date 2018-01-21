using AsyncTcpClient.Common;
using Creatrue.Common;
using hxdevice.Common;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace hxdevice
{
    public partial class Form1 : Form
    {
        string strmac;
        byte[] byte_mac = new byte[12];
        public Form1()
        {
            InitializeComponent();
            mac_tb.Text = "861853032010134";//861853031484991
            tableLayoutPanel1.GetControlFromPosition(0, 0).Text = "139.199.160.173";
            //InitBtn();
            ////byte_mac = GetMac(12);
            ////strmac = ConvertHelper.ByteToHexString(byte_mac);
            ThreadPool.QueueUserWorkItem(SendBeates);
            tcpConnecter1.TCPConnecter_ShowLog_Handler += TCPShowLog;
            tcpConnecter1.TCPConnecter_Receive_Handler += ExecDataGram;
        }

        private void TCPShowLog(string strmsg)
        {
            LogHelper.ShowLog(rtbox_log,strmsg);
            LogHelper.WriteLog(strmsg);
        }
        private void ExecDataGram(object sender,byte[]datagram)
        {
            if (sender is TcpClient && datagram != null && datagram.Length > 0)
            {
                string LastStrDataGram=GetLastStrToEnd("EF02", ConvertHelper.ByteToHexString(datagram));
                LogHelper.WriteLog("收到原始数据：" + LastStrDataGram);
                LogHelper.ShowLog(rtbox_log, "收到原始数据：" + LastStrDataGram);
                byte[] LastRes = ConvertHelper.HexStringToByte(LastStrDataGram);
                if (CheckDataGram(LastRes))
                {
                    switch (LastRes[9])
                    {
                        case 1://心跳的响应
                            {
                                LogHelper.WriteLog("收到心跳响应：" + LastStrDataGram);
                                LogHelper.ShowLog(rtbox_log, "收到心跳响应：" + LastStrDataGram);
                            }
                            break;
                        case 3://开箱命令
                            {
                                LogHelper.WriteLog("收到开箱指令：" + LastStrDataGram);
                                LogHelper.ShowLog(rtbox_log, "收到开箱指令：" + LastStrDataGram);
                                byte [] byte_box_status= new byte[6];
                                Array.Copy(LastRes,22,byte_box_status,0,6);
                                SetBoxStatus(byte_box_status);
                                SendCmdOpenRespnse(byte_box_status);
                                
                            }
                            break;

                    }
                }
                else
                {
                    LogHelper.ShowLog(rtbox_log,"收到异常报文" + LastStrDataGram);
                    LogHelper.WriteLog("收到异常报文" + LastStrDataGram);
                }
            }
        }

        private byte[] GetBoxStatus()
        {
            byte[] byte_boxststus = new byte[6];
            byte_boxststus[0] = (byte)Utils.ObjToInt(button1.Tag, 1);
            byte_boxststus[1] = (byte)Utils.ObjToInt(button2.Tag, 1);
            byte_boxststus[2] = (byte)Utils.ObjToInt(button3.Tag, 1);
            byte_boxststus[3] = (byte)Utils.ObjToInt(button4.Tag, 1);
            byte_boxststus[4] = (byte)Utils.ObjToInt(button5.Tag, 1);
            byte_boxststus[5] = (byte)Utils.ObjToInt(button6.Tag, 1);
            return byte_boxststus;
        }

        private void SetBoxStatus(byte[] byte_boxststus_cmd)
        {  
            byte[] byte_boxststus = new byte[6];
            if(byte_boxststus_cmd!=null&&byte_boxststus_cmd.Length>0)
            {
                int index= byte_boxststus_cmd.Length>5?6:byte_boxststus_cmd.Length;
                Array.Copy(byte_boxststus_cmd,0,byte_boxststus,0,index);
                SetBtnState(button1, byte_boxststus[0]);
                SetBtnState(button2, byte_boxststus[1]);
                SetBtnState(button3, byte_boxststus[2]);
                SetBtnState(button4, byte_boxststus[3]);
                SetBtnState(button5, byte_boxststus[4]);
                SetBtnState(button6, byte_boxststus[5]);
            }
        }
        public void SetBtnState(Button btn_current, byte byte_current)
        {
            switch (byte_current)
            {
                case 0x00://正确关门。 
                    btn_current.BeginInvoke(new EventHandler(delegate
                    {
                        btn_current.Text = "已关闭";
                        btn_current.Tag = 0;
                        btn_current.Enabled = true;
                    }));
                    break;
                case 0X01: //正确开门。 
                    btn_current.BeginInvoke(new EventHandler(delegate
                    {
                        btn_current.Text = "已打开";
                        btn_current.Tag = 1;
                        btn_current.Enabled = false;

                    }));
                    break;
                case 0X02: //开门后，没有正常关门，忘记关门了。 
                    btn_current.BeginInvoke(new EventHandler(delegate
                    {
                        btn_current.Text = "已打开";
                        btn_current.Tag = 2;
                        btn_current.Enabled = false;

                    }));
                    break;
                case 0X03: //开门动作后，开门失败。
                    btn_current.BeginInvoke(new EventHandler(delegate
                    {
                        btn_current.Text = "开门失败";
                        btn_current.Tag = 3;
                        btn_current.Enabled = true;
                    }));
                    break;
                default:
                    break;
            }
        }
        private  void SendBeates(object obj)
        {
            while (true)
            {
                Thread.CurrentThread.Join(30 * 1000);
                Box_Date box_date = new Box_Date();
                byte[] date_control = new byte[37];
                date_control[0] = box_date.Date_start[0];//EF
                date_control[1] = box_date.Date_start[1];//02
                date_control[2] = box_date.Date_length[0];//25
                Array.Copy(box_date.Date_datetime, 0, date_control, 3, 6);
                date_control[9] = 0x01;//功能命令字
                Array.Copy(byte_mac, 0, date_control, 10, 12);//MAC

                byte[] null_byte = new byte[13] { 0x00,0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte [] cur_box_status=GetBoxStatus();
                Array.Copy(cur_box_status, 0, null_byte, 0, 6);//放箱子状态

                Array.Copy(null_byte, 0, date_control, 22, 12);
                byte[] rcr = new byte[33];
                Array.Copy(date_control, 2, rcr, 0, 33);
                date_control[35] = Converts.GetCRCSUM(rcr)[0];
                date_control[36] = Converts.GetCRCSUM(rcr)[1];
        
            }   
        }

        private void SendCmdOpenRespnse(byte[]box_status)
        {
                Box_Date box_date = new Box_Date();
                byte[] date_control = new byte[37];
                date_control[0] = box_date.Date_start[0];//EF
                date_control[1] = box_date.Date_start[1];//02
                date_control[2] = box_date.Date_length[0];//25
                Array.Copy(box_date.Date_datetime, 0, date_control, 3, 6);
                date_control[9] = 0x03;//功能命令字
                Array.Copy(byte_mac, 0, date_control, 10, 12);//MAC
                byte[] null_byte = new byte[13] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte[] cur_box_status = box_status;
                Array.Copy(cur_box_status, 0, null_byte, 0, 6);//放箱子状态
                Array.Copy(null_byte, 0, date_control, 22, 13);
                byte[] rcr = new byte[33];
                Array.Copy(date_control, 2, rcr, 0, 33);
                date_control[35] = Converts.GetCRCSUM(rcr)[0];
                date_control[36] = Converts.GetCRCSUM(rcr)[1];
                //tcpConnecter1.TCPSend(date_control);
        }

        private byte[] GetMac(int num)
        {
            byte[] bytemac = new byte[num];
            Random rd = new Random();
            for (int i = 0; i < num; i++)
            {
                bytemac[i] = (byte)rd.Next(0xff);
            }
            return bytemac;
        }

        /// <summary>
        /// 取出以指定字符串开头的字符串的最后一个子串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strsource"></param>
        /// <returns></returns>
        string GetLastStrToEnd(string str, string strsource)
        {
            string result = "";
            try
            {
                int lastlocation = strsource.LastIndexOf(str);
                result = strsource.Substring(lastlocation);
            }
            catch
            {
            }
            return result;// Encoding.ASCII.ToString();
        }
        bool CheckDataGram(byte[] datagram)
        {
            string strdatagram = ConvertHelper.ByteToHexString(datagram);//EF020016112019151A01FEE199B98B39B78C9F8497EA00000000000000000000000000086C
            bool result = false;
            if (datagram.Length == 37)
            {
                byte[] bytecrc = new byte[33];
                Array.Copy(datagram, 2, bytecrc, 0, 33);

                string strcrc = ConvertHelper.ByteToHexString(bytecrc);//0016112019151A01FEE199B98B39B78C9F8497EA00000000000000000000000000

                byte crcsumheigh = Converts.GetCRCSUM(bytecrc)[0];
                byte crcsumlow = Converts.GetCRCSUM(bytecrc)[1];
                if (crcsumheigh == datagram[35] && crcsumlow == datagram[36])
                {
                    result = true;
                }
            }
            return result;
        }
      
        private void InitBtn()
        {
            
            button1.Tag = 0; button1.Text = "关闭"; button1.Enabled = false;
            button2.Tag = 0; button2.Text = "关闭"; button2.Enabled = false;
            button3.Tag = 0; button3.Text = "关闭"; button3.Enabled = false;
            button4.Tag = 0; button4.Text = "关闭"; button4.Enabled = false;
            button5.Tag = 0; button5.Text = "关闭"; button5.Enabled = false;
            button6.Tag = 0; button6.Text = "关闭"; button6.Enabled = false;
        }
        #region 第一个箱子
        private void button1_Click(object sender, EventArgs e)
        {
            OpenBox("0");
        }
        #endregion

        #region 第二个箱子
        private void button2_Click(object sender, EventArgs e)
        {
            OpenBox("1");
        }
        #endregion

        #region 第三个箱子
        private void button3_Click(object sender, EventArgs e)
        {
            OpenBox("2");
        }
        #endregion

        #region 第四个箱子
        private void button6_Click(object sender, EventArgs e)
        {
            OpenBox("3");
        }
        #endregion

        #region 第五个箱子
        private void button4_Click(object sender, EventArgs e)
        {
            OpenBox("4");
        }
        #endregion

        #region 第六个箱子
        private void button5_Click(object sender, EventArgs e)
        {
            OpenBox("5");
        }
        #endregion

        #region 第七个箱子
        private void button8_Click(object sender, EventArgs e)
        {
            OpenBox("6");
        }
        #endregion

        #region 第八个箱子
        private void button9_Click(object sender, EventArgs e)
        {
            OpenBox("7");
        }
        #endregion

        #region 第九个箱子
        private void button10_Click(object sender, EventArgs e)
        {
            OpenBox("8");
        }
        #endregion

        #region 第十个箱子
        private void button12_Click(object sender, EventArgs e)
        {
            OpenBox("9");
        }
        #endregion

        #region 第十一个箱子
        private void button11_Click(object sender, EventArgs e)
        {
            OpenBox("10");
        }
        #endregion

        #region 第十二个箱子
        private void button13_Click(object sender, EventArgs e)
        {
            OpenBox("11");
        }
        #endregion

        #region 全部开箱
        private void button7_Click(object sender, EventArgs e)
        {
            //rtbox_log.Text = string.Empty;
            //LogHelper.ShowLog(rtbox_log, "My MAC Is " + strmac);
            //LogHelper.WriteLog("My MAC Is " + strmac);
            //InitBtn();
            OpenBox("0,1,2,3,4,5,6,7,8,9,10,11");
        }
        #endregion

        #region 开箱逻辑
        public void OpenBox(string num)
        {
            try
            {
                var remote = new RemoteBoxHelper();
                var ip = tableLayoutPanel1.GetControlFromPosition(0,0).Text;

                var mac = mac_tb.Text;//861853031485105
                //var orderNo = GetOrderNo();
                //S201775532345392
                //B201775532345392
                var orderNo = "201775532345392";
                orderNo = orderNo.PadRight(15, '0');
                remote.OpenRemoteBox(mac, orderNo, num, 0x02);

                LogHelper.ShowLog(rtbox_log, "----------------------------------------------------------");
                LogHelper.ShowLog(rtbox_log, "第" + num + "个箱子");
                LogHelper.ShowLog(rtbox_log, "----------------------------------------------------------");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+";"+ex.StackTrace);
            }
        }

        #endregion
        public string GetOrderNo()
        {
            string OrderNo = string.Empty;
            Random rd = new Random();
            int num1 = rd.Next(100, 1000);
            DateTime dtnow = DateTime.Now;
            OrderNo = "S" + System.DateTime.Now.Year.ToString().PadRight(4,'0') + System.DateTime.Now.Month.ToString().PadRight(2, '0') + System.DateTime.Now.Minute.ToString().PadRight(2, '0') + System.DateTime.Now.Second.ToString().PadRight(2, '0') + System.DateTime.Now.Millisecond.ToString().PadRight(2, '0') + num1;
            OrderNo = OrderNo.PadRight(16, '9');
            if (OrderNo.Length > 16)
            {
                OrderNo = OrderNo.Substring(0, 16);
            }

            return OrderNo;
        }
    }
    
}
