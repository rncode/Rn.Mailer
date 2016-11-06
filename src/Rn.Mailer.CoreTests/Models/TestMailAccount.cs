using NUnit.Framework;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.CoreTests.Models
{
    [TestFixture]
    public class TestMailAccount
    {
        [Test]
        public void MailAccount_ShouldConstruct()
        {
            Assert.IsNotNull(new MailAccount());
        }

        [Test]
        public void UseDefaultCredentials_GivenNoCredentialsProvided_ShouldReturnTrue()
        {
            var mailAccount = new MailAccount();

            Assert.IsTrue(mailAccount.UseDefaultCredentials());
        }

        [Test]
        public void UseDefaultCredentials_GivenHasCredentials_ShouldReturnFalse()
        {
            var account = new MailAccount
            {
                SmtpUsername = "username",
                SmtpPassword = "password"
            };

            Assert.IsFalse(account.UseDefaultCredentials());
        }

        [Test]
        public void UseDefaultCredentials_GivenHasUsername_ShouldReturnFalse()
        {
            var account = new MailAccount
            {
                SmtpUsername = "username"
            };

            Assert.IsFalse(account.UseDefaultCredentials());
        }

        [Test]
        public void UseDefaultCredentials_GivenHasPassword_ShouldReturnFalse()
        {
            var account = new MailAccount
            {
                SmtpPassword = "password"
            };

            Assert.IsFalse(account.UseDefaultCredentials());
        }
    }
}
