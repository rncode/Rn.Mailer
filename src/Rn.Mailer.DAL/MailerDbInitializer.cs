using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Rn.Core.Extensions;
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
                SeedMailAccounts(helper);
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

            // Ensure that we have a valid directory to work with
            var baseDir = helper.WebConfig.GetAppSetting("Rn.Mailer.DevSeedBaseDir")
                .AppendIfMissing("\\");

            if (!Directory.Exists(baseDir))
            {
                throw new DirectoryNotFoundException($"Unable to find directory: {baseDir}");
            }

            // Get all account information from the expected accounts file
            var accountFilePath = $"{baseDir}mail-accounts.csv";
            if (!File.Exists(accountFilePath)) return;

            var headerRow = true;
            var lines = File.ReadAllLines(accountFilePath);
            var admin = helper.Users.FirstOrDefault(x => x.Username.Equals("admin"));
            var seedAccounts = new List<MailAccountEntity>();

            // Populate the "seedAccounts" list with all the CSV lines
            foreach (var rawAccount in lines)
            {
                // Cater for the header row in the mail-accounts.csv file
                if (headerRow)
                {
                    headerRow = false;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(rawAccount)) continue;

                // Create our account we wish to seed
                var rawParts = rawAccount.Split(',');

                seedAccounts.Add(new MailAccountEntity
                {
                    SmtpUsername = rawParts[0].Trim(),
                    SmtpPassword = rawParts[1].Trim(),
                    SmtpHost = rawParts[2].Trim(),
                    SmtpPort = int.Parse(rawParts[3].Trim()),
                    EnableSsl = bool.Parse(rawParts[4].Trim()),
                    FromAddress = rawParts[5].Trim(),
                    FromDisplayName = rawParts[6].Trim(),
                    Enabled = bool.Parse(rawParts[7].Trim()),
                    CreationDateUtc = DateTime.UtcNow,
                    UserId = admin.Id
                });
            }

            // Finally append the extracted accounts to the DB
            helper.AddMailAccounts(seedAccounts);
        }
    }
}