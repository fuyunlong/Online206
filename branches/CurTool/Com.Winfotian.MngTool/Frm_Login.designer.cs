namespace Com.Winfotian.MngTool
{
    partial class Frm_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.pnl_back = new System.Windows.Forms.Panel();
            this.lb_Quit = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_uid = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_back.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_back
            // 
            this.pnl_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.pnl_back.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.login08;
            this.pnl_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_back.Controls.Add(this.lb_Quit);
            this.pnl_back.Controls.Add(this.btn_Login);
            this.pnl_back.Controls.Add(this.txt_uid);
            this.pnl_back.Controls.Add(this.txt_pwd);
            this.pnl_back.Location = new System.Drawing.Point(0, 266);
            this.pnl_back.Name = "pnl_back";
            this.pnl_back.Size = new System.Drawing.Size(756, 434);
            this.pnl_back.TabIndex = 10;
            this.pnl_back.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_back_MouseDown);
            this.pnl_back.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_back_MouseMove);
            this.pnl_back.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_back_MouseUp);
            // 
            // lb_Quit
            // 
            this.lb_Quit.ActiveLinkColor = System.Drawing.Color.Green;
            this.lb_Quit.AutoSize = true;
            this.lb_Quit.BackColor = System.Drawing.Color.Transparent;
            this.lb_Quit.LinkColor = System.Drawing.Color.Transparent;
            this.lb_Quit.Location = new System.Drawing.Point(502, 471);
            this.lb_Quit.Name = "lb_Quit";
            this.lb_Quit.Size = new System.Drawing.Size(35, 12);
            this.lb_Quit.TabIndex = 12;
            this.lb_Quit.TabStop = true;
            this.lb_Quit.Text = "退 出";
            this.lb_Quit.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.btn_Login.BackgroundImage = global::Com.Winfotian.MngTool.Properties.Resources.login08_r2_c2;
            this.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Login.Location = new System.Drawing.Point(689, 299);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(92, 72);
            this.btn_Login.TabIndex = 11;
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_uid
            // 
            this.txt_uid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_uid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_uid.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_uid.Location = new System.Drawing.Point(460, 292);
            this.txt_uid.Name = "txt_uid";
            this.txt_uid.Size = new System.Drawing.Size(158, 14);
            this.txt_uid.TabIndex = 7;
            // 
            // txt_pwd
            // 
            this.txt_pwd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_pwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pwd.Location = new System.Drawing.Point(460, 326);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(158, 14);
            this.txt_pwd.TabIndex = 8;
            this.txt_pwd.UseSystemPasswordChar = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Login
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(963, 700);
            this.Controls.Add(this.pnl_back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "英菲信SCADA管理系统";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.pnl_back.ResumeLayout(false);
            this.pnl_back.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_uid;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Panel pnl_back;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.LinkLabel lb_Quit;
        private System.Windows.Forms.Timer timer1;


    }
}