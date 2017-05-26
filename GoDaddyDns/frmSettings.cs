using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace GoDaddyDns
{
    public enum TimePeriod
    {
        Seconds = 0,
        Minutes = 1,
        Hours = 2,
        Days = 3
    }
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

            if ( Program.UpdateFrequency.TotalDays >= 1)
            {
                this.numTimeout.Value = (int)Program.UpdateFrequency.TotalDays;
                this.cmbPeriod.SelectedIndex = (int)TimePeriod.Days;
            }
            else if (Program.UpdateFrequency.TotalHours >= 1)
            {
                this.numTimeout.Value = (int)Program.UpdateFrequency.TotalHours;
                this.cmbPeriod.SelectedIndex = (int)TimePeriod.Hours;
            }
            else if (Program.UpdateFrequency.TotalMinutes >= 1)
            {
                this.numTimeout.Value = (int)Program.UpdateFrequency.TotalMinutes;
                this.cmbPeriod.SelectedIndex = (int)TimePeriod.Minutes;
            }
            else 
            {
                this.numTimeout.Value = (int)Program.UpdateFrequency.TotalSeconds;
                this.cmbPeriod.SelectedIndex = (int)TimePeriod.Seconds;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var apiKey = this.txtApiKey.Text;
            var apiSecret = this.txtApiSecret.Text;
            var defaultTtl = Convert.ToInt32(this.txtDefaultTtl.Text);
            var intervalValue = this.numTimeout.Value;
            var intervalPeriod = (TimePeriod)this.cmbPeriod.SelectedIndex;
            var interval = generateInterval(intervalValue, intervalPeriod);

            Program.ApiKey = apiKey;
            Program.ApiSecret = apiSecret;
            Program.DefaultTtl = defaultTtl;
            Program.UpdateFrequency = interval;

            this.Close();
        }

        private TimeSpan generateInterval(decimal intervalValue, TimePeriod intervalPeriod)
        {
            Func<double, TimeSpan> evaluator = null;

            switch ( intervalPeriod)
            {
                case TimePeriod.Seconds:
                    evaluator = TimeSpan.FromSeconds;
                    break;
                case TimePeriod.Hours:
                    evaluator = TimeSpan.FromHours;
                    break;
                case TimePeriod.Days:
                    evaluator = TimeSpan.FromDays;
                    break;
                case TimePeriod.Minutes:
                default:
                    evaluator = TimeSpan.FromMinutes;
                    break;
            }

            return evaluator(Convert.ToDouble(intervalValue));
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
            if (!int.TryParse(this.txtDefaultTtl.Text, out int validInteger))
            {
                e.Cancel = true;
                this.txtDefaultTtl.Select(0, this.txtDefaultTtl.Text.Length);
                this.errorProvider.SetError(this.txtDefaultTtl, Properties.Resources.frmSettings_InvalidTtl);
            }
        }
    }
}
