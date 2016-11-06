using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.DAL.Repos
{
    public class MailAccountRepo : IMailAccountRepo
    {
        public async Task<MailAccount> GetMailAccount(int accountId, bool includeUser = false)
        {
            using (var db = new MailerDbContext())
            {
                var query =  db.MailAccounts
                    .Where(x => x.Id == accountId);

                if (includeUser)
                    query = query.Include(x => x.User);

                var account = await query.FirstOrDefaultAsync();

                return account.AsMailAccount();
            }
        }
    }
}
