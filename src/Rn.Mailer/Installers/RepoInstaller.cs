using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rn.Mailer.DAL.Repos;

namespace Rn.Mailer.Installers
{
    public class RepoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IUserRepo>()
                .ImplementedBy<UserRepo>()
                .LifestyleSingleton());

            container.Register(Component
                .For<IMailAccountsRepo>()
                .ImplementedBy<MailAccountsRepo>()
                .LifestyleSingleton());
        }
    }
}