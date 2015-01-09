using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using Com.Winfotian.MngTool.ClientMng;

namespace Com.Winfotian.MngTool
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
            if (ToolHelper.ReadINIValue("ValidateName", "test", "") == "winfotian888")
            {
                this.menu_SNProduct.Visible = true;
                this.menu_SNMng.Visible = true;
                this.Menu_Client.Visible = true;
            }
            else
            {
                this.menu_SNProduct.Visible = false;
                this.menu_SNMng.Visible = false;
                this.Menu_Client.Visible = false;
            }
            this.BringToFront();
        }

        /// <summary>
        /// 检测进程
        /// </summary>
        /// <param name="isCreate"></param>
        /// <param name="ProcessName"></param>
        private void CheckProcess(bool isCreate, string ProcessName)
        {
            try
            {
                if (isCreate)
                {
                    if (WinManager.CheckIsHaveProcess(ProcessName) > 0)
                    {
                        if (MessageBox.Show("已启动该程序，是否关闭之前的程序？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            WinManager.KillProcessByName(ProcessName);
                            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + ProcessName + ".exe");
                        }
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + ProcessName + ".exe");
                    }
                    this.Close();
                }
                else
                {
                    WinManager.KillProcessByName(ProcessName);
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void btnCompanyManager_Click(object sender, EventArgs e)
        {
            new FrmCompany().ShowDialog();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            new FrmUser().ShowDialog();
        }

        private void btnSiteManager_Click(object sender, EventArgs e)
        {
            new FrmDTU().ShowDialog();
        }

        private void btnDtuIDGenerater_Click(object sender, EventArgs e)
        {
            new FrmDtuIDGenerate().ShowDialog();
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_MouseEnter(object sender, EventArgs e)
        {
            this.btnHelp.Size = new Size(270, 147);
        }

        private void btnHelp_MouseLeave(object sender, EventArgs e)
        {
            this.btnHelp.Size = new Size(268, 145);
        }

        private void btnUserManager_MouseEnter(object sender, EventArgs e)
        {
            btnUserManager.FlatStyle = FlatStyle.Standard;
        }

        private void btnUserManager_MouseLeave(object sender, EventArgs e)
        {
            btnUserManager.FlatStyle = FlatStyle.Flat;
        }

        private void btnSiteManager_MouseEnter(object sender, EventArgs e)
        {
            btnSiteManager.FlatStyle = FlatStyle.Standard;
        }

        private void btnSiteManager_MouseLeave(object sender, EventArgs e)
        {
            btnSiteManager.FlatStyle = FlatStyle.Flat;
        }

        private void btnCompanyManager_MouseEnter(object sender, EventArgs e)
        {
            btnCompanyManager.FlatStyle = FlatStyle.Standard;
        }

        private void btnCompanyManager_MouseLeave(object sender, EventArgs e)
        {
            btnCompanyManager.FlatStyle = FlatStyle.Flat;
        }

        private void btnDtuIDGenerater_MouseEnter(object sender, EventArgs e)
        {
            btnDtuIDGenerater.FlatStyle = FlatStyle.Standard;
        }

        private void btnDtuIDGenerater_MouseLeave(object sender, EventArgs e)
        {
            btnDtuIDGenerater.FlatStyle = FlatStyle.Flat;
        }

        private void DTUManagerMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDTU().ShowDialog();
        }

        private void FieldManagerMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDtuFieldManager().ShowDialog();
        }

        private void CompanyManagerMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCompany().ShowDialog();
        }

        private void UserManagerMenuItem_Click(object sender, EventArgs e)
        {
            new FrmUser().ShowDialog();
        }

        private void DTUGroupMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDtuGroup().ShowDialog();
        }

        private void DTUConfigMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDtuConfig().ShowDialog();
        }

        private void DTUPressureMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDtuPressureLevel().ShowDialog();
        }

        private void UserGroupMenuItem_Click(object sender, EventArgs e)
        {
            new FrmUserGroup().ShowDialog();
        }

        private void UserRoleMenuItem_Click(object sender, EventArgs e)
        {
            new FrmUserRole().ShowDialog();
        }

        private void UserBillMenuItem_Click(object sender, EventArgs e)
        {
            new FrmSMSBill().ShowDialog();
        }

        private void UserConfigMenuItem_Click(object sender, EventArgs e)
        {
            new FrmUserConfig().ShowDialog();
        }

        private void CompanyConfigMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCompanyConfig().ShowDialog();
        }

        private void BeatDataMenuItem_Click(object sender, EventArgs e)
        {
            new FrmBeatRecord().ShowDialog();
        }

        private void DeviceAlertMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDeviceAlertRecord().ShowDialog();
        }

        private void menu_SetParam_Click(object sender, EventArgs e)
        {
            //new FrmDtuSet().ShowDialog();
        }

        //ProgressBarHelper hlper = null;
        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void menu_UploadFlow_Click(object sender, EventArgs e)
        {
            new FrmUpLoadFlow().ShowDialog();
        }

        private void menu_AuthorClient_Click(object sender, EventArgs e)
        {
            new FrmClientAuthor().ShowDialog();
        }

        private void menu_SNProduct_Click(object sender, EventArgs e)
        {
            new FrmSNProduct().ShowDialog();
        }

        private void menu_SNMng_Click(object sender, EventArgs e)
        {
            new FrmSNManager().ShowDialog();
        }

        private void menu_ImportantDevice_Click(object sender, EventArgs e)
        {
            new FrmImportantDevice().ShowDialog();
        }

        private void menu_Transmit_Click(object sender, EventArgs e)
        {
            new FrmTransmit().ShowDialog();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出本系统吗？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    if (CurUser != null && CurUser != "")
                    {
                        ServiceProxy.UserServiceProxy.LoginOut(CurUser, (int)Enumerations.ClientType.Winfo_Tool, WinManager.GetPublicIP());
                    }
                }
                catch (Exception msg)//捕获异常
                {
                    LogManager.WriteExceptionLog(msg, "BaseMain.PG_FormClosing");
                }
            }
        }

        private void menu_TransDif_Click(object sender, EventArgs e)
        {
            new FrmTransDifConf().ShowDialog();
        }

        private void FieldManagerMenu2_Click(object sender, EventArgs e)
        {
            new FrmDtuFieldMana().ShowDialog();
        }

        private void DtuUserMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDtuUserManager().ShowDialog();
        }

        private void menu_about_Click(object sender, EventArgs e)
        {
            new Frm_SysInfo().ShowDialog();
        }

        private void menu_ValveEffect_Click(object sender, EventArgs e)
        {
            new FrmValveEffect().ShowDialog();
        }

        private void menu_OdorDTU_Click(object sender, EventArgs e)
        {
            new FrmOdorDTU().ShowDialog();
        }

        private void DTUConfigMenuItem2_Click(object sender, EventArgs e)
        {
            new FrmOdorDtuConfig().ShowDialog();
        }

        private void menu_ClientKey_Click(object sender, EventArgs e)
        {
            new FrmRegisterClientKey().ShowDialog();
        }

        private void menu_DOConfig_Click(object sender, EventArgs e)
        {
            new FrmDTU_DOConfig().ShowDialog();
        }
    }
}
