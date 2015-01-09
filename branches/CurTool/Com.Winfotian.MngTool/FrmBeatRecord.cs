﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using Com.Winfotian.ServiceProxy;
using Com.Winfotian.Encrypts;

namespace Com.Winfotian.MngTool
{
    public partial class FrmBeatRecord : FrmBase
    {
        public FrmBeatRecord()
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
                IList<ServiceProxy.DTUService.DTU> dtuList = DTUServiceProxy.GetAllDtuInfo(LocalIP);
                dtuList.Insert(0, new ServiceProxy.DTUService.DTU() { Dtuid = "0", DtuidName = "---全部---" });
                cbxDtu.DataSource = dtuList;
                cbxDtu.DisplayMember = "DtuidName";
                cbxDtu.ValueMember = "DtuId";
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
                    pbh.PopProgressBar("正在查询心跳数据...");
                    dgvBeat.DataSource = CommonServiceProxy.GetRecentlyBeatRecordList(LocalIP);
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
                    pbh.PopProgressBar("正在查询心跳数据...");

                    List<string> beatRecord = CommonServiceProxy.GetBeatRecordList(LocalIP, cbxDtu.SelectedValue.ToString(), dtpTime.Value);
                    DataTable dtBeatRecord = new DataTable();
                    dtBeatRecord.Columns.Add(new DataColumn("DtuidName"));
                    dtBeatRecord.Columns.Add(new DataColumn("BeatTime"));
                    foreach (string item in beatRecord)
                    {
                        DataRow row = dtBeatRecord.NewRow();
                        row["DtuidName"] = cbxDtu.Text;
                        row["BeatTime"] = item;
                        dtBeatRecord.Rows.Add(row);
                    }

                    dgvBeat.DataSource = dtBeatRecord;
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
                    lblDate.Visible = true;
                    dtpTime.Visible = true;
                }
                else
                {
                    lblDate.Visible = false;
                    dtpTime.Visible = false;
                }
            }
        }
    }
}