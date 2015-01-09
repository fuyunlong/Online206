﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Proxy;
using Proxy.ServiceWinToolWrite;
using System.Text;
using Com.Winfotian.DB;
using Com.Winfotian.Common;

namespace WinfoToolSys.Controllers.SiteMng
{
    public class SiteSetController : Controller
    {
        //站点配置管理
        public ActionResult Index()
        {
            return View();
        }

        //根据配置名称查询
        public JsonResult GetSiteSetList(string configName)
        {
            List<Proxy.ServiceWinToolRead.T_DTU_Config> list = new List<Proxy.ServiceWinToolRead.T_DTU_Config>();
            try
            {
                list = ServcieTool.WinToolServiceReadInstance.GetDTUConfigListByConfigName(PmsMng.ActiveKey, configName);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //添加、详细、修改
        public ActionResult ShowDetail(string oper, string configId)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.ServiceWinToolRead.T_DTU_Config model = null;
            switch (oper)
            {
                case "Show":
                    ViewBag.Oper = "Show";
                    break;
                case "Edit":
                    ViewBag.Oper = "Edit";
                    sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='SiteSet.Update();' />");
                    break;
                case "Add":
                    ViewBag.Oper = "Add";
                    sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='SiteSet.Add();' />");
                    break;
                default:
                    break;
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();
            try
            {
                model = ServcieTool.WinToolServiceReadInstance.GetDtuConfigByCode(PmsMng.ActiveKey, configId);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return View(model);
        }

        //添加
        public string Add(T_DTU_Config model)
        {
            string result = "false";
            Proxy.ServiceWinToolWrite.T_DTU_Config config = new Proxy.ServiceWinToolWrite.T_DTU_Config();
            string configCode = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            config.ConfigCode = configCode;
            config.ConfigName = model.ConfigName;
            config.ConfigDesc = model.ConfigDesc;
            config.FlowNum = model.FlowNum;
            config.AINum = model.AINum;
            config.DINum = model.DINum;
            config.IsAlert = model.IsAlert;
            config.IsCreate = model.IsCreate;
            config.Status = 1;
            config.UpdateFlag = 1;
            config.BoardInfo = string.Empty;
            config.CType = 0;

            try
            {
                if (ServcieTool.WinToolServiceWriteInstance.AddDtuConfig(PmsMng.ActiveKey, config))
                {
                    result = "true";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //修改
        public string Update(T_DTU_Config model)
        {
            string result = "false";
            T_DTU_Config config = new T_DTU_Config();
            config.ConfigCode = model.ConfigCode;
            config.ConfigName = model.ConfigName;
            config.ConfigDesc = model.ConfigDesc;
            config.FlowNum = model.FlowNum;
            config.AINum = model.AINum;
            config.DINum = model.DINum;
            config.IsAlert = model.IsAlert;
            config.IsCreate = model.IsCreate;
            config.Status = 1;
            config.UpdateFlag = 1;
            config.BoardInfo = string.Empty;
            config.CType = 0;

            try
            {
                if (DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.UpdateDtuConfig(PmsMng.ActiveKey, config))
                    {
                        result = "true";
                    }
                }
                else
                {
                    result = "4";
                }

            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //删除
        public string Delete(string configCode)
        {
            string result = "false";
            try
            {
                if (DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.DeleteDtuConfig("", configCode))
                    {
                        result = "true";
                    }
                }
                else
                {
                    result = "4";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }
    }
}
