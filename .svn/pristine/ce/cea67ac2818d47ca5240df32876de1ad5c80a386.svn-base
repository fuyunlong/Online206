using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuIDGenerate : FrmBase
    {
        public FrmDtuIDGenerate()
        {
            InitializeComponent();
            cbxCompany.DataSource =ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
            cbxCompany.DisplayMember = "CompanyName";
            cbxCompany.ValueMember = "CompanyId";
        }

        private void btnGenerater_Click(object sender, EventArgs e)
        {
            txtDtuIDContainer.ResetText();//清空TextBox
            List<string> DtuIdlst = ServiceProxy.DTUServiceProxy.GenerateDtuidList(LocalIP, int.Parse(cbxCompany.SelectedValue.ToString()), int.Parse(numUDNums.Value.ToString()));
            foreach (string item in DtuIdlst)
            {
                txtDtuIDContainer.AppendText(item+"\n");
            }
        }
    }
}
