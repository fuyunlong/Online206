using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using Com.Winfotian.Components;

namespace Com.Winfotian.MngTool
{
    public partial class FrmUserGroup : FrmBase
    {
        ComboBoxTreeView cbTree;
        ServiceProxy.UserService.T_User_Group curModel = null;
        public FrmUserGroup()
        {
            InitializeComponent();
            cbTree = new ComboBoxTreeView();
            cbTree.Location = new System.Drawing.Point(249, 325);
            cbTree.Name = "cbxParentCode";
            cbTree.Size = new System.Drawing.Size(110, 21);
            cbTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbTree);
            CompanyBind();
        }
        /// <summary>
        /// 绑定公司数据源
        /// </summary>
        private void CompanyBind()
        {
            //这里因为查询和添加用的数据源一样所以采取新建一个空数据源，然后再往里面插入数据一完成克隆数据源的作用
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载公司数据!");
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
                MessageBox.Show("加载公司数据失败:" + ex.Message);
            }
        }
        /// <summary>
        /// 递归绑定用户组树形节点
        /// </summary>
        /// <param name="dtTreeData">数据DataTable</param>
        /// <param name="parentCode">父节点编码</param>
        /// <param name="nodes">父节点</param>
        private void BindTree(List<ServiceProxy.UserService.T_User_Group> dtTreeData, string parentCode, TreeNode nodes)
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
            if (txtGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("角色名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存用户分组数据!");
                ServiceProxy.UserService.T_User_Group userGroup = new ServiceProxy.UserService.T_User_Group();
                userGroup.GroupCode = "FZ_" + ((ServiceProxy.CompanyService.CompanyIDAndName)cbxCompany.SelectedItem).CompanyId.ToString() + "_" + DateTime.Now.ToString("yyMMddHHmmssffff");
                userGroup.GroupName = txtGroupName.Text.Trim();
                userGroup.GroupDesc = txtGroupDesc.Text.Trim();
                if (cbTree.TreeView.SelectedNode != null)//如果不为null则为子节点
                {
                    userGroup.ParentCode = cbTree.TreeView.SelectedNode.Name;
                }
                else//否则根节点
                {
                    userGroup.ParentCode = "0";
                };
                userGroup.CompanyId = ((ServiceProxy.CompanyService.CompanyIDAndName)cbxCompany.SelectedItem).CompanyId;
                userGroup.Status = 1;
                userGroup.UpdateFlag = 1;
                ServiceProxy.UserServiceProxy.AddUserGroup(LocalIP, userGroup);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加用户分组:ID-{0},Name-{1}", userGroup.GroupCode, userGroup.GroupName), 1);
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
                pbh.PopProgressBar("正在查询用户分组数据!");
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
            dgvUserGroupList.DataSource = ServiceProxy.UserServiceProxy.GetUserGroupByCompamyId(LocalIP, CompanyId); ;
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCompany.SelectedItem != null)
            {
                int CompanyId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                var userGroups = ServiceProxy.UserServiceProxy.GetUserGroupByCompamyId(LocalIP, CompanyId);
                cbTree.Items.Clear();
                cbTree.TreeView.Nodes.Clear();
                BindTree(userGroups, "0", null);
                if (userGroups.Count > 0)
                {
                    cbTree.TreeView.SelectedNode = cbTree.TreeView.Nodes[0];
                    cbTree.Items.Add(cbTree.TreeView.SelectedNode.Text);
                    cbTree.SelectedIndex = 0;
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (curModel == null)
            {
                MessageBox.Show("请双击选择要修改的数据行!");
                return;
            }
            if (txtGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("分组名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改用户分组数据");
                ServiceProxy.UserService.T_User_Group userGroup = new ServiceProxy.UserService.T_User_Group();
                userGroup.GroupCode = curModel.GroupCode;
                userGroup.GroupName = txtGroupName.Text.Trim();
                userGroup.GroupDesc = txtGroupDesc.Text.Trim();
                if (cbTree.TreeView.SelectedNode != null)//如果不为null则为子节点
                {
                    userGroup.ParentCode = cbTree.TreeView.SelectedNode.Name;
                }
                else//否则根节点
                {
                    userGroup.ParentCode = "0";
                }
                userGroup.CompanyId = ((ServiceProxy.CompanyService.CompanyIDAndName)cbxCompany.SelectedItem).CompanyId;
                userGroup.Status = 1;
                userGroup.UpdateFlag = curModel.UpdateFlag + 1;
                ServiceProxy.UserServiceProxy.UpdateUserGroup(LocalIP, userGroup);
                BindQueryData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改用户分组:ID-{0},Name-{1}", userGroup.GroupCode, userGroup.GroupName), 1);
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
                pbh.PopProgressBar("正在删除用户分组数据");
                DataGridViewRow row = dgvUserGroupList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.UserService.T_User_Group;
                if (ServiceProxy.UserServiceProxy.DeleteUserGroup(LocalIP, model.GroupCode))
                {
                    ClearForm();
                    btnQuery_Click(null, null);
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除用户分组:ID-{0},Name-{1}", model.GroupCode, model.GroupName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("删除成功!");
                }
                else
                {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            cbxCompany.SelectedIndex = 0;
            cbTree.Enabled = true;
            curModel = null;
            ClearForm();
        }

        private void ClearForm()
        {
            txtGroupName.Text = "";
            txtGroupDesc.Text = "";
            cbTree.Items.Clear();
            cbTree.TreeView.SelectedNode = cbTree.TreeView.Nodes[0];
            cbTree.Items.Add(cbTree.TreeView.Nodes[0].Text);
            cbTree.SelectedIndex = 0;
        }

        private void dgvUserGroupList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            DataGridViewRow row = dgvUserGroupList.SelectedRows[0];
            curModel = row.DataBoundItem as ServiceProxy.UserService.T_User_Group;
            cbxCompany.SelectedValue = curModel.CompanyId;
            List<ServiceProxy.UserService.T_User_Group> dtuGroupList = (dgvUserGroupList.DataSource as List<ServiceProxy.UserService.T_User_Group>).FindAll(p => p.GroupCode == curModel.ParentCode);
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
    }
}
