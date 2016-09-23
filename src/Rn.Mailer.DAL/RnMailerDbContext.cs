using System.Data.Entity;

namespace Rn.Mailer.DAL
{
    public class RnMailerDbContext : DbContext
    {
        public RnMailerDbContext()
            : base("RnMailer")
        {
            Database.SetInitializer(new RnMailerDbInitializer());
        }
    }
}
