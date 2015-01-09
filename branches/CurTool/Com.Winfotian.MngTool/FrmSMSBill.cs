using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public partial class FrmSMSBill : FrmBase
    {
        ServiceProxy.UserService.T_SMS_Bill curModel = null;
        public FrmSMSBill()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string valiStr = ValiFormInput();
            if (!string.IsNullOrEmpty(valiStr))
            {
                MessageBox.Show(valiStr, "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存计费数据");
                ServiceProxy.UserService.T_SMS_Bill smsBill = new ServiceProxy.UserService.T_SMS_Bill();
                smsBill.BillName = txtBillName.Text.Trim();
                smsBill.BillCode = "JF_" + DateTime.Now.ToString("yyMMddHHmmssffff");
                smsBill.AlertFee = double.Parse(txtAlertFee.Text.Trim());
                smsBill.DataFee = double.Parse(txtDataFee.Text.Trim());
                smsBill.BookFee = double.Parse(txtBookFee.Text.Trim());
                smsBill.RptFee = double.Parse(txtRptFree.Text.Trim());
                smsBill.OtherFee = string.IsNullOrWhiteSpace(txtOtherFee.Text) ? 0 : double.Parse(txtOtherFee.Text.Trim());
                smsBill.DayMax = int.Parse(txtDayMax.Text.Trim());
                smsBill.MonthMax = int.Parse(txtMonthMax.Text.Trim());
                smsBill.ExtendFee = "";
                smsBill.Status = 1;
                smsBill.UpdateFlag = 1;
                ServiceProxy.UserServiceProxy.AddSMSBill(LocalIP, smsBill);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加短信计费:ID-{0},Name-{1}", smsBill.BillCode, smsBill.BillName), 1);
                pbh.CloseProgressBar();
                MessageBox.Show("保存成功!");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("保存失败:" + ex.Message);
            }
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在查询计费数据");
                BindQueryedData();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("查询失败:" + ex.Message);
            }
        }

        private void BindQueryedData()
        {
            dgvBillList.DataSource = ServiceProxy.UserServiceProxy.GetSMSBillsByName(LocalIP, txtQBillName.Text.Trim());
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            string valiStr = ValiFormInput();
            if (curModel == null)
                valiStr += "请双击选择要修改的数据行!\n";
            if (!string.IsNullOrEmpty(valiStr))
            {
                MessageBox.Show(valiStr, "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改计费数据");
                ServiceProxy.UserService.T_SMS_Bill smsBill = new ServiceProxy.UserService.T_SMS_Bill();
                smsBill.BillName = txtBillName.Text.Trim();
                smsBill.BillCode = curModel.BillCode;
                smsBill.AlertFee = double.Parse(txtAlertFee.Text.Trim());
                smsBill.DataFee = double.Parse(txtDataFee.Text.Trim());
                smsBill.BookFee = double.Parse(txtBookFee.Text.Trim());
                smsBill.RptFee = double.Parse(txtRptFree.Text.Trim());
                smsBill.OtherFee = string.IsNullOrWhiteSpace(txtOtherFee.Text) ? 0 : double.Parse(txtOtherFee.Text.Trim());
                smsBill.DayMax = int.Parse(txtDayMax.Text.Trim());
                smsBill.MonthMax = int.Parse(txtMonthMax.Text.Trim());
                smsBill.ExtendFee = "";
                smsBill.Status = 1;
                smsBill.UpdateFlag = curModel.UpdateFlag + 1;
                ServiceProxy.UserServiceProxy.UpdateSMSBill(LocalIP, smsBill);
                BindQueryedData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改短信计费:ID-{0},Name-{1}", smsBill.BillCode, smsBill.BillName), 1);
                pbh.CloseProgressBar();
                MessageBox.Show("修改成功!");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("修改失败:" + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除计费数据");
                DataGridViewRow row = dgvBillList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.UserService.T_SMS_Bill;
                if (ServiceProxy.UserServiceProxy.DeleteSMSBillById(LocalIP, model.BillCode))
                {
                    ClearForm();
                    BindQueryedData();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除短信计费:ID-{0},Name-{1}", model.BillCode, model.BillName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("删除成功!");
                }
                else
                {
                    ClearForm();
                    BindQueryedData();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除短信计费:ID-{0},Name-{1}", model.BillCode, model.BillName), 2);
                    pbh.CloseProgressBar();
                    MessageBox.Show("删除失败!");
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("删除失败:" + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtAlertFee.Text = "";
            txtBillName.Text = "";
            txtDataFee.Text = "";
            txtBookFee.Text = "";
            txtDayMax.Text = "";
            txtMonthMax.Text = "";
            txtOtherFee.Text = "";
            txtRptFree.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            curModel = null;
            ClearForm();
        }

        private void dgvBillList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            DataGridViewRow row = dgvBillList.SelectedRows[0];
            curModel = row.DataBoundItem as ServiceProxy.UserService.T_SMS_Bill;
            txtBillName.Text = curModel.BillName;
            txtAlertFee.Text = curModel.AlertFee.ToString();
            txtDataFee.Text = curModel.DataFee.ToString();
            txtBookFee.Text = curModel.BookFee.ToString();
            txtRptFree.Text = curModel.RptFee.ToString();
            txtOtherFee.Text = curModel.OtherFee.ToString();
            txtDayMax.Text = curModel.DayMax.ToString();
            txtMonthMax.Text = curModel.MonthMax.ToString();
        }
        private string ValiFormInput()
        {
            string valiStr = string.Empty;
            int outInt = 0;
            if (string.IsNullOrEmpty(txtBillName.Text))
                valiStr += "收费名称不能为空!\n";
            if (!(ToolHelper.IsNumber(txtAlertFee.Text) || ToolHelper.IsDecimal(txtAlertFee.Text)))
                valiStr += "报警计费信息错误!注意要填整数(例如:5)或者浮点数(例如:1.20)!\n";
            if (!(ToolHelper.IsNumber(txtDataFee.Text) || ToolHelper.IsDecimal(txtDataFee.Text)))
                valiStr += "数据查询计费信息错误!注意要填整数(例如:5)或者浮点数(例如:1.20)!\n";
            if (!(ToolHelper.IsNumber(txtBookFee.Text) || ToolHelper.IsDecimal(txtBookFee.Text)))
                valiStr += "定时短信计费信息错误!注意要填整数(例如:5)或者浮点数(例如:1.20)!\n";
            if (!(ToolHelper.IsNumber(txtRptFree.Text) || ToolHelper.IsDecimal(txtRptFree.Text)))
                valiStr += "报表计费信息错误!注意要填整数(例如:5)或者浮点数(例如:1.20)!\n";
            if (!int.TryParse(txtDayMax.Text.Trim(), out outInt))
                valiStr += "每天最多条数设置错误!注意要填整数(例如:5)!\n";
            if (!int.TryParse(txtMonthMax.Text.Trim(), out outInt))
                valiStr += "每月最多条数设置错误!注意要填整数(例如:5)!\n";
            return valiStr;
        }
    }
}
