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
    public partial class FrmOdorDtuConfig : FrmBase
    {
        ServiceProxy.DTUService.OdorDTUConfig curModel = null;
        string configCode = string.Empty;
        public FrmOdorDtuConfig()
        {
            InitializeComponent();
            cbxBoardNum.SelectedIndex = 0;
            BuidConfigName();
            BindAllConfig();
        }
        private void BindAllConfig()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载站点配置数据!");
                dgvDtuConfigList.DataSource = ServiceProxy.DTUServiceProxy.GetOdorDtuConfigsByStatus(LocalIP, 1);
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
                ServiceProxy.DTUService.OdorDTUConfig dtuConfig = new ServiceProxy.DTUService.OdorDTUConfig();
                dtuConfig.ConfigCode = configCode;
                dtuConfig.ConfigName = txtConfigName.Text.Trim();
                dtuConfig.ConfigDesc = txtConfigDesc.Text.Trim();
                dtuConfig.AINum = int.Parse(numUDAINum.Value.ToString());
                dtuConfig.FlowNum = int.Parse(numUDFlowNum.Value.ToString());
                dtuConfig.DINum = int.Parse(numUDDINum.Value.ToString());
                dtuConfig.IsAlert = rbtIsAlertTrue.Checked ? 1 : 0;
                dtuConfig.IsCreate = rbtnIsCreateTrue.Checked ? 1 : 0;
                ServiceProxy.CommonService.EnumExistsStatus flag = ServiceProxy.CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_DTU_Config]", "ConfigCode", dtuConfig.ConfigCode);
                if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
                {
                    pbh.CloseProgressBar();
                    MessageBox.Show("这个配置编号已经存在!");
                    return;
                }
                dtuConfig.Status = 1;
                dtuConfig.UpdateFlag = 1;
                int boardNum = Convert.ToInt32(cbxBoardNum.SelectedItem);
                dtuConfig.BoardInfo = new Dictionary<int, int>();
                switch (boardNum)
                {
                    case 1:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        break;
                    case 2:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        dtuConfig.BoardInfo.Add(2, Convert.ToInt32(nudB2JztNum.Value));
                        break;
                    case 3:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        dtuConfig.BoardInfo.Add(2, Convert.ToInt32(nudB2JztNum.Value));
                        dtuConfig.BoardInfo.Add(3, Convert.ToInt32(nudB3JztNum.Value));
                        break;
                    case 4:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        dtuConfig.BoardInfo.Add(2, Convert.ToInt32(nudB2JztNum.Value));
                        dtuConfig.BoardInfo.Add(3, Convert.ToInt32(nudB3JztNum.Value));
                        dtuConfig.BoardInfo.Add(4, Convert.ToInt32(nudB4JztNum.Value));
                        break;
                    default:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        break;
                }
                ServiceProxy.DTUServiceProxy.AddOdorDtuConfig(LocalIP, dtuConfig);
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
            curModel = row.DataBoundItem as ServiceProxy.DTUService.OdorDTUConfig;
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
            cbxBoardNum.SelectedIndex = curModel.BoardInfo.Count - 1;
            switch (curModel.BoardInfo.Count)
            {
                case 1:
                    nudB1JztNum.Value = curModel.BoardInfo[1];
                    break;
                case 2:
                    nudB1JztNum.Value = curModel.BoardInfo[1];
                    nudB2JztNum.Value = curModel.BoardInfo[2];
                    break;
                case 3:
                    nudB1JztNum.Value = curModel.BoardInfo[1];
                    nudB2JztNum.Value = curModel.BoardInfo[2];
                    nudB3JztNum.Value = curModel.BoardInfo[3];
                    break;
                case 4:
                    nudB1JztNum.Value = curModel.BoardInfo[1];
                    nudB2JztNum.Value = curModel.BoardInfo[2];
                    nudB3JztNum.Value = curModel.BoardInfo[3];
                    nudB4JztNum.Value = curModel.BoardInfo[4];
                    break;
                default:
                    nudB1JztNum.Value = curModel.BoardInfo[1];
                    break;
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
                var model = row.DataBoundItem as ServiceProxy.DTUService.OdorDTUConfig;
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
                ServiceProxy.DTUService.OdorDTUConfig dtuConfig = new ServiceProxy.DTUService.OdorDTUConfig();
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
                dtuConfig.BoardInfo = new Dictionary<int, int>();
                int boardNum = Convert.ToInt32(cbxBoardNum.SelectedItem);
                switch (boardNum)
                {
                    case 1:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        break;
                    case 2:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        dtuConfig.BoardInfo.Add(2, Convert.ToInt32(nudB2JztNum.Value));
                        break;
                    case 3:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        dtuConfig.BoardInfo.Add(2, Convert.ToInt32(nudB2JztNum.Value));
                        dtuConfig.BoardInfo.Add(3, Convert.ToInt32(nudB3JztNum.Value));
                        break;
                    case 4:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        dtuConfig.BoardInfo.Add(2, Convert.ToInt32(nudB2JztNum.Value));
                        dtuConfig.BoardInfo.Add(3, Convert.ToInt32(nudB3JztNum.Value));
                        dtuConfig.BoardInfo.Add(4, Convert.ToInt32(nudB4JztNum.Value));
                        break;
                    default:
                        dtuConfig.BoardInfo.Add(1, Convert.ToInt32(nudB1JztNum.Value));
                        break;
                }
                ServiceProxy.DTUServiceProxy.UpdateOdorDtuConfig(LocalIP, dtuConfig);
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
            numUDFlowNum.Value = 3;
            numUDAINum.Value = 3;
            numUDDINum.Value = 3;
            cbxBoardNum.SelectedIndex = 0;
            rbtIsAlertTrue.Checked = true;
            rbtnIsCreateTrue.Checked = true;
            BuidConfigName();
        }

        private void numUDFlowNum_ValueChanged(object sender, EventArgs e)
        {
            BuidConfigName();
        }

        private void numUDAINum_ValueChanged(object sender, EventArgs e)
        {
            BuidConfigName();
        }

        private void numUDDINum_ValueChanged(object sender, EventArgs e)
        {
            BuidConfigName();
        }

        private void cbxBoardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxBoardNum.SelectedIndex)
            {
                case 0:
                    gBoard1.Visible = true;
                    gBoard2.Visible = false;
                    gBoard3.Visible = false;
                    gBoard4.Visible = false;
                    break;
                case 1:
                    gBoard1.Visible = true;
                    gBoard2.Visible = true;
                    gBoard3.Visible = false;
                    gBoard4.Visible = false;
                    break;
                case 2:
                    gBoard1.Visible = true;
                    gBoard2.Visible = true;
                    gBoard3.Visible = true;
                    gBoard4.Visible = false;
                    break;
                case 3:
                    gBoard1.Visible = true;
                    gBoard2.Visible = true;
                    gBoard3.Visible = true;
                    gBoard4.Visible = true;
                    break;
            }
            BuidConfigName();
        }
        private void BuidConfigName()
        {
            int boardNum = Convert.ToInt32(cbxBoardNum.SelectedItem);
            switch (boardNum)
            {
                case 1:
                    configCode = string.Format("PZ_{0}{1}{2}{3}{4}{5}{6}", 1, nudB1JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value, rbtIsAlertTrue.Checked ? 1 : 0, rbtnIsCreateTrue.Checked ? 1 : 0);
                    txtConfigName.Text = string.Format("{0}面{1}加{2}流{3}模{4}开", 1, nudB1JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    txtConfigDesc.Text = string.Format("{0}面板{1}加注头{2}个流量计{3}个模拟量{4}个开关量", 1, nudB1JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    break;
                case 2:
                    configCode = string.Format("PZ_{0}{1}{2}{3}{4}{5}{6}{7}{8}", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, numUDFlowNum.Value, numUDAINum.Value,
                                 numUDDINum.Value, rbtIsAlertTrue.Checked ? 1 : 0, rbtnIsCreateTrue.Checked ? 1 : 0);
                    txtConfigName.Text = string.Format("{0}面{1}加{2}面{3}加{4}流{5}模{6}开", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    txtConfigDesc.Text = string.Format("{0}面板{1}加注头{2}面板{3}加注头{4}个流量计{5}个模拟量{6}个开关量", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    break;
                case 3:
                    configCode = string.Format("PZ_{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, 3, nudB3JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value, rbtIsAlertTrue.Checked ? 1 : 0, rbtnIsCreateTrue.Checked ? 1 : 0);
                    txtConfigName.Text = string.Format("{0}面{1}加{2}面{3}加{4}面{5}加{6}流{7}模{8}开", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, 3, nudB3JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    txtConfigDesc.Text = string.Format("{0}面板{1}加注头{2}面板{3}加注头{4}面板{5}加注头{6}个流量计{7}个模拟量{8}个开关量", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, 3, nudB3JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    break;
                case 4:
                    configCode = string.Format("PZ_{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, 3, nudB3JztNum.Value, 4, nudB4JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value, rbtIsAlertTrue.Checked ? 1 : 0, rbtnIsCreateTrue.Checked ? 1 : 0);
                    txtConfigName.Text = string.Format("{0}面{1}加{2}面{3}加{4}面{5}加{6}面{7}加{8}流{9}模{10}开", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, 3, nudB3JztNum.Value, 4, nudB4JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    txtConfigDesc.Text = string.Format("{0}面板{1}加注头{2}面板{3}加注头{4}面板{5}加注头{6}面板{7}加注头{8}个流量计{9}个模拟量{10}个开关量", 1, nudB1JztNum.Value, 2, nudB2JztNum.Value, 3, nudB3JztNum.Value, 4, nudB4JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    break;
                default:
                    configCode = string.Format("PZ_{0}{1}{2}{3}{4}{5}{6}", 1, nudB1JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value, rbtIsAlertTrue.Checked ? 1 : 0, rbtnIsCreateTrue.Checked ? 1 : 0);
                    txtConfigName.Text = string.Format("{0}面{1}加{2}流{3}模{4}开", 1, nudB1JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    txtConfigDesc.Text = string.Format("{0}面板{1}加注头{2}个流量计{3}个模拟量{4}个开关量", 1, nudB1JztNum.Value, numUDFlowNum.Value, numUDAINum.Value, numUDDINum.Value);
                    break;
            }
        }

        private void nudB1JztNum_ValueChanged(object sender, EventArgs e)
        {
            BuidConfigName();
        }

        private void nudB2JztNum_ValueChanged(object sender, EventArgs e)
        {
            BuidConfigName();
        }

        private void nudB3JztNum_ValueChanged(object sender, EventArgs e)
        {
            BuidConfigName();
        }

        private void nudB4JztNum_ValueChanged(object sender, EventArgs e)
        {
            BuidConfigName();
        }
    }
}
