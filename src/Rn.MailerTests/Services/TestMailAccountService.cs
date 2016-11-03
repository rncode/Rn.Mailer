using NUnit.Framework;
using Rn.MailerTests.TestSupport;

namespace Rn.MailerTests.Services
{
    [TestFixture]
    public class TestMailAccountService
    {
        [Test]
        public void MailAccountService_ShouldConstruct()
        {
            Assert.IsNotNull(Builder.BuildMailAccountService());
        }
    }
}
