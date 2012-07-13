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
            // set the security protocol to use - in this case we are instructing the FtpClient to use either
            // the SSL 3.0 protocol or the TLS 1.0 protocol depending on what the FTP server supports
            FtpClient ftp = new FtpClient(tbFtpHost.Text, Int32.Parse(tbFtpPort.Text), FtpSecurityProtocol.Tls1OrSsl3Implicit);

            // register an event hook so that we can view and accept the security certificate that is given by the FTP server
            ftp.ValidateServerCertificate += new EventHandler<ValidateServerCertificateEventArgs>(ftp_ValidateServerCertificate);

            // registered an event hook for the transfer complete event so we get an update when the transfer is over
            ftp.TransferComplete += new EventHandler<TransferCompleteEventArgs>(ftp_TransferComplete);

            try
            {
                // open a connection to the ftp server with a username and password
                // an FtpAuthenicationException is thrown if the authentication certificate 
                // is rejected or is invalid
                for (int i = 0; i < 100; i++)
                {
                    ftp.Open(tbUsername.Text, tbPassword.Text);

                    // get a file and store it locally to disk
                    ftp.GetFile(tbRemoteFile.Text, tbLocalFile.Text, FileAction.Create);
                    ftp.Close();
                }
            }
            catch (FtpAuthenticationException)
            {
                MessageBox.Show("Certificate authentication was rejected or is invalid.");
            }
            finally
            {
                ftp.Close();
            }
        }

        private void ftp_ValidateServerCertificate(object sender, ValidateServerCertificateEventArgs e)
        {
            // display the certificate to the user and ask the user to either accept or reject the certificate
            //if (MessageBox.Show(e.Certificate.ToString(), "Accept Certificate?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                // the user accepted the certicate so we need to inform the FtpClient Component that the certificate is valid
                // be setting the IsCertificateValue property to true
                e.IsCertificateValid = true;
            //}
        }

        private void btnPutFile_Click(object sender, EventArgs e)
        {
            // clear the bytes transferred label
            lblBytesTransferred.Text = "";

            // create a new ftpclient object with the host and port number to use
            // set the security protocol to use - in this case we are instructing the FtpClient to use either
            // the SSL 3.0 protocol or the TLS 1.0 protocol depending on what the FTP server supports
            FtpClient ftp = new FtpClient(tbFtpHost.Text, Int32.Parse(tbFtpPort.Text), FtpSecurityProtocol.Tls1OrSsl3Implicit);

            // register an event hook so that we can view and accept the security certificate that is given by the FTP server
            ftp.ValidateServerCertificate += new EventHandler<ValidateServerCertificateEventArgs>(ftp_ValidateServerCertificate);

            // registered an event hook for the transfer complete event so we get an update when the transfer is over
            ftp.TransferComplete += new EventHandler<TransferCompleteEventArgs>(ftp_TransferComplete);

            try
            {
                // open a connection to the ftp server with a username and password
                // an FtpAuthenicationException is thrown if the authentication certificate 
                // is rejected or is invalid
                ftp.Open(tbUsername.Text, tbPassword.Text);

                // put a local file and store it remotely as the supplied file location and name 
                ftp.PutFile(tbLocalFile.Text, tbRemoteFile.Text, FileAction.Create);
            }
            catch (FtpAuthenticationException)
            {
                MessageBox.Show("Certificate authentication was rejected or is invalid.");
            }
            finally
            {
                // close the ftp connection
                ftp.Close();
            }
        }

        // transfer complete event hook function
        private void ftp_TransferComplete(object sender, TransferCompleteEventArgs e)
        {
            // update the bytes transferred label
            lblBytesTransferred.Text = e.BytesTransferred.ToString() + " bytes transferred in " + e.ElapsedTime.Seconds.ToString() + " seconds";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbFtpHost.Text = "141.61.102.16";
            tbFtpPort.Text = "1299";
            tbUsername.Text = "Teste";
            tbPassword.Text = "123456";
        }


    }
}