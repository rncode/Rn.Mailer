namespace Rn.Mailer.Services
{
    public interface ITestService
    {
        string GetName();
    }

    public class TestService : ITestService
    {
        public string GetName()
        {
            return "Test Service";
        }
    }
}