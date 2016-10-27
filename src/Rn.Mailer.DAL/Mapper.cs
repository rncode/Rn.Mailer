using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public static class Mapper
    {
        public static MailUser AsMailUser(this MailUserEntity source, bool mapPassword = true)
        {
            if (source == null)
                return null;

            var mapped = new MailUser
            {
                LastLoginDateUtc = source.LastLoginDateUtc,
                DisplayName = source.DisplayName,
                Enabled = source.Enabled,
                Username = source.Username,
                Id = source.Id,
                CreationDateUtc = source.CreationDateUtc
            };

            if (mapPassword)
                mapped.Password = source.Password;

            return mapped;
        }

        public static MailAccount AsMailAccount(this MailAccountEntity source, bool mapPassword = true)
        {
            if (source == null)
                return null;

            var mapped = new MailAccount
            {
                Enabled = source.Enabled,
                Id = source.Id,
                SmtpHost = source.SmtpHost,
                UserId = source.UserId,
                SmtpUsername = source.SmtpUsername,
                User = source.User.AsMailUser(),
                FromDisplayName = source.FromDisplayName,
                FromAddress = source.FromAddress,
                EnableSsl = source.EnableSsl,
                SmtpPort = source.SmtpPort,
                CreationDateUtc = source.CreationDateUtc
            };

            if (mapPassword)
                mapped.SmtpPassword = source.SmtpPassword;

            return mapped;
        }

        public static MailApiKey AsMailApiKey(this MailApiKeyEntity source, bool mapPassword = true)
        {
            if (source == null)
                return null;

            var mapped = new MailApiKey
            {
                MailAccount = source.MailAccount.AsMailAccount(mapPassword),
                Enabled = source.Enabled,
                Id = source.Id,
                CreationDateUtc = source.CreationDateUtc,
                MailSendCount = source.MailSendCount,
                MailAccountId = source.MailAccountId,
                ApiKey = source.ApiKey
            };

            return mapped;
        }
    }
}
