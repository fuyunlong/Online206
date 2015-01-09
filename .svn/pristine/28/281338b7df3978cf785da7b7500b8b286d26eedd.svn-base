using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Components;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuUser : FrmBase
    {
        public FrmDtuUser(string Dtuid, string DtuName, List<ServiceProxy.UserService.UserIDAndName> userList)
        {
            InitializeComponent();
            txtDtuid.Text = Dtuid;
            txtDtuName.Text = DtuName;
            cklbUser.DataSource = userList;
            cklbUser.DisplayMember = "TrueName";
            cklbUser.ValueMember = "UserId";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存站点和用户关系数据");
                List<ServiceProxy.UserService.T_User_UserDtuid> listUserDtuid = new List<ServiceProxy.UserService.T_User_UserDtuid>();
                if (cklbUser.CheckedItems != null)
                {
                    for (int i = 0; i < cklbUser.CheckedItems.Count; i++)
                    {
                        listUserDtuid.Add(new ServiceProxy.UserService.T_User_UserDtuid() { Dtuid = txtDtuid.Text, UserId = (cklbUser.CheckedItems[i] as ServiceProxy.UserService.UserIDAndName).UserId, Status = 1 });
                    }
                    if (listUserDtuid.Count > 0)
                    {
                        ServiceProxy.UserServiceProxy.InsertListUserDtuid(LocalIP, listUserDtuid);
                        LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("保存站点{0}用户关系", txtDtuName.Text), 1);
                    }
                    pbh.ShowDialogInfo("保存成功!");
                }
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.ShowDialogInfo("保存失败:" + ex.Message);
                pbh.CloseProgressBar();
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
