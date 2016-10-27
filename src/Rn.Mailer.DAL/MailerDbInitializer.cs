using System.Data.Entity;

namespace Rn.Mailer.DAL
{
    public class MailerDbInitializer : DropCreateDatabaseIfModelChanges<MailerDbContext>
    {
        protected override void Seed(MailerDbContext context)
        {
            using (var helper = new MailerDbInitializerHelper(context))
            {
                
            }

            base.Seed(context);
        }
    }
}