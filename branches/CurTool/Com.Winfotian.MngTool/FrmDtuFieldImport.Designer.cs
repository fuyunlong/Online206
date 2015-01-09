namespace Com.Winfotian.MngTool
{
    partial class FrmDtuFieldImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDtuFieldImport));
            this.btnGetFilePath = new System.Windows.Forms.Button();
            this.linkTemplateDown = new System.Windows.Forms.LinkLabel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvField = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetFilePath
            // 
            this.btnGetFilePath.Location = new System.Drawing.Point(420, 264);
            this.btnGetFilePath.Name = "btnGetFilePath";
            this.btnGetFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnGetFilePath.TabIndex = 21;
            this.btnGetFilePath.Text = "浏览";
            this.btnGetFilePath.UseVisualStyleBackColor = true;
            this.btnGetFilePath.Click += new System.EventHandler(this.btnGetFilePath_Click);
            // 
            // linkTemplateDown
            // 
            this.linkTemplateDown.AutoSize = true;
            this.linkTemplateDown.Location = new System.Drawing.Point(615, 269);
            this.linkTemplateDown.Name = "linkTemplateDown";
            this.linkTemplateDown.Size = new System.Drawing.Size(53, 12);
            this.linkTemplateDown.TabIndex = 20;
            this.linkTemplateDown.TabStop = true;
            this.linkTemplateDown.Text = "模板下载";
            this.linkTemplateDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTemplateDown_LinkClicked);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(7, 265);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(407, 21);
            this.txtFilePath.TabIndex = 19;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(520, 264);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 18;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(312, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(210, 23);
            this.btnSave.TabIndex = 115;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvField
            // 
            this.dgvField.AllowUserToAddRows = false;
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
            this.ParentId,
            this.OrderId,
            this.FieldType,
            this.Id,
            this.UpdateFlag});
            this.dgvField.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvField.Location = new System.Drawing.Point(0, 0);
            this.dgvField.Name = "dgvField";
            this.dgvField.ReadOnly = true;
            this.dgvField.RowHeadersVisible = false;
            this.dgvField.RowTemplate.Height = 23;
            this.dgvField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvField.Size = new System.Drawing.Size(825, 247);
            this.dgvField.TabIndex = 138;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 114);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 96);
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
            this.label2.Size = new System.Drawing.Size(815, 72);
            this.label2.TabIndex = 116;
            this.label2.Text = resources.GetString("label2.Text");
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
            this.colFieldShortDesc.ReadOnly = true;
            // 
            // colFieldDesc
            // 
            this.colFieldDesc.DataPropertyName = "FieldDesc";
            this.colFieldDesc.HeaderText = "字段描述";
            this.colFieldDesc.Name = "colFieldDesc";
            this.colFieldDesc.ReadOnly = true;
            // 
            // colFieldUnit
            // 
            this.colFieldUnit.DataPropertyName = "FieldUnit";
            this.colFieldUnit.HeaderText = "字段单位";
            this.colFieldUnit.Name = "colFieldUnit";
            this.colFieldUnit.ReadOnly = true;
            // 
            // colValueMin
            // 
            this.colValueMin.DataPropertyName = "ValueMin";
            this.colValueMin.HeaderText = "字段最小值";
            this.colValueMin.Name = "colValueMin";
            this.colValueMin.ReadOnly = true;
            // 
            // colValueMax
            // 
            this.colValueMax.DataPropertyName = "ValueMax";
            this.colValueMax.HeaderText = "字段最大值";
            this.colValueMax.Name = "colValueMax";
            this.colValueMax.ReadOnly = true;
            // 
            // colLowlimit
            // 
            this.colLowlimit.DataPropertyName = "Lowlimit";
            this.colLowlimit.HeaderText = "字段低报警值";
            this.colLowlimit.Name = "colLowlimit";
            this.colLowlimit.ReadOnly = true;
            // 
            // colHighlimit
            // 
            this.colHighlimit.DataPropertyName = "Highlimit";
            this.colHighlimit.HeaderText = "字段高报警值";
            this.colHighlimit.Name = "colHighlimit";
            this.colHighlimit.ReadOnly = true;
            // 
            // colLololimit
            // 
            this.colLololimit.DataPropertyName = "Lololimit";
            this.colLololimit.HeaderText = "字段最低报警值";
            this.colLololimit.Name = "colLololimit";
            this.colLololimit.ReadOnly = true;
            // 
            // colHihilimit
            // 
            this.colHihilimit.DataPropertyName = "Hihilimit";
            this.colHihilimit.HeaderText = "字段最高报警值";
            this.colHihilimit.Name = "colHihilimit";
            this.colHihilimit.ReadOnly = true;
            // 
            // colValueInOrOut
            // 
            this.colValueInOrOut.DataPropertyName = "ValueInOrOut";
            this.colValueInOrOut.HeaderText = "进出口类型";
            this.colValueInOrOut.Name = "colValueInOrOut";
            this.colValueInOrOut.ReadOnly = true;
            // 
            // colIsAlert
            // 
            this.colIsAlert.DataPropertyName = "IsAlert";
            this.colIsAlert.HeaderText = "是否报警检查";
            this.colIsAlert.Name = "colIsAlert";
            this.colIsAlert.ReadOnly = true;
            // 
            // IsCollect
            // 
            this.IsCollect.DataPropertyName = "IsCollect";
            this.IsCollect.HeaderText = "是否开启采集";
            this.IsCollect.Name = "IsCollect";
            this.IsCollect.ReadOnly = true;
            // 
            // IsShow
            // 
            this.IsShow.DataPropertyName = "IsShow";
            this.IsShow.HeaderText = "是否显示";
            this.IsShow.Name = "IsShow";
            this.IsShow.ReadOnly = true;
            // 
            // KeyValues
            // 
            this.KeyValues.DataPropertyName = "KeyValues";
            this.KeyValues.HeaderText = "DI配置";
            this.KeyValues.Name = "KeyValues";
            this.KeyValues.ReadOnly = true;
            // 
            // ParentId
            // 
            this.ParentId.DataPropertyName = "ParentId";
            this.ParentId.HeaderText = "父字段";
            this.ParentId.Name = "ParentId";
            this.ParentId.ReadOnly = true;
            this.ParentId.Visible = false;
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "排序";
            this.OrderId.Name = "OrderId";
            this.OrderId.ReadOnly = true;
            // 
            // FieldType
            // 
            this.FieldType.DataPropertyName = "FieldType";
            this.FieldType.HeaderText = "统计类型";
            this.FieldType.Name = "FieldType";
            this.FieldType.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // UpdateFlag
            // 
            this.UpdateFlag.DataPropertyName = "UpdateFlag";
            this.UpdateFlag.HeaderText = "UpdateFlag";
            this.UpdateFlag.Name = "UpdateFlag";
            this.UpdateFlag.ReadOnly = true;
            this.UpdateFlag.Visible = false;
            // 
            // FrmDtuFieldImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 437);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvField);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGetFilePath);
            this.Controls.Add(this.linkTemplateDown);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnImport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDtuFieldImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字段数据导入";
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetFilePath;
        private System.Windows.Forms.LinkLabel linkTemplateDown;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvField;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFlag;
    }
}