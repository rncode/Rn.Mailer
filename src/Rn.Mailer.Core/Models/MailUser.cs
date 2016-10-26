using System;

namespace Rn.Mailer.Core.Models
{
    public class MailUser
    {
        /// <summary>
        /// Unique identifier for this user, often referred to as the userId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indicates the enabled state for this user.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The date (in UTC) that this user account was created
        /// </summary>
        public DateTime DateAddedUtc { get; set; }

        /// <summary>
        /// The last time (in UTC) the user logged in - initially this is set to the DateAddedUtc value
        /// </summary>
        public DateTime LastLoginDateUtc { get; set; }

        /// <summary>
        /// The login name for this user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password for this user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The display name for this user
        /// </summary>
        public string DisplayName { get; set; }
    }
}
