using NSubstitute;
using Rn.Mailer.DAL.Repos;
using Rn.Mailer.Services;

namespace Rn.MailerTests.TestSupport
{
    public static class Builder
    {
        public static UserService BuildUserService(IUserRepo userRepo = null)
        {
            userRepo = userRepo ?? Substitute.For<IUserRepo>();

            return new UserService(userRepo);
        }
    }
}
