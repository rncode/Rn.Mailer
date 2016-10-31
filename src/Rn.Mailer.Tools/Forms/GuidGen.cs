using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Rn.Mailer.Tools.Forms
{
    public partial class GuidGen : Form
    {
        public GuidGen()
        {
            InitializeComponent();
        }

        private void GuidGen_Load(object sender, EventArgs e)
        {
            SeedGuidList();
        }

        private void SeedGuidList()
        {
            var list = new List<ComboboxItem>();

            for (int i = 0; i < 50; i++)
            {
                var value = i + 1;

                list.Add(new ComboboxItem
                {
                    Text = value.ToString("D"),
                    Value = value
                });
            }

            cb_numGuids.DataSource = list;
        }

        private void btn_genGuids_Click(object sender, EventArgs e)
        {
            var numItems = ((ComboboxItem) cb_numGuids.SelectedItem).Value;
            var uppercase = cb_uppercase.Checked;
            var noDash = cb_noDashes.Checked;
            var singleLine = cb_singleLine.Checked;
            var sb = new StringBuilder();

            for (int i = 0; i < numItems; i++)
            {
                var guid = Guid.NewGuid().ToString();

                if (uppercase) guid = guid.ToUpper();
                if (noDash) guid = guid.Replace("-", "");

                sb.Append(guid);

                if (!singleLine) sb.Append(Environment.NewLine);
            }

            rtb_output.Text = sb.ToString();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
