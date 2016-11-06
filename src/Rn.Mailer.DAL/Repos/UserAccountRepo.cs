using System.Data.Entity;
using System.Threading.Tasks;
using Rn.Mailer.Core.Interfaces.Repos;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.DAL.Repos
{
    public class UserAccountRepo : IUserAccountRepo
    {
        public async Task<MailUser> GetUserAccount(int userId)
        {
            using (var db = new MailerDbContext())
            {
                var account = await db.Users
                    .FirstOrDefaultAsync(x => x.Id == userId);

                return account.AsMailUser();
            }
        }
    }
}
