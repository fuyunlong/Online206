using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public partial class FrmImportantDevice : FrmBase
    {
        ServiceProxy.DTUService.T_DTU_Device curModel = null;
        public FrmImportantDevice()
        {
            InitializeComponent();
            CompanyBind();
        }
        /// <summary>
        /// 绑定公司数据源
        /// </summary>
        private void CompanyBind()
        {
            List<ServiceProxy.CompanyService.CompanyIDAndName> Companylist = ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
            List<ServiceProxy.CompanyService.CompanyIDAndName> ClonedCompanyList = new List<ServiceProxy.CompanyService.CompanyIDAndName>();
            foreach (ServiceProxy.CompanyService.CompanyIDAndName item in Companylist)
            {
                ClonedCompanyList.Add(item);
            }
            cbxQCompany.DataSource = Companylist;
            cbxQCompany.DisplayMember = "CompanyName";
            cbxQCompany.ValueMember = "CompanyId";
            cbxQCompany.SelectedIndex = 0;
            if (Companylist.Count > 0)
            {
                DTUQBind(Companylist[0].CompanyId);
            }

            cbxCompany.DataSource = ClonedCompanyList;
            cbxCompany.DisplayMember = "CompanyName";
            cbxCompany.ValueMember = "CompanyId";
        }
        /// <summary>
        /// 递归绑定站点分组数据源（查询用）
        /// </summary>
        /// <param name="dtTreeData">数据</param>
        /// <param name="parentCode">父编码</param>
        /// <param name="nodes">树节点</param>
        private void DTUQBind(int CompanyId)
        {
            var DataSource = ServiceProxy.DTUServiceProxy.GetDtuInfoWithGroup(LocalIP, CompanyId);
            cbxQDTU.DataSource = DataSource;
            cbxQDTU.DisplayMember = "DtuidName";
            cbxQDTU.ValueMember = "DtuId";
            cbxQDTU.SelectedIndex = 0;
        }
        private void DTUBind(int CompanyId)
        {
            var DataSource = ServiceProxy.DTUServiceProxy.GetDtuInfoWithGroup(LocalIP, CompanyId);
            cbxDtu.DataSource = DataSource;
            cbxDtu.DisplayMember = "DtuidName";
            cbxDtu.ValueMember = "DtuId";
            cbxDtu.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                if (string.IsNullOrEmpty(txtDeviceName.Text))
                {
                    MessageBox.Show("设备名称不能发为空!");
                    return;
                }
                pbh.PopProgressBar("正在保存站点数据!");
                ServiceProxy.DTUService.T_DTU_Device model = new ServiceProxy.DTUService.T_DTU_Device();
                model.Dtuid = cbxQDTU.SelectedValue.ToString();
                model.DeviceBrand = txtDeviceBrand.Text.Trim();
                model.DeviceName = txtDeviceName.Text.Trim();
                model.DeviceSN = txtDeviceSN.Text.Trim();
                model.ModelCode = txtSupplier.Text.Trim();
                model.DeviceSupplier = "";
                model.ProduceDate = dtpProductDate.Value;
                model.DeviceParams = txtParams.Text.Trim().Replace("\r\n", "<br />");
                model.Memo = txtRemark.Text.Trim();
                ServiceProxy.DTUServiceProxy.AddDtuDevice(LocalIP, model);
                BindQueryData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加重要设备:{0}", model.DeviceName), 1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("保存失败:" + ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存站点数据!");
                ServiceProxy.DTUService.T_DTU_Device model = new ServiceProxy.DTUService.T_DTU_Device();
                model.Id = curModel.Id;
                model.Dtuid = cbxDtu.SelectedValue.ToString();
                model.DeviceBrand = txtDeviceBrand.Text.Trim();
                model.DeviceName = txtDeviceName.Text.Trim();
                model.DeviceSN = txtDeviceSN.Text.Trim();
                model.DeviceParams = txtParams.Text.Trim().Replace("\r\n", "<br />");
                model.ModelCode = txtSupplier.Text.Trim();
                model.DeviceSupplier = "";
                model.ProduceDate = dtpProductDate.Value;
                model.Memo = txtRemark.Text.Trim();
                ServiceProxy.DTUServiceProxy.UpdateDtuDevice(LocalIP, model);
                BindQueryData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改重要设备:ID-{0},Name-{1}", model.Id, model.DeviceName), 1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("保存失败:" + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除所选站点数据!");
                DataGridViewRow row = dgvDtuList.SelectedRows[0];
                int Id = int.Parse(row.Cells["Id"].Value.ToString());
                ServiceProxy.DTUServiceProxy.DeleteDtuDeviceById(LocalIP, Id);
                ClearForm();
                BindQueryData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除重要设备:ID-{0},Name-{1}", Id), 1);
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
            curModel = null;
            ClearForm();
        }
        /// <summary>
        /// 
        /// </summary>
        private void ClearForm()
        {
            txtDeviceBrand.Text = "";
            txtDeviceName.Text = "";
            txtDeviceSN.Text = "";
            txtRemark.Text = "";
            txtSupplier.Text = "";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载查询的站点数据!");
                ClearForm();
                BindQueryData();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.PopProgressBar("加载查询的站点数据出错:" + ex.Message);
                pbh.CloseProgressBar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void BindQueryData()
        {
            if (cbxQDTU.SelectedIndex != -1)
            {
                dgvDtuList.DataSource = ServiceProxy.DTUServiceProxy.GetDtuDevicesByDtuid(LocalIP, cbxQDTU.SelectedValue.ToString());
            }
        }

        private void dgvDtuList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            curModel = dgvDtuList.CurrentRow.DataBoundItem as ServiceProxy.DTUService.T_DTU_Device;
            txtDeviceBrand.Text = curModel.DeviceBrand;
            txtDeviceName.Text = curModel.DeviceName;
            txtDeviceSN.Text = curModel.DeviceSN;
            txtRemark.Text = curModel.Memo;
            txtParams.Text = curModel.DeviceParams.Replace("<br />", "\r\n");
            txtSupplier.Text = curModel.ModelCode;
            dtpProductDate.Value = curModel.ProduceDate;
            cbxCompany.SelectedValue = cbxQCompany.SelectedValue;
            cbxDtu.SelectedValue = curModel.Dtuid;
            btnAdd.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void cbxQCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTUQBind((cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId);
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTUBind((cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId);
        }
    }
}
