using EncryptStringSample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoDaddyDns
{
    public partial class frmSettings : frmBase
    {
        protected DnsManager _dnsManager;

        public frmSettings(DnsManager dnsManager)
        {
            this._dnsManager = dnsManager;

            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            var apiKey = this._dnsManager.ApiKey;
            var apiSecret = this._dnsManager.ApiSecret;

            if (!String.IsNullOrWhiteSpace(apiKey))
                this.txtApiKey.Text = apiKey;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var apiKey = this.txtApiKey.Text;
            var apiSecret = this.txtApiSecret.Text;

            this._dnsManager.ApiKey = apiKey;
            this._dnsManager.ApiSecret = apiSecret;

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
    }
}
