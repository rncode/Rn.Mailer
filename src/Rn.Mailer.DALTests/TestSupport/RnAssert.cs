using NUnit.Framework;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DALTests.TestSupport
{
    public static class RnAssert
    {
        public static void AreEqual(MailUserEntity source, MailUser target, bool checkPassword = true)
        {
            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.Enabled, target.Enabled);
            Assert.AreEqual(source.LastLoginDateUtc, target.LastLoginDateUtc);
            Assert.AreEqual(source.CreationDateUtc, target.CreationDateUtc);
            Assert.AreEqual(source.Username, target.Username);
            Assert.AreEqual(source.DisplayName, target.DisplayName);

            if (checkPassword)
                Assert.AreEqual(source.Password, target.Password);
        }

        public static void AreEqual(MailAccountEntity source, MailAccount target, bool checkPassword = true)
        {
            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.Enabled, target.Enabled);
            Assert.AreEqual(source.CreationDateUtc, target.CreationDateUtc);
            Assert.AreEqual(source.UserId, target.UserId);
            Assert.AreEqual(source.SmtpUsername, target.SmtpUsername);
            Assert.AreEqual(source.SmtpHost, target.SmtpHost);
            Assert.AreEqual(source.SmtpPort, target.SmtpPort);
            Assert.AreEqual(source.EnableSsl, target.EnableSsl);
            Assert.AreEqual(source.FromAddress, target.FromAddress);
            Assert.AreEqual(source.FromDisplayName, target.FromDisplayName);

            if(checkPassword)
                Assert.AreEqual(source.SmtpPassword, target.SmtpPassword);

            RnAssert.AreEqual(source.User, target.User, checkPassword);
        }

        public static void AreEqual(MailApiKeyEntity source, MailApiKey target, bool checkPassword = true)
        {
            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.Enabled, target.Enabled);
            Assert.AreEqual(source.CreationDateUtc, target.CreationDateUtc);
            Assert.AreEqual(source.MailAccountId, target.MailAccountId);
            Assert.AreEqual(source.MailSendCount, target.MailSendCount);
            Assert.AreEqual(source.ApiKey, target.ApiKey);

            RnAssert.AreEqual(source.MailAccount, target.MailAccount, checkPassword);
        }
    }
}
