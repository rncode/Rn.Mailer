using System;
using NSubstitute;
using NUnit.Framework;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Models;
using Rn.Mailer.CoreTestObjects.Builders;
using Rn.MailerTests.TestSupport;

namespace Rn.MailerTests.Services
{
    [TestFixture]
    public class TestMailAccountService
    {
        [Test]
        public void MailAccountService_ShouldConstruct()
        {
            Assert.IsNotNull(Builder.BuildMailAccountService());
        }

        [Test]
        public void GetMailAccount_GivenInvalidAccountId_ShouldThrow()
        {
            // Arrange
            var service = Builder.BuildMailAccountService();

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => service.GetMailAccount(0));

            // Assert
            Assert.IsInstanceOf<ArgumentException>(ex);
            StringAssert.Contains("no mail account found with id:0", ex.Message);
        }

        [Test]
        public void GetMailAccount_GivenInvalidAccountId_ShouldLogWarning()
        {
            // Arrange
            var logger = Substitute.For<IRnLogger>();
            var service = Builder.BuildMailAccountService(logger);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => service.GetMailAccount(0));

            // Assert
            logger.Received(1).Warn("MailAccountService.GetMailAccount() no mail account found with id:0");
        }

        [Test]
        public void GetMailAccount_GivenValidAccountId_ShouldCallRepo()
        {
            // Arrange
            var repo = Substitute.For<IMailAccountRepo>();
            var service = Builder.BuildMailAccountService(mailAccountRepo: repo);

            // Act
            var account = service.GetMailAccount(1, false).Result;

            // Assert
            repo.Received(1).GetMailAccount(1, false);
        }

        [Test]
        public void GetMailAccount_GivenToldToIncludeUserAccount_ShouldPassFlagToRepo()
        {
            // Arrange
            var repo = Substitute.For<IMailAccountRepo>();
            var service = Builder.BuildMailAccountService(mailAccountRepo: repo);

            // Act
            var account = service.GetMailAccount(1, true).Result;

            // Assert
            repo.Received(1).GetMailAccount(1, true);
        }

        [Test]
        public void GetMailAccount_GivenNoAccountFound_ShouldLogDebug()
        {
            // Arrange
            var logger = Substitute.For<IRnLogger>();
            var repo = Substitute.For<IMailAccountRepo>();
            var service = Builder.BuildMailAccountService(logger, repo);

            repo.GetMailAccount(1).Returns((MailAccount) null);

            // Act
            var account = service.GetMailAccount(1).Result;

            // Assert
            logger.Received(1).Debug("MailAccountService.GetMailAccount() no mail account found with id:1");
        }

        [Test]
        public void GetMailAccount_GivenAccountExists_ShouldReturnIt()
        {
            // Arrange
            var logger = Substitute.For<IRnLogger>();
            var repo = Substitute.For<IMailAccountRepo>();
            var service = Builder.BuildMailAccountService(logger, repo);
            var mailAccount = new MailAccountBuilder().AsValidAccount().WithValidUserAccount().Build();

            repo.GetMailAccount(1).Returns(mailAccount);

            // Act
            var account = service.GetMailAccount(1).Result;

            // Assert
            Assert.IsNotNull(account);
            Assert.AreEqual(account, mailAccount);
        }
    }
}
