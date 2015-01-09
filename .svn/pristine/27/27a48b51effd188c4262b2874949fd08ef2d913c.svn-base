using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using Com.Winfotian.Components.Enumerations;

namespace Com.Winfotian.MngTool
{
    public partial class FrmUserRole : FrmBase
    {
        int curFlag = 1;
        public FrmUserRole()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //检查是已经否存在这个角色编号
            ServiceProxy.CommonService.EnumExistsStatus flag = ServiceProxy.CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_User_Role]", "RoleCode", txtRoleCode.Text.Trim());
            if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
            {
                MessageBox.Show("这个角色编号已经存在,请另外填写一个编号!");
                return;
            }
            if (string.IsNullOrEmpty(txtRoleCode.Text))
            {
                MessageBox.Show("角色编码不能为空!");
                return;
            }
            if (txtRoleName.Text.Trim().Length == 0)
            {
                MessageBox.Show("角色名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存角色数据!");
                ServiceProxy.UserService.T_User_Role userRole = new ServiceProxy.UserService.T_User_Role();
                userRole.RoleCode = txtRoleCode.Text.Trim();
                userRole.RoleName = txtRoleName.Text.Trim();
                userRole.RoleDesc = txtRoleDesc.Text.Trim();
                userRole.Status = 1;
                userRole.UpdateFlag = 1;
                ServiceProxy.UserServiceProxy.AddUserRole(LocalIP, userRole);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加用户角色:ID-{0},Name-{1}", userRole.RoleCode, userRole.RoleName), 1);
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
                pbh.PopProgressBar("正在查询角色数据!");
                dgvRoleList.DataSource = ServiceProxy.UserServiceProxy.GetUserRolesByRoleName(LocalIP, txtQRoleName.Text.Trim());
                dgvRoleList.ClearSelection();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("查询失败:" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            txtRoleCode.ReadOnly = false;
            ClearForm();
        }

        private void ClearForm()
        {
            txtRoleCode.Text = "";
            txtRoleName.Text = "";
            txtRoleDesc.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除角色数据!");
                DataGridViewRow row = dgvRoleList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.UserService.T_User_Role;
                ServiceProxy.UserServiceProxy.DeleteUserRoleById(LocalIP, model.RoleCode);
                btnQuery_Click(null, null);
                ClearForm();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除用户角色:ID-{0},Name-{1}", model.RoleCode, model.RoleName), 1);
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
            if (string.IsNullOrEmpty(txtRoleCode.Text))
            {
                MessageBox.Show("角色编码不能为空!");
                return;
            }
            if (txtRoleName.Text.Trim().Length == 0)
            {
                MessageBox.Show("角色名称不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改角色数据!");
                ServiceProxy.UserService.T_User_Role userRole = new ServiceProxy.UserService.T_User_Role();
                userRole.RoleCode = txtRoleCode.Text.Trim();
                userRole.RoleName = txtRoleName.Text.Trim();
                userRole.RoleDesc = txtRoleDesc.Text.Trim();
                userRole.UpdateFlag = curFlag + 1;
                userRole.Status = 1;
                ServiceProxy.UserServiceProxy.UpdateUserRole(LocalIP, userRole);
                btnQuery_Click(null, null);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改用户角色:ID-{0},Name-{1}", userRole.RoleCode, userRole.RoleName), 1);
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

        private void dgvRoleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvRoleList.SelectedRows[0];
            var model = row.DataBoundItem as ServiceProxy.UserService.T_User_Role;
            txtRoleCode.Text = model.RoleCode;
            txtRoleName.Text = model.RoleName;
            txtRoleDesc.Text = model.RoleDesc;
            curFlag = model.UpdateFlag;
            btnSave.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            txtRoleCode.ReadOnly = true;
        }
    }
}
