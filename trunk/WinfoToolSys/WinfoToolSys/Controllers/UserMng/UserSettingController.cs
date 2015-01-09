﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WinfoToolSys.Pms;
using Proxy;
using Com.Winfotian.DB;
using Com.Winfotian.Common;
using Proxy.ServiceWinToolWrite;

namespace WinfoToolSys.Controllers.UserMng
{
    public class UserSettingController : Controller
    {
        //用户配置管理
        public ActionResult Index()
        {
            return View();
        }

        //根据名称查询
        public JsonResult GetUserConfigByName(string configName)
        {
            List<Proxy.ServiceWinToolRead.T_User_Config> list = new List<Proxy.ServiceWinToolRead.T_User_Config>();
            try
            {
                list = ServcieTool.WinToolServiceReadInstance.GetUserConfigListByName(PmsMng.ActiveKey, configName);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        /// <summary>
        /// 该方法为配置权限页面，不需要检验
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public JsonResult GetUserConfigByNameV2(string configName)
        {
            List<Proxy.ServiceWinToolRead.T_User_Config> list = new List<Proxy.ServiceWinToolRead.T_User_Config>();
            try
            {
                list = ServcieTool.WinToolServiceReadInstance.GetUserConfigListByName(PmsMng.ActiveKey, configName);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //详细、修改、添加
        public ActionResult Operation(string oper, string configId)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.ServiceWinToolRead.T_User_Config model = null;
            switch (oper)
            {
                case "Show":
                    ViewBag.Oper = "Show";
                    break;
                case "Edit":
                    ViewBag.Oper = "Edit";
                    sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='UserConfig.Update();' />");
                    break;
                case "Add":
                    ViewBag.Oper = "Add";
                    sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='UserConfig.Add();' />");
                    break;
                default:
                    break;
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();

            try
            {
                model = ServcieTool.WinToolServiceReadInstance.GetUserConfigByCode(PmsMng.ActiveKey, configId);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return View(model);
        }

        //获取客户端类型
        public JsonResult GetUsers()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            try
            {
                dic = ServcieTool.CrmServiceGetInstance.diclEnum(PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {

                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(dic.ToList());
        }

        //添加
        public string Add(T_User_Config model)
        {
            string result = "false";
            string cCode = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;

            T_User_Config config = new T_User_Config();
            config.CCode = cCode;
            config.ConfigName = model.ConfigName;
            config.ConfigDesc = model.ConfigDesc == null ? "" : model.ConfigDesc;
            config.SoftInterval = model.SoftInterval;
            config.IsAlert = model.IsAlert;
            config.IsRpt = model.IsRpt;
            config.Status = 1;
            config.PopCode = model.PopCode == null ? "" : model.PopCode;
            config.UpdateFlag = 1;

            try
            {
                if (ServcieTool.WinToolServiceWriteInstance.AddUserConfig(PmsMng.ActiveKey, config))
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
        public string Update(T_User_Config model)
        {
            string result = string.Empty;

            T_User_Config config = new T_User_Config();
            config.CCode = model.CCode;
            config.ConfigName = model.ConfigName;
            config.ConfigDesc = model.ConfigDesc == null ? "" : model.ConfigDesc;
            config.SoftInterval = model.SoftInterval;
            config.IsAlert = model.IsAlert;
            config.IsRpt = model.IsRpt;
            config.PopCode = model.PopCode == null ? "" : model.PopCode;

            try
            {
                if (Pms.DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.UpdateUserConfig(PmsMng.ActiveKey, config))
                    {
                        result = "修改成功";
                    }
                    else
                    {
                        result = "修改配置信息失败！";
                    }
                }
                else
                {
                    result = "没有修改权限！";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //删除
        public string Delete(string cCode)
        {
            string result = "false";
            try
            {
                if (Pms.DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.DeleteUserConfig(PmsMng.ActiveKey, cCode))
                    {
                        result = "删除成功";
                    }
                    else
                    {
                        result = "删除配置信息失败！";
                    }
                }
                else
                {
                    result = "没有删除权限！";
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
