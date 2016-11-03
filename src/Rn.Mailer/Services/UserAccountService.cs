using System;
using System.Threading.Tasks;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Interfaces.Services;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IRnLogger _logger;
        private readonly IUserAccountRepo _repo;

        public UserAccountService(IRnLogger logger, IUserAccountRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<MailUser> GetUserAccount(int userId)
        {
            if (userId <= 0)
            {
                _logger.Warn($"UserAccountService.GetUserAccount() invalid userId provided ({userId})");
                throw new ArgumentException($"Invalid userId provided: {userId}");
            }

            // fetch the user from the repository
            var userAccount = await _repo.GetUserAccount(userId);

            // ensure that we have a user to work with
            if (userAccount == null)
                _logger.Debug($"UserAccountService.GetUserAccount() no user account found for userId ({userId})");

            return userAccount;
        }
    }
}