namespace Com.Winfotian.MngTool
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.DTUMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DTUManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_OdorDTU = new System.Windows.Forms.ToolStripMenuItem();
            this.FieldManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FieldManagerMenu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DTUToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.DTUGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DTUConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DTUConfigMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DTUPressureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SetParam = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_UploadFlow = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ImportantDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Transmit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_TransDif = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ValveEffect = new System.Windows.Forms.ToolStripMenuItem();
            this.CompanyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompanyManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompanyConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.UserGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserRoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserBillMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DtuUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BeatDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceAlertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Client = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SNMng = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SNProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_AuthorClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ClientKey = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnUserManager = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSiteManager = new System.Windows.Forms.Button();
            this.btnCompanyManager = new System.Windows.Forms.Button();
            this.btnDtuIDGenerater = new System.Windows.Forms.Button();
            this.btn_quit = new System.Windows.Forms.Button();
            this.menu_DOConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DTUMenuItem,
            this.CompanyMenuItem,
            this.UserMenuItem,
            this.SearchDataMenuItem,
            this.Menu_Client,
            this.帮助HToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // DTUMenuItem
            // 
            this.DTUMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DTUManagerMenuItem,
            this.menu_OdorDTU,
            this.FieldManagerMenuItem,
            this.FieldManagerMenu2,
            this.menu_DOConfig,
            this.menu_Transmit,
            this.menu_ValveEffect,
            this.DTUToolStripSeparator,
            this.DTUGroupMenuItem,
            this.DTUConfigMenuItem,
            this.DTUConfigMenuItem2,
            this.DTUPressureMenuItem,
            this.menu_SetParam,
            this.menu_UploadFlow,
            this.menu_ImportantDevice,
            this.menu_TransDif});
            this.DTUMenuItem.Name = "DTUMenuItem";
            this.DTUMenuItem.Size = new System.Drawing.Size(85, 21);
            this.DTUMenuItem.Text = "站点管理(D)";
            // 
            // DTUManagerMenuItem
            // 
            this.DTUManagerMenuItem.Name = "DTUManagerMenuItem";
            this.DTUManagerMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DTUManagerMenuItem.Text = "站点信息管理";
            this.DTUManagerMenuItem.Click += new System.EventHandler(this.DTUManagerMenuItem_Click);
            // 
            // menu_OdorDTU
            // 
            this.menu_OdorDTU.Name = "menu_OdorDTU";
            this.menu_OdorDTU.Size = new System.Drawing.Size(180, 22);
            this.menu_OdorDTU.Text = "站点信息管理(加臭)";
            this.menu_OdorDTU.Click += new System.EventHandler(this.menu_OdorDTU_Click);
            // 
            // FieldManagerMenuItem
            // 
            this.FieldManagerMenuItem.Name = "FieldManagerMenuItem";
            this.FieldManagerMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FieldManagerMenuItem.Text = "字段信息管理";
            this.FieldManagerMenuItem.Click += new System.EventHandler(this.FieldManagerMenuItem_Click);
            // 
            // FieldManagerMenu2
            // 
            this.FieldManagerMenu2.Name = "FieldManagerMenu2";
            this.FieldManagerMenu2.Size = new System.Drawing.Size(180, 22);
            this.FieldManagerMenu2.Text = "字段管理(增强)";
            this.FieldManagerMenu2.Click += new System.EventHandler(this.FieldManagerMenu2_Click);
            // 
            // DTUToolStripSeparator
            // 
            this.DTUToolStripSeparator.Name = "DTUToolStripSeparator";
            this.DTUToolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // DTUGroupMenuItem
            // 
            this.DTUGroupMenuItem.Name = "DTUGroupMenuItem";
            this.DTUGroupMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DTUGroupMenuItem.Text = "站点分组管理";
            this.DTUGroupMenuItem.Click += new System.EventHandler(this.DTUGroupMenuItem_Click);
            // 
            // DTUConfigMenuItem
            // 
            this.DTUConfigMenuItem.Name = "DTUConfigMenuItem";
            this.DTUConfigMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DTUConfigMenuItem.Text = "站点配置管理";
            this.DTUConfigMenuItem.Click += new System.EventHandler(this.DTUConfigMenuItem_Click);
            // 
            // DTUConfigMenuItem2
            // 
            this.DTUConfigMenuItem2.Name = "DTUConfigMenuItem2";
            this.DTUConfigMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.DTUConfigMenuItem2.Text = "站点配置管理(加臭)";
            this.DTUConfigMenuItem2.Click += new System.EventHandler(this.DTUConfigMenuItem2_Click);
            // 
            // DTUPressureMenuItem
            // 
            this.DTUPressureMenuItem.Name = "DTUPressureMenuItem";
            this.DTUPressureMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DTUPressureMenuItem.Text = "压力等级管理";
            this.DTUPressureMenuItem.Click += new System.EventHandler(this.DTUPressureMenuItem_Click);
            // 
            // menu_SetParam
            // 
            this.menu_SetParam.Name = "menu_SetParam";
            this.menu_SetParam.Size = new System.Drawing.Size(180, 22);
            this.menu_SetParam.Text = "参数设置";
            this.menu_SetParam.Visible = false;
            this.menu_SetParam.Click += new System.EventHandler(this.menu_SetParam_Click);
            // 
            // menu_UploadFlow
            // 
            this.menu_UploadFlow.Name = "menu_UploadFlow";
            this.menu_UploadFlow.Size = new System.Drawing.Size(180, 22);
            this.menu_UploadFlow.Text = "站点流程图上传";
            this.menu_UploadFlow.Click += new System.EventHandler(this.menu_UploadFlow_Click);
            // 
            // menu_ImportantDevice
            // 
            this.menu_ImportantDevice.Name = "menu_ImportantDevice";
            this.menu_ImportantDevice.Size = new System.Drawing.Size(180, 22);
            this.menu_ImportantDevice.Text = "重要设备管理";
            this.menu_ImportantDevice.Click += new System.EventHandler(this.menu_ImportantDevice_Click);
            // 
            // menu_Transmit
            // 
            this.menu_Transmit.Name = "menu_Transmit";
            this.menu_Transmit.Size = new System.Drawing.Size(180, 22);
            this.menu_Transmit.Text = "数据转发配置";
            this.menu_Transmit.Click += new System.EventHandler(this.menu_Transmit_Click);
            // 
            // menu_TransDif
            // 
            this.menu_TransDif.Name = "menu_TransDif";
            this.menu_TransDif.Size = new System.Drawing.Size(180, 22);
            this.menu_TransDif.Text = "输差配置";
            this.menu_TransDif.Click += new System.EventHandler(this.menu_TransDif_Click);
            // 
            // menu_ValveEffect
            // 
            this.menu_ValveEffect.Name = "menu_ValveEffect";
            this.menu_ValveEffect.Size = new System.Drawing.Size(180, 22);
            this.menu_ValveEffect.Text = "阀门影响管理";
            this.menu_ValveEffect.Click += new System.EventHandler(this.menu_ValveEffect_Click);
            // 
            // CompanyMenuItem
            // 
            this.CompanyMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompanyManagerMenuItem,
            this.CompanyConfigMenuItem});
            this.CompanyMenuItem.Name = "CompanyMenuItem";
            this.CompanyMenuItem.Size = new System.Drawing.Size(84, 21);
            this.CompanyMenuItem.Text = "客户管理(C)";
            // 
            // CompanyManagerMenuItem
            // 
            this.CompanyManagerMenuItem.Name = "CompanyManagerMenuItem";
            this.CompanyManagerMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CompanyManagerMenuItem.Text = "客户信息管理";
            this.CompanyManagerMenuItem.Click += new System.EventHandler(this.CompanyManagerMenuItem_Click);
            // 
            // CompanyConfigMenuItem
            // 
            this.CompanyConfigMenuItem.Name = "CompanyConfigMenuItem";
            this.CompanyConfigMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CompanyConfigMenuItem.Text = "公司配置管理";
            this.CompanyConfigMenuItem.Click += new System.EventHandler(this.CompanyConfigMenuItem_Click);
            // 
            // UserMenuItem
            // 
            this.UserMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserManagerMenuItem,
            this.UserToolStripSeparator,
            this.UserGroupMenuItem,
            this.UserRoleMenuItem,
            this.UserBillMenuItem,
            this.UserConfigMenuItem,
            this.UserToolStripSeparator1,
            this.DtuUserMenuItem});
            this.UserMenuItem.Name = "UserMenuItem";
            this.UserMenuItem.Size = new System.Drawing.Size(84, 21);
            this.UserMenuItem.Text = "用户管理(A)";
            // 
            // UserManagerMenuItem
            // 
            this.UserManagerMenuItem.Name = "UserManagerMenuItem";
            this.UserManagerMenuItem.Size = new System.Drawing.Size(148, 22);
            this.UserManagerMenuItem.Text = "用户信息管理";
            this.UserManagerMenuItem.Click += new System.EventHandler(this.UserManagerMenuItem_Click);
            // 
            // UserToolStripSeparator
            // 
            this.UserToolStripSeparator.Name = "UserToolStripSeparator";
            this.UserToolStripSeparator.Size = new System.Drawing.Size(145, 6);
            // 
            // UserGroupMenuItem
            // 
            this.UserGroupMenuItem.Name = "UserGroupMenuItem";
            this.UserGroupMenuItem.Size = new System.Drawing.Size(148, 22);
            this.UserGroupMenuItem.Text = "用户分组管理";
            this.UserGroupMenuItem.Click += new System.EventHandler(this.UserGroupMenuItem_Click);
            // 
            // UserRoleMenuItem
            // 
            this.UserRoleMenuItem.Name = "UserRoleMenuItem";
            this.UserRoleMenuItem.Size = new System.Drawing.Size(148, 22);
            this.UserRoleMenuItem.Text = "用户角色管理";
            this.UserRoleMenuItem.Click += new System.EventHandler(this.UserRoleMenuItem_Click);
            // 
            // UserBillMenuItem
            // 
            this.UserBillMenuItem.Name = "UserBillMenuItem";
            this.UserBillMenuItem.Size = new System.Drawing.Size(148, 22);
            this.UserBillMenuItem.Text = "用户计费管理";
            this.UserBillMenuItem.Click += new System.EventHandler(this.UserBillMenuItem_Click);
            // 
            // UserConfigMenuItem
            // 
            this.UserConfigMenuItem.Name = "UserConfigMenuItem";
            this.UserConfigMenuItem.Size = new System.Drawing.Size(148, 22);
            this.UserConfigMenuItem.Text = "用户配置管理";
            this.UserConfigMenuItem.Click += new System.EventHandler(this.UserConfigMenuItem_Click);
            // 
            // UserToolStripSeparator1
            // 
            this.UserToolStripSeparator1.Name = "UserToolStripSeparator1";
            this.UserToolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // DtuUserMenuItem
            // 
            this.DtuUserMenuItem.Name = "DtuUserMenuItem";
            this.DtuUserMenuItem.Size = new System.Drawing.Size(148, 22);
            this.DtuUserMenuItem.Text = "站点用户管理";
            this.DtuUserMenuItem.Click += new System.EventHandler(this.DtuUserMenuItem_Click);
            // 
            // SearchDataMenuItem
            // 
            this.SearchDataMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BeatDataMenuItem,
            this.DeviceAlertMenuItem});
            this.SearchDataMenuItem.Name = "SearchDataMenuItem";
            this.SearchDataMenuItem.Size = new System.Drawing.Size(68, 21);
            this.SearchDataMenuItem.Text = "数据查询";
            // 
            // BeatDataMenuItem
            // 
            this.BeatDataMenuItem.Name = "BeatDataMenuItem";
            this.BeatDataMenuItem.Size = new System.Drawing.Size(172, 22);
            this.BeatDataMenuItem.Text = "心跳记录查询";
            this.BeatDataMenuItem.Click += new System.EventHandler(this.BeatDataMenuItem_Click);
            // 
            // DeviceAlertMenuItem
            // 
            this.DeviceAlertMenuItem.Name = "DeviceAlertMenuItem";
            this.DeviceAlertMenuItem.Size = new System.Drawing.Size(172, 22);
            this.DeviceAlertMenuItem.Text = "设备报警记录查询";
            this.DeviceAlertMenuItem.Click += new System.EventHandler(this.DeviceAlertMenuItem_Click);
            // 
            // Menu_Client
            // 
            this.Menu_Client.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_SNMng,
            this.menu_SNProduct,
            this.menu_AuthorClient,
            this.menu_ClientKey});
            this.Menu_Client.Name = "Menu_Client";
            this.Menu_Client.Size = new System.Drawing.Size(80, 21);
            this.Menu_Client.Text = "客户端管理";
            // 
            // menu_SNMng
            // 
            this.menu_SNMng.Name = "menu_SNMng";
            this.menu_SNMng.Size = new System.Drawing.Size(141, 22);
            this.menu_SNMng.Text = "序列号管理";
            this.menu_SNMng.Click += new System.EventHandler(this.menu_SNMng_Click);
            // 
            // menu_SNProduct
            // 
            this.menu_SNProduct.Name = "menu_SNProduct";
            this.menu_SNProduct.Size = new System.Drawing.Size(141, 22);
            this.menu_SNProduct.Text = "SN批量导入";
            this.menu_SNProduct.Click += new System.EventHandler(this.menu_SNProduct_Click);
            // 
            // menu_AuthorClient
            // 
            this.menu_AuthorClient.Name = "menu_AuthorClient";
            this.menu_AuthorClient.Size = new System.Drawing.Size(141, 22);
            this.menu_AuthorClient.Text = "客户端授权";
            this.menu_AuthorClient.Click += new System.EventHandler(this.menu_AuthorClient_Click);
            // 
            // menu_ClientKey
            // 
            this.menu_ClientKey.Name = "menu_ClientKey";
            this.menu_ClientKey.Size = new System.Drawing.Size(141, 22);
            this.menu_ClientKey.Text = "客户端绑定";
            this.menu_ClientKey.Click += new System.EventHandler(this.menu_ClientKey_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_about});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(H)";
            // 
            // menu_about
            // 
            this.menu_about.Name = "menu_about";
            this.menu_about.Size = new System.Drawing.Size(100, 22);
            this.menu_about.Text = "关于";
            this.menu_about.Click += new System.EventHandler(this.menu_about_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Main_CusMng.jpg");
            this.imageList1.Images.SetKeyName(1, "Main_Generate.jpg");
            this.imageList1.Images.SetKeyName(2, "Main_Help.jpg");
            this.imageList1.Images.SetKeyName(3, "Main_Quit.jpg");
            this.imageList1.Images.SetKeyName(4, "Main_SiteMng.jpg");
            this.imageList1.Images.SetKeyName(5, "Main_UserMng.jpg");
            // 
            // btnUserManager
            // 
            this.btnUserManager.BackColor = System.Drawing.Color.Transparent;
            this.btnUserManager.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.Main_UserMng;
            this.btnUserManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserManager.FlatAppearance.BorderSize = 0;
            this.btnUserManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManager.ImageIndex = 4;
            this.btnUserManager.Location = new System.Drawing.Point(140, 30);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(290, 175);
            this.btnUserManager.TabIndex = 1;
            this.btnUserManager.UseVisualStyleBackColor = false;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            this.btnUserManager.MouseEnter += new System.EventHandler(this.btnUserManager_MouseEnter);
            this.btnUserManager.MouseLeave += new System.EventHandler(this.btnUserManager_MouseLeave);
            // 
            // btnHelp
            // 
            this.btnHelp.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.Main_Help;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(671, 41);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(268, 145);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            this.btnHelp.MouseEnter += new System.EventHandler(this.btnHelp_MouseEnter);
            this.btnHelp.MouseLeave += new System.EventHandler(this.btnHelp_MouseLeave);
            // 
            // btnSiteManager
            // 
            this.btnSiteManager.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.Main_SiteMng;
            this.btnSiteManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiteManager.FlatAppearance.BorderSize = 0;
            this.btnSiteManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiteManager.Location = new System.Drawing.Point(67, 203);
            this.btnSiteManager.Name = "btnSiteManager";
            this.btnSiteManager.Size = new System.Drawing.Size(275, 165);
            this.btnSiteManager.TabIndex = 3;
            this.btnSiteManager.UseVisualStyleBackColor = true;
            this.btnSiteManager.Click += new System.EventHandler(this.btnSiteManager_Click);
            this.btnSiteManager.MouseEnter += new System.EventHandler(this.btnSiteManager_MouseEnter);
            this.btnSiteManager.MouseLeave += new System.EventHandler(this.btnSiteManager_MouseLeave);
            // 
            // btnCompanyManager
            // 
            this.btnCompanyManager.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.Main_CusMng;
            this.btnCompanyManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompanyManager.FlatAppearance.BorderSize = 0;
            this.btnCompanyManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompanyManager.Location = new System.Drawing.Point(47, 370);
            this.btnCompanyManager.Name = "btnCompanyManager";
            this.btnCompanyManager.Size = new System.Drawing.Size(278, 175);
            this.btnCompanyManager.TabIndex = 4;
            this.btnCompanyManager.UseVisualStyleBackColor = true;
            this.btnCompanyManager.Click += new System.EventHandler(this.btnCompanyManager_Click);
            this.btnCompanyManager.MouseEnter += new System.EventHandler(this.btnCompanyManager_MouseEnter);
            this.btnCompanyManager.MouseLeave += new System.EventHandler(this.btnCompanyManager_MouseLeave);
            // 
            // btnDtuIDGenerater
            // 
            this.btnDtuIDGenerater.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.Main_Generate;
            this.btnDtuIDGenerater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDtuIDGenerater.FlatAppearance.BorderSize = 0;
            this.btnDtuIDGenerater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDtuIDGenerater.Location = new System.Drawing.Point(253, 547);
            this.btnDtuIDGenerater.Name = "btnDtuIDGenerater";
            this.btnDtuIDGenerater.Size = new System.Drawing.Size(288, 163);
            this.btnDtuIDGenerater.TabIndex = 5;
            this.btnDtuIDGenerater.UseVisualStyleBackColor = true;
            this.btnDtuIDGenerater.Click += new System.EventHandler(this.btnDtuIDGenerater_Click);
            this.btnDtuIDGenerater.MouseEnter += new System.EventHandler(this.btnDtuIDGenerater_MouseEnter);
            this.btnDtuIDGenerater.MouseLeave += new System.EventHandler(this.btnDtuIDGenerater_MouseLeave);
            // 
            // btn_quit
            // 
            this.btn_quit.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.Main_Quit;
            this.btn_quit.FlatAppearance.BorderSize = 0;
            this.btn_quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quit.Location = new System.Drawing.Point(858, 617);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(90, 103);
            this.btn_quit.TabIndex = 6;
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // menu_DOConfig
            // 
            this.menu_DOConfig.Name = "menu_DOConfig";
            this.menu_DOConfig.Size = new System.Drawing.Size(180, 22);
            this.menu_DOConfig.Text = "远程控制配置";
            this.menu_DOConfig.Click += new System.EventHandler(this.menu_DOConfig_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.btnDtuIDGenerater);
            this.Controls.Add(this.btnCompanyManager);
            this.Controls.Add(this.btnSiteManager);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnUserManager);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "英菲信SCADA管理工具（内部专用）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem DTUMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompanyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnUserManager;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSiteManager;
        private System.Windows.Forms.Button btnCompanyManager;
        private System.Windows.Forms.Button btnDtuIDGenerater;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.ToolStripMenuItem DTUManagerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompanyManagerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FieldManagerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserManagerMenuItem;
        private System.Windows.Forms.ToolStripSeparator DTUToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem DTUGroupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DTUConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DTUPressureMenuItem;
        private System.Windows.Forms.ToolStripSeparator UserToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem UserGroupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserRoleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserBillMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompanyConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BeatDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeviceAlertMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_SetParam;
        private System.Windows.Forms.ToolStripMenuItem menu_UploadFlow;
        private System.Windows.Forms.ToolStripMenuItem Menu_Client;
        private System.Windows.Forms.ToolStripMenuItem menu_SNMng;
        private System.Windows.Forms.ToolStripMenuItem menu_SNProduct;
        private System.Windows.Forms.ToolStripMenuItem menu_AuthorClient;
        private System.Windows.Forms.ToolStripMenuItem menu_ImportantDevice;
        private System.Windows.Forms.ToolStripMenuItem menu_Transmit;
        private System.Windows.Forms.ToolStripMenuItem menu_TransDif;
        private System.Windows.Forms.ToolStripMenuItem FieldManagerMenu2;
        private System.Windows.Forms.ToolStripSeparator UserToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem DtuUserMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_about;
        private System.Windows.Forms.ToolStripMenuItem menu_ValveEffect;
        private System.Windows.Forms.ToolStripMenuItem menu_OdorDTU;
        private System.Windows.Forms.ToolStripMenuItem DTUConfigMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menu_ClientKey;
        private System.Windows.Forms.ToolStripMenuItem menu_DOConfig;
    }
}