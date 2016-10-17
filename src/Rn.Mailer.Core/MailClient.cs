using System.Net.Mail;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Core
{
    public interface IMailClient
    {

    }

    public class MailClient : IMailClient
    {
        private readonly MailAccount _mailAccount;
        private readonly SmtpClient _smtpClient;

        public MailClient(MailAccount mailAccount)
        {
            _mailAccount = mailAccount;





            _smtpClient = new SmtpClient
            {
                UseDefaultCredentials = MustUseDefaultCredentials(mailAccount)
            };
        }

        // Helper methods
        private bool MustUseDefaultCredentials(MailAccount mailAccount)
        {
            if (!string.IsNullOrWhiteSpace(mailAccount.Username))
                return false;

            if (!string.IsNullOrWhiteSpace(mailAccount.Password))
                return false;

            return true;
        }
    }
}
