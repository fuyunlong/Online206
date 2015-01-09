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
    public partial class FrmDeviceAlarmDetail : FrmBase
    {
        public FrmDeviceAlarmDetail(int alertId)
        {
            InitializeComponent();
            BindAlertDetailById(alertId);
        }
        private void BindAlertDetailById(int alertId)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在查询告警详细...");
                dgvAlarmDetail.DataSource = ServiceProxy.AlertServiceProxy.GetAlertDetailById(LocalIP, alertId);
                dgvAlarmDetail.ClearSelection();
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
}
