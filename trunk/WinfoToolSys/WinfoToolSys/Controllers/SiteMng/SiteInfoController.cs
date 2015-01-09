﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Com.Winfotian.Model;
using Com.Winfotian.DB;
using Com.Winfotian.Common;
using Proxy;
namespace WinfoToolSys.Controllers.SiteMng
{
    public class SiteInfoController : Controller
    {
        //
        // GET: /SiteInfo/

        public SiteInfoController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.ddlCompany = new HtmlCommon().GetCompanyList();
            return View();
        }

        //获取单个站点对象
        public JsonResult GetSiteInfo(string id)
        {
            Proxy.ServiceWinToolRead.T_Dtu_Ex site = null;
            site = ServcieTool.WinToolServiceReadInstance.GetSiteById(PmsMng.ActiveKey, id);
            return Json(site);
        }

        //获取站点列表
        public JsonResult GetSite(string Company, string Group, string SiteName)
        {
            var ShowList = new List<Proxy.ServiceWinToolRead.T_Dtu_Ex>();
            try
            {
                var list = ServcieTool.WinToolServiceReadInstance.GetSite("", Company, Group, SiteName, false);
                if (PmsMng.CompanyId != 12)
                {
                    var PerList = DataPermission.PermisSites(PmsMng.LogUser);
                    foreach (var a in list)
                    {
                        if (PerList.Contains(a.Dtuid))
                        {
                            ShowList.Add(a);
                        }
                    }
                }
                else
                {
                    ShowList = list;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(ShowList);
        }

        //获取站点详细
        public ActionResult SiteDetail(string OperRation, string DtuId)
        {

            if (OperRation == "Show")
                ViewBag.OperAreaText = "";
            else
                ViewBag.OperAreaText = "<input type='button' class='buttonVer2' value='修改' onclick='SiteMng.UpdateSiteInfo()' />";
            ViewBag.dtuid = DtuId;
            return View();
        }

        //获取终端类型列表
        public ActionResult GetVerTypeList()
        {
            Dictionary<string, string> dic = ServcieTool.WinToolServiceReadInstance.GetVerList(PmsMng.ActiveKey);
            List<object> list = new List<object>();
            foreach (var a in dic)
            {
                list.Add(new { key = a.Key, value = a.Value });
            }
            return Json(list);
        }

        //获取压力等级列表
        public ActionResult PressureLevelList()
        {
            return Json(ServcieTool.WinToolServiceReadInstance.GetPressureLevelList(PmsMng.ActiveKey, ""));
        }

        //获取配置列表 
        public JsonResult DtuConfigList()
        {
            return Json(ServcieTool.WinToolServiceReadInstance.DtuConfigListV2(PmsMng.ActiveKey));
        }

        //打开分组树
        public string OpenGroupTree()
        {
            StringBuilder Str = new StringBuilder();
            Str.Append("  [");
            Str.Append("{ text: '节点1', children: [");
            Str.Append("    { text: '节点1.1' },");
            Str.Append("    { text: '节点1.2' },");
            Str.Append("  { text: '节点1.3', children: [");
            Str.Append("        { text: '节点1.3.1' ,children: [");
            Str.Append("			{ text: '节点1.3.1.1' },");
            Str.Append("			{ text: '节点1.3.1.2' }]");
            Str.Append("		},");
            Str.Append("     { text: '节点1.3.2' }");
            Str.Append(" ]");
            Str.Append("  },");
            Str.Append("  { text: '节点1.4' }");
            Str.Append("  ]");
            Str.Append("  },");
            Str.Append(" { text: '节点2' },");
            Str.Append(" { text: '节点3' },");
            Str.Append(" { text: '节点4' }");
            Str.Append("]");
            return Str.ToString();
        }

        public ActionResult AddSite(string companyId)
        {
            ViewBag.VerType = new HtmlCommon().GetVerTypeList();
            ViewBag.ddlCompany = new HtmlCommon().GetCompanyList(companyId == "-1" ? "" : companyId);
            ViewBag.PressureLevel = new HtmlCommon().GetPressureLevelList();
            ViewBag.DtuConfig = new HtmlCommon().GetDtuConfigList();
            return View();
        }
        //添加站点
        public string AddSiteOper(T_Dtu_Ex dtuex)
        {
            string rlst = "0";
            try
            {
                List<string> list = Com.Winfotian.ServiceProxy.DTUServiceProxy.GenerateDtuidList(WinManager.GetPublicIP(), dtuex.CompanyId, 1);
                if (list.Count > 0)
                {
                    Proxy.ServiceWinToolWrite.T_DTU dtu = new Proxy.ServiceWinToolWrite.T_DTU();
                    #region
                    dtu.Dtuid = list[0];
                    dtu.ConfigCode = dtuex.ConfigCode;
                    dtu.DataInterval = dtuex.DataInterval;
                    dtu.DayFrom = dtuex.DayFrom;
                    dtu.DtuidLocation = dtuex.DtuidLocation;
                    dtu.DtuidName = dtuex.DtuidName;
                    dtu.FlowBrand = dtuex.FlowBrand;
                    dtu.FlowType = dtuex.FlowType;
                    dtu.GroupCode = dtuex.GroupCode;
                    dtu.Latitude = dtuex.Latitude;
                    dtu.LgPwd = dtuex.LgPwd;
                    dtu.Longitude = dtuex.Longitude;
                    dtu.MonthFrom = dtuex.MonthFrom;
                    dtu.OrderId = dtuex.OrderId;
                    dtu.PhoneNum = dtuex.PhoneNum;
                    dtu.PressureLevel = dtuex.PressureLevel;
                    dtu.ProtocolVersion = dtuex.ProtocolVersion;
                    dtu.RegDate = dtuex.RegDate;
                    dtu.RunDate = dtuex.RunDate;
                    dtu.Skidbrand = dtuex.Skidbrand;
                    dtu.Status = 1;
                    dtu.Supplier = dtuex.Supplier;
                    dtu.UpdateFlag = 1;
                    dtu.UpLoadInterval = dtuex.UpLoadInterval;
                    #endregion
                    if (ServcieTool.WinToolServiceWriteInstance.AddSite(PmsMng.ActiveKey, PmsMng.LogUser, dtu))
                    {
                        //站点添加成功后，需要配置当前用户拥有该站点的权限
                        ServcieTool.WinToolServiceWriteInstance.AddUserUserDtuid(PmsMng.ActiveKey, PmsMng.LogUser, PmsMng.LogUser, new List<Proxy.ServiceWinToolWrite.T_User_UserDtuid> { new Proxy.ServiceWinToolWrite.T_User_UserDtuid { Dtuid = dtu.Dtuid, UserId = PmsMng.LogUser, Status = 1 } });
                        rlst = dtu.Dtuid;
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);

            }
            return rlst;
        }

        public ActionResult ShowSite()
        {
            ViewBag.CompanyList = ServcieTool.CrmServiceGetInstance.GetCompanyLists("", "", PmsMng.ActiveKey);
            ViewBag.DtuConfigList = ServcieTool.WinToolServiceReadInstance.DtuConfigListV2(PmsMng.ActiveKey);
            ViewBag.VerList = ServcieTool.WinToolServiceReadInstance.GetVerList(PmsMng.ActiveKey);
            ViewBag.PressureLevelList = ServcieTool.WinToolServiceReadInstance.GetPressureLevelList(PmsMng.ActiveKey, "");
            return View();
        }

        public string UpdateSite(Proxy.ServiceWinToolWrite.T_DTU dtu)
        {
            string rlst = "修改失败";
            try
            {
                if (string.IsNullOrWhiteSpace(dtu.DtuidLocation))
                {
                    dtu.DtuidLocation = "四川省成都市青羊区XX街";
                }
                if (string.IsNullOrWhiteSpace(dtu.Skidbrand))
                {
                    dtu.Skidbrand = "苍南/天信";
                }
                if (string.IsNullOrWhiteSpace(dtu.FlowBrand))
                { dtu.FlowBrand = "Joyu/Winfo"; }
                if (string.IsNullOrWhiteSpace(dtu.FlowType))
                {
                    dtu.FlowType = "Winfo-001";
                }
                if (string.IsNullOrWhiteSpace(dtu.Supplier))
                {
                    dtu.Supplier = "久宇/英菲信";
                }
                dtu.Status = 1;
                if (DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.UpdateSite(PmsMng.ActiveKey, PmsMng.LogUser, dtu))
                    {
                        rlst = "ok";
                    }
                }
                else
                {
                    rlst = "4";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);

            }
            return rlst;
        }

        /// <summary>
        /// 删除站点
        /// </summary>
        /// <param name="id">Dtuid</param>
        /// <returns></returns>
        public int DeleteSite(string id)
        {
            int rlst = 0;
            try
            {
                if (DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.DeleteSite(PmsMng.ActiveKey, id, PmsMng.LogUser))
                    {
                        rlst = 1;
                    }
                }
                else
                {
                    rlst = 4;//无权限
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rlst;
        }

        //根据公司获取站点列表
        public JsonResult GetSiteListByCompany(string Company)
        {
            List<T_DTU> DtuList = new List<T_DTU>();
            try
            {
                ServcieTool.WinToolServiceReadInstance.GetDTUListByCompanyId(PmsMng.ActiveKey, Company);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(DtuList);
        }
    }
}