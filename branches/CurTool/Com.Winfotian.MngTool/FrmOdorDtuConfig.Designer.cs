namespace Com.Winfotian.MngTool
{
    partial class FrmOdorDtuConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOdorDtuConfig));
            this.lblIsCreate = new System.Windows.Forms.Label();
            this.lblIsAlert = new System.Windows.Forms.Label();
            this.txtConfigDesc = new System.Windows.Forms.TextBox();
            this.lblConfigDesc = new System.Windows.Forms.Label();
            this.txtConfigName = new System.Windows.Forms.TextBox();
            this.lblConfigName = new System.Windows.Forms.Label();
            this.numUDFlowNum = new System.Windows.Forms.NumericUpDown();
            this.lblFlowNum = new System.Windows.Forms.Label();
            this.numUDAINum = new System.Windows.Forms.NumericUpDown();
            this.lblAINum = new System.Windows.Forms.Label();
            this.numUDDINum = new System.Windows.Forms.NumericUpDown();
            this.lblDINum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtIsAlertFalse = new System.Windows.Forms.RadioButton();
            this.rbtIsAlertTrue = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnIsCreateTrue = new System.Windows.Forms.RadioButton();
            this.rbtnIsCreateFalse = new System.Windows.Forms.RadioButton();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvDtuConfigList = new System.Windows.Forms.DataGridView();
            this.ConfigName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DINum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AINum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lblBoardNum = new System.Windows.Forms.Label();
            this.cbxBoardNum = new System.Windows.Forms.ComboBox();
            this.gBoard1 = new System.Windows.Forms.GroupBox();
            this.nudB1JztNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoard2 = new System.Windows.Forms.GroupBox();
            this.nudB2JztNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.gBoard4 = new System.Windows.Forms.GroupBox();
            this.nudB4JztNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.gBoard3 = new System.Windows.Forms.GroupBox();
            this.nudB3JztNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUDFlowNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDAINum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDDINum)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtuConfigList)).BeginInit();
            this.gBoard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB1JztNum)).BeginInit();
            this.gBoard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB2JztNum)).BeginInit();
            this.gBoard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB4JztNum)).BeginInit();
            this.gBoard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB3JztNum)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIsCreate
            // 
            this.lblIsCreate.AutoSize = true;
            this.lblIsCreate.Location = new System.Drawing.Point(161, 348);
            this.lblIsCreate.Name = "lblIsCreate";
            this.lblIsCreate.Size = new System.Drawing.Size(65, 12);
            this.lblIsCreate.TabIndex = 74;
            this.lblIsCreate.Text = "是否已创建";
            // 
            // lblIsAlert
            // 
            this.lblIsAlert.AutoSize = true;
            this.lblIsAlert.Location = new System.Drawing.Point(16, 348);
            this.lblIsAlert.Name = "lblIsAlert";
            this.lblIsAlert.Size = new System.Drawing.Size(53, 12);
            this.lblIsAlert.TabIndex = 71;
            this.lblIsAlert.Text = "报警通知";
            // 
            // txtConfigDesc
            // 
            this.txtConfigDesc.Location = new System.Drawing.Point(72, 269);
            this.txtConfigDesc.Multiline = true;
            this.txtConfigDesc.Name = "txtConfigDesc";
            this.txtConfigDesc.ReadOnly = true;
            this.txtConfigDesc.Size = new System.Drawing.Size(398, 35);
            this.txtConfigDesc.TabIndex = 66;
            this.txtConfigDesc.Text = "XX个流量计XX个模拟量XX个开关量";
            // 
            // lblConfigDesc
            // 
            this.lblConfigDesc.AutoSize = true;
            this.lblConfigDesc.Location = new System.Drawing.Point(16, 281);
            this.lblConfigDesc.Name = "lblConfigDesc";
            this.lblConfigDesc.Size = new System.Drawing.Size(53, 12);
            this.lblConfigDesc.TabIndex = 65;
            this.lblConfigDesc.Text = "配置描述";
            // 
            // txtConfigName
            // 
            this.txtConfigName.Enabled = false;
            this.txtConfigName.Location = new System.Drawing.Point(73, 236);
            this.txtConfigName.Name = "txtConfigName";
            this.txtConfigName.ReadOnly = true;
            this.txtConfigName.Size = new System.Drawing.Size(397, 21);
            this.txtConfigName.TabIndex = 64;
            this.txtConfigName.Text = "XX流XX模XX开";
            // 
            // lblConfigName
            // 
            this.lblConfigName.AutoSize = true;
            this.lblConfigName.Location = new System.Drawing.Point(16, 239);
            this.lblConfigName.Name = "lblConfigName";
            this.lblConfigName.Size = new System.Drawing.Size(53, 12);
            this.lblConfigName.TabIndex = 63;
            this.lblConfigName.Text = "配置名称";
            // 
            // numUDFlowNum
            // 
            this.numUDFlowNum.Location = new System.Drawing.Point(72, 311);
            this.numUDFlowNum.Name = "numUDFlowNum";
            this.numUDFlowNum.ReadOnly = true;
            this.numUDFlowNum.Size = new System.Drawing.Size(83, 21);
            this.numUDFlowNum.TabIndex = 80;
            this.numUDFlowNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUDFlowNum.ValueChanged += new System.EventHandler(this.numUDFlowNum_ValueChanged);
            // 
            // lblFlowNum
            // 
            this.lblFlowNum.AutoSize = true;
            this.lblFlowNum.Location = new System.Drawing.Point(4, 315);
            this.lblFlowNum.Name = "lblFlowNum";
            this.lblFlowNum.Size = new System.Drawing.Size(65, 12);
            this.lblFlowNum.TabIndex = 79;
            this.lblFlowNum.Text = "流量计个数";
            // 
            // numUDAINum
            // 
            this.numUDAINum.Location = new System.Drawing.Point(229, 311);
            this.numUDAINum.Name = "numUDAINum";
            this.numUDAINum.ReadOnly = true;
            this.numUDAINum.Size = new System.Drawing.Size(83, 21);
            this.numUDAINum.TabIndex = 82;
            this.numUDAINum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUDAINum.ValueChanged += new System.EventHandler(this.numUDAINum_ValueChanged);
            // 
            // lblAINum
            // 
            this.lblAINum.AutoSize = true;
            this.lblAINum.Location = new System.Drawing.Point(161, 315);
            this.lblAINum.Name = "lblAINum";
            this.lblAINum.Size = new System.Drawing.Size(65, 12);
            this.lblAINum.TabIndex = 81;
            this.lblAINum.Text = "模拟量个数";
            // 
            // numUDDINum
            // 
            this.numUDDINum.Location = new System.Drawing.Point(387, 311);
            this.numUDDINum.Name = "numUDDINum";
            this.numUDDINum.ReadOnly = true;
            this.numUDDINum.Size = new System.Drawing.Size(83, 21);
            this.numUDDINum.TabIndex = 84;
            this.numUDDINum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUDDINum.ValueChanged += new System.EventHandler(this.numUDDINum_ValueChanged);
            // 
            // lblDINum
            // 
            this.lblDINum.AutoSize = true;
            this.lblDINum.Location = new System.Drawing.Point(319, 315);
            this.lblDINum.Name = "lblDINum";
            this.lblDINum.Size = new System.Drawing.Size(65, 12);
            this.lblDINum.TabIndex = 83;
            this.lblDINum.Text = "开关量个数";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtIsAlertFalse);
            this.panel1.Controls.Add(this.rbtIsAlertTrue);
            this.panel1.Location = new System.Drawing.Point(72, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 23);
            this.panel1.TabIndex = 85;
            // 
            // rbtIsAlertFalse
            // 
            this.rbtIsAlertFalse.AutoSize = true;
            this.rbtIsAlertFalse.Location = new System.Drawing.Point(41, 3);
            this.rbtIsAlertFalse.Name = "rbtIsAlertFalse";
            this.rbtIsAlertFalse.Size = new System.Drawing.Size(35, 16);
            this.rbtIsAlertFalse.TabIndex = 71;
            this.rbtIsAlertFalse.TabStop = true;
            this.rbtIsAlertFalse.Text = "否";
            this.rbtIsAlertFalse.UseVisualStyleBackColor = true;
            // 
            // rbtIsAlertTrue
            // 
            this.rbtIsAlertTrue.AutoSize = true;
            this.rbtIsAlertTrue.Checked = true;
            this.rbtIsAlertTrue.Location = new System.Drawing.Point(2, 3);
            this.rbtIsAlertTrue.Name = "rbtIsAlertTrue";
            this.rbtIsAlertTrue.Size = new System.Drawing.Size(35, 16);
            this.rbtIsAlertTrue.TabIndex = 72;
            this.rbtIsAlertTrue.TabStop = true;
            this.rbtIsAlertTrue.Text = "是";
            this.rbtIsAlertTrue.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnIsCreateTrue);
            this.panel2.Controls.Add(this.rbtnIsCreateFalse);
            this.panel2.Location = new System.Drawing.Point(229, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(83, 23);
            this.panel2.TabIndex = 86;
            // 
            // rbtnIsCreateTrue
            // 
            this.rbtnIsCreateTrue.AutoSize = true;
            this.rbtnIsCreateTrue.Checked = true;
            this.rbtnIsCreateTrue.Location = new System.Drawing.Point(3, 3);
            this.rbtnIsCreateTrue.Name = "rbtnIsCreateTrue";
            this.rbtnIsCreateTrue.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsCreateTrue.TabIndex = 75;
            this.rbtnIsCreateTrue.TabStop = true;
            this.rbtnIsCreateTrue.Text = "是";
            this.rbtnIsCreateTrue.UseVisualStyleBackColor = true;
            // 
            // rbtnIsCreateFalse
            // 
            this.rbtnIsCreateFalse.AutoSize = true;
            this.rbtnIsCreateFalse.Location = new System.Drawing.Point(44, 3);
            this.rbtnIsCreateFalse.Name = "rbtnIsCreateFalse";
            this.rbtnIsCreateFalse.Size = new System.Drawing.Size(35, 16);
            this.rbtnIsCreateFalse.TabIndex = 74;
            this.rbtnIsCreateFalse.TabStop = true;
            this.rbtnIsCreateFalse.Text = "否";
            this.rbtnIsCreateFalse.UseVisualStyleBackColor = true;
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(149, 431);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 88;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(40, 431);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 87;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDtuConfigList
            // 
            this.dgvDtuConfigList.AllowUserToAddRows = false;
            this.dgvDtuConfigList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDtuConfigList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDtuConfigList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDtuConfigList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigName,
            this.ConfigDesc,
            this.ConfigCode,
            this.IsCreate,
            this.IsAlert,
            this.DINum,
            this.FlowNum,
            this.AINum,
            this.UpdateFlag,
            this.BoardInfo});
            this.dgvDtuConfigList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDtuConfigList.Location = new System.Drawing.Point(0, 0);
            this.dgvDtuConfigList.MultiSelect = false;
            this.dgvDtuConfigList.Name = "dgvDtuConfigList";
            this.dgvDtuConfigList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDtuConfigList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDtuConfigList.RowHeadersVisible = false;
            this.dgvDtuConfigList.RowTemplate.Height = 23;
            this.dgvDtuConfigList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDtuConfigList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDtuConfigList.Size = new System.Drawing.Size(490, 222);
            this.dgvDtuConfigList.TabIndex = 90;
            this.dgvDtuConfigList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDtuConfigList_CellDoubleClick);
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
            // ConfigCode
            // 
            this.ConfigCode.DataPropertyName = "ConfigCode";
            this.ConfigCode.HeaderText = "ConfigCode";
            this.ConfigCode.Name = "ConfigCode";
            this.ConfigCode.ReadOnly = true;
            this.ConfigCode.Visible = false;
            // 
            // IsCreate
            // 
            this.IsCreate.DataPropertyName = "IsCreate";
            this.IsCreate.HeaderText = "IsCreate";
            this.IsCreate.Name = "IsCreate";
            this.IsCreate.ReadOnly = true;
            this.IsCreate.Visible = false;
            // 
            // IsAlert
            // 
            this.IsAlert.DataPropertyName = "IsAlert";
            this.IsAlert.HeaderText = "IsAlert";
            this.IsAlert.Name = "IsAlert";
            this.IsAlert.ReadOnly = true;
            this.IsAlert.Visible = false;
            // 
            // DINum
            // 
            this.DINum.DataPropertyName = "DINum";
            this.DINum.HeaderText = "DINum";
            this.DINum.Name = "DINum";
            this.DINum.ReadOnly = true;
            this.DINum.Visible = false;
            // 
            // FlowNum
            // 
            this.FlowNum.DataPropertyName = "FlowNum";
            this.FlowNum.HeaderText = "FlowNum";
            this.FlowNum.Name = "FlowNum";
            this.FlowNum.ReadOnly = true;
            this.FlowNum.Visible = false;
            // 
            // AINum
            // 
            this.AINum.DataPropertyName = "AINum";
            this.AINum.HeaderText = "AINum";
            this.AINum.Name = "AINum";
            this.AINum.ReadOnly = true;
            this.AINum.Visible = false;
            // 
            // UpdateFlag
            // 
            this.UpdateFlag.DataPropertyName = "UpdateFlag";
            this.UpdateFlag.HeaderText = "UpdateFlag";
            this.UpdateFlag.Name = "UpdateFlag";
            this.UpdateFlag.ReadOnly = true;
            this.UpdateFlag.Visible = false;
            // 
            // BoardInfo
            // 
            this.BoardInfo.DataPropertyName = "BoardInfo";
            this.BoardInfo.HeaderText = "BoardInfo";
            this.BoardInfo.Name = "BoardInfo";
            this.BoardInfo.ReadOnly = true;
            this.BoardInfo.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(367, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 100;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(258, 431);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 89;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblBoardNum
            // 
            this.lblBoardNum.AutoSize = true;
            this.lblBoardNum.Location = new System.Drawing.Point(331, 348);
            this.lblBoardNum.Name = "lblBoardNum";
            this.lblBoardNum.Size = new System.Drawing.Size(53, 12);
            this.lblBoardNum.TabIndex = 101;
            this.lblBoardNum.Text = "面板个数";
            // 
            // cbxBoardNum
            // 
            this.cbxBoardNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBoardNum.FormattingEnabled = true;
            this.cbxBoardNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbxBoardNum.Location = new System.Drawing.Point(387, 344);
            this.cbxBoardNum.Name = "cbxBoardNum";
            this.cbxBoardNum.Size = new System.Drawing.Size(83, 20);
            this.cbxBoardNum.TabIndex = 102;
            this.cbxBoardNum.SelectedIndexChanged += new System.EventHandler(this.cbxBoardNum_SelectedIndexChanged);
            // 
            // gBoard1
            // 
            this.gBoard1.Controls.Add(this.nudB1JztNum);
            this.gBoard1.Controls.Add(this.label2);
            this.gBoard1.Location = new System.Drawing.Point(11, 375);
            this.gBoard1.Name = "gBoard1";
            this.gBoard1.Size = new System.Drawing.Size(113, 39);
            this.gBoard1.TabIndex = 103;
            this.gBoard1.TabStop = false;
            this.gBoard1.Text = "面板1";
            // 
            // nudB1JztNum
            // 
            this.nudB1JztNum.Location = new System.Drawing.Point(62, 13);
            this.nudB1JztNum.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudB1JztNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB1JztNum.Name = "nudB1JztNum";
            this.nudB1JztNum.ReadOnly = true;
            this.nudB1JztNum.Size = new System.Drawing.Size(46, 21);
            this.nudB1JztNum.TabIndex = 105;
            this.nudB1JztNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB1JztNum.ValueChanged += new System.EventHandler(this.nudB1JztNum_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 104;
            this.label2.Text = "加注头数";
            // 
            // gBoard2
            // 
            this.gBoard2.Controls.Add(this.nudB2JztNum);
            this.gBoard2.Controls.Add(this.label3);
            this.gBoard2.Location = new System.Drawing.Point(128, 375);
            this.gBoard2.Name = "gBoard2";
            this.gBoard2.Size = new System.Drawing.Size(113, 39);
            this.gBoard2.TabIndex = 104;
            this.gBoard2.TabStop = false;
            this.gBoard2.Text = "面板2";
            this.gBoard2.Visible = false;
            // 
            // nudB2JztNum
            // 
            this.nudB2JztNum.Location = new System.Drawing.Point(63, 13);
            this.nudB2JztNum.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudB2JztNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB2JztNum.Name = "nudB2JztNum";
            this.nudB2JztNum.ReadOnly = true;
            this.nudB2JztNum.Size = new System.Drawing.Size(46, 21);
            this.nudB2JztNum.TabIndex = 105;
            this.nudB2JztNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB2JztNum.ValueChanged += new System.EventHandler(this.nudB2JztNum_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 104;
            this.label3.Text = "加注头数";
            // 
            // gBoard4
            // 
            this.gBoard4.Controls.Add(this.nudB4JztNum);
            this.gBoard4.Controls.Add(this.label5);
            this.gBoard4.Location = new System.Drawing.Point(367, 375);
            this.gBoard4.Name = "gBoard4";
            this.gBoard4.Size = new System.Drawing.Size(113, 39);
            this.gBoard4.TabIndex = 106;
            this.gBoard4.TabStop = false;
            this.gBoard4.Text = "面板4";
            this.gBoard4.Visible = false;
            // 
            // nudB4JztNum
            // 
            this.nudB4JztNum.Location = new System.Drawing.Point(63, 13);
            this.nudB4JztNum.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudB4JztNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB4JztNum.Name = "nudB4JztNum";
            this.nudB4JztNum.ReadOnly = true;
            this.nudB4JztNum.Size = new System.Drawing.Size(46, 21);
            this.nudB4JztNum.TabIndex = 105;
            this.nudB4JztNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB4JztNum.ValueChanged += new System.EventHandler(this.nudB4JztNum_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 104;
            this.label5.Text = "加注头数";
            // 
            // gBoard3
            // 
            this.gBoard3.Controls.Add(this.nudB3JztNum);
            this.gBoard3.Controls.Add(this.label7);
            this.gBoard3.Location = new System.Drawing.Point(250, 375);
            this.gBoard3.Name = "gBoard3";
            this.gBoard3.Size = new System.Drawing.Size(113, 39);
            this.gBoard3.TabIndex = 105;
            this.gBoard3.TabStop = false;
            this.gBoard3.Text = "面板3";
            this.gBoard3.Visible = false;
            // 
            // nudB3JztNum
            // 
            this.nudB3JztNum.Location = new System.Drawing.Point(64, 13);
            this.nudB3JztNum.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudB3JztNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB3JztNum.Name = "nudB3JztNum";
            this.nudB3JztNum.ReadOnly = true;
            this.nudB3JztNum.Size = new System.Drawing.Size(46, 21);
            this.nudB3JztNum.TabIndex = 105;
            this.nudB3JztNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudB3JztNum.ValueChanged += new System.EventHandler(this.nudB3JztNum_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 104;
            this.label7.Text = "加注头数";
            // 
            // FrmOdorDtuConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 459);
            this.Controls.Add(this.gBoard4);
            this.Controls.Add(this.gBoard3);
            this.Controls.Add(this.gBoard2);
            this.Controls.Add(this.gBoard1);
            this.Controls.Add(this.cbxBoardNum);
            this.Controls.Add(this.lblBoardNum);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvDtuConfigList);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.numUDDINum);
            this.Controls.Add(this.lblDINum);
            this.Controls.Add(this.numUDAINum);
            this.Controls.Add(this.lblAINum);
            this.Controls.Add(this.numUDFlowNum);
            this.Controls.Add(this.lblFlowNum);
            this.Controls.Add(this.lblIsCreate);
            this.Controls.Add(this.lblIsAlert);
            this.Controls.Add(this.txtConfigDesc);
            this.Controls.Add(this.lblConfigDesc);
            this.Controls.Add(this.txtConfigName);
            this.Controls.Add(this.lblConfigName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOdorDtuConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站点配置(加臭)";
            ((System.ComponentModel.ISupportInitialize)(this.numUDFlowNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDAINum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDDINum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtuConfigList)).EndInit();
            this.gBoard1.ResumeLayout(false);
            this.gBoard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB1JztNum)).EndInit();
            this.gBoard2.ResumeLayout(false);
            this.gBoard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB2JztNum)).EndInit();
            this.gBoard4.ResumeLayout(false);
            this.gBoard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB4JztNum)).EndInit();
            this.gBoard3.ResumeLayout(false);
            this.gBoard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB3JztNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIsCreate;
        private System.Windows.Forms.Label lblIsAlert;
        private System.Windows.Forms.TextBox txtConfigDesc;
        private System.Windows.Forms.Label lblConfigDesc;
        private System.Windows.Forms.TextBox txtConfigName;
        private System.Windows.Forms.Label lblConfigName;
        private System.Windows.Forms.NumericUpDown numUDFlowNum;
        private System.Windows.Forms.Label lblFlowNum;
        private System.Windows.Forms.NumericUpDown numUDAINum;
        private System.Windows.Forms.Label lblAINum;
        private System.Windows.Forms.NumericUpDown numUDDINum;
        private System.Windows.Forms.Label lblDINum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnIsCreateTrue;
        private System.Windows.Forms.RadioButton rbtnIsCreateFalse;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvDtuConfigList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.RadioButton rbtIsAlertFalse;
        private System.Windows.Forms.RadioButton rbtIsAlertTrue;
        private System.Windows.Forms.Label lblBoardNum;
        private System.Windows.Forms.ComboBox cbxBoardNum;
        private System.Windows.Forms.GroupBox gBoard1;
        private System.Windows.Forms.NumericUpDown nudB1JztNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gBoard2;
        private System.Windows.Forms.NumericUpDown nudB2JztNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gBoard4;
        private System.Windows.Forms.NumericUpDown nudB4JztNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gBoard3;
        private System.Windows.Forms.NumericUpDown nudB3JztNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn DINum;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn AINum;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardInfo;
    }
}