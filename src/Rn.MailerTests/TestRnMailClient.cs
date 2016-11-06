using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Rn.Core.Config;
using Rn.Core.IO;
using Rn.Mailer;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.CoreTestObjects.Builders;
using Rn.MailerTests.TestSupport;

namespace Rn.MailerTests
{
    [TestFixture]
    public class TestRnMailClient
    {
        [Test]
        public void RnMailClient_ShouldConstruct()
        {
            Assert.IsNotNull(Builder.BuildRnMailClient());
        }

        [Test]
        public void Constructor_GivenWhenCalled_ShouldCheckForDiskRedirectionOverride()
        {
            // Arrange
            var webConfig = Substitute.For<IWebConfig>();

            // Act
            Builder.BuildRnMailClient(webConfig: webConfig);

            // Assert
            webConfig.Received(1).GetBoolAppSetting(RnMailClient.REDIRECT_TO_DISK, false);
        }

        [Test]
        public void Constructor_GivenRedirectToDisk_ShouldGenerateDiskPath()
        {
            // Arrange
            var webConfig = Substitute.For<IWebConfig>();
            webConfig.GetBoolAppSetting(RnMailClient.REDIRECT_TO_DISK, false).Returns(true);

            // Act
            Builder.BuildRnMailClient(webConfig: webConfig);

            // Assert
            webConfig.Received(1).GetAppSetting(RnMailClient.DISK_MAIL_FOLDER, Arg.Any<string>());
        }

        [Test]
        public void Constructor_GivenRedirectToDisk_ShouldCreateMailFolderIfMissing()
        {
            // Arrange
            var logger = Substitute.For<IRnLogger>();
            var webConfig = Substitute.For<IWebConfig>();
            var directory = Substitute.For<IDirectory>();

            webConfig
                .GetBoolAppSetting(RnMailClient.REDIRECT_TO_DISK, false)
                .Returns(true);

            webConfig
                .GetAppSetting(RnMailClient.DISK_MAIL_FOLDER, Arg.Any<string>())
                .Returns(@"c:\dev-mails\");

            directory.Exists(Arg.Any<string>()).Returns(false);

            // Act
            Builder.BuildRnMailClient(
                logger: logger,
                webConfig: webConfig,
                directory: directory);

            // Assert
            directory.Received(1).Exists(@"c:\dev-mails\00001\");
            directory.Received(1).CreateDirectory(@"c:\dev-mails\00001\");

            // ensure that we get the correct messages logged by the mail client's constructor
            logger.Received(1).Info("RnMailClient - mail pickup directory not found " +
                                    "(c:\\dev-mails\\00001\\), attempting to create it now");

            logger.Received(1).Debug("RnMailClient - successfully created mail pickup directory");
        }

        [Test]
        public void Constructor_GivenDirectoryContainsTilda_ShouldCorrectTheFilePath()
        {
            var logger = Substitute.For<IRnLogger>();
            var webConfig = Substitute.For<IWebConfig>();
            var directory = Substitute.For<IDirectory>();

            webConfig
                .GetBoolAppSetting(RnMailClient.REDIRECT_TO_DISK, false)
                .Returns(true);

            webConfig
                .GetAppSetting(RnMailClient.DISK_MAIL_FOLDER, Arg.Any<string>())
                .Returns(@"~");

            directory.Exists(Arg.Any<string>()).Returns(false);

            // Act
            Builder.BuildRnMailClient(
                logger: logger,
                webConfig: webConfig,
                directory: directory);

            // Assert
            directory.Received(1).Exists(Arg.Is<string>(s =>
                s.Contains("Rn.MailerTests\\") &&
                s.Contains("00001\\")));
        }

        [Test]
        public void GetMailDiskFolderPath_GivenNoOverrides_ShouldReturnDefaultFolder()
        {
            // Arrange
            var mailAccount = new MailAccountBuilder()
                .AsValidAccount()
                .WithId(1)
                .Build();

            var mailClient = Builder.BuildRnMailClient(mailAccount);

            // Act
            var path = mailClient.GetMailDiskFolderPath();

            // Assert
            Assert.IsNotNull(path);
            Assert.AreEqual("c:\\mails\\00001\\", path);
        }

        [Test]
        public void GetMailDiskFolderPath_GivenPathOverride_ShouldGenerateExpectedPath()
        {
            // Arrange
            var webConfig = Substitute.For<IWebConfig>();

            webConfig
                .GetAppSetting(RnMailClient.DISK_MAIL_FOLDER, Arg.Any<string>())
                .Returns("c:\\dev-mails\\");

            var mailAccount = new MailAccountBuilder()
                .AsValidAccount()
                .WithId(1)
                .Build();

            var mailClient = Builder.BuildRnMailClient(mailAccount, webConfig: webConfig);

            // Acts
            var path = mailClient.GetMailDiskFolderPath();

            // Assert
            Assert.IsNotNull(path);
            Assert.AreEqual("c:\\dev-mails\\00001\\", path);
        }
    }
}
