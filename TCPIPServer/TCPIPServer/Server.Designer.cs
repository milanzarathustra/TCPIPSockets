namespace TCPIPServer
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.tbConsoleOutput = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.tbPayLoad = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.msgControls = new System.Windows.Forms.GroupBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.configurationGroup = new System.Windows.Forms.GroupBox();
            this.btnlogoabt = new System.Windows.Forms.PictureBox();
            this.msgControls.SuspendLayout();
            this.configurationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoabt)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConsoleOutput
            // 
            this.tbConsoleOutput.BackColor = System.Drawing.Color.White;
            this.tbConsoleOutput.Location = new System.Drawing.Point(12, 7);
            this.tbConsoleOutput.Multiline = true;
            this.tbConsoleOutput.Name = "tbConsoleOutput";
            this.tbConsoleOutput.ReadOnly = true;
            this.tbConsoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsoleOutput.Size = new System.Drawing.Size(280, 213);
            this.tbConsoleOutput.TabIndex = 0;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(214, 19);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(76, 20);
            this.tbPort.TabIndex = 1;
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(53, 19);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(153, 20);
            this.tbIPAddress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP/Port: ";
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(296, 18);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(81, 23);
            this.btnStartListening.TabIndex = 4;
            this.btnStartListening.Text = "Listen";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // tbPayLoad
            // 
            this.tbPayLoad.Location = new System.Drawing.Point(6, 21);
            this.tbPayLoad.Multiline = true;
            this.tbPayLoad.Name = "tbPayLoad";
            this.tbPayLoad.Size = new System.Drawing.Size(371, 57);
            this.tbPayLoad.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(248, 84);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(129, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // msgControls
            // 
            this.msgControls.Controls.Add(this.btnAbout);
            this.msgControls.Controls.Add(this.tbPayLoad);
            this.msgControls.Controls.Add(this.btnSend);
            this.msgControls.Enabled = false;
            this.msgControls.Location = new System.Drawing.Point(304, 102);
            this.msgControls.Name = "msgControls";
            this.msgControls.Size = new System.Drawing.Size(391, 118);
            this.msgControls.TabIndex = 8;
            this.msgControls.TabStop = false;
            this.msgControls.Text = "Message";
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(6, 84);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(452, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "TCP/IP Server";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(660, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 28);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // configurationGroup
            // 
            this.configurationGroup.Controls.Add(this.btnStartListening);
            this.configurationGroup.Controls.Add(this.tbPort);
            this.configurationGroup.Controls.Add(this.tbIPAddress);
            this.configurationGroup.Controls.Add(this.label1);
            this.configurationGroup.Location = new System.Drawing.Point(304, 34);
            this.configurationGroup.Name = "configurationGroup";
            this.configurationGroup.Size = new System.Drawing.Size(391, 51);
            this.configurationGroup.TabIndex = 11;
            this.configurationGroup.TabStop = false;
            this.configurationGroup.Text = "Configuration";
            // 
            // btnlogoabt
            // 
            this.btnlogoabt.Image = global::TCPIPServer.Properties.Resources.icon;
            this.btnlogoabt.InitialImage = global::TCPIPServer.Properties.Resources.icon;
            this.btnlogoabt.Location = new System.Drawing.Point(428, 7);
            this.btnlogoabt.Name = "btnlogoabt";
            this.btnlogoabt.Size = new System.Drawing.Size(28, 24);
            this.btnlogoabt.TabIndex = 14;
            this.btnlogoabt.TabStop = false;
            this.btnlogoabt.Click += new System.EventHandler(this.btnlogoabt_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(708, 231);
            this.Controls.Add(this.btnlogoabt);
            this.Controls.Add(this.configurationGroup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.msgControls);
            this.Controls.Add(this.tbConsoleOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(708, 231);
            this.MinimumSize = new System.Drawing.Size(708, 231);
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCPIP Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.msgControls.ResumeLayout(false);
            this.msgControls.PerformLayout();
            this.configurationGroup.ResumeLayout(false);
            this.configurationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoabt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsoleOutput;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.TextBox tbPayLoad;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox msgControls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox configurationGroup;
        private System.Windows.Forms.PictureBox btnlogoabt;
    }
}

