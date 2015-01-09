namespace Com.Winfotian.MngTool
{
    partial class FrmMain_Extend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain_Extend));
            this.btnCompanyManager = new System.Windows.Forms.Button();
            this.btnUserManager = new System.Windows.Forms.Button();
            this.btnSiteManager = new System.Windows.Forms.Button();
            this.btnDtuIDGenerater = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCompanyManager
            // 
            this.btnCompanyManager.Location = new System.Drawing.Point(209, 177);
            this.btnCompanyManager.Name = "btnCompanyManager";
            this.btnCompanyManager.Size = new System.Drawing.Size(75, 23);
            this.btnCompanyManager.TabIndex = 1;
            this.btnCompanyManager.Text = "公司管理";
            this.btnCompanyManager.UseVisualStyleBackColor = true;
            this.btnCompanyManager.Click += new System.EventHandler(this.btnCompanyManager_Click);
            // 
            // btnUserManager
            // 
            this.btnUserManager.Location = new System.Drawing.Point(396, 326);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(75, 23);
            this.btnUserManager.TabIndex = 2;
            this.btnUserManager.Text = "用户管理";
            this.btnUserManager.UseVisualStyleBackColor = true;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            // 
            // btnSiteManager
            // 
            this.btnSiteManager.Location = new System.Drawing.Point(298, 253);
            this.btnSiteManager.Name = "btnSiteManager";
            this.btnSiteManager.Size = new System.Drawing.Size(75, 23);
            this.btnSiteManager.TabIndex = 3;
            this.btnSiteManager.Text = "站点管理";
            this.btnSiteManager.UseVisualStyleBackColor = true;
            this.btnSiteManager.Click += new System.EventHandler(this.btnSiteManager_Click);
            // 
            // btnDtuIDGenerater
            // 
            this.btnDtuIDGenerater.Location = new System.Drawing.Point(103, 93);
            this.btnDtuIDGenerater.Name = "btnDtuIDGenerater";
            this.btnDtuIDGenerater.Size = new System.Drawing.Size(75, 23);
            this.btnDtuIDGenerater.TabIndex = 4;
            this.btnDtuIDGenerater.Text = "编码生成器";
            this.btnDtuIDGenerater.UseVisualStyleBackColor = true;
            this.btnDtuIDGenerater.Click += new System.EventHandler(this.btnDtuIDGenerater_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Com.Winfotian.MngTool.Properties.Resources.bg;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(916, 602);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 602);
            this.Controls.Add(this.btnDtuIDGenerater);
            this.Controls.Add(this.btnSiteManager);
            this.Controls.Add(this.btnUserManager);
            this.Controls.Add(this.btnCompanyManager);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "英菲信燃气管理平台管理工具（内部专用）";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCompanyManager;
        private System.Windows.Forms.Button btnUserManager;
        private System.Windows.Forms.Button btnSiteManager;
        private System.Windows.Forms.Button btnDtuIDGenerater;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

