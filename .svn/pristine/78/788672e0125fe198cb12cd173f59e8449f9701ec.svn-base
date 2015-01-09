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
    public partial class FrmTransDifConf : FrmBase
    {
        public ServiceProxy.DTUService.DtuField CurField { get; set; }

        public FrmTransDifConf()
        {
            InitializeComponent();
            cbxQCompany.SelectedIndexChanged -= new EventHandler(cbxQCompany_SelectedIndexChanged);
            CompanyBind();
        }
        private void CompanyBind()
        {
            cbxQCompany.DataSource = ServiceProxy.CompanyServiceProxy.GetCompanyIDAndNameList(LocalIP);
            cbxQCompany.DisplayMember = "CompanyName";
            cbxQCompany.ValueMember = "CompanyId";
            cbxQCompany.SelectedIndex = -1;
            cbxQCompany.SelectedIndexChanged += new EventHandler(cbxQCompany_SelectedIndexChanged);
        }
        private void BindDtuField(int cmpId)
        {
            var models = ServiceProxy.DTUServiceProxy.GetDtuFieldListByCompanyId(LocalIP, cmpId);
            string dtuid = string.Empty;
            TreeNode node = null;
            foreach (var item in models)
            {
                if (dtuid != item.Dtuid)
                {
                    node = new TreeNode(item.DtuidName);
                    node.Tag = item;
                    tvDtuField.Nodes.Add(node);
                }
                TreeNode subNode;
                if (item.ParentId != 0)
                {
                    ServiceProxy.DTUService.DtuField parentField = models.Find(p => p.Id == item.ParentId);
                    subNode = new TreeNode(string.Format("{0}:{1}--->>{2}:{3}", item.DtuidName, item.FieldShortDesc, parentField.DtuidName, parentField.FieldShortDesc));
                }
                else
                {
                    subNode = new TreeNode(string.Format("{0}:{1}", item.DtuidName, item.FieldShortDesc));
                }
                subNode.ContextMenuStrip = ctMenu;
                subNode.Tag = item;
                node.Nodes.Add(subNode);
                dtuid = item.Dtuid;
            }
            tvDtuField.ExpandAll();
        }

        private void menuConf_Click(object sender, EventArgs e)
        {
            CurField = null;
            TreeNode node = tvDtuField.SelectedNode;
            var model = node.Tag as ServiceProxy.DTUService.DtuField;
            FrmTransDifData frm = new FrmTransDifData((cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId, model);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (CurField != null)
                {
                    ServiceProxy.DTUServiceProxy.UpdateFieldParentId(LocalIP, model.Id, CurField.Id);
                    node.Text = string.Format("{0}:{1}--->>{2}:{3}", model.DtuidName, model.FieldShortDesc, CurField.DtuidName, CurField.FieldShortDesc);
                }
            }
        }

        private void menuDel_Click(object sender, EventArgs e)
        {
            TreeNode node = tvDtuField.SelectedNode;
            var model = node.Tag as ServiceProxy.DTUService.DtuField;
            ServiceProxy.DTUServiceProxy.UpdateFieldParentId(LocalIP, model.Id, 0);
            node.Text = string.Format("{0}:{1}", model.DtuidName, model.FieldShortDesc);
        }

        private void cbxQCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxQCompany.DataSource != null && cbxQCompany.SelectedIndex > -1)
            {
                tvDtuField.Nodes.Clear();
                BindDtuField((cbxQCompany.SelectedItem as ServiceProxy.CompanyService.CompanyIDAndName).CompanyId);
            }
        }

        private void tvDtuField_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvDtuField.SelectedNode = e.Node;
        }
    }
}
