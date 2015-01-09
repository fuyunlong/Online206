﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using WinfoToolSys.Pms;
using System.Web.Script.Serialization;
using Proxy;
using System.Text;
using Proxy.ServiceWinToolWrite;

namespace WinfoToolSys.Controllers.SiteMng
{
    public class ValveInfluenceController : Controller
    {
        //阀门影响配置
        public ActionResult Index()
        {
            return View();
        }

        //获取阀门影响列表
        public JsonResult GetInfluencList(string siteId)
        {
            List<Proxy.ServiceWinToolRead.T_DTU_ValveEffect> list = new List<Proxy.ServiceWinToolRead.T_DTU_ValveEffect>();
            try
            {
                list = ServcieTool.WinToolServiceReadInstance.GetInfluencList(PmsMng.ActiveKey, siteId);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //详细、修改、添加
        public ActionResult ShowDetail(string oper, string valveCode)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.ServiceWinToolRead.T_DTU_ValveEffectEx model = null;
            switch (oper)
            {
                case "Show":
                    ViewBag.Oper = "Show";
                    break;
                case "Edit":
                    ViewBag.Oper = "Edit";
                    sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='ValueEffect.Update();' />");
                    break;
                case "Add":
                    ViewBag.Oper = "Add";
                    sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='ValueEffect.Add();' />");
                    break;
                default:
                    break;
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();
            try
            {
                model = ServcieTool.WinToolServiceReadInstance.GetInfluencByCode(PmsMng.ActiveKey, valveCode);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return View(model);
        }

        //添加
        public string Add(T_DTU_ValveEffect model)
        {
            string result = "false";
            string valveCode = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;

            T_DTU_ValveEffect effect = new T_DTU_ValveEffect();
            effect.ValveCode = valveCode;
            effect.ClosedTime = model.ClosedTime;
            effect.EffctArea = model.EffctArea == null ? "" : model.EffctArea;
            effect.EffctUserNum = model.EffctUserNum;
            effect.ValveName = model.ValveName;
            effect.Dtuid = model.Dtuid;

            try
            {
                if (ServcieTool.WinToolServiceWriteInstance.AddInfluence(PmsMng.ActiveKey, effect))
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
        public string Update(T_DTU_ValveEffect model)
        {
            string result = "false";

            T_DTU_ValveEffect effect = new T_DTU_ValveEffect();
            effect.ValveCode = model.ValveCode;
            effect.ClosedTime = model.ClosedTime;
            effect.EffctArea = model.EffctArea == null ? "" : model.EffctArea;
            effect.EffctUserNum = model.EffctUserNum;
            effect.ValveName = model.ValveName;
            effect.Dtuid = model.Dtuid;

            try
            {
                if (DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.UpdateInfluence(PmsMng.ActiveKey, effect))
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
        public string Delete(string valveCode)
        {
            string result = "false";
            try
            {
                if (DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.DeleteInfluence(PmsMng.ActiveKey, valveCode))
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