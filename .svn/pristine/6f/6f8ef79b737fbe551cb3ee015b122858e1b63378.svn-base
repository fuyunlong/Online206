using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Winfotian.MngTool
{
    public partial class FrmProgressBar : Form
    {
        public FrmProgressBar()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.TopLevel = true;
        }
        
        public FrmProgressBar(Size size)
        {
            InitializeComponent();
            this.Size = size;
        }

        /// <summary>
        /// 消息
        /// </summary>
        public string ShowMessage
        {
            set 
            {                
                this.lb_Info.Text = value;
            }
        }
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="Msg"></param>
        public void ShowDiaglogInfo(string Msg)
        {
            MessageBox.Show(this, Msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
