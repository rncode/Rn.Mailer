using System;

namespace Rn.Mailer.DAL
{
    public class MailerDbInitializerHelper : IDisposable
    {
        private readonly MailerDbContext _db;

        public MailerDbInitializerHelper(MailerDbContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            
        }
    }
}