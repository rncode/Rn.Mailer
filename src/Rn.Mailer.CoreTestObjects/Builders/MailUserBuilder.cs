using System;
using Rn.Mailer.Core.Models;

namespace Rn.Mailer.CoreTestObjects.Builders
{
    public class MailUserBuilder
    {
        private readonly MailUser _user;

        public MailUserBuilder()
        {
            _user = new MailUser();
        }

        public MailUserBuilder AsValidUser()
        {
            _user.Id = 1;
            _user.Enabled = true;
            _user.CreationDateUtc = new DateTime(2016, 11, 1, 12, 0, 0);
            _user.LastLoginDateUtc = new DateTime(2016, 11, 1, 12, 0, 0);
            _user.Username = "RichardN";
            _user.DisplayName = "Richard Niemand";
            _user.Password = "test";

            return this;
        }
        
        public MailUser Build()
        {
            return _user;
        }
    }
}
