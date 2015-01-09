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
    public partial class FrmDTU : FrmBase
    {
        #region Private
        ComboBoxTreeView cbgGroupTree;
        ComboBoxTreeView cbgQGroupTree;
        //isMod这个变量来控制是否自动生成Dtuid,以避免双击行修改是负值的Dtuid被重置
        bool isMod = false;
        //OriConfigCode这个变量来辨识站点配置是否被修改了,如果没有被修改就可以避免给站点表添加字段的带来的大量操作
        string OriConfigCode = string.Empty;
        int curFlag = 1;
        private static string _longi = "";
        private static string _lati = "";
        #endregion

        public FrmDTU()
        {
            InitializeComponent();
            //加载ComboBoxTree0控件
            cbgGroupTree = new ComboBoxTreeView();//添加用
            cbgGroupTree.Location = new System.Drawing.Point(88, 335);
            cbgGroupTree.Name = "cbxDtuGroup0";
            cbgGroupTree.Size = new System.Drawing.Size(96, 20);
            cbgGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.gbxDetail.Controls.Add(cbgGroupTree);
            cbgGroupTree.BringToFront();
            //
            cbgQGroupTree = new ComboBoxTreeView();//查询条件用
            cbgQGroupTree.Location = new System.Drawing.Point(430, 21);
            cbgQGroupTree.Name = "cbxDtuGroup1";
            cbgQGroupTree.Size = new System.Drawing.Size(96, 20);
            cbgQGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbgQGroupTree);
            cbgQGroupTree.BringToFront();
            DrpProtocolVersion.SelectedIndex = 0;
            Init();
        }

        #region Method
        /// <summary>
        /// 初始数据绑定
        /// </summary>
        private void Init()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("加载公司数据!");
                BindDtuType();
                CompanyBind();
                pbh.PopProgressBar("加载压力等级数据!");
                PressureLevelBind();
                pbh.PopProgressBar("加载站点配置数据!");
                DtuConfigBind();
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
        /// 绑定DTU类型
        /// </summary>
        private void BindDtuType()
        {
            DrpProtocolVersion.Items.Clear();
            DrpProtocolVersion.Items.Add(new CheckedListBoxItem("流量计终端", "AA55"));
            DrpProtocolVersion.Items.Add(new CheckedListBoxItem("压力记录仪", "AA56"));
            DrpProtocolVersion.Items.Add(new CheckedListBoxItem("加臭终端", "AA58"));
            DrpProtocolVersion.Items.Add(new CheckedListBoxItem("加臭终端(新)", "AA59"));
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
        /// <summary>
        /// 绑定站点配置数据源
        /// </summary>
        private void DtuConfigBind()
        {
            cbxDtuConfig.DataSource = ServiceProxy.DTUServiceProxy.GetDtuConfigsByStatus(LocalIP, 1);
            cbxDtuConfig.DisplayMember = "ConfigName";
            cbxDtuConfig.ValueMember = "ConfigCode";
        }
        /// <summary>
        /// 绑定压力等级数据源
        /// </summary>
        private void PressureLevelBind()
        {
            cbxPressureLevel.DataSource = ServiceProxy.DTUServiceProxy.GetDtuPressureLevelByStatus(LocalIP, 1);
            cbxPressureLevel.DisplayMember = "PressureName";
            cbxPressureLevel.ValueMember = "Id";
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
            ClonedCompanyList.Insert(0, new ServiceProxy.CompanyService.CompanyIDAndName() { CompanyId = -1, CompanyName = "全部" });
            cbxQCompany.DataSource = ClonedCompanyList;
            cbxQCompany.DisplayMember = "CompanyName";
            cbxQCompany.ValueMember = "CompanyId";

            List<string> DtuIdlst = ServiceProxy.DTUServiceProxy.GenerateDtuidList(LocalIP, (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId, 1);
            txtDtuid.Text = DtuIdlst[0];
        }
        /// <summary>
        /// 
        /// </summary>
        private void ClearForm()
        {
            txtDtuid.Text = "";
            txtDtuidLocation.Text = "四川省成都市青羊区XX街";
            txtDtuName.Text = "XXX工业用户";
            txtFlowBrand.Text = "苍南/天信";
            txtFlowType.Text = "Winfo-001";
            txtLgPwd.Text = "123456";
            txtLongitude.Text = "103.940658";
            txtLatitude.Text = "30.702892";
            txtSkidbrand.Text = "Joyu/Winfo";
            txtSupplier.Text = "久宇/英菲信";
            txtPhoneNum.Text = "13800138000";
            DrpProtocolVersion.SelectedIndex = 0;
            dtpRegDate.Value = DateTime.Now;
            dtpRunDate.Value = DateTime.Now;
            cbxPressureLevel.SelectedIndex = 0;
            if (cbgGroupTree.Items.Count > 0)
            {
                cbgGroupTree.SelectedIndex = 0;
            }
            if (cbxDtuConfig.Items.Count > 11)
            {
                cbxDtuConfig.SelectedIndex = 11;
            }
            if (cbxCompany.Items.Count > 5)
                cbxCompany.SelectedIndex = 6;
            numDUDayFrom.Value = 8;
            numUDDataInterval.Value = 2;
            numUDMonthFrom.Value = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        private void BindQueryData()
        {
            int cmpId = 0;
            string groupCode = string.Empty;
            string dtuidName = string.Empty;
            if (cbxQCompany.SelectedIndex != 0)
            {
                cmpId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
            }
            if (cbgQGroupTree.TreeView.SelectedNode != null && cbgQGroupTree.TreeView.SelectedNode.Name != "-1")
            {
                groupCode = cbgQGroupTree.TreeView.SelectedNode.Name;
            }
            if (!string.IsNullOrEmpty(txtQDtuName.Text))
            {
                dtuidName = txtQDtuName.Text.Trim();
            }
            dgvDtuList.DataSource = ServiceProxy.DTUServiceProxy.GetDtuListBy(LocalIP, 1, cmpId, groupCode, dtuidName);
        }
        /// <summary>
        /// 设置经纬度
        /// </summary>
        /// <param name="longi"></param>
        /// <param name="lati"></param>
        public static void SetLongiLati(string longi, string lati)
        {
            _longi = longi;
            _lati = lati;
        }
        #endregion

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            new FrmCompany().ShowDialog();
            cbxCompany.DataSource = null;
            CompanyBind();
        }

        private void btnAddPressureLevel_Click(object sender, EventArgs e)
        {
            new FrmDtuPressureLevel().ShowDialog();
            cbxPressureLevel.DataSource = null;
            PressureLevelBind();
        }

        private void btnAddDtuGroup_Click(object sender, EventArgs e)
        {
            new FrmDtuGroup().ShowDialog();
            cbgGroupTree.DataSource = null;
            cbgGroupTree.TreeView.Nodes.Clear();
            if (cbxCompany.SelectedItem != null)
            {
                DtuGroupBind((cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId);
            }
        }

        private void btnDtuConfig_Click(object sender, EventArgs e)
        {
            new FrmDtuConfig().ShowDialog();
            cbxDtuConfig.DataSource = null;
            DtuConfigBind();
        }

        /// <summary>
        /// 根据选中的公司动态生成当前站点ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCompany.SelectedItem != null)
            {
                int CompanyId = (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                if (!isMod)
                {
                    List<string> DtuIdlst = ServiceProxy.DTUServiceProxy.GenerateDtuidList(LocalIP, CompanyId, 1);
                    txtDtuid.Text = DtuIdlst[0];
                }
                DtuGroupBind(CompanyId);
            }
        }

        private void FrmDTU_Load(object sender, EventArgs e)
        {
            if (cbgGroupTree.TreeView.Nodes.Count > 0)
            {
                cbgGroupTree.Items.Clear();
                cbgGroupTree.Items.Add(cbgGroupTree.TreeView.Nodes[0].Text);
                cbgGroupTree.SelectedIndex = 0;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            ServiceProxy.CommonService.EnumExistsStatus flag = ServiceProxy.CommonServiceProxy.CheckIfIDIsExists(LocalIP, "[Infa]..[T_DTU]", "Dtuid", txtDtuid.Text.Trim());
            if (flag == ServiceProxy.CommonService.EnumExistsStatus.Exists)
            {
                MessageBox.Show("这个站点编号已经存在,请另外填写一个编号!");
                return;
            }
            if (txtDtuid.Text.Trim().Length != 8)
            {
                MessageBox.Show("站点编号必须是8位!");
                return;
            }
            if (string.IsNullOrEmpty(txtDtuName.Text))
            {
                MessageBox.Show("站点名称不能为空!");
                return;
            }
            if (cbgGroupTree.TreeView.SelectedNode == null)
            {
                MessageBox.Show("请选择站点所属分组!");
                return;
            }
            if (DrpProtocolVersion.SelectedItem == null)
            {
                MessageBox.Show("协议版本不能为空!");
                return;
            }
            if (numUploadInterval.Value < numUDDataInterval.Value)
            {
                MessageBox.Show("【上传频率】必须小于等于【采集频率】!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存站点数据!");
                ServiceProxy.DTUService.T_DTU dtu = new ServiceProxy.DTUService.T_DTU();
                dtu.DayFrom = int.Parse(numDUDayFrom.Value.ToString());
                dtu.Dtuid = txtDtuid.Text;
                dtu.DtuidLocation = txtDtuidLocation.Text.Trim();
                dtu.DtuidName = txtDtuName.Text.Trim();
                dtu.FlowBrand = txtFlowBrand.Text.Trim();
                dtu.FlowType = txtFlowType.Text.Trim();
                dtu.Latitude = double.Parse(txtLatitude.Text.Trim());
                dtu.LgPwd = txtLgPwd.Text.Trim();
                dtu.Longitude = double.Parse(txtLongitude.Text.Trim());
                dtu.PressureLevel = cbxPressureLevel.SelectedValue.ToString();
                dtu.RegDate = dtpRegDate.Value;
                dtu.RunDate = dtpRunDate.Value;
                dtu.Skidbrand = txtSkidbrand.Text.Trim();
                dtu.Supplier = txtSupplier.Text.Trim();
                dtu.DataInterval = Convert.ToInt32(numUDDataInterval.Value);
                dtu.UpLoadInterval = Convert.ToInt32(numUploadInterval.Value);
                dtu.UpdateFlag = 1;
                dtu.Status = 1;
                dtu.GroupCode = cbgGroupTree.TreeView.SelectedNode.Name;
                dtu.ConfigCode = cbxDtuConfig.SelectedValue.ToString();
                dtu.OrderId = Convert.ToInt32(nudOrder.Value);
                dtu.PhoneNum = txtPhoneNum.Text.Trim();
                dtu.ProtocolVersion = ((CheckedListBoxItem)DrpProtocolVersion.SelectedItem).Value;
                dtu.MonthFrom = Convert.ToInt32(numUDMonthFrom.Value) - 1;
                if (flag == ServiceProxy.CommonService.EnumExistsStatus.Invalid)
                {
                    ServiceProxy.DTUServiceProxy.UpdateDTU(LocalIP, dtu);
                }
                else
                {
                    ServiceProxy.DTUServiceProxy.AddDTU(LocalIP, dtu);
                }
                //检查是否存在该站点的表,如果不存在则创建
                ServiceProxy.DTUServiceProxy.CheckAndCreateDtuTable(dtu.Dtuid, LocalIP);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点:ID-{0},Name-{1}", dtu.Dtuid, dtu.DtuidName), 1);
                pbh.CloseProgressBar();
                if (MessageBox.Show("数据保存成功,转入下一步?", "提示!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Hide();
                    var dtuConfig = (cbxDtuConfig.DataSource as List<ServiceProxy.DTUService.T_DTU_Config>).Find(p => p.ConfigCode == cbxDtuConfig.SelectedValue.ToString());
                    if (new FrmDtuField(txtDtuid.Text.Trim(), txtDtuName.Text.Trim(), (cbxCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId, dtuConfig).ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
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
            }
        }

        private void dgvDtuList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            isMod = true;
            DataGridViewRow row = dgvDtuList.SelectedRows[0];
            var model = row.DataBoundItem as ServiceProxy.DTUService.DTU;
            ServiceProxy.DTUService.T_DTU dtu = ServiceProxy.DTUServiceProxy.GetDtuByDtuid(model.Dtuid, LocalIP);
            txtDtuid.Text = dtu.Dtuid;
            txtDtuidLocation.Text = dtu.DtuidLocation;
            txtDtuName.Text = dtu.DtuidName;
            txtFlowBrand.Text = dtu.FlowBrand;
            txtFlowType.Text = dtu.FlowType;
            txtLatitude.Text = dtu.Latitude.ToString();
            txtLgPwd.Text = dtu.LgPwd;
            txtLongitude.Text = dtu.Longitude.ToString();
            txtLatitude.Text = dtu.Latitude.ToString();
            txtSkidbrand.Text = dtu.Skidbrand;
            txtSupplier.Text = dtu.Supplier;
            dtpRegDate.Value = dtu.RegDate;
            dtpRunDate.Value = dtu.RunDate;
            cbxPressureLevel.SelectedValue = int.Parse(dtu.PressureLevel);
            cbgGroupTree.SelectedValue = dtu.GroupCode;
            cbxDtuConfig.SelectedValue = dtu.ConfigCode;
            numUDDataInterval.Value = dtu.DataInterval;
            numUploadInterval.Value = dtu.UpLoadInterval;
            nudOrder.Value = dtu.OrderId;
            OriConfigCode = dtu.ConfigCode;
            numUDMonthFrom.Value = dtu.MonthFrom;
            txtPhoneNum.Text = dtu.PhoneNum;
            foreach (CheckedListBoxItem drpitm in DrpProtocolVersion.Items)
            {
                if (drpitm.Value == dtu.ProtocolVersion)
                {
                    DrpProtocolVersion.SelectedItem = drpitm;
                    break;
                }
            }
            ServiceProxy.DTUService.T_DTU_Group dtuGroup = ServiceProxy.DTUServiceProxy.GetDtuGroupById(LocalIP, dtu.GroupCode);
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
            numDUDayFrom.Value = decimal.Parse(dtu.DayFrom.ToString());
            curFlag = dtu.UpdateFlag;
            btnAdd.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            txtDtuid.ReadOnly = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            txtDtuid.ReadOnly = false;
            cbxDtuConfig.Enabled = true;
            isMod = false;
            ClearForm();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDtuName.Text))
            {
                MessageBox.Show("站点名称不能为空!");
                return;
            }
            if (cbgGroupTree.TreeView.SelectedNode == null)
            {
                MessageBox.Show("请选择站点所属分组!");
                return;
            }
            if (numUploadInterval.Value < numUDDataInterval.Value)
            {
                MessageBox.Show("【上传频率】必须小于等于【采集频率】!");
                return;
            }
            if (DrpProtocolVersion.SelectedItem == null)
            {
                MessageBox.Show("协议版本不能为空!");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存修改的站点数据!");
                ServiceProxy.DTUService.T_DTU dtu = new ServiceProxy.DTUService.T_DTU();
                dtu.DayFrom = int.Parse(numDUDayFrom.Value.ToString());
                dtu.Dtuid = txtDtuid.Text.Trim();
                dtu.DtuidLocation = txtDtuidLocation.Text.Trim();
                dtu.DtuidName = txtDtuName.Text.Trim();
                dtu.FlowBrand = txtFlowBrand.Text.Trim();
                dtu.FlowType = txtFlowType.Text.Trim();
                dtu.Latitude = double.Parse(txtLatitude.Text.Trim());
                dtu.LgPwd = txtLgPwd.Text.Trim();
                dtu.Longitude = double.Parse(txtLongitude.Text.Trim());
                dtu.PressureLevel = cbxPressureLevel.SelectedValue.ToString();
                dtu.RegDate = dtpRegDate.Value;
                dtu.RunDate = dtpRunDate.Value;
                dtu.Skidbrand = txtSkidbrand.Text.Trim();
                dtu.Supplier = txtSupplier.Text.Trim();
                dtu.DataInterval = Convert.ToInt32(numUDDataInterval.Value);
                dtu.UpLoadInterval = Convert.ToInt32(numUploadInterval.Value);
                dtu.UpdateFlag = curFlag + 1;
                dtu.Status = 1;
                dtu.GroupCode = cbgGroupTree.TreeView.SelectedNode.Name;
                dtu.ConfigCode = cbxDtuConfig.SelectedValue.ToString();
                dtu.OrderId = Convert.ToInt32(nudOrder.Value);
                dtu.PhoneNum = txtPhoneNum.Text.Trim();
                dtu.ProtocolVersion = ((CheckedListBoxItem)DrpProtocolVersion.SelectedItem).Value;
                dtu.MonthFrom = Convert.ToInt32(numUDMonthFrom.Value) - 1;
                ServiceProxy.DTUServiceProxy.UpdateDTU(LocalIP, dtu);
                BindQueryData();
                if (OriConfigCode != dtu.ConfigCode)
                {
                    pbh.PopProgressBar("正在修改站点配置数据!");
                    ServiceProxy.DTUServiceProxy.UpdateDtuTable(LocalIP, dtu.Dtuid, OriConfigCode);
                    OriConfigCode = dtu.ConfigCode;
                }
                pbh.CloseProgressBar();
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改站点:ID-{0},Name-{1}", dtu.Dtuid, dtu.DtuidName), 1);
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
                pbh.PopProgressBar("正在删除所选站点数据!");
                DataGridViewRow row = dgvDtuList.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.DTUService.DTU;
                ServiceProxy.DTUServiceProxy.DeleteDtuByDtuid(LocalIP, model.Dtuid);
                ClearForm();
                this.txtDtuid.Enabled = true;
                BindQueryData();
                pbh.CloseProgressBar();
                isMod = false;
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点:ID-{0},Name-{1}", model.Dtuid, model.DtuidName), 1);
                MessageBox.Show("删除成功!");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("删除失败:" + ex.Message);
            }
        }

        private void btn_GetLongitude_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDTULongiLati frm = new FrmDTULongiLati();
                frm.ShowDialog(this);
                frm.Dispose();
                frm = null;
                this.txtLongitude.Text = _longi;
                this.txtLatitude.Text = _lati;
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
            }
        }
    }
}
