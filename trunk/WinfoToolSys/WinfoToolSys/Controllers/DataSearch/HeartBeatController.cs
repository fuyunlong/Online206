using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Com.Winfotian.Proxy;
using Com.Winfotian.ServiceProxy;
using Proxy;
using Proxy.ServiceWinToolRead;
using WinfoToolSys.Pms;

namespace WinfoToolSys.Controllers.DataSearch
{
    public class HeartBeatController : Controller
    {
        //心跳记录查询
        public ActionResult Index()
        {
            return View();
        }

        //根据站点查询心跳记录
        public JsonResult GetBeatRecordListByDTUId(string dtuId, DateTime date)
        {
            List<string> list = new List<string>();
            try
            {
                if (PmsMng.CompanyId != 12)
                {
                    //当前用户可以访问的站点
                    List<string> dtuIds = DataPermission.PermisSites(PmsMng.LogUser);
                    if (dtuIds.Contains(dtuId))
                    {
                        list = CommonServiceProxy.GetBeatRecordList(WinManager.GetPublicIP(), dtuId, date);
                    }
                }
                else
                {
                    list = CommonServiceProxy.GetBeatRecordList(WinManager.GetPublicIP(), dtuId, date);
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
