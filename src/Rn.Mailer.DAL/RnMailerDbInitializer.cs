using System;
using System.Collections.Generic;
using System.Data.Entity;
using Rn.Core.Encryption;
using Rn.Mailer.Core.Castle;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public class RnMailerDbInitializer : DropCreateDatabaseIfModelChanges<RnMailerDbContext>
    {
        protected override void Seed(RnMailerDbContext context)
        {
            using (var helper = new InitializerHelper(context))
            {
                SeedUsers(helper);
            }

            base.Seed(context);
        }

        private static void SeedUsers(InitializerHelper helper)
        {
            var encHelper = CastleHelper.Container.Resolve<IEncryptionService>();

            helper.AddUsers(new List<MailerUserEntity>
            {
                new MailerUserEntity
                {
                    DateAddedUtc = DateTime.UtcNow,
                    DisplayName = "Richard Niemand",
                    Username = "richardn",
                    Password = encHelper.EncryptText("password")
                }
            });
        }
    }
}