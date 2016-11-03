using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.DAL.Repos;

namespace Rn.Mailer.Castle.Installers
{
    public class RepoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IMailAccountRepo>()
                .ImplementedBy<MailAccountRepo>()
                .LifestyleSingleton());
        }
    }
}