using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace GoDaddyDns
{
    public partial class frmSettings : frmBase
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            var apiKey = Program.ApiKey;

            if (!String.IsNullOrWhiteSpace(apiKey))
                this.txtApiKey.Text = apiKey;

            this.txtDefaultTtl.Text = Program.DefaultTtl.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var apiKey = this.txtApiKey.Text;
            var apiSecret = this.txtApiSecret.Text;
            var defaultTtl = Convert.ToInt32(this.txtDefaultTtl.Text);

            Program.ApiKey = apiKey;
            Program.ApiSecret = apiSecret;
            Program.DefaultTtl = defaultTtl;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRemarks_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void txtDefaultTtl_Validating(object sender, CancelEventArgs e)
        {
            int validInteger = 0;
            if (!int.TryParse(this.txtDefaultTtl.Text, out validInteger))
            {
                e.Cancel = true;
                this.txtDefaultTtl.Select(0, this.txtDefaultTtl.Text.Length);
                this.errorProvider.SetError(this.txtDefaultTtl, Properties.Resources.frmSettings_InvalidTtl);
            }
        }
    }
}
