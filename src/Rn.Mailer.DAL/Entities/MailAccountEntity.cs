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
        public int UserId { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }

        [Required]
        public string SmtpHost { get; set; }

        [Required]
        public int SmtpPort { get; set; }

        [Required]
        public bool EnableSsl { get; set; }

        [Required]
        public string FromAddress { get; set; }

        [Required]
        public string FromDisplayName { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public MailUserEntity User { get; set; }
    }
}
