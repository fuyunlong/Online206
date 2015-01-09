namespace Com.Winfotian.MngTool
{
    partial class FrmDtuUserManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxDtu = new System.Windows.Forms.ComboBox();
            this.lblQDtuName = new System.Windows.Forms.Label();
            this.lblQDtuGroup = new System.Windows.Forms.Label();
            this.lblQCompany = new System.Windows.Forms.Label();
            this.cbxQCompany = new System.Windows.Forms.ComboBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.gbxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.btnQuery);
            this.gbxSearch.Controls.Add(this.cbxDtu);
            this.gbxSearch.Controls.Add(this.lblQDtuName);
            this.gbxSearch.Controls.Add(this.lblQDtuGroup);
            this.gbxSearch.Controls.Add(this.lblQCompany);
            this.gbxSearch.Controls.Add(this.cbxQCompany);
            this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearch.Location = new System.Drawing.Point(0, 0);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(367, 113);
            this.gbxSearch.TabIndex = 113;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "筛选";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(317, 39);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(47, 47);
            this.btnQuery.TabIndex = 111;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxDtu
            // 
            this.cbxDtu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDtu.FormattingEnabled = true;
            this.cbxDtu.Location = new System.Drawing.Point(61, 81);
            this.cbxDtu.Name = "cbxDtu";
            this.cbxDtu.Size = new System.Drawing.Size(250, 20);
            this.cbxDtu.TabIndex = 110;
            // 
            // lblQDtuName
            // 
            this.lblQDtuName.AutoSize = true;
            this.lblQDtuName.Location = new System.Drawing.Point(29, 85);
            this.lblQDtuName.Name = "lblQDtuName";
            this.lblQDtuName.Size = new System.Drawing.Size(29, 12);
            this.lblQDtuName.TabIndex = 103;
            this.lblQDtuName.Text = "站点";
            // 
            // lblQDtuGroup
            // 
            this.lblQDtuGroup.AutoSize = true;
            this.lblQDtuGroup.Location = new System.Drawing.Point(5, 56);
            this.lblQDtuGroup.Name = "lblQDtuGroup";
            this.lblQDtuGroup.Size = new System.Drawing.Size(53, 12);
            this.lblQDtuGroup.TabIndex = 101;
            this.lblQDtuGroup.Text = "站点分组";
            // 
            // lblQCompany
            // 
            this.lblQCompany.AutoSize = true;
            this.lblQCompany.Location = new System.Drawing.Point(5, 25);
            this.lblQCompany.Name = "lblQCompany";
            this.lblQCompany.Size = new System.Drawing.Size(53, 12);
            this.lblQCompany.TabIndex = 76;
            this.lblQCompany.Text = "所属公司";
            // 
            // cbxQCompany
            // 
            this.cbxQCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQCompany.FormattingEnabled = true;
            this.cbxQCompany.Location = new System.Drawing.Point(61, 21);
            this.cbxQCompany.Name = "cbxQCompany";
            this.cbxQCompany.Size = new System.Drawing.Size(250, 20);
            this.cbxQCompany.TabIndex = 75;
            this.cbxQCompany.SelectedIndexChanged += new System.EventHandler(this.cbxQCompany_SelectedIndexChanged);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.TrueName});
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvUser.Location = new System.Drawing.Point(0, 113);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(367, 236);
            this.dgvUser.TabIndex = 114;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UserId.DefaultCellStyle = dataGridViewCellStyle2;
            this.UserId.FillWeight = 130F;
            this.UserId.HeaderText = "用户名";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Width = 130;
            // 
            // TrueName
            // 
            this.TrueName.DataPropertyName = "TrueName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TrueName.DefaultCellStyle = dataGridViewCellStyle3;
            this.TrueName.FillWeight = 235F;
            this.TrueName.HeaderText = "真实姓名";
            this.TrueName.Name = "TrueName";
            this.TrueName.ReadOnly = true;
            this.TrueName.Width = 235;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(100, 362);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 115;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(236, 362);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 116;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // FrmDtuUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 397);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.gbxSearch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDtuUserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站点用户管理";
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.ComboBox cbxDtu;
        private System.Windows.Forms.Label lblQDtuName;
        private System.Windows.Forms.Label lblQDtuGroup;
        private System.Windows.Forms.Label lblQCompany;
        private System.Windows.Forms.ComboBox cbxQCompany;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrueName;
    }
}