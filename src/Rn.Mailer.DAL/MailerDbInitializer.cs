using System;
using System.Collections.Generic;
using System.Data.Entity;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public class MailerDbInitializer : DropCreateDatabaseIfModelChanges<MailerDbContext>
    {
        protected override void Seed(MailerDbContext context)
        {
            using (var helper = new MailerDbInitializerHelper(context))
            {
                SeedUserAccounts(helper);
            }

            base.Seed(context);
        }

        private static void SeedUserAccounts(MailerDbInitializerHelper helper)
        {
            helper.AddUsers(new List<MailUserEntity>
            {
                new MailUserEntity
                {
                    CreationDateUtc = DateTime.UtcNow,
                    DisplayName = "Administrator",
                    Username = "admin",
                    Enabled = true,
                    LastLoginDateUtc = DateTime.UtcNow,
                    Password = helper.EncryptionService.EncryptText("admin")
                }
            });
        }

        private static void SeedMailAccounts(MailerDbInitializerHelper helper)
        {
            if (!helper.DevelopmentMode) return;

            // todo: seed mail accounts
        }
    }
}