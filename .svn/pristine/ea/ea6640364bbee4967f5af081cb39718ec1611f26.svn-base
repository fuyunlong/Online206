using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using Com.Winfotian.Components;
using System.Linq;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuFieldImport : FrmBase
    {
        string dtuid = string.Empty;
        DataTable dtField;
        public FrmDtuFieldImport(string Dtuid)
        {
            InitializeComponent();
            this.dtuid = Dtuid;
            this.Text += "(站点:" + Dtuid + ")";
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
                    if (string.IsNullOrWhiteSpace(item.ValueInOrOut))
                    {
                        if (item.ValueInOrOut == "进")
                            model.ValueInOrOut = 1;
                        else if (item.ValueInOrOut == "出")
                            model.ValueInOrOut = 2;
                    }
                    model.IsAlert = item.IsAlert == "是" ? 1 : 0;
                    model.IsCollect = item.IsCollect == "是" ? 1 : 0;
                    model.IsShow = item.IsShow == "是" ? 1 : 0;
                    model.KeyValues = item.KeyValues;
                    model.OrderId = item.OrderId;
                    model.ParentId = item.ParentId;
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
                    model.UpdateFlag = 1;
                    lisDtuField.Add(model);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                MessageBox.Show("模板数据有错误,请仔细检查!:" + ex.Message);
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
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("导入站点字段:{0}", dtuid), 1);
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
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                try
                {
                    dtField = ExcelHelper.GetExcelDataToDataTable(txtFilePath.Text.Trim());
                    List<DTUFieldDesc> newModels = dgvField.DataSource == null ? new List<DTUFieldDesc>() : dgvField.DataSource as List<DTUFieldDesc>;
                    foreach (DataRow dtrow in dtField.Rows)
                    {
                        if (dtrow[0].ToString() != dtuid)
                        {
                            MessageBox.Show("Excel中站点编号为" + dtrow[0].ToString() + "的数据不属于本站点字段!");
                            dgvField.Rows.Clear();
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
                    MessageBox.Show("导入站点字段数据出错:" + ex.Message);
                }
            }
            if (dgvField.Rows.Count > 0 && btnSave.Enabled == false)
            {
                btnSave.Enabled = true;
            }
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
    }
}
