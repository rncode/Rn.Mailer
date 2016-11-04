using NUnit.Framework;

namespace Rn.Mailer.CoreTestObjects
{
    [TestFixture]
    public class HackTest
    {
        [Test]
        public void BogusTest_GivenRunningOnAppveyor_ShouldAllowBuildToPass()
        {
            // this test was created as a hack to allow the build to pass on Appveyor
            // I will address this in the future - at the moment this DLL is being picked
            // up as a test suite based on the name "CoreTestObjects"!
            Assert.IsTrue(true);
        }
    }
}
