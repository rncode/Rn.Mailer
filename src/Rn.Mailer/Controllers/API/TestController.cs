using System.Web.Http;
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
    }
}