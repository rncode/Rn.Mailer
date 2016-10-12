using System.Data.Entity;
using System.Threading.Tasks;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Helpers;

namespace Rn.Mailer.DAL.Repos
{
    public interface IUserRepo
    {
        Task<MailerUser> GetUserById(int id);
    }

    public class UserRepo : IUserRepo
    {
        public async Task<MailerUser> GetUserById(int id)
        {
            using (var db = new RnMailerDbContext())
            {
                var user = await db.Users
                    .FirstOrDefaultAsync(x => x.Id == id);

                return user?.AsMailerUser();
            }
        }
    }
}
