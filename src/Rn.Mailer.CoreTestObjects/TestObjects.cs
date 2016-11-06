using NSubstitute;
using Rn.Core.Config;
using Rn.Core.Encryption;

namespace Rn.Mailer.CoreTestObjects
{
    public static class TestObjects
    {
        public static IEncryptionService GetEncryptionService(
            string encryptionSalt = null,
            string serverPass = null)
        {
            var webConfig = Substitute.For<IWebConfig>();

            encryptionSalt = encryptionSalt ?? "1,2,3,4,5,6,7,8";
            serverPass = serverPass ?? "D1654BBFF67A47BBBA58B40E7ACA8019";

            webConfig.HasAppSetting("Rn.EncryptionService.Salt").Returns(true);
            webConfig.GetAppSetting("Rn.EncryptionService.Salt").Returns(encryptionSalt);

            webConfig.HasAppSetting("Rn.EncryptionService.ServerPass").Returns(true);
            webConfig.GetAppSetting("Rn.EncryptionService.ServerPass").Returns(serverPass);

            return new RnEncryptionService(webConfig);
        }
    }
}
