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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtApiSecret = new System.Windows.Forms.TextBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.txtApiSecret);
            this.groupBox1.Controls.Add(this.txtApiKey);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblKey);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}