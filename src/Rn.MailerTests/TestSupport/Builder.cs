using NSubstitute;
using Rn.Core.Encryption;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Services;

namespace Rn.MailerTests.TestSupport
{
    public static class Builder
    {
        public static MailAccountService BuildMailAccountService(
            IRnLogger logger = null,
            IMailAccountRepo mailAccountRepo = null)
        {
            logger = logger ?? Substitute.For<IRnLogger>();
            mailAccountRepo = mailAccountRepo ?? Substitute.For<IMailAccountRepo>();

            return new MailAccountService(logger, mailAccountRepo);
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
    }
}
