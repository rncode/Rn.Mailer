using System.Data.Entity;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public class RnMailerDbContext : DbContext
    {
        public virtual DbSet<MailerUserEntity> Users { get; set; }

        public RnMailerDbContext()
            : base("RnMailer")
        {
            Database.SetInitializer(new RnMailerDbInitializer());
        }
    }
}
