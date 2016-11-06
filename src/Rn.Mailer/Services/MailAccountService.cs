using System;
using System.Threading.Tasks;
using Rn.Core.Encryption;
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
        private readonly IEncryptionService _encryptionService;

        public MailAccountService(IRnLogger logger, IMailAccountRepo repo, IEncryptionService encryptionService)
        {
            _logger = logger;
            _repo = repo;
            _encryptionService = encryptionService;
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
                return null;
            }

            // decrypt the mail accounts password
            mailAccount.SmtpPassword = _encryptionService.DecryptText(mailAccount.SmtpPassword);

            // if we have an user account, we need to decrypt its password too
            if (mailAccount.User != null)
                mailAccount.User.Password = _encryptionService.DecryptText(mailAccount.User.Password);

            return mailAccount;
        }
    }
}