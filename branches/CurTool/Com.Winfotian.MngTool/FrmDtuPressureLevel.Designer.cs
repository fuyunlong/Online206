namespace Com.Winfotian.MngTool
{
    partial class FrmDtuPressureLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDtuPressureLevel));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPressureDesc = new System.Windows.Forms.TextBox();
            this.lblPressureDesc = new System.Windows.Forms.Label();
            this.txtPressureName = new System.Windows.Forms.TextBox();
            this.lblPressureName = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.dgvPressureList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PressureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PressureDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtQPressureName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPressureList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 68;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPressureDesc
            // 
            this.txtPressureDesc.Location = new System.Drawing.Point(71, 276);
            this.txtPressureDesc.Multiline = true;
            this.txtPressureDesc.Name = "txtPressureDesc";
            this.txtPressureDesc.Size = new System.Drawing.Size(295, 48);
            this.txtPressureDesc.TabIndex = 67;
            // 
            // lblPressureDesc
            // 
            this.lblPressureDesc.AutoSize = true;
            this.lblPressureDesc.Location = new System.Drawing.Point(9, 293);
            this.lblPressureDesc.Name = "lblPressureDesc";
            this.lblPressureDesc.Size = new System.Drawing.Size(53, 12);
            this.lblPressureDesc.TabIndex = 66;
            this.lblPressureDesc.Text = "压力描述";
            // 
            // txtPressureName
            // 
            this.txtPressureName.Location = new System.Drawing.Point(71, 241);
            this.txtPressureName.Name = "txtPressureName";
            this.txtPressureName.Size = new System.Drawing.Size(295, 21);
            this.txtPressureName.TabIndex = 65;
            // 
            // lblPressureName
            // 
            this.lblPressureName.AutoSize = true;
            this.lblPressureName.Location = new System.Drawing.Point(9, 245);
            this.lblPressureName.Name = "lblPressureName";
            this.lblPressureName.Size = new System.Drawing.Size(53, 12);
            this.lblPressureName.TabIndex = 64;
            this.lblPressureName.Text = "压力名称";
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(200, 348);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 70;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(109, 348);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 69;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // dgvPressureList
            // 
            this.dgvPressureList.AllowUserToAddRows = false;
            this.dgvPressureList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPressureList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPressureList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPressureList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PressureName,
            this.PressureDesc});
            this.dgvPressureList.Location = new System.Drawing.Point(0, 43);
            this.dgvPressureList.MultiSelect = false;
            this.dgvPressureList.Name = "dgvPressureList";
            this.dgvPressureList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPressureList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPressureList.RowHeadersVisible = false;
            this.dgvPressureList.RowTemplate.Height = 23;
            this.dgvPressureList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPressureList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPressureList.Size = new System.Drawing.Size(380, 182);
            this.dgvPressureList.TabIndex = 71;
            this.dgvPressureList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPressureList_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // PressureName
            // 
            this.PressureName.DataPropertyName = "PressureName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PressureName.DefaultCellStyle = dataGridViewCellStyle2;
            this.PressureName.HeaderText = "配置名称";
            this.PressureName.Name = "PressureName";
            this.PressureName.ReadOnly = true;
            this.PressureName.Width = 125;
            // 
            // PressureDesc
            // 
            this.PressureDesc.DataPropertyName = "PressureDesc";
            this.PressureDesc.HeaderText = "配置描述";
            this.PressureDesc.Name = "PressureDesc";
            this.PressureDesc.ReadOnly = true;
            this.PressureDesc.Width = 250;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(291, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 97;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtQPressureName
            // 
            this.txtQPressureName.Location = new System.Drawing.Point(71, 12);
            this.txtQPressureName.Name = "txtQPressureName";
            this.txtQPressureName.Size = new System.Drawing.Size(242, 21);
            this.txtQPressureName.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 98;
            this.label1.Text = "压力名称";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(319, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(52, 23);
            this.btnQuery.TabIndex = 105;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // FrmDtuPressureLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 379);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtQPressureName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvPressureList);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPressureDesc);
            this.Controls.Add(this.lblPressureDesc);
            this.Controls.Add(this.txtPressureName);
            this.Controls.Add(this.lblPressureName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDtuPressureLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "压力等级";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPressureList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPressureDesc;
        private System.Windows.Forms.Label lblPressureDesc;
        private System.Windows.Forms.TextBox txtPressureName;
        private System.Windows.Forms.Label lblPressureName;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.DataGridView dgvPressureList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtQPressureName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PressureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PressureDesc;
    }
}