using System.Threading.Tasks;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Core.Interfaces.Services
{
    public interface IMailAccountService
    {
        Task<MailAccount> GetMailAccount(int accountId, bool includeUser = false);
    }
}