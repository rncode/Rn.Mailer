using System;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.CoreTestObjects.Builders
{
    public class MailAccountBuilder
    {
        private readonly MailAccount _mailAccount;

        public MailAccountBuilder()
        {
            _mailAccount = new MailAccount();
        }

        public MailAccountBuilder AsValidAccount()
        {
            _mailAccount.Id = 1;
            _mailAccount.Enabled = true;
            _mailAccount.CreationDateUtc = new DateTime(2016, 11, 1, 12, 0, 0);
            _mailAccount.UserId = 1;
            _mailAccount.SmtpUsername = "username";
            _mailAccount.SmtpPassword = "password";
            _mailAccount.SmtpHost = "mail.google.com";
            _mailAccount.SmtpPort = 443;
            _mailAccount.FromAddress = "niemand.richard@gmail.com";
            _mailAccount.FromDisplayName = "Richard Niemand";
            _mailAccount.EnableSsl = true;

            return this;
        }

        public MailAccountBuilder WithId(int id)
        {
            _mailAccount.Id = id;

            return this;
        }

        public MailAccountBuilder WithSmtpPassword(string password)
        {
            _mailAccount.SmtpPassword = password;

            return this;
        }

        public MailAccountBuilder WithValidUserAccount()
        {
            _mailAccount.User = new MailUserBuilder().AsValidUser().Build();
            _mailAccount.UserId = _mailAccount.User.Id;

            return this;
        }

        public MailAccountBuilder WithUserAccountPassword(string password)
        {
            if (_mailAccount.User == null)
                return this;

            _mailAccount.User.Password = password;

            return this;
        }

        public MailAccount Build()
        {
            return _mailAccount;
        }
    }
}
