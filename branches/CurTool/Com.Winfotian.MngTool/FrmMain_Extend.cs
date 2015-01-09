using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Winfotian.MngTool
{
    public partial class FrmMain_Extend : FrmBase
    {
        public FrmMain_Extend()
        {
            InitializeComponent();
        }

        private void btnCompanyManager_Click(object sender, EventArgs e)
        {
            new FrmCompany().ShowDialog();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            new FrmUser().ShowDialog();
        }

        private void btnSiteManager_Click(object sender, EventArgs e)
        {
            new FrmDTU().ShowDialog();
        }

        private void btnDtuIDGenerater_Click(object sender, EventArgs e)
        {
            new FrmDtuIDGenerate().ShowDialog();
        }
    }
}
