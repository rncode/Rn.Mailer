using NSubstitute;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Services;

namespace Rn.MailerTests.TestSupport
{
    public static class Builder
    {
        public static MailAccountService BuildMailAccountService(
            IMailAccountRepo mailAccountRepo = null)
        {
            mailAccountRepo = mailAccountRepo ?? Substitute.For<IMailAccountRepo>();

            return new MailAccountService(mailAccountRepo);
        }
    }
}
