using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoDaddyDns
{
    public partial class DataRow : UserControl
    {
        public DataRow(string domain, DateTime lastUpdate, UpdateStatus status)
        {
            InitializeComponent();

            this.chkDomain.Text = domain;
            this.lblLastUpdated.Text = $"{lastUpdate.ToShortDateString()} {lastUpdate.ToShortTimeString()}";
            this.lblDomainHealth.Text = status.ToString();
            if (status == UpdateStatus.OK)
            {
                this.lblDomainHealth.BackColor = Color.Green;
                this.lblDomainHealth.ForeColor = Color.White;
            }
            else if ( status == UpdateStatus.NA)
            {
                this.lblDomainHealth.BackColor = Color.Yellow;
                this.lblDomainHealth.ForeColor = Color.Black;
            }
            else
            {
                this.lblDomainHealth.BackColor = Color.Red;
                this.lblDomainHealth.ForeColor = Color.Black;
            }
        }

        private void flowLayoutPanel_Click(object sender, EventArgs e)
        {
            toggleChecked();
        }

        private void lblLastUpdated_Click(object sender, EventArgs e)
        {
            toggleChecked();
        }

        private void lblDomainHealth_Click(object sender, EventArgs e)
        {
            toggleChecked();
        }

        private void toggleChecked()
        {
            this.chkDomain.Checked = !this.chkDomain.Checked;
        }
    }
}
