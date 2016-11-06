using System;
using System.Net;
using System.Net.Mail;
using Rn.Core.Config;
using Rn.Core.Extensions;
using Rn.Core.IO;
using Rn.Mailer.Castle;
using Rn.Mailer.Core.Interfaces;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer
{
    public class RnMailClient
    {
        public const string REDIRECT_TO_DISK = "Rn.Mailer.RedirectToDisk";
        public const string DISK_MAIL_FOLDER = "Rn.Mailer.DiskMailFolder";

        private readonly IRnLogger _logger;
        private readonly IDirectory _directory;
        private readonly IWebConfig _webConfig;
        private readonly MailAccount _account;
        private readonly SmtpClient _mailClient;

        // constructor
        public RnMailClient(IRnLogger logger, IWebConfig webConfig, MailAccount mailAccount, IDirectory directory = null)
        {
            _logger = logger;
            _webConfig = webConfig;
            _account = mailAccount;
            _directory = directory ?? new RnDirectory();

            _mailClient = CreateMailClient();
        }

        // public methods
        public string GetMailDiskFolderPath()
        {
            // todo: add tests
            var baseLocation = _webConfig
                .GetAppSetting(DISK_MAIL_FOLDER, @"c:\mails\")
                .AppendIfMissing("\\");

            var accountId = _account.Id.ToString("D").PadLeft(5, '0');

            return $"{baseLocation}{accountId}\\";
        }

        // helper methods
        private SmtpClient CreateMailClient()
        {
            var redirectToDisk = _webConfig.GetBoolAppSetting(REDIRECT_TO_DISK, false);

            var client = new SmtpClient
            {
                UseDefaultCredentials = _account.UseDefaultCredentials(),
                Host = _account.SmtpHost,
                Port = _account.SmtpPort
            };

            // Set the delivery location for the composed mails
            if (redirectToDisk)
            {
                // http://stackoverflow.com/questions/567765/how-can-i-save-an-email-instead-of-sending-when-using-smtpclient
                client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                client.PickupDirectoryLocation = GetMailDiskFolderPath();

                // todo: add tests
                // if we are working with a relative path we need to modify it
                if (client.PickupDirectoryLocation.StartsWith("~"))
                {
                    var root = AppDomain.CurrentDomain.BaseDirectory;
                    var pickupRoot = client.PickupDirectoryLocation.Replace("~/", root);
                    pickupRoot = pickupRoot.Replace("/", @"\");
                    client.PickupDirectoryLocation = pickupRoot;
                }

                // todo: add tests
                // ensure that the pickup location exists
                if (!_directory.Exists(client.PickupDirectoryLocation))
                {
                    _logger.Info($"RnMailClient - mail pickup directory not found ({client.PickupDirectoryLocation})," +
                                 " attempting to create it now");

                    _directory.CreateDirectory(client.PickupDirectoryLocation);

                    _logger.Debug("RnMailClient - successfully created mail pickup directory");
                }
            }
            else
            {
                client.EnableSsl = _account.EnableSsl;
            }

            // if we don't need credentials we can complete our configuration here
            if (_account.UseDefaultCredentials())
                return client;

            // set the credentials for the given mail account
            client.Credentials = new NetworkCredential(
                _account.SmtpUsername,
                _account.SmtpPassword);

            return client;
        }
    }
}