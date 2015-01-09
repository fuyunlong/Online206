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
    public partial class FrmDtuGroup : FrmBase
    {
        ComboBoxTreeView cbTree;
        ServiceProxy.DTUService.T_DTU_Group curModel = null;
        public FrmDtuGroup()
        {
            InitializeComponent();
            cbTree = new ComboBoxTreeView();
            cbTree.Location = new System.Drawing.Point(256, 291);
            cbTree.Name = "cbxParentCode";
            cbTree.Size = new System.Drawing.Size(111, 20);
            cbTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbTree);
            CompanyBind();
        }
        /// <summary>
        /// 绑定公司数据源
        /// </summary>
        private void CompanyBind()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载站点分组数据!");
                //这里因为查询和添加用的数据源一样所以采取新建一个空数据源，然后再往里面插入数据一完成克隆数据源的作用
                List<ServiceProxy.CompanyService.CompanyIDAndName> Companylist = ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
                List<ServiceProxy.CompanyService.CompanyIDAndName> ClonedCompanyList = new List<ServiceProxy.CompanyService.CompanyIDAndName>();
                foreach (ServiceProxy.CompanyService.CompanyIDAndName item in Companylist)
                {
                    ClonedCompanyList.Add(item);
                }
                cbxCompany.DataSource = Companylist;
                cbxCompany.DisplayMember = "CompanyName";
                cbxCompany.ValueMember = "CompanyId";
                cbxQCompany.DataSource = ClonedCompanyList;
                cbxQCompany.DisplayMember = "CompanyName";
                cbxQCompany.ValueMember = "CompanyId";
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("删除失败:" + ex.Message);
            }
        }
        /// <summary>
        /// 绑定站点分组信息树形结构
        /// </summary>
        /// <param name="dtTreeData">数据DataTable</param>
        /// <param name="parentCode">父节点编码</param>
        /// <param name="nodes">父节点</param>
        private void BindTree(List<ServiceProxy.DTUService.T_DTU_Group> dtTreeData, string parentCode, TreeNode nodes)
        {
            if (nodes == null)
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    cbTree.TreeView.Nodes.Add(tNode);
                    BindTree(dtTreeData, tNode.Name, tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    nodes.Nodes.Add(tNode);
                    BindTree(dtTreeData, tNode.Name, tNode);
                }
            }
            cbTree.TreeView.ExpandAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGroupName.Text))
            {
                MessageBox.Show("分组名称不能为空!");
                return;
            }
            ServiceProxy.CommonService.EnumExistsStatus flag = ServiceProxy.CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_DTU_Group]", "GroupName", txtGroupName.Text.Trim());
            if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
            {
                MessageBox.Show("这个分组已经存在,请另外填写一个分组!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存站点分组数据!");
                ServiceProxy.DTUService.T_DTU_Group dtuGroup = new ServiceProxy.DTUService.T_DTU_Group();
                dtuGroup.GroupCode = "DFZ" + DateTime.Now.ToString("yyMMddHHmmssffff");
                dtuGroup.GroupName = txtGroupName.Text.Trim();
                dtuGroup.GroupDesc = txtGroupDesc.Text.Trim();
                if (cbTree.TreeView.SelectedNode != null)//如果不为null则为子节点
                {
                    dtuGroup.ParentCode = cbTree.TreeView.SelectedNode.Name;
                }
                else//否则根节点
                {
                    dtuGroup.ParentCode = "0";
                }
                dtuGroup.CompanyId = int.Parse(cbxCompany.SelectedValue.ToString());
                dtuGroup.Status = 1;
                dtuGroup.UpdateFlag = 1;
                ServiceProxy.DTUServiceProxy.AddDtuGroup(LocalIP, dtuGroup);
                BindQueryData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点分组:ID-{0},Name-{1}", dtuGroup.GroupCode, dtuGroup.GroupName), 1);
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
                pbh.PopProgressBar("正在查询站点分组数据!");
                BindQueryData();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("查询失败:" + ex.Message);
            }
        }

        private void BindQueryData()
        {
            int CompanyId = ((ServiceProxy.CompanyService.CompanyIDAndName)cbxQCompany.SelectedItem).CompanyId;
            List<ServiceProxy.DTUService.T_DTU_Group> userGroupList = ServiceProxy.DTUServiceProxy.GetDtuGroupsByCompanyId(LocalIP, CompanyId);
            dgvDtuGroupList.DataSource = userGroupList;
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCompany.SelectedItem != null)
            {
                int CompanyId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                var dtuGroups = ServiceProxy.DTUServiceProxy.GetDtuGroupsByCompanyId(LocalIP, CompanyId);
                cbTree.Items.Clear();
                cbTree.TreeView.Nodes.Clear();
                BindTree(dtuGroups, "0", null);
                if (dtuGroups.Count > 0)
                {
                    cbTree.TreeView.SelectedNode = cbTree.TreeView.Nodes[0];
                    cbTree.Items.Add(cbTree.TreeView.SelectedNode.Text);
                    cbTree.SelectedIndex = 0;
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGroupName.Text))
            {
                MessageBox.Show("分组名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改站点分组数据!");
                ServiceProxy.DTUService.T_DTU_Group dtuGroup = new ServiceProxy.DTUService.T_DTU_Group();
                dtuGroup.GroupCode = curModel.GroupCode;
                dtuGroup.GroupName = txtGroupName.Text.Trim();
                dtuGroup.GroupDesc = txtGroupDesc.Text.Trim();
                if (cbTree.TreeView.SelectedNode != null)
                {
                    dtuGroup.ParentCode = cbTree.TreeView.SelectedNode.Name;
                }
                else
                {
                    dtuGroup.ParentCode = "0";
                }
                dtuGroup.CompanyId = int.Parse(cbxCompany.SelectedValue.ToString());
                dtuGroup.Status = 1;
                dtuGroup.UpdateFlag = curModel.UpdateFlag + 1;
                ServiceProxy.DTUServiceProxy.UpdateDtuGroup(LocalIP, dtuGroup);
                btnQuery_Click(null, null);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改站点分组:ID-{0},Name-{1}", dtuGroup.GroupCode, dtuGroup.GroupName), 1);
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

        private void dgvUserGroupList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            DataGridViewRow row = dgvDtuGroupList.SelectedRows[0];
            curModel = row.DataBoundItem as ServiceProxy.DTUService.T_DTU_Group;
            cbxCompany.SelectedValue = curModel.CompanyId;
            List<ServiceProxy.DTUService.T_DTU_Group> dtuGroupList = (dgvDtuGroupList.DataSource as List<ServiceProxy.DTUService.T_DTU_Group>).FindAll(p => p.GroupCode == curModel.ParentCode);
            if (dtuGroupList.Count > 0)
            {
                if (cbTree.TreeView.Nodes.Find(dtuGroupList[0].GroupCode, true).Length > 0)
                {
                    cbTree.TreeView.SelectedNode = cbTree.TreeView.Nodes.Find(dtuGroupList[0].GroupCode, true)[0];
                    cbTree.Items.Clear();
                    cbTree.Items.Add(cbTree.TreeView.SelectedNode.Text);
                    if (cbTree.Enabled == false)
                    {
                        cbTree.Enabled = true;
                    }
                    cbTree.SelectedIndex = 0;
                }
            }
            else
            {
                cbTree.SelectedIndex = -1;
                cbTree.TreeView.SelectedNode = null;
                cbTree.Enabled = false;
            }
            txtGroupName.Text = curModel.GroupName;
            txtGroupDesc.Text = curModel.GroupDesc;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            cbTree.Enabled = true;
            curModel = null;
            ClearForm();
        }

        private void ClearForm()
        {
            txtGroupDesc.Text = "";
            txtGroupName.Text = "";
            cbxCompany.SelectedIndex = 0;
            cbTree.Items.Clear();
            cbTree.TreeView.SelectedNode = cbTree.TreeView.Nodes[0];
            cbTree.Items.Add(cbTree.TreeView.Nodes[0].Text);
            cbTree.SelectedIndex = 0;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除站点分组数据!");
                DataGridViewRow row = dgvDtuGroupList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.DTUService.T_DTU_Group;
                if (ServiceProxy.DTUServiceProxy.DeleteDtuGroup(LocalIP, model.GroupCode))
                {
                    btnQuery_Click(null, null);
                    ClearForm();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点分组:ID-{0},Name-{1}", model.GroupCode, model.GroupName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("删除成功!");
                }
                else
                {
                    btnQuery_Click(null, null);
                    ClearForm();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点分组:ID-{0},Name-{1}", model.GroupCode, model.GroupName), 2);
                    pbh.CloseProgressBar();
                    MessageBox.Show("该分组下面还有子分组,不能被删除!");
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
