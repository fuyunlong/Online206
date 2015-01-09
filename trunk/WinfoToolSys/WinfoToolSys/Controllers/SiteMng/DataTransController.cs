﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Proxy;
using Com.Winfotian.DB;
using Com.Winfotian.Common;


namespace WinfoToolSys.Controllers.SiteMng
{
    public class DataTransController : Controller
    {
        //
        // GET: /DataTrans/

        public ActionResult Index()
        {
            ViewBag.ddlCompany = new HtmlCommon().GetCompanyList();
            return View();
        }

        public ActionResult AddTrans()
        {
            ViewBag.ddlGroup = new HtmlCommon().GetDepartList(Convert.ToInt32(PmsMng.CompanyId));
            ViewBag.ddlCompany = new HtmlCommon().GetCompanyList();
            ViewBag.ddlDtu = new HtmlCommon().GetDtuList(PmsMng.CompanyId.ToString());
            return View();
        }

        public string AddTransOper(Proxy.ServiceWinToolWrite.T_DTU_DataTransmit model)
        {
            int rlst = 0;
            try
            {


                if (ServcieTool.WinToolServiceWriteInstance.AddTrans(PmsMng.ActiveKey, PmsMng.LogUser, model))
                {
                    rlst = 1;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rlst.ToString();
        }

        public JsonResult GetVerList()
        {
            List<Proxy.ServiceWinToolRead.T_DTU_DataTransmit> list = null;
            try
            {
                list = ServcieTool.WinToolServiceReadInstance.GetTransVerList(PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            if (list == null)
            {
                list = new List<Proxy.ServiceWinToolRead.T_DTU_DataTransmit>();
            }
            return Json(list);
        }

        public JsonResult GetTransSetList(string Company)
        {
            var list = ServcieTool.WinToolServiceReadInstance.GetTransSetList(PmsMng.ActiveKey, Company);
            return Json(list);
        }

        public ActionResult DataTransDetail(string Oper, string TransId)
        {
            ViewBag.TransObj = ServcieTool.WinToolServiceReadInstance.GetTransById(PmsMng.ActiveKey, TransId);
            if (Oper == "Show")
            {
                ViewBag.Oper = "";
            }
            else
            { ViewBag.Oper = "<input type='button' class='buttonVer2' value='修改' onclick='DataTrans.EditTrans()' />"; }
            return View();
        }

        public int DeleteTrans(string Id)
        {
            int rlst = 0;
            try
            {
                if (DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.DeleteTrans(PmsMng.ActiveKey, Id))
                    {
                        rlst = 1;
                        LogBLL.WriteOperatorLog(WinManager.GetPublicIP(), PmsMng.LogUser, "删除配置" + Id, 1);
                    }
                }
                else { rlst = 4; }

            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rlst;
        }

        public int EditTrans(Proxy.ServiceWinToolWrite.T_DTU_DataTransmit model)
        {
            int rslt = 0;
            try
            {
                if (DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.UpdateTrans(PmsMng.ActiveKey, PmsMng.LogUser, model))
                    {
                        rslt = 1;
                    }
                }
                else
                { rslt = 4; }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rslt;
        }
    }
}
