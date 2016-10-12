using System.Configuration;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rn.Core.Config;
using Rn.Core.Encryption;
using Rn.Mailer.Services;

namespace Rn.Mailer.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IWebConfig>()
                .Instance(GetWebConfig()));

            container.Register(Component
                .For<IEncryptionService>()
                .ImplementedBy<RnEncryptionService>()
                .LifestyleSingleton());

            container.Register(Component
                .For<IUserService>()
                .ImplementedBy<UserService>()
                .LifestyleSingleton());

            container.Register(Component
                .For<IEncryptionHelper>()
                .Instance(GetEncryptionHelper()));

            container.Register(Component
                .For<IMailAccountService>()
                .ImplementedBy<MailAccountService>()
                .LifestyleSingleton());
        }

        private static IEncryptionHelper GetEncryptionHelper()
        {
            var saltString = ConfigurationManager.AppSettings["Rn.Mailer.Encryption.Salt"];

            // Check to see if this is a file path
            if (File.Exists(saltString))
            {
                saltString = File.ReadAllText(saltString);
            }

            var encryptionHelper = new EncryptionHelper(saltString);
            return encryptionHelper;
        }

        private static IWebConfig GetWebConfig()
        {
            var webConfig = new RnWebConfig();
            var serverKey = ConfigurationManager.AppSettings["Rn.Mailer.Encryption.ServerPass"];

            // Check to see if we need to overwrite "Rn.EncryptionService.ServerPass"
            if (string.IsNullOrWhiteSpace(serverKey))
                return webConfig;

            var newServerKey = File.Exists(serverKey)
                ? File.ReadAllText(serverKey)
                : serverKey;

            webConfig.SetAppSetting("Rn.EncryptionService.ServerPass", newServerKey);

            return webConfig;
        }
    }
}