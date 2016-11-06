using System;
using NSubstitute;
using NUnit.Framework;
using Rn.Core.Config;
using Rn.Core.Encryption;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Models;
using Rn.Mailer.CoreTestObjects;
using Rn.Mailer.CoreTestObjects.Builders;
using Rn.MailerTests.TestSupport;

namespace Rn.MailerTests.Services
{
    [TestFixture]
    public class TestUserAccountService
    {
        [Test]
        public void UserAccountService_ShouldConstruct()
        {
            Assert.IsNotNull(Builder.BuildUserAccountService());
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void GetUserAccount_GivenInvalidUserId_ShouldThrow(int userId)
        {
            // Arrange
            var service = Builder.BuildUserAccountService();

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => service.GetUserAccount(userId));

            // Assert
            Assert.IsInstanceOf<ArgumentException>(ex);
            StringAssert.Contains("Invalid userId provided:", ex.Message);
        }

        [Test]
        public void GetUserAccount_GivenInvalidUserId_ShouldLogWarning()
        {
            // Arrange
            var logger = Substitute.For<IRnLogger>();
            var service = Builder.BuildUserAccountService(logger);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => service.GetUserAccount(0));

            // Assert
            logger.Received(1).Warn(Arg.Is<string>(s =>
                s.Contains("UserAccountService.GetUserAccount() invalid userId provided (0)")));
        }

        [Test]
        public void GetUserAccount_GivenValidUserId_ShouldGetUserFromRepo()
        {
            // Arrange
            var repo = Substitute.For<IUserAccountRepo>();
            var service = Builder.BuildUserAccountService(userAccountRepo: repo);

            // Act
            var user = service.GetUserAccount(1).Result;

            // Assert
            repo.Received(1).GetUserAccount(1);
        }

        [Test]
        public void GetUserAccount_GivenNoUserAccountFound_ShouldLogDebugMessage()
        {
            // Arrange
            var logger = Substitute.For<IRnLogger>();
            var repo = Substitute.For<IUserAccountRepo>();
            var service = Builder.BuildUserAccountService(logger, repo);

            repo.GetUserAccount(1).Returns((MailUser) null);

            // Act
            var user = service.GetUserAccount(1).Result;

            // Assert
            logger.Received(1).Debug("UserAccountService.GetUserAccount() no user account found for userId (1)");
        }

        [Test]
        public void GetUserAccount_GivenUserAccountFound_ShouldReturnIt()
        {
            // Arrange
            var repo = Substitute.For<IUserAccountRepo>();
            var service = Builder.BuildUserAccountService(userAccountRepo: repo);
            var serviceUser = new MailUserBuilder().AsValidUser().Build();

            repo.GetUserAccount(1).Returns(serviceUser);

            // Act
            var user = service.GetUserAccount(1).Result;

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(user, serviceUser);
        }

        [Test]
        public void GetUserAccount_GivenHasAccount_ShouldDecryptPassword()
        {
            // Arrange
            var repo = Substitute.For<IUserAccountRepo>();
            var encryptionService = TestObjects.GetEncryptionService();
            var encryptedPass = encryptionService.EncryptText("password");

            var serviceUser = new MailUserBuilder()
                .AsValidUser()
                .WithPassword(encryptedPass)
                .Build();

            repo.GetUserAccount(1).Returns(serviceUser);

            var service = Builder.BuildUserAccountService(
                userAccountRepo: repo,
                encryptionService: encryptionService);

            // Act
            var user = service.GetUserAccount(1).Result;

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("password", user.Password);
        }
    }
}
