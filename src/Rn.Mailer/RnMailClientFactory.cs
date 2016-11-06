using Rn.Core.Config;
using Rn.Core.IO;
using Rn.Mailer.Core;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer
{
    public class RnMailClientFactory : IRnMailClientFactory
    {
        private readonly IRnLogger _logger;
        private readonly IWebConfig _webConfig;
        private readonly IDirectory _directory;

        public RnMailClientFactory(IRnLogger logger, IWebConfig webConfig, IDirectory directory)
        {
            _logger = logger;
            _webConfig = webConfig;
            _directory = directory;
        }

        public IRnMailClient GetMailClient(MailAccount mailAccount)
        {
            return new RnMailClient(_logger, _webConfig, mailAccount, _directory);
        }
    }
}