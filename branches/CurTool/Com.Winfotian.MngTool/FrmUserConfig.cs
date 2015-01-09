using System;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;
using Com.Winfotian.Components.Enumerations;
using System.Linq;
using System.Globalization;

namespace Com.Winfotian.MngTool
{
    public partial class FrmUserConfig : FrmBase
    {
        ServiceProxy.UserService.T_User_Config curModel;
        public FrmUserConfig()
        {
            InitializeComponent();
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载用户配置数据");
                BindAllConfig();
                BindCheckListBox();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("加载数据失败:" + ex.Message);
            }
        }
        private void BindCheckListBox()
        {
            var Enums = Enum.GetValues(typeof(Com.Winfotian.Enumerations.ClientType)).OfType<Com.Winfotian.Enumerations.ClientType>();
            string text = string.Empty;
            foreach (Com.Winfotian.Enumerations.ClientType item in Enums)
            {
                text = EnumHelper.GetEnumDescrptionByKey<Com.Winfotian.Enumerations.ClientType>(item.ToString());
                ckList.Items.Add(new CheckedListBoxItem(text, ((int)item).ToString()));
            }
        }
        private void BindAllConfig()
        {
            dgvUserConfigList.DataSource = ServiceProxy.UserServiceProxy.GetUserConfigsByStatus(LocalIP, 1);
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
                pbh.PopProgressBar("正在保存用户配置数据");
                ServiceProxy.UserService.T_User_Config userConfig = new ServiceProxy.UserService.T_User_Config();
                userConfig.ConfigName = txtConfigName.Text.Trim();
                userConfig.ConfigDesc = txtConfigDesc.Text.Trim();
                userConfig.IsAlert = rbtnIsAlertTrue.Checked ? 1 : 0;
                userConfig.IsRpt = rbtnIsRptTrue.Checked ? 1 : 0;
                string popCode = string.Empty;

                for (int i = 0; i < ckList.Items.Count; i++)
                {
                    if (ckList.GetItemChecked(i))
                    {
                        popCode += (ckList.Items[i] as CheckedListBoxItem).Value + ",";
                    }
                }
                userConfig.PopCode = popCode.TrimEnd(',');
                userConfig.CCode = "PZ_" + userConfig.IsAlert.ToString() + DateTime.Now.ToString("yyMMddHHmmssffff");
                ServiceProxy.CommonService.EnumExistsStatus flag = ServiceProxy.CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_User_Config]", "CCode", userConfig.CCode);
                if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
                {
                    MessageBox.Show("这个配置编号已经存在!");
                    return;
                }
                userConfig.SoftInterval = int.Parse(numUDSoftInterval.Value.ToString());
                userConfig.Status = 1;
                userConfig.UpdateFlag = 1;
                ServiceProxy.UserServiceProxy.AddUserConfig(LocalIP, userConfig);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加用户配置:ID-{0},Name-{1}", userConfig.CCode, userConfig.ConfigName), 1);
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

        private void dgvUserConfigList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearForm();
            DataGridViewRow row = dgvUserConfigList.SelectedRows[0];
            curModel = row.DataBoundItem as ServiceProxy.UserService.T_User_Config;
            txtConfigName.Text = curModel.ConfigName;
            txtConfigDesc.Text = curModel.ConfigDesc;
            numUDSoftInterval.Value = curModel.SoftInterval;
            if (curModel.IsRpt == 1)
            {
                rbtnIsRptTrue.Checked = true;
            }
            else
            {
                rbtnIsRptFalse.Checked = true;
            }
            if (curModel.IsAlert == 1)
            {
                rbtnIsAlertTrue.Checked = true;
            }
            else
            {
                rbtnIsAlertFalse.Checked = true;
            }
            string popCode = curModel.PopCode;
            for (int i = 0; i < ckList.Items.Count; i++)
            {
                if (popCode.Contains((ckList.Items[i] as CheckedListBoxItem).Value))
                {
                    ckList.SetItemChecked(i, true);
                }
            }
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (curModel == null)
            {
                MessageBox.Show("请双击选择要修改的数据行!");
                return;
            }
            if (string.IsNullOrEmpty(txtConfigName.Text))
            {
                MessageBox.Show("配置名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改用户配置数据");

                ServiceProxy.UserService.T_User_Config userConfig = new ServiceProxy.UserService.T_User_Config();
                userConfig.CCode = curModel.CCode;
                userConfig.ConfigName = txtConfigName.Text.Trim();
                userConfig.ConfigDesc = txtConfigDesc.Text.Trim();
                userConfig.IsAlert = rbtnIsAlertTrue.Checked ? 1 : 0;
                userConfig.IsRpt = rbtnIsRptTrue.Checked ? 1 : 0;
                userConfig.SoftInterval = int.Parse(numUDSoftInterval.Value.ToString());
                string popCode = string.Empty;

                for (int i = 0; i < ckList.Items.Count; i++)
                {
                    if (ckList.GetItemChecked(i))
                    {
                        popCode += (ckList.Items[i] as CheckedListBoxItem).Value + ",";
                    }
                }
                userConfig.PopCode = popCode.TrimEnd(',');
                userConfig.Status = 1;
                userConfig.UpdateFlag = curModel.UpdateFlag + 1;
                if (ServiceProxy.UserServiceProxy.UpdateUserConfig(LocalIP, userConfig))
                {
                    ClearForm();
                    BindAllConfig();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改用户配置:ID-{0},Name-{1}", userConfig.CCode, userConfig.ConfigName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    ClearForm();
                    BindAllConfig();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改用户配置:ID-{0},Name-{1}", userConfig.CCode, userConfig.ConfigName), 2);
                    pbh.CloseProgressBar();
                    MessageBox.Show("修改失败!");
                }
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
                pbh.PopProgressBar("正在删除用户配置数据");
                DataGridViewRow row = dgvUserConfigList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.UserService.T_User_Config;

                if (ServiceProxy.UserServiceProxy.DeleteUserConfigById(LocalIP, model.CCode))
                {
                    BindAllConfig();
                    ClearForm();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除用户配置:ID-{0},Name-{1}", model.CCode, model.ConfigName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("删除成功!");
                }
                else
                {
                    BindAllConfig();
                    ClearForm();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除用户配置:ID-{0},Name-{1}", model.CCode, model.ConfigName), 2);
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
            for (int i = 0; i < ckList.Items.Count; i++)
            {
                ckList.SetItemChecked(i, false);
            }
            rbtnIsAlertTrue.Checked = true;
            rbtnIsRptTrue.Checked = false;
            numUDSoftInterval.Value = 120;
        }
    }
}
