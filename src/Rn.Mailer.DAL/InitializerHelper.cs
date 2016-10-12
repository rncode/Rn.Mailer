using System;
using System.Collections.Generic;
using System.Linq;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DAL
{
    public class InitializerHelper : IDisposable
    {
        public List<MailerUserEntity> Users { get; set; }
        private readonly RnMailerDbContext _dbContext;

        public InitializerHelper(RnMailerDbContext dbContext)
        {
            _dbContext = dbContext;

            Users = new List<MailerUserEntity>();
        }

        public void AddUsers(List<MailerUserEntity> users)
        {
            Users.Clear();

            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();

            Users.AddRange(_dbContext.Users.ToList());
        }

        public void Dispose()
        {
            Users.Clear();
        }
    }
}