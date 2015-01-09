using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;
using Com.Winfotian.Components.Enumerations;
using System.Collections.Specialized;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuFieldManager : FrmBase
    {
        ComboBoxTreeView cbgQGroupTree;
        DTUFieldDesc curModel;
        public FrmDtuFieldManager()
        {
            InitializeComponent();
            //
            cbgQGroupTree = new ComboBoxTreeView();//查询条件用
            cbgQGroupTree.Location = new System.Drawing.Point(434, 21);
            cbgQGroupTree.Name = "cbxDtuGroup1";
            cbgQGroupTree.Size = new System.Drawing.Size(154, 20);
            cbgQGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbgQGroupTree);
            cbgQGroupTree.BringToFront();
            cbgQGroupTree.SelectedIndexChanged += new EventHandler(cbgQGroupTree_SelectedIndexChanged);
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载公司数据!");
                CompanyBind();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("加载公司数据失败:" + ex.Message);
            }
            cbxQFieldName.SelectedIndex = 0;
        }

        private void cbgQGroupTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDtu.DataSource = null;
            if (cbgQGroupTree.TreeView.SelectedNode.Tag.ToString() == "-1")
            {
                List<ServiceProxy.DTUService.DTU> dtuList = new List<ServiceProxy.DTUService.DTU>();
                dtuList.Add(new ServiceProxy.DTUService.DTU() { Dtuid = "-1", DtuidName = "全部" });
                cbxDtu.DataSource = dtuList;
                cbxDtu.DisplayMember = "DtuidName";
                cbxDtu.ValueMember = "DtuId";
            }
            else
            {
                List<ServiceProxy.DTUService.DTU> dtuList = ServiceProxy.DTUServiceProxy.GetDtuListByGroupCode(LocalIP, cbgQGroupTree.TreeView.SelectedNode.Tag.ToString());
                dtuList.Insert(0, new ServiceProxy.DTUService.DTU() { Dtuid = "-1", DtuidName = "全部" });
                cbxDtu.DataSource = dtuList;
                cbxDtu.DisplayMember = "DtuidName";
                cbxDtu.ValueMember = "DtuId";
            }
            cbxDtu.SelectedIndex = 0;
        }
        /// <summary>
        /// 绑定公司数据源
        /// </summary>
        private void CompanyBind()
        {
            List<ServiceProxy.CompanyService.CompanyIDAndName> lisCompany = ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
            cbxQCompany.DataSource = lisCompany;
            cbxQCompany.DisplayMember = "CompanyName";
            cbxQCompany.ValueMember = "CompanyId";
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
                TreeNode tFirstNode = new TreeNode() { Text = "全部", Tag = "-1" };
                cbgQGroupTree.TreeView.Nodes.Add(tFirstNode);
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Tag = row.GroupCode };
                    cbgQGroupTree.TreeView.Nodes.Add(tNode);
                    BindGroupTree1(dtTreeData, tNode.Tag.ToString(), tNode);
                }
            }
            else
            {
                var rowList = dtTreeData.FindAll(p => p.ParentCode == parentCode);
                foreach (var row in rowList)
                {
                    TreeNode tNode = new TreeNode() { Text = row.GroupName, Tag = row.GroupCode };
                    nodes.Nodes.Add(tNode);
                    BindGroupTree1(dtTreeData, tNode.Tag.ToString(), tNode);
                }
            }
            cbgQGroupTree.TreeView.ExpandAll();
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在查站点字段数据!");
                QueryDataBind();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("查询失败:" + ex.Message);
            }
        }

        private void QueryDataBind()
        {
            int cmpId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
            string groupCode = string.Empty;
            string dtuid = string.Empty;
            string fieldName = string.Empty;
            if (cbgQGroupTree.TreeView.SelectedNode.Tag.ToString() != "-1")
            {
                groupCode = cbgQGroupTree.TreeView.SelectedNode.Tag.ToString();
            }
            if ((cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid != "-1")
            {
                dtuid = (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid;
            }
            if (cbxQFieldName.SelectedIndex != 0)
            {
                fieldName = GetFieldName(Convert.ToInt32(drp_SelIndex.Value), cbxQFieldName.Text.Trim());
            }
            List<ServiceProxy.DTUService.T_DTU_FieldDesc> models = ServiceProxy.DTUServiceProxy.GetFieldBy(LocalIP, cmpId, groupCode, dtuid, fieldName);
            List<DTUFieldDesc> newModels = new List<DTUFieldDesc>();
            foreach (var item in models)
            {
                DTUFieldDesc model = new DTUFieldDesc();
                model.Id = item.Id;
                model.ColName = item.ColName;
                model.Dtuid = item.Dtuid;
                model.FieldDesc = item.FieldDesc;
                model.FieldName = item.FieldName;
                model.FieldShortDesc = item.FieldShortDesc;
                model.FieldUnit = item.FieldUnit;
                model.Highlimit = item.Highlimit;
                model.Hihilimit = item.Hihilimit;
                model.IsAlert = item.IsAlert == 1 ? "是" : "否";
                model.IsCollect = item.IsCollect == 1 ? "是" : "否";
                model.IsShow = item.IsShow == 1 ? "是" : "否";
                model.KeyValues = item.KeyValues;
                model.Lololimit = item.Lololimit;
                model.Lowlimit = item.Lowlimit;
                model.OrderId = item.OrderId;
                model.ParentId = item.ParentId;
                model.UpdateFlag = item.UpdateFlag;
                switch (item.ValueInOrOut)
                {
                    case 0:
                        model.ValueInOrOut = "不分进出口";
                        break;
                    case 1:
                        model.ValueInOrOut = "进";
                        break;
                    case 2:
                        model.ValueInOrOut = "出";
                        break;
                    default:
                        model.ValueInOrOut = "不分进出口";
                        break;
                }
                switch (item.FieldType)
                {
                    case 0:
                        model.FieldType = "不统计";
                        break;
                    case 1:
                        model.FieldType = "累计";
                        break;
                    case 2:
                        model.FieldType = "示数";
                        break;
                    case 3:
                        model.FieldType = "平均";
                        break;
                    default:
                        model.FieldType = "不统计";
                        break;
                }
                model.ValueMax = item.ValueMax;
                model.ValueMin = item.ValueMin;
                newModels.Add(model);
            }
            dgvField.DataSource = newModels;
        }

        private void cbxQCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxQCompany.SelectedItem != null)
            {
                int CompanyId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
                var dtuGroups = ServiceProxy.DTUServiceProxy.GetDtuGroupsByCompanyId(LocalIP, CompanyId);
                cbgQGroupTree.Items.Clear();
                cbgQGroupTree.TreeView.Nodes.Clear();
                BindGroupTree1(dtuGroups, "0", null);
                cbgQGroupTree.TreeView.SelectedNode = cbgQGroupTree.TreeView.Nodes[0];
                cbgQGroupTree.Items.Add(cbgQGroupTree.TreeView.SelectedNode.Text);
                cbgQGroupTree.SelectedIndex = 0;
                BindcbxDtuid(CompanyId);
            }
        }
        /// <summary>
        /// 站点编号列表绑定
        /// </summary>
        /// <param name="CompanyId"></param>
        private void BindcbxDtuid(int CompanyId)
        {
            cbxDtuid.Items.Clear();
            List<string> dtuidList = ServiceProxy.DTUServiceProxy.GetDtuidListByCompanyId(LocalIP, CompanyId);
            if (dtuidList.Count > 0)
            {
                foreach (string item in dtuidList)
                {
                    cbxDtuid.Items.Add(item);
                }
                cbxDtuid.SelectedIndex = 0;
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            #region Validate
            if (curModel == null)
            {
                MessageBox.Show("请选择要修改的数据行!");
                return;
            }
            if (string.IsNullOrEmpty(txtFieldShortDesc.Text))
            {
                MessageBox.Show("字段短描述不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtFieldDesc.Text))
            {
                MessageBox.Show("字段描述不能为空!");
                return;
            }
            if (!ToolHelper.IsNumberSign(txtValueMin.Text))
            {
                MessageBox.Show("字段最小值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumber(txtValueMax.Text))
            {
                MessageBox.Show("字段最大值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumberSign(txtLowlimit.Text))
            {
                MessageBox.Show("字段低报警值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumber(txtHighlimit.Text))
            {
                MessageBox.Show("字段高报警值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumberSign(txtLololimit.Text))
            {
                MessageBox.Show("字段最低报警值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumber(txtHihilimit.Text))
            {
                MessageBox.Show("字段最高报警值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumber(txt_Order.Text))
            {
                MessageBox.Show("字段排序序号必须为数字!");
                return;
            }
            #endregion
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改站点字段数据!");
                ServiceProxy.DTUService.T_DTU_FieldDesc dtuField = new ServiceProxy.DTUService.T_DTU_FieldDesc();
                dtuField.Id = curModel.Id;
                dtuField.Dtuid = cbxDtuid.Text.Trim();
                dtuField.ColName = "OPC_WINFO";
                dtuField.FieldName = GetFieldName(Convert.ToInt32(drp_Index.Value), drp_FieldName.Text.Trim());
                dtuField.FieldShortDesc = txtFieldShortDesc.Text.Trim();
                dtuField.FieldDesc = txtFieldDesc.Text.Trim();
                dtuField.FieldUnit = txtFieldUnit.Text.Trim();
                dtuField.ValueMin = double.Parse(txtValueMin.Text.Trim());
                dtuField.ValueMax = double.Parse(txtValueMax.Text.Trim());
                dtuField.Lowlimit = double.Parse(txtLowlimit.Text.Trim());
                dtuField.Highlimit = double.Parse(txtHighlimit.Text.Trim());
                dtuField.Lololimit = double.Parse(txtLololimit.Text.Trim());
                dtuField.Hihilimit = double.Parse(txtHihilimit.Text.Trim());
                dtuField.OrderId = Int32.Parse(txt_Order.Text.Trim());
                dtuField.ValueInOrOut = 0;
                if (drp_ValueInOut.SelectedIndex > 0)
                {
                    dtuField.ValueInOrOut = (drp_ValueInOut.SelectedIndex == 1) ? 1 : 2;
                }
                dtuField.IsAlert = rbtnIsAlertTrue.Checked ? 1 : 0;
                dtuField.IsCollect = rbtnIsCollectTrue.Checked ? 1 : 0;
                dtuField.UpdateFlag = curModel.UpdateFlag + 1;
                dtuField.IsShow = rbtnIsShowTrue.Checked ? 1 : 0;
                if (dtuField.FieldName.StartsWith("DI"))
                {
                    dtuField.KeyValues = string.Format("1={0};0={1};", txtDi1.Text.Trim(), txtDi0.Text.Trim());
                }
                else if (dtuField.FieldName.EndsWith("TC"))
                {
                    dtuField.KeyValues = string.Format("1={0};0={1};", txtJC1.Text.Trim(), txtJC0.Text.Trim());
                }
                else
                {
                    dtuField.KeyValues = "";
                }
                dtuField.FieldType = drp_FieldType.SelectedIndex;
                if (ServiceProxy.DTUServiceProxy.UpdateDTUFieldDesc(LocalIP, dtuField))
                {
                    QueryDataBind();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改站点字段:ID-{0},Name-{1}", curModel.Id, curModel.FieldName), 1);
                    pbh.CloseProgressBar();
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    QueryDataBind();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改站点字段:ID-{0},Name-{1}", curModel.Id, curModel.FieldName), 2);
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

        private void ClearForm()
        {
            drp_Index.Value = 1;
            drp_FieldName.SelectedIndex = 0;
            txtFieldUnit.Text = "Nm3/h";
            txtFieldShortDesc.Text = "标况瞬时流量1";
            txtFieldDesc.Text = "去/至_____标况瞬时流量";
            txtValueMin.Text = "0";
            txtValueMax.Text = "1000";
            txtLowlimit.Text = "-1";
            txtHighlimit.Text = "9999999999999";
            txtLololimit.Text = "-1";
            txtHihilimit.Text = "9999999999999";
            drp_ValueInOut.SelectedIndex = 0;
            txtJC1.Visible = false;
            txtJC0.Visible = false;
            lblJc.Visible = false;
            label5.Visible = false;
            txtDi1.Visible = false;
            txtDi0.Visible = false;
            lblDI.Visible = false;
            label3.Visible = false;
            rbtnIsAlertFalse.Checked = true;
            rbtnIsCollectTrue.Checked = true;
            txtFieldShortDesc.Enabled = true;
            txtFieldUnit.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "您确定删除该配置信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                ProgressBarHelper pbh = new ProgressBarHelper();
                try
                {
                    pbh.PopProgressBar("正在删除站点字段数据!");
                    DataGridViewRow row = dgvField.SelectedRows[0];
                    var model = row.DataBoundItem as DTUFieldDesc;
                    if (ServiceProxy.DTUServiceProxy.DeleteDTUFieldDesc(LocalIP, model.Id))
                    {
                        QueryDataBind();
                        ClearForm();
                        LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点字段:ID-{0},Name-{1}", model.Id, model.FieldName), 1);
                        pbh.CloseProgressBar();
                        MessageBox.Show("删除成功!");
                    }
                    else
                    {
                        QueryDataBind();
                        ClearForm();
                        LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除站点字段:ID-{0},Name-{1}", model.Id, model.FieldName), 2);
                        pbh.CloseProgressBar();
                        MessageBox.Show("删除失败!");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            btnImport.Enabled = true;
            this.drp_FieldName.Enabled = true;
            this.drp_ValueInOut.Enabled = true;
            this.txtFieldShortDesc.Enabled = true;
            this.drp_Index.Enabled = true;
            ClearForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Validate
            if (string.IsNullOrWhiteSpace(drp_FieldName.Text))
            {
                MessageBox.Show("字段名称不能为空!");
                return;
            }
            string filedName = GetFieldName(Convert.ToInt32(drp_Index.Value), drp_FieldName.Text.Trim());
            ServiceProxy.DTUService.EnumExistsStatus flag = ServiceProxy.DTUServiceProxy.CheckIfFieldIsExists(LocalIP, cbxDtuid.Text.Trim(), filedName);
            if (flag == ServiceProxy.DTUService.EnumExistsStatus.Exists)
            {
                MessageBox.Show("这个字段名称已经存在!");
                return;
            }
            if (string.IsNullOrEmpty(txtFieldShortDesc.Text))
            {
                MessageBox.Show("字段短描述不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtFieldDesc.Text))
            {
                MessageBox.Show("字段描述不能为空!");
                return;
            }
            if (!ToolHelper.IsNumberSign(txtValueMin.Text))
            {
                MessageBox.Show("字段最小值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumber(txtValueMax.Text))
            {
                MessageBox.Show("字段最大值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumberSign(txtLowlimit.Text))
            {
                MessageBox.Show("字段低报警值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumber(txtHighlimit.Text))
            {
                MessageBox.Show("字段高报警值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumberSign(txtLololimit.Text))
            {
                MessageBox.Show("字段最低报警值必须为数字!");
                return;
            }
            if (!ToolHelper.IsNumber(txtHihilimit.Text))
            {
                MessageBox.Show("字段最高报警值必须为数字!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDi1.Text) || string.IsNullOrWhiteSpace(txtDi0.Text))
            {
                MessageBox.Show("DI描述不能为空!");
                return;
            }
            #endregion
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存站点字段数据!");
                ServiceProxy.DTUService.T_DTU_FieldDesc dtuField = new ServiceProxy.DTUService.T_DTU_FieldDesc();
                dtuField.Dtuid = cbxDtuid.Text.Trim();
                dtuField.ColName = "OPC_WINFO";
                dtuField.FieldName = filedName;
                dtuField.FieldShortDesc = txtFieldShortDesc.Text.Trim();
                dtuField.FieldDesc = txtFieldDesc.Text.Trim();
                dtuField.FieldUnit = txtFieldUnit.Text.Trim();
                dtuField.ValueMin = double.Parse(txtValueMin.Text.Trim());
                dtuField.ValueMax = double.Parse(txtValueMax.Text.Trim());
                dtuField.Lowlimit = double.Parse(txtLowlimit.Text.Trim());
                dtuField.Highlimit = double.Parse(txtHighlimit.Text.Trim());
                dtuField.Lololimit = double.Parse(txtLololimit.Text.Trim());
                dtuField.Hihilimit = double.Parse(txtHihilimit.Text.Trim());
                dtuField.ValueInOrOut = 0;
                if (drp_ValueInOut.SelectedIndex > 0)
                {
                    dtuField.ValueInOrOut = (drp_ValueInOut.SelectedIndex == 1) ? 1 : 2;
                }
                dtuField.IsAlert = rbtnIsAlertTrue.Checked ? 1 : 0;
                dtuField.IsCollect = rbtnIsCollectTrue.Checked ? 1 : 0;
                dtuField.ParentId = 0;
                dtuField.UpdateFlag = 1;
                dtuField.IsShow = rbtnIsShowTrue.Checked ? 1 : 0;
                if (dtuField.FieldName.StartsWith("DI"))
                {
                    dtuField.KeyValues = string.Format("1={0};0={1};", txtDi1.Text.Trim(), txtDi0.Text.Trim());
                }
                else if (dtuField.FieldName.EndsWith("TC"))
                {
                    dtuField.KeyValues = string.Format("1={0};0={1};", txtJC1.Text.Trim(), txtJC0.Text.Trim());
                }
                else
                {
                    dtuField.KeyValues = "";
                }
                dtuField.FieldType = drp_FieldType.SelectedIndex;
                if (ServiceProxy.DTUServiceProxy.AddDTUFieldDesc(LocalIP, dtuField))
                {
                    QueryDataBind();
                    pbh.CloseProgressBar();
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点字段:{0}", dtuField.FieldName), 1);
                    MessageBox.Show("添加成功!");
                }
                else
                {
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点字段:{0}", dtuField.FieldName), 2);
                    pbh.CloseProgressBar();
                    MessageBox.Show("添加失败!");
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("添加失败:" + ex.Message);
            }
        }

        private void dgvField_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            drp_FieldName.Enabled = false;
            drp_Index.Enabled = false;
            DataGridViewRow row = dgvField.SelectedRows[0];
            curModel = row.DataBoundItem as DTUFieldDesc;
            cbxDtuid.Text = curModel.Dtuid;

            string tmp = curModel.FieldName;
            System.Text.RegularExpressions.Match mstr = System.Text.RegularExpressions.Regex.Match(tmp, @"[\d]+");
            string idx = mstr.Groups[0].Value;
            drp_Index.Value = Convert.ToInt32(idx);
            if (tmp.StartsWith("M"))
                drp_FieldName.SelectedItem = tmp.Substring(tmp.IndexOf(idx) + idx.Length);
            else
                drp_FieldName.SelectedItem = tmp.Substring(0, 2);
            txtFieldUnit.Text = curModel.FieldUnit;
            txtFieldShortDesc.Text = curModel.FieldShortDesc;
            txtFieldDesc.Text = curModel.FieldDesc;
            txtValueMin.Text = curModel.ValueMin.ToString();
            txtValueMax.Text = curModel.ValueMax.ToString();
            txtLowlimit.Text = curModel.Lowlimit.ToString();
            txtHighlimit.Text = curModel.Highlimit.ToString();
            txtLololimit.Text = curModel.Lololimit.ToString();
            txtHihilimit.Text = curModel.Hihilimit.ToString();
            txt_Order.Text = curModel.OrderId.ToString();
            switch (curModel.ValueInOrOut)
            {
                case "不分进出口":
                    drp_ValueInOut.SelectedIndex = 0;
                    break;
                case "进":
                    drp_ValueInOut.SelectedIndex = 1;
                    break;
                case "出":
                    drp_ValueInOut.SelectedIndex = 2;
                    break;
                default:
                    drp_ValueInOut.SelectedIndex = 0;
                    break;
            }

            if (curModel.IsAlert == "是")
                rbtnIsAlertTrue.Checked = true;
            else
                rbtnIsAlertFalse.Checked = true;
            if (curModel.IsCollect == "是")
                rbtnIsCollectTrue.Checked = true;
            else
                rbtnIsCollectFalse.Checked = true;
            if (curModel.IsShow == "是")
                rbtnIsShowTrue.Checked = true;
            else
                rbtnIsShowFalse.Checked = true;
            if (curModel.FieldName.StartsWith("DI"))
            {
                NameValueCollection nv = ToolHelper.ParseAtts(curModel.KeyValues);
                txtDi1.Visible = true;
                txtDi0.Visible = true;
                lblDI.Visible = true;
                label3.Visible = true;
                txtDi1.Text = nv["1"];
                txtDi0.Text = nv["0"];
                txtJC1.Visible = false;
                txtJC0.Visible = false;
                lblJc.Visible = false;
                label5.Visible = false;
            }
            if (curModel.FieldName.EndsWith("TC"))
            {
                NameValueCollection nv = ToolHelper.ParseAtts(curModel.KeyValues);
                txtJC1.Visible = true;
                txtJC0.Visible = true;
                lblJc.Visible = true;
                label5.Visible = true;
                txtJC0.Text = nv["0"];
                txtJC1.Text = nv["1"];
                txtDi1.Visible = false;
                txtDi0.Visible = false;
                lblDI.Visible = false;
                label3.Visible = false;
            }
            switch (curModel.FieldType)
            {
                case "不统计":
                    drp_FieldType.SelectedIndex = 0;
                    break;
                case "累计":
                    drp_FieldType.SelectedIndex = 1;
                    break;
                case "示数":
                    drp_FieldType.SelectedIndex = 2;
                    break;
                case "平均":
                    drp_FieldType.SelectedIndex = 3;
                    break;
                default:
                    drp_FieldType.SelectedIndex = 0;
                    break;
            }
            btnAdd.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            btnImport.Enabled = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cbxDtu.SelectedIndex != 0 && !string.IsNullOrEmpty(cbxDtu.SelectedValue.ToString()))
            {
                new FrmDtuFieldImport(cbxDtu.SelectedValue.ToString()).ShowDialog();
                QueryDataBind();
            }
            else
            {
                MessageBox.Show("请选中要导入字段的站点编号!");
            }
        }

        private void cbxFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDI.Visible = false;
            txtDi0.Visible = false;
            txtDi1.Visible = false;
            label3.Visible = false;
            lblJc.Visible = false;
            txtJC0.Visible = false;
            txtJC1.Visible = false;
            label5.Visible = false;
            int idx = Convert.ToInt32(this.drp_Index.Value);
            this.drp_ValueInOut.SelectedIndex = 0;
            switch (drp_FieldName.Text.Trim())
            {
                case "AO":
                    this.txtFieldUnit.Text = "罐";
                    this.txtFieldShortDesc.Text = "累计加臭罐数" + idx;
                    this.txtFieldDesc.Text = "面板1-N累计加臭罐数";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "BO":
                    this.txtFieldUnit.Text = "个";
                    this.txtFieldShortDesc.Text = "加注头个数" + idx;
                    this.txtFieldDesc.Text = "面板1-N加注头个数";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "QB":
                    this.txtFieldUnit.Text = "Nm3/h";
                    this.txtFieldShortDesc.Text = "标况瞬时流量" + idx;
                    this.txtFieldDesc.Text = "去/至_____标况瞬时流量";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "QBC":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "臭液标况瞬时流量" + idx;
                    this.txtFieldDesc.Text = "去/至_____臭液标况瞬时流量";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "Q":
                    this.txtFieldUnit.Text = "Nm3/h";
                    this.txtFieldShortDesc.Text = "工况瞬时流量" + idx;
                    this.txtFieldDesc.Text = "去/至_____工况瞬时流量";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "QC":
                    this.txtFieldUnit.Text = "mg/Nm3";
                    this.txtFieldShortDesc.Text = "臭液瞬时浓度" + idx;
                    this.txtFieldDesc.Text = "去/至_____臭液瞬时浓度";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "VB":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "标况流量累计" + idx;
                    this.txtFieldDesc.Text = "去/至_____标况流量累计";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "VBC":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "臭液标况流量累计" + idx;
                    this.txtFieldDesc.Text = "去/至_____臭液标况流量累计";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "VC":
                    this.txtFieldUnit.Text = "g";
                    this.txtFieldShortDesc.Text = "累计加臭量" + idx;
                    this.txtFieldDesc.Text = "去/至_____累计加臭量";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "V":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "工况流量累计" + idx;
                    this.txtFieldDesc.Text = "去/至_____工况流量累计";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "P":
                    this.txtFieldUnit.Text = "Kpa";
                    this.txtFieldShortDesc.Text = "流量计压力" + idx;
                    this.txtFieldDesc.Text = "去/至_____流量计压力";
                    this.drp_ValueInOut.Enabled = true;
                    this.drp_ValueInOut.SelectedIndex = 1;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "PC":
                    this.txtFieldUnit.Text = "次";
                    this.txtFieldShortDesc.Text = "加注阀动作次数" + idx;
                    this.txtFieldDesc.Text = "加注阀动作次数";
                    this.drp_ValueInOut.Enabled = true;
                    this.drp_ValueInOut.SelectedIndex = 1;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "T":
                    this.txtFieldUnit.Text = "℃";
                    this.txtFieldShortDesc.Text = "管内温度" + idx;
                    this.txtFieldDesc.Text = "去/至_____管内温度";
                    this.drp_ValueInOut.Enabled = false;
                    //this.txtFieldShortDesc.Enabled = false;
                    break;
                case "AI":
                    this.txtFieldUnit.Text = "";
                    this.txtFieldUnit.Enabled = true;
                    this.drp_ValueInOut.Enabled = true;
                    this.drp_ValueInOut.SelectedIndex = 1;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "DI":
                    this.txtFieldUnit.Text = "";
                    this.txtFieldShortDesc.Text = "";
                    this.txtFieldDesc.Text = "";
                    this.txtFieldUnit.Enabled = true;
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    lblDI.Visible = true;
                    txtDi0.Visible = true;
                    txtDi1.Visible = true;
                    label3.Visible = true;
                    break;
                case "TC":
                    this.txtFieldUnit.Text = "";
                    this.txtFieldShortDesc.Text = "加臭模式" + idx;
                    this.txtFieldDesc.Text = "加臭模式" + idx;
                    this.txtFieldUnit.Enabled = true;
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    lblJc.Visible = true;
                    txtJC0.Visible = true;
                    txtJC1.Visible = true;
                    label5.Visible = true;
                    break;
                default:
                    this.txtFieldUnit.Text = "";
                    this.drp_ValueInOut.Enabled = true;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
            }
        }

        #region Method
        /// <summary>
        /// 获取字段名称
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        private string GetFieldName(int Index, string fieldType)
        {
            string rslt = string.Empty;
            switch (fieldType)
            {
                case "QB":
                case "Q":
                case "VB":
                case "V":
                case "P":
                case "T":
                case "QBC":
                case "QC":
                case "VBC":
                case "VC":
                case "PC":
                case "TC":
                    rslt = "M" + Index + fieldType;
                    break;
                case "AI":
                case "DI":
                case "AO":
                case "BO":
                    rslt = fieldType + Index;
                    break;
                default:
                    rslt = fieldType + Index;
                    break;
            }
            return rslt;
        }
        #endregion
    }
}
