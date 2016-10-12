using System;
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
                .ImplementedBy<RnWebConfig>()
                .LifestyleSingleton());

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
        }

        private static EncryptionHelper GetEncryptionHelper()
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
    }
}