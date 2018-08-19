﻿using System;
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
            var apiSecret = Program.ApiSecret;

            if (!String.IsNullOrWhiteSpace(apiKey))
                this.txtApiKey.Text = apiKey;

            if (!String.IsNullOrWhiteSpace(apiSecret))
                this.txtApiSecret.Text = "".PadLeft(apiSecret.Length, '*');

            this.numTtl.Value = Program.DefaultTtl;
            this.chkTray.Checked = Program.MinimizeToTray;

            if (Program.UpdateFrequency.TotalDays >= 1)
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
            var defaultTtl = (int)this.numTtl.Value;
            var intervalValue = this.numTimeout.Value;
            var intervalPeriod = (TimePeriod)this.cmbPeriod.SelectedIndex;
            var interval = generateInterval(intervalValue, intervalPeriod);
            var minimizeToTray = this.chkTray.Checked;

            Program.ApiKey = apiKey;
            if (apiSecret.Trim('*').Length > 0)
            {
                Program.ApiSecret = apiSecret;
            }
            Program.DefaultTtl = defaultTtl;
            Program.UpdateFrequency = interval;
            Program.MinimizeToTray = minimizeToTray;

            this.Close();
        }

        private TimeSpan generateInterval(decimal intervalValue, TimePeriod intervalPeriod)
        {
            Func<double, TimeSpan> evaluator = null;

            switch (intervalPeriod)
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
    }
}
