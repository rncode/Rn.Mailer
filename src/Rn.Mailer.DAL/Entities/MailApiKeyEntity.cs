using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rn.Mailer.DAL.Entities
{
    [Table("ApiKeys")]
    public class MailApiKeyEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Index]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public DateTime DateAddedUtc { get; set; }

        [Required]
        public int MailAccountId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ApiKey { get; set; }

        // Navigation properties
        [ForeignKey("MailAccountId")]
        public MailAccountEntity MailAccount { get; set; }

        [ForeignKey("UserId")]
        public MailUserEntity User { get; set; }
    }
}
