using System;
using System.Windows.Forms;
using Rn.Mailer.Tools.Forms;

namespace Rn.Mailer.Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncryptionHelper_Click(object sender, EventArgs e)
        {
            var encryptionHelper = new EncryptionHelper();
            encryptionHelper.Show();
            encryptionHelper.Focus();
        }
    }
}
