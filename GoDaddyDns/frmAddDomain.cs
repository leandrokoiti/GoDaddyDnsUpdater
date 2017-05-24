using GoDaddyDns.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoDaddyDns
{
    public partial class frmAddDomain : frmBase
    {
        public GoDaddyDomainDto Domain { get; private set; }

        protected DnsManager _dnsManager;

        public frmAddDomain(DnsManager dnsManager)
        {
            this._dnsManager = dnsManager;

            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var domainName = this.txtDomainName.Text;
            var aName = this.txtRecordName.Text;

            var domain = this._dnsManager.AddDomain(domainName, aName);

            this.Domain = domain;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
