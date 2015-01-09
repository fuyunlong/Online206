using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;
using Com.Winfotian.Components.Enumerations;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuConfig : FrmBase
    {
        ServiceProxy.DTUService.T_DTU_Config curModel = null;
        public FrmDtuConfig()
        {
            InitializeComponent();
            BindAllConfig();
        }
        private void BindAllConfig()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载站点配置数据!");
                dgvDtuConfigList.DataSource = ServiceProxy.DTUServiceProxy.GetDtuConfigsByStatus(LocalIP, 1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.PopProgressBar("加载查询的站点数据出错:" + ex.Message);
                pbh.CloseProgressBar();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfigName.Text))
            {
                MessageBox.Show("配置名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存站点配置数据!");
                ServiceProxy.DTUService.T_DTU_Config dtuConfig = new ServiceProxy.DTUService.T_DTU_Config();
                dtuConfig.AINum = int.Parse(numUDAINum.Value.ToString());
                dtuConfig.FlowNum = int.Parse(numUDFlowNum.Value.ToString());
                dtuConfig.DINum = int.Parse(numUDDINum.Value.ToString());
                dtuConfig.IsAlert = rbtIsAlertTrue.Checked ? 1 : 0;
                dtuConfig.IsCreate = rbtnIsCreateTrue.Checked ? 1 : 0;
                dtuConfig.ConfigCode = "PZ_" + dtuConfig.FlowNum.ToString() + dtuConfig.AINum.ToString() + dtuConfig.DINum.ToString() + dtuConfig.IsAlert.ToString() + dtuConfig.IsCreate.ToString();
                ServiceProxy.CommonService.EnumExistsStatus flag = ServiceProxy.CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_DTU_Config]", "ConfigCode", dtuConfig.ConfigCode);
                if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
                {
                    MessageBox.Show("这个配置编号已经存在!");
                    return;
                }
                dtuConfig.ConfigName = string.Format("{0}流{1}模{2}开", dtuConfig.FlowNum, dtuConfig.AINum, dtuConfig.DINum);// txtConfigName.Text.Trim();
                dtuConfig.ConfigDesc = string.Format("{0}个流量计{1}个模拟量{2}个开关量", dtuConfig.FlowNum, dtuConfig.AINum, dtuConfig.DINum);//txtConfigDesc.Text.Trim();
                dtuConfig.Status = 1;
                dtuConfig.UpdateFlag = 1;
                ServiceProxy.DTUServiceProxy.AddDtuConfig(LocalIP, dtuConfig);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点配置:ID-{0},Name-{1}", dtuConfig.ConfigCode, dtuConfig.ConfigName), 1);
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

        private void dgvDtuConfigList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDtuConfigList.SelectedRows[0];
            curModel = row.DataBoundItem as ServiceProxy.DTUService.T_DTU_Config;
            txtConfigName.Text = curModel.ConfigName;
            txtConfigDesc.Text = curModel.ConfigDesc;
            numUDFlowNum.Value = curModel.FlowNum.Value;
            numUDAINum.Value = curModel.AINum.Value;
            numUDDINum.Value = curModel.DINum.Value;
            if (curModel.IsCreate == 1)
            {
                rbtnIsCreateTrue.Checked = true;
            }
            else
            {
                rbtnIsCreateFalse.Checked = true;
            }
            if (curModel.IsAlert == 1)
            {
                rbtIsAlertTrue.Checked = true;
            }
            else
            {
                rbtIsAlertFalse.Checked = true;
            }
            btnAdd.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除站点配置数据!");
                DataGridViewRow row = dgvDtuConfigList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.DTUService.T_DTU_Config;
                if (ServiceProxy.DTUServiceProxy.DeleteDtuConfig(LocalIP, model.ConfigCode))
                {
                    ClearForm();
                    BindAllConfig();
                }
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点配置:ID-{0},Name-{1}", model.ConfigCode, model.ConfigName), 1);
                pbh.CloseProgressBar();
                MessageBox.Show("删除成功!");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("删除失败:" + ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfigName.Text))
            {
                MessageBox.Show("配置名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存修改的站点配置数据!");
                ServiceProxy.DTUService.T_DTU_Config dtuConfig = new ServiceProxy.DTUService.T_DTU_Config();
                dtuConfig.ConfigCode = curModel.ConfigCode;
                dtuConfig.AINum = int.Parse(numUDAINum.Value.ToString());
                dtuConfig.FlowNum = int.Parse(numUDFlowNum.Value.ToString());
                dtuConfig.DINum = int.Parse(numUDDINum.Value.ToString());
                dtuConfig.IsAlert = rbtIsAlertTrue.Checked ? 1 : 0;
                dtuConfig.IsCreate = rbtnIsCreateTrue.Checked ? 1 : 0;
                dtuConfig.ConfigName = txtConfigName.Text.Trim();
                dtuConfig.ConfigDesc = txtConfigDesc.Text.Trim();
                dtuConfig.Status = 1;
                dtuConfig.UpdateFlag = curModel.UpdateFlag + 1;
                ServiceProxy.DTUServiceProxy.UpdateDtuConfig(LocalIP, dtuConfig);
                BindAllConfig();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改站点配置:ID-{0},Name-{1}", dtuConfig.ConfigCode, dtuConfig.ConfigName), 1);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            curModel = null;
            ClearForm();
        }

        private void ClearForm()
        {
            txtConfigName.Text = "";
            txtConfigDesc.Text = "";
            numUDFlowNum.Value = 3;
            numUDAINum.Value = 3;
            numUDDINum.Value = 3;
            rbtIsAlertTrue.Checked = true;
            rbtnIsCreateTrue.Checked = true;
        }

        private void numUDFlowNum_ValueChanged(object sender, EventArgs e)
        {
            this.txtConfigName.Text = string.Format("{0}流{1}模{2}开", int.Parse(numUDFlowNum.Value.ToString()), int.Parse(numUDAINum.Value.ToString()), int.Parse(numUDDINum.Value.ToString()));
            this.txtConfigDesc.Text = string.Format("{0}个流量计{1}个模拟量{2}个开关量", int.Parse(numUDFlowNum.Value.ToString()), int.Parse(numUDAINum.Value.ToString()), int.Parse(numUDDINum.Value.ToString()));
        }

        private void numUDAINum_ValueChanged(object sender, EventArgs e)
        {
            this.txtConfigName.Text = string.Format("{0}流{1}模{2}开", int.Parse(numUDFlowNum.Value.ToString()), int.Parse(numUDAINum.Value.ToString()), int.Parse(numUDDINum.Value.ToString()));
            this.txtConfigDesc.Text = string.Format("{0}个流量计{1}个模拟量{2}个开关量", int.Parse(numUDFlowNum.Value.ToString()), int.Parse(numUDAINum.Value.ToString()), int.Parse(numUDDINum.Value.ToString()));
        }

        private void numUDDINum_ValueChanged(object sender, EventArgs e)
        {
            this.txtConfigName.Text = string.Format("{0}流{1}模{2}开", int.Parse(numUDFlowNum.Value.ToString()), int.Parse(numUDAINum.Value.ToString()), int.Parse(numUDDINum.Value.ToString()));
            this.txtConfigDesc.Text = string.Format("{0}个流量计{1}个模拟量{2}个开关量", int.Parse(numUDFlowNum.Value.ToString()), int.Parse(numUDAINum.Value.ToString()), int.Parse(numUDDINum.Value.ToString()));
        }
    }
}
