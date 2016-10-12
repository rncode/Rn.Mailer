using System;
using System.Collections.Generic;
using System.Linq;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public class InitializerHelper : IDisposable
    {
        public List<MailerUserEntity> Users { get; set; }
        public List<MailAccountEntity> MailAccounts { get; set; }

        private readonly RnMailerDbContext _dbContext;

        // Constructor
        public InitializerHelper(RnMailerDbContext dbContext)
        {
            _dbContext = dbContext;

            Users = new List<MailerUserEntity>();
            MailAccounts = new List<MailAccountEntity>();
        }

        // Public methods
        public void AddUsers(List<MailerUserEntity> users)
        {
            Users.Clear();

            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();

            Users.AddRange(_dbContext.Users.ToList());
        }

        public void AddMailAccounts(List<MailAccountEntity> accounts)
        {
            MailAccounts.Clear();

            _dbContext.MailAccounts.AddRange(accounts);
            _dbContext.SaveChanges();

            MailAccounts.AddRange(_dbContext.MailAccounts.ToList());
        }

        // Dispose
        public void Dispose()
        {
            Users.Clear();
            MailAccounts.Clear();
        }
    }
}