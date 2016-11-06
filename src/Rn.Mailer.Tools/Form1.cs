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

        private void btnGuidGen_Click(object sender, EventArgs e)
        {
            var ggen = new GuidGen();
            ggen.Show();
            ggen.Focus();
        }
    }
}
