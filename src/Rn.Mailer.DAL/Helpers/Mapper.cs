using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL.Helpers
{
    public static class Mapper
    {
        public static MailerUser AsMailerUser(this MailerUserEntity user, bool mapPassword = true)
        {
            if (user == null)
                return null;

            var mapped = new MailerUser
            {
                Id = user.Id,
                DateAddedUtc = user.DateAddedUtc,
                DisplayName = user.DisplayName,
                Enabled = user.Enabled,
                Username = user.Username
            };

            if (mapPassword)
                mapped.Password = user.Password;

            return mapped;
        }

        // todo: add tests
        public static MailAccount AsMailAccount(this MailAccountEntity account, bool mapPassword = true)
        {
            if (account == null)
                return null;

            var mapped = new MailAccount
            {
                Id = account.Id,
                Username = account.Username,
                DateAddedUtc = account.DateAddedUtc,
                Enabled = account.Enabled,
                MailsSent = account.MailsSent,
                UserId = account.UserId
            };

            if (mapPassword)
                mapped.Password = account.Password;

            return mapped;
        }
    }
}
