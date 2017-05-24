namespace GoDaddyDns
{
    partial class DataRow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkDomain = new System.Windows.Forms.CheckBox();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.lblDomainHealth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkDomain
            // 
            this.chkDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDomain.Location = new System.Drawing.Point(3, 4);
            this.chkDomain.Name = "chkDomain";
            this.chkDomain.Size = new System.Drawing.Size(157, 20);
            this.chkDomain.TabIndex = 4;
            this.chkDomain.Text = "your.domain.to.update";
            this.chkDomain.UseVisualStyleBackColor = true;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.Location = new System.Drawing.Point(166, 2);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(180, 23);
            this.lblLastUpdated.TabIndex = 5;
            this.lblLastUpdated.Text = "1/1/0001 12:00:00 AM";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDomainHealth
            // 
            this.lblDomainHealth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDomainHealth.BackColor = System.Drawing.Color.Green;
            this.lblDomainHealth.ForeColor = System.Drawing.Color.White;
            this.lblDomainHealth.Location = new System.Drawing.Point(352, 2);
            this.lblDomainHealth.Name = "lblDomainHealth";
            this.lblDomainHealth.Size = new System.Drawing.Size(167, 23);
            this.lblDomainHealth.TabIndex = 6;
            this.lblDomainHealth.Text = "OK";
            this.lblDomainHealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.chkDomain);
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.lblDomainHealth);
            this.Name = "DataRow";
            this.Size = new System.Drawing.Size(522, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDomain;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Label lblDomainHealth;
    }
}
