using System.Linq;
using System.Web.Http;
using Rn.Mailer.DAL;
using Rn.Mailer.Services;

namespace Rn.Mailer.Controllers.API
{
    [RoutePrefix("API/v1/Test")]
    public class TestController : ApiController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_testService.GetName());
        }

        [HttpGet, Route("MailAccounts")]
        public IHttpActionResult MailAccounts()
        {
            using (var db = new MailerDbContext())
            {
                var accounts = db.MailAccounts.ToList();
                return Ok(accounts);
            }
        }

        [HttpGet, Route("MailApiKeys")]
        public IHttpActionResult MailApiKeys()
        {
            using (var db = new MailerDbContext())
            {
                var apiKeys = db.ApiKeys.ToList();
                return Ok(apiKeys);
            }
        }
    }
}