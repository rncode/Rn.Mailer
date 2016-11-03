using System;
using System.Threading.Tasks;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Interfaces.Services;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Services
{
    public class MailAccountService : IMailAccountService
    {
        private readonly IRnLogger _logger;
        private readonly IMailAccountRepo _repo;

        public MailAccountService(IRnLogger logger, IMailAccountRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<MailAccount> GetMailAccount(int accountId, bool includeUser = false)
        {
            if (accountId <= 0)
            {
                _logger.Warn($"MailAccountService.GetMailAccount() no mail account found with id:{accountId}");
                throw new ArgumentException($"MailAccountService.GetMailAccount() no mail account found with id:{accountId}");
            }

            // get the mail account
            var mailAccount = await _repo.GetMailAccount(accountId, includeUser);

            // log if we don't have the requested mail account
            if (mailAccount == null)
            {
                _logger.Debug($"MailAccountService.GetMailAccount() no mail account found with id:{accountId}");
            }

            return mailAccount;
        }
    }
}