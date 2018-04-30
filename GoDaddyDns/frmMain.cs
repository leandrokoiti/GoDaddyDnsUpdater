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
using DynamicDns.Core.Classes;
using DynamicDns.Core.Dto;

namespace GoDaddyDns
{
    public partial class frmMain : frmBase
    {
        #region Fields
        /// <summary>
        /// The external IP address of this machine.
        /// </summary>
        protected string _currentIp;

        private DnsManager _dnsManager = new DnsManager(Program.ApiKey, Program.ApiSecret, Program.DefaultTtl);
        #endregion

        #region Constructors
        public frmMain()
        {
            initializeUI();

            this.CultureChanged += FrmMain_CultureChanged;
            NetworkStatus.AvailabilityChanged += NetworkStatus_AvailabilityChanged;
        }
        #endregion

        #region Event Handlers
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
            if (this.toolStripProgressBar1.Value == this.toolStripProgressBar1.Maximum)
                this.toolStripProgressBar1.Value = 0;
            else
                this.toolStripProgressBar1.Value += 1;
        }

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

        private async void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSettings();
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.gvDomains.DataSource = null;
                this._dnsManager = new DnsManager(Program.ApiKey, Program.ApiSecret, Program.DefaultTtl);
                this.timerIpRefresh.Interval = (int)Program.UpdateFrequency.TotalMilliseconds;
                await refreshDomainsList();
            }
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

                if (hti?.RowIndex < 0)
                    return;

                this.gvDomains.ClearSelection();
                this.gvDomains.Rows[hti.RowIndex].Selected = true;
            }
        }

        private async void btnRefreshAll_Click(object sender, EventArgs e)
        {
            await loadCurrentIpAddress();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeCulture("en-US");
        }

        private void portugueseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeCulture("pt-BR");
        }

        private async void updateIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.gvDomains.SelectedRows)
            {
                if (row.DataBoundItem is DomainSummaryDto domain)
                    await updateDomain(domain);
            }
        }
        #endregion

        #region Public Methods
        public void ShowErrorMessage(string message)
        {
            this.lblCurrentIp.Text = message;
            this.lblCurrentIp.ForeColor = Color.Red;
        }
        #endregion

        #region Private Methods
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
        /// Refreshes the ip of the selected domain.
        /// </summary>
        /// <returns></returns>
        private async Task updateDomain(DomainSummaryDto domain)
        {
            var updateMessage = String.Format(Properties.Resources.frmMain_UpdatingDomainIp, domain.Domain);
            await updateDomain(updateMessage, async () =>
            {
                await this._dnsManager.UpdateDomain(domain, this._currentIp);
                await refreshDomainsList();
            });
        }

        /// <summary>
        /// Refreshes the ip of every domain stored in this application.
        /// </summary>
        /// <returns></returns>
        private async Task updateAllDomains()
        {
            var updateMessage = Properties.Resources.frmMain_UpdatingDomainsIp;
            await updateDomain(updateMessage, async () =>
            {
                await this._dnsManager.UpdateAllDomains(this._currentIp);
                await refreshDomainsList();
            });
        }

        /// <summary>
        /// Checks if the application has a key and a secret before executing the given function.
        /// </summary>
        /// <param name="fx">The function to be executed.</param>
        /// <returns></returns>
        /// <remarks>The function will be a function that uses GoDaddy's API, that's why it needs a key and
        /// a secret set before running it.</remarks>
        private async Task runGoDaddyFunction(Func<Task> fx)
        {
            if (String.IsNullOrWhiteSpace(Program.ApiKey) ||
                String.IsNullOrWhiteSpace(Program.ApiSecret))
                return;

            await startProgress(fx);
        }

        /// <summary>
        /// Encapsulates the logic involved in updating a domain, which includes settings
        /// the progress bar and changing the UI message.
        /// </summary>
        /// <param name="updatingMessage">The message to set in the user interface.</param>
        /// <param name="fx">The function to invoke.</param>
        /// <returns></returns>
        private async Task updateDomain(string updatingMessage, Func<Task> fx)
        {
            await runGoDaddyFunction(async () =>
            {
                var lastMessage = this.lblCurrentIp.Text;

                this.lblCurrentIp.Text = updatingMessage;

                await fx();

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
        /// Lists all domains available.
        /// </summary>
        private async Task refreshDomainsList()
        {
            await runGoDaddyFunction(async () =>
            {
                this.gvDomains.Enabled = false;
                this.gvDomains.DataSource = await this._dnsManager.ListDomains();
                this.gvDomains.Enabled = true;
            });
        }

        /// <summary>
        /// Starts the progress bar and executes long running method.
        /// </summary>
        /// <param name="fx">The method to be executed that will need a progress bar while the user awaits.</param>
        /// <returns></returns>
        private async Task startProgress(Func<Task> fx)
        {
            this.toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Visible = true;
            this.timerProgress.Enabled = true;

            try
            {
                await fx();
                this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum;
            }
            finally
            {
                stopProgress();
            }
        }

        /// <summary>
        /// Stops the progress bar and resets its value.
        /// </summary>
        private void stopProgress()
        {
            this.toolStripProgressBar1.Value = 0;

            this.timerProgress.Enabled = false;
        }

        /// <summary>
        /// Invokes a webmethod to check for the external ip address of the network of this machine.
        /// </summary>
        /// <returns></returns>
        private async Task loadCurrentIpAddress()
        {
            this.lblCurrentIp.Text = Properties.Resources.frmMain_CheckingIp;

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

            // Places the refresh on the top right corner of the window, since after invoking 
            // InitializeComponent it will be placed on its starting position
            this.btnRefreshAll.Left = this.gvDomains.Width - this.btnRefreshAll.Width;
            this.btnRefreshAll.Top = 0;

            // Loads the interval stored in the settings
            this.timerIpRefresh.Interval = (int)Program.UpdateFrequency.TotalMilliseconds;

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
        #endregion

        private async void timerIpRefresh_Tick(object sender, EventArgs e)
        {
            await loadCurrentIpAddress();
        }
    }
}
