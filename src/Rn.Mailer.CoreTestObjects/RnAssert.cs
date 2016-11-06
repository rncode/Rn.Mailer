using System;
using NUnit.Framework;
using Rn.Mailer.Core.Models;
using Rn.Mailer.DAL.Entities;

namespace Rn.Mailer.CoreTestObjects
{
    public static class RnAssert
    {
        public static void AreEqual(MailUser source, MailUserEntity target)
        {
            if(source == null)
                throw new ArgumentException("source object cannot be null");

            if(target == null)
                throw new ArgumentException("target object cannot be null");

            Assert.AreEqual(source.Enabled, target.Enabled);
            Assert.AreEqual(source.CreationDateUtc, target.CreationDateUtc);
            Assert.AreEqual(source.DisplayName, target.DisplayName);
            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.LastLoginDateUtc, target.LastLoginDateUtc);
            Assert.AreEqual(source.Password, target.Password);
            Assert.AreEqual(source.Username, target.Username);
        }
    }
}
