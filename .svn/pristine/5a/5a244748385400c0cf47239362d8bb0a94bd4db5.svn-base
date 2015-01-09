using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Com.Winfotian.ServiceProxy;
using Proxy;
using WinfoToolSys.Pms;

namespace WinfoToolSys.Controllers.SiteMng
{
    public class SiteProblemController : Controller
    {
        //站点故障分析
        public ActionResult Index()
        {
            return View();
        }

        //获取电量
        public string GetPower(string siteId)
        {
            string result = string.Empty;
            Com.Winfotian.ServiceProxy.DataService.CSRealTimeDataInfoExt model = null;
            try
            {
                model = DataServiceProxy.GetRealTimeDataById(WinManager.GetPublicIP(), siteId);
                if (model != null)
                {
                    string data = model.DataContent;
                    string[] arr = data.Split(';');
                    foreach (var item in arr)
                    {
                        string[] temp = item.Split('=');
                        if (temp[0] == "Elec")
                        {
                            result = temp[1];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return result;
        }

        //获取最后一次心跳时间
        public string GetLastHeartRecord(string siteId)
        {
            string result = string.Empty;
            try
            {
                List<string> list = CommonServiceProxy.GetBeatRecordList(WinManager.GetPublicIP(), siteId, DateTime.Now);
                if (list.Count > 0)
                {
                    result = DateTime.Now + "," + list[0].Trim();
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return result;
        }

        //获取最新两条报警信息
        public JsonResult GetTop2AleartRecord(string siteId)
        {
            var list = new List<Proxy.ServiceWinToolRead.T_Alert_Info>();
            try
            {
                list = ServcieTool.WinToolServiceReadInstance.GetAlertListBySiteIdAndDate(Pms.PmsMng.ActiveKey, siteId, DateTime.Now.AddHours(-5), DateTime.Now);
                if (list.Count > 0)
                {
                    list = list.GetRange(0, 2);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //获取5条最新新原始数据
        public JsonResult GetTop5OriginalData(string siteId)
        {
            List<Com.Winfotian.ServiceProxy.DataService.T_DataRecord> list = new List<Com.Winfotian.ServiceProxy.DataService.T_DataRecord>();
            try
            {
                if (DataPermission.IsUserReadSiteOriginalData())
                {
                    list = DataServiceProxy.GetDataRecordListByTop(WinManager.GetPublicIP(), 5, siteId, 1);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return Json(list);
        }
    }
}
