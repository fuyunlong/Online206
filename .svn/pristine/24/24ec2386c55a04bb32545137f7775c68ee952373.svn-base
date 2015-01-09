using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool.ClientMng
{
    public partial class FrmClientAuthor : FrmBase
    {
        public FrmClientAuthor()
        {
            InitializeComponent();
        }

        private string UserId = string.Empty;

        private void FrmClientAuthor_Load(object sender, EventArgs e)
        {
            ProgressBarHelper progress = new ProgressBarHelper();
            progress.PopProgressBar("数据加载中...");
            try
            {
                Random rd = new Random(DateTime.Now.Millisecond);
                this.txt_Key.Text = rd.Next(10000000, 99999999).ToString();
                drp_UserId.DataSource = ServiceProxy.UserServiceProxy.GetUserAndNameListBy(LocalIP, 1, 0, null, null);
                drp_UserId.DisplayMember = "TrueName";
                drp_UserId.ValueMember = "UserId";
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
            progress.CloseProgressBar();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ProgressBarHelper progress = new ProgressBarHelper();
            try
            {
                progress.PopProgressBar("授权验证中...");
                if (drp_UserId.SelectedItem != null)
                {
                    string tmpUserId = drp_UserId.SelectedValue.ToString();
                    if (tmpUserId == UserId)
                    {
                        progress.ShowDialogInfo("激活码失效之前，相同用户不能重复授权");
                        progress.CloseProgressBar();
                        return;
                    }
                    ServiceProxy.CommonService.T_SN_Apply model = new ServiceProxy.CommonService.T_SN_Apply();
                    model.BuildBy = "admin";
                    model.BuildTime = DateTime.Now;
                    model.Status = 1;
                    model.ValiKey = this.txt_Key.Text.Trim();
                    model.valiUser = Com.Winfotian.Encrypts.DESEncrypt.Encrypt(tmpUserId);//加密
                    if (ServiceProxy.CommonServiceProxy.BuildApply(LocalIP, model) > 0)
                    {
                        UserId = tmpUserId;
                        progress.ShowDialogInfo("授权成功\n请牢记激活码：" + model.ValiKey + "\n请提醒用户尽快激活，否则1小时后失效");
                        Random rd = new Random(DateTime.Now.Millisecond);
                        this.txt_Key.Text = rd.Next(10000000, 99999999).ToString();
                    }
                    else
                    {
                        progress.ShowDialogInfo("授权失败");
                    }
                }
                else
                {
                    progress.ShowDialogInfo("请选择用户");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
            progress.CloseProgressBar();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
