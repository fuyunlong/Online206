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

namespace Com.Winfotian.MngTool
{
    public partial class FrmTransmit : FrmBase
    {
        private Dictionary<string, string> verAndName = null;
        private int curId = 0;
        public FrmTransmit()
        {
            InitializeComponent();
            BindTransmitedDtu(true);
            BindDtuList();
        }
        private void BindTransmitedDtu(bool isFirst)
        {
            var transList = ServiceProxy.DTUServiceProxy.GetDTUTransmitByUser(LocalIP, CurUser);
            if (isFirst && (transList == null || transList.Count == 0))
            {
                MessageBox.Show("当前用户拥有的站点没有转发配置！");
            }
            dgvDtuList.DataSource = transList;
        }
        private void BindDtuList()
        {
            cbxDtu.Items.Clear();
            cbxDtu.DataSource = ServiceProxy.DTUServiceProxy.GetUserDtuList(CurUser, LocalIP);
            cbxDtu.DisplayMember = "DtuidName";
            cbxDtu.ValueMember = "Dtuid";

            verAndName = ServiceProxy.DTUServiceProxy.GetAllExistVerAndName(LocalIP);
            txtVersion.Items.Clear();
            txtVersion.Items.AddRange(verAndName.Keys.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                if (!ToolHelper.IsIPv4(txtIP.Text) || (txtIP.Text.IndexOf(":") > 0 && !ToolHelper.IsIPV6(txtIP.Text)))
                {
                    MessageBox.Show("请配置正确的IP地址!");
                    return;
                }
                if (!ToolHelper.IsNumber(txtPort.Text))
                {
                    MessageBox.Show("端口号必须是数字!");
                    return;
                }
                if (!ToolHelper.IsNumber(txt_TargetPhone.Text))
                {
                    MessageBox.Show("端口号必须是数字!");
                    return;
                }
                pbh.PopProgressBar("正在保存配置!");
                ServiceProxy.DTUService.T_DTU_Transmit model = new ServiceProxy.DTUService.T_DTU_Transmit();
                model.Dtuid = cbxDtu.SelectedValue.ToString();
                model.IsTransmit = rbtnIsTransmitTrue.Checked ? 1 : 0;
                model.TargetIP = txtIP.Text.Trim();
                model.TargetPort = int.Parse(txtPort.Text.Trim());
                model.TargetVersion = txtVersion.Text;
                model.TargetSiteId = Convert.ToInt32(txtTargetId.Value);
                model.OrderNum = Convert.ToInt32(txt_OrderNum.Value);
                model.TargetPhoneNum = txt_TargetPhone.Text;
                model.TransDesc = txt_Desc.Text;
                model.TransProtocol = rdo_TCP.Checked ? 1 : 2;
                ServiceProxy.DTUServiceProxy.AddDTUTransmit(LocalIP, model);
                pbh.ShowDialogInfo("添加成功！");
                BindTransmitedDtu(false);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加转发站点:{0}", model.Dtuid), 1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("保存失败:" + ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (!ToolHelper.IsIPv4(txtIP.Text) || (txtIP.Text.IndexOf(":") > 0 && !ToolHelper.IsIPV6(txtIP.Text)))
            {
                MessageBox.Show("请配置正确的IP地址!");
                return;
            }
            if (!ToolHelper.IsNumber(txtPort.Text))
            {
                MessageBox.Show("端口号必须是数字!");
                return;
            }
            if (curId == 0)
            {
                MessageBox.Show("请重新选择需要修改的转发配置！");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在保存配置!");
                ServiceProxy.DTUService.T_DTU_Transmit model = new ServiceProxy.DTUService.T_DTU_Transmit();
                model.Id = curId;
                model.Dtuid = cbxDtu.SelectedValue.ToString();
                model.IsTransmit = rbtnIsTransmitTrue.Checked ? 1 : 0;
                model.TransProtocol = rdo_TCP.Checked ? 1 : 2;
                model.TargetIP = txtIP.Text.Trim();
                model.TargetPort = int.Parse(txtPort.Text.Trim());
                model.TargetVersion = txtVersion.Text;
                model.TargetSiteId = Convert.ToInt32(txtTargetId.Value);
                model.OrderNum = Convert.ToInt32(txt_OrderNum.Value);
                model.TargetPhoneNum = txt_TargetPhone.Text;
                model.TransDesc = txt_Desc.Text;
                ServiceProxy.DTUServiceProxy.UpdateDTUTransmit(LocalIP, model);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("修改转发站点:{0}", model.Dtuid), 1);
                pbh.CloseProgressBar();
                MessageBox.Show("修改成功!");
                ClearForm();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("修改失败:" + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (curId == 0)
            {
                MessageBox.Show("请重新选择需要修改的转发配置！");
                return;
            }
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在删除站点转发数据!");
                var rslt = ServiceProxy.DTUServiceProxy.DeleteDTUTransmitById(LocalIP, curId);
                if (rslt.State == ServiceProxy.DTUService.ReturnState.Success)
                {
                    ClearForm();
                    BindTransmitedDtu(false);
                    LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("删除转发站点:{0}", curId), 1);
                }
                pbh.CloseProgressBar();
                MessageBox.Show("删除成功!");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("删除失败:" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cbxDtu.Enabled = true;
            btnMod.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            ClearForm();
        }
        private void ClearForm()
        {
            cbxDtu.Enabled = true;
            rbtnIsTransmitTrue.Checked = true;
            rdo_TCP.Checked = true;
            txtIP.Text = "";
            txtPort.Text = "";
            txt_TargetPhone.Text = "";
            txtTargetId.Value = 1;
            txt_OrderNum.Value = 1;
            txt_Desc.Text = "";
            curId = 0;
        }

        private void dgvDtuList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDtuList.SelectedRows[0];
            curId = Convert.ToInt32(row.Cells["Id"].Value.ToString());
            string Dtuid = row.Cells["Dtuid"].Value.ToString();
            cbxDtu.SelectedValue = Dtuid;
            ServiceProxy.DTUService.T_DTU_Transmit model = ServiceProxy.DTUServiceProxy.GetDTUTransmitById(LocalIP, curId);
            txtIP.Text = model.TargetIP;
            txtPort.Text = model.TargetPort.ToString();
            txtVersion.Text = model.TargetVersion;
            txt_TargetPhone.Text = model.TargetPhoneNum;
            txtTargetId.Value = model.TargetSiteId;
            txt_OrderNum.Value = model.OrderNum;
            txt_Desc.Text = model.TransDesc;
            if (model.IsTransmit == 1)
            {
                rbtnIsTransmitTrue.Checked = true;
            }
            else
            {
                rbtnIsTransmitFalse.Checked = true;
            }
            if (model.TransProtocol == 1)
            {
                rdo_TCP.Checked = true;
            }
            else
            {
                rdo_UDP.Checked = true;
            }
            cbxDtu.Enabled = false;
            btnMod.Enabled = true;
            btnDel.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void txtVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (verAndName.ContainsKey(txtVersion.Text.Trim()))
            {
                lb_Memo.Text = verAndName[txtVersion.Text.Trim()];
                txt_Desc.Text = verAndName[txtVersion.Text.Trim()];
            }
            else
            {
                lb_Memo.Text = "系统中暂不添加该协议，请慎重填写";
            }
            //switch (txtVersion.Text.Trim())
            //{
            //    case "AA66":
            //        lb_Memo.Text = "转发为OPC协议";
            //        break;
            //    case "AA67":
            //        lb_Memo.Text = "原始转发";
            //        break;
            //    case "AA68":
            //        lb_Memo.Text = "透明传输";
            //        break;
            //    case "AA88":
            //        lb_Memo.Text = "宏电转发(三台)";
            //        break;
            //    case "AA89":
            //        lb_Memo.Text = "Modbus转发(简阳)";
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
