namespace Com.Winfotian.MngTool
{
    partial class FrmUserRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserRole));
            this.txtRoleDesc = new System.Windows.Forms.TextBox();
            this.lblRoleDesc = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtRoleCode = new System.Windows.Forms.TextBox();
            this.lblRoleCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvRoleList = new System.Windows.Forms.DataGridView();
            this.RoleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtuidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.gbxQuery = new System.Windows.Forms.GroupBox();
            this.txtQRoleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleList)).BeginInit();
            this.gbxQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRoleDesc
            // 
            this.txtRoleDesc.Location = new System.Drawing.Point(78, 343);
            this.txtRoleDesc.Name = "txtRoleDesc";
            this.txtRoleDesc.Size = new System.Drawing.Size(377, 21);
            this.txtRoleDesc.TabIndex = 54;
            // 
            // lblRoleDesc
            // 
            this.lblRoleDesc.AutoSize = true;
            this.lblRoleDesc.Location = new System.Drawing.Point(7, 347);
            this.lblRoleDesc.Name = "lblRoleDesc";
            this.lblRoleDesc.Size = new System.Drawing.Size(53, 12);
            this.lblRoleDesc.TabIndex = 53;
            this.lblRoleDesc.Text = "角色描述";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(308, 309);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(147, 21);
            this.txtRoleName.TabIndex = 52;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Location = new System.Drawing.Point(237, 313);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(53, 12);
            this.lblRoleName.TabIndex = 51;
            this.lblRoleName.Text = "角色名称";
            // 
            // txtRoleCode
            // 
            this.txtRoleCode.Location = new System.Drawing.Point(78, 309);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Size = new System.Drawing.Size(147, 21);
            this.txtRoleCode.TabIndex = 50;
            // 
            // lblRoleCode
            // 
            this.lblRoleCode.AutoSize = true;
            this.lblRoleCode.Location = new System.Drawing.Point(7, 313);
            this.lblRoleCode.Name = "lblRoleCode";
            this.lblRoleCode.Size = new System.Drawing.Size(53, 12);
            this.lblRoleCode.TabIndex = 49;
            this.lblRoleCode.Text = "角色编号";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(42, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvRoleList
            // 
            this.dgvRoleList.AllowUserToAddRows = false;
            this.dgvRoleList.AllowUserToResizeRows = false;
            this.dgvRoleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoleCode,
            this.DtuidName,
            this.RoleDesc,
            this.UpdateFlag});
            this.dgvRoleList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRoleList.Location = new System.Drawing.Point(0, 55);
            this.dgvRoleList.MultiSelect = false;
            this.dgvRoleList.Name = "dgvRoleList";
            this.dgvRoleList.ReadOnly = true;
            this.dgvRoleList.RowHeadersVisible = false;
            this.dgvRoleList.RowTemplate.Height = 23;
            this.dgvRoleList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRoleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoleList.Size = new System.Drawing.Size(477, 243);
            this.dgvRoleList.TabIndex = 62;
            this.dgvRoleList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoleList_CellDoubleClick);
            // 
            // RoleCode
            // 
            this.RoleCode.DataPropertyName = "RoleCode";
            this.RoleCode.HeaderText = "角色编号";
            this.RoleCode.Name = "RoleCode";
            this.RoleCode.ReadOnly = true;
            this.RoleCode.Width = 120;
            // 
            // DtuidName
            // 
            this.DtuidName.DataPropertyName = "RoleName";
            this.DtuidName.HeaderText = "角色名称";
            this.DtuidName.Name = "DtuidName";
            this.DtuidName.ReadOnly = true;
            this.DtuidName.Width = 120;
            // 
            // RoleDesc
            // 
            this.RoleDesc.DataPropertyName = "RoleDesc";
            this.RoleDesc.HeaderText = "角色描述";
            this.RoleDesc.Name = "RoleDesc";
            this.RoleDesc.ReadOnly = true;
            this.RoleDesc.Width = 233;
            // 
            // UpdateFlag
            // 
            this.UpdateFlag.DataPropertyName = "UpdateFlag";
            this.UpdateFlag.HeaderText = "UpdateFlag";
            this.UpdateFlag.Name = "UpdateFlag";
            this.UpdateFlag.ReadOnly = true;
            this.UpdateFlag.Visible = false;
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(134, 378);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 63;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(227, 378);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 64;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // gbxQuery
            // 
            this.gbxQuery.Controls.Add(this.txtQRoleName);
            this.gbxQuery.Controls.Add(this.label1);
            this.gbxQuery.Controls.Add(this.btnQuery);
            this.gbxQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxQuery.Location = new System.Drawing.Point(0, 0);
            this.gbxQuery.Name = "gbxQuery";
            this.gbxQuery.Size = new System.Drawing.Size(477, 55);
            this.gbxQuery.TabIndex = 65;
            this.gbxQuery.TabStop = false;
            this.gbxQuery.Text = "查询";
            // 
            // txtQRoleName
            // 
            this.txtQRoleName.Location = new System.Drawing.Point(81, 20);
            this.txtQRoleName.Name = "txtQRoleName";
            this.txtQRoleName.Size = new System.Drawing.Size(314, 21);
            this.txtQRoleName.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "角色名称";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(413, 19);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(52, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(320, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 413);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvRoleList);
            this.Controls.Add(this.gbxQuery);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRoleDesc);
            this.Controls.Add(this.lblRoleDesc);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.txtRoleCode);
            this.Controls.Add(this.lblRoleCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户角色";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleList)).EndInit();
            this.gbxQuery.ResumeLayout(false);
            this.gbxQuery.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoleDesc;
        private System.Windows.Forms.Label lblRoleDesc;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox txtRoleCode;
        private System.Windows.Forms.Label lblRoleCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvRoleList;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.GroupBox gbxQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtQRoleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtuidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFlag;
    }
}