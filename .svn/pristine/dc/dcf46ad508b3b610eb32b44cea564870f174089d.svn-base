using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using Com.Winfotian.Components;
using Com.Winfotian.Components.Enumerations;
using System.Linq;
namespace Com.Winfotian.MngTool
{
    public partial class FrmUser : FrmBase
    {
        ComboBoxTreeView cbgGroupTree;
        ComboBoxTreeView cbgQGroupTree;
        int curUpdateFlag = 1;
        List<TreeNode> fLastlyNodes = new List<TreeNode>();
        public FrmUser()
        {
            InitializeComponent();
            //加载ComboBoxTree控件
            cbgGroupTree = new ComboBoxTreeView();
            cbgGroupTree.Location = new System.Drawing.Point(86, 208);
            cbgGroupTree.Name = "cbxUserGroup";
            cbgGroupTree.Size = new System.Drawing.Size(121, 20);
            cbgGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.gbxDetail.Controls.Add(cbgGroupTree);
            cbgGroupTree.BringToFront();
            //
            cbgQGroupTree = new ComboBoxTreeView();
            cbgQGroupTree.Location = new System.Drawing.Point(406, 19);
            cbgQGroupTree.Name = "cbxDtuGroup1";
            cbgQGroupTree.Size = new System.Drawing.Size(127, 20);
            cbgQGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbgQGroupTree);
            cbgQGroupTree.BringToFront();
            Init();
        }

