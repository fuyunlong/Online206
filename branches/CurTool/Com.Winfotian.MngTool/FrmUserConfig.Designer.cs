namespace Com.Winfotian.MngTool
{
    partial class FrmUserConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserConfig));
            this.txtConfigName = new System.Windows.Forms.TextBox();
            this.lblConfigName = new System.Windows.Forms.Label();
            this.lblSoftInterval = new System.Windows.Forms.Label();
            this.txtConfigDesc = new System.Windows.Forms.TextBox();
            this.lblConfigDesc = new System.Windows.Forms.Label();
            this.numUDSoftInterval = new System.Windows.Forms.NumericUpDown();
            this.lblIsAlert = new System.Windows.Forms.Label();
            this.lblIsWinUser = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnIsAlertTrue = new System.Windows.Forms.RadioButton();
            this.rbtnIsAlertFalse = new System.Windows.Forms.RadioButton();
            this.dgvUserConfigList = new System.Windows.Forms.DataGridView();
            this.ConfigName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoftInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ckList = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnIsRptTrue = new System.Windows.Forms.RadioButton();
            this.rbtnIsRptFalse = new System.Windows.Forms.RadioButton();
            this.lblIsRtp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSoftInterval)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserConfigList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConfigName
            // 
            this.txtConfigName.Location = new System.Drawing.Point(81, 235);
            this.txtConfigName.Name = "txtConfigName";
            this.txtConfigName.Size = new System.Drawing.Size(376, 21);
            this.txtConfigName.TabIndex = 46;
            // 
            // lblConfigName
            // 
            this.lblConfigName.AutoSize = true;
            this.lblConfigName.Location = new System.Drawing.Point(22, 238);
            this.lblConfigName.Name = "lblConfigName";
            this.lblConfigName.Size = new System.Drawing.Size(53, 12);
            this.lblConfigName.TabIndex = 45;
            this.lblConfigName.Text = "配置名称";
            // 
            // lblSoftInterval
            // 
            this.lblSoftInterval.AutoSize = true;
            this.lblSoftInterval.Location = new System.Drawing.Point(22, 485);
            this.lblSoftInterval.Name = "lblSoftInterval";
            this.lblSoftInterval.Size = new System.Drawing.Size(53, 12);
            this.lblSoftInterval.TabIndex = 49;
            this.lblSoftInterval.Text = "刷新时间";
            // 
            // txtConfigDesc
            // 
            this.txtConfigDesc.Location = new System.Drawing.Point(80, 268);
            this.txtConfigDesc.Multiline = true;
            this.txtConfigDesc.Name = "txtConfigDesc";
            this.txtConfigDesc.Size = new System.Drawing.Size(377, 58);
            this.txtConfigDesc.TabIndex = 48;
            // 
            // lblConfigDesc
            // 
            this.lblConfigDesc.AutoSize = true;
            this.lblConfigDesc.Location = new System.Drawing.Point(22, 291);
            this.lblConfigDesc.Name = "lblConfigDesc";
            this.lblConfigDesc.Size = new System.Drawing.Size(53, 12);
            this.lblConfigDesc.TabIndex = 47;
            this.lblConfigDesc.Text = "配置描述";
            // 
            // numUDSoftInterval
            // 
            this.numUDSoftInterval.Location = new System.Drawing.Point(81, 481);
            this.numUDSoftInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUDSoftInterval.Name = "numUDSoftInterval";
            this.numUDSoftInterval.ReadOnly = true;
            this.numUDSoftInterval.Size = new System.Drawing.Size(58, 21);
            this.numUDSoftInterval.TabIndex = 51;
            this.numUDSoftInterval.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // lblIsAlert
            // 
            this.lblIsAlert.AutoSize = true;
            this.lblIsAlert.Location = new System.Drawing.Point(159, 485);
            this.lblIsAlert.Name = "lblIsAlert";
            this.lblIsAlert.Size = new System.Drawing.Size(53, 12);
            this.lblIsAlert.TabIndex = 53;
            this.lblIsAlert.Text = "接收报警";
            // 
            // lblIsWinUser
            // 
            this.lblIsWinUser.AutoSize = true;
            this.lblIsWinUser.Location = new System.Drawing.Point(34, 343);
            this.lblIsWinUser.Name = "lblIsWinUser";
            this.lblIsWinUser.Size = new System.Drawing.Size(41, 12);
            this.lblIsWinUser.TabIndex = 59;
            this.lblIsWinUser.Text = "使用者";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtnIsAlertTrue);
            this.panel3.Controls.Add(this.rbtnIsAlertFalse);
            this.panel3.Location = new System.Drawing.Point(224, 480);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(80, 23);
            this.panel3.TabIndex = 63;
            // 
            // rbtnIsAlertTrue
            // 
            this.rbtnIsAlertTrue.AutoSize = true;
            this.rbtnIsAlertTrue.Checked = true;
            this.rbtnIsAlertTrue.Location = new System.Drawing.Point(4, 3);
            this.rbtnIsAlertTrue.Name = "rbtnIsAlertTrue";
            this.rbtnIsAlertTrue.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsAlertTrue.TabIndex = 54;
            this.rbtnIsAlertTrue.TabStop = true;
            this.rbtnIsAlertTrue.Text = "是";
            this.rbtnIsAlertTrue.UseVisualStyleBackColor = true;
            // 
            // rbtnIsAlertFalse
            // 
            this.rbtnIsAlertFalse.AutoSize = true;
            this.rbtnIsAlertFalse.Location = new System.Drawing.Point(43, 3);
            this.rbtnIsAlertFalse.Name = "rbtnIsAlertFalse";
            this.rbtnIsAlertFalse.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsAlertFalse.TabIndex = 53;
            this.rbtnIsAlertFalse.Text = "否";
            this.rbtnIsAlertFalse.UseVisualStyleBackColor = true;
            // 
            // dgvUserConfigList
            // 
            this.dgvUserConfigList.AllowUserToAddRows = false;
            this.dgvUserConfigList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserConfigList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserConfigList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUserConfigList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigName,
            this.ConfigDesc,
            this.CCode,
            this.SoftInterval,
            this.IsAlert,
            this.PopCode,
            this.UpdateFlag});
            this.dgvUserConfigList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvUserConfigList.Location = new System.Drawing.Point(0, 0);
            this.dgvUserConfigList.MultiSelect = false;
            this.dgvUserConfigList.Name = "dgvUserConfigList";
            this.dgvUserConfigList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserConfigList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserConfigList.RowHeadersVisible = false;
            this.dgvUserConfigList.RowTemplate.Height = 23;
            this.dgvUserConfigList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUserConfigList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserConfigList.Size = new System.Drawing.Size(477, 222);
            this.dgvUserConfigList.TabIndex = 91;
            this.dgvUserConfigList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserConfigList_CellDoubleClick);
            // 
            // ConfigName
            // 
            this.ConfigName.DataPropertyName = "ConfigName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ConfigName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ConfigName.HeaderText = "配置名称";
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.ReadOnly = true;
            this.ConfigName.Width = 120;
            // 
            // ConfigDesc
            // 
            this.ConfigDesc.DataPropertyName = "ConfigDesc";
            this.ConfigDesc.HeaderText = "配置描述";
            this.ConfigDesc.Name = "ConfigDesc";
            this.ConfigDesc.ReadOnly = true;
            this.ConfigDesc.Width = 365;
            // 
            // CCode
            // 
            this.CCode.DataPropertyName = "CCode";
            this.CCode.HeaderText = "CCode";
            this.CCode.Name = "CCode";
            this.CCode.ReadOnly = true;
            this.CCode.Visible = false;
            // 
            // SoftInterval
            // 
            this.SoftInterval.DataPropertyName = "SoftInterval";
            this.SoftInterval.HeaderText = "SoftInterval";
            this.SoftInterval.Name = "SoftInterval";
            this.SoftInterval.ReadOnly = true;
            this.SoftInterval.Visible = false;
            // 
            // IsAlert
            // 
            this.IsAlert.DataPropertyName = "IsAlert";
            this.IsAlert.HeaderText = "IsAlert";
            this.IsAlert.Name = "IsAlert";
            this.IsAlert.ReadOnly = true;
            this.IsAlert.Visible = false;
            // 
            // PopCode
            // 
            this.PopCode.DataPropertyName = "PopCode";
            this.PopCode.HeaderText = "PopCode";
            this.PopCode.Name = "PopCode";
            this.PopCode.ReadOnly = true;
            this.PopCode.Visible = false;
            // 
            // UpdateFlag
            // 
            this.UpdateFlag.DataPropertyName = "UpdateFlag";
            this.UpdateFlag.HeaderText = "UpdateFlag";
            this.UpdateFlag.Name = "UpdateFlag";
            this.UpdateFlag.ReadOnly = true;
            this.UpdateFlag.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(367, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 104;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(258, 518);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 103;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(149, 518);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 102;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(40, 518);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 101;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ckList
            // 
            this.ckList.CheckOnClick = true;
            this.ckList.ColumnWidth = 120;
            this.ckList.FormattingEnabled = true;
            this.ckList.Location = new System.Drawing.Point(80, 339);
            this.ckList.MultiColumn = true;
            this.ckList.Name = "ckList";
            this.ckList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckList.Size = new System.Drawing.Size(377, 132);
            this.ckList.TabIndex = 105;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnIsRptTrue);
            this.panel1.Controls.Add(this.rbtnIsRptFalse);
            this.panel1.Location = new System.Drawing.Point(374, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 23);
            this.panel1.TabIndex = 107;
            // 
            // rbtnIsRptTrue
            // 
            this.rbtnIsRptTrue.AutoSize = true;
            this.rbtnIsRptTrue.Location = new System.Drawing.Point(4, 3);
            this.rbtnIsRptTrue.Name = "rbtnIsRptTrue";
            this.rbtnIsRptTrue.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsRptTrue.TabIndex = 54;
            this.rbtnIsRptTrue.Text = "是";
            this.rbtnIsRptTrue.UseVisualStyleBackColor = true;
            // 
            // rbtnIsRptFalse
            // 
            this.rbtnIsRptFalse.AutoSize = true;
            this.rbtnIsRptFalse.Checked = true;
            this.rbtnIsRptFalse.Location = new System.Drawing.Point(45, 3);
            this.rbtnIsRptFalse.Name = "rbtnIsRptFalse";
            this.rbtnIsRptFalse.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsRptFalse.TabIndex = 53;
            this.rbtnIsRptFalse.TabStop = true;
            this.rbtnIsRptFalse.Text = "否";
            this.rbtnIsRptFalse.UseVisualStyleBackColor = true;
            // 
            // lblIsRtp
            // 
            this.lblIsRtp.AutoSize = true;
            this.lblIsRtp.Location = new System.Drawing.Point(323, 485);
            this.lblIsRtp.Name = "lblIsRtp";
            this.lblIsRtp.Size = new System.Drawing.Size(53, 12);
            this.lblIsRtp.TabIndex = 106;
            this.lblIsRtp.Text = "短信报表";
            // 
            // FrmUserConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblIsRtp);
            this.Controls.Add(this.ckList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvUserConfigList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblIsWinUser);
            this.Controls.Add(this.lblIsAlert);
            this.Controls.Add(this.numUDSoftInterval);
            this.Controls.Add(this.lblSoftInterval);
            this.Controls.Add(this.txtConfigDesc);
            this.Controls.Add(this.lblConfigDesc);
            this.Controls.Add(this.txtConfigName);
            this.Controls.Add(this.lblConfigName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户配置";
            ((System.ComponentModel.ISupportInitialize)(this.numUDSoftInterval)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserConfigList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConfigName;
        private System.Windows.Forms.Label lblConfigName;
        private System.Windows.Forms.Label lblSoftInterval;
        private System.Windows.Forms.TextBox txtConfigDesc;
        private System.Windows.Forms.Label lblConfigDesc;
        private System.Windows.Forms.NumericUpDown numUDSoftInterval;
        private System.Windows.Forms.Label lblIsAlert;
        private System.Windows.Forms.Label lblIsWinUser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtnIsAlertTrue;
        private System.Windows.Forms.RadioButton rbtnIsAlertFalse;
        private System.Windows.Forms.DataGridView dgvUserConfigList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckedListBox ckList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoftInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFlag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnIsRptTrue;
        private System.Windows.Forms.RadioButton rbtnIsRptFalse;
        private System.Windows.Forms.Label lblIsRtp;
    }
}