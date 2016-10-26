using Rn.Mailer.Client.Enums;

namespace Rn.Mailer.Client.Models
{
    public class RnMailAddress
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public MailPartEncoding Encoding { get; set; }

        // Constructors
        public RnMailAddress()
        {
            Email = string.Empty;
            Name = string.Empty;
            Encoding = MailPartEncoding.UTF8;
        }

        public RnMailAddress(string email)
        {
            Email = email;
            Name = email;
            Encoding = MailPartEncoding.UTF8;
        }

        public RnMailAddress(string email, string name)
        {
            Email = email;
            Name = name;
            Encoding = MailPartEncoding.UTF8;
        }

        public RnMailAddress(string email, string name, MailPartEncoding encoding)
        {
            Email = email;
            Name = name;
            Encoding = encoding;
        }

        // Public methods
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            // Simplest form of validation we need - emails are complex to validate
            // http://stackoverflow.com/questions/201323/using-a-regular-expression-to-validate-an-email-address
            if (!Email.Contains("@") || !Email.Contains("."))
                return false;

            // To pass name validation all we require is any non-empty value
            if (string.IsNullOrWhiteSpace(Name))
                return false;

            return true;
        }
    }
}
