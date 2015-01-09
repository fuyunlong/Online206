using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;
using System.IO;

namespace Com.Winfotian.MngTool
{
    public partial class FrmUpLoadFlow : FrmBase
    {
        public FrmUpLoadFlow()
        {
            InitializeComponent();
            //dm = new DTUManager();
        }

        //private DTUManager dm;

        #region Method
        /// <summary>
        /// 
        /// </summary>
        private void InitialData()
        {
            drp_FileType.SelectedIndex = 0;
            var dtulist = ServiceProxy.DTUServiceProxy.GetAllDtuInfo(LocalIP);
            drp_Dtuid.DataSource = dtulist;
            drp_Dtuid.DisplayMember = "DtuidName";
            drp_Dtuid.ValueMember = "Dtuid";

            drp_Dtuid01.DataSource = dtulist;
            drp_Dtuid01.DisplayMember = "Dtuid";
            drp_Dtuid01.ValueMember = "Dtuid";

            drp_Dtuid02.DataSource = dtulist;
            drp_Dtuid02.DisplayMember = "Dtuid";
            drp_Dtuid02.ValueMember = "Dtuid";

            panel1.Visible = true;
            panel2.Visible = false;
        }
        #endregion

        private void FrmUpLoadFlow_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BringToFront();
            this.ShowInTaskbar = true;

            InitialData();
        }

        private void btn_Brower_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            file1.Multiselect = false;
            file1.Filter = "英菲信画图文件(*.shape)|*.shape";
            if (file1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txt_Path.Text = file1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DtuidName.Text.Trim()))
            {
                MessageBox.Show("站点名称不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txt_Path.Text.Trim()))
            {
                MessageBox.Show("文件路径不能为空");
                return;
            }
            ProgressBarHelper hlper = new ProgressBarHelper();
            try
            {
                hlper.PopProgressBar("获取文件信息");
                ServiceProxy.DTUService.DTU seldtu = (ServiceProxy.DTUService.DTU)drp_Dtuid01.SelectedItem;
                if (seldtu != null)
                {
                    hlper.PopProgressBar("绑定远程对象");
                    ServiceProxy.DTUService.T_DTU_Flow model = new ServiceProxy.DTUService.T_DTU_Flow();
                    model.Dtuid = seldtu.Dtuid;
                    model.DtuidName = txt_DtuidName.Text.Trim();
                    model.FileType = drp_FileType.SelectedIndex + 1;
                    model.MadeDate = DateTime.Now;
                    model.UpdateDate = DateTime.Now;
                    model.UpdateFlag = 1;
                    ServiceProxy.UpdateService.ClientType Ctype = ServiceProxy.UpdateService.ClientType.FlowChart;
                    switch (model.FileType)
                    {
                        case 2:
                            Ctype = ServiceProxy.UpdateService.ClientType.RealTable;
                            break;
                        case 3:
                            Ctype = ServiceProxy.UpdateService.ClientType.GISChart;
                            break;
                        case 4:
                            Ctype = ServiceProxy.UpdateService.ClientType.GISModel;
                            break;
                        default:
                            break;
                    }

                    hlper.PopProgressBar("开始上传文件，请稍等...");
                    bool isSuccess = false;
                    long bufferSize = 122480;//下载包大小
                    long start = 0;
                    bool isFinish = false;
                    ServiceProxy.UpdateService.RemoteResult callRslt;
                    using (FileStream stream = new FileStream(this.txt_Path.Text, FileMode.Open))
                    {
                        model.FileSize = Convert.ToInt32(stream.Length);
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            while (start < stream.Length - 1)
                            {
                                byte[] buffer;
                                long lastStreamLen = stream.Length - start;
                                stream.Seek(start, SeekOrigin.Begin);
                                if (lastStreamLen <= bufferSize)
                                {
                                    isFinish = true;
                                    bufferSize = lastStreamLen;//判断剩余的文件长度是否超过需要获取的长度
                                }
                                buffer = new byte[bufferSize];
                                reader.Read(buffer, 0, (int)bufferSize);
                                callRslt = Com.Winfotian.ServiceProxy.UpdateServiceProxy.UpLoadFile(LocalIP, model.DtuidName, Ctype, buffer, start, isFinish);
                                if (callRslt.State == ServiceProxy.UpdateService.ReturnState.Success)
                                {
                                    start += bufferSize;
                                    if (callRslt.Message == "完成")
                                        isSuccess = true;
                                }
                                else
                                {
                                    isSuccess = false;
                                    hlper.ShowDialogInfo("上传异常，请重新上传！\n或联系供应商");
                                    start = 0;
                                }
                            }
                        }
                    }
                    if (isSuccess)
                    {
                        if (ServiceProxy.DTUServiceProxy.AddDTUFlow(LocalIP, model))
                        {
                            hlper.ShowDialogInfo("上传成功");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hlper.ShowDialogInfo("上传失败");
                LogManager.WriteExceptionLog(ex);
            }
            hlper.CloseProgressBar();
            this.txt_Path.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drp_Dtuid02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drp_Dtuid02.SelectedItem != null)
            {
                ServiceProxy.DTUService.DTU seldtu = (ServiceProxy.DTUService.DTU)drp_Dtuid02.SelectedItem;
                drp_Dtuid.SelectedItem = seldtu;
                drp_Dtuid01.SelectedItem = seldtu;
                txt_DtuidName.Text = seldtu.DtuidName;
            }
        }

        private void drp_Dtuid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drp_Dtuid.SelectedItem != null)
            {
                ServiceProxy.DTUService.DTU seldtu = (ServiceProxy.DTUService.DTU)drp_Dtuid.SelectedItem;
                drp_Dtuid02.SelectedItem = seldtu;
                drp_Dtuid01.SelectedItem = seldtu;
                txt_DtuidName.Text = seldtu.DtuidName;
            }
        }

        private void drp_FileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drp_FileType.SelectedIndex == 0)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }
    }
}
