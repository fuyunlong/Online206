using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDeviceAlertRecord : FrmBase
    {
        public FrmDeviceAlertRecord()
        {
            InitializeComponent();
            cbxDtuBind();
        }
        /// <summary>
        /// 绑定站点数据
        /// </summary>
        private void cbxDtuBind()
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在加载站点数据...");
                var Dtus = ServiceProxy.DTUServiceProxy.GetAllDtuInfo(LocalIP);
                ServiceProxy.DTUService.DTU model = new ServiceProxy.DTUService.DTU();
                model.Dtuid = "0";
                model.DtuidName = "----全部---";
                Dtus.Insert(0, model);
                cbxDtu.DataSource = Dtus;
                cbxDtu.DisplayMember = "DtuidName";
                cbxDtu.ValueMember = "DtuId";
                this.dtpStartTime.Value = DateTime.Now.AddDays(-1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("加载站点数据出错:" + ex.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cbxDtu.SelectedValue.ToString() == "0")
            {
                ProgressBarHelper pbh = new ProgressBarHelper();
                try
                {
                    pbh.PopProgressBar("正在查询告警数据...");
                    dgvAlarm.DataSource = ServiceProxy.AlertServiceProxy.GetRecentlyAlarmRecordList(LocalIP);
                    pbh.CloseProgressBar();
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                    pbh.CloseProgressBar();
                    MessageBox.Show("查询出错:" + ex.Message);
                }
            }
            else
            {
                ProgressBarHelper pbh = new ProgressBarHelper();
                try
                {
                    pbh.PopProgressBar("正在查询告警数据...");
                    dgvAlarm.DataSource = ServiceProxy.AlertServiceProxy.GetAlarmRecordList(LocalIP, cbxDtu.SelectedValue.ToString(), dtpStartTime.Value, dtpEndTime.Value);
                    dgvAlarm.ClearSelection();
                    pbh.CloseProgressBar();
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                    pbh.CloseProgressBar();
                    MessageBox.Show("查询出错:" + ex.Message);
                }
            }
        }

        private void cbxDtu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDtu.CanSelect)
            {
                if (cbxDtu.SelectedValue.ToString() != "0")
                {
                    lblStartTime.Visible = true;
                    lblEndTime.Visible = true;
                    dtpEndTime.Visible = true;
                    dtpStartTime.Visible = true;
                }
                else
                {
                    lblStartTime.Visible = false;
                    lblEndTime.Visible = false;
                    dtpEndTime.Visible = false;
                    dtpStartTime.Visible = false;
                }
            }
        }

        private void dgvBeat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbxDtu.SelectedValue.ToString() != "0")
            {
                DataGridViewRow row = dgvAlarm.SelectedRows[0];
                var model = row.DataBoundItem as ServiceProxy.AlertService.TAlarmInfo;
                new FrmDeviceAlarmDetail(model.Id).ShowDialog();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelHelper excelHelper = new ExcelHelper();
            object[] objHeadText = new object[dgvAlarm.ColumnCount - 1];
            int i = 0;
            foreach (DataGridViewColumn dgvc in dgvAlarm.Columns)
            {
                if (dgvc.Visible == true)
                {
                    objHeadText[i++] = dgvc.HeaderText;
                }
            }
            for (int j = 0; j < dgvAlarm.Rows.Count; j++)
            {
                if (j == 0)
                {
                    excelHelper.Create(dgvAlarm.Rows[j].Cells[1].Value.ToString());
                    excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 1, 1, 1, objHeadText.Length, objHeadText);
                    excelHelper.SetCellHeader(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 1, 1, 1, objHeadText.Length);
                    object[,] objData = new object[1, objHeadText.Length];
                    for (int l = 0; l < objHeadText.Length; l++)
                    {
                        objData[0, l] = dgvAlarm.Rows[0].Cells[l + 1].Value.ToString();
                    }
                    excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 2, 1, 2, objHeadText.Length, objData);
                    excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 3, 1, "报警时间");
                    excelHelper.SetCellHeader(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 3, 1, 3, 1);
                    List<ServiceProxy.AlertService.T_Alert_AlertTimes> list = ServiceProxy.AlertServiceProxy.GetAlertDetailById(LocalIP, int.Parse(dgvAlarm.Rows[j].Cells[0].Value.ToString()));
                    if (list.Count > 0)
                    {
                        object[,] objArr = new object[1, list.Count];
                        for (int k = 0; k < list.Count; k++)
                        {
                            objArr[0, k] = list[k].AlertTime.ToString();
                        }
                        excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 4, 1, objArr.Length + 4, 1, objArr);
                    }
                }
                else
                {
                    excelHelper.AddSheet(dgvAlarm.Rows[j].Cells[1].Value.ToString());
                    excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 1, 1, 1, objHeadText.Length, objHeadText);
                    excelHelper.SetCellHeader(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 1, 1, 1, objHeadText.Length);
                    object[,] objData = new object[1, objHeadText.Length];
                    for (int l = 0; l < objHeadText.Length; l++)
                    {
                        objData[0, l] = dgvAlarm.Rows[0].Cells[l + 1].Value.ToString();
                    }
                    excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 2, 1, 2, objHeadText.Length, objData);
                    excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 3, 1, "报警时间");
                    excelHelper.SetCellHeader(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 3, 1, 3, 1);
                    List<ServiceProxy.AlertService.T_Alert_AlertTimes> list = ServiceProxy.AlertServiceProxy.GetAlertDetailById(LocalIP, int.Parse(dgvAlarm.Rows[j].Cells[0].Value.ToString()));
                    if (list.Count > 0)
                    {
                        object[,] objArr = new object[1, list.Count];
                        for (int k = 0; k < list.Count; k++)
                        {
                            objArr[0, k] = list[k].AlertTime.ToString();
                        }
                        excelHelper.SetCellValue(dgvAlarm.Rows[j].Cells[1].Value.ToString(), 4, 1, objArr.Length + 4, 1, objArr);
                    }
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "设备报警信息" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                excelHelper.SaveAs(sfd.FileName);
            }
            excelHelper.Close();
        }
    }
}
