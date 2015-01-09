namespace Com.Winfotian.MngTool
{
    partial class FrmTransmit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbx1 = new System.Windows.Forms.GroupBox();
            this.dgvDtuList = new System.Windows.Forms.DataGridView();
            this.Dtuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtuidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTargetId = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdo_TCP = new System.Windows.Forms.RadioButton();
            this.rdo_UDP = new System.Windows.Forms.RadioButton();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TargetPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_OrderNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Memo = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnIsTransmitTrue = new System.Windows.Forms.RadioButton();
            this.rbtnIsTransmitFalse = new System.Windows.Forms.RadioButton();
            this.lblIsCollect = new System.Windows.Forms.Label();
            this.cbxDtu = new System.Windows.Forms.ComboBox();
            this.lblQDtuName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtuList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetId)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_OrderNum)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx1
            // 
            this.gbx1.Controls.Add(this.dgvDtuList);
            this.gbx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx1.Location = new System.Drawing.Point(0, 81);
            this.gbx1.Name = "gbx1";
            this.gbx1.Size = new System.Drawing.Size(484, 342);
            this.gbx1.TabIndex = 129;
            this.gbx1.TabStop = false;
            this.gbx1.Text = "已配置站点";
            // 
            // dgvDtuList
            // 
            this.dgvDtuList.AllowUserToAddRows = false;
            this.dgvDtuList.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDtuList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDtuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDtuList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dtuid,
            this.DtuidName,
            this.TransDesc,
            this.Id});
            this.dgvDtuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDtuList.Location = new System.Drawing.Point(3, 17);
            this.dgvDtuList.MultiSelect = false;
            this.dgvDtuList.Name = "dgvDtuList";
            this.dgvDtuList.ReadOnly = true;
            this.dgvDtuList.RowHeadersVisible = false;
            this.dgvDtuList.RowTemplate.Height = 23;
            this.dgvDtuList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDtuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDtuList.Size = new System.Drawing.Size(478, 322);
            this.dgvDtuList.TabIndex = 1;
            this.dgvDtuList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDtuList_CellDoubleClick);
            // 
            // Dtuid
            // 
            this.Dtuid.DataPropertyName = "Dtuid";
            this.Dtuid.HeaderText = "编号";
            this.Dtuid.Name = "Dtuid";
            this.Dtuid.ReadOnly = true;
            // 
            // DtuidName
            // 
            this.DtuidName.DataPropertyName = "DtuidName";
            this.DtuidName.HeaderText = "站点名称";
            this.DtuidName.Name = "DtuidName";
            this.DtuidName.ReadOnly = true;
            this.DtuidName.Width = 120;
            // 
            // TransDesc
            // 
            this.TransDesc.DataPropertyName = "TransDesc";
            this.TransDesc.HeaderText = "转发说明";
            this.TransDesc.Name = "TransDesc";
            this.TransDesc.ReadOnly = true;
            this.TransDesc.Width = 240;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTargetId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.txt_Desc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_TargetPhone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_OrderNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_Memo);
            this.groupBox1.Controls.Add(this.txtVersion);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnMod);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.lblIP);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.lblIsCollect);
            this.groupBox1.Controls.Add(this.cbxDtu);
            this.groupBox1.Controls.Add(this.lblQDtuName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(484, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 342);
            this.groupBox1.TabIndex = 130;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置站点";
            // 
            // txtTargetId
            // 
            this.txtTargetId.Location = new System.Drawing.Point(87, 188);
            this.txtTargetId.Name = "txtTargetId";
            this.txtTargetId.Size = new System.Drawing.Size(84, 21);
            this.txtTargetId.TabIndex = 152;
            this.txtTargetId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 151;
            this.label6.Text = "设备ID：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdo_TCP);
            this.panel2.Controls.Add(this.rdo_UDP);
            this.panel2.Location = new System.Drawing.Point(80, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 23);
            this.panel2.TabIndex = 134;
            // 
            // rdo_TCP
            // 
            this.rdo_TCP.AutoSize = true;
            this.rdo_TCP.Checked = true;
            this.rdo_TCP.Location = new System.Drawing.Point(3, 3);
            this.rdo_TCP.Name = "rdo_TCP";
            this.rdo_TCP.Size = new System.Drawing.Size(41, 16);
            this.rdo_TCP.TabIndex = 68;
            this.rdo_TCP.TabStop = true;
            this.rdo_TCP.Text = "TCP";
            this.rdo_TCP.UseVisualStyleBackColor = true;
            // 
            // rdo_UDP
            // 
            this.rdo_UDP.AutoSize = true;
            this.rdo_UDP.Location = new System.Drawing.Point(47, 3);
            this.rdo_UDP.Name = "rdo_UDP";
            this.rdo_UDP.Size = new System.Drawing.Size(41, 16);
            this.rdo_UDP.TabIndex = 67;
            this.rdo_UDP.Text = "UDP";
            this.rdo_UDP.UseVisualStyleBackColor = true;
            // 
            // txt_Desc
            // 
            this.txt_Desc.Location = new System.Drawing.Point(88, 271);
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(211, 21);
            this.txt_Desc.TabIndex = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 133;
            this.label5.Text = "通信：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 149;
            this.label4.Text = "转发描述：";
            // 
            // txt_TargetPhone
            // 
            this.txt_TargetPhone.Location = new System.Drawing.Point(87, 160);
            this.txt_TargetPhone.Name = "txt_TargetPhone";
            this.txt_TargetPhone.Size = new System.Drawing.Size(211, 21);
            this.txt_TargetPhone.TabIndex = 148;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 147;
            this.label3.Text = "目标手机号：";
            // 
            // txt_OrderNum
            // 
            this.txt_OrderNum.Location = new System.Drawing.Point(88, 215);
            this.txt_OrderNum.Name = "txt_OrderNum";
            this.txt_OrderNum.Size = new System.Drawing.Size(84, 21);
            this.txt_OrderNum.TabIndex = 146;
            this.txt_OrderNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 145;
            this.label2.Text = "序号：";
            // 
            // lb_Memo
            // 
            this.lb_Memo.AutoSize = true;
            this.lb_Memo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_Memo.Location = new System.Drawing.Point(85, 68);
            this.lb_Memo.MaximumSize = new System.Drawing.Size(220, 50);
            this.lb_Memo.Name = "lb_Memo";
            this.lb_Memo.Size = new System.Drawing.Size(59, 12);
            this.lb_Memo.TabIndex = 144;
            this.lb_Memo.Text = "转发为OPC";
            // 
            // txtVersion
            // 
            this.txtVersion.FormattingEnabled = true;
            this.txtVersion.Items.AddRange(new object[] {
            "AA66",
            "AA67",
            "AA68",
            "AA88",
            "AA89"});
            this.txtVersion.Location = new System.Drawing.Point(87, 46);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(211, 20);
            this.txtVersion.TabIndex = 143;
            this.txtVersion.SelectedIndexChanged += new System.EventHandler(this.txtVersion_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(221, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(158, 306);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(61, 23);
            this.btnDel.TabIndex = 141;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(91, 306);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(61, 23);
            this.btnMod.TabIndex = 140;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 306);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 23);
            this.btnAdd.TabIndex = 139;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(87, 133);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(211, 21);
            this.txtPort.TabIndex = 137;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(87, 106);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(211, 21);
            this.txtIP.TabIndex = 136;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(31, 110);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(53, 12);
            this.lblIP.TabIndex = 135;
            this.lblIP.Text = "IP地址：";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(31, 137);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(53, 12);
            this.lblPort.TabIndex = 134;
            this.lblPort.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 133;
            this.label1.Text = "版本：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnIsTransmitTrue);
            this.panel1.Controls.Add(this.rbtnIsTransmitFalse);
            this.panel1.Location = new System.Drawing.Point(206, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 23);
            this.panel1.TabIndex = 132;
            // 
            // rbtnIsTransmitTrue
            // 
            this.rbtnIsTransmitTrue.AutoSize = true;
            this.rbtnIsTransmitTrue.Checked = true;
            this.rbtnIsTransmitTrue.Location = new System.Drawing.Point(3, 3);
            this.rbtnIsTransmitTrue.Name = "rbtnIsTransmitTrue";
            this.rbtnIsTransmitTrue.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsTransmitTrue.TabIndex = 68;
            this.rbtnIsTransmitTrue.TabStop = true;
            this.rbtnIsTransmitTrue.Text = "是";
            this.rbtnIsTransmitTrue.UseVisualStyleBackColor = true;
            // 
            // rbtnIsTransmitFalse
            // 
            this.rbtnIsTransmitFalse.AutoSize = true;
            this.rbtnIsTransmitFalse.Location = new System.Drawing.Point(47, 3);
            this.rbtnIsTransmitFalse.Name = "rbtnIsTransmitFalse";
            this.rbtnIsTransmitFalse.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsTransmitFalse.TabIndex = 67;
            this.rbtnIsTransmitFalse.Text = "否";
            this.rbtnIsTransmitFalse.UseVisualStyleBackColor = true;
            // 
            // lblIsCollect
            // 
            this.lblIsCollect.AutoSize = true;
            this.lblIsCollect.Location = new System.Drawing.Point(174, 247);
            this.lblIsCollect.Name = "lblIsCollect";
            this.lblIsCollect.Size = new System.Drawing.Size(41, 12);
            this.lblIsCollect.TabIndex = 131;
            this.lblIsCollect.Text = "开启：";
            // 
            // cbxDtu
            // 
            this.cbxDtu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDtu.FormattingEnabled = true;
            this.cbxDtu.Location = new System.Drawing.Point(87, 20);
            this.cbxDtu.Name = "cbxDtu";
            this.cbxDtu.Size = new System.Drawing.Size(211, 20);
            this.cbxDtu.TabIndex = 130;
            // 
            // lblQDtuName
            // 
            this.lblQDtuName.AutoSize = true;
            this.lblQDtuName.Location = new System.Drawing.Point(43, 24);
            this.lblQDtuName.Name = "lblQDtuName";
            this.lblQDtuName.Size = new System.Drawing.Size(41, 12);
            this.lblQDtuName.TabIndex = 129;
            this.lblQDtuName.Text = "站点：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 81);
            this.groupBox2.TabIndex = 131;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作说明";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(31, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(455, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "1、如果为压力记录仪，请注意填写设备ID和序号；\r\n2、非开发人员，请勿自行填写【版本】编号，尽量下拉选择（会有版本描述说明）；\r\n3、转发描述可参照版本描述说明" +
                "填写；";
            // 
            // FrmTransmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 423);
            this.Controls.Add(this.gbx1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransmit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "数据传输配置";
            this.gbx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtuList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetId)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_OrderNum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnIsTransmitTrue;
        private System.Windows.Forms.RadioButton rbtnIsTransmitFalse;
        private System.Windows.Forms.Label lblIsCollect;
        private System.Windows.Forms.ComboBox cbxDtu;
        private System.Windows.Forms.Label lblQDtuName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvDtuList;
        private System.Windows.Forms.ComboBox txtVersion;
        private System.Windows.Forms.Label lb_Memo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txt_OrderNum;
        private System.Windows.Forms.TextBox txt_TargetPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdo_TCP;
        private System.Windows.Forms.RadioButton rdo_UDP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtTargetId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dtuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtuidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
    }
}