using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;
using Com.Winfotian.Components.Enumerations;
using System.Linq;
using Com.Winfotian.ServiceProxy;

namespace Com.Winfotian.MngTool
{
    public partial class FrmCompany : FrmBase
    {
        ServiceProxy.CommonService.T_CityInfo CurCityInfo;//当前城市信息设为全局是为了替换地址栏里面已经组成的地址信息
        private int curFlag;
        private int orderId = -1;

        public FrmCompany()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载省级信息!");
                BindProvince(CommonServiceProxy.GetProvinceList(LocalIP));
                pbh.PopProgressBar("正在加载公司配置!");
                BindCompanyConfig();
                pbh.PopProgressBar("正在加载公司信息!");
                BindParentCompany();
                ClearForm();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("初始数据加载出错:" + ex.Message);
            }
        }
        private void BindParentCompany()
        {
            List<ServiceProxy.CompanyService.CompanyIDAndName> modelList = CompanyServiceProxy.GetCmpIdAndNameListBy(LocalIP, 0, null, 1);
            modelList.Insert(0, new ServiceProxy.CompanyService.CompanyIDAndName() { CompanyId = 0, CompanyName = "--无母公司--" });
            cbxParentCompany.DataSource = modelList;
            cbxParentCompany.DisplayMember = "CompanyName";
            cbxParentCompany.ValueMember = "CompanyId";
            cbxParentCompany.SelectedIndex = 0;
        }
        private void BindCompanyConfig()
        {
            List<ServiceProxy.CompanyService.T_Company_Config> comConfigList = CompanyServiceProxy.GetAllCmpConfigListByStatus(LocalIP, 1);
            if (comConfigList != null && comConfigList.Count > 0)
            {
                foreach (ServiceProxy.CompanyService.T_Company_Config item in comConfigList)
                {
                    ckList.Items.Add(new CheckedListBoxItem(item.ConfigName, item.ConfigId.ToString()));
                }
            }
        }
        /// <summary>
        /// 省份信息绑定//添加用
        /// </summary>
        /// <param name="lstProvince">省份信息列表</param>
        private void BindProvince(List<string> lstProvince)
        {
            cbxQProvince.SelectedIndexChanged -= new EventHandler(cbxQProvince_SelectedIndexChanged);
            foreach (string item in lstProvince)
            {
                cbxProvince.Items.Add(item);
                cbxQProvince.Items.Add(item);
            }
            cbxProvince.SelectedIndex = 0;
            cbxQProvince.Items.Insert(0, "--请选择--");
            cbxQProvince.SelectedIndex = 0;
            cbxQProvince.SelectedIndexChanged += new EventHandler(cbxQProvince_SelectedIndexChanged);
        }
        /// <summary>
        /// 地市信息绑定//添加用
        /// </summary>
        /// <param name="Province">省名称</param>
        private void BindCity(string Province)
        {
            cbxCity.DataSource = CommonServiceProxy.GetCityInfoList(LocalIP, Province);
            cbxCity.DisplayMember = "CityName";
            cbxCity.ValueMember = "CityID";
        }
        /// <summary>
        /// 地市信息绑定//查询用
        /// </summary>
        /// <param name="Province">省名称</param>
        private void BindQCity(string Province)
        {
            cbxQCity.DataSource = CommonServiceProxy.GetCityInfoList(LocalIP, Province);
            cbxQCity.DisplayMember = "CityName";
            cbxQCity.ValueMember = "CityID";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ServiceProxy.CommonService.EnumExistsStatus flag;
            string valiStr = ValidateFormInput(true, out flag);
            if (!string.IsNullOrEmpty(valiStr))
            {
                MessageBox.Show(valiStr, "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存站点数据!");
                int CompanyID;
                //公司基本信息添加
                ServiceProxy.CompanyService.T_Company company = new ServiceProxy.CompanyService.T_Company();
                company.CityId = int.Parse(cbxCity.SelectedValue.ToString());
                company.CmpAddress = cbxProvince.Text + cbxCity.Text + txtCmpAddress.Text.Trim();
                company.OrderId = CompanyServiceProxy.GetCompanyOrderIDByCityID(LocalIP, company.CityId);
                company.CmpDesc = txtCmpDesc.Text.Trim();
                company.CmpEmail = txtCmpEmail.Text.Trim();
                company.CmpMobile = txtCmpMobile.Text.Trim();
                company.CmpTel = txtCmpTel.Text.Trim();
                company.CmpWebSite = txtCmpWebSite.Text.Trim();
                company.CompanyName = txtCompanyName.Text.Trim();
                company.FaxTel = txtFaxTel.Text.Trim();
                company.LinkPerson = txtLinkPerson.Text.Trim();
                company.Status = 1;
                company.ParentId = Convert.ToInt32(cbxParentCompany.SelectedValue);
                if (flag == ServiceProxy.CommonService.EnumExistsStatus.Invalid)//如果此公司名字在数据库存在并且无效
                {
                    CompanyID = CompanyServiceProxy.UpdateCompany(LocalIP, company);
                }
                else
                {
                    CompanyID = CompanyServiceProxy.AddCompany(LocalIP, company);
                }
                List<KeyValuePair<int, int>> companyConfigs = new List<KeyValuePair<int, int>>();
                for (int i = 0; i < ckList.Items.Count; i++)
                {
                    if (ckList.GetItemChecked(i))
                    {
                        companyConfigs.Add(new KeyValuePair<int, int>(CompanyID, int.Parse((ckList.Items[i] as CheckedListBoxItem).Value)));
                    }
                }
                //公司分组部门关系表信息添加
                List<ServiceProxy.CompanyService.T_User_Group> userGroupList = new List<ServiceProxy.CompanyService.T_User_Group>();
                ServiceProxy.CompanyService.T_User_Group userGroup0 = new ServiceProxy.CompanyService.T_User_Group();
                userGroup0 = new ServiceProxy.CompanyService.T_User_Group();
                userGroup0.CompanyId = CompanyID;
                userGroup0.GroupCode = CompanyID.ToString() + "_FZ_" + DateTime.Now.ToString("yyMMddHHmmssff");//公司编号_FZ_自增长
                userGroup0.GroupDesc = "燃气公司";
                userGroup0.GroupName = "燃气公司";
                userGroup0.ParentCode = "0";
                userGroup0.Status = 1;
                userGroup0.UpdateFlag = 1;
                userGroupList.Add(userGroup0);
                ServiceProxy.CompanyService.T_User_Group userGroup1 = new ServiceProxy.CompanyService.T_User_Group();
                userGroup1 = new ServiceProxy.CompanyService.T_User_Group();
                userGroup1.CompanyId = CompanyID;
                userGroup1.GroupCode = CompanyID.ToString() + "_FZ_" + DateTime.Now.ToString("yyMMddHHmmssff") + new Random(DateTime.Now.Millisecond).Next(99);//公司编号_FZ_自增长
                userGroup1.GroupDesc = "运维组";
                userGroup1.GroupName = "运维组";
                userGroup1.ParentCode = userGroupList[0].GroupCode;
                userGroup1.Status = 1;
                userGroup1.UpdateFlag = 1;
                userGroupList.Add(userGroup1);
                //公司站点分组关系信息添加
                ServiceProxy.CompanyService.T_DTU_Group dtuGroup = new ServiceProxy.CompanyService.T_DTU_Group();
                dtuGroup.CompanyId = CompanyID;
                dtuGroup.GroupCode = CompanyID.ToString() + "_default_01";
                dtuGroup.GroupDesc = "默认分组";
                dtuGroup.GroupName = "默认分组";
                dtuGroup.ParentCode = "0";
                dtuGroup.Status = 1;
                dtuGroup.UpdateFlag = 1;
                CompanyServiceProxy.AddDefaultUserGroupAndDtuGroup(LocalIP, userGroupList, dtuGroup, companyConfigs);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加公司:ID-{0},Name-{1}", company.CompanyId, company.CompanyName), 1);
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

        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity(cbxProvince.Text);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("加载查询的公司数据!");
                int cityID = cbxQCity.SelectedItem == null ? 0 : (cbxQCity.SelectedItem as ServiceProxy.CommonService.CityInfo).CityID;
                dgvCompanyList.DataSource = CompanyServiceProxy.GetCmpIdAndNameListBy(LocalIP, cityID, txtQCompanyName.Text.Trim(), 1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.PopProgressBar("加载查询的公司数据出错:" + ex.Message);
                pbh.CloseProgressBar();
            }
        }

        private void cbxQProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindQCity(cbxQProvince.Text);
        }

        private void dgvCompanyList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCompanyList.SelectedRows[0];
            var model = row.DataBoundItem as ServiceProxy.CompanyService.CompanyIDAndName;
            ServiceProxy.CompanyService.T_Company Company = CompanyServiceProxy.GetCompanyById(LocalIP, model.CompanyId);
            if (Company != null)
            {
                CurCityInfo = ServiceProxy.CommonServiceProxy.GetCityInfoByCityId(LocalIP, Company.CityId);
                txtCmpAddress.Text = Company.CmpAddress;
                txtCmpDesc.Text = Company.CmpDesc;
                txtCmpEmail.Text = Company.CmpEmail;
                txtCmpMobile.Text = Company.CmpMobile;
                txtCmpTel.Text = Company.CmpTel;
                txtCmpWebSite.Text = Company.CmpWebSite;
                txtCompanyName.Text = Company.CompanyName;
                txtFaxTel.Text = Company.FaxTel;
                txtLinkPerson.Text = Company.LinkPerson;
                cbxProvince.Text = CurCityInfo.Province;
                if (Company.ParentId <= 0)
                {
                    cbxParentCompany.SelectedIndex = 0;
                }
                else
                {
                    cbxParentCompany.SelectedValue = Company.ParentId;
                }
                List<ServiceProxy.CompanyService.T_Company_CmpConfig> modelList = CompanyServiceProxy.GetCompanyCmpConfigs(LocalIP, model.CompanyId);
                for (int i = 0; i < ckList.Items.Count; i++)
                {
                    if (modelList.Any(p => p.ConfigId == int.Parse((ckList.Items[i] as CheckedListBoxItem).Value)))
                    {
                        ckList.SetItemChecked(i, true);
                    }
                    else
                    {
                        ckList.SetItemChecked(i, false);
                    }
                }
                cbxCity.Text = CurCityInfo.CityName;
                curFlag = Company.UpdateFlag;
                orderId = Company.OrderId;
                btnSave.Enabled = false;
                btnMod.Enabled = true;
                btnDel.Enabled = true;
                btnCancel.Enabled = true;
            }
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
            txtCmpAddress.Text = "四川省成都市青羊区XX街XX号";
            txtCmpDesc.Text = "公司成立于，主营：，规模：，注册资金：，拥有员工：。";
            txtCmpEmail.Text = "support@winfotian.com";
            txtCmpMobile.Text = "";
            txtCmpTel.Text = "028-61100111";
            txtCmpWebSite.Text = "http://www.winfotian.com";
            txtCompanyName.Text = "XXX地区+燃气有限公司";
            txtFaxTel.Text = "028-61100111";
            txtLinkPerson.Text = "经理/部长/领导";
            cbxProvince.SelectedIndex = 0;
            cbxCity.SelectedIndex = 0;
            curFlag = 1;
            orderId = -1;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            ServiceProxy.CommonService.EnumExistsStatus flag;
            string valiStr = ValidateFormInput(false, out flag);
            if (!string.IsNullOrEmpty(valiStr))
            {
                MessageBox.Show(valiStr, "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存修改的站点数据!");
                //公司基本信息修改
                DataGridViewRow row = dgvCompanyList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.CompanyService.CompanyIDAndName;

                ServiceProxy.CompanyService.T_Company company = new ServiceProxy.CompanyService.T_Company();
                company.CompanyId = model.CompanyId;
                company.CityId = int.Parse(cbxCity.SelectedValue.ToString());
                company.CmpAddress = txtCmpAddress.Text.Replace(CurCityInfo.Province, cbxProvince.Text).Replace(CurCityInfo.CityName, cbxCity.Text);
                if (orderId != -1)
                    company.OrderId = orderId;
                company.CmpDesc = txtCmpDesc.Text.Trim();
                company.CmpEmail = txtCmpEmail.Text.Trim();
                company.CmpMobile = txtCmpMobile.Text.Trim();
                company.CmpTel = txtCmpTel.Text.Trim();
                company.CmpWebSite = txtCmpWebSite.Text.Trim();
                company.CompanyName = txtCompanyName.Text.Trim();
                company.FaxTel = txtFaxTel.Text.Trim();
                company.LinkPerson = txtLinkPerson.Text.Trim();
                company.ParentId = Convert.ToInt32(cbxParentCompany.SelectedValue);
                List<KeyValuePair<int, int>> companyConfigs = new List<KeyValuePair<int, int>>();
                for (int i = 0; i < ckList.Items.Count; i++)
                {
                    if (ckList.GetItemChecked(i))
                    {
                        companyConfigs.Add(new KeyValuePair<int, int>(model.CompanyId, int.Parse((ckList.Items[i] as CheckedListBoxItem).Value)));
                    }
                }
                company.Status = 1;
                company.UpdateFlag = curFlag + 1;
                CompanyServiceProxy.UpdateCompanyAndConfig(LocalIP, company, companyConfigs);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改公司:ID-{0},Name-{1}", company.CompanyId, company.CompanyName), 1);
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
            try
            {
                DataGridViewRow row = dgvCompanyList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.CompanyService.CompanyIDAndName;
                if (new FrmDelCompanyConfirm(model.CompanyId).ShowDialog() == DialogResult.OK)
                {
                    ClearForm();
                    btnQuery_Click(null, null);
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除公司:ID-{0},Name-{1}", model.CompanyId, model.CompanyName), 1);
                    MessageBox.Show("删除成功!");
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                MessageBox.Show("删除失败:" + ex.Message);
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            new FrmCompanyConfig().ShowDialog();
            BindCompanyConfig();
        }
        private string ValidateFormInput(bool valiExists, out ServiceProxy.CommonService.EnumExistsStatus flag)
        {
            string valiStr = string.Empty;
            flag = ServiceProxy.CommonService.EnumExistsStatus.NotExists;
            if (valiExists)
            {
                flag = CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_Company]", "CompanyName", txtCompanyName.Text.Trim());
                if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
                {
                    valiStr += "这个公司名称已经存在!\n";
                }
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text))
                valiStr = "公司名称不能为空!\n";
            if (string.IsNullOrEmpty(txtLinkPerson.Text))
                valiStr += "联系人名称不能为空!\n";
            if (!ToolHelper.IsTelNumber(txtCmpTel.Text))
                valiStr += "请填写正确的电话号码!格式:区号-号码,例如:028-1234567!\n";
            if (!ToolHelper.IsNumber(txtCmpMobile.Text.Trim()))
                valiStr += "请填写正确的移动电话号码!\n";
            if (!ToolHelper.IsEmail(txtCmpEmail.Text))
                valiStr += "请填写正确的邮件信息!\n";
            if (ckList.CheckedItems.Count == 0)
                valiStr += "请选择公司配置信息!\n";
            return valiStr;
        }
    }
}
