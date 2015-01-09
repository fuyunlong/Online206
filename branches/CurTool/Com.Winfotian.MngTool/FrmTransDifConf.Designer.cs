namespace Com.Winfotian.MngTool
{
    partial class FrmTransDifConf
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
            this.tvDtuField = new System.Windows.Forms.TreeView();
            this.ctMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuConf = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.lblQCompany = new System.Windows.Forms.Label();
            this.cbxQCompany = new System.Windows.Forms.ComboBox();
            this.ctMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDtuField
            // 
            this.tvDtuField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tvDtuField.Location = new System.Drawing.Point(0, 34);
            this.tvDtuField.Name = "tvDtuField";
            this.tvDtuField.Size = new System.Drawing.Size(384, 440);
            this.tvDtuField.TabIndex = 0;
            this.tvDtuField.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDtuField_NodeMouseClick);
            // 
            // ctMenu
            // 
            this.ctMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConf,
            this.menuDel});
            this.ctMenu.Name = "ctMenu";
            this.ctMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // menuConf
            // 
            this.menuConf.Name = "menuConf";
            this.menuConf.Size = new System.Drawing.Size(152, 22);
            this.menuConf.Text = "配置";
            this.menuConf.Click += new System.EventHandler(this.menuConf_Click);
            // 
            // menuDel
            // 
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(152, 22);
            this.menuDel.Text = "删除配置";
            this.menuDel.Click += new System.EventHandler(this.menuDel_Click);
            // 
            // lblQCompany
            // 
            this.lblQCompany.AutoSize = true;
            this.lblQCompany.Location = new System.Drawing.Point(8, 12);
            this.lblQCompany.Name = "lblQCompany";
            this.lblQCompany.Size = new System.Drawing.Size(53, 12);
            this.lblQCompany.TabIndex = 108;
            this.lblQCompany.Text = "所属公司";
            // 
            // cbxQCompany
            // 
            this.cbxQCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQCompany.FormattingEnabled = true;
            this.cbxQCompany.Location = new System.Drawing.Point(67, 8);
            this.cbxQCompany.Name = "cbxQCompany";
            this.cbxQCompany.Size = new System.Drawing.Size(305, 20);
            this.cbxQCompany.TabIndex = 107;
            this.cbxQCompany.SelectedIndexChanged += new System.EventHandler(this.cbxQCompany_SelectedIndexChanged);
            // 
            // FrmTransDifConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 474);
            this.Controls.Add(this.lblQCompany);
            this.Controls.Add(this.cbxQCompany);
            this.Controls.Add(this.tvDtuField);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransDifConf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输差配置";
            this.ctMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDtuField;
        private System.Windows.Forms.ContextMenuStrip ctMenu;
        private System.Windows.Forms.ToolStripMenuItem menuConf;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.Label lblQCompany;
        private System.Windows.Forms.ComboBox cbxQCompany;
    }
}