using System;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DALTests.TestSupport.Builders
{
    public class MailAccountEntityBuilder
    {
        private readonly MailAccountEntity _account;

        public MailAccountEntityBuilder()
        {
            _account = new MailAccountEntity();
        }

        public MailAccountEntityBuilder AsValidObject()
        {
            _account.Id = 1;
            _account.Enabled = true;
            _account.CreationDateUtc = DateTime.UtcNow;
            _account.UserId = 1;
            _account.SmtpUsername = "smtp-username";
            _account.SmtpPassword = "smtp-password";
            _account.SmtpHost = "smtp-host";
            _account.SmtpPort = 25;
            _account.EnableSsl = true;
            _account.FromAddress = "niemand.richard@gmail.com";
            _account.FromDisplayName = "Richard Niemand";
            _account.RedirectToDisk = false;
            _account.User = new MailUserEntityBuilder().AsValidObject().Build();

            return this;
        }

        public MailAccountEntityBuilder WithRedirectToDisk(bool redirectToDisk)
        {
            _account.RedirectToDisk = redirectToDisk;

            return this;
        }

        public MailAccountEntity Build()
        {
            return _account;
        }
    }
}
