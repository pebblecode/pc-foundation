using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using PebbleCode.Framework.Configuration;
using System.IO;

namespace PebbleCode.Framework
{
    public class Emailer : IDisposable
    {
        private readonly SmtpClient _client;
        private readonly MailMessage _message;

        public string SenderEmail { get; set; }
        public string SenderDisplayName { get; set; }

        public Emailer()
        {
            _client =
                new SmtpClient
                    {
                        Host = MailSettings.Host,
                        Port = MailSettings.Port,
                        EnableSsl = MailSettings.SslEnabled,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(MailSettings.Username, MailSettings.Password)
                    };
            _message = new MailMessage();
            SenderEmail = MailSettings.Username;
            SenderDisplayName = MailSettings.DisplayName;
        }

        public void AddRecipient(params string[] recipients)
        {
            foreach (var recipient in recipients.Where(recipient => !string.IsNullOrWhiteSpace(recipient)))
                _message.To.Add(recipient);
        }

        public void AttachFile(params string[] filePaths)
        {
            foreach (var filePath in filePaths.Where(File.Exists))
                _message.Attachments.Add(new Attachment(filePath));
        }

        public virtual bool Send(string subject, string body)
        {
            if (_message.To.Count > 0)
            {
                _message.From = new MailAddress(SenderEmail, SenderDisplayName);
                _message.Subject = subject;
                _message.Body = body;

                _client.Send(_message);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            if(_client != null)
                _client.Dispose();
        }
    }
}
