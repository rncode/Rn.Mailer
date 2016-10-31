using System;
using System.Collections.Generic;
using System.Linq;
using Rn.Core.Config;
using Rn.Core.Encryption;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public class MailerDbInitializerHelper : IDisposable
    {
        public bool DevelopmentMode { get; set; }
        public IWebConfig WebConfig { get; private set; }
        public IEncryptionService EncryptionService { get; private set; }

        public List<MailUserEntity> Users { get; set; }
        public List<MailAccountEntity> MailAccounts { get; set; }

        private readonly MailerDbContext _db;

        // Constructor
        public MailerDbInitializerHelper(MailerDbContext db)
        {
            _db = db;

            WebConfig = new RnWebConfig();
            EncryptionService = new RnEncryptionService(WebConfig);
            DevelopmentMode = WebConfig.GetBoolAppSetting("Rn.Mailer.DevMode", false);

            Users = new List<MailUserEntity>();
            MailAccounts = new List<MailAccountEntity>();
        }

        // Public methods
        public void AddUsers(List<MailUserEntity> users)
        {
            _db.Users.AddRange(users);
            _db.SaveChanges();

            Users.Clear();
            Users.AddRange(_db.Users.ToList());
        }

        public void AddMailAccounts(List<MailAccountEntity> accounts)
        {
            _db.MailAccounts.AddRange(accounts);
            _db.SaveChanges();

            MailAccounts.Clear();
            MailAccounts.AddRange(_db.MailAccounts.ToList());
        }

        // IDisposable
        public void Dispose()
        {
            Users.Clear();
            MailAccounts.Clear();

            WebConfig = null;
            EncryptionService = null;
        }
    }
}