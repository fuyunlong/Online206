using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Proxy;
 
namespace WinfoToolSys.Controllers.SiteMng
{
    public class OutPutChaController : Controller
    {
        //
        // GET: /OutPutCha/

        public ActionResult Index()
        {
            ViewBag.CompanyList = ServcieTool.CrmServiceGetInstance.GetCompanyLists("", "", PmsMng.ActiveKey);
           
            return View();
        }

    }
}
