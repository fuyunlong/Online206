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
using System.IO;
using Com.Winfotian.ServiceProxy;

namespace Com.Winfotian.MngTool.ClientMng
{
    public partial class FrmSNProduct : FrmBase
    {
        public FrmSNProduct()
        {
            InitializeComponent();
        }

        private List<string> tmpSnlist = null;

        private void FrmSNProduct_Load(object sender, EventArgs e)
        {
            ProgressBarHelper progress = new ProgressBarHelper();
            progress.PopProgressBar("数据加载中...");
            try
            {
                cbxQCompany.DataSource = CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
                cbxQCompany.DisplayMember = "CompanyName";
                cbxQCompany.ValueMember = "CompanyId";

                this.date_End.Text = DateTime.Now.AddYears(1).ToString();
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
            progress.CloseProgressBar();
        }

        private void btn_Build_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "文本文件|*.txt|所有文件|*.*";
                openfile.Multiselect = false;
                if (openfile.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openfile.FileName))
                    {
                        tmpSnlist = new List<string>();
                        list_SN.Items.Clear();
                        while (sr.Peek() > 0)
                        {
                            string readline = sr.ReadLine();
                            if (!string.IsNullOrEmpty(readline))
                            {
                                tmpSnlist.Add(readline);
                                list_SN.Items.Add(readline);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ProgressBarHelper progress = new ProgressBarHelper();
            progress.PopProgressBar("数据验证中...");
            try
            {
                if (this.txt_Vali.Text == "admin159")
                {
                    string tmpErr = string.Empty;
                    if (tmpSnlist == null || tmpSnlist.Count == 0)
                    {
                        tmpErr += "序列号不能空\n";
                    }
                    if (cbxQCompany.SelectedItem == null)
                    {
                        tmpErr += "所属公司不能空\n";
                    }
                    if (tmpErr == string.Empty)
                    {
                        this.btn_OK.Enabled = false;
                        this.btn_Build.Enabled = false;
                        ServiceProxy.CommonService.T_SN_Info model = new ServiceProxy.CommonService.T_SN_Info();
                        model.BuildTime = DateTime.Now;
                        model.ClientKey = "A8632848F1B3723968318A8ABA7318BE0B";
                        model.CompanyId = Convert.ToInt32(cbxQCompany.SelectedValue.ToString());
                        model.EffectStart = DateTime.Parse(date_Start.Text);
                        model.EffectEnd = DateTime.Parse(date_End.Text);
                        model.Status = 0;
                        model.UserId = string.Empty;
                        int i = 0;
                        foreach (var itm in tmpSnlist)
                        {
                            model.SN = Com.Winfotian.Encrypts.DESEncrypt.Encrypt(itm);
                            CommonServiceProxy.BuildNewSN(LocalIP, model);
                            progress.PopProgressBar("序列号导入中..." + i);
                            i++;
                        }
                        if (i > 0)
                        {
                            list_SN.Items.Clear();
                            tmpSnlist.Clear();
                            this.txt_Vali.Text = "";
                            progress.ShowDialogInfo("导入成功！");
                        }
                    }
                    else
                    {
                        progress.ShowDialogInfo(tmpErr);
                    }
                }
                else
                {
                    progress.ShowDialogInfo("没有权限");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
            progress.CloseProgressBar();
            this.btn_OK.Enabled = true;
            this.btn_Build.Enabled = true;
        }
    }
}
