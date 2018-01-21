namespace hxdevice.Units
{
    partial class TCPConnecter
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.nmServerPort = new System.Windows.Forms.NumericUpDown();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_constatus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtServerIP);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.nmServerPort);
            this.panel1.Controls.Add(this.btn_connect);
            this.panel1.Controls.Add(this.btn_disconnect);
            this.panel1.Controls.Add(this.btn_constatus);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 24);
            this.panel1.TabIndex = 0;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServerIP.Location = new System.Drawing.Point(115, 0);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(214, 21);
            this.txtServerIP.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(329, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 24);
            this.button2.TabIndex = 11;
            this.button2.Text = "端口：";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // nmServerPort
            // 
            this.nmServerPort.Dock = System.Windows.Forms.DockStyle.Right;
            this.nmServerPort.Location = new System.Drawing.Point(386, 0);
            this.nmServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmServerPort.Name = "nmServerPort";
            this.nmServerPort.Size = new System.Drawing.Size(53, 21);
            this.nmServerPort.TabIndex = 10;
            this.nmServerPort.Value = new decimal(new int[] {
            2756,
            0,
            0,
            0});
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.SystemColors.Control;
            this.btn_connect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_connect.Location = new System.Drawing.Point(439, 0);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 24);
            this.btn_connect.TabIndex = 9;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_disconnect.Location = new System.Drawing.Point(514, 0);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(61, 24);
            this.btn_disconnect.TabIndex = 8;
            this.btn_disconnect.Text = "断开";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_constatus
            // 
            this.btn_constatus.BackColor = System.Drawing.Color.Red;
            this.btn_constatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_constatus.Location = new System.Drawing.Point(575, 0);
            this.btn_constatus.Name = "btn_constatus";
            this.btn_constatus.Size = new System.Drawing.Size(75, 24);
            this.btn_constatus.TabIndex = 7;
            this.btn_constatus.Text = "未连接";
            this.btn_constatus.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "服务器地址：";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TCPConnecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TCPConnecter";
            this.Size = new System.Drawing.Size(650, 24);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_constatus;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nmServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button btn_connect;

    }
}
