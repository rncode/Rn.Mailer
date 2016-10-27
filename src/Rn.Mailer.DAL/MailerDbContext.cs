using System.Data.Entity;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public class MailerDbContext : DbContext
    {
        public virtual DbSet<MailUserEntity> Users { get; set; }
        public virtual DbSet<MailAccountEntity> MailAccounts { get; set; }
        public virtual DbSet<MailApiKeyEntity> ApiKeys { get; set; }

        public MailerDbContext()
            : base("RnMailer")
        {
            Database.SetInitializer(new MailerDbInitializer());
        }
    }
}
