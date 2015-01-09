using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using System.Media;
using Com.Winfotian.Components;
using System.IO;
using Com.Winfotian.ServiceProxy;
using Com.Winfotian.Encrypts;

namespace Com.Winfotian.MngTool
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
            this.ShowInTaskbar = true;
            ToolHelper.WirteINIValue("ValidateName", "cType", Com.Winfotian.ServiceProxy.UpdateService.ClientType.Winfo_Tool.ToString());
        }

        #region
        bool dragEnable = true;
        bool dragging = false;
        int xOld = 0;
        int yOld = 0;
        double dou = 0.05;
        ProgressBarHelper pbh = null;
        #endregion

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BringToFront();

            pbh = new ProgressBarHelper();
            pbh.PopProgressBar("正在检查进程...");
            if (!CheckProcess())
            {
                pbh.PopProgressBar("正在检查刷新文件...");
                FileHelper.UpdateFile("InfaRemote.dll");
                FileHelper.UpdateFile("UpClear.exe");
                FileHelper.UpdateFile("UpClear.exe.mainifest");
                FileHelper.UpdateFile("SysUpdate.exe");
            }
            pbh.PopProgressBar("正在检查网络,请稍等...");
            CheckNetWork();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.btn_Login.FlatStyle = FlatStyle.Flat;
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.Opacity = 0;
            this.timer1.Start();
            this.Refresh();
            pbh.CloseProgressBar();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string pbIp = WinManager.GetPublicIP();
            string uid = this.txt_uid.Text.Trim();
            try
            {
                string tempArr = "";
                string pwd = this.txt_pwd.Text.Trim();
                if (string.IsNullOrEmpty(uid))
                {
                    tempArr += "用户名不能为空\r\n";
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    tempArr += "密码不能为空\r\n";
                }
                if (tempArr == "")
                {
                    string lginfo = string.Empty;
                    CINIFile ini = new CINIFile(ToolHelper.ApplicationPath + "InfaVer.dll");
                    string rslt = UserServiceProxy.UserLogin(uid, DESEncrypt.Encrypt(pwd), pbIp, (int)Enumerations.ClientType.Winfo_Tool);
                    if (rslt.Substring(0, 1) == "X")
                    {
                        //检查用户是否有设备
                        string[] arrrslt = rslt.Split('*');
                        var attr = ToolHelper.ParseAtts(arrrslt[1]);
                        if (attr["CompanyId"] == "12")
                        {
                            //ini.WirteINIValue("ValidateName", "vk", DESEncrypt.Encrypt(arrrslt[2]));
                            string valiCus = string.Format("Uid={0};Pwd={1};URole=;", uid, pwd);
                            ToolHelper.WirteINIValue("ValidateName", "validcustomer", DESEncrypt.Encrypt(valiCus));
                            lginfo = "1";
                            //检测更新程序
                            CreateProcess("SysUpdate");
                            //缓存菜单权限，不做删除，离线时和在线权限一样，为空的时候重新获取，获取为空退出系统；
                        }
                        else
                        {
                            lginfo = "非授权用户登录！";
                        }
                    }
                    else
                    {
                        switch (rslt)
                        {
                            case "-2":
                                lginfo = "同一账号不能同时登录，或10分钟后重新登录";
                                break;
                            case "-3":
                                lginfo = "用户名或密码错误";
                                break;
                            case "-4":
                                lginfo = "网络异常，请确认网络正常！";
                                break;
                            case "-5":
                                lginfo = "没有权限，请联系供应商：\nsupport@winfotian.com;\n028-61100999-2010";
                                break;
                            case "-6":
                                lginfo = "非法登录30分钟后才能登录";
                                break;
                            case "-7":
                                lginfo = "未授权需要验证码才能登录成功";
                                break;
                            case "-8":
                                lginfo = "没有注册，请联系供应商：\nsupport@winfotian.com;\n028-61100999-2010";
                                break;
                            default:
                                lginfo = "远程登陆失败，错误码：" + rslt;
                                break;
                        }
                    }
                    if (lginfo == "1")
                    {
                        LogBLL.WriteLoginLog(pbIp, uid, pwd, 1);
                        FrmMain frm = new FrmMain();
                        frm.CurUser = uid;
                        frm.CurCompanyId = 12;
                        this.Visible = false;
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.txt_pwd.Text = "";
                        LogBLL.WriteLoginLog(pbIp, uid, pwd, 2, lginfo);
                        MessageBox.Show(lginfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    this.txt_pwd.Text = "";
                    MessageBox.Show(tempArr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(pbIp, string.IsNullOrEmpty(uid) ? "sys_tool" : uid, ex);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void pnl_back_MouseDown(object sender, MouseEventArgs e)
        {
            if (dragEnable && e.Button == MouseButtons.Left)
            {
                //   保存当前鼠标的位置，可以用它来计算鼠标移动的距离   
                xOld = MousePosition.X;
                yOld = MousePosition.Y;
                //   标识鼠标正在拖动窗体   
                dragging = true;
            }
        }

        private void pnl_back_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragEnable && e.Button == MouseButtons.Left)
                dragging = false;
        }

        private void pnl_back_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragEnable && dragging)
            {
                //   计算出鼠标在   X   和   Y   坐标方向上移动的距离   
                int dx = MousePosition.X - xOld;
                int dy = MousePosition.Y - yOld;

                //   根据上面的结果计算出窗体偏移后的位置   
                Point point = this.Location;
                point.Offset(dx, dy);

                //   设置上面的偏移位置为窗体的位置   
                this.Location = point;

                //   保存当前鼠标的位置，用于下一个循环的计算   
                xOld = MousePosition.X;
                yOld = MousePosition.Y;
            }
        }

        private void lb_Company_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lb_Company_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        #region 初始化数据
        private delegate void DealDelegate();
        /// <summary>
        /// 
        /// </summary>
        private void PlayAlert()
        {
            try
            {
                string path = ToolHelper.ApplicationPath + "Sound\\" + ToolHelper.ReadINIValue("SoundSet", "StartSound", "Start.wav");
                if (File.Exists(path))
                {
                    SoundPlayer simpleSound = new SoundPlayer(path);
                    simpleSound.Play();
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex, "Frm_Login.PlayAlert");
            }
        }
        #endregion

        #region private
        /// <summary>
        /// 
        /// </summary>
        private bool CheckProcess()
        {
            bool isRun = false;
            try
            {
                if (WinManager.CheckIsHaveProcess("MngTool") > 1)
                {
                    isRun = true;
                    MessageBox.Show("您已启动本系统，不可以再打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    this.Close();
                }
                if (WinManager.CheckIsHaveProcess("SysUpdate") > 1)
                {
                    isRun = true;
                    MessageBox.Show("系统正在更新，请稍后...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    this.Close();
                }
                if (WinManager.CheckIsHaveProcess("UpClear") > 1)
                {
                    isRun = true;
                    MessageBox.Show("系统正在更新，请稍后...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex, "CheckProcess");
            }
            return isRun;
        }
        /// <summary>
        /// 检查网络
        /// </summary>
        private void CheckNetWork()
        {
            string temp = "local";
            if (NetWorkHelper.CheckInternetConnect())
            {
                temp = "remote";
                ToolHelper.WirteINIValue("NetworkConnect", "connected", temp);
            }
            else
            {
                pbh.CloseProgressBar();
                MessageBox.Show(this, "没有网络或无法连接到服务器", "网络问题", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                this.Close();
            }
        }
        /// <summary>
        /// 检测进程
        /// </summary>
        /// <param name="isCreate"></param>
        /// <param name="ProcessName"></param>
        public virtual void CreateProcess(string ProcessName)
        {
            try
            {
                string path = ToolHelper.ApplicationPath + ProcessName + ".exe";
                if (WinManager.CheckIsHaveProcess(ProcessName) > 0)
                {
                    WinManager.KillProcessByName(ProcessName);
                    if (System.IO.File.Exists(path))
                        System.Diagnostics.Process.Start(path);
                }
                else
                {
                    if (System.IO.File.Exists(path))
                        System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex, "BaseForm.CheckProcess");
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += dou;
            if (this.Opacity == 1)
            {
                timer1.Stop();
                dou = -0.05;
            }
            else if (this.Opacity == 0)
            {
                timer1.Stop();
            }
        }
    }
}