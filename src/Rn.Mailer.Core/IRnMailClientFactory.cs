using Rn.Mailer.Core.Models;

namespace Rn.Mailer.Core
{
    public interface IRnMailClientFactory
    {
        IRnMailClient GetMailClient(MailAccount mailAccount);
    }
}