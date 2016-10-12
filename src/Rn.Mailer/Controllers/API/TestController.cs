using System.Threading.Tasks;
using System.Web.Http;
using Rn.Mailer.Core.Models;
using Rn.Mailer.Services;

namespace Rn.Mailer.Controllers.API
{
    [RoutePrefix("API/v1/Test")]
    public class TestController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMailAccountService _accountService;

        public TestController(IUserService userService, IMailAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var user = await _userService.GetUserById(1);
            var account = await _accountService.GetMailAcount(1);

            return Ok(new CustomReturn
            {
                User = user,
                Account = account
            });
        }

        internal class CustomReturn
        {
            public MailerUser User { get; set; }
            public MailAccount Account { get; set; }
        }
    }
}