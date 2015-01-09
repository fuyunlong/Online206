namespace Com.Winfotian.MngTool
{
    partial class FrmDtuFieldMana
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDtuFieldMana));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetFilePath = new System.Windows.Forms.Button();
            this.linkTemplateDown = new System.Windows.Forms.LinkLabel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvField = new System.Windows.Forms.DataGridView();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.drp_SelIndex = new System.Windows.Forms.NumericUpDown();
            this.cbxQFieldName = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblQFieldName = new System.Windows.Forms.Label();
            this.cbxDtu = new System.Windows.Forms.ComboBox();
            this.lblQDtuName = new System.Windows.Forms.Label();
            this.lblQDtuGroup = new System.Windows.Forms.Label();
            this.lblQCompany = new System.Windows.Forms.Label();
            this.cbxQCompany = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldShortDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValueMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValueMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLowlimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHighlimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLololimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHihilimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValueInOrOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCollect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).BeginInit();
            this.gbxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drp_SelIndex)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(255, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(305, 23);
            this.btnSave.TabIndex = 120;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetFilePath
            // 
            this.btnGetFilePath.Location = new System.Drawing.Point(485, 500);
            this.btnGetFilePath.Name = "btnGetFilePath";
            this.btnGetFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnGetFilePath.TabIndex = 119;
            this.btnGetFilePath.Text = "浏览";
            this.btnGetFilePath.UseVisualStyleBackColor = true;
            this.btnGetFilePath.Click += new System.EventHandler(this.btnGetFilePath_Click);
            // 
            // linkTemplateDown
            // 
            this.linkTemplateDown.AutoSize = true;
            this.linkTemplateDown.Location = new System.Drawing.Point(760, 505);
            this.linkTemplateDown.Name = "linkTemplateDown";
            this.linkTemplateDown.Size = new System.Drawing.Size(53, 12);
            this.linkTemplateDown.TabIndex = 118;
            this.linkTemplateDown.TabStop = true;
            this.linkTemplateDown.Text = "模板下载";
            this.linkTemplateDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTemplateDown_LinkClicked);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(72, 501);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(407, 21);
            this.txtFilePath.TabIndex = 117;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(585, 500);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 116;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvField
            // 
            this.dgvField.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvField.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvField.ColumnHeadersHeight = 25;
            this.dgvField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colDtuid,
            this.colColName,
            this.colFieldName,
            this.colFieldShortDesc,
            this.colFieldDesc,
            this.colFieldUnit,
            this.colValueMin,
            this.colValueMax,
            this.colLowlimit,
            this.colHighlimit,
            this.colLololimit,
            this.colHihilimit,
            this.colValueInOrOut,
            this.colIsAlert,
            this.IsCollect,
            this.IsShow,
            this.KeyValues,
            this.OrderId,
            this.FieldType,
            this.ParentId,
            this.UpdateFlag});
            this.dgvField.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvField.Location = new System.Drawing.Point(2, 101);
            this.dgvField.MultiSelect = false;
            this.dgvField.Name = "dgvField";
            this.dgvField.RowHeadersVisible = false;
            this.dgvField.RowTemplate.Height = 23;
            this.dgvField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvField.Size = new System.Drawing.Size(823, 394);
            this.dgvField.TabIndex = 113;
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.drp_SelIndex);
            this.gbxSearch.Controls.Add(this.cbxQFieldName);
            this.gbxSearch.Controls.Add(this.btnQuery);
            this.gbxSearch.Controls.Add(this.lblQFieldName);
            this.gbxSearch.Controls.Add(this.cbxDtu);
            this.gbxSearch.Controls.Add(this.lblQDtuName);
            this.gbxSearch.Controls.Add(this.lblQDtuGroup);
            this.gbxSearch.Controls.Add(this.lblQCompany);
            this.gbxSearch.Controls.Add(this.cbxQCompany);
            this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearch.Location = new System.Drawing.Point(0, 0);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(825, 95);
            this.gbxSearch.TabIndex = 112;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "查询";
            // 
            // drp_SelIndex
            // 
            this.drp_SelIndex.Location = new System.Drawing.Point(434, 57);
            this.drp_SelIndex.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.drp_SelIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.drp_SelIndex.Name = "drp_SelIndex";
            this.drp_SelIndex.Size = new System.Drawing.Size(52, 21);
            this.drp_SelIndex.TabIndex = 123;
            this.drp_SelIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.drp_SelIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxQFieldName
            // 
            this.cbxQFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQFieldName.FormattingEnabled = true;
            this.cbxQFieldName.Items.AddRange(new object[] {
            "全部",
            "QB",
            "Q",
            "VB",
            "V",
            "P",
            "T",
            "AI",
            "DI",
            "AO",
            "BO",
            "TC",
            "PC",
            "VC",
            "VBC",
            "QC",
            "QBC"});
            this.cbxQFieldName.Location = new System.Drawing.Point(492, 57);
            this.cbxQFieldName.Name = "cbxQFieldName";
            this.cbxQFieldName.Size = new System.Drawing.Size(96, 20);
            this.cbxQFieldName.TabIndex = 114;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(634, 34);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 111;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblQFieldName
            // 
            this.lblQFieldName.AutoSize = true;
            this.lblQFieldName.Location = new System.Drawing.Point(375, 61);
            this.lblQFieldName.Name = "lblQFieldName";
            this.lblQFieldName.Size = new System.Drawing.Size(53, 12);
            this.lblQFieldName.TabIndex = 113;
            this.lblQFieldName.Text = "字段名称";
            // 
            // cbxDtu
            // 
            this.cbxDtu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDtu.FormattingEnabled = true;
            this.cbxDtu.Location = new System.Drawing.Point(61, 56);
            this.cbxDtu.Name = "cbxDtu";
            this.cbxDtu.Size = new System.Drawing.Size(287, 20);
            this.cbxDtu.TabIndex = 110;
            // 
            // lblQDtuName
            // 
            this.lblQDtuName.AutoSize = true;
            this.lblQDtuName.Location = new System.Drawing.Point(29, 56);
            this.lblQDtuName.Name = "lblQDtuName";
            this.lblQDtuName.Size = new System.Drawing.Size(29, 12);
            this.lblQDtuName.TabIndex = 103;
            this.lblQDtuName.Text = "站点";
            // 
            // lblQDtuGroup
            // 
            this.lblQDtuGroup.AutoSize = true;
            this.lblQDtuGroup.Location = new System.Drawing.Point(375, 24);
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
            this.cbxQCompany.Size = new System.Drawing.Size(287, 20);
            this.cbxQCompany.TabIndex = 75;
            this.cbxQCompany.SelectedIndexChanged += new System.EventHandler(this.cbxQCompany_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 558);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 114);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(622, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 12);
            this.label4.TabIndex = 117;
            this.label4.Text = "注：同一站点字段长描述不能有相同";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(815, 84);
            this.label2.TabIndex = 116;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(666, 500);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 135;
            this.btn_Export.Text = "导出";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // colDtuid
            // 
            this.colDtuid.DataPropertyName = "Dtuid";
            this.colDtuid.HeaderText = "站点编号";
            this.colDtuid.Name = "colDtuid";
            this.colDtuid.ReadOnly = true;
            // 
            // colColName
            // 
            this.colColName.DataPropertyName = "ColName";
            this.colColName.FillWeight = 120F;
            this.colColName.HeaderText = "字段采集名称";
            this.colColName.Name = "colColName";
            this.colColName.ReadOnly = true;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "FieldName";
            this.colFieldName.HeaderText = "字段名称";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            // 
            // colFieldShortDesc
            // 
            this.colFieldShortDesc.DataPropertyName = "FieldShortDesc";
            this.colFieldShortDesc.HeaderText = "字段短描述";
            this.colFieldShortDesc.Name = "colFieldShortDesc";
            // 
            // colFieldDesc
            // 
            this.colFieldDesc.DataPropertyName = "FieldDesc";
            this.colFieldDesc.HeaderText = "字段描述";
            this.colFieldDesc.Name = "colFieldDesc";
            // 
            // colFieldUnit
            // 
            this.colFieldUnit.DataPropertyName = "FieldUnit";
            this.colFieldUnit.HeaderText = "字段单位";
            this.colFieldUnit.Name = "colFieldUnit";
            // 
            // colValueMin
            // 
            this.colValueMin.DataPropertyName = "ValueMin";
            this.colValueMin.HeaderText = "字段最小值";
            this.colValueMin.Name = "colValueMin";
            // 
            // colValueMax
            // 
            this.colValueMax.DataPropertyName = "ValueMax";
            this.colValueMax.HeaderText = "字段最大值";
            this.colValueMax.Name = "colValueMax";
            // 
            // colLowlimit
            // 
            this.colLowlimit.DataPropertyName = "Lowlimit";
            this.colLowlimit.HeaderText = "字段低报警值";
            this.colLowlimit.Name = "colLowlimit";
            // 
            // colHighlimit
            // 
            this.colHighlimit.DataPropertyName = "Highlimit";
            this.colHighlimit.HeaderText = "字段高报警值";
            this.colHighlimit.Name = "colHighlimit";
            // 
            // colLololimit
            // 
            this.colLololimit.DataPropertyName = "Lololimit";
            this.colLololimit.HeaderText = "字段最低报警值";
            this.colLololimit.Name = "colLololimit";
            // 
            // colHihilimit
            // 
            this.colHihilimit.DataPropertyName = "Hihilimit";
            this.colHihilimit.HeaderText = "字段最高报警值";
            this.colHihilimit.Name = "colHihilimit";
            // 
            // colValueInOrOut
            // 
            this.colValueInOrOut.DataPropertyName = "ValueInOrOut";
            this.colValueInOrOut.HeaderText = "进出口类型";
            this.colValueInOrOut.Name = "colValueInOrOut";
            // 
            // colIsAlert
            // 
            this.colIsAlert.DataPropertyName = "IsAlert";
            this.colIsAlert.HeaderText = "是否报警检查";
            this.colIsAlert.Name = "colIsAlert";
            // 
            // IsCollect
            // 
            this.IsCollect.DataPropertyName = "IsCollect";
            this.IsCollect.HeaderText = "是否开启采集";
            this.IsCollect.Name = "IsCollect";
            // 
            // IsShow
            // 
            this.IsShow.DataPropertyName = "IsShow";
            this.IsShow.HeaderText = "是否显示";
            this.IsShow.Name = "IsShow";
            // 
            // KeyValues
            // 
            this.KeyValues.DataPropertyName = "KeyValues";
            this.KeyValues.HeaderText = "DI配置";
            this.KeyValues.Name = "KeyValues";
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "排序";
            this.OrderId.Name = "OrderId";
            // 
            // FieldType
            // 
            this.FieldType.DataPropertyName = "FieldType";
            this.FieldType.HeaderText = "统计类型";
            this.FieldType.Name = "FieldType";
            // 
            // ParentId
            // 
            this.ParentId.DataPropertyName = "ParentId";
            this.ParentId.HeaderText = "父字段";
            this.ParentId.Name = "ParentId";
            this.ParentId.Visible = false;
            // 
            // UpdateFlag
            // 
            this.UpdateFlag.DataPropertyName = "UpdateFlag";
            this.UpdateFlag.HeaderText = "UpdateFlag";
            this.UpdateFlag.Name = "UpdateFlag";
            this.UpdateFlag.Visible = false;
            // 
            // FrmDtuFieldMana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 672);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGetFilePath);
            this.Controls.Add(this.linkTemplateDown);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvField);
            this.Controls.Add(this.gbxSearch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDtuFieldMana";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站点字段管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).EndInit();
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drp_SelIndex)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.Label lblQDtuName;
        private System.Windows.Forms.Label lblQDtuGroup;
        private System.Windows.Forms.Label lblQCompany;
        private System.Windows.Forms.ComboBox cbxQCompany;
        private System.Windows.Forms.ComboBox cbxDtu;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxQFieldName;
        private System.Windows.Forms.Label lblQFieldName;
        private System.Windows.Forms.DataGridView dgvField;
        private System.Windows.Forms.NumericUpDown drp_SelIndex;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetFilePath;
        private System.Windows.Forms.LinkLabel linkTemplateDown;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldShortDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValueMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValueMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLowlimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHighlimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLololimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHihilimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValueInOrOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCollect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFlag;
    }
}