namespace GetPutFile
{
    partial class Form1
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
            this.tbFtpHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFtpPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLocalFile = new System.Windows.Forms.TextBox();
            this.tbRemoteFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPutFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblBytesTransferred = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbFtpHost
            // 
            this.tbFtpHost.Location = new System.Drawing.Point(84, 12);
            this.tbFtpHost.Name = "tbFtpHost";
            this.tbFtpHost.Size = new System.Drawing.Size(188, 20);
            this.tbFtpHost.TabIndex = 0;
            this.tbFtpHost.Text = "ftps.g6ftpserver.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "FTP Host";
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(12, 180);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 2;
            this.btnGetFile.Text = "Get File";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FTP Port";
            // 
            // tbFtpPort
            // 
            this.tbFtpPort.Location = new System.Drawing.Point(84, 38);
            this.tbFtpPort.Name = "tbFtpPort";
            this.tbFtpPort.Size = new System.Drawing.Size(54, 20);
            this.tbFtpPort.TabIndex = 3;
            this.tbFtpPort.Text = "21";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Local File";
            // 
            // tbLocalFile
            // 
            this.tbLocalFile.Location = new System.Drawing.Point(84, 143);
            this.tbLocalFile.Name = "tbLocalFile";
            this.tbLocalFile.Size = new System.Drawing.Size(394, 20);
            this.tbLocalFile.TabIndex = 6;
            this.tbLocalFile.Text = "c:\\temp\\welcome.txt";
            // 
            // tbRemoteFile
            // 
            this.tbRemoteFile.Location = new System.Drawing.Point(84, 116);
            this.tbRemoteFile.Name = "tbRemoteFile";
            this.tbRemoteFile.Size = new System.Drawing.Size(394, 20);
            this.tbRemoteFile.TabIndex = 8;
            this.tbRemoteFile.Text = "/welcome.txt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Remote File";
            // 
            // btnPutFile
            // 
            this.btnPutFile.Location = new System.Drawing.Point(93, 180);
            this.btnPutFile.Name = "btnPutFile";
            this.btnPutFile.Size = new System.Drawing.Size(75, 23);
            this.btnPutFile.TabIndex = 9;
            this.btnPutFile.Text = "Put File";
            this.btnPutFile.UseVisualStyleBackColor = true;
            this.btnPutFile.Click += new System.EventHandler(this.btnPutFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Username";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(84, 64);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(188, 20);
            this.tbUsername.TabIndex = 10;
            this.tbUsername.Text = "anonymous";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(84, 90);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(188, 20);
            this.tbPassword.TabIndex = 12;
            this.tbPassword.Text = "user@domain.com";
            // 
            // lblBytesTransferred
            // 
            this.lblBytesTransferred.Location = new System.Drawing.Point(111, 223);
            this.lblBytesTransferred.Name = "lblBytesTransferred";
            this.lblBytesTransferred.Size = new System.Drawing.Size(367, 13);
            this.lblBytesTransferred.TabIndex = 15;
            this.lblBytesTransferred.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Bytes Transferred:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 250);
            this.Controls.Add(this.lblBytesTransferred);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.btnPutFile);
            this.Controls.Add(this.tbRemoteFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbLocalFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFtpPort);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFtpHost);
            this.Name = "Form1";
            this.Text = "Starksoft.Net.Ftp GetPutFileSSL C#";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFtpHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFtpPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLocalFile;
        private System.Windows.Forms.TextBox tbRemoteFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPutFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblBytesTransferred;
        private System.Windows.Forms.Label label7;
    }
}

