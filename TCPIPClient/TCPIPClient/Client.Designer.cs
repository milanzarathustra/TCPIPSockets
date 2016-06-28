namespace TCPIPClient
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPayLoad = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.connectionGroup = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.msgControls = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnlogoabt = new System.Windows.Forms.PictureBox();
            this.connectionGroup.SuspendLayout();
            this.msgControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoabt)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.Color.White;
            this.tbConsole.Location = new System.Drawing.Point(13, 9);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(263, 298);
            this.tbConsole.TabIndex = 0;
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(95, 63);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(181, 20);
            this.tbServerIP.TabIndex = 1;
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(94, 95);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(90, 20);
            this.tbServerPort.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(190, 94);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Port: ";
            // 
            // tbPayLoad
            // 
            this.tbPayLoad.Location = new System.Drawing.Point(6, 19);
            this.tbPayLoad.Multiline = true;
            this.tbPayLoad.Name = "tbPayLoad";
            this.tbPayLoad.Size = new System.Drawing.Size(294, 69);
            this.tbPayLoad.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(146, 94);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(154, 23);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // connectionGroup
            // 
            this.connectionGroup.Controls.Add(this.tbName);
            this.connectionGroup.Controls.Add(this.label3);
            this.connectionGroup.Controls.Add(this.tbServerIP);
            this.connectionGroup.Controls.Add(this.tbServerPort);
            this.connectionGroup.Controls.Add(this.btnConnect);
            this.connectionGroup.Controls.Add(this.label1);
            this.connectionGroup.Controls.Add(this.label2);
            this.connectionGroup.Location = new System.Drawing.Point(292, 37);
            this.connectionGroup.Name = "connectionGroup";
            this.connectionGroup.Size = new System.Drawing.Size(309, 135);
            this.connectionGroup.TabIndex = 9;
            this.connectionGroup.TabStop = false;
            this.connectionGroup.Text = "Connection";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(95, 31);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(181, 20);
            this.tbName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Your Name: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "TCP/IP Client";
            // 
            // msgControls
            // 
            this.msgControls.Controls.Add(this.button1);
            this.msgControls.Controls.Add(this.tbPayLoad);
            this.msgControls.Controls.Add(this.btnSend);
            this.msgControls.Enabled = false;
            this.msgControls.Location = new System.Drawing.Point(292, 178);
            this.msgControls.Name = "msgControls";
            this.msgControls.Size = new System.Drawing.Size(309, 129);
            this.msgControls.TabIndex = 11;
            this.msgControls.TabStop = false;
            this.msgControls.Text = "Message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(563, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 28);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnlogoabt
            // 
            this.btnlogoabt.Image = global::TCPIPClient.Properties.Resources.icon;
            this.btnlogoabt.InitialImage = global::TCPIPClient.Properties.Resources.icon;
            this.btnlogoabt.Location = new System.Drawing.Point(383, 9);
            this.btnlogoabt.Name = "btnlogoabt";
            this.btnlogoabt.Size = new System.Drawing.Size(28, 24);
            this.btnlogoabt.TabIndex = 13;
            this.btnlogoabt.TabStop = false;
            this.btnlogoabt.Click += new System.EventHandler(this.btnlogoabt_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 320);
            this.Controls.Add(this.btnlogoabt);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.msgControls);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.connectionGroup);
            this.Controls.Add(this.tbConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(613, 320);
            this.MinimumSize = new System.Drawing.Size(613, 320);
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCPIP Client";
            this.connectionGroup.ResumeLayout(false);
            this.connectionGroup.PerformLayout();
            this.msgControls.ResumeLayout(false);
            this.msgControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoabt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPayLoad;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox connectionGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox msgControls;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnlogoabt;
    }
}

