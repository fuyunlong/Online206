namespace Com.Winfotian.MngTool
{
    partial class FrmDtuIDGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDtuIDGenerate));
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblNums = new System.Windows.Forms.Label();
            this.numUDNums = new System.Windows.Forms.NumericUpDown();
            this.txtDtuIDContainer = new System.Windows.Forms.TextBox();
            this.btnGenerater = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNums)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxCompany
            // 
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(117, 24);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(161, 20);
            this.cbxCompany.TabIndex = 0;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(36, 28);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(53, 12);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "选择公司";
            // 
            // lblNums
            // 
            this.lblNums.AutoSize = true;
            this.lblNums.Location = new System.Drawing.Point(36, 68);
            this.lblNums.Name = "lblNums";
            this.lblNums.Size = new System.Drawing.Size(53, 12);
            this.lblNums.TabIndex = 3;
            this.lblNums.Text = "生成个数";
            // 
            // numUDNums
            // 
            this.numUDNums.Location = new System.Drawing.Point(117, 64);
            this.numUDNums.Name = "numUDNums";
            this.numUDNums.ReadOnly = true;
            this.numUDNums.Size = new System.Drawing.Size(161, 21);
            this.numUDNums.TabIndex = 4;
            this.numUDNums.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtDtuIDContainer
            // 
            this.txtDtuIDContainer.Location = new System.Drawing.Point(38, 105);
            this.txtDtuIDContainer.Multiline = true;
            this.txtDtuIDContainer.Name = "txtDtuIDContainer";
            this.txtDtuIDContainer.Size = new System.Drawing.Size(240, 158);
            this.txtDtuIDContainer.TabIndex = 5;
            // 
            // btnGenerater
            // 
            this.btnGenerater.Location = new System.Drawing.Point(117, 269);
            this.btnGenerater.Name = "btnGenerater";
            this.btnGenerater.Size = new System.Drawing.Size(75, 23);
            this.btnGenerater.TabIndex = 6;
            this.btnGenerater.Text = "生成";
            this.btnGenerater.UseVisualStyleBackColor = true;
            this.btnGenerater.Click += new System.EventHandler(this.btnGenerater_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(36, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "说明：新生产终端时，便于熟知生产新终端的编号";
            // 
            // FrmDtuIDGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerater);
            this.Controls.Add(this.txtDtuIDContainer);
            this.Controls.Add(this.numUDNums);
            this.Controls.Add(this.lblNums);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cbxCompany);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDtuIDGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站点编号生成器";
            ((System.ComponentModel.ISupportInitialize)(this.numUDNums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblNums;
        private System.Windows.Forms.NumericUpDown numUDNums;
        private System.Windows.Forms.TextBox txtDtuIDContainer;
        private System.Windows.Forms.Button btnGenerater;
        private System.Windows.Forms.Label label1;
    }
}