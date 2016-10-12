using System;

namespace Rn.Mailer.Core.Models
{
    public class MailerUser
    {
        public int Id { get; set; }

        public bool Enabled { get; set; }

        public DateTime DateAddedUtc { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }
    }
}
