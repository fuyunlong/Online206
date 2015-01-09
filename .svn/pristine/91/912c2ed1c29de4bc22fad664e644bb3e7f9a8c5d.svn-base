using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Winfotian.Common;
using Com.Winfotian.Components;

namespace Com.Winfotian.MngTool.ClientMng
{
    public partial class FrmSNManager : FrmBase
    {
        public FrmSNManager()
        {
            InitializeComponent();
        }

        private void LoadCompanySN(string CompanyId)
        {
            if (!ToolHelper.IsNumber(CompanyId)) return;
            ProgressBarHelper progress = new ProgressBarHelper();
            progress.PopProgressBar("数据加载中...");
            try
            {
                list_SN.Items.Clear();
                var snlist = ServiceProxy.CommonServiceProxy.GetSNInfoByCompanyId(LocalIP,int.Parse(CompanyId));
                if (snlist != null)
                {
                    ListViewItem LvItem = null;
                    foreach (var itm in snlist)
                    {
                        LvItem = new ListViewItem(Com.Winfotian.Encrypts.DESEncrypt.Decrypt(itm.SN));
                        LvItem.SubItems.Add(Com.Winfotian.Encrypts.DESEncrypt.Decrypt(itm.UserId));
                        LvItem.SubItems.Add((itm.RegistTime.HasValue) ? itm.RegistTime.ToString() : "--");
                        LvItem.SubItems.Add((itm.Status == 0) ? "未激活" : "激活");
                        LvItem.SubItems.Add(itm.EffectStart.ToString("yyyy-MM-dd"));
                        LvItem.SubItems.Add(itm.EffectEnd.ToString("yyyy-MM-dd"));
                        LvItem.SubItems.Add(itm.BuildTime.ToString("yyyy-MM-dd"));
                        list_SN.Items.Add(LvItem);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
            progress.CloseProgressBar();
        }

        private void cbxQCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCompanySN(cbxQCompany.SelectedValue.ToString());
        }

        private void FrmSNManager_Load(object sender, EventArgs e)
        {
            ProgressBarHelper progress = new ProgressBarHelper();
            progress.PopProgressBar("数据加载中...");
            try
            {
                cbxQCompany.DataSource = ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
                cbxQCompany.DisplayMember = "CompanyName";
                cbxQCompany.ValueMember = "CompanyId";

                if (cbxQCompany.Items.Count > 0)
                {
                    cbxQCompany.SelectedIndex = 0;
                    LoadCompanySN(cbxQCompany.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
            progress.CloseProgressBar();
        }
    }
}
