using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Com.Winfotian.Common;
using System.Linq;
using System.Collections.Specialized;

namespace Com.Winfotian.MngTool
{
    public partial class FrmOdorDtuField : FrmBase
    {
        string Dtuid;
        string DtuName;
        int CompanyID;
        DTUFieldDesc curModel;
        public FrmOdorDtuField(string Dtuid, string DtuName, int CompanyID, ServiceProxy.DTUService.OdorDTUConfig config)
        {
            InitializeComponent();
            txtDtuid.Text = Dtuid;
            this.Dtuid = Dtuid;
            this.DtuName = DtuName;
            this.CompanyID = CompanyID;
            GenerateField(config);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        private void GenerateField(ServiceProxy.DTUService.OdorDTUConfig config)
        {
            BindingList<DTUFieldDesc> models = new BindingList<DTUFieldDesc>();
            for (int i = 0; i < config.FlowNum; i++)
            {
                DTUFieldDesc model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("M{0}VB", i + 1);
                model.FieldShortDesc = string.Format("标况累计{0}", i + 1);
                model.FieldDesc = string.Format("标况累计{0}", i + 1);
                model.FieldUnit = "Nm3";
                model.ValueMin = 0;
                model.ValueMax = 9999999999999;
                model.Lowlimit = 0;
                model.Highlimit = 9999999999999;
                model.Lololimit = 0;
                model.Hihilimit = 9999999999999;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "示数";
                model.KeyValues = "";
                models.Add(model);

                model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("M{0}V", i + 1);
                model.FieldShortDesc = string.Format("工况累计{0}", i + 1);
                model.FieldDesc = string.Format("工况累计{0}", i + 1);
                model.FieldUnit = "Nm3";
                model.ValueMin = 0;
                model.ValueMax = 9999999999999;
                model.Lowlimit = 0;
                model.Highlimit = 9999999999999;
                model.Lololimit = 0;
                model.Hihilimit = 9999999999999;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "示数";
                model.KeyValues = "";
                models.Add(model);

                model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("M{0}QB", i + 1);
                model.FieldShortDesc = string.Format("标况瞬时{0}", i + 1);
                model.FieldDesc = string.Format("标况瞬时{0}", i + 1);
                model.FieldUnit = "Nm3/h";
                model.ValueMin = 0;
                model.ValueMax = 9999999999999;
                model.Lowlimit = 0;
                model.Highlimit = 9999999999999;
                model.Lololimit = 0;
                model.Hihilimit = 9999999999999;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "平均";
                model.KeyValues = "";
                models.Add(model);

                model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("M{0}Q", i + 1);
                model.FieldShortDesc = string.Format("工况瞬时{0}", i + 1);
                model.FieldDesc = string.Format("工况瞬时{0}", i + 1);
                model.FieldUnit = "Nm3/h";
                model.ValueMin = 0;
                model.ValueMax = 9999999999999;
                model.Lowlimit = 0;
                model.Highlimit = 9999999999999;
                model.Lololimit = 0;
                model.Hihilimit = 9999999999999;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "平均";
                model.KeyValues = "";
                models.Add(model);

                model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("M{0}P", i + 1);
                model.FieldShortDesc = string.Format("流量计压力{0}", i + 1);
                model.FieldDesc = string.Format("流量计压力{0}", i + 1);
                model.FieldUnit = "kPa";
                model.ValueMin = 0;
                model.ValueMax = 9999999999999;
                model.Lowlimit = 0;
                model.Highlimit = 9999999999999;
                model.Lololimit = 0;
                model.Hihilimit = 9999999999999;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "平均";
                model.KeyValues = "";
                models.Add(model);

                model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("M{0}T", i + 1);
                model.FieldShortDesc = string.Format("管道温度{0}", i + 1);
                model.FieldDesc = string.Format("管道温度{0}", i + 1);
                model.FieldUnit = "℃";
                model.ValueMin = 0;
                model.ValueMax = 100;
                model.Lowlimit = 0;
                model.Highlimit = 100;
                model.Lololimit = 0;
                model.Hihilimit = 100;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "平均";
                model.KeyValues = "";
                models.Add(model);
            }
            for (int i = 0; i < config.AINum; i++)
            {
                DTUFieldDesc model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("AI{0}", i + 1);
                model.FieldShortDesc = string.Format("模拟量{0}", i + 1);
                model.FieldDesc = string.Format("模拟量{0}", i + 1);
                model.FieldUnit = "";
                model.ValueMin = 0;
                model.ValueMax = 9999999999999;
                model.Lowlimit = 0;
                model.Highlimit = 9999999999999;
                model.Lololimit = 0;
                model.Hihilimit = 9999999999999;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "平均";
                model.KeyValues = "";
                models.Add(model);
            }
            for (int i = 0; i < config.DINum; i++)
            {
                DTUFieldDesc model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("DI{0}", i + 1);
                model.FieldShortDesc = string.Format("开关量{0}", i + 1);
                model.FieldDesc = string.Format("开关量{0}", i + 1);
                model.FieldUnit = "";
                model.ValueMin = -1;
                model.ValueMax = 2;
                model.Lowlimit = -1;
                model.Highlimit = 2;
                model.Lololimit = -1;
                model.Hihilimit = 2;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "不统计";
                model.KeyValues = "1=开;0=关;";
                models.Add(model);
            }
            int k = 1;
            for (int i = 0; i < config.BoardInfo.Count; i++)
            {
                DTUFieldDesc model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("AO{0}", i + 1);
                model.FieldShortDesc = string.Format("累计加臭罐数{0}", i + 1);
                model.FieldDesc = string.Format("面板{0}累计加臭罐数", i + 1);
                model.FieldUnit = "罐";
                model.ValueMin = 0;
                model.ValueMax = 65535;
                model.Lowlimit = 0;
                model.Highlimit = 65535;
                model.Lololimit = 0;
                model.Hihilimit = 65535;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "不统计";
                model.KeyValues = "";
                models.Add(model);

                model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = string.Format("BO{0}", i + 1);
                model.FieldShortDesc = string.Format("加注头个数{0}", i + 1);
                model.FieldDesc = string.Format("面板{0}加注头个数", i + 1);
                model.FieldUnit = "个";
                model.ValueMin = 1;
                model.ValueMax = 4;
                model.Lowlimit = 1;
                model.Highlimit = 4;
                model.Lololimit = 1;
                model.Hihilimit = 4;
                model.ValueInOrOut = "不分进出口";
                model.OrderId = 0;
                model.IsAlert = "否";
                model.IsCollect = "是";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = "是";
                model.FieldType = "不统计";
                model.KeyValues = "";
                models.Add(model);
                for (int j = 0; j < config.BoardInfo[i + 1]; j++)
                {
                    model = new DTUFieldDesc();
                    model.Dtuid = txtDtuid.Text.Trim();
                    model.ColName = "OPC_WINFO";
                    model.FieldName = string.Format("M{0}TC", k);
                    model.FieldShortDesc = string.Format("加臭模式{0}", k);
                    model.FieldDesc = string.Format("面板{1}加臭模式{0}", k, i + 1);
                    model.FieldUnit = "";
                    model.ValueMin = -1;
                    model.ValueMax = 2;
                    model.Lowlimit = -1;
                    model.Highlimit = 2;
                    model.Lololimit = -1;
                    model.Hihilimit = 2;
                    model.ValueInOrOut = "不分进出口";
                    model.OrderId = 0;
                    model.IsAlert = "否";
                    model.IsCollect = "是";
                    model.ParentId = 0;
                    model.UpdateFlag = 1;
                    model.IsShow = "是";
                    model.FieldType = "不统计";
                    model.KeyValues = "1=手动;0=自动;";
                    models.Add(model);

                    model = new DTUFieldDesc();
                    model.Dtuid = txtDtuid.Text.Trim();
                    model.ColName = "OPC_WINFO";
                    model.FieldName = string.Format("M{0}VC", k);
                    model.FieldShortDesc = string.Format("累计加臭量{0}", k);
                    model.FieldDesc = string.Format("面板{1}累计加臭量{0}", k, i + 1);
                    model.FieldUnit = "g";
                    model.ValueMin = 0;
                    model.ValueMax = 9999999999999;
                    model.Lowlimit = 0;
                    model.Highlimit = 9999999999999;
                    model.Lololimit = 0;
                    model.Hihilimit = 9999999999999;
                    model.ValueInOrOut = "不分进出口";
                    model.OrderId = 0;
                    model.IsAlert = "否";
                    model.IsCollect = "是";
                    model.ParentId = 0;
                    model.UpdateFlag = 1;
                    model.IsShow = "是";
                    model.FieldType = "示数";
                    model.KeyValues = "";
                    models.Add(model);

                    model = new DTUFieldDesc();
                    model.Dtuid = txtDtuid.Text.Trim();
                    model.ColName = "OPC_WINFO";
                    model.FieldName = string.Format("M{0}QC", k);
                    model.FieldShortDesc = string.Format("臭液瞬时浓度{0}", k);
                    model.FieldDesc = string.Format("面板{1}臭液瞬时浓度{0}", k, i + 1);
                    model.FieldUnit = "mg/Nm3";
                    model.ValueMin = 0;
                    model.ValueMax = 9999999999999;
                    model.Lowlimit = 0;
                    model.Highlimit = 9999999999999;
                    model.Lololimit = 0;
                    model.Hihilimit = 9999999999999;
                    model.ValueInOrOut = "不分进出口";
                    model.OrderId = 0;
                    model.IsAlert = "否";
                    model.IsCollect = "是";
                    model.ParentId = 0;
                    model.UpdateFlag = 1;
                    model.IsShow = "是";
                    model.FieldType = "平均";
                    model.KeyValues = "";
                    models.Add(model);

                    model = new DTUFieldDesc();
                    model.Dtuid = txtDtuid.Text.Trim();
                    model.ColName = "OPC_WINFO";
                    model.FieldName = string.Format("M{0}VBC", k);
                    model.FieldShortDesc = string.Format("臭液标况流量累计{0}", k);
                    model.FieldDesc = string.Format("面板{1}加臭标况流量累计{0}", k, i + 1);
                    model.FieldUnit = "Nm3";
                    model.ValueMin = 0;
                    model.ValueMax = 9999999999999;
                    model.Lowlimit = 0;
                    model.Highlimit = 9999999999999;
                    model.Lololimit = 0;
                    model.Hihilimit = 9999999999999;
                    model.ValueInOrOut = "不分进出口";
                    model.OrderId = 0;
                    model.IsAlert = "否";
                    model.IsCollect = "是";
                    model.ParentId = 0;
                    model.UpdateFlag = 1;
                    model.IsShow = "是";
                    model.FieldType = "示数";
                    model.KeyValues = "";
                    models.Add(model);

                    model = new DTUFieldDesc();
                    model.Dtuid = txtDtuid.Text.Trim();
                    model.ColName = "OPC_WINFO";
                    model.FieldName = string.Format("M{0}QBC", k);
                    model.FieldShortDesc = string.Format("臭液标况瞬时流量{0}", k);
                    model.FieldDesc = string.Format("面板{1}标况瞬时流量{0}", k, i + 1);
                    model.FieldUnit = "Nm3";
                    model.ValueMin = 0;
                    model.ValueMax = 9999999999999;
                    model.Lowlimit = 0;
                    model.Highlimit = 9999999999999;
                    model.Lololimit = 0;
                    model.Hihilimit = 9999999999999;
                    model.ValueInOrOut = "不分进出口";
                    model.OrderId = 0;
                    model.IsAlert = "否";
                    model.IsCollect = "是";
                    model.ParentId = 0;
                    model.UpdateFlag = 1;
                    model.IsShow = "是";
                    model.FieldType = "平均";
                    model.KeyValues = "";
                    models.Add(model);

                    model = new DTUFieldDesc();
                    model.Dtuid = txtDtuid.Text.Trim();
                    model.ColName = "OPC_WINFO";
                    model.FieldName = string.Format("M{0}PC", k);
                    model.FieldShortDesc = string.Format("加注阀动作次数{0}", k);
                    model.FieldDesc = string.Format("面板{1}加注阀动作次数{0}", k, i + 1);
                    model.FieldUnit = "次";
                    model.ValueMin = 0;
                    model.ValueMax = 65535;
                    model.Lowlimit = 0;
                    model.Highlimit = 65535;
                    model.Lololimit = 0;
                    model.Hihilimit = 65535;
                    model.ValueInOrOut = "不分进出口";
                    model.OrderId = 0;
                    model.IsAlert = "否";
                    model.IsCollect = "是";
                    model.ParentId = 0;
                    model.UpdateFlag = 1;
                    model.IsShow = "是";
                    model.FieldType = "示数";
                    model.KeyValues = "";
                    models.Add(model);
                    k++;
                }
            }
            dgvField.DataSource = models;
        }
        /// <summary>
        /// 保存DataGridView里面的数据到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvField.Rows.Count == 0)
            {
                MessageBox.Show("请添加站点字段数据!");
                return;
            }
            List<ServiceProxy.DTUService.T_DTU_FieldDesc> lisDtuField = new List<ServiceProxy.DTUService.T_DTU_FieldDesc>();
            ProgressBarHelper pbh = new ProgressBarHelper();
            try
            {
                pbh.PopProgressBar("正在组织站点字段数据!");
                BindingList<DTUFieldDesc> models = dgvField.DataSource as BindingList<DTUFieldDesc>;
                foreach (var row in models)
                {
                    ServiceProxy.DTUService.T_DTU_FieldDesc dtuField = new ServiceProxy.DTUService.T_DTU_FieldDesc();
                    dtuField.Dtuid = row.Dtuid;
                    dtuField.ColName = row.ColName;
                    dtuField.FieldName = row.FieldName;
                    dtuField.FieldShortDesc = row.FieldShortDesc;
                    dtuField.FieldDesc = row.FieldDesc;
                    dtuField.FieldUnit = row.FieldUnit;
                    dtuField.ValueMin = row.ValueMin;
                    dtuField.ValueMax = row.ValueMax;
                    dtuField.Lowlimit = row.Lowlimit;
                    dtuField.Highlimit = row.Highlimit;
                    dtuField.Lololimit = row.Lololimit;
                    dtuField.Hihilimit = row.Hihilimit;
                    dtuField.ValueInOrOut = 0;
                    if (!string.IsNullOrWhiteSpace(row.ValueInOrOut))
                    {
                        if (row.ValueInOrOut == "进")
                            dtuField.ValueInOrOut = 1;
                        else if (row.ValueInOrOut == "出")
                            dtuField.ValueInOrOut = 2;
                    }
                    dtuField.IsAlert = row.IsAlert == "是" ? 1 : 0;
                    dtuField.IsShow = row.IsShow == "是" ? 1 : 0;
                    dtuField.KeyValues = row.KeyValues;
                    dtuField.ParentId = 0;
                    dtuField.OrderId = row.OrderId;
                    if (dtuField.FieldName.ToUpper() == "ONLINE" || dtuField.FieldName.ToUpper() == "COLLECTTIME")
                    {
                        dtuField.IsCollect = 0;
                    }
                    else
                    {
                        dtuField.IsCollect = 1;
                    }
                    switch (row.FieldType)
                    {
                        case "不统计":
                            dtuField.FieldType = 0;
                            break;
                        case "累计":
                            dtuField.FieldType = 1;
                            break;
                        case "示数":
                            dtuField.FieldType = 2;
                            break;
                        case "平均":
                            dtuField.FieldType = 3;
                            break;
                        default:
                            dtuField.FieldType = 0;
                            break;
                    }
                    dtuField.UpdateFlag = 1;
                    lisDtuField.Add(dtuField);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("模板数据有错误:" + ex.Message);
                return;
            }
            try
            {
                //去除重复项
                pbh.PopProgressBar("正在检查字段数据是否有重复!");
                List<ServiceProxy.DTUService.T_DTU_FieldDesc> lisDtuFieldDistinct = new List<ServiceProxy.DTUService.T_DTU_FieldDesc>();//保存不重复的对象
                foreach (ServiceProxy.DTUService.T_DTU_FieldDesc item in lisDtuField)
                {
                    if (!lisDtuFieldDistinct.Exists(p => p.Dtuid == item.Dtuid && p.FieldName == item.FieldName))
                    {
                        item.IsShow = 1;
                        item.KeyValues = "0=关;1=开;";
                        lisDtuFieldDistinct.Add(item);
                    }
                }
                ServiceProxy.DTUServiceProxy.InsertListDTUFieldDesc(LocalIP, lisDtuFieldDistinct);
                LogBLL.WriteOperatorLog(LocalIP, CurUser, string.Format("添加站点字段:ID-{0},Name-{1}", Dtuid, DtuName), 1);
                pbh.CloseProgressBar();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                pbh.CloseProgressBar();
                MessageBox.Show("插入站点字段时出错:" + ex.Message);
                return;
            }
            //如果此站点所在下有用户则给本站点分配用户
            List<ServiceProxy.UserService.UserIDAndName> userList = ServiceProxy.UserServiceProxy.GetUserByCompanyID(LocalIP, CompanyID);
            if (userList.Count > 0)
            {
                this.Hide();
                Form frmDtuUser = new FrmDtuUser(Dtuid, DtuName, userList);
                if (frmDtuUser.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        /// <summary>
        /// 单行添加数据到DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string valiResult = ValidateInput();
                if (!string.IsNullOrEmpty(valiResult))
                {
                    MessageUtil.ShowWarning(valiResult);
                    return;
                }
                string filedName = GetFieldName(Convert.ToInt32(drp_Index.Value), drp_FieldName.Text.Trim());
                
                if (dgvField.DataSource == null) dgvField.DataSource = new BindingList<DTUFieldDesc>();
                BindingList<DTUFieldDesc> models = dgvField.DataSource as BindingList<DTUFieldDesc>;
                DTUFieldDesc model = new DTUFieldDesc();
                model.Dtuid = txtDtuid.Text.Trim();
                model.ColName = "OPC_WINFO";
                model.FieldName = filedName;
                model.FieldShortDesc = txtFieldShortDesc.Text.Trim();
                model.FieldDesc = txtFieldDesc.Text.Trim();
                model.FieldUnit = txtFieldUnit.Text.Trim();
                model.ValueMin = double.Parse(txtValueMin.Text.Trim());
                model.ValueMax = double.Parse(txtValueMax.Text.Trim());
                model.Lowlimit = double.Parse(txtLowlimit.Text.Trim());
                model.Highlimit = double.Parse(txtHighlimit.Text.Trim());
                model.Lololimit = double.Parse(txtLololimit.Text.Trim());
                model.Hihilimit = double.Parse(txtHihilimit.Text.Trim());
                model.ValueInOrOut = drp_ValueInOut.SelectedText;
                model.OrderId = Int32.Parse(txt_Order.Text.Trim());
                model.IsAlert = rbtnIsAlertTrue.Checked ? "是" : "否";
                model.IsCollect = rbtnIsCollectTrue.Checked ? "是" : "否";
                model.ParentId = 0;
                model.UpdateFlag = 1;
                model.IsShow = rbtnIsShowTrue.Checked ? "是" : "否";
                model.FieldType = drp_FieldType.Text;
                if (model.FieldName.StartsWith("DI"))
                {
                    model.KeyValues = string.Format("1={0};0={1};", txtDi1.Text.Trim(), txtDi0.Text.Trim());
                }
                else if (model.FieldName.EndsWith("TC"))
                {
                    model.KeyValues = string.Format("1={0};0={1};", txtJC1.Text.Trim(), txtJC0.Text.Trim());
                }
                else
                {
                    model.KeyValues = "";
                }
                if (!models.Any(p => p.FieldName == model.FieldName))
                {
                    models.Add(model);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
            }
        }
        /// <summary>
        /// 删除DataGridView选中行的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            BindingList<DTUFieldDesc> models = dgvField.DataSource as BindingList<DTUFieldDesc>;
            for (int i = dgvField.SelectedRows.Count; i > 0; i--)
            {
                models.RemoveAt(dgvField.SelectedRows[i - 1].Index);
            }
            ClearForm();
        }
        /// <summary>
        /// 获取文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.RestoreDirectory = true;
            opd.Filter = "Excel(2003)文件|*.xls|Excel(2007)文件|*.xlsx|所有文件|*.*";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = opd.FileName;
            }
        }
        /// <summary>
        /// 导入Excel的数据到DataGridView(dgvField)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                try
                {
                    DataTable dtField = ExcelHelper.GetExcelDataToDataTable(txtFilePath.Text.Trim());
                    string valiResult = ValidateImport(dtField);
                    if (!string.IsNullOrEmpty(valiResult))
                    {
                        MessageUtil.ShowWarning(valiResult);
                        return;
                    }
                    BindingList<DTUFieldDesc> newModels = dgvField.DataSource == null ? new BindingList<DTUFieldDesc>() : dgvField.DataSource as BindingList<DTUFieldDesc>;
                    foreach (DataRow dtrow in dtField.Rows)
                    {
                        if (dtrow[0].ToString() != txtDtuid.Text.Trim())
                        {
                            MessageBox.Show("Excel中站点编号为" + dtrow[0].ToString() + "的数据不属于本站点字段!");
                            return;
                        }
                        DTUFieldDesc model = new DTUFieldDesc();
                        model.Dtuid = dtrow[0].ToString().Trim();
                        model.ColName = dtrow[1].ToString().Trim();
                        model.FieldName = dtrow[2].ToString().Trim();
                        model.FieldShortDesc = dtrow[3].ToString().Trim();
                        model.FieldDesc = dtrow[4].ToString().Trim();
                        model.FieldUnit = dtrow[5].ToString().Trim();
                        model.ValueMin = Convert.ToDouble(dtrow[6].ToString().Trim());
                        model.ValueMax = Convert.ToDouble(dtrow[7].ToString().Trim());
                        model.Lowlimit = Convert.ToDouble(dtrow[8].ToString().Trim());
                        model.Highlimit = Convert.ToDouble(dtrow[9].ToString().Trim());
                        model.Lololimit = Convert.ToDouble(dtrow[10].ToString().Trim());
                        model.Hihilimit = Convert.ToDouble(dtrow[11].ToString().Trim());
                        model.ValueInOrOut = dtrow[12].ToString().Trim();
                        model.IsAlert = dtrow[13].ToString().Trim();
                        model.IsCollect = dtrow[14].ToString().Trim();
                        model.IsShow = dtrow[15].ToString().Trim();
                        model.KeyValues = dtrow[16] == null ? "" : dtrow[16].ToString().Trim();
                        model.OrderId = Convert.ToInt32(dtrow[17].ToString().Trim());
                        model.FieldType = dtrow[18].ToString().Trim();
                        model.ParentId = 0;
                        model.UpdateFlag = 1;
                        if (!newModels.Any(p => p.FieldName == model.FieldName))
                        {
                            newModels.Add(model);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                    MessageBox.Show("导入站点字段时出错:" + ex.Message);
                }
            }
        }
        /// <summary>
        /// 模板下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkTemplateDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = fbd.SelectedPath + "\\字段导入模板.xls";
                    string fileTemplatePath = AppDomain.CurrentDomain.BaseDirectory + "字段导入模板.xls";
                    if (FileHelper.CopyFile(fileTemplatePath, filePath))
                    {
                        MessageUtil.ShowTips("下载成功!");
                    }
                    else
                    {
                        MessageUtil.ShowTips("下载失败:文件不存在!");
                    }
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(LocalIP, CurUser, ex);
                    MessageBox.Show("下载失败！" + ex.ToString());
                }
            }
        }

        private void FrmDtuField_Load(object sender, EventArgs e)
        {
            this.drp_ValueInOut.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取字段名称
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        private string GetFieldName(int Index, string fieldType)
        {
            string rslt = string.Empty;
            switch (fieldType)
            {
                case "QB":
                case "Q":
                case "VB":
                case "V":
                case "P":
                case "T":
                case "QBC":
                case "QC":
                case "VBC":
                case "VC":
                case "PC":
                case "TC":
                    rslt = "M" + Index + fieldType;
                    break;
                case "AI":
                case "DI":
                case "AO":
                case "BO":
                    rslt = fieldType + Index;
                    break;
                default:
                    rslt = fieldType + Index;
                    break;
            }
            return rslt;
        }

        private void drp_FieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDI.Visible = false;
            txtDi0.Visible = false;
            txtDi1.Visible = false;
            label3.Visible = false;
            lblJc.Visible = false;
            txtJC0.Visible = false;
            txtJC1.Visible = false;
            label5.Visible = false;
            int idx = Convert.ToInt32(this.drp_Index.Value);
            this.drp_ValueInOut.SelectedIndex = 0;
            switch (drp_FieldName.Text.Trim())
            {
                case "AO":
                    this.txtFieldUnit.Text = "罐";
                    this.txtFieldShortDesc.Text = "累计加臭罐数" + idx;
                    this.txtFieldDesc.Text = "面板1-N累计加臭罐数";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "BO":
                    this.txtFieldUnit.Text = "个";
                    this.txtFieldShortDesc.Text = "加注头个数" + idx;
                    this.txtFieldDesc.Text = "面板1-N加注头个数";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "QB":
                    this.txtFieldUnit.Text = "Nm3/h";
                    this.txtFieldShortDesc.Text = "标况瞬时流量" + idx;
                    this.txtFieldDesc.Text = "去/至_____标况瞬时流量";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "QBC":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "臭液标况瞬时流量" + idx;
                    this.txtFieldDesc.Text = "去/至_____臭液标况瞬时流量";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "Q":
                    this.txtFieldUnit.Text = "Nm3/h";
                    this.txtFieldShortDesc.Text = "工况瞬时流量" + idx;
                    this.txtFieldDesc.Text = "去/至_____工况瞬时流量";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "QC":
                    this.txtFieldUnit.Text = "mg/Nm3";
                    this.txtFieldShortDesc.Text = "臭液瞬时浓度" + idx;
                    this.txtFieldDesc.Text = "去/至_____臭液瞬时浓度";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "VB":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "标况流量累计" + idx;
                    this.txtFieldDesc.Text = "去/至_____标况流量累计";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "VBC":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "臭液标况流量累计" + idx;
                    this.txtFieldDesc.Text = "去/至_____臭液标况流量累计";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "VC":
                    this.txtFieldUnit.Text = "g";
                    this.txtFieldShortDesc.Text = "累计加臭量" + idx;
                    this.txtFieldDesc.Text = "去/至_____累计加臭量";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "V":
                    this.txtFieldUnit.Text = "Nm3";
                    this.txtFieldShortDesc.Text = "工况流量累计" + idx;
                    this.txtFieldDesc.Text = "去/至_____工况流量累计";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "P":
                    this.txtFieldUnit.Text = "Kpa";
                    this.txtFieldShortDesc.Text = "流量计压力" + idx;
                    this.txtFieldDesc.Text = "去/至_____流量计压力";
                    this.drp_ValueInOut.Enabled = true;
                    this.drp_ValueInOut.SelectedIndex = 1;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "PC":
                    this.txtFieldUnit.Text = "次";
                    this.txtFieldShortDesc.Text = "加注阀动作次数" + idx;
                    this.txtFieldDesc.Text = "加注阀动作次数";
                    this.drp_ValueInOut.Enabled = true;
                    this.drp_ValueInOut.SelectedIndex = 1;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "T":
                    this.txtFieldUnit.Text = "℃";
                    this.txtFieldShortDesc.Text = "管内温度" + idx;
                    this.txtFieldDesc.Text = "去/至_____管内温度";
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "AI":
                    this.txtFieldUnit.Text = "";
                    this.txtFieldUnit.Enabled = true;
                    this.drp_ValueInOut.Enabled = true;
                    this.drp_ValueInOut.SelectedIndex = 1;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
                case "DI":
                    this.txtFieldUnit.Text = "";
                    this.txtFieldShortDesc.Text = "";
                    this.txtFieldDesc.Text = "";
                    this.txtFieldUnit.Enabled = true;
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    lblDI.Visible = true;
                    txtDi0.Visible = true;
                    txtDi1.Visible = true;
                    label3.Visible = true;
                    break;
                case "TC":
                    this.txtFieldUnit.Text = "";
                    this.txtFieldShortDesc.Text = "加臭模式" + idx;
                    this.txtFieldDesc.Text = "加臭模式" + idx;
                    this.txtFieldUnit.Enabled = true;
                    this.drp_ValueInOut.Enabled = false;
                    this.txtFieldShortDesc.Enabled = true;
                    lblJc.Visible = true;
                    txtJC0.Visible = true;
                    txtJC1.Visible = true;
                    label5.Visible = true;
                    break;
                default:
                    this.txtFieldUnit.Text = "";
                    this.drp_ValueInOut.Enabled = true;
                    this.txtFieldShortDesc.Enabled = true;
                    break;
            }
        }

        private void dgvField_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            drp_FieldName.Enabled = false;
            drp_Index.Enabled = false;
            txtDtuid.Enabled = false;
            curModel = dgvField.SelectedRows[0].DataBoundItem as DTUFieldDesc;
            txtDtuid.Text = curModel.Dtuid;

            string tmp = curModel.FieldName;
            System.Text.RegularExpressions.Match mstr = System.Text.RegularExpressions.Regex.Match(tmp, @"[\d]+");
            string idx = mstr.Groups[0].Value;
            drp_Index.Value = Convert.ToInt32(idx);
            if (tmp.StartsWith("M"))
                drp_FieldName.SelectedItem = tmp.Substring(tmp.IndexOf(idx) + idx.Length);
            else
                drp_FieldName.SelectedItem = tmp.Substring(0, 2);
            txtFieldUnit.Text = curModel.FieldUnit;
            txtFieldShortDesc.Text = curModel.FieldShortDesc;
            txtFieldDesc.Text = curModel.FieldDesc;
            txtValueMin.Text = curModel.ValueMin.ToString();
            txtValueMax.Text = curModel.ValueMax.ToString();
            txtLowlimit.Text = curModel.Lowlimit.ToString();
            txtHighlimit.Text = curModel.Highlimit.ToString();
            txtLololimit.Text = curModel.Lololimit.ToString();
            txtHihilimit.Text = curModel.Hihilimit.ToString();
            txt_Order.Text = curModel.OrderId.ToString();
            switch (curModel.ValueInOrOut)
            {
                case "不分进出口":
                    drp_ValueInOut.SelectedIndex = 0;
                    break;
                case "进":
                    drp_ValueInOut.SelectedIndex = 1;
                    break;
                case "出":
                    drp_ValueInOut.SelectedIndex = 2;
                    break;
                default:
                    drp_ValueInOut.SelectedIndex = 0;
                    break;
            }

            if (curModel.IsAlert == "是")
                rbtnIsAlertTrue.Checked = true;
            else
                rbtnIsAlertFalse.Checked = true;
            if (curModel.IsCollect == "是")
                rbtnIsCollectTrue.Checked = true;
            else
                rbtnIsCollectFalse.Checked = true;
            if (curModel.IsShow == "是")
                rbtnIsShowTrue.Checked = true;
            else
                rbtnIsShowFalse.Checked = true;
            if (curModel.FieldName.StartsWith("DI"))
            {
                NameValueCollection nv = ToolHelper.ParseAtts(curModel.KeyValues);
                txtDi1.Visible = true;
                txtDi0.Visible = true;
                lblDI.Visible = true;
                label3.Visible = true;
                txtDi1.Text = nv["1"];
                txtDi0.Text = nv["0"];
            }
            if (curModel.FieldName.EndsWith("TC"))
            {
                NameValueCollection nv = ToolHelper.ParseAtts(curModel.KeyValues);
                txtJC1.Visible = true;
                txtJC0.Visible = true;
                lblJc.Visible = true;
                label5.Visible = true;
                txtJC0.Text = nv["0"];
                txtJC1.Text = nv["1"];
            }
            switch (curModel.FieldType)
            {
                case "不统计":
                    drp_FieldType.SelectedIndex = 0;
                    break;
                case "累计":
                    drp_FieldType.SelectedIndex = 1;
                    break;
                case "示数":
                    drp_FieldType.SelectedIndex = 2;
                    break;
                case "平均":
                    drp_FieldType.SelectedIndex = 3;
                    break;
                default:
                    drp_FieldType.SelectedIndex = 0;
                    break;
            }
            btnAdd.Enabled = false;
            btnMod.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = true;
            btnImport.Enabled = false;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            string valiResult = ValidateInput();
            if (!string.IsNullOrEmpty(valiResult))
            {
                MessageUtil.ShowWarning(valiResult);
                return;
            }

            string filedName = GetFieldName(Convert.ToInt32(drp_Index.Value), drp_FieldName.Text.Trim());
           
            curModel.Dtuid = txtDtuid.Text.Trim();
            curModel.ColName = "OPC_WINFO";
            curModel.FieldName = filedName;
            curModel.FieldShortDesc = txtFieldShortDesc.Text.Trim();
            curModel.FieldDesc = txtFieldDesc.Text.Trim();
            curModel.FieldUnit = txtFieldUnit.Text.Trim();
            curModel.ValueMin = double.Parse(txtValueMin.Text.Trim());
            curModel.ValueMax = double.Parse(txtValueMax.Text.Trim());
            curModel.Lowlimit = double.Parse(txtLowlimit.Text.Trim());
            curModel.Highlimit = double.Parse(txtHighlimit.Text.Trim());
            curModel.Lololimit = double.Parse(txtLololimit.Text.Trim());
            curModel.Hihilimit = double.Parse(txtHihilimit.Text.Trim());
            curModel.ValueInOrOut = drp_ValueInOut.SelectedText;
            curModel.OrderId = Int32.Parse(txt_Order.Text.Trim());
            curModel.IsAlert = rbtnIsAlertTrue.Checked ? "是" : "否";
            curModel.IsCollect = rbtnIsCollectTrue.Checked ? "是" : "否";
            curModel.ParentId = 0;
            curModel.UpdateFlag = 1;
            curModel.IsShow = rbtnIsShowTrue.Checked ? "是" : "否";
            curModel.FieldType = drp_FieldType.Text;
            if (curModel.FieldName.StartsWith("DI"))
            {
                curModel.KeyValues = string.Format("1={0};0={1};", txtDi1.Text.Trim(), txtDi0.Text.Trim());
            }
            else if (curModel.FieldName.EndsWith("TC"))
            {
                curModel.KeyValues = string.Format("1={0};0={1};", txtJC1.Text.Trim(), txtJC0.Text.Trim());
            }
            else
            {
                curModel.KeyValues = "";
            }
            dgvField.Refresh();
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            drp_Index.Value = 1;
            drp_FieldName.SelectedIndex = 0;
            txtFieldUnit.Text = "Nm3/h";
            txtJC1.Visible = false;
            txtJC0.Visible = false;
            lblJc.Visible = false;
            label5.Visible = false;
            txtDi1.Visible = false;
            txtDi0.Visible = false;
            lblDI.Visible = false;
            label3.Visible = false;
            txt_Order.Text = "0";
            txtValueMin.Text = "0";
            txtValueMax.Text = "1000";
            txtLowlimit.Text = "-1";
            txtHighlimit.Text = "9999999999999";
            txtLololimit.Text = "-1";
            txtHihilimit.Text = "9999999999999";
            drp_ValueInOut.SelectedIndex = 0;
            rbtnIsAlertFalse.Checked = true;
            rbtnIsShowTrue.Checked = true;
            rbtnIsCollectTrue.Checked = true;
            txtFieldShortDesc.Enabled = true;
            txtFieldUnit.Enabled = false;
            btnAdd.Enabled = true;
            btnMod.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnImport.Enabled = true;
        }
        #region 输入验证
        private string ValidateInput()
        {
            if (string.IsNullOrEmpty(txtDtuid.Text))
                return "站点编号不能为空!";

            if (string.IsNullOrEmpty(txtFieldShortDesc.Text))
                return "字段短描述不能为空!";

            if (string.IsNullOrEmpty(txtFieldDesc.Text))
                return "字段描述不能为空!";

            if (!ToolHelper.IsNumberSign(txtValueMin.Text))
                return "字段最小值必须为数字!";

            if (!ToolHelper.IsNumber(txtValueMax.Text))
                return "字段最大值必须为数字!";

            if (double.Parse(txtValueMax.Text.Trim()) < double.Parse(txtValueMin.Text.Trim()))
                return "字段最大值必须大于字段最小值!";

            if (!ToolHelper.IsNumberSign(txtLowlimit.Text))
                return "字段低报警值必须为数字!";

            if (!ToolHelper.IsNumber(txtHighlimit.Text))
                return "字段高报警值必须为数字!";

            if (double.Parse(txtHighlimit.Text.Trim()) < double.Parse(txtLowlimit.Text.Trim()))
                return "字段高报警值必须大于字段低报警值!";

            if (!ToolHelper.IsNumberSign(txtLololimit.Text))
                return "字段最低报警值必须为数字!";

            if (!ToolHelper.IsNumber(txtHihilimit.Text))
                return "字段最高报警值必须为数字!";

            if (double.Parse(txtHihilimit.Text.Trim()) < double.Parse(txtLololimit.Text.Trim()))
                return "字段最高报警值必须大于字段最低报警值!";

            if (double.Parse(txtHihilimit.Text.Trim()) < double.Parse(txtHighlimit.Text.Trim()))
                return "字段最高报警值必须大于字段高报警值!";

            if (double.Parse(txtLololimit.Text.Trim()) > double.Parse(txtLowlimit.Text.Trim()))
                return "字段最低报警值必须小于字段低报警值!";

            if (!ToolHelper.IsNumber(txt_Order.Text))
                return "字段排序序号必须为数字!";

            return string.Empty;
        }

        private string ValidateImport(DataTable dtFields)
        {
            if (dtFields.Rows.Count == 0)
                return "没有查到任何数据!";
            foreach (DataRow item in dtFields.Rows)
            {
                if (item[0].ToString().Trim() != txtDtuid.Text.Trim())
                    return "Excel中站点编号为" + item[0].ToString() + "的数据不属于本站点字段!";

                if (string.IsNullOrEmpty(item[1].ToString().Trim()))
                    return "字段采集名称不能为空!";

                if (string.IsNullOrEmpty(item[2].ToString().Trim()))
                    return "字段名称不能为空!";

                if (string.IsNullOrEmpty(item[3].ToString().Trim()))
                    return "字段短描述不能为空!";

                if (string.IsNullOrEmpty(item[4].ToString().Trim()))
                    return "字段描述不能为空!";

                if (!ToolHelper.IsNumberSign(item[6].ToString().Trim()))
                    return "字段最小值必须为数字!";

                if (!ToolHelper.IsNumber(item[7].ToString().Trim()))
                    return "字段最大值必须为数字!";

                if (double.Parse(item[7].ToString().Trim()) < double.Parse(item[6].ToString().Trim()))
                    return "字段最大值必须大于字段最小值!";

                if (!ToolHelper.IsNumberSign(item[8].ToString().Trim()))
                    return "字段低报警值必须为数字!";

                if (!ToolHelper.IsNumber(item[9].ToString().Trim()))
                    return "字段高报警值必须为数字!";

                if (double.Parse(item[9].ToString().Trim()) < double.Parse(item[8].ToString().Trim()))
                    return "字段高报警值必须大于字段低报警值!";

                if (!ToolHelper.IsNumberSign(item[10].ToString().Trim()))
                    return "字段最低报警值必须为数字!";

                if (!ToolHelper.IsNumber(item[11].ToString().Trim()))
                    return "字段最高报警值必须为数字!";

                if (double.Parse(item[11].ToString().Trim()) < double.Parse(item[10].ToString().Trim()))
                    return "字段最高报警值必须大于字段最低报警值!";

                if (double.Parse(item[11].ToString().Trim()) < double.Parse(item[9].ToString().Trim()))
                    return "字段最高报警值必须大于字段高报警值!";

                if (double.Parse(item[10].ToString().Trim()) > double.Parse(item[8].ToString().Trim()))
                    return "字段最低报警值必须小于字段低报警值!";

                if (!ToolHelper.IsNumber(item[17].ToString().Trim()))
                    return "字段排序序号必须为数字!";

            }
            return string.Empty;
        }
        #endregion
    }
}
