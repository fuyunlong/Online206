using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuUserManager : FrmBase
    {
        public ServiceProxy.UserService.UserIDAndName CurUserInfo { get; set; }
        ComboBoxTreeView cbgGroupTree;
        public FrmDtuUserManager()
        {
            InitializeComponent();
            //加载ComboBoxTree0控件
            cbgGroupTree = new ComboBoxTreeView();//添加用
            cbgGroupTree.Location = new System.Drawing.Point(61, 52);
            cbgGroupTree.Name = "cbxDtuGroup0";
            cbgGroupTree.Size = new System.Drawing.Size(250, 20);
            cbgGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbgGroupTree);
            cbgGroupTree.BringToFront();
            cbgGroupTree.SelectedIndexChanged += new EventHandler(cbgGroupTree_SelectedIndexChanged);
            CompanyBind();
        }

        private void cbgGroupTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDtu.DataSource = null;
            cbxDtu.DataSource = ServiceProxy.DTUServiceProxy.GetDtuListByGroupCode(LocalIP, cbgGroupTree.TreeView.SelectedNode.Name);
            cbxDtu.DisplayMember = "DtuidName";
            cbxDtu.ValueMember = "DtuId";
        }
        /// <summary>
        /// 绑定公司数据源
        /// </summary>
        private void CompanyBind()
        {
            cbxQCompany.DataSource = ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
            cbxQCompany.DisplayMember = "CompanyName";
            cbxQCompany.ValueMember = "CompanyId";
        }
        /// <summary>
        /// 递归绑定站点分组数据源（查询用）
        /// </summary>
        /// <param name="dtTreeData">数据</param>
        /// <param name="parentCode">父编码</param>
        /// <param name="nodes">树节点</param>
        private void BindGroupTree(List<ServiceProxy.DTUService.T_DTU_Group> dtTreeData, string parentCode, TreeNode nodes)
        {
            if (nodes == null)
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    cbgGroupTree.TreeView.Nodes.Add(tNode);
                    BindGroupTree(dtTreeData, tNode.Name, tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    nodes.Nodes.Add(tNode);
                    BindGroupTree(dtTreeData, tNode.Name, tNode);
                }
            }
            cbgGroupTree.TreeView.ExpandAll();
        }

        private void cbxQCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxQCompany.SelectedItem != null)
            {
                int CompanyId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                List<ServiceProxy.DTUService.T_DTU_Group> dtuGroups = ServiceProxy.DTUServiceProxy.GetDtuGroupsByCompanyId(LocalIP, CompanyId);
                cbgGroupTree.Items.Clear();
                cbgGroupTree.TreeView.Nodes.Clear();
                if (dtuGroups != null && dtuGroups.Count != 0)
                {
                    BindGroupTree(dtuGroups, "0", null);
                    cbgGroupTree.TreeView.SelectedNode = cbgGroupTree.TreeView.Nodes[0];
                    cbgGroupTree.Items.Add(cbgGroupTree.TreeView.SelectedNode.Text);
                    cbgGroupTree.SelectedIndex = 0;
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                if (cbxDtu.SelectedItem == null)
                {
                    MessageBox.Show("请选择查询的站点!", "提示!", MessageBoxButtons.OK);
                    return;
                }
                pbh.PopProgressBar("加载查询的用户数据!");
                dgvUser.DataSource = ServiceProxy.UserServiceProxy.GetUserByDtuid(LocalIP, (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid);
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
            FrmDtuUserAdd frm = new FrmDtuUserAdd((cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId, (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (CurUser != null)
                {
                    var model = new List<ServiceProxy.UserService.T_User_UserDtuid>();
                    model.Add(new ServiceProxy.UserService.T_User_UserDtuid() { Dtuid = (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid, UserId = CurUserInfo.UserId, Status = 1 });
                    ServiceProxy.UserServiceProxy.InsertListUserDtuid(LocalIP, model);
                    btnQuery_Click(null, null);
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点用户:{0}-{1}", (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).DtuidName, CurUserInfo.UserId), 1);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除所选站点数据!");
                var model = dgvUser.SelectedRows[0].DataBoundItem as ServiceProxy.UserService.UserIDAndName;
                ServiceProxy.DTUServiceProxy.DeleteDtuUser(LocalIP, (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid, model.UserId);
                btnQuery_Click(null, null);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点用户:{0}-{1}", (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).DtuidName, model.UserId), 1);
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
    }
}
