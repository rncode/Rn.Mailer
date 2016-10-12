using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Rn.Core.Config;
using Rn.Core.Encryption;

namespace MailerTools.Tools
{
    public partial class PasswordEncrypter : Form
    {
        private readonly IEncryptionService _encryptionService;

        public PasswordEncrypter()
        {
            InitializeComponent();

            var encSalt = ConfigurationManager.AppSettings["Rn.Mailer.Encryption.Salt"];
            var encKey = ConfigurationManager.AppSettings["Rn.EncryptionService.ServerPass"];

            if (File.Exists(encSalt))
            {
                encSalt = File.ReadAllText(encSalt);
            }

            var encryptionHelper = new EncryptionHelper(encSalt);
            var webConfig = new RnWebConfig();

            _encryptionService = new RnEncryptionService(webConfig, encryptionHelper);
            rtbEncKey.Text = encKey;
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            var encrypted = _encryptionService.EncryptText(passIn.Text, rtbEncKey.Text);
            passOut.Text = encrypted;
        }
    }
}
