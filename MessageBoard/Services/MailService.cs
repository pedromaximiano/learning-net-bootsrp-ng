using System;
using System.Diagnostics;
using System.Net.Mail;

namespace MessageBoard.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string message)
        {
            try
            {
                var msg = new MailMessage(from, to, subject, message);
                var client = new SmtpClient();

                client.Send(msg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return false;
            }

            return true;
        }
    }
}