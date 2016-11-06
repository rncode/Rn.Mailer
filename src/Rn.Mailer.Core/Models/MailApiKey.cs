using System;

namespace Rn.Mailer.Core.Models
{
   public class MailApiKey
    {
        /// <summary>
        /// The unique identifier for this API keyThe unique identifier for this API key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indicates the enabled state for this API key
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The date (in UTC) that this API key was created
        /// </summary>
        public DateTime CreationDateUtc { get; set; }

        /// <summary>
        /// The associated MailAccount’s identifier
        /// </summary>
        public int MailAccountId { get; set; }

        /// <summary>
        /// Total count of mails sent via this API key
        /// </summary>
        public long MailSendCount { get; set; }

        /// <summary>
        /// The actual API key (this is a GUID)
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The associated MailAccount for this API key
        /// </summary>
        public MailAccount MailAccount { get; set; }
    }
}
