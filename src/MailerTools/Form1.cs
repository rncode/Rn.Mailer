using System;
using System.Windows.Forms;
using MailerTools.Tools;

namespace MailerTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pe = new PasswordEncrypter();
            pe.Show();
            pe.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
