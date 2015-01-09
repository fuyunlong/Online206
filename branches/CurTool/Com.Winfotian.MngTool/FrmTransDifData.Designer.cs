namespace Com.Winfotian.MngTool
{
    partial class FrmTransDifData
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
            this.tvDtuField = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvDtuField
            // 
            this.tvDtuField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDtuField.Location = new System.Drawing.Point(0, 0);
            this.tvDtuField.Name = "tvDtuField";
            this.tvDtuField.Size = new System.Drawing.Size(289, 462);
            this.tvDtuField.TabIndex = 1;
            this.tvDtuField.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDtuField_NodeMouseDoubleClick);
            // 
            // FrmTransDifData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 462);
            this.Controls.Add(this.tvDtuField);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransDifData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输差配置";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDtuField;
    }
}