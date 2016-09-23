using System.Data.Entity;

namespace Rn.Mailer.DAL
{
    public class RnMailerDbInitializer : DropCreateDatabaseIfModelChanges<RnMailerDbContext>
    {
        protected override void Seed(RnMailerDbContext context)
        {
            base.Seed(context);
        }
    }
}