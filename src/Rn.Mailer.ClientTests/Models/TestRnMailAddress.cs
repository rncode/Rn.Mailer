using NUnit.Framework;
using Rn.Mailer.Client.Enums;
using Rn.Mailer.Client.Models;

namespace Rn.Mailer.ClientTests.Models
{
    [TestFixture]
    public class TestRnMailAddress
    {
        private const string TestEmail = "niemand.richard@gmail.com";
        private const string TestName = "Richard Niemand";

        [Test]
        public void Constructor_GivenNoArguments_ShouldConstruct()
        {
            Assert.IsNotNull(new RnMailAddress());
        }

        [Test]
        public void Constructor_GivenNoArguments_ShouldDefaultValues()
        {
            // Act
            var address = new RnMailAddress();

            // Assert
            Assert.AreEqual(string.Empty, address.Email);
            Assert.AreEqual(string.Empty, address.Name);
            Assert.AreEqual(MailPartEncoding.UTF8, address.Encoding);
        }

        [Test]
        public void Constructor_GivenEmailAddress_ShouldSetEmailAndName()
        {
            // Act
            var address = new RnMailAddress(TestEmail);

            // Assert
            Assert.AreEqual(TestEmail, address.Name);
            Assert.AreEqual(TestEmail, address.Email);
            Assert.AreEqual(MailPartEncoding.UTF8, address.Encoding);
        }

        [Test]
        public void Constructor_GivenEmailAndName_ShouldSetValues()
        {
            // Act
            var address = new RnMailAddress(TestEmail, TestName);

            // Assert
            Assert.AreEqual(TestEmail, address.Email);
            Assert.AreEqual(TestName, address.Name);
            Assert.AreEqual(MailPartEncoding.UTF8, address.Encoding);
        }

        [Test]
        public void Constructor_GivenEmailNameAndEncodig_ShouldSetValues()
        {
            // Act
            var address = new RnMailAddress(TestEmail, TestName, MailPartEncoding.UTF7);

            // Assert
            Assert.AreEqual(TestEmail, address.Email);
            Assert.AreEqual(TestName, address.Name);
            Assert.AreEqual(address.Encoding, MailPartEncoding.UTF7);
        }

        [Test]
        public void IsValid_GivenNoEmail_ShouldReturnFalse()
        {
            // Arrange
            var address = new RnMailAddress();

            // Act
            var valid = address.IsValid();

            // Assert
            Assert.IsFalse(valid, "Email address is invalid");
        }

        [Test]
        public void IsValid_GivenInvalidEmail_ShouldReturnFalse()
        {
            // Arrange
            var address = new RnMailAddress("fofpoo@fdfd");

            // Act
            var valid = address.IsValid();

            // Assert
            Assert.IsFalse(valid, "Email address is invalid");
        }

        [Test]
        public void IsValid_GivenInvalidName_ShouldReturnFalse()
        {
            // Arrange
            var address = new RnMailAddress(TestEmail, "");

            // Act
            var isValid = address.IsValid();

            // Assert
            Assert.IsFalse(isValid, "Invalid Name");
        }

        [Test]
        public void IsValid_GivenValidEmailAndName_ShouldSucceed()
        {
            // Arrange
            var address = new RnMailAddress(TestEmail, TestName);

            // Act
            var isValid = address.IsValid();

            // Assert
            Assert.IsTrue(isValid, "Valid RnMailAddress information supplied");
        }
    }
}
