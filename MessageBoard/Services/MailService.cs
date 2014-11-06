using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Microsoft.Owin.Security.Twitter.Messages;

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
                // Add logging
                return false;
            }

            return true;
        }
    }
}