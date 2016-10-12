using System.Threading.Tasks;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Repos;

namespace Rn.Mailer.Services
{
    public interface IUserService
    {
        Task<MailerUser> GetUserById(int userId);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<MailerUser> GetUserById(int userId)
        {
            return await _userRepo.GetUserById(userId);
        }
    }
}