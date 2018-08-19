﻿namespace GoDaddyDns
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
            this.numTtl = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpAppSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTtl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.numTtl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtApiSecret);
            this.groupBox1.Controls.Add(this.txtApiKey);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblKey);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtApiSecret
            // 
            resources.ApplyResources(this.txtApiSecret, "txtApiSecret");
            this.txtApiSecret.Name = "txtApiSecret";
            // 
            // txtApiKey
            // 
            resources.ApplyResources(this.txtApiKey, "txtApiKey");
            this.txtApiKey.Name = "txtApiKey";
            // 
            // txtRemarks
            // 
            resources.ApplyResources(this.txtRemarks, "txtRemarks");
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Control;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtRemarks_LinkClicked);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblKey
            // 
            resources.ApplyResources(this.lblKey, "lblKey");
            this.lblKey.Name = "lblKey";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // grpAppSettings
            // 
            resources.ApplyResources(this.grpAppSettings, "grpAppSettings");
            this.grpAppSettings.Controls.Add(this.chkTray);
            this.grpAppSettings.Controls.Add(this.cmbPeriod);
            this.grpAppSettings.Controls.Add(this.numTimeout);
            this.grpAppSettings.Controls.Add(this.lblCheckInterval);
            this.grpAppSettings.Name = "grpAppSettings";
            this.grpAppSettings.TabStop = false;
            // 
            // chkTray
            // 
            resources.ApplyResources(this.chkTray, "chkTray");
            this.chkTray.Name = "chkTray";
            this.chkTray.UseVisualStyleBackColor = true;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            resources.GetString("cmbPeriod.Items"),
            resources.GetString("cmbPeriod.Items1"),
            resources.GetString("cmbPeriod.Items2"),
            resources.GetString("cmbPeriod.Items3")});
            resources.ApplyResources(this.cmbPeriod, "cmbPeriod");
            this.cmbPeriod.Name = "cmbPeriod";
            // 
            // numTimeout
            // 
            resources.ApplyResources(this.numTimeout, "numTimeout");
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
            this.lblCheckInterval.Name = "lblCheckInterval";
            // 
            // numTtl
            // 
            resources.ApplyResources(this.numTtl, "numTtl");
            this.numTtl.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numTtl.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numTtl.Name = "numTtl";
            this.numTtl.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
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
            ((System.ComponentModel.ISupportInitialize)(this.numTtl)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox grpAppSettings;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label lblCheckInterval;
        private System.Windows.Forms.CheckBox chkTray;
        private System.Windows.Forms.NumericUpDown numTtl;
    }
}