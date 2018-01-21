namespace hxdevice
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelboxes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mac_tb = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbox_log = new System.Windows.Forms.RichTextBox();
            this.tcpConnecter1 = new hxdevice.Units.TCPConnecter();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelboxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelboxes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tcpConnecter1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbox_log, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.81818F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.09091F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 524);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelboxes
            // 
            this.panelboxes.Controls.Add(this.label1);
            this.panelboxes.Controls.Add(this.mac_tb);
            this.panelboxes.Controls.Add(this.button13);
            this.panelboxes.Controls.Add(this.button12);
            this.panelboxes.Controls.Add(this.button11);
            this.panelboxes.Controls.Add(this.button10);
            this.panelboxes.Controls.Add(this.button9);
            this.panelboxes.Controls.Add(this.button8);
            this.panelboxes.Controls.Add(this.button7);
            this.panelboxes.Controls.Add(this.button6);
            this.panelboxes.Controls.Add(this.button5);
            this.panelboxes.Controls.Add(this.button4);
            this.panelboxes.Controls.Add(this.button3);
            this.panelboxes.Controls.Add(this.button2);
            this.panelboxes.Controls.Add(this.button1);
            this.panelboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelboxes.Location = new System.Drawing.Point(3, 50);
            this.panelboxes.Name = "panelboxes";
            this.panelboxes.Size = new System.Drawing.Size(757, 291);
            this.panelboxes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "MAC地址：";
            // 
            // mac_tb
            // 
            this.mac_tb.Location = new System.Drawing.Point(110, 253);
            this.mac_tb.Name = "mac_tb";
            this.mac_tb.Size = new System.Drawing.Size(326, 21);
            this.mac_tb.TabIndex = 15;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(478, 158);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(93, 50);
            this.button13.TabIndex = 13;
            this.button13.Text = "012";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(199, 158);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(93, 50);
            this.button12.TabIndex = 12;
            this.button12.Text = "010";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(343, 158);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(93, 50);
            this.button11.TabIndex = 11;
            this.button11.Text = "011";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(47, 158);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 50);
            this.button10.TabIndex = 10;
            this.button10.Text = "009";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(475, 85);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 44);
            this.button9.TabIndex = 9;
            this.button9.Text = "008";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(341, 83);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(95, 46);
            this.button8.TabIndex = 8;
            this.button8.Text = "007";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(596, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 203);
            this.button7.TabIndex = 7;
            this.button7.Text = "全部开箱";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(475, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 47);
            this.button6.TabIndex = 5;
            this.button6.Text = "004";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(199, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 46);
            this.button5.TabIndex = 4;
            this.button5.Text = "006";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(47, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 44);
            this.button4.TabIndex = 3;
            this.button4.Text = "005";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(341, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "003";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(198, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "002";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "001";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbox_log
            // 
            this.rtbox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbox_log.Location = new System.Drawing.Point(3, 347);
            this.rtbox_log.Name = "rtbox_log";
            this.rtbox_log.Size = new System.Drawing.Size(757, 174);
            this.rtbox_log.TabIndex = 2;
            this.rtbox_log.Text = "";
            // 
            // tcpConnecter1
            // 
            this.tcpConnecter1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.tcpConnecter1.Location = new System.Drawing.Point(3, 3);
            this.tcpConnecter1.Name = "tcpConnecter1";
            this.tcpConnecter1.Size = new System.Drawing.Size(757, 28);
            this.tcpConnecter1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 524);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "模拟货箱";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelboxes.ResumeLayout(false);
            this.panelboxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelboxes;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbox_log;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox mac_tb;
        private System.Windows.Forms.Label label1;
        private Units.TCPConnecter tcpConnecter1;
    }
}

