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
using System.IO;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuFieldMana : FrmBase
    {
        ComboBoxTreeView cbgQGroupTree;
        public FrmDtuFieldMana()
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
                model.Lololimit = item.Lololimit;
                model.Lowlimit = item.Lowlimit;               
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
                model.KeyValues = item.KeyValues;
                model.OrderId = item.OrderId;
                model.ParentId = item.ParentId;
                model.UpdateFlag = item.UpdateFlag;
                model.ValueMax = item.ValueMax;
                model.ValueMin = item.ValueMin;
                newModels.Add(model);
            }
            dgvField.DataSource = newModels;
        }

        private void BindChild(List<ServiceProxy.DTUService.DataItemInfo> datalist, string parentId, int depth)
        {
            var childs = datalist.Where(p => p.FlowName == parentId);
            string bankspace = string.Empty;
            foreach (var itm in childs)
            {
                for (int i = 0; i < depth; i++)
                {
                    bankspace += "┃";
                }
                itm.ItemText = bankspace + "┗" + itm.ItemText;
                BindChild(datalist, itm.ItemValue, depth + 1);
            }
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
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                try
                {
                    DataTable dtField = ExcelHelper.GetExcelDataToDataTable(txtFilePath.Text.Trim());
                    List<DTUFieldDesc> newModels = dgvField.DataSource == null ? new List<DTUFieldDesc>() : dgvField.DataSource as List<DTUFieldDesc>;
                    foreach (DataRow dtrow in dtField.Rows)
                    {
                        if (dtrow[0].ToString() != cbxDtu.SelectedValue.ToString())
                        {
                            MessageBox.Show("Excel中站点编号为" + dtrow[0].ToString() + "的数据不属于本站点字段!");
                            return;
                        }
                        DTUFieldDesc model = new DTUFieldDesc();
                        model.Dtuid = dtrow[0].ToString();
                        model.ColName = dtrow[1].ToString();
                        model.FieldName = dtrow[2].ToString();
                        model.FieldShortDesc = dtrow[3].ToString();
                        model.FieldDesc = dtrow[4].ToString();
                        model.FieldUnit = dtrow[5].ToString();
                        model.ValueMin = Convert.ToDouble(dtrow[6]);
                        model.ValueMax = Convert.ToDouble(dtrow[7]);
                        model.Lowlimit = Convert.ToDouble(dtrow[8]);
                        model.Hihilimit = Convert.ToDouble(dtrow[9]);
                        model.Lololimit = Convert.ToDouble(dtrow[10]);
                        model.Highlimit = Convert.ToDouble(dtrow[11]);
                        model.ValueInOrOut = dtrow[12].ToString();
                        model.IsAlert = dtrow[13].ToString();
                        model.IsCollect = dtrow[14].ToString();
                        model.IsShow = dtrow[15].ToString();
                        model.KeyValues = dtrow[16] == null ? "" : dtrow[16].ToString();
                        model.OrderId = Convert.ToInt32(dtrow[17]);
                        model.ParentId = 0;
                        model.UpdateFlag = 1;
                        model.FieldType = dtrow[18].ToString();
                        newModels.Add(model);
                    }
                    dgvField.DataSource = newModels;
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                    MessageBox.Show("模板数据有错误,请仔细检查!:" + ex.Message);
                }
            }
            if (dgvField.Rows.Count > 0 && btnSave.Enabled == false)
            {
                btnSave.Enabled = true;
            }
        }

        private void linkTemplateDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = fbd.SelectedPath + "\\字段导入模板.xls";
                    string fileTemplatePath = AppDomain.CurrentDomain.BaseDirectory + "字段导入模板.xls";
                    if (FileHelper.CopyFile(fileTemplatePath, filePath))
                    {
                        MessageUtil.ShowTips("下载成功!");
                    }
                    else
                    {
                        MessageUtil.ShowTips("下载失败:文件不存在!");
                    }
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                    MessageBox.Show("下载失败！" + ex.ToString());
                }
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

        private void btnGetFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.RestoreDirectory = true;
            opd.Filter = "Excel(2003)文件|*.xls|Excel(2007)文件|*.xlsx|所有文件|*.*";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = opd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvField.Rows.Count == 0)
            {
                MessageBox.Show("请添加站点字段数据!");
                return;
            }
            List<ServiceProxy.DTUService.T_DTU_FieldDesc> lisDtuField = new List<ServiceProxy.DTUService.T_DTU_FieldDesc>();
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在组织站点字段数据!");
                List<DTUFieldDesc> models = dgvField.DataSource as List<DTUFieldDesc>;
                foreach (var item in models)
                {
                    var model = new ServiceProxy.DTUService.T_DTU_FieldDesc();
                    model.Dtuid = item.Dtuid;
                    model.ColName = item.ColName;
                    model.FieldName = item.FieldName;
                    model.FieldShortDesc = item.FieldShortDesc;
                    model.FieldDesc = item.FieldDesc;
                    model.FieldUnit = item.FieldUnit;
                    model.ValueMin = item.ValueMin;
                    model.ValueMax = item.ValueMax;
                    model.Lowlimit = item.Lowlimit;
                    model.Highlimit = item.Highlimit;
                    model.Lololimit = item.Lololimit;
                    model.Hihilimit = item.Hihilimit;
                    model.ValueInOrOut = 0;
                    if (!string.IsNullOrWhiteSpace(item.ValueInOrOut))
                    {
                        if (item.ValueInOrOut == "进")
                            model.ValueInOrOut = 1;
                        if (item.ValueInOrOut == "出")
                            model.ValueInOrOut = 2;
                    }
                    model.IsAlert = item.IsAlert == "是" ? 1 : 0;
                    model.IsCollect = item.IsCollect == "是" ? 1 : 0;
                    model.IsShow = item.IsShow == "是" ? 1 : 0;
                    model.KeyValues = item.KeyValues;
                    model.OrderId = item.OrderId;
                    model.ParentId = item.ParentId;
                    model.UpdateFlag = 1;
                    switch (item.FieldType)
                    {
                        case "不统计":
                            model.FieldType = 0;
                            break;
                        case "累计":
                            model.FieldType = 1;
                            break;
                        case "示数":
                            model.FieldType = 2;
                            break;
                        case "平均":
                            model.FieldType = 3;
                            break;
                        default:
                            model.FieldType = 0;
                            break;
                    }
                    lisDtuField.Add(model);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                MessageBox.Show("模板数据有错误:" + ex.Message);
                pbh.CloseProgressBar();
                return;
            }
            try
            {
                //去除重复项
                List<ServiceProxy.DTUService.T_DTU_FieldDesc> lisDtuFieldDistinct = new List<ServiceProxy.DTUService.T_DTU_FieldDesc>();//保存不重复的对象
                foreach (ServiceProxy.DTUService.T_DTU_FieldDesc item in lisDtuField)
                {
                    if (!lisDtuFieldDistinct.Exists(p => p.Dtuid == item.Dtuid && p.FieldName == item.FieldName))
                    {
                        lisDtuFieldDistinct.Add(item);
                    }
                }
                ServiceProxy.DTUServiceProxy.InsertListDTUFieldDesc(LocalIP, lisDtuFieldDistinct);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("导入字段站点:{0}", (cbxDtu.SelectedItem as ServiceProxy.DTUService.DTU).DtuidName), 1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("插入数据出错!" + ex.ToString());
                return;
            }
            MessageBox.Show("保存成功!");
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        /// <summary>
        /// 另存新档按钮
        /// </summary>
        private void SaveAs() //另存新档按钮   导出成Excel
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            saveFileDialog.ShowDialog();
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {
                List<int> removeList = new List<int>();
                //写标题
                for (int i = 0; i < dgvField.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        if ("UpdateFlag,父字段".Contains(dgvField.Columns[i].HeaderText))
                        {
                            removeList.Add(i);
                            continue;
                        }
                        if (i > 1) str += "\t";
                        str += dgvField.Columns[i].HeaderText;
                    }
                }
                sw.WriteLine(str);
                //写内容
                for (int j = 0; j < dgvField.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dgvField.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            if (removeList.Contains(k)) continue;
                            if (k > 1) tempStr += "\t";
                            tempStr += dgvField.Rows[j].Cells[k].Value.ToString();
                        }
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
    }
}
