namespace Com.Winfotian.MngTool
{
    partial class FrmValveEffect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxDtu = new System.Windows.Forms.ComboBox();
            this.lblDtu = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.cbxQDtu = new System.Windows.Forms.ComboBox();
            this.lblQDtuName = new System.Windows.Forms.Label();
            this.lblQDtuGroup = new System.Windows.Forms.Label();
            this.lblQCompany = new System.Windows.Forms.Label();
            this.cbxQCompany = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblCloseTime = new System.Windows.Forms.Label();
            this.dtpCloseTime = new System.Windows.Forms.DateTimePicker();
            this.txtEffctUserNum = new System.Windows.Forms.TextBox();
            this.lblEffctUserNum = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtEffctArea = new System.Windows.Forms.TextBox();
            this.lblEffctArea = new System.Windows.Forms.Label();
            this.dgvValve = new System.Windows.Forms.DataGridView();
            this.ValveCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EffctArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EffctUserNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dtuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtValveName = new System.Windows.Forms.TextBox();
            this.lblValveCode = new System.Windows.Forms.Label();
            this.lblValveName = new System.Windows.Forms.Label();
            this.txtValveCode = new System.Windows.Forms.TextBox();
            this.gbxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValve)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxDtu
            // 
            this.cbxDtu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDtu.FormattingEnabled = true;
            this.cbxDtu.Location = new System.Drawing.Point(524, 349);
            this.cbxDtu.Name = "cbxDtu";
            this.cbxDtu.Size = new System.Drawing.Size(158, 20);
            this.cbxDtu.TabIndex = 171;
            this.cbxDtu.SelectedIndexChanged += new System.EventHandler(this.cbxDtu_SelectedIndexChanged);
            // 
            // lblDtu
            // 
            this.lblDtu.AutoSize = true;
            this.lblDtu.Location = new System.Drawing.Point(464, 352);
            this.lblDtu.Name = "lblDtu";
            this.lblDtu.Size = new System.Drawing.Size(53, 12);
            this.lblDtu.TabIndex = 170;
            this.lblDtu.Text = "站点名称";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(252, 353);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(53, 12);
            this.lblGroup.TabIndex = 169;
            this.lblGroup.Text = "站点分组";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(4, 353);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(53, 12);
            this.lblCompany.TabIndex = 168;
            this.lblCompany.Text = "所属公司";
            // 
            // cbxCompany
            // 
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(63, 349);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(186, 20);
            this.cbxCompany.TabIndex = 167;
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbxCompany_SelectedIndexChanged);
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.cbxQDtu);
            this.gbxSearch.Controls.Add(this.lblQDtuName);
            this.gbxSearch.Controls.Add(this.lblQDtuGroup);
            this.gbxSearch.Controls.Add(this.lblQCompany);
            this.gbxSearch.Controls.Add(this.cbxQCompany);
            this.gbxSearch.Controls.Add(this.btnQuery);
            this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearch.Location = new System.Drawing.Point(0, 0);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(696, 43);
            this.gbxSearch.TabIndex = 166;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "查询";
            // 
            // cbxQDtu
            // 
            this.cbxQDtu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQDtu.FormattingEnabled = true;
            this.cbxQDtu.Location = new System.Drawing.Point(475, 15);
            this.cbxQDtu.Name = "cbxQDtu";
            this.cbxQDtu.Size = new System.Drawing.Size(158, 20);
            this.cbxQDtu.TabIndex = 104;
            // 
            // lblQDtuName
            // 
            this.lblQDtuName.AutoSize = true;
            this.lblQDtuName.Location = new System.Drawing.Point(416, 19);
            this.lblQDtuName.Name = "lblQDtuName";
            this.lblQDtuName.Size = new System.Drawing.Size(53, 12);
            this.lblQDtuName.TabIndex = 103;
            this.lblQDtuName.Text = "站点名称";
            // 
            // lblQDtuGroup
            // 
            this.lblQDtuGroup.AutoSize = true;
            this.lblQDtuGroup.Location = new System.Drawing.Point(254, 19);
            this.lblQDtuGroup.Name = "lblQDtuGroup";
            this.lblQDtuGroup.Size = new System.Drawing.Size(53, 12);
            this.lblQDtuGroup.TabIndex = 101;
            this.lblQDtuGroup.Text = "站点分组";
            // 
            // lblQCompany
            // 
            this.lblQCompany.AutoSize = true;
            this.lblQCompany.Location = new System.Drawing.Point(5, 19);
            this.lblQCompany.Name = "lblQCompany";
            this.lblQCompany.Size = new System.Drawing.Size(53, 12);
            this.lblQCompany.TabIndex = 76;
            this.lblQCompany.Text = "所属公司";
            // 
            // cbxQCompany
            // 
            this.cbxQCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQCompany.FormattingEnabled = true;
            this.cbxQCompany.Location = new System.Drawing.Point(64, 15);
            this.cbxQCompany.Name = "cbxQCompany";
            this.cbxQCompany.Size = new System.Drawing.Size(186, 20);
            this.cbxQCompany.TabIndex = 75;
            this.cbxQCompany.SelectedIndexChanged += new System.EventHandler(this.cbxQCompany_SelectedIndexChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(639, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(52, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblCloseTime
            // 
            this.lblCloseTime.AutoSize = true;
            this.lblCloseTime.Location = new System.Drawing.Point(4, 419);
            this.lblCloseTime.Name = "lblCloseTime";
            this.lblCloseTime.Size = new System.Drawing.Size(53, 12);
            this.lblCloseTime.TabIndex = 165;
            this.lblCloseTime.Text = "关阀时间";
            // 
            // dtpCloseTime
            // 
            this.dtpCloseTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCloseTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCloseTime.Location = new System.Drawing.Point(63, 415);
            this.dtpCloseTime.Name = "dtpCloseTime";
            this.dtpCloseTime.Size = new System.Drawing.Size(186, 21);
            this.dtpCloseTime.TabIndex = 164;
            // 
            // txtEffctUserNum
            // 
            this.txtEffctUserNum.Location = new System.Drawing.Point(631, 415);
            this.txtEffctUserNum.Name = "txtEffctUserNum";
            this.txtEffctUserNum.Size = new System.Drawing.Size(51, 21);
            this.txtEffctUserNum.TabIndex = 163;
            this.txtEffctUserNum.Text = "0";
            // 
            // lblEffctUserNum
            // 
            this.lblEffctUserNum.AutoSize = true;
            this.lblEffctUserNum.Location = new System.Drawing.Point(572, 418);
            this.lblEffctUserNum.Name = "lblEffctUserNum";
            this.lblEffctUserNum.Size = new System.Drawing.Size(53, 12);
            this.lblEffctUserNum.TabIndex = 162;
            this.lblEffctUserNum.Text = "影响户数";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(444, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 159;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(335, 450);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 158;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(226, 450);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 157;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(117, 450);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 156;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtEffctArea
            // 
            this.txtEffctArea.Location = new System.Drawing.Point(309, 415);
            this.txtEffctArea.Name = "txtEffctArea";
            this.txtEffctArea.Size = new System.Drawing.Size(257, 21);
            this.txtEffctArea.TabIndex = 153;
            // 
            // lblEffctArea
            // 
            this.lblEffctArea.AutoSize = true;
            this.lblEffctArea.Location = new System.Drawing.Point(252, 419);
            this.lblEffctArea.Name = "lblEffctArea";
            this.lblEffctArea.Size = new System.Drawing.Size(53, 12);
            this.lblEffctArea.TabIndex = 152;
            this.lblEffctArea.Text = "影响区域";
            // 
            // dgvValve
            // 
            this.dgvValve.AllowUserToAddRows = false;
            this.dgvValve.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValve.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvValve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvValve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValveCode,
            this.ValveName,
            this.ClosedTime,
            this.EffctArea,
            this.EffctUserNum,
            this.Dtuid});
            this.dgvValve.Location = new System.Drawing.Point(0, 49);
            this.dgvValve.MultiSelect = false;
            this.dgvValve.Name = "dgvValve";
            this.dgvValve.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValve.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvValve.RowHeadersVisible = false;
            this.dgvValve.RowTemplate.Height = 23;
            this.dgvValve.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvValve.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValve.Size = new System.Drawing.Size(696, 294);
            this.dgvValve.TabIndex = 151;
            this.dgvValve.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValve_CellDoubleClick);
            // 
            // ValveCode
            // 
            this.ValveCode.DataPropertyName = "ValveCode";
            this.ValveCode.HeaderText = "阀门编号";
            this.ValveCode.Name = "ValveCode";
            this.ValveCode.ReadOnly = true;
            this.ValveCode.Width = 120;
            // 
            // ValveName
            // 
            this.ValveName.DataPropertyName = "ValveName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ValveName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ValveName.HeaderText = "阀门名称";
            this.ValveName.Name = "ValveName";
            this.ValveName.ReadOnly = true;
            this.ValveName.Width = 220;
            // 
            // ClosedTime
            // 
            this.ClosedTime.DataPropertyName = "ClosedTime";
            this.ClosedTime.HeaderText = "关阀时间";
            this.ClosedTime.Name = "ClosedTime";
            this.ClosedTime.ReadOnly = true;
            // 
            // EffctArea
            // 
            this.EffctArea.DataPropertyName = "EffctArea";
            this.EffctArea.HeaderText = "影响区域";
            this.EffctArea.Name = "EffctArea";
            this.EffctArea.ReadOnly = true;
            this.EffctArea.Width = 180;
            // 
            // EffctUserNum
            // 
            this.EffctUserNum.DataPropertyName = "EffctUserNum";
            this.EffctUserNum.HeaderText = "影响户数";
            this.EffctUserNum.Name = "EffctUserNum";
            this.EffctUserNum.ReadOnly = true;
            this.EffctUserNum.Width = 80;
            // 
            // Dtuid
            // 
            this.Dtuid.DataPropertyName = "Dtuid";
            this.Dtuid.HeaderText = "Dtuid";
            this.Dtuid.Name = "Dtuid";
            this.Dtuid.ReadOnly = true;
            this.Dtuid.Visible = false;
            // 
            // txtValveName
            // 
            this.txtValveName.Location = new System.Drawing.Point(309, 381);
            this.txtValveName.Name = "txtValveName";
            this.txtValveName.Size = new System.Drawing.Size(257, 21);
            this.txtValveName.TabIndex = 150;
            this.txtValveName.Text = "[阀门1]";
            // 
            // lblValveCode
            // 
            this.lblValveCode.AutoSize = true;
            this.lblValveCode.Location = new System.Drawing.Point(4, 385);
            this.lblValveCode.Name = "lblValveCode";
            this.lblValveCode.Size = new System.Drawing.Size(53, 12);
            this.lblValveCode.TabIndex = 147;
            this.lblValveCode.Text = "阀门编号";
            // 
            // lblValveName
            // 
            this.lblValveName.AutoSize = true;
            this.lblValveName.Location = new System.Drawing.Point(252, 385);
            this.lblValveName.Name = "lblValveName";
            this.lblValveName.Size = new System.Drawing.Size(53, 12);
            this.lblValveName.TabIndex = 149;
            this.lblValveName.Text = "阀门名称";
            // 
            // txtValveCode
            // 
            this.txtValveCode.Enabled = false;
            this.txtValveCode.Location = new System.Drawing.Point(63, 381);
            this.txtValveCode.Name = "txtValveCode";
            this.txtValveCode.Size = new System.Drawing.Size(186, 21);
            this.txtValveCode.TabIndex = 148;
            // 
            // FrmValveEffect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 477);
            this.Controls.Add(this.cbxDtu);
            this.Controls.Add(this.lblDtu);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.gbxSearch);
            this.Controls.Add(this.lblCloseTime);
            this.Controls.Add(this.dtpCloseTime);
            this.Controls.Add(this.txtEffctUserNum);
            this.Controls.Add(this.lblEffctUserNum);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEffctArea);
            this.Controls.Add(this.lblEffctArea);
            this.Controls.Add(this.dgvValve);
            this.Controls.Add(this.txtValveName);
            this.Controls.Add(this.lblValveCode);
            this.Controls.Add(this.lblValveName);
            this.Controls.Add(this.txtValveCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmValveEffect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阀门影响管理";
            this.Load += new System.EventHandler(this.FrmValveEffect_Load);
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEffctUserNum;
        private System.Windows.Forms.Label lblEffctUserNum;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtEffctArea;
        private System.Windows.Forms.Label lblEffctArea;
        private System.Windows.Forms.DataGridView dgvValve;
        private System.Windows.Forms.TextBox txtValveName;
        private System.Windows.Forms.Label lblValveCode;
        private System.Windows.Forms.Label lblValveName;
        private System.Windows.Forms.TextBox txtValveCode;
        private System.Windows.Forms.Label lblCloseTime;
        private System.Windows.Forms.DateTimePicker dtpCloseTime;
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.Label lblQDtuName;
        private System.Windows.Forms.Label lblQDtuGroup;
        private System.Windows.Forms.Label lblQCompany;
        private System.Windows.Forms.ComboBox cbxQCompany;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxQDtu;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblDtu;
        private System.Windows.Forms.ComboBox cbxDtu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValveCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValveName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EffctArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn EffctUserNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dtuid;
    }
}