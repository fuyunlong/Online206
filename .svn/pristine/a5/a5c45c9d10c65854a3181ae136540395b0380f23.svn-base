using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Com.Winfotian.ServiceProxy;
using Com.Winfotian.ServiceProxy.UpdateService;
using System.Text;
using WinfoToolSys.Pms;
using System.Reflection;
using System.ComponentModel;
using Proxy;
using Proxy.CrmServicePost;

namespace WinfoToolSys.Controllers.ClientMng
{
    public class ConfigController : Controller
    {
        //公司配置管理
        public ActionResult ShowConfigList()
        {
            return View();
        }

        //查询配置信息
        public JsonResult GetConfigByName(string configName)
        {
            List<Proxy.CrmServiceGet.T_CompanyComfigs> list = new List<Proxy.CrmServiceGet.T_CompanyComfigs>();
            try
            {
                list = ServcieTool.CrmServiceGetInstance.GetListConfiginfo("", configName, PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //查询所有配置信息
        public JsonResult GetConfigList()
        {
            List<Proxy.CrmServiceGet.T_CompanyComfigs> list = new List<Proxy.CrmServiceGet.T_CompanyComfigs>();
            try
            {
                list = ServcieTool.CrmServiceGetInstance.GetCompanyConfigs(PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //根据公司id查询配置信息
        public JsonResult GetCompanyConfig(string companyId)
        {
            List<Proxy.CrmServiceGet.T_CompanyComfigs> list = new List<Proxy.CrmServiceGet.T_CompanyComfigs>();
            try
            {
                list = ServcieTool.CrmServiceGetInstance.GetCompanyConfig(companyId, PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //添加、详细、修改页面
        public ActionResult ShowOper(string oper, string configId)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.CrmServiceGet.T_CompanyComfigs model = null;

            switch (oper)
            {
                case "Show":
                    ViewBag.Oper = "Show";
                    break;
                case "Edit":
                    ViewBag.Oper = "Edit";
                    sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='CompanyConfig.Update();' />");
                    break;
                case "Add":
                    ViewBag.Oper = "Add";
                    sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='CompanyConfig.Add();' />");
                    break;
                default:
                    break;
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();

            try
            {
                model = ServcieTool.CrmServiceGetInstance.GetCompanyConfigID(configId, PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return View(model);
        }

        //添加配置
        public string Add(T_CompanyComfigs model)
        {
            string result = "false";
            try
            {
                if (ServcieTool.CrmServicePostInstance.AddConfigInfo(model, PmsMng.ActiveKey))
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

        //修改配置
        public string Update(T_CompanyComfigs model)
        {
            string result = string.Empty;
            try
            {
                if (Pms.DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.CrmServicePostInstance.UpdateCompanyConfig(model, PmsMng.ActiveKey))
                    {
                        result = "修改成功";
                    }
                    else
                    {
                        result = "修改失败";
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

        //删除配置
        public string Delete(string configId)
        {
            string result = string.Empty;
            try
            {
                if (Pms.DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.CrmServicePostInstance.ChangeConfigStatus(configId, 0, PmsMng.ActiveKey))
                    {
                        result = "删除成功";
                    }
                    else
                    {
                        result = "删除失败";
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
