using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
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
                SeedMailAccounts(helper);
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

        private static void SeedMailAccounts(InitializerHelper helper)
        {
            var me = helper.Users.First(x => x.Username.Equals("richardn"));

            var accountsFile = ConfigurationManager.AppSettings["Rn.Mailer.Seed.MailAccounts"];
            var accountLines = File.ReadAllLines(accountsFile);
            var accounts = new List<MailAccountEntity>();
            var parsedHeader = false;

            // todo: document the expected format for the mail accounts CSV file
            foreach (var account in accountLines)
            {
                if (string.IsNullOrWhiteSpace(account)) continue;

                // Skip the first row - this is the CSV file header
                if (!parsedHeader)
                {
                    parsedHeader = true;
                    continue;
                }

                var bits = account.Split(',');

                // todo: add better CSV file parsing here...
                accounts.Add(new MailAccountEntity
                {
                    Username = bits[0],
                    DateAddedUtc = DateTime.UtcNow,
                    Enabled = true,
                    MailsSent = 0,
                    Password = bits[1],
                    UserId = me.Id,
                    Host = bits[2],
                    Port = int.Parse(bits[3]),
                    UseSsl = bool.Parse(bits[4]),
                    FromAddress = bits[5],
                    FromName = bits[6]
                });
            }

            // Check to see if we have something to add
            if (accounts.Count == 0) return;

            helper.AddMailAccounts(accounts);
        }
    }
}