using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using System.IO;

namespace Com.Winfotian.MngTool
{
    public partial class FrmBase : Form
    {
        private string _localip;
        public FrmBase()
        {
            InitializeComponent();
            PG_ValidateUser();
        }
        /// <summary>
        /// 当前用户
        /// </summary>
        public string CurUser
        {
            set;
            get;
        }
        /// <summary>
        /// 当前用户
        /// </summary>
        public int CurCompanyId
        {
            set;
            get;
        }
        /// <summary>
        /// 本地IP
        /// </summary>
        public string LocalIP
        {
            get { if (string.IsNullOrEmpty(_localip)) { _localip = GetLocalIp(); } return _localip.Replace("\n", ""); }
        }
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        private string GetLocalIp()
        {
            return WinManager.GetPublicIP();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void PG_ValidateUser()
        {
            string admin = Com.Winfotian.Encrypts.DESEncrypt.Decrypt(ToolHelper.ReadINIValue("ValidateName", "validcustomer", "A867D95E1A1869F23C2CDFE10F7D3087269D6D8E8BE7D4CAFEE6EFE06BA894C20E8D015857DCB93EBB"));
            if (admin != "")
            {
                System.Collections.Specialized.NameValueCollection att = ToolHelper.ParseAtts(admin);
                if (att != null)
                {
                    CurUser = att.Get("Uid");
                    //_localpwd = att.Get("Pwd");
                    //_level = att.Get("URole").ToLower();
                    if (CurUser == "daolian")
                    {
                        CurUser = "";
                        MessageBox.Show("非法登录，请重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DirectoryInfo dinfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                        var files = dinfo.GetFiles("*.exe", SearchOption.TopDirectoryOnly);
                        foreach (var fl in files)
                        {
                            if (fl.Name != "SysUpdate.exe" && fl.Name != "UpClear.exe")
                            {
                                WinManager.KillProcessByName(fl.Name);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
