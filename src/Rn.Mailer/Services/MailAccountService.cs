using System.Threading.Tasks;
using Rn.Core.Encryption;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Repos;

namespace Rn.Mailer.Services
{
    public interface IMailAccountService
    {
        Task<MailAccount> GetMailAcount(int accountId);
    }

    public class MailAccountService : IMailAccountService
    {
        private readonly IMailAccountsRepo _accountsRepo;
        private readonly IEncryptionService _encryptionService;

        public MailAccountService(IMailAccountsRepo accountsRepo, IEncryptionService encryptionService)
        {
            _accountsRepo = accountsRepo;
            _encryptionService = encryptionService;
        }

        public async Task<MailAccount> GetMailAcount(int accountId)
        {
            var account = await _accountsRepo.GetAccount(accountId);

            // Decrypt the accounts password
            account.Password = _encryptionService.DecryptText(account.Password);

            return account;
        }
    }
}