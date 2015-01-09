namespace Com.Winfotian.MngTool
{
    partial class FrmDtuUser
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
            this.txtDtuid = new System.Windows.Forms.TextBox();
            this.lblDtuid = new System.Windows.Forms.Label();
            this.lblDtuName = new System.Windows.Forms.Label();
            this.txtDtuName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cklbUser = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // txtDtuid
            // 
            this.txtDtuid.Location = new System.Drawing.Point(83, 17);
            this.txtDtuid.Name = "txtDtuid";
            this.txtDtuid.ReadOnly = true;
            this.txtDtuid.Size = new System.Drawing.Size(235, 21);
            this.txtDtuid.TabIndex = 0;
            // 
            // lblDtuid
            // 
            this.lblDtuid.AutoSize = true;
            this.lblDtuid.Location = new System.Drawing.Point(24, 20);
            this.lblDtuid.Name = "lblDtuid";
            this.lblDtuid.Size = new System.Drawing.Size(53, 12);
            this.lblDtuid.TabIndex = 1;
            this.lblDtuid.Text = "站点编号";
            // 
            // lblDtuName
            // 
            this.lblDtuName.AutoSize = true;
            this.lblDtuName.Location = new System.Drawing.Point(24, 56);
            this.lblDtuName.Name = "lblDtuName";
            this.lblDtuName.Size = new System.Drawing.Size(53, 12);
            this.lblDtuName.TabIndex = 3;
            this.lblDtuName.Text = "站点名称";
            // 
            // txtDtuName
            // 
            this.txtDtuName.Location = new System.Drawing.Point(83, 53);
            this.txtDtuName.Name = "txtDtuName";
            this.txtDtuName.ReadOnly = true;
            this.txtDtuName.Size = new System.Drawing.Size(235, 21);
            this.txtDtuName.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(135, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cklbUser
            // 
            this.cklbUser.CheckOnClick = true;
            this.cklbUser.FormattingEnabled = true;
            this.cklbUser.Location = new System.Drawing.Point(83, 88);
            this.cklbUser.Name = "cklbUser";
            this.cklbUser.Size = new System.Drawing.Size(235, 228);
            this.cklbUser.TabIndex = 6;
            // 
            // FrmDtuUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 359);
            this.Controls.Add(this.cklbUser);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDtuName);
            this.Controls.Add(this.txtDtuName);
            this.Controls.Add(this.lblDtuid);
            this.Controls.Add(this.txtDtuid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDtuUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站点用户选择";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDtuid;
        private System.Windows.Forms.Label lblDtuid;
        private System.Windows.Forms.Label lblDtuName;
        private System.Windows.Forms.TextBox txtDtuName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox cklbUser;
    }
}