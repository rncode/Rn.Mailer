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
        public RnEncryptionService EncryptionService { get; set; }
        public List<MailUserEntity> Users { get; set; }

        private readonly MailerDbContext _db;

        // Constructor
        public MailerDbInitializerHelper(MailerDbContext db)
        {
            _db = db;

            var webConfig = new RnWebConfig();
            EncryptionService = new RnEncryptionService(webConfig);
            DevelopmentMode = webConfig.GetBoolAppSetting("Rn.Mailer.DevMode", false);

            Users = new List<MailUserEntity>();
        }

        // Public methods
        public void AddUsers(List<MailUserEntity> users)
        {
            _db.Users.AddRange(users);
            _db.SaveChanges();

            Users.Clear();
            Users.AddRange(_db.Users.ToList());
        }

        public void Dispose()
        {
            Users.Clear();

            EncryptionService = null;
        }
    }
}