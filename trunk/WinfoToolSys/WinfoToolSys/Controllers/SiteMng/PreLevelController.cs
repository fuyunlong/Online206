﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Proxy;
using System.Text;
using Proxy.ServiceWinToolWrite;

namespace WinfoToolSys.Controllers.SiteMng
{
    public class PreLevelController : Controller
    {
        //压力等级
        public ActionResult Index()
        {
            return View();
        }

        //获取压力等级列表
        public JsonResult GetLevelList(string levelName)
        {
            var list = ServcieTool.WinToolServiceReadInstance.GetPressureLevelList(PmsMng.ActiveKey, levelName);
            return Json(list);
        }

        //分组详细、修改、添加
        public ActionResult ShowDetail(string oper, string id)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.ServiceWinToolRead.T_DTU_PressureLevel model = ServcieTool.WinToolServiceReadInstance.GetOnePressureLevel(PmsMng.ActiveKey, id);

            switch (oper)
            {
                case "Show":
                    ViewBag.Oper = "Show";
                    break;
                case "Edit":
                    ViewBag.Oper = "Edit";
                    sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='PreLevel.Update();' />");
                    break;
                case "Add":
                    ViewBag.Oper = "Add";
                    sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='PreLevel.Add();' />");
                    break;
                default:
                    break;
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();
            return View(model);
        }

        //添加
        public string Add(T_DTU_PressureLevel model)
        {
            string result = "false";
            T_DTU_PressureLevel level = new T_DTU_PressureLevel();
            level.PressureName = model.PressureName;
            level.PressureDesc = model.PressureDesc == null ? "" : model.PressureDesc;
            level.Status = 1;
            level.UpdateFlag = 1;

            if (ServcieTool.WinToolServiceWriteInstance.AddPreLevel("", level))
            {
                result = "true";
            }
            return result;
        }

        //修改
        public string Update(T_DTU_PressureLevel model)
        {
            string result = "false";
            T_DTU_PressureLevel level = new T_DTU_PressureLevel();
            level.Id = model.Id;
            level.PressureName = model.PressureName;
            level.PressureDesc = model.PressureDesc == null ? "" : model.PressureDesc;
            level.Status = 1;
            level.UpdateFlag = 1;
            if (DataPermission.IsUserCanUpdateSite())
            {
                if (ServcieTool.WinToolServiceWriteInstance.UpdatePreLevel("", level))
                {
                    result = "true";
                }
            }
            else
            {
                result = "4";
            }
            return result;
        }

        //删除
        public string Delete(string id)
        {
            string result = "false";
            if (DataPermission.IsUserCanDeleteSite())
            {
                if (ServcieTool.WinToolServiceWriteInstance.DeletePreLevel("", id))
                {
                    result = "true";
                }
            }
            else
            {
                result = "4";
            }
            return result;
        }
    }
}
