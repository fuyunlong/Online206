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
    public partial class FrmDtuPressureLevel : FrmBase
    {
        ServiceProxy.DTUService.T_DTU_PressureLevel curModel = null;
        public FrmDtuPressureLevel()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPressureName.Text))
            {
                MessageBox.Show("压力名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存压力数据!");
                ServiceProxy.DTUService.T_DTU_PressureLevel PressureLevel = new ServiceProxy.DTUService.T_DTU_PressureLevel();
                PressureLevel.PressureName = txtPressureName.Text.Trim();
                PressureLevel.PressureDesc = txtPressureDesc.Text.Trim();
                PressureLevel.Status = 1;
                ServiceProxy.DTUServiceProxy.AddPressureLevel(LocalIP, PressureLevel);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点压力:{0}", PressureLevel.PressureName), 1);
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
                pbh.PopProgressBar("正在查询压力数据!");
                dgvPressureList.DataSource = ServiceProxy.DTUServiceProxy.GetPressureLevelsByName(LocalIP, txtQPressureName.Text.Trim());
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("查询失败:" + ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (curModel == null)
            {
                MessageBox.Show("请双击选择要修改的数据行!");
                return;
            }
            if (string.IsNullOrEmpty(txtPressureName.Text))
            {
                MessageBox.Show("压力名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改压力数据!");
                ServiceProxy.DTUService.T_DTU_PressureLevel PressureLevel = new ServiceProxy.DTUService.T_DTU_PressureLevel();
                PressureLevel.Id = curModel.Id;
                PressureLevel.PressureName = txtPressureName.Text.Trim();
                PressureLevel.PressureDesc = txtPressureDesc.Text.Trim();
                PressureLevel.Status = 1;
                PressureLevel.UpdateFlag = curModel.UpdateFlag + 1;
                ServiceProxy.DTUServiceProxy.UpdatePressureLevel(LocalIP, PressureLevel);
                btnQuery_Click(null, null);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改站点压力:ID-{0},Name-{1}", PressureLevel.Id, PressureLevel.PressureName), 1);
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

        private void dgvPressureList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            DataGridViewRow row = dgvPressureList.SelectedRows[0];
            curModel = row.DataBoundItem as ServiceProxy.DTUService.T_DTU_PressureLevel;
            txtPressureName.Text = curModel.PressureName;
            txtPressureDesc.Text = curModel.PressureDesc;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            ClearForm();
        }

        private void ClearForm()
        {
            txtPressureName.Text = "";
            txtPressureDesc.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除压力数据!");
                DataGridViewRow row = dgvPressureList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.DTUService.T_DTU_PressureLevel;
                if (ServiceProxy.DTUServiceProxy.DeletePressureLevel(LocalIP, model.Id))
                {
                    ClearForm();
                    btnQuery_Click(null, null);
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点压力:ID-{0},Name-{1}", model.Id, model.PressureName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("删除成功!");
                }
                else
                {
                    ClearForm();
                    btnQuery_Click(null, null);
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点压力:ID-{0},Name-{1}", model.Id, model.PressureName), 2);
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
    }
}
