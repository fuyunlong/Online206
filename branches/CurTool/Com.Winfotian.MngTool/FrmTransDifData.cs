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
    public partial class FrmTransDifData : FrmBase
    {
        public FrmTransDifData(int cmpId, ServiceProxy.DTUService.DtuField curField)
        {
            InitializeComponent();
            BindDtuField(cmpId, curField);
        }
        private void BindDtuField(int cmpId, ServiceProxy.DTUService.DtuField curField)
        {
            var models = ServiceProxy.DTUServiceProxy.GetDtuFieldListByCompanyId(LocalIP, cmpId);
            var filterModels = models.FindAll(p => p.Dtuid != curField.Dtuid);
            string curDtuid = string.Empty;
            string keyName = string.Empty;
            bool isPressure = false;
            TreeNode node = null;
            foreach (var item in filterModels)
            {
                if (curDtuid != item.Dtuid)
                {
                    node = new TreeNode(item.DtuidName);
                    node.Tag = item.Id;
                    tvDtuField.Nodes.Add(node);
                }
                keyName = GetFieldKeyName(curField, out isPressure);
                if (isPressure)
                {
                    if (item.FieldName.Contains("P") || (item.FieldName.Contains("AI") && item.ValueInOrOut > 0))
                    {
                        TreeNode subNode = new TreeNode(item.DtuidName + ":" + item.FieldShortDesc);
                        subNode.Tag = item;
                        node.Nodes.Add(subNode);
                    }
                }
                else
                {
                    if (item.FieldName.Substring(2) == keyName)
                    {
                        TreeNode subNode = new TreeNode(item.DtuidName + ":" + item.FieldShortDesc);
                        subNode.Tag = item;
                        node.Nodes.Add(subNode);
                    }
                }
                curDtuid = item.Dtuid;
            }
            tvDtuField.ExpandAll();
        }
        private string GetFieldKeyName(ServiceProxy.DTUService.DtuField field, out bool isPressure)
        {
            isPressure = false;
            string keyName = string.Empty;
            if (field.FieldName.Contains("P") || (field.FieldName.Contains("AI") && field.ValueInOrOut > 0))
            {
                isPressure = true;
            }
            else
            {
                isPressure = false;
                keyName = field.FieldName.Substring(2);
            }
            return keyName;
        }
        private void tvDtuField_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FrmTransDifConf frm = (FrmTransDifConf)this.Owner;
            frm.CurField = e.Node.Tag as ServiceProxy.DTUService.DtuField;
            this.DialogResult = DialogResult.OK;
        }
    }
}
