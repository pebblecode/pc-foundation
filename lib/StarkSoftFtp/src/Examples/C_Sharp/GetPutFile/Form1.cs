using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Starksoft.Net.Ftp;

namespace GetPutFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            // clear the bytes transferred label
            lblBytesTransferred.Text = "";

            // create a new ftpclient object with the host and port number to use
            FtpClient ftp = new FtpClient(tbFtpHost.Text, Int32.Parse(tbFtpPort.Text));

            // registered an event hook for the transfer complete event so we get an update when the transfer is over
            ftp.TransferComplete += new EventHandler<TransferCompleteEventArgs>(ftp_TransferComplete);

            // open a connection to the ftp server with a username and password
            ftp.Open(tbUsername.Text, tbPassword.Text);
            
            // get a file and store it locally to disk
            ftp.GetFile(tbRemoteFile.Text, tbLocalFile.Text, FileAction.Create);

            // close the ftp connection
            ftp.Close();
        }

        private void btnPutFile_Click(object sender, EventArgs e)
        {
            // clear the bytes transferred label
            lblBytesTransferred.Text = "";

            // create a new ftpclient object with the host and port number to use
            FtpClient ftp = new FtpClient(tbFtpHost.Text, Int32.Parse(tbFtpPort.Text));

            // registered an event hook for the transfer complete event so we get an update when the transfer is over
            ftp.TransferComplete += new EventHandler<TransferCompleteEventArgs>(ftp_TransferComplete);

            // open a connection to the ftp server with a username and password
            ftp.Open(tbUsername.Text, tbPassword.Text);

            // put a local file and store it remotely as the supplied file location and name 
            ftp.PutFile(tbLocalFile.Text, tbRemoteFile.Text, FileAction.Create);

            // close the ftp connection
            ftp.Close();
        }

        // transfer complete event hook function
        private void ftp_TransferComplete(object sender, TransferCompleteEventArgs e)
        {
            // update the bytes transferred label
            lblBytesTransferred.Text = e.BytesTransferred.ToString() + " bytes transferred in " + e.ElapsedTime.Seconds.ToString() + " seconds";
        }


    }
}