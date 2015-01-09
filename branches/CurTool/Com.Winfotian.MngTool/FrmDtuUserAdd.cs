using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDtuUserAdd : FrmBase
    {
        public FrmDtuUserAdd(int cmpId, string dtuId)
        {
            InitializeComponent();
            UserBind(cmpId, dtuId);
        }
        private void UserBind(int cmpId, string dtuId)
        {
            dgvUser.DataSource = ServiceProxy.UserServiceProxy.GetUserCanAssign(LocalIP, cmpId, dtuId);
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmDtuUserManager frm = (FrmDtuUserManager)this.Owner;
            frm.CurUserInfo = dgvUser.SelectedRows[0].DataBoundItem as ServiceProxy.UserService.UserIDAndName;
            this.DialogResult = DialogResult.OK;
        }
    }
}
