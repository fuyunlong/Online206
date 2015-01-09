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
    public partial class FrmRegisterClientKey : Form
    {
        public FrmRegisterClientKey()
        {
            InitializeComponent();
            BindCheckListBox();
        }

        private void BindCheckListBox()
        {
            var Enums = Enum.GetValues(typeof(Com.Winfotian.Enumerations.ClientType)).OfType<Com.Winfotian.Enumerations.ClientType>();
            string text = string.Empty;
            foreach (Com.Winfotian.Enumerations.ClientType item in Enums)
            {
                text = EnumHelper.GetEnumDescrptionByKey<Com.Winfotian.Enumerations.ClientType>(item.ToString());
                drp_ClientType.Items.Add(new CheckedListBoxItem(text, ((int)item).ToString()));
            }
            drp_ClientType.SelectedIndex = 0;
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (this.txt_UserId.Text.Trim() == string.Empty)
            {
                MessageBox.Show("用户编号不能为空！");
                return;
            }
            if (this.txt_ClientKey.Text.Trim() == string.Empty)
            {
                MessageBox.Show("机器码不能为空！");
                return;
            }
            var rtn = ServiceProxy.CommonServiceProxy.RegisterClientKey(this.txt_UserId.Text.Trim(), this.txt_ClientKey.Text.Trim(), Convert.ToInt32(((CheckedListBoxItem)drp_ClientType.SelectedItem).Value));
            if (rtn.ResultState == ServiceProxy.CommonService.SNValiResultType.SNSuccess)
            {
                MessageBox.Show("恭喜您，注册成功！");
                this.txt_ClientKey.Text = "";
                this.txt_UserId.Text = "";
            }
            else
            {
                MessageBox.Show("Err:" + rtn.Message);
            }
        }
    }
}
