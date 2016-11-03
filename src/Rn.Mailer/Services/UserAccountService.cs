using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Interfaces.Services;

namespace Rn.Mailer.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepo _repo;

        public UserAccountService(IUserAccountRepo repo)
        {
            _repo = repo;
        }
    }
}