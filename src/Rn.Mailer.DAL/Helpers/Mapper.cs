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
    }
}
