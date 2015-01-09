using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDelCompanyConfirm : FrmBase
    {
        private int CompanyId;
        public FrmDelCompanyConfirm(int CompanyId)
        {
            InitializeComponent();
            this.CompanyId = CompanyId;
        }

        private void btnDelOnlyCom_Click(object sender, EventArgs e)
        {
            ServiceProxy.CompanyServiceProxy.DeleteOnlyCompany(LocalIP, CompanyId);
            LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("只删除公司:ID({0})", CompanyId), 1);
            this.DialogResult = DialogResult.OK;
        }

        private void btnDelComAndOther_Click(object sender, EventArgs e)
        {
            ServiceProxy.CompanyServiceProxy.DeleteCompanyAndOther(LocalIP, CompanyId);
            LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除公司和其他:ID({0})", CompanyId), 1);
            this.DialogResult = DialogResult.OK;
        }
    }
}
