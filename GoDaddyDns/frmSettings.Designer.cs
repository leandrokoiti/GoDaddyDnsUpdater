namespace GoDaddyDns
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDefaultTtl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApiSecret = new System.Windows.Forms.TextBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpAppSettings = new System.Windows.Forms.GroupBox();
            this.chkTray = new System.Windows.Forms.CheckBox();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblCheckInterval = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpAppSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.txtDefaultTtl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtApiSecret);
            this.groupBox1.Controls.Add(this.txtApiKey);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblKey);
            this.errorProvider.SetError(this.groupBox1, resources.GetString("groupBox1.Error"));
            this.errorProvider.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding"))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtDefaultTtl
            // 
            resources.ApplyResources(this.txtDefaultTtl, "txtDefaultTtl");
            this.errorProvider.SetError(this.txtDefaultTtl, resources.GetString("txtDefaultTtl.Error"));
            this.errorProvider.SetIconAlignment(this.txtDefaultTtl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtDefaultTtl.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtDefaultTtl, ((int)(resources.GetObject("txtDefaultTtl.IconPadding"))));
            this.txtDefaultTtl.Name = "txtDefaultTtl";
            this.txtDefaultTtl.Validating += new System.ComponentModel.CancelEventHandler(this.txtDefaultTtl_Validating);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // txtApiSecret
            // 
            resources.ApplyResources(this.txtApiSecret, "txtApiSecret");
            this.errorProvider.SetError(this.txtApiSecret, resources.GetString("txtApiSecret.Error"));
            this.errorProvider.SetIconAlignment(this.txtApiSecret, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtApiSecret.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtApiSecret, ((int)(resources.GetObject("txtApiSecret.IconPadding"))));
            this.txtApiSecret.Name = "txtApiSecret";
            // 
            // txtApiKey
            // 
            resources.ApplyResources(this.txtApiKey, "txtApiKey");
            this.errorProvider.SetError(this.txtApiKey, resources.GetString("txtApiKey.Error"));
            this.errorProvider.SetIconAlignment(this.txtApiKey, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtApiKey.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtApiKey, ((int)(resources.GetObject("txtApiKey.IconPadding"))));
            this.txtApiKey.Name = "txtApiKey";
            // 
            // txtRemarks
            // 
            resources.ApplyResources(this.txtRemarks, "txtRemarks");
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Control;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorProvider.SetError(this.txtRemarks, resources.GetString("txtRemarks.Error"));
            this.errorProvider.SetIconAlignment(this.txtRemarks, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtRemarks.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtRemarks, ((int)(resources.GetObject("txtRemarks.IconPadding"))));
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtRemarks_LinkClicked);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // lblKey
            // 
            resources.ApplyResources(this.lblKey, "lblKey");
            this.errorProvider.SetError(this.lblKey, resources.GetString("lblKey.Error"));
            this.errorProvider.SetIconAlignment(this.lblKey, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblKey.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblKey, ((int)(resources.GetObject("lblKey.IconPadding"))));
            this.lblKey.Name = "lblKey";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.errorProvider.SetError(this.btnOk, resources.GetString("btnOk.Error"));
            this.errorProvider.SetIconAlignment(this.btnOk, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnOk.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnOk, ((int)(resources.GetObject("btnOk.IconPadding"))));
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.btnCancel, resources.GetString("btnCancel.Error"));
            this.errorProvider.SetIconAlignment(this.btnCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnCancel, ((int)(resources.GetObject("btnCancel.IconPadding"))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // grpAppSettings
            // 
            resources.ApplyResources(this.grpAppSettings, "grpAppSettings");
            this.grpAppSettings.Controls.Add(this.chkTray);
            this.grpAppSettings.Controls.Add(this.cmbPeriod);
            this.grpAppSettings.Controls.Add(this.numTimeout);
            this.grpAppSettings.Controls.Add(this.lblCheckInterval);
            this.errorProvider.SetError(this.grpAppSettings, resources.GetString("grpAppSettings.Error"));
            this.errorProvider.SetIconAlignment(this.grpAppSettings, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpAppSettings.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.grpAppSettings, ((int)(resources.GetObject("grpAppSettings.IconPadding"))));
            this.grpAppSettings.Name = "grpAppSettings";
            this.grpAppSettings.TabStop = false;
            // 
            // chkTray
            // 
            resources.ApplyResources(this.chkTray, "chkTray");
            this.errorProvider.SetError(this.chkTray, resources.GetString("chkTray.Error"));
            this.errorProvider.SetIconAlignment(this.chkTray, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkTray.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.chkTray, ((int)(resources.GetObject("chkTray.IconPadding"))));
            this.chkTray.Name = "chkTray";
            this.chkTray.UseVisualStyleBackColor = true;
            // 
            // cmbPeriod
            // 
            resources.ApplyResources(this.cmbPeriod, "cmbPeriod");
            this.errorProvider.SetError(this.cmbPeriod, resources.GetString("cmbPeriod.Error"));
            this.cmbPeriod.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cmbPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cmbPeriod.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cmbPeriod, ((int)(resources.GetObject("cmbPeriod.IconPadding"))));
            this.cmbPeriod.Items.AddRange(new object[] {
            resources.GetString("cmbPeriod.Items"),
            resources.GetString("cmbPeriod.Items1"),
            resources.GetString("cmbPeriod.Items2"),
            resources.GetString("cmbPeriod.Items3")});
            this.cmbPeriod.Name = "cmbPeriod";
            // 
            // numTimeout
            // 
            resources.ApplyResources(this.numTimeout, "numTimeout");
            this.errorProvider.SetError(this.numTimeout, resources.GetString("numTimeout.Error"));
            this.errorProvider.SetIconAlignment(this.numTimeout, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("numTimeout.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.numTimeout, ((int)(resources.GetObject("numTimeout.IconPadding"))));
            this.numTimeout.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCheckInterval
            // 
            resources.ApplyResources(this.lblCheckInterval, "lblCheckInterval");
            this.errorProvider.SetError(this.lblCheckInterval, resources.GetString("lblCheckInterval.Error"));
            this.errorProvider.SetIconAlignment(this.lblCheckInterval, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblCheckInterval.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblCheckInterval, ((int)(resources.GetObject("lblCheckInterval.IconPadding"))));
            this.lblCheckInterval.Name = "lblCheckInterval";
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.grpAppSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpAppSettings.ResumeLayout(false);
            this.grpAppSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtApiSecret;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.TextBox txtDefaultTtl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox grpAppSettings;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label lblCheckInterval;
        private System.Windows.Forms.CheckBox chkTray;
    }
}