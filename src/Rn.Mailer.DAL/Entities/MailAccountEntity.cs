using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rn.Mailer.DAL.Entities
{
    [Table("MailAccounts")]
    public class MailAccountEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Index]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public DateTime DateAddedUtc { get; set; }

        [Required]
        public long MailsSent { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
