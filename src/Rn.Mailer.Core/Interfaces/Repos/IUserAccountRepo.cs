using System.Threading.Tasks;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Core.Interfaces.Repos
{
    public interface IUserAccountRepo
    {
        Task<MailUser> GetUserAccount(int userId);
    }
}
