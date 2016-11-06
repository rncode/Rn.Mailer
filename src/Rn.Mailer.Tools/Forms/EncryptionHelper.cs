using System;
using System.Windows.Forms;
using Rn.Core.Config;
using Rn.Core.Encryption;

namespace Rn.Mailer.Tools.Forms
{
    public partial class EncryptionHelper : Form
    {
        public EncryptionHelper()
        {
            InitializeComponent();

            var webConfig = new RnWebConfig();
            rtb_salt.Text = webConfig.GetAppSetting("Rn.EncryptionService.Salt");
            rtb_pass.Text = webConfig.GetAppSetting("Rn.EncryptionService.ServerPass");
        }

        private void btn_encode_Click(object sender, EventArgs e)
        {
            var encrypter = new RnEncryptionService(rtb_salt.Text, rtb_pass.Text);
            rtb_encoded.Text = encrypter.EncryptText(rtb_input.Text);
        }

        private void btn_decode_Click(object sender, EventArgs e)
        {
            var encrypter = new RnEncryptionService(rtb_salt.Text, rtb_pass.Text);
            rtb_input.Text = encrypter.DecryptText(rtb_encoded.Text);
        }
    }
}
