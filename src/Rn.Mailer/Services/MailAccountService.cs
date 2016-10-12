using System.Threading.Tasks;
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

        public MailAccountService(IMailAccountsRepo accountsRepo)
        {
            _accountsRepo = accountsRepo;
        }

        public async Task<MailAccount> GetMailAcount(int accountId)
        {
            return await _accountsRepo.GetAccount(accountId);
        }
    }
}