namespace Com.Winfotian.MngTool
{
    partial class FrmUserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserGroup));
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblParentCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.lblGroupDesc = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.lblUserGroupTree = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblQCompany = new System.Windows.Forms.Label();
            this.cbxQCompany = new System.Windows.Forms.ComboBox();
            this.dgvUserGroupList = new System.Windows.Forms.DataGridView();
            this.GroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserGroupList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(63, 325);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(132, 21);
            this.txtGroupName.TabIndex = 84;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(6, 329);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(53, 12);
            this.lblGroupName.TabIndex = 83;
            this.lblGroupName.Text = "分组名称";
            // 
            // lblParentCode
            // 
            this.lblParentCode.AutoSize = true;
            this.lblParentCode.Location = new System.Drawing.Point(201, 329);
            this.lblParentCode.Name = "lblParentCode";
            this.lblParentCode.Size = new System.Drawing.Size(41, 12);
            this.lblParentCode.TabIndex = 82;
            this.lblParentCode.Text = "父分组";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 81;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Location = new System.Drawing.Point(63, 362);
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.Size = new System.Drawing.Size(297, 21);
            this.txtGroupDesc.TabIndex = 80;
            // 
            // lblGroupDesc
            // 
            this.lblGroupDesc.AutoSize = true;
            this.lblGroupDesc.Location = new System.Drawing.Point(4, 365);
            this.lblGroupDesc.Name = "lblGroupDesc";
            this.lblGroupDesc.Size = new System.Drawing.Size(53, 12);
            this.lblGroupDesc.TabIndex = 79;
            this.lblGroupDesc.Text = "分组描述";
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(107, 405);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 86;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // lblUserGroupTree
            // 
            this.lblUserGroupTree.AutoSize = true;
            this.lblUserGroupTree.Location = new System.Drawing.Point(4, 128);
            this.lblUserGroupTree.Name = "lblUserGroupTree";
            this.lblUserGroupTree.Size = new System.Drawing.Size(53, 12);
            this.lblUserGroupTree.TabIndex = 89;
            this.lblUserGroupTree.Text = "分组列表";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(303, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 90;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblQCompany
            // 
            this.lblQCompany.AutoSize = true;
            this.lblQCompany.Location = new System.Drawing.Point(4, 11);
            this.lblQCompany.Name = "lblQCompany";
            this.lblQCompany.Size = new System.Drawing.Size(53, 12);
            this.lblQCompany.TabIndex = 92;
            this.lblQCompany.Text = "所属公司";
            // 
            // cbxQCompany
            // 
            this.cbxQCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQCompany.FormattingEnabled = true;
            this.cbxQCompany.Location = new System.Drawing.Point(63, 7);
            this.cbxQCompany.Name = "cbxQCompany";
            this.cbxQCompany.Size = new System.Drawing.Size(232, 20);
            this.cbxQCompany.TabIndex = 91;
            // 
            // dgvUserGroupList
            // 
            this.dgvUserGroupList.AllowUserToAddRows = false;
            this.dgvUserGroupList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUserGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupCode,
            this.GroupName,
            this.GroupDesc,
            this.ParentCode,
            this.UpdateFlag,
            this.Company,
            this.Status});
            this.dgvUserGroupList.Location = new System.Drawing.Point(63, 35);
            this.dgvUserGroupList.MultiSelect = false;
            this.dgvUserGroupList.Name = "dgvUserGroupList";
            this.dgvUserGroupList.ReadOnly = true;
            this.dgvUserGroupList.RowHeadersVisible = false;
            this.dgvUserGroupList.RowTemplate.Height = 23;
            this.dgvUserGroupList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUserGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserGroupList.Size = new System.Drawing.Size(297, 237);
            this.dgvUserGroupList.TabIndex = 93;
            this.dgvUserGroupList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserGroupList_CellDoubleClick);
            // 
            // GroupCode
            // 
            this.GroupCode.DataPropertyName = "GroupCode";
            this.GroupCode.HeaderText = "GroupCode";
            this.GroupCode.Name = "GroupCode";
            this.GroupCode.ReadOnly = true;
            this.GroupCode.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "分组名称";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 295;
            // 
            // GroupDesc
            // 
            this.GroupDesc.DataPropertyName = "GroupDesc";
            this.GroupDesc.HeaderText = "GroupDesc";
            this.GroupDesc.Name = "GroupDesc";
            this.GroupDesc.ReadOnly = true;
            this.GroupDesc.Visible = false;
            // 
            // ParentCode
            // 
            this.ParentCode.DataPropertyName = "ParentCode";
            this.ParentCode.HeaderText = "ParentCode";
            this.ParentCode.Name = "ParentCode";
            this.ParentCode.ReadOnly = true;
            this.ParentCode.Visible = false;
            // 
            // UpdateFlag
            // 
            this.UpdateFlag.DataPropertyName = "UpdateFlag";
            this.UpdateFlag.HeaderText = "UpdateFlag";
            this.UpdateFlag.Name = "UpdateFlag";
            this.UpdateFlag.ReadOnly = true;
            this.UpdateFlag.Visible = false;
            // 
            // Company
            // 
            this.Company.DataPropertyName = "CompanyId";
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(308, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(52, 23);
            this.btnQuery.TabIndex = 94;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 96;
            this.label1.Text = "所属公司";
            // 
            // cbxCompany
            // 
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(63, 289);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(297, 20);
            this.cbxCompany.TabIndex = 95;
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbxCompany_SelectedIndexChanged);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(205, 405);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 87;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // FrmUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 442);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dgvUserGroupList);
            this.Controls.Add(this.lblQCompany);
            this.Controls.Add(this.cbxQCompany);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblUserGroupTree);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.lblParentCode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGroupDesc);
            this.Controls.Add(this.lblGroupDesc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户分组";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserGroupList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblParentCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGroupDesc;
        private System.Windows.Forms.Label lblGroupDesc;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Label lblUserGroupTree;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblQCompany;
        private System.Windows.Forms.ComboBox cbxQCompany;
        private System.Windows.Forms.DataGridView dgvUserGroupList;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;

    }
}