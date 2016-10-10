using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rn.Core.Config;

namespace Rn.Mailer.Castle.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IWebConfig>()
                .ImplementedBy<RnWebConfig>()
                .LifestyleSingleton());
        }
    }
}