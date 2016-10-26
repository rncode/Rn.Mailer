using System.Net;
using System.Net.Mail;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Core
{
    public interface IMailClient
    {
        int MailAccountId { get; }
        int OwningUserId { get; }
    }

    public class MailClient : IMailClient
    {
        public int MailAccountId { get; }
        public int OwningUserId { get; }

        private readonly MailAccount _mailAccount;
        private readonly SmtpClient _smtpClient;

        public MailClient(MailAccount mailAccount)
        {
            // Set basic information about our mail account
            _mailAccount = mailAccount;
            OwningUserId = mailAccount.UserId;
            MailAccountId = mailAccount.Id;

            // Create our base SmtpClient
            _smtpClient = new SmtpClient
            {
                UseDefaultCredentials = MustUseDefaultCredentials(mailAccount),
                Host = mailAccount.Host,
                Port = mailAccount.Port,
                EnableSsl = mailAccount.UseSsl
            };

            // Decide if we need to set credentials for the clients user
            if (_smtpClient.UseDefaultCredentials == false)
            {
                _smtpClient.Credentials = new NetworkCredential
                {
                    UserName = mailAccount.Username,
                    Password = mailAccount.Password
                };
            }
        }

        // Helper methods
        public static bool MustUseDefaultCredentials(MailAccount mailAccount)
        {
            if (!string.IsNullOrWhiteSpace(mailAccount.Username))
                return false;

            if (!string.IsNullOrWhiteSpace(mailAccount.Password))
                return false;

            return true;
        }
    }
}
