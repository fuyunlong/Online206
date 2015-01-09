using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.ServiceProxy;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public partial class FrmValveEffect : FrmBase
    {
        ServiceProxy.DTUService.T_DTU_ValveEffect curModel;
        ComboBoxTreeView cbgGroupTree;
        ComboBoxTreeView cbgQGroupTree;
        public FrmValveEffect()
        {
            InitializeComponent();
            //加载ComboBoxTree0控件
            cbgGroupTree = new ComboBoxTreeView();//添加用
            cbgGroupTree.Location = new System.Drawing.Point(309, 349);
            cbgGroupTree.Name = "cbxDtuGroup0";
            cbgGroupTree.Size = new System.Drawing.Size(149, 20);
            cbgGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbgGroupTree);
            cbgGroupTree.BringToFront();
            //
            cbgQGroupTree = new ComboBoxTreeView();//查询条件用
            cbgQGroupTree.Location = new System.Drawing.Point(311, 15);
            cbgQGroupTree.Name = "cbxDtuGroup1";
            cbgQGroupTree.Size = new System.Drawing.Size(101, 20);
            cbgQGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.gbxSearch.Controls.Add(cbgQGroupTree);
            cbgQGroupTree.BringToFront();
            Init();
        }

        private void cbgQGroupTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupCode = cbgQGroupTree.TreeView.SelectedNode.Name;
            cbxQDtu.DataSource = ServiceProxy.DTUServiceProxy.GetDtuListByGroupCode(LocalIP, groupCode);
            cbxQDtu.DisplayMember = "DtuidName";
            cbxQDtu.ValueMember = "Dtuid";
        }

        private void cbgGroupTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupCode = cbgGroupTree.TreeView.SelectedNode.Name;
            cbxDtu.DataSource = ServiceProxy.DTUServiceProxy.GetDtuListByGroupCode(LocalIP, groupCode);
            cbxDtu.DisplayMember = "DtuidName";
            cbxDtu.ValueMember = "Dtuid";
        }
        /// <summary>
        /// 初始数据绑定
        /// </summary>
        private void Init()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("加载公司数据!");
                CompanyBind();
                ClearForm();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.PopProgressBar("初始绑定数据出错:" + ex.Message);
            }
            finally
            {
                pbh.CloseProgressBar();
            }
        }
        /// <summary>
        /// 绑定公司数据源
        /// </summary>
        private void CompanyBind()
        {
            //这里因为查询和添加用的数据源一样所以采取新建一个空数据源，然后再往里面插入数据一完成克隆数据源的作用
            List<ServiceProxy.CompanyService.CompanyIDAndName> Companylist = ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
            cbxCompany.DataSource = Companylist;
            cbxCompany.DisplayMember = "CompanyName";
            cbxCompany.ValueMember = "CompanyId";
            cbxCompany.SelectedIndex = 0;

            List<ServiceProxy.CompanyService.CompanyIDAndName> ClonedCompanyList = CloneUtil.GetClone<List<ServiceProxy.CompanyService.CompanyIDAndName>>(Companylist);
            cbxQCompany.DataSource = ClonedCompanyList;
            cbxQCompany.DisplayMember = "CompanyName";
            cbxQCompany.ValueMember = "CompanyId";
        }
        /// <summary>
        /// 站点分组信息树形结构绑定
        /// </summary>
        private void DtuGroupBind(int CompanyId)
        {
            List<ServiceProxy.DTUService.T_DTU_Group> dtuGroups = ServiceProxy.DTUServiceProxy.GetDtuGroupsByCompanyId(LocalIP, CompanyId);
            cbgGroupTree.Items.Clear();
            cbgGroupTree.TreeView.Nodes.Clear();
            if (dtuGroups.Count > 0)
            {
                BindGroupTree0(dtuGroups, "0", null);
                if (cbgGroupTree.TreeView.Nodes.Count > 0)
                {
                    cbgGroupTree.TreeView.SelectedNode = cbgGroupTree.TreeView.Nodes[0];
                    cbgGroupTree.Items.Add(cbgGroupTree.TreeView.SelectedNode.Text);
                    cbgGroupTree.SelectedIndex = 0;
                }
            }
        }
        /// <summary>
        /// 递归绑定站点分组数据源（添加数据用）
        /// </summary>
        /// <param name="dtTreeData">数据</param>
        /// <param name="parentCode">父编码</param>
        /// <param name="nodes">树节点</param>
        private void BindGroupTree0(List<ServiceProxy.DTUService.T_DTU_Group> dtTreeData, string parentCode, TreeNode nodes)
        {
            if (nodes == null)
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    cbgGroupTree.TreeView.Nodes.Add(tNode);
                    BindGroupTree0(dtTreeData, tNode.Name, tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    nodes.Nodes.Add(tNode);
                    BindGroupTree0(dtTreeData, tNode.Name, tNode);
                }
            }
            cbgGroupTree.TreeView.ExpandAll();
        }
        private void BindQueryData()
        {
            int cmpId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
            string groupCode = string.Empty;
            string dtuid = string.Empty;
            if (cbgQGroupTree.TreeView.SelectedNode != null && cbgQGroupTree.TreeView.SelectedNode.Name != "-1")
            {
                groupCode = cbgQGroupTree.TreeView.SelectedNode.Name;
            }
            if (cbxQDtu.SelectedItem != null)
            {
                dtuid = (cbxQDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid;
            }
            dgvValve.DataSource = ServiceProxy.DTUServiceProxy.GetValveModelListBy(LocalIP, cmpId, groupCode, dtuid);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] codePart = txtValveCode.Text.Trim().Split('_');
            if (codePart.Length != 2)
            {
                MessageUtil.ShowTips("阀门编号格式不正确(站点编号_序号)!");
                return;
            }
            if (DTUServiceProxy.CheckValveExists(LocalIP, txtValveCode.Text.Trim()))
            {
                MessageUtil.ShowTips(string.Format("阀门编号:{0}已经存在!", txtValveCode.Text.Trim()));
                return;
            }
            ServiceProxy.CommonService.EnumExistsStatus flag = CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_DTU]", "Dtuid", codePart[0]);
            if (flag != ServiceProxy.CommonService.EnumExistsStatus.Exists)
            {
                MessageUtil.ShowTips(string.Format("站点编号:{0}不存在!", codePart[0]));
                return;
            }
            int outInt = 0;
            if (!int.TryParse(txtEffctUserNum.Text.Trim(), out outInt))
            {
                MessageUtil.ShowTips("影响数量必须是正整数!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存阀门影响数据!");
                ServiceProxy.DTUService.T_DTU_ValveEffect model = new ServiceProxy.DTUService.T_DTU_ValveEffect();
                model.ValveCode = txtValveCode.Text.Trim();
                model.ValveName = txtValveName.Text.Trim();
                model.EffctArea = txtEffctArea.Text.Trim();
                model.EffctUserNum = int.Parse(txtEffctUserNum.Text.Trim());
                model.ClosedTime = dtpCloseTime.Value;
                model.Dtuid = (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid;
                DTUServiceProxy.AddValveInfo(LocalIP, model);
                BindQueryData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加阀门数据:ID-{0},Name-{1}", model.ValveCode, model.EffctArea), 1);
                pbh.CloseProgressBar();
                MessageUtil.ShowTips("保存成功!");
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
            int outInt = 0;
            if (!int.TryParse(txtEffctUserNum.Text.Trim(), out outInt))
            {
                MessageUtil.ShowTips("影响数量必须是正整数!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存修改的阀门影响数据!");
                ServiceProxy.DTUService.T_DTU_ValveEffect model = new ServiceProxy.DTUService.T_DTU_ValveEffect();
                model.ValveCode = curModel.ValveCode;
                model.ValveName = txtValveName.Text.Trim();
                model.EffctArea = txtEffctArea.Text.Trim();
                model.EffctUserNum = int.Parse(txtEffctUserNum.Text.Trim());
                model.ClosedTime = dtpCloseTime.Value;
                model.Dtuid = curModel.Dtuid;
                ServiceProxy.DTUServiceProxy.UpdateValveInfo(LocalIP, model);
                BindQueryData();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改阀门数据:ID-{0},Name-{1}", model.ValveCode, model.EffctArea), 1);
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
                pbh.PopProgressBar("正在删除阀门影响数据!");
                DataGridViewRow row = dgvValve.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.DTUService.T_DTU_ValveEffect;
                if (ServiceProxy.DTUServiceProxy.DeleteValveInfo(LocalIP, model.ValveCode))
                {
                    ClearForm();
                    BindQueryData();
                }
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除阀门数据:ID-{0},Name-{1}", model.ValveCode, model.EffctArea), 1);
                pbh.CloseProgressBar();
                MessageUtil.ShowTips("删除成功!");
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
            cbxCompany.Enabled = true;
            cbgGroupTree.Enabled = true;
            cbxDtu.Enabled = true;
            curModel = null;
            ClearForm();
        }
        private void ClearForm()
        {
            txtValveName.Text = "[阀门1]";
            txtEffctArea.Text = "";
            txtEffctUserNum.Text = "0";
            txtValveCode.Text = "";
            dtpCloseTime.Value = DateTime.Now;
            cbxCompany.SelectedIndex = 0;
            if (cbgGroupTree.Items.Count > 0)
            {
                cbgGroupTree.SelectedIndex = 0;
            }
            cbxDtu.DataSource = null;
        }

        private void dgvValve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxCompany.Enabled = false;
            cbgGroupTree.Enabled = false;
            cbxDtu.Enabled = false;
            btnAdd.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            curModel = dgvValve.Rows[e.RowIndex].DataBoundItem as ServiceProxy.DTUService.T_DTU_ValveEffect;
            txtValveCode.Text = curModel.ValveCode;
            txtValveName.Text = curModel.ValveName;
            txtEffctUserNum.Text = curModel.EffctUserNum.ToString();
            txtEffctArea.Text = curModel.EffctArea;
            ServiceProxy.DTUService.T_DTU_Group dtuGroup = ServiceProxy.DTUServiceProxy.GetDtuGroupByDtuId(LocalIP, curModel.Dtuid);
            if (dtuGroup != null)//如果这个站点所属分组不为空
            {
                cbxCompany.SelectedValue = dtuGroup.CompanyId;
                if (cbgGroupTree.TreeView.Nodes.Count > 0)//如果本公司下面有分组
                {
                    if (cbgGroupTree.TreeView.Nodes.Find(dtuGroup.GroupCode, true).Length > 0)//如果找到这个分组就开始设置界面本站点的分组
                    {
                        cbgGroupTree.TreeView.SelectedNode = cbgGroupTree.TreeView.Nodes.Find(dtuGroup.GroupCode, true)[0];
                        cbgGroupTree.Items.Clear();
                        cbgGroupTree.Items.Add(cbgGroupTree.TreeView.SelectedNode.Text);
                        cbgGroupTree.SelectedIndex = 0;
                    }
                    else//否则本站点没有被绑定到公司下面的分组这里默认显示空但是分组控件依然绑定公司下面的分组
                    {
                        cbgGroupTree.TreeView.SelectedNode = null;
                        cbgGroupTree.SelectedIndex = -1;
                    }
                }
                else//没有分组的情况下清除分组选框等用户选择了公司后回重新绑定
                {
                    cbgGroupTree.TreeView.SelectedNode = null;
                    cbgGroupTree.TreeView.Nodes.Clear();
                    cbgGroupTree.Items.Clear();
                }
            }
            else//没有分组的情况下清除分组选框等用户选择了公司后回重新绑定
            {
                cbgGroupTree.TreeView.SelectedNode = null;
                cbgGroupTree.TreeView.Nodes.Clear();
                cbgGroupTree.Items.Clear();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载查询的站点数据!");
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
        /// 递归绑定站点分组数据源（查询用）
        /// </summary>
        /// <param name="dtTreeData">数据</param>
        /// <param name="parentCode">父编码</param>
        /// <param name="nodes">树节点</param>
        private void BindGroupTree1(List<ServiceProxy.DTUService.T_DTU_Group> dtTreeData, string parentCode, TreeNode nodes)
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
                    BindGroupTree1(dtTreeData, tNode.Name, tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Name = row.GroupCode };
                    nodes.Nodes.Add(tNode);
                    BindGroupTree1(dtTreeData, tNode.Name, tNode);
                }
            }
            cbgQGroupTree.TreeView.ExpandAll();
        }
        private void cbxQCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxQDtu.DataSource = null;
            if (cbxQCompany.SelectedItem != null)
            {
                cbgQGroupTree.SelectedIndexChanged -= new EventHandler(cbgQGroupTree_SelectedIndexChanged);
                int CompanyId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                List<ServiceProxy.DTUService.T_DTU_Group> dtuGroups = ServiceProxy.DTUServiceProxy.GetDtuGroupsByCompanyId(LocalIP, CompanyId);
                cbgQGroupTree.Items.Clear();
                cbgQGroupTree.TreeView.Nodes.Clear();
                if (dtuGroups != null && dtuGroups.Count != 0)
                {
                    BindGroupTree1(dtuGroups, "0", null);
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
                cbgQGroupTree.SelectedIndexChanged += new EventHandler(cbgQGroupTree_SelectedIndexChanged);
            }
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDtu.DataSource = null;
            if (cbxCompany.SelectedItem != null)
            {
                int CompanyId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                cbgGroupTree.SelectedIndexChanged -= new EventHandler(cbgGroupTree_SelectedIndexChanged);
                DtuGroupBind(CompanyId);
                cbgGroupTree.SelectedIndexChanged += new EventHandler(cbgGroupTree_SelectedIndexChanged);
            }
        }

        private void FrmValveEffect_Load(object sender, EventArgs e)
        {
            if (cbgGroupTree.TreeView.Nodes.Count > 0)
            {
                cbgGroupTree.Items.Clear();
                cbgGroupTree.Items.Add(cbgGroupTree.TreeView.Nodes[0].Text);
                cbgGroupTree.SelectedIndex = 0;
            }
        }

        private void cbxDtu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDtu.SelectedItem != null)
            {
                int cmpId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                string dtuid = (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid;
                int count = ServiceProxy.DTUServiceProxy.GetValveModelListBy(LocalIP, cmpId, string.Empty, dtuid).Count;
                txtValveCode.Text = string.Format("{0}_{1}", dtuid, count + 1);
            }
        }
    }
}
