using System;

namespace Rn.Mailer.Core.Models
{
    public class MailAccount
    {
        /// <summary>
        /// Unique id for the current MailAccount
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indicates the enabled state for this MailAccount
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates that all mails sent from this account should be redirected to a local 
        /// folder rather than routing through the mail server
        /// </summary>
        public bool RedirectToDisk { get; set; }

        /// <summary>
        /// The date (in UTC) that this MailAccount was created
        /// </summary>
        public DateTime CreationDateUtc { get; set; }

        /// <summary>
        /// The owning userId for this MailAccount
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The username for account authentication (if required)
        /// </summary>
        public string SmtpUsername { get; set; }

        /// <summary>
        /// The password for account authentication (if required)
        /// </summary>
        public string SmtpPassword { get; set; }

        /// <summary>
        /// The SMTP server's host address
        /// </summary>
        public string SmtpHost { get; set; }

        /// <summary>
        /// The SMTP server’s port
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// Indicates if SSL should be used when connecting to the SMTP server
        /// </summary>
        public bool EnableSsl { get; set; }

        /// <summary>
        /// The from address to use when sending mails from this account
        /// </summary>
        public string FromAddress { get; set; }

        /// <summary>
        /// The from display name to use when sending mails from this account
        /// </summary>
        public string FromDisplayName { get; set; }

        /// <summary>
        /// The owning MailUser for this account
        /// </summary>
        public MailUser User { get; set; }

        /// <summary>
        /// Returns FALSE if the account has a "SmtpUsername" or "SmtpPassword" value set, otherwise TRUE is returned.
        /// </summary>
        /// <returns>boolean</returns>
        public bool UseDefaultCredentials()
        {
            return string.IsNullOrWhiteSpace(SmtpUsername) && string.IsNullOrWhiteSpace(SmtpPassword);
        }
    }
}
