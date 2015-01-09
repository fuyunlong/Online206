﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDTU_DOConfig : FrmBase
    {
        #region Private
        ComboBoxTreeView cbgQGroupTree;
        private Com.Winfotian.ServiceProxy.DTUService.T_DTU_DOConfig curModel = null;
        #endregion

        public FrmDTU_DOConfig()
        {
            InitializeComponent();
            //分组下拉
            cbgQGroupTree = new ComboBoxTreeView();//查询条件用
            cbgQGroupTree.Location = new System.Drawing.Point(434, 21);
            cbgQGroupTree.Name = "cbxDtuGroup1";
            cbgQGroupTree.Size = new System.Drawing.Size(154, 20);
            cbgQGroupTree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbgQGroupTree);
            cbgQGroupTree.BringToFront();
            cbgQGroupTree.SelectedIndexChanged += new EventHandler(cbgQGroupTree_SelectedIndexChanged);

            cbxQFieldName.SelectedIndex = 0;
        }

        #region Method
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

        private void QueryDataBind()
        {
            //int cmpId = (cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId;
            //string groupCode = string.Empty;
            string dtuid = string.Empty;
            string fieldName = string.Empty;
            if ((cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid != "-1")
            {
                dtuid = (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).Dtuid;
            }
            else
            {
                MessageBox.Show("请选择站点！");
                return;
            }
            //if (cbgQGroupTree.TreeView.SelectedNode.Tag.ToString() != "-1")
            //{
            //    groupCode = cbgQGroupTree.TreeView.SelectedNode.Tag.ToString();
            //}
            List<Com.Winfotian.ServiceProxy.DTUService.T_DTU_DOConfig> list = new List<ServiceProxy.DTUService.T_DTU_DOConfig>();
            if (cbxQFieldName.SelectedIndex != 0)
            {
                fieldName = GetFieldName(Convert.ToInt32(drp_SelIndex.Value), cbxQFieldName.Text.Trim());
                list.Add(Com.Winfotian.ServiceProxy.DTUServiceProxy.GetControlCfgByField(LocalIP, dtuid, fieldName));
            }
            else
            {
                list = Com.Winfotian.ServiceProxy.DTUServiceProxy.GetControlCfgByDtu(LocalIP, dtuid); 
            }
            dgvField.DataSource = list;
        }

        private void ClearForm()
        {
            curModel = null;
            this.txt_DIIndex.Value = 1;
            this.txt_DOIndex.Value = 1;
            this.txt_FieldName.Text = "";
            this.drp_ReturnState.SelectedIndex = 0;
            this.cbxDtuid.Enabled = true;
            this.btn_Add.Enabled = true;
            this.btn_Cancl.Enabled = false;
            this.btn_Del.Enabled = false;
            this.btn_Mod.Enabled = false;
        }
        #endregion

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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxDtuid.Text.Trim()))
            {
                MessageBox.Show("请站点编号！");
                return;
            } 
            if (string.IsNullOrEmpty(txt_FieldName.Text.Trim()))
            {
                MessageBox.Show("请输入站点字段名称！");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在添加配置信息!");
                curModel = new Com.Winfotian.ServiceProxy.DTUService.T_DTU_DOConfig();
                curModel.Dtuid = cbxDtuid.Text.Trim();
                curModel.FieldName = txt_FieldName.Text.Trim();
                curModel.DO_Index = Convert.ToInt32(txt_DOIndex.Value);
                curModel.DI_Index = Convert.ToInt32(txt_DIIndex.Value);
                curModel.ReturnState = drp_ReturnState.SelectedIndex;
                if (Com.Winfotian.ServiceProxy.DTUServiceProxy.AddDOConfig(LocalIP, curModel))
                {
                    pbh.ShowDialogInfo("添加成功！");
                    ClearForm();
                    QueryDataBind();
                }
                else
                {
                    pbh.ShowDialogInfo("添加失败！");
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
            }
            pbh.CloseProgressBar();
        }

        private void btn_Mod_Click(object sender, EventArgs e)
        {
            if (dgvField.SelectedRows.Count == 0)
            {
                MessageBox.Show("当前选择失效，请重新选择！");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在修改配置信息!");
                DataGridViewRow row = dgvField.SelectedRows[0];
                curModel = row.DataBoundItem as Com.Winfotian.ServiceProxy.DTUService.T_DTU_DOConfig;
                curModel.DO_Index = Convert.ToInt32(txt_DOIndex.Value);
                curModel.DI_Index = Convert.ToInt32(txt_DIIndex.Value);
                curModel.ReturnState = drp_ReturnState.SelectedIndex;
                if (Com.Winfotian.ServiceProxy.DTUServiceProxy.UpdateDOConfig(LocalIP, curModel))
                {
                    pbh.ShowDialogInfo("修改成功！");
                    ClearForm();
                    QueryDataBind();
                }
                else
                {
                    pbh.ShowDialogInfo("修改失败！");
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
            }
            pbh.CloseProgressBar();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dgvField.SelectedRows.Count == 0)
            {
                MessageBox.Show("当前选择失效，请重新选择！");
                return;
            }
            if (MessageBox.Show(this, "您确定删除该配置信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                ProgressBarHelper pbh = new ProgressBarHelper();
                try
                {
                    pbh.PopProgressBar("正在删除配置信息!");
                    DataGridViewRow row = dgvField.SelectedRows[0];
                    curModel = row.DataBoundItem as Com.Winfotian.ServiceProxy.DTUService.T_DTU_DOConfig;
                    if (Com.Winfotian.ServiceProxy.DTUServiceProxy.DeleteDOConfig(LocalIP, curModel.Dtuid, curModel.FieldName))
                    {
                        pbh.ShowDialogInfo("删除成功！");
                        ClearForm();
                        QueryDataBind();
                    }
                    else
                    {
                        pbh.ShowDialogInfo("删除失败！");
                    }
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                }
                pbh.CloseProgressBar();
            }
        }

        private void btn_Cancl_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvField_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {                
                DataGridViewRow row = dgvField.SelectedRows[0];
                curModel = row.DataBoundItem as Com.Winfotian.ServiceProxy.DTUService.T_DTU_DOConfig;
                cbxDtuid.Text = curModel.Dtuid;
                txt_FieldName.Text = curModel.FieldName;
                txt_DOIndex.Value = curModel.DO_Index;
                txt_DIIndex.Value = curModel.DI_Index;
                drp_ReturnState.SelectedIndex = curModel.ReturnState;

                cbxDtuid.Enabled = false;
                btn_Add.Enabled = false;
                btn_Mod.Enabled = true;
                btn_Del.Enabled = true;
                btn_Cancl.Enabled = true;
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
            }
        }

        private void FrmDTU_DOConfig_Load(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载公司数据!");
                CompanyBind();
                ClearForm();
                this.BringToFront();
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("加载公司数据失败:" + ex.Message);
            }
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
    }
}
