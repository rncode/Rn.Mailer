using System.Data.Entity;
using System.Threading.Tasks;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Helpers;

namespace Rn.Mailer.DAL.Repos
{
    public interface IMailAccountsRepo
    {
        Task<MailAccount> GetAccount(int accountId);
    }

    public class MailAccountsRepo : IMailAccountsRepo
    {
        public async Task<MailAccount> GetAccount(int accountId)
        {
            using (var db = new RnMailerDbContext())
            {
                var account = await db.MailAccounts.FirstOrDefaultAsync(x => x.Id == accountId);

                return account.AsMailAccount();
            }
        }
    }
}
