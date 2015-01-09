using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Proxy;
using Com.Winfotian.DB;
using Com.Winfotian.Common;
using System.IO;
using System.Text;
using Com.Winfotian.DB.Provider;
using Com.Winfotian.Model;
namespace WinfoToolSys.Controllers.SiteMng
{
    public class FieldPowerController : Controller
    {
        //字段管理（加强）
        public ActionResult Index()
        {
            return View();
        }

        //上传
        [HttpPost]
        public JsonResult UpLoadFile()
        {
            List<Proxy.ServiceWinToolWrite.T_DTU_FieldDesc> list = new List<Proxy.ServiceWinToolWrite.T_DTU_FieldDesc>();
            try
            {
                if (Request.Files["iconImg"] != null)
                {
                    HttpPostedFileBase file = Request.Files["iconImg"];
                    string path = ToolHelper.ApplicationPath;
                    if (!Directory.Exists(path + "File"))
                    {
                        Directory.CreateDirectory(path + "File");
                    }
                    if (!System.IO.File.Exists(path + "File" + "\\字段导入模板.xls"))
                    {
                        System.IO.File.Create(path + "File" + "\\字段导入模板.xls").Close();
                    }
                    var bts = new byte[file.InputStream.Length];
                    file.InputStream.Read(bts, 0, Convert.ToInt32(file.InputStream.Length));
                    file.InputStream.Close();
                    using (System.IO.FileStream fs = new System.IO.FileStream((path + "File" + "\\字段导入模板.xls"), FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                    {
                        fs.Write(bts, 0, bts.Length);
                    }
                    System.Data.DataTable dt = ExcelHelper.GetExcelDataToDataTable((path + "File" + "\\字段导入模板.xls"));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var model = new Proxy.ServiceWinToolWrite.T_DTU_FieldDesc()
                           {
                               Dtuid = dt.Rows[i]["站点编号"].ToString(),
                               ColName = dt.Rows[i]["字段采集名称"].ToString(),
                               FieldName = dt.Rows[i]["字段名称"].ToString(),
                               FieldUnit = dt.Rows[i]["字段单位"].ToString(),
                               ValueMin = decimal.Parse(dt.Rows[i]["字段最小值"].ToString()),
                               ValueMax = decimal.Parse(dt.Rows[i]["字段最大值"].ToString()),
                               Lowlimit = decimal.Parse(dt.Rows[i]["字段低报警值"].ToString()),
                               Highlimit = decimal.Parse(dt.Rows[i]["字段高报警值"].ToString()),
                               Lololimit = decimal.Parse(dt.Rows[i]["字段最低报警值"].ToString()),
                               Hihilimit = decimal.Parse(dt.Rows[i]["字段最高报警值"].ToString()),
                               FieldShortDesc = dt.Rows[i]["字段短描述"].ToString(),
                               FieldDesc = dt.Rows[i]["字段描述"].ToString(),
                               IsAlert = dt.Rows[i]["是否报警检查"].ToString() == "是" ? 1 : 0,
                               IsCollect = dt.Rows[i]["是否开启采集"].ToString() == "是" ? 1 : 0,
                               IsShow = dt.Rows[i]["是否显示"].ToString() == "是" ? 1 : 0,
                               KeyValues = dt.Rows[i]["开关定义"].ToString(),
                               OrderId = Convert.ToInt32(dt.Rows[i]["排序"].ToString()),
                               ParentId = 0,
                               UpdateFlag = 0
                           };
                            var ValueInOrOut = dt.Rows[i]["进出口类型"].ToString();
                            var FieldType = dt.Rows[i]["统计类型"].ToString();
                            if (ValueInOrOut == "进")
                            {
                                model.ValueInOrOut = 1;
                            }
                            else if (ValueInOrOut == "出")
                            { model.ValueInOrOut = 2; }
                            else
                            { model.ValueInOrOut = 0; }
                            if (FieldType == "不统计")
                            {
                                model.FieldType = 0;
                            }
                            else if (FieldType == "不统计")
                            { model.FieldType = 1; }
                            else if (FieldType == "示数")
                            { model.FieldType = 2; }
                            else if (FieldType == "平均")
                            { model.FieldType = 3; }
                            model.IsAlert = 0;
                            model.IsCollect = 0;
                            model.IsShow = 0;
                            model.OrderId = 0;
                            model.FieldType = 0;
                            list.Add(model);

                        }
                        if (list.Count > 0)
                        {

                            ServcieTool.WinToolServiceWriteInstance.AddDtuFiledDescBatch(PmsMng.ActiveKey, PmsMng.LogUser, list);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }
    }
}
