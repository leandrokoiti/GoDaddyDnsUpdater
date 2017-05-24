namespace GoDaddyDns
{
    partial class frmAddDomain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDomain));
            this.grpDomainInfo = new System.Windows.Forms.GroupBox();
            this.txtRecordName = new System.Windows.Forms.TextBox();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.lblARecordName = new System.Windows.Forms.Label();
            this.lblDomainName = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpDomainInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDomainInfo
            // 
            resources.ApplyResources(this.grpDomainInfo, "grpDomainInfo");
            this.grpDomainInfo.Controls.Add(this.txtRecordName);
            this.grpDomainInfo.Controls.Add(this.txtDomainName);
            this.grpDomainInfo.Controls.Add(this.lblARecordName);
            this.grpDomainInfo.Controls.Add(this.lblDomainName);
            this.grpDomainInfo.Name = "grpDomainInfo";
            this.grpDomainInfo.TabStop = false;
            // 
            // txtRecordName
            // 
            resources.ApplyResources(this.txtRecordName, "txtRecordName");
            this.txtRecordName.Name = "txtRecordName";
            // 
            // txtDomainName
            // 
            resources.ApplyResources(this.txtDomainName, "txtDomainName");
            this.txtDomainName.Name = "txtDomainName";
            // 
            // lblARecordName
            // 
            resources.ApplyResources(this.lblARecordName, "lblARecordName");
            this.lblARecordName.Name = "lblARecordName";
            // 
            // lblDomainName
            // 
            resources.ApplyResources(this.lblDomainName, "lblDomainName");
            this.lblDomainName.Name = "lblDomainName";
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddDomain
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpDomainInfo);
            this.Name = "frmAddDomain";
            this.grpDomainInfo.ResumeLayout(false);
            this.grpDomainInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDomainInfo;
        private System.Windows.Forms.TextBox txtRecordName;
        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.Label lblARecordName;
        private System.Windows.Forms.Label lblDomainName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}