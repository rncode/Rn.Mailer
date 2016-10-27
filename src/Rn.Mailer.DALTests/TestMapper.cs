using NUnit.Framework;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL;
using Rn.Mailer.DAL.Entities;
using Rn.Mailer.DALTests.TestSupport;
using Rn.Mailer.DALTests.TestSupport.Builders;

namespace Rn.Mailer.DALTests
{
    [TestFixture]
    public class TestMapper
    {
        [Test]
        public void AsMailUser_GivenNull_ShouldReturnNull()
        {
            Assert.IsNull(Mapper.AsMailUser(null));
        }

        [Test]
        public void AsMailUser_GivenMailUserEntity_ShouldReturnMailUser()
        {
            // Act
            var user = new MailUserEntity().AsMailUser();

            // Assert
            Assert.IsNotNull(user);
            Assert.IsInstanceOf<MailUser>(user);
        }

        [Test]
        public void AsMailUser_GivenValidMailUserEntity_ShouldMapAllFields()
        {
            // Arrange
            var userEntity = new MailUserEntityBuilder().AsValidObject().Build();

            // Act
            var user = userEntity.AsMailUser();

            // Assert
            Assert.IsNotNull(user);
            RnAssert.AreEqual(userEntity, user);
        }

        [Test]
        public void AsMailUser_GivenWasToldToSkipPasswordMapping_ShouldNotMapPassword()
        {
            // Arrange
            var userEntity = new MailUserEntityBuilder().AsValidObject().Build();

            // Act
            var user = userEntity.AsMailUser(false);

            // Assert
            Assert.IsNotNull(user);
            Assert.IsTrue(string.IsNullOrWhiteSpace(user.Password));
        }

        [Test]
        public void AsMailAccount_GivenNull_ShouldReturnNull()
        {
            Assert.IsNull(Mapper.AsMailAccount(null));
        }

        [Test]
        public void AsMailAccount_GivenMailAccountEntity_ShouldReturnMailAccount()
        {
            // Act
            var account = new MailAccountEntity().AsMailAccount();

            // Assert
            Assert.IsNotNull(account);
            Assert.IsInstanceOf<MailAccount>(account);
        }

        [Test]
        public void AsMailAccount_GivenValidAccount_ShouldMapAllProperties()
        {
            // Arrange
            var accountEntity = new MailAccountEntityBuilder().AsValidObject().Build();

            // Act
            var account = accountEntity.AsMailAccount();

            // Assert
            Assert.IsNotNull(account);
            RnAssert.AreEqual(accountEntity, account);
        }

        [Test]
        public void AsMailAccount_GivenWasToldToSkipPasswordMapping_ShouldNotMapPassword()
        {
            // Arrange
            var accountEntity = new MailAccountEntityBuilder().AsValidObject().Build();

            // Act
            var account = accountEntity.AsMailAccount(false);

            // Assert
            Assert.IsNotNull(account);
            Assert.IsTrue(string.IsNullOrWhiteSpace(account.SmtpPassword));
        }

        [Test]
        public void AsMailApiKey_GivenNull_ShouldReturnNull()
        {
            Assert.IsNull(Mapper.AsMailApiKey(null));
        }

        [Test]
        public void AsMailApiKey_GivenMailApiKeyEntity_ShouldReturnMailApiKey()
        {
            // Act
            var mapped = Mapper.AsMailApiKey(new MailApiKeyEntity());

            // Assert
            Assert.IsNotNull(mapped);
            Assert.IsInstanceOf<MailApiKey>(mapped);
        }

        [Test]
        public void AsMailApiKey_GivenValidMailApiKeyEntity_ShouldMapAllProperties()
        {
            // Arrange
            var keyEntity = new MailApiKeyEntityBuilder().AsValidObject().Build();

            // Act
            var apiKey = keyEntity.AsMailApiKey();

            // Assert
            Assert.IsNotNull(apiKey);
            RnAssert.AreEqual(keyEntity, apiKey);
        }
    }
}
