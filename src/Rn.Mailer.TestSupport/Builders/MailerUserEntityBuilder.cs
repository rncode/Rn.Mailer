using System;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.TestCore.Builders
{
    public class MailerUserEntityBuilder
    {
        private readonly MailerUserEntity _entity;

        public MailerUserEntityBuilder()
        {
            _entity = new MailerUserEntity();
        }

        public MailerUserEntityBuilder WithValidData()
        {
            _entity.Id = 10;
            _entity.Enabled = true;
            _entity.DateAddedUtc = new DateTime(2016, 1, 1, 1, 1, 1);
            _entity.Username = "username";
            _entity.Password = "password";
            _entity.DisplayName = "displayname";

            return this;
        }

        public MailerUserEntity Build()
        {
            return _entity;
        }
    }
}
