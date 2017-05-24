using EncryptStringSample;
using GoDaddyDns.Dto;
using iTuner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoDaddyDns
{
    public partial class frmMain : frmBase
    {
        /// <summary>
        /// The external IP address of this machine.
        /// </summary>
        protected string _currentIp;

        private DnsManager _dnsManager = new DnsManager(Program.ApiKey, Program.ApiSecret, Program.DefaultTtl);

        public frmMain()
        {
            initializeUI();

            this.CultureChanged += FrmMain_CultureChanged;
            NetworkStatus.AvailabilityChanged += NetworkStatus_AvailabilityChanged;
        }

        #region Event Handlers
        private void FrmMain_CultureChanged(object sender, EventArgs e)
        {
            // Stores the newly selected culture inside the application settings
            Properties.Settings.Default.appLanguage = this.culture.Name;
            Properties.Settings.Default.Save();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await refreshDomainsList();

            await loadCurrentIpAddress();
        }

        private async void NetworkStatus_AvailabilityChanged(object sender, NetworkStatusChangedArgs e)
        {
            // If the network is available we must check for the IP address since it may have change since
            // the last time we checked, and enable network related functions.
            // If there's no network available we simply disable the network functions.
            if (e.IsAvailable)
            {
                await loadCurrentIpAddress();

                toggleNetworkFunctions(true);
            }
            else
            {
                toggleNetworkFunctions(false);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSettings();
            frm.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cmsDomain.Close();
        }

        private async void updateIpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await updateAllDomains();
        }

        private void gvDomains_MouseDown(object sender, MouseEventArgs e)
        {
            // Selects the current row that was right clicked, since we have a context menu in this control
            // we need to handle the click event on mouse down or it will not work
            if (e.Button == MouseButtons.Right)
            {
                var hti = this.gvDomains.HitTest(e.X, e.Y);
                this.gvDomains.ClearSelection();
                this.gvDomains.Rows[hti.RowIndex].Selected = true;
            }
        }

        private async void btnRefreshAll_Click(object sender, EventArgs e)
        {
            await updateAllDomains();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeCulture("en-US");
        }

        private void portugueseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeCulture("pt-BR");
        }
        #endregion

        /// <summary>
        /// Changes the culture of the application for the culture specified.
        /// </summary>
        /// <param name="name"><see cref="CultureInfo.Name"/></param>
        private void changeCulture(string name)
        {
            Program.GlobalUICulture = new CultureInfo(name);
            initializeUI();
        }

        /// <summary>
        /// Refreshes the ip of every domain stored in this application.
        /// </summary>
        /// <returns></returns>
        private async Task updateAllDomains()
        {
            var lastMessage = this.lblCurrentIp.Text;

            this.Invoke((MethodInvoker)delegate ()
            {
                this.lblCurrentIp.Text = Properties.Resources.frmMain_UpdatingDomainsIp;
            });

            await this._dnsManager.UpdateAllDomains(this._currentIp);
            await refreshDomainsList();

            this.Invoke((MethodInvoker)delegate ()
            {
                this.lblCurrentIp.Text = lastMessage;
            });
        }

        /// <summary>
        /// Enables or disables the functions that require an internet connection.
        /// </summary>
        /// <param name="enabled"></param>
        private void toggleNetworkFunctions(bool enabled)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.btnRefreshAll.Enabled = enabled;
                this.updateIPToolStripMenuItem.Enabled = enabled;
                this.updateIpToolStripMenuItem1.Enabled = enabled;
            });
        }

        /// <summary>
        /// Lists all domains stored in this application.
        /// </summary>
        private async Task refreshDomainsList()
        {
            showProgress();

            this.gvDomains.Enabled = false;
            this.gvDomains.DataSource = await this._dnsManager.ListDomains();
            this.gvDomains.Enabled = true;

            stopProgress();
        }

        private void stopProgress()
        {
            this.btnRefreshAll.Enabled = true;
            this.updateIPToolStripMenuItem.Enabled = true;
            this.updateIpToolStripMenuItem1.Enabled = true;

            this.pbGridView.Visible = false;
            this.timerProgress.Enabled = false;
        }

        private void showProgress()
        {
            this.btnRefreshAll.Enabled = false;
            this.updateIPToolStripMenuItem.Enabled = false;
            this.updateIpToolStripMenuItem1.Enabled = false;

            this.pbGridView.Value = 0;
            this.pbGridView.Left = (this.gvDomains.Right / 2) - (this.pbGridView.Width / 2);
            this.pbGridView.Top = (this.gvDomains.Bottom / 2) - (this.pbGridView.Height / 2);
            this.pbGridView.Visible = true;
            this.timerProgress.Enabled = true;
        }

        /// <summary>
        /// Invokes a webmethod to check for the external ip address of the network of this machine.
        /// </summary>
        /// <returns></returns>
        private async Task loadCurrentIpAddress()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.lblCurrentIp.Text = Properties.Resources.frmMain_CheckingIp;
            });

            if (NetworkStatus.IsAvailable)
            {
                try
                {
                    var currentIp = await this._dnsManager.GetCurrentIp();
                    this.lblCurrentIp.Text = String.Format(Properties.Resources.frmMain_YourCurrentIp, currentIp.Ip);

                    if (currentIp.Ip != this._currentIp)
                    {
                        this._currentIp = currentIp.Ip;
                        await this.updateAllDomains();
                    }
                    else
                    {
                        this._currentIp = currentIp.Ip;
                    }
                }
                catch (Exception ex)
                {
                    this.lblCurrentIp.Text = String.Format(Properties.Resources.frmMain_ErrorCurrentIp, ex.Message);
                }
            }
            else
            {
                this.lblCurrentIp.Text = String.Format(Properties.Resources.frmMain_NoNetworkCurrentIp);
            }
        }

        /// <summary>
        /// Logic required to initialize the User Interface.
        /// </summary>
        /// <remarks>Must be called every time the current culture of the application is changed.</remarks>
        private async void initializeUI()
        {
            // Stores the default culture of the application as the current culture
            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.appLanguage))
                Properties.Settings.Default.appLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

            // Sets the current culture of the application for the value previously stored
            Program.GlobalUICulture = new CultureInfo(Properties.Settings.Default.appLanguage);

            // Remove all controls so they can be re-rendered with the new culture
            Controls.Clear();

            // Invokes the designer method to initialize all controls with the current culture
            InitializeComponent();

            // Loads fonts stored within this application
            setCustomFonts();

            // Refreshes the ip (since we invoke this method when this application starts, we need to check if the handle is already created
            // If not, the method will be invoked later by the initialization of the form itself
            if (this.IsHandleCreated)
            {
                await refreshDomainsList();
                await loadCurrentIpAddress();
            }

            // 
            highlightCurrentLanguage();
        }

        /// <summary>
        /// Marks the current language of the application with an "✓" before its text
        /// </summary>
        private void highlightCurrentLanguage()
        {
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "pt-BR")
            {
                this.portugueseToolStripMenuItem.Text = $"✓ {this.portugueseToolStripMenuItem.Text}";
            }
            else
            {
                this.englishToolStripMenuItem.Text = $"✓ {this.englishToolStripMenuItem.Text}";
            }
        }

        /// <summary>
        /// Loads fonts stored inside the application and sets them to the required controls.
        /// </summary>
        private void setCustomFonts()
        {
            this.btnRefreshAll.Font = Program.FontManager.Load("FontAwesome", 12F, FontStyle.Regular);
        }

        private void gvDomains_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in this.gvDomains.Rows)
            {
                var data = r.DataBoundItem as DomainSummaryDto;
                r.Cells["current_ip"].Value = data.Records.FirstOrDefault().Data;
            }
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            if (this.pbGridView.Value == this.pbGridView.Maximum)
                this.pbGridView.Value = 0;
            else
                this.pbGridView.Value += 1;
        }
    }
}
