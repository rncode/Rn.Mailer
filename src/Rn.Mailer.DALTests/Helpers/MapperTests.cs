using NUnit.Framework;
using Rn.Mailer.DAL.Helpers;
using Rn.Mailer.TestCore.Builders;

namespace Rn.Mailer.DALTests.Helpers
{
    [TestFixture]
    public class MapperTests
    {
        [Test]
        public void AsMailerUser_GivenNull_ShouldReturnNull()
        {
            Assert.IsNull(Mapper.AsMailerUser(null));
        }

        [Test]
        public void AsMailerUser_GivenValidUser_ShouldReturnMappedUser()
        {
            // Arrange
            var entity = new MailerUserEntityBuilder()
                .WithValidData().Build();

            // Act
            var mapped = entity.AsMailerUser();

            // Assert
            Assert.AreEqual(entity.Id, mapped.Id);
            Assert.AreEqual(entity.Enabled, mapped.Enabled);
            Assert.AreEqual(entity.DateAddedUtc, mapped.DateAddedUtc);
            Assert.AreEqual(entity.Username, mapped.Username);
            Assert.AreEqual(entity.Password, mapped.Password);
            Assert.AreEqual(entity.DisplayName, mapped.DisplayName);
        }

        [Test]
        public void AsMailerUser_GivenWasToldNotToMapPassword_ShouldNotMapPassword()
        {
            // Arrange
            var entity = new MailerUserEntityBuilder()
                .WithValidData().Build();

            // Act
            var mapped = entity.AsMailerUser(false);

            // Assert
            Assert.AreEqual(entity.Id, mapped.Id);
            Assert.AreEqual(entity.Enabled, mapped.Enabled);
            Assert.AreEqual(entity.DateAddedUtc, mapped.DateAddedUtc);
            Assert.AreEqual(entity.Username, mapped.Username);
            Assert.IsTrue(string.IsNullOrWhiteSpace(mapped.Password));
            Assert.AreEqual(entity.DisplayName, mapped.DisplayName);
        }
    }
}
