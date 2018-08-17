namespace GoDaddyDns
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateIpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portugueseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblCurrentIp = new System.Windows.Forms.ToolStripStatusLabel();
            this.gvDomains = new System.Windows.Forms.DataGridView();
            this.domainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmsDomain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            this.btnRefreshToolip = new System.Windows.Forms.ToolTip(this.components);
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.timerIpRefresh = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showGoDaddyDNSUpdaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDomains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainBindingSource)).BeginInit();
            this.cmsDomain.SuspendLayout();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.btnRefreshToolip.SetToolTip(this.menuStrip, resources.GetString("menuStrip.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateIpToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // updateIpToolStripMenuItem1
            // 
            resources.ApplyResources(this.updateIpToolStripMenuItem1, "updateIpToolStripMenuItem1");
            this.updateIpToolStripMenuItem1.Name = "updateIpToolStripMenuItem1";
            this.updateIpToolStripMenuItem1.Click += new System.EventHandler(this.updateIpToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // closeToolStripMenuItem
            // 
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.portugueseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // portugueseToolStripMenuItem
            // 
            resources.ApplyResources(this.portugueseToolStripMenuItem, "portugueseToolStripMenuItem");
            this.portugueseToolStripMenuItem.Name = "portugueseToolStripMenuItem";
            this.portugueseToolStripMenuItem.Click += new System.EventHandler(this.portugueseToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.lblCurrentIp});
            this.statusStrip.Name = "statusStrip";
            this.btnRefreshToolip.SetToolTip(this.statusStrip, resources.GetString("statusStrip.ToolTip"));
            // 
            // toolStripProgressBar1
            // 
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            // 
            // lblCurrentIp
            // 
            resources.ApplyResources(this.lblCurrentIp, "lblCurrentIp");
            this.lblCurrentIp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblCurrentIp.Name = "lblCurrentIp";
            this.lblCurrentIp.Spring = true;
            // 
            // gvDomains
            // 
            resources.ApplyResources(this.gvDomains, "gvDomains");
            this.gvDomains.AllowUserToAddRows = false;
            this.gvDomains.AutoGenerateColumns = false;
            this.gvDomains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDomains.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gvDomains.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gvDomains.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvDomains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDomains.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDomains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDomains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.domainDataGridViewTextBoxColumn,
            this.current_ip});
            this.gvDomains.DataSource = this.domainBindingSource;
            this.gvDomains.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvDomains.EnableHeadersVisualStyles = false;
            this.gvDomains.Name = "gvDomains";
            this.gvDomains.RowHeadersVisible = false;
            this.gvDomains.RowTemplate.ContextMenuStrip = this.cmsDomain;
            this.gvDomains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDomains.ShowCellErrors = false;
            this.gvDomains.ShowCellToolTips = false;
            this.gvDomains.ShowEditingIcon = false;
            this.gvDomains.ShowRowErrors = false;
            this.btnRefreshToolip.SetToolTip(this.gvDomains, resources.GetString("gvDomains.ToolTip"));
            this.gvDomains.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvDomains_DataBindingComplete);
            this.gvDomains.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvDomains_MouseDown);
            // 
            // domainDataGridViewTextBoxColumn
            // 
            this.domainDataGridViewTextBoxColumn.DataPropertyName = "Domain";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.domainDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.domainDataGridViewTextBoxColumn, "domainDataGridViewTextBoxColumn");
            this.domainDataGridViewTextBoxColumn.Name = "domainDataGridViewTextBoxColumn";
            // 
            // current_ip
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.current_ip.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.current_ip, "current_ip");
            this.current_ip.Name = "current_ip";
            // 
            // domainBindingSource
            // 
            this.domainBindingSource.DataSource = typeof(DynamicDns.Core.Dto.DomainSummaryDto);
            // 
            // cmsDomain
            // 
            resources.ApplyResources(this.cmsDomain, "cmsDomain");
            this.cmsDomain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateIPToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.cmsDomain.Name = "cmsDomain";
            this.btnRefreshToolip.SetToolTip(this.cmsDomain, resources.GetString("cmsDomain.ToolTip"));
            // 
            // updateIPToolStripMenuItem
            // 
            resources.ApplyResources(this.updateIPToolStripMenuItem, "updateIPToolStripMenuItem");
            this.updateIPToolStripMenuItem.Name = "updateIPToolStripMenuItem";
            this.updateIPToolStripMenuItem.Click += new System.EventHandler(this.updateIPToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            resources.ApplyResources(this.cancelToolStripMenuItem, "cancelToolStripMenuItem");
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // btnRefreshAll
            // 
            resources.ApplyResources(this.btnRefreshAll, "btnRefreshAll");
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshToolip.SetToolTip(this.btnRefreshAll, resources.GetString("btnRefreshAll.ToolTip"));
            this.btnRefreshAll.UseVisualStyleBackColor = true;
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // timerProgress
            // 
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // timerIpRefresh
            // 
            this.timerIpRefresh.Enabled = true;
            this.timerIpRefresh.Interval = 3600000;
            this.timerIpRefresh.Tick += new System.EventHandler(this.timerIpRefresh_Tick);
            // 
            // trayIcon
            // 
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.ContextMenuStrip = this.cmsTray;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // cmsTray
            // 
            resources.ApplyResources(this.cmsTray, "cmsTray");
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGoDaddyDNSUpdaterToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cmsTray.Name = "cmsTray";
            this.btnRefreshToolip.SetToolTip(this.cmsTray, resources.GetString("cmsTray.ToolTip"));
            // 
            // showGoDaddyDNSUpdaterToolStripMenuItem
            // 
            resources.ApplyResources(this.showGoDaddyDNSUpdaterToolStripMenuItem, "showGoDaddyDNSUpdaterToolStripMenuItem");
            this.showGoDaddyDNSUpdaterToolStripMenuItem.Name = "showGoDaddyDNSUpdaterToolStripMenuItem";
            this.showGoDaddyDNSUpdaterToolStripMenuItem.Click += new System.EventHandler(this.showGoDaddyDNSUpdaterToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefreshAll);
            this.Controls.Add(this.gvDomains);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.btnRefreshToolip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDomains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainBindingSource)).EndInit();
            this.cmsDomain.ResumeLayout(false);
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentIp;
        private System.Windows.Forms.DataGridView gvDomains;
        private System.Windows.Forms.BindingSource domainBindingSource;
        private System.Windows.Forms.ContextMenuStrip cmsDomain;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateIpToolStripMenuItem1;
        private System.Windows.Forms.Button btnRefreshAll;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portugueseToolStripMenuItem;
        private System.Windows.Forms.ToolTip btnRefreshToolip;
        private System.Windows.Forms.Timer timerProgress;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn domainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_ip;
        private System.Windows.Forms.Timer timerIpRefresh;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem showGoDaddyDNSUpdaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

