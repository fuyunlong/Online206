using System;
using System.Linq;
using System.Windows.Forms;
using Com.Winfotian.Common;
using System.Collections.Generic;

namespace Com.Winfotian.MngTool
{
    public partial class FrmCompanyConfig : FrmBase
    {
        private int curFlag;
        public FrmCompanyConfig()
        {
            InitializeComponent();
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载用户配置数据");
                BindAllConfig();
                BindClientTypeList();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("加载数据失败:" + ex.Message);
            }
        }
        private void BindAllConfig()
        {
            dgvCompanyConfig.DataSource = ServiceProxy.CompanyServiceProxy.GetAllCmpConfigListByStatus(LocalIP, 1);
            dgvCompanyConfig.ClearSelection();
        }
        private void BindClientTypeList()
        {
            List<CheckedListBoxItem> dataSource = new List<CheckedListBoxItem>();
            var Enums = Enum.GetValues(typeof(Com.Winfotian.Enumerations.ClientType)).OfType<Com.Winfotian.Enumerations.ClientType>();
            string text = string.Empty;
            foreach (Com.Winfotian.Enumerations.ClientType item in Enums)
            {
                text = EnumHelper.GetEnumDescrptionByKey<Com.Winfotian.Enumerations.ClientType>(item.ToString());
                dataSource.Add(new CheckedListBoxItem(text, ((int)item).ToString()));
            }
            drp_Type.DataSource = dataSource;
            drp_Type.DisplayMember = "Text";
            drp_Type.ValueMember = "Value";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfigName.Text))
            {
                MessageBox.Show("配置名称不能为空!");
                return;
            }
            if (!Regexlib.IsValidIp(txtIP.Text.Trim()))
            {
                MessageBox.Show("请填写正确的IP格式,例如:192.168.1.1");
                return;
            }
            if (!ToolHelper.IsNumber(txtPort.Text.Trim()))
            {
                MessageBox.Show("端口号必须是纯数字!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存公司配置数据");
                ServiceProxy.CompanyService.T_Company_Config comConfig = new ServiceProxy.CompanyService.T_Company_Config();
                comConfig.ConfigDesc = txtConfigDesc.Text.Trim();
                comConfig.ConfigName = txtConfigName.Text.Trim();
                comConfig.IP = txtIP.Text.Trim();
                comConfig.Port = int.Parse(txtPort.Text.Trim());
                comConfig.Status = 1;
                comConfig.ClientType = int.Parse((drp_Type.SelectedItem as CheckedListBoxItem).Value);
                comConfig.ClientNum = int.Parse(txt_Num.Text.Trim());
                ServiceProxy.CompanyServiceProxy.AddCompanyConfig(LocalIP, comConfig);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加公司配置:ID-{0},Name-{1}", comConfig.ConfigId, comConfig.ConfigName), 1);
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

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfigName.Text))
            {
                MessageBox.Show("配置名称不能为空!");
                return;
            }
            if (!Regexlib.IsValidIp(txtIP.Text.Trim()))
            {
                MessageBox.Show("请填写正确的IP格式,例如:192.168.1.1");
                return;
            }
            if (!ToolHelper.IsNumber(txtPort.Text.Trim()))
            {
                MessageBox.Show("端口号必须是纯数字!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改公司配置数据");
                DataGridViewRow row = dgvCompanyConfig.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.CompanyService.T_Company_Config;
                ServiceProxy.CompanyService.T_Company_Config comConfig = new ServiceProxy.CompanyService.T_Company_Config();
                comConfig.ConfigId = model.ConfigId;
                comConfig.ConfigDesc = txtConfigDesc.Text.Trim();
                comConfig.ConfigName = txtConfigName.Text.Trim();
                comConfig.IP = txtIP.Text.Trim();
                comConfig.Port = int.Parse(txtPort.Text.Trim());
                comConfig.Status = 1;
                comConfig.ClientType = int.Parse((drp_Type.SelectedItem as CheckedListBoxItem).Value);
                comConfig.ClientNum = int.Parse(txt_Num.Text.Trim());
                comConfig.UpdateFlag = curFlag + 1;
                if (ServiceProxy.CompanyServiceProxy.UpdateCompanyConfig(LocalIP, comConfig))
                {
                    ClearForm();
                    BindAllConfig();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改公司配置:ID-{0},Name-{1}", comConfig.ConfigId, comConfig.ConfigName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    ClearForm();
                    BindAllConfig();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改公司配置:ID-{0},Name-{1}", comConfig.ConfigId, comConfig.ConfigName), 2);
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
                pbh.PopProgressBar("正在删除公司配置数据");
                DataGridViewRow row = dgvCompanyConfig.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.CompanyService.T_Company_Config;
                ServiceProxy.CompanyServiceProxy.DeleteCompanyConfig(LocalIP, model.ConfigId);
                BindAllConfig();
                ClearForm();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除公司配置:ID-{0},Name-{1}", model.ConfigId, model.ConfigName), 1);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            ClearForm();
        }

        private void dgvCompanyConfig_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCompanyConfig.SelectedRows[0];
            var model = row.DataBoundItem as ServiceProxy.CompanyService.T_Company_Config;

            txtConfigName.Text = model.ConfigName;
            txtConfigDesc.Text = model.ConfigDesc;
            txtIP.Text = model.IP;
            txtPort.Text = model.Port.ToString();
            drp_Type.SelectedValue = model.ClientType.ToString();
            txt_Num.Text = model.ClientNum.ToString();
            curFlag = model.UpdateFlag.Value;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
        }
        private void ClearForm()
        {
            drp_Type.SelectedIndex = 0;
            txtConfigName.Text = "";
            txtConfigDesc.Text = "";
            txtIP.Text = "";
            txtPort.Text = "";
            txt_Num.Text = "1";
        }
    }
}
