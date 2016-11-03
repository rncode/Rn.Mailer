using System.Threading.Tasks;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Core.Interfaces.Services
{
    public interface IUserAccountService
    {
        Task<MailUser> GetUserAccount(int userId);
    }
}
