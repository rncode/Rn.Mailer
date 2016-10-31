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
        public DateTime CreationDateUtc { get; set; }

        [Required]
        public int MailAccountId { get; set; }

        [Required]
        public long MailSendCount { get; set; }

        [Required]
        public string ApiKey { get; set; }

        // Navigation properties
        [ForeignKey("MailAccountId")]
        public MailAccountEntity MailAccount { get; set; }

        // Constructors
        public MailApiKeyEntity()
        { }

        public MailApiKeyEntity(int mailAccountId, string apiKey)
        {
            Enabled = true;
            CreationDateUtc = DateTime.UtcNow;
            MailAccountId = mailAccountId;
            ApiKey = apiKey;
            MailSendCount = 0;
        }
    }
}
