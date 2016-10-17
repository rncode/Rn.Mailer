using System;

namespace Rn.Mailer.Core.Models
{
    public class MailAccount
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public DateTime DateAddedUtc { get; set; }
        public long MailsSent { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
