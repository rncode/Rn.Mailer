using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Rn.Mailer.Services;

namespace Rn.Mailer.Controllers.API
{
    [RoutePrefix("API/v1/Test")]
    public class TestController : ApiController
    {
        private readonly IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var user = await _userService.GetUserById(1);
            return Ok(user);
        }
    }
}