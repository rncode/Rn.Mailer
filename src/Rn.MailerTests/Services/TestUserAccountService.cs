using NUnit.Framework;
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
    }
}
