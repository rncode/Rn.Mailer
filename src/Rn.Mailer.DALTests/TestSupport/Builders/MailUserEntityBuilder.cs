using System;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.DALTests.TestSupport.Builders
{
    public class MailUserEntityBuilder
    {
        private readonly MailUserEntity _user;

        public MailUserEntityBuilder()
        {
            _user = new MailUserEntity();
        }

        public MailUserEntityBuilder AsValidObject()
        {
            _user.Id = 1;
            _user.Enabled = true;
            _user.LastLoginDateUtc = DateTime.UtcNow;
            _user.CreationDateUtc = DateTime.UtcNow;
            _user.Username = "RichardN";
            _user.Password = "password";
            _user.DisplayName = "Richard Niemand";

            return this;
        }

        public MailUserEntity Build()
        {
            return _user;
        }
    }
}
