﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rn.Core.Config;
using Rn.Core.Encryption;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Interfaces.Services;
using Rn.Mailer.Services;

namespace Rn.Mailer.Castle.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<ITestService>()
                .ImplementedBy<TestService>()
                .LifestylePerWebRequest());

            container.Register(Component
                .For<IWebConfig>()
                .ImplementedBy<RnWebConfig>()
                .LifestyleSingleton());

            container.Register(Component
                .For<IEncryptionService>()
                .ImplementedBy<RnEncryptionService>()
                .LifestyleSingleton());

            container.Register(Component
                .For<IMailAccountService>()
                .ImplementedBy<MailAccountService>()
                .LifestyleSingleton());

            container.Register(Component
                .For<IUserAccountService>()
                .ImplementedBy<UserAccountService>()
                .LifestyleSingleton());

            // todo: swap out with Rn.Logging in the not so far future
            container.Register(Component
                .For<IRnLogger>()
                .ImplementedBy<RnLogger>()
                .LifestyleSingleton());
        }
    }
}