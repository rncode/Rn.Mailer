using NSubstitute;
using NUnit.Framework;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Repos;
using Rn.MailerTests.TestSupport;

namespace Rn.MailerTests.Services
{
    [TestFixture]
    public class TestUserService
    {
        [Test]
        public void UserService_ShouldConstruct()
        {
            Assert.IsNotNull(Builder.BuildUserService());
        }

        [Test]
        public void GetUserById_GivenIsCalled_ShouldCallThroughToRepo()
        {
            // Arrange
            var userRepo = Substitute.For<IUserRepo>();
            var userService = Builder.BuildUserService(userRepo);

            // Act
            var user = userService.GetUserById(1).Result;

            // Assert
            userRepo.Received(1).GetUserById(1);
        }

        [Test]
        public void GetUserById_GivenNoUser_ShouldReturnNull()
        {
            // Arrange
            var userRepo = Substitute.For<IUserRepo>();
            var userService = Builder.BuildUserService(userRepo);

            // Act
            var user = userService.GetUserById(1).Result;

            // Assert
            Assert.IsNull(user);
        }

        [Test]
        public void GetUserById_GivenHasUser_ShouldReturnUser()
        {
            // Arrange
            var userRepo = Substitute.For<IUserRepo>();
            var userService = Builder.BuildUserService(userRepo);
            userService.GetUserById(1).Returns(new MailerUser {Id = 1});

            // Act
            var user = userService.GetUserById(1).Result;

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
        }
    }
}