        private void Init()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                Random rd = new Random(DateTime.Now.Millisecond);
                this.txtUserPwd.Text = rd.Next(10000, 99999).ToString();
                pbh.PopProgressBar("加载公司信息!");
                CompanyBind();
                pbh.PopProgressBar("加载用户角色信息!");
                UserRoleBind();
                pbh.PopProgressBar("加载用户计费信息!");
                UserBillBind();
                pbh.PopProgressBar("加载用户配置信息!");
                UserConfigBind();
                ClearForm();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("加载初始数据出错:" + ex.Message);
            }
        }

        private void UserConfigBind()
        {
            cbxUserConfig.DataSource = ServiceProxy.UserServiceProxy.GetUserConfigsByStatus(LocalIP, 1);
            cbxUserConfig.DisplayMember = "ConfigName";
            cbxUserConfig.ValueMember = "CCode";
            cbxUserConfig.SelectedIndex = 1;
        }

        private void UserBillBind()
        {
            cbxUserBill.DataSource = ServiceProxy.UserServiceProxy.GetSMSBillsByStatus(LocalIP, 1);
            cbxUserBill.DisplayMember = "BillName";
            cbxUserBill.ValueMember = "BillCode";
        }

        private void UserGroupBind(int CompanyId)
        {
            var userGroups = ServiceProxy.UserServiceProxy.GetUserGroupByCompamyId(LocalIP, CompanyId);
            cbgGroupTree.Items.Clear();
            if (userGroups.Count > 0)
            {
                BindUserGroupTree0(userGroups, "0", null);
                if (cbgGroupTree.TreeView.Nodes.Count > 0)
                {
                    cbgGroupTree.TreeView.SelectedNode = cbgGroupTree.TreeView.Nodes[0];
                    cbgGroupTree.Items.Add(cbgGroupTree.TreeView.SelectedNode.Text);
                    cbgGroupTree.SelectedIndex = 0;
                }
            }
        }
        /// <summary>
        /// 递归绑定用户分组数据源(添加用)
        /// </summary>
        /// <param name="dtTreeData">数据</param>
        /// <param name="parentCode">父编码</param>
        /// <param name="nodes">树节点</param>
        private void BindUserGroupTree0(List<ServiceProxy.UserService.T_User_Group> dtTreeData, string parentCode, TreeNode nodes)
        {
            if (nodes == null)
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    cbgGroupTree.TreeView.Nodes.Add(tNode);
                    BindUserGroupTree0(dtTreeData, tNode.Name, tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    nodes.Nodes.Add(tNode);
                    BindUserGroupTree0(dtTreeData, tNode.Name, tNode);
                }
            }
            cbgGroupTree.TreeView.ExpandAll();
        }

        /// <summary>
        /// 递归绑定站点分组数据源（查询用）
        /// </summary>
        /// <param name="dtTreeData">数据</param>
        /// <param name="parentCode">父编码</param>
        /// <param name="nodes">树节点</param>
        private void BindUserGroupTree1(List<ServiceProxy.UserService.T_User_Group> dtTreeData, string parentCode, TreeNode nodes)
        {
            if (nodes == null)
            {
                TreeNode tFirstNode = new TreeNode() { Text = "全部", Name = "-1" };
                cbgQGroupTree.TreeView.Nodes.Add(tFirstNode);
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    cbgQGroupTree.TreeView.Nodes.Add(tNode);
                    BindUserGroupTree1(dtTreeData, tNode.Name, tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    nodes.Nodes.Add(tNode);
                    BindUserGroupTree1(dtTreeData, tNode.Name, tNode);
                }
            }
            cbgQGroupTree.TreeView.ExpandAll();
        }
        private void UserRoleBind()
        {
            cbxUserRole.DataSource = ServiceProxy.UserServiceProxy.GetUserRolesByStatus(LocalIP, 1);
            cbxUserRole.DisplayMember = "RoleName";
            cbxUserRole.ValueMember = "RoleCode";
            cbxUserRole.SelectedIndex = 1;
        }

        private void CompanyBind()
        {
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
            cbxCompany.SelectedIndex = 0;

            ClonedCompanyList.Insert(0, new ServiceProxy.CompanyService.CompanyIDAndName() { CompanyId = -1, CompanyName = "全部" });
            cbxQCompany.DataSource = ClonedCompanyList;
            cbxQCompany.DisplayMember = "CompanyName";
            cbxQCompany.ValueMember = "CompanyId";
        }
        private void DtuBind(int CompanyID)
        {
            if (CompanyID != 12)
            {
                var dtDtu = ServiceProxy.DTUServiceProxy.GetDtuInfoWithGroup(LocalIP, CompanyID);
                var dtGroupedTree = ServiceProxy.DTUServiceProxy.GetDtuGroupsByCompanyId(LocalIP, CompanyID);
                dtDtu = dtDtu.OrderBy(p => p.DtuidName).ToList();
                BindDtuGroupTree(dtGroupedTree, dtDtu, "0", null);
            }
            else//如果是英菲信则绑定所有站点
            {
                IList<ServiceProxy.DTUService.DTU> dtuList = ServiceProxy.DTUServiceProxy.GetAllDtuInfo(LocalIP);
                dtuList = dtuList.OrderBy(p => p.DtuidName).ToList();
                BindAllDtu(dtuList);
            }
        }
        /// <summary>
        /// 为英菲信的用户绑定所有数据
        /// </summary>
        /// <param name="dtDtu"></param>
        private void BindAllDtu(IList<ServiceProxy.DTUService.DTU> dtuList)
        {
            foreach (var row in dtuList)
            {
                TreeNode tNode = new TreeNode() { Text = row.DtuidName, Name = row.Dtuid };
                fLastlyNodes.Add(tNode);
                treeDtu.Nodes.Add(tNode);
            }
        }
        /// <summary>
        /// 递归绑定站点分组数据源
        /// </summary>
        /// <param name="dtTreeData">数据</param>
        /// <param name="parentCode">父编码</param>
        /// <param name="nodes">树节点</param>
        private void BindDtuGroupTree(List<ServiceProxy.DTUService.T_DTU_Group> dtTreeData, List<ServiceProxy.DTUService.DTUWithGroup> dtDtu, string parentCode, TreeNode nodes)
        {
            if (nodes == null)
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    var dtuRowList = dtDtu.FindAll(p => p.GroupCode == row.GroupCode);
                    foreach (var item in dtuRowList)
                    {
                        TreeNode lastTreeNode = new TreeNode() { Text = item.DtuidName, Name = item.Dtuid };
                        fLastlyNodes.Add(lastTreeNode);
                        tNode.Nodes.Add(lastTreeNode);
                    }
                    treeDtu.Nodes.Add(tNode);
                    BindDtuGroupTree(dtTreeData, dtDtu, tNode.Name, tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    var dtuRowList = dtDtu.FindAll(p => p.GroupCode == row.GroupCode);
                    foreach (var item in dtuRowList)
                    {
                        TreeNode lastTreeNode = new TreeNode() { Text = item.DtuidName, Name = item.Dtuid };
                        fLastlyNodes.Add(lastTreeNode);
                        tNode.Nodes.Add(lastTreeNode);
                    }
                    nodes.Nodes.Add(tNode);
                    BindDtuGroupTree(dtTreeData, dtDtu, tNode.Name, tNode);
                }
            }
            treeDtu.ExpandAll();
        }
        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            new FrmCompany().ShowDialog();
            cbxCompany.DataSource = null;
            CompanyBind();
        }

        private void btnAddUserGroup_Click(object sender, EventArgs e)
        {
            new FrmUserGroup().ShowDialog();
            cbgGroupTree.DataSource = null;
            cbgGroupTree.TreeView.Nodes.Clear();
            UserGroupBind((cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId);
        }

        private void btnAddUserConfig_Click(object sender, EventArgs e)
        {
            new FrmUserConfig().ShowDialog();
            cbxUserConfig.DataSource = null;
            UserConfigBind();
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            new FrmUserRole().ShowDialog();
            cbxUserRole.DataSource = null;
            UserRoleBind();
        }

        private void btnAddUserBill_Click(object sender, EventArgs e)
        {
            new FrmSMSBill().ShowDialog();
            cbxUserBill.DataSource = null;
            UserBillBind();
        }

        private void btnAddDtu_Click(object sender, EventArgs e)
        {
            new FrmDTU().ShowDialog();
            treeDtu.Nodes.Clear();
            fLastlyNodes.Clear();
            DtuBind((cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId);
        }

        private void cbxUserCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCompany.SelectedItem != null)
            {
                treeDtu.Nodes.Clear();
                fLastlyNodes.Clear();
                cbgGroupTree.TreeView.Nodes.Clear();
                int CompanyId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                DtuBind(CompanyId);
                UserGroupBind(CompanyId);
            }
            else
            {
                treeDtu.Nodes.Clear();
                fLastlyNodes.Clear();
            }
        }
        ///// <summary>
        ///// 实现TreeView全选和反选功能
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void treeDtu_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    if (e.Action != TreeViewAction.Unknown)
        //    {
        //        CheckAllChildNodes(e.Node, e.Node.Checked);
        //        //选中父节点 
        //        bool bol = true;
        //        if (e.Node.Parent != null)
        //        {
        //            for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
        //            {
        //                if (!e.Node.Parent.Nodes[i].Checked)
        //                    bol = false;
        //            }
        //            e.Node.Parent.Checked = bol;
        //        }
        //    }
        //}


        private void btnQuery_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("加载查询的用户数据!");
                System.Threading.Thread.Sleep(500);
                int cmpId = 0;
                string groupCode = string.Empty;
                string trueName = string.Empty;
                if (cbxQCompany.SelectedIndex != 0)
                {
                    cmpId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                }
                if (cbgQGroupTree.TreeView.SelectedNode != null && cbgQGroupTree.TreeView.SelectedNode.Name != "-1")
                {
                    groupCode = cbgQGroupTree.TreeView.SelectedNode.Name;
                }
                if (!string.IsNullOrEmpty(txtQTrueName.Text))
                {
                    trueName = txtQTrueName.Text.Trim();
                }
                dgvUserList.DataSource = ServiceProxy.UserServiceProxy.GetUserAndNameListBy(LocalIP, 1, cmpId, groupCode, trueName);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.PopProgressBar("加载查询的用户数据出错:" + ex.Message);
            }
            finally
            {
                pbh.CloseProgressBar();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ServiceProxy.CommonService.EnumExistsStatus flag = ServiceProxy.CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_User_Info]", "UserId", txtUserId.Text.Trim());
            if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
            {
                MessageBox.Show("这个用户编号已经存在,请另外填写一个编号!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserPwd.Text.Trim()))
            {
                MessageBox.Show("用户密码不能为空!");
                return;
            }
            if (txtUserPwd.Text.Trim() == "123" || txtUserPwd.Text.Trim() == "123456")
            {
                MessageBox.Show("您设置的用户密码太简单!");
                return;
            }
            if (cbgGroupTree.TreeView.SelectedNode == null)
            {
                MessageBox.Show("您没有选择用户分组!");
                return;
            }
            if (!ToolHelper.IsEmail(txtUserMail.Text))
            {
                MessageBox.Show("请填写正确的电子邮件格式!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存用户数据!");
                ServiceProxy.UserService.T_User_Info userInfo = new ServiceProxy.UserService.T_User_Info();
                userInfo.LinkAddr = txtLinkAddr.Text.Trim();
                userInfo.RegDate = DateTime.Now;
                userInfo.Status = 1;
                userInfo.TrueName = txtTrueName.Text.Trim();
                userInfo.UpdateFlag = 1;
                userInfo.UserId = txtUserId.Text.Trim();
                userInfo.UserMail = txtUserMail.Text.Trim();
                userInfo.UserPhone = txtUserPhone.Text.Trim();
                userInfo.UserPosition = txtUserPosition.Text.Trim();
                userInfo.UserPwd = Com.Winfotian.Encrypts.DESEncrypt.Encrypt(txtUserPwd.Text.Trim());
                userInfo.CCode = cbxUserConfig.SelectedValue.ToString();
                userInfo.BillCode = cbxUserBill.SelectedValue.ToString();
                userInfo.CompanyId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                userInfo.BirthDay = dtpBirthday.Value;
                userInfo.ParentUser = "-1";
                //插入用户和用户分组关系表
                ServiceProxy.UserService.T_User_UserGroup userGroup = new ServiceProxy.UserService.T_User_UserGroup();
                userGroup.UserId = txtUserId.Text.Trim();
                userGroup.GroupCode = cbgGroupTree.TreeView.SelectedNode.Name;
                userGroup.Status = 1;
                //插入用户-角色关系表
                ServiceProxy.UserService.T_User_UserRole userRole = new ServiceProxy.UserService.T_User_UserRole();
                userRole.RoleCode = cbxUserRole.SelectedValue.ToString();
                userRole.UserId = txtUserId.Text.Trim();
                userRole.Status = 1;
                //批量事务插入用户-站点关系表
                List<ServiceProxy.UserService.T_User_UserDtuid> listUserDtuid = new List<ServiceProxy.UserService.T_User_UserDtuid>();
                foreach (TreeNode item in fLastlyNodes)
                {
                    if (item.Checked)
                    {
                        ServiceProxy.UserService.T_User_UserDtuid userDtuid = new ServiceProxy.UserService.T_User_UserDtuid();
                        userDtuid.Dtuid = item.Name.ToString();
                        userDtuid.UserId = txtUserId.Text.Trim();
                        userDtuid.Status = 1;
                        listUserDtuid.Add(userDtuid);
                    }
                }
                //如果存在此UserID并且Status为0的更新的逻辑写在SQL语句里面了！
                ServiceProxy.UserServiceProxy.InsertUserAndOtherRelation(LocalIP, userInfo, userGroup, userRole, listUserDtuid);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加用户:ID-{0},Name-{1}", userInfo.UserId, userInfo.TrueName), 1);
                pbh.CloseProgressBar();
                MessageBox.Show("保存成功!");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("保存失败:" + ex.Message);
            }
        }

        private void cbxQCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxQCompany.SelectedItem != null)
            {
                int CompanyId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                var userGroups = ServiceProxy.UserServiceProxy.GetUserGroupByCompamyId(LocalIP, CompanyId);
                cbgQGroupTree.Items.Clear();
                cbgQGroupTree.TreeView.Nodes.Clear();
                if (userGroups != null && userGroups.Count != 0)
                {
                    BindUserGroupTree1(userGroups, "0", null);
                    cbgQGroupTree.TreeView.SelectedNode = cbgQGroupTree.TreeView.Nodes[0];
                    cbgQGroupTree.Items.Add(cbgQGroupTree.TreeView.SelectedNode.Text);
                    cbgQGroupTree.SelectedIndex = 0;
                }
                else
                {
                    TreeNode tFirstNode = new TreeNode() { Text = "全部", Name = "-1" };
                    cbgQGroupTree.TreeView.Nodes.Add(tFirstNode);
                    cbgQGroupTree.TreeView.SelectedNode = tFirstNode;
                    cbgQGroupTree.Items.Add(cbgQGroupTree.TreeView.SelectedNode.Text);
                    cbgQGroupTree.SelectedIndex = 0;
                }
            }
        }

        private void dgvUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (TreeNode item in fLastlyNodes)
            {
                item.Checked = false;
            }
            DataGridViewRow row = dgvUserList.SelectedRows[0];
            var model = row.DataBoundItem as ServiceProxy.UserService.UserIDAndName;
            ServiceProxy.UserService.T_User_Info userInfo = ServiceProxy.UserServiceProxy.GetUserInfoByUserId(model.UserId, LocalIP);
            txtLinkAddr.Text = userInfo.LinkAddr;
            txtTrueName.Text = userInfo.TrueName;
            txtUserId.Text = userInfo.UserId;
            txtUserMail.Text = userInfo.UserMail;
            txtUserPhone.Text = userInfo.UserPhone;
            txtUserPosition.Text = userInfo.UserPosition;
            txtUserPwd.Text = Com.Winfotian.Encrypts.DESEncrypt.Decrypt(userInfo.UserPwd);
            cbxCompany.SelectedValue = userInfo.CompanyId;
            if (userInfo.CompanyId == 12)
            {
                this.txtUserPwd.UseSystemPasswordChar = true;
            }
            else
                this.txtUserPwd.UseSystemPasswordChar = false;
            cbxUserBill.SelectedValue = userInfo.BillCode;
            cbxUserConfig.SelectedValue = userInfo.CCode;
            curUpdateFlag = userInfo.UpdateFlag + 1;
            List<ServiceProxy.UserService.T_User_UserRole> userRoleList = ServiceProxy.UserServiceProxy.GetUserRolesByUserId(LocalIP, userInfo.UserId);
            if (userRoleList.Count > 0)
            {
                cbxUserRole.SelectedValue = userRoleList[0].RoleCode;
            }
            List<ServiceProxy.UserService.T_User_UserGroup> userGroupList = ServiceProxy.UserServiceProxy.GetUserGroupsByUserId(LocalIP, userInfo.UserId);
            if (userGroupList != null && userGroupList.Count > 0)//如果得到用户和分组关系不为空的时候才设置界面
            {
                if (cbgGroupTree.TreeView.Nodes.Count > 0)//如果用户所在公司已经建有用户分组
                {
                    if (cbgGroupTree.TreeView.Nodes.Find(userGroupList[0].GroupCode, true).Length > 0)//如果找到用户所在分组
                    {
                        cbgGroupTree.TreeView.SelectedNode = cbgGroupTree.TreeView.Nodes.Find(userGroupList[0].GroupCode, true)[0];
                        cbgGroupTree.Items.Clear();
                        cbgGroupTree.Items.Add(cbgGroupTree.TreeView.SelectedNode.Text);
                        cbgGroupTree.SelectedIndex = 0;
                    }
                    else//如果没有找到
                    {
                        cbgGroupTree.TreeView.SelectedNode = null;
                        cbgGroupTree.SelectedIndex = -1;
                    }
                }
                else//如果用户所在公司没有建立分组
                {
                    cbgGroupTree.TreeView.SelectedNode = null;
                    cbgGroupTree.TreeView.Nodes.Clear();
                    cbgGroupTree.Items.Clear();
                }
            }
            else//如果得到用户和分组关系为空的时候就设置分组显示为空(用户所在公司的用户分组会依然绑定)
            {
                cbgGroupTree.SelectedIndex = -1;
            }
            List<ServiceProxy.UserService.T_User_UserDtuid> userDtuList = ServiceProxy.UserServiceProxy.GetUserDtuidByUserId(LocalIP, userInfo.UserId);
            if ((userDtuList != null && userDtuList.Count > 0) && treeDtu.Nodes.Count > 0)
            {
                ClearTreeNodeSelected(treeDtu.Nodes[0]);
                foreach (ServiceProxy.UserService.T_User_UserDtuid item in userDtuList)
                {
                    CheckedByDtuid(item.Dtuid);
                }
            }
            btnAdd.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            txtUserId.ReadOnly = true;
        }
        /// <summary>
        /// 清除treeDtu所有选中状态
        /// </summary>
        /// <param name="node"></param>
        private static void ClearTreeNodeSelected(TreeNode node)
        {
            foreach (TreeNode item in node.Nodes)//先清除全部选中
            {
                item.Checked = false;
                ClearTreeNodeSelected(item);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserId.Text))
            {
                MessageBox.Show("用户编码不能为空!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserPwd.Text.Trim()))
            {
                MessageBox.Show("用户密码不能为空!");
                return;
            }
            if (cbgGroupTree.TreeView.SelectedNode == null)
            {
                MessageBox.Show("您没有选择用户分组!");
                return;
            }
            if (!ToolHelper.IsEmail(txtUserMail.Text))
            {
                MessageBox.Show("请填写正确的电子邮件格式!");
                return;
            }
            if (cbxCompany.SelectedIndex < 0)
            {
                MessageBox.Show("您没有选择用户所属公司!");
                return;
            }
            if (cbxUserConfig.SelectedIndex < 0)
            {
                MessageBox.Show("您没有选择用户配置!");
                return;
            }
            if (cbxUserRole.SelectedIndex < 0)
            {
                MessageBox.Show("您没有选择用户角色!");
                return;
            }
            if (cbxUserBill.SelectedIndex < 0)
            {
                MessageBox.Show("您没有选择用户计费!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存用户数据!");
                ServiceProxy.UserService.T_User_Info userInfo = new ServiceProxy.UserService.T_User_Info();
                userInfo.LinkAddr = txtLinkAddr.Text.Trim();
                userInfo.RegDate = DateTime.Now;
                userInfo.Status = 1;
                userInfo.TrueName = txtTrueName.Text.Trim();
                userInfo.UpdateFlag = 1;
                userInfo.BirthDay = DateTime.Parse(dtpBirthday.Text.Trim());
                userInfo.UserId = txtUserId.Text.Trim();
                userInfo.UserMail = txtUserMail.Text.Trim();
                userInfo.UserPhone = txtUserPhone.Text.Trim();
                userInfo.UserPosition = txtUserPosition.Text.Trim();
                userInfo.UserPwd = Com.Winfotian.Encrypts.DESEncrypt.Encrypt(txtUserPwd.Text.Trim());
                userInfo.CCode = cbxUserConfig.SelectedValue.ToString();
                userInfo.BillCode = cbxUserBill.SelectedValue.ToString();
                userInfo.CompanyId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                userInfo.UpdateFlag = curUpdateFlag;
                //修改用户和用户分组关系表
                ServiceProxy.UserService.T_User_UserGroup userGroup = new ServiceProxy.UserService.T_User_UserGroup();
                userGroup.UserId = txtUserId.Text.Trim();
                userGroup.GroupCode = cbgGroupTree.TreeView.SelectedNode.Name;
                userGroup.Status = 1;
                //修改用户-角色关系表
                ServiceProxy.UserService.T_User_UserRole userRole = new ServiceProxy.UserService.T_User_UserRole();
                userRole.RoleCode = cbxUserRole.SelectedValue.ToString();
                userRole.UserId = txtUserId.Text.Trim();
                userRole.Status = 1;
                //批量事务插入用户-站点关系表
                List<ServiceProxy.UserService.T_User_UserDtuid> listUserDtuid = new List<ServiceProxy.UserService.T_User_UserDtuid>();
                foreach (TreeNode item in fLastlyNodes)
                {
                    if (item.Checked)
                    {
                        ServiceProxy.UserService.T_User_UserDtuid userDtuid = new ServiceProxy.UserService.T_User_UserDtuid();
                        userDtuid.Dtuid = item.Name.ToString();
                        userDtuid.UserId = txtUserId.Text.Trim();
                        userDtuid.Status = 1;
                        listUserDtuid.Add(userDtuid);
                    }
                }
                ServiceProxy.UserServiceProxy.UpdateUserAndOtherRelation(LocalIP, userInfo, userGroup, userRole, listUserDtuid);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改用户:ID-{0},Name-{1}", userInfo.UserId, userInfo.TrueName), 1);
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
                pbh.PopProgressBar("正在删除所选用户数据!");
                DataGridViewRow row = dgvUserList.SelectedRows[0];
                ServiceProxy.UserService.UserIDAndName user = row.DataBoundItem as ServiceProxy.UserService.UserIDAndName;
                ServiceProxy.UserServiceProxy.DeleteUserByUserId(LocalIP, user.UserId);
                ClearForm();
                btnQuery_Click(null, null);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除用户:ID-{0},Name-{1}", user.UserId, user.TrueName), 1);
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
        /// <summary>
        /// 根据传入的Dtuid来决定本TreeNode是否被选中
        /// </summary>
        /// <param name="dtuid"></param>
        private void CheckedByDtuid(string dtuid)
        {
            foreach (TreeNode node in fLastlyNodes)
            {
                if (node.Name.ToString() == dtuid)
                {
                    node.Checked = true;
                }
            }
        }
        /// <summary>
        /// 重置界面
        /// </summary>
        private void ClearForm()
        {
            txtLinkAddr.Text = "四川省成都市XXX街XXX号";
            txtTrueName.Text = "领导";
            txtUserMail.Text = "test@winftoian.com";
            txtUserId.Text = "XXX+rq+序号";
            txtUserPhone.Text = "";
            txtUserPosition.Text = "经理/部长/员工";
            Random rd = new Random(DateTime.Now.Millisecond);
            this.txtUserPwd.Text = rd.Next(10000, 99999).ToString();
            if (cbxCompany.Items.Count > 5)
                cbxCompany.SelectedIndex = 6;
            cbxUserBill.SelectedIndex = 0;
            cbxUserConfig.SelectedIndex = 2;
            cbxUserRole.SelectedIndex = 1;
            cbgGroupTree.SelectedIndex = 0;
            foreach (TreeNode item in fLastlyNodes)
            {
                item.Checked = false;
            }
            this.txtUserPwd.UseSystemPasswordChar = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            txtUserId.ReadOnly = false;
            ClearForm();
        }

        /// <summary>
        /// 选中子节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        public void CheckAllChildNodes(TreeNode treeNode, bool isReverse)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (isReverse)
                    node.Checked = !node.Checked;
                else
                    node.Checked = true;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, isReverse);
                }
            }
        }
        /// <summary>
        /// 选中子节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        public void UnCheckAllChildNodes(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = false;
                if (node.Nodes.Count > 0)
                {
                    this.UnCheckAllChildNodes(node);
                }
            }
        }
        private void chkAll_Click(object sender, EventArgs e)
        {
            chkAll.Checked = true;
            if (chkReverse.Checked)
                chkReverse.Checked = false;
            if (chkAllUn.Checked)
                chkAllUn.Checked = false;
            foreach (TreeNode item in treeDtu.Nodes)
            {
                item.Checked = true;
                CheckAllChildNodes(item, false);
            }
        }

        private void chkReverse_Click(object sender, EventArgs e)
        {
            chkReverse.Checked = true;
            if (chkAll.Checked)
                chkAll.Checked = false;
            if (chkAllUn.Checked)
                chkAllUn.Checked = false;
            foreach (TreeNode item in treeDtu.Nodes)
            {
                item.Checked = !item.Checked;
                CheckAllChildNodes(item, true);
            }
        }

        private void chkAllUn_Click(object sender, EventArgs e)
        {
            chkAllUn.Checked = true;
            if (chkAll.Checked)
                chkAll.Checked = false;
            if (chkReverse.Checked)
                chkReverse.Checked = false;
            foreach (TreeNode item in treeDtu.Nodes)
            {
                item.Checked = false;
                UnCheckAllChildNodes(item);
            }
        }
    }
}
