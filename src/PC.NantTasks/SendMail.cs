using System;
using System.Collections.Generic;
using System.Text;
using NAnt.Core.Attributes;
using NAnt.Core;
using System.Net.Mail;
using System.Net;

namespace PebbleCode.NantTasks
{
    [TaskName("sendmail")]
    public class SendMail : Task
    {
        /// <summary>
        /// Set some default values
        /// </summary>
        public SendMail()
        {
            Port = 587;
        }

        [TaskAttribute("from", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string From { get; set; }

        [TaskAttribute("fromDisplay", Required = false)]
        [StringValidator(AllowEmpty = true)]
        public string FromDisplay { get; set; }

        /// <summary>
        /// Comma seperated list of recipient email addresses
        /// </summary>
        [TaskAttribute("to", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string To { get; set; }

        /// <summary>
        /// SMTP host password
        /// </summary>
        [TaskAttribute("password", Required = true)]
        [StringValidator(AllowEmpty = true)]
        public string Password { get; set; }

        /// <summary>
        /// SMTP host 
        /// </summary>
        [TaskAttribute("host", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string Host { get; set; }
        
        /// <summary>
        /// Message
        /// </summary>
        [TaskAttribute("message", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string Message { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        [TaskAttribute("subject", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public string Subject { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        [TaskAttribute("attachments", Required = false)]
        [StringValidator(AllowEmpty = true)]
        public string Attachments { get; set; }

        /// <summary>
        /// SSL usage? 
        /// </summary>
        [TaskAttribute("useSsl", Required = false)]
        [BooleanValidator()]
        public bool UseSsl { get; set; }

        /// <summary>
        /// Port number
        /// </summary>
        [TaskAttribute("port", Required = false)]
        [Int32Validator()]
        public int Port { get; set; }

        protected override void ExecuteTask()
        {
            SendMessageWithAttachment();
        }

        /// <summary>
        /// Transmit an email message with
        /// attachments
        /// </summary>
        /// <param name="sendTo">Recipient Email Address</param>
        /// <param name="sendFrom">Sender Email Address</param>
        /// <param name="sendSubject">Subject Line Describing Message</param>
        /// <param name="sendMessage">The Email Message Body</param>
        /// <param name="attachments">A string array pointing to the location of each attachment</param>
        /// <returns>Status Message as String</returns>
        public void SendMessageWithAttachment()
        {
            MailAddress fromAdd = new MailAddress(From, FromDisplay);

            //Build the SMTP client that will sent the message using gmail's server
            var smtp = new SmtpClient
            {
                Host = Host,
                Port = Port,
                EnableSsl = UseSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAdd.Address, Password)
            };

            //Build a mail message
            using (var message = new MailMessage()
            {
                Subject = Subject,
                Body = Message,
                From = fromAdd
            })
            {
                foreach (string toAddress in To.Split(';', ','))
                {
                    message.To.Add(toAddress);
                }
                    
                //Add the file attachments if required.
                if (Attachments != null)
                {
                    Array.ForEach(Attachments.Split(';', ','), fileName => message.Attachments.Add(new Attachment(fileName, "text/plain")));
                }
                smtp.Send(message);
            }
        }    
    }
}
