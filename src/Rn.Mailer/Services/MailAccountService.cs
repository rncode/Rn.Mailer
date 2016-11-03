using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Interfaces.Services;
using Rn.Mailer.DAL.Repos;

namespace Rn.Mailer.Services
{
    public class MailAccountService : IMailAccountService
    {
        private readonly IMailAccountRepo _repo;

        public MailAccountService(IMailAccountRepo repo)
        {
            _repo = repo;
        }
    }
}