using NSubstitute;
using Rn.Core.Config;
using Rn.Core.Encryption;
using Rn.Core.IO;
using Rn.Mailer;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Models;
using Rn.Mailer.Services;

namespace Rn.MailerTests.TestSupport
{
    public static class Builder
    {
        public static MailAccountService BuildMailAccountService(
            IRnLogger logger = null,
            IMailAccountRepo mailAccountRepo = null,
            IEncryptionService encryptionService = null)
        {
            logger = logger ?? Substitute.For<IRnLogger>();
            mailAccountRepo = mailAccountRepo ?? Substitute.For<IMailAccountRepo>();
            encryptionService = encryptionService ?? Substitute.For<IEncryptionService>();

            return new MailAccountService(logger, mailAccountRepo, encryptionService);
        }

        public static UserAccountService BuildUserAccountService(
            IRnLogger logger = null,
            IUserAccountRepo userAccountRepo = null,
            IEncryptionService encryptionService = null)
        {
            logger = logger ?? Substitute.For<IRnLogger>();
            userAccountRepo = userAccountRepo ?? Substitute.For<IUserAccountRepo>();
            encryptionService = encryptionService ?? Substitute.For<IEncryptionService>();

            return new UserAccountService(logger, userAccountRepo, encryptionService);
        }

        public static RnMailClient BuildRnMailClient(
            MailAccount mailAccount = null,
            IRnLogger logger = null,
            IWebConfig webConfig = null,
            IDirectory directory = null)
        {
            // ensure that we have a mail account to work with
            if (mailAccount == null)
            {
                mailAccount = new MailAccount
                {
                    SmtpHost = "mail.goolge.com",
                    SmtpPort = 443,
                    Id = 1
                };
            }

            // ensure that we have all other required objects
            logger = logger ?? Substitute.For<IRnLogger>();
            directory = directory ?? Substitute.For<IDirectory>();

            // configure the default web.config reader
            if (webConfig == null)
            {
                webConfig = Substitute.For<IWebConfig>();

                webConfig // override for default behavior
                    .GetAppSetting(RnMailClient.DISK_MAIL_FOLDER, @"c:\mails\")
                    .Returns(@"c:\mails\");
            }

            return new RnMailClient(logger, webConfig, mailAccount, directory);
        }
    }
}
