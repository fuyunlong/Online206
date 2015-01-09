namespace Com.Winfotian.MngTool
{
    partial class FrmSMSBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSMSBill));
            this.txtMonthMax = new System.Windows.Forms.TextBox();
            this.lblMonthMax = new System.Windows.Forms.Label();
            this.txtDayMax = new System.Windows.Forms.TextBox();
            this.lblDayMax = new System.Windows.Forms.Label();
            this.txtOtherFee = new System.Windows.Forms.TextBox();
            this.lblOtherFee = new System.Windows.Forms.Label();
            this.txtRptFree = new System.Windows.Forms.TextBox();
            this.lblRptFree = new System.Windows.Forms.Label();
            this.dgvBillList = new System.Windows.Forms.DataGridView();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQBillName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.txtBillName = new System.Windows.Forms.TextBox();
            this.lblBillName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBookFee = new System.Windows.Forms.TextBox();
            this.lblGroupFee = new System.Windows.Forms.Label();
            this.txtDataFee = new System.Windows.Forms.TextBox();
            this.lblDataFee = new System.Windows.Forms.Label();
            this.txtAlertFee = new System.Windows.Forms.TextBox();
            this.lblAlertFee = new System.Windows.Forms.Label();
            this.BillCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RptFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtendFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMonthMax
            // 
            this.txtMonthMax.Location = new System.Drawing.Point(364, 339);
            this.txtMonthMax.Name = "txtMonthMax";
            this.txtMonthMax.Size = new System.Drawing.Size(147, 21);
            this.txtMonthMax.TabIndex = 110;
            // 
            // lblMonthMax
            // 
            this.lblMonthMax.AutoSize = true;
            this.lblMonthMax.Location = new System.Drawing.Point(283, 342);
            this.lblMonthMax.Name = "lblMonthMax";
            this.lblMonthMax.Size = new System.Drawing.Size(77, 12);
            this.lblMonthMax.TabIndex = 112;
            this.lblMonthMax.Text = "每月最多(条)";
            // 
            // txtDayMax
            // 
            this.txtDayMax.Location = new System.Drawing.Point(102, 339);
            this.txtDayMax.Name = "txtDayMax";
            this.txtDayMax.Size = new System.Drawing.Size(147, 21);
            this.txtDayMax.TabIndex = 109;
            // 
            // lblDayMax
            // 
            this.lblDayMax.AutoSize = true;
            this.lblDayMax.Location = new System.Drawing.Point(21, 342);
            this.lblDayMax.Name = "lblDayMax";
            this.lblDayMax.Size = new System.Drawing.Size(77, 12);
            this.lblDayMax.TabIndex = 111;
            this.lblDayMax.Text = "每天最多(条)";
            // 
            // txtOtherFee
            // 
            this.txtOtherFee.Location = new System.Drawing.Point(618, 302);
            this.txtOtherFee.Name = "txtOtherFee";
            this.txtOtherFee.Size = new System.Drawing.Size(147, 21);
            this.txtOtherFee.TabIndex = 106;
            // 
            // lblOtherFee
            // 
            this.lblOtherFee.AutoSize = true;
            this.lblOtherFee.Location = new System.Drawing.Point(519, 305);
            this.lblOtherFee.Name = "lblOtherFee";
            this.lblOtherFee.Size = new System.Drawing.Size(95, 12);
            this.lblOtherFee.TabIndex = 108;
            this.lblOtherFee.Text = "其他费用(元/条)";
            // 
            // txtRptFree
            // 
            this.txtRptFree.Location = new System.Drawing.Point(364, 303);
            this.txtRptFree.Name = "txtRptFree";
            this.txtRptFree.Size = new System.Drawing.Size(147, 21);
            this.txtRptFree.TabIndex = 105;
            // 
            // lblRptFree
            // 
            this.lblRptFree.AutoSize = true;
            this.lblRptFree.Location = new System.Drawing.Point(265, 306);
            this.lblRptFree.Name = "lblRptFree";
            this.lblRptFree.Size = new System.Drawing.Size(95, 12);
            this.lblRptFree.TabIndex = 107;
            this.lblRptFree.Text = "报表短信(元/条)";
            // 
            // dgvBillList
            // 
            this.dgvBillList.AllowUserToAddRows = false;
            this.dgvBillList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBillList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBillList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillCode,
            this.BillName,
            this.AlertFee,
            this.DataFee,
            this.BookFee,
            this.RptFee,
            this.OtherFee,
            this.DayMax,
            this.MonthMax,
            this.ExtendFee,
            this.Status,
            this.UpdateFlag});
            this.dgvBillList.Location = new System.Drawing.Point(1, 36);
            this.dgvBillList.MultiSelect = false;
            this.dgvBillList.Name = "dgvBillList";
            this.dgvBillList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBillList.RowHeadersVisible = false;
            this.dgvBillList.RowTemplate.Height = 23;
            this.dgvBillList.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvBillList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillList.Size = new System.Drawing.Size(775, 221);
            this.dgvBillList.TabIndex = 67;
            this.dgvBillList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillList_CellDoubleClick);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(713, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(52, 23);
            this.btnQuery.TabIndex = 104;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQBillName
            // 
            this.txtQBillName.Location = new System.Drawing.Point(62, 8);
            this.txtQBillName.Name = "txtQBillName";
            this.txtQBillName.Size = new System.Drawing.Size(635, 21);
            this.txtQBillName.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 103;
            this.label1.Text = "计费名称";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(494, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 101;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(392, 389);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 66;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(290, 389);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 65;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // txtBillName
            // 
            this.txtBillName.Location = new System.Drawing.Point(102, 269);
            this.txtBillName.Name = "txtBillName";
            this.txtBillName.Size = new System.Drawing.Size(147, 21);
            this.txtBillName.TabIndex = 1;
            // 
            // lblBillName
            // 
            this.lblBillName.AutoSize = true;
            this.lblBillName.Location = new System.Drawing.Point(45, 273);
            this.lblBillName.Name = "lblBillName";
            this.lblBillName.Size = new System.Drawing.Size(53, 12);
            this.lblBillName.TabIndex = 48;
            this.lblBillName.Text = "计费名称";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(188, 389);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBookFee
            // 
            this.txtBookFee.Location = new System.Drawing.Point(102, 302);
            this.txtBookFee.Name = "txtBookFee";
            this.txtBookFee.Size = new System.Drawing.Size(147, 21);
            this.txtBookFee.TabIndex = 4;
            // 
            // lblGroupFee
            // 
            this.lblGroupFee.AutoSize = true;
            this.lblGroupFee.Location = new System.Drawing.Point(3, 306);
            this.lblGroupFee.Name = "lblGroupFee";
            this.lblGroupFee.Size = new System.Drawing.Size(95, 12);
            this.lblGroupFee.TabIndex = 45;
            this.lblGroupFee.Text = "定时短信(元/条)";
            // 
            // txtDataFee
            // 
            this.txtDataFee.Location = new System.Drawing.Point(618, 269);
            this.txtDataFee.Name = "txtDataFee";
            this.txtDataFee.Size = new System.Drawing.Size(147, 21);
            this.txtDataFee.TabIndex = 3;
            // 
            // lblDataFee
            // 
            this.lblDataFee.AutoSize = true;
            this.lblDataFee.Location = new System.Drawing.Point(519, 273);
            this.lblDataFee.Name = "lblDataFee";
            this.lblDataFee.Size = new System.Drawing.Size(95, 12);
            this.lblDataFee.TabIndex = 43;
            this.lblDataFee.Text = "数据查询(元/条)";
            // 
            // txtAlertFee
            // 
            this.txtAlertFee.Location = new System.Drawing.Point(364, 269);
            this.txtAlertFee.Name = "txtAlertFee";
            this.txtAlertFee.Size = new System.Drawing.Size(147, 21);
            this.txtAlertFee.TabIndex = 2;
            // 
            // lblAlertFee
            // 
            this.lblAlertFee.AutoSize = true;
            this.lblAlertFee.Location = new System.Drawing.Point(263, 273);
            this.lblAlertFee.Name = "lblAlertFee";
            this.lblAlertFee.Size = new System.Drawing.Size(95, 12);
            this.lblAlertFee.TabIndex = 41;
            this.lblAlertFee.Text = "报警短信(元/条)";
            // 
            // BillCode
            // 
            this.BillCode.DataPropertyName = "BillCode";
            this.BillCode.FillWeight = 110F;
            this.BillCode.HeaderText = "BillCode";
            this.BillCode.Name = "BillCode";
            this.BillCode.ReadOnly = true;
            this.BillCode.Visible = false;
            // 
            // BillName
            // 
            this.BillName.DataPropertyName = "BillName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BillName.DefaultCellStyle = dataGridViewCellStyle2;
            this.BillName.HeaderText = "计费名称";
            this.BillName.Name = "BillName";
            this.BillName.ReadOnly = true;
            this.BillName.Width = 195;
            // 
            // AlertFee
            // 
            this.AlertFee.DataPropertyName = "AlertFee";
            this.AlertFee.HeaderText = "报警费用(元/条)";
            this.AlertFee.Name = "AlertFee";
            this.AlertFee.ReadOnly = true;
            this.AlertFee.Width = 110;
            // 
            // DataFee
            // 
            this.DataFee.DataPropertyName = "DataFee";
            this.DataFee.HeaderText = "数据查询(元/条)";
            this.DataFee.Name = "DataFee";
            this.DataFee.ReadOnly = true;
            this.DataFee.Width = 110;
            // 
            // BookFee
            // 
            this.BookFee.DataPropertyName = "BookFee";
            this.BookFee.HeaderText = "定时短信(元/条)";
            this.BookFee.Name = "BookFee";
            this.BookFee.ReadOnly = true;
            this.BookFee.Width = 110;
            // 
            // RptFee
            // 
            this.RptFee.DataPropertyName = "RptFee";
            this.RptFee.FillWeight = 110F;
            this.RptFee.HeaderText = "报表短信(元/条)";
            this.RptFee.Name = "RptFee";
            this.RptFee.ReadOnly = true;
            this.RptFee.Width = 110;
            // 
            // OtherFee
            // 
            this.OtherFee.DataPropertyName = "OtherFee";
            this.OtherFee.HeaderText = "其他费用(元/条)";
            this.OtherFee.Name = "OtherFee";
            this.OtherFee.ReadOnly = true;
            this.OtherFee.Width = 110;
            // 
            // DayMax
            // 
            this.DayMax.DataPropertyName = "DayMax";
            this.DayMax.HeaderText = "每天最多(条)";
            this.DayMax.Name = "DayMax";
            this.DayMax.ReadOnly = true;
            this.DayMax.Width = 110;
            // 
            // MonthMax
            // 
            this.MonthMax.DataPropertyName = "MonthMax";
            this.MonthMax.HeaderText = "每月最多(条)";
            this.MonthMax.Name = "MonthMax";
            this.MonthMax.ReadOnly = true;
            this.MonthMax.Width = 110;
            // 
            // ExtendFee
            // 
            this.ExtendFee.DataPropertyName = "ExtendFee";
            this.ExtendFee.HeaderText = "ExtendFee";
            this.ExtendFee.Name = "ExtendFee";
            this.ExtendFee.ReadOnly = true;
            this.ExtendFee.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            // 
            // UpdateFlag
            // 
            this.UpdateFlag.DataPropertyName = "UpdateFlag";
            this.UpdateFlag.HeaderText = "UpdateFlag";
            this.UpdateFlag.Name = "UpdateFlag";
            this.UpdateFlag.ReadOnly = true;
            this.UpdateFlag.Visible = false;
            // 
            // FrmSMSBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 423);
            this.Controls.Add(this.txtMonthMax);
            this.Controls.Add(this.lblMonthMax);
            this.Controls.Add(this.txtDayMax);
            this.Controls.Add(this.lblDayMax);
            this.Controls.Add(this.txtOtherFee);
            this.Controls.Add(this.lblOtherFee);
            this.Controls.Add(this.txtRptFree);
            this.Controls.Add(this.lblRptFree);
            this.Controls.Add(this.dgvBillList);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtQBillName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.txtBillName);
            this.Controls.Add(this.lblBillName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBookFee);
            this.Controls.Add(this.lblGroupFee);
            this.Controls.Add(this.txtDataFee);
            this.Controls.Add(this.lblDataFee);
            this.Controls.Add(this.txtAlertFee);
            this.Controls.Add(this.lblAlertFee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSMSBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "短信计费";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAlertFee;
        private System.Windows.Forms.Label lblAlertFee;
        private System.Windows.Forms.TextBox txtDataFee;
        private System.Windows.Forms.Label lblDataFee;
        private System.Windows.Forms.TextBox txtBookFee;
        private System.Windows.Forms.Label lblGroupFee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBillName;
        private System.Windows.Forms.Label lblBillName;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.DataGridView dgvBillList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtQBillName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtOtherFee;
        private System.Windows.Forms.Label lblOtherFee;
        private System.Windows.Forms.TextBox txtRptFree;
        private System.Windows.Forms.Label lblRptFree;
        private System.Windows.Forms.TextBox txtMonthMax;
        private System.Windows.Forms.Label lblMonthMax;
        private System.Windows.Forms.TextBox txtDayMax;
        private System.Windows.Forms.Label lblDayMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn RptFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtendFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFlag;
    }
}