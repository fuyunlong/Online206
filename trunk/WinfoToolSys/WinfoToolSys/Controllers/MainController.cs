﻿using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Winfotian.Permission.HttpModule;
using Winfotian.Permission.HttpModule.PermissionWCF;
using System.Web.UI.WebControls;
using WinfoToolSys.Cache;

namespace WinfoToolSys.Controllers.Index
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            //根据用户信息获取用户所在公司的名字，logo
            string Str = ServcieTool.CrmServiceGetInstance.LogoToCompanyName(Pms.PmsMng.CompanyId.ToString(), Pms.PmsMng.ActiveKey);
            ViewBag.TrueName = Pms.PmsMng.TrueName;
            if (Pms.PmsMng.CompanyId == 12)
            { ViewBag.CacheOper = "yes"; }
            else
            {
                ViewBag.CacheOper = "";
            }
            if (!string.IsNullOrWhiteSpace(Str) && Str.Length > 0)
            {
                Str = Str.Replace("\\", "/");
                string[] StrArr = Str.Split(',');
                if (StrArr.Length == 2)
                {
                    ViewBag.Logo = StrArr[0];
                    ViewBag.ComName = StrArr[1];
                }
                else
                {
                    ViewBag.Logo = "";
                    ViewBag.ComName = "";
                }
            }
            //获取菜单列表pms
            var menuInfos = PermissionWCFProxy.GetMenuRightList(Pms.PmsMng.LogUser, System.Configuration.ConfigurationManager.AppSettings["Winfotian.Permission.AppCode"].ToString()).ToArray();
            int dnIdx = 0;
            StringBuilder ReturnStr = new StringBuilder();
            ReturnStr.Append(GenerateMenu(menuInfos, false, ref dnIdx));
            ViewBag.Menus = ReturnStr.ToString();
            return View();
        }

        public ActionResult SiteMap()
        {
            return View();
        }

        private string GenerateMenu(MenuInfo[] menuInfos, bool haveParent, ref int dateNameIdx)
        {
            StringBuilder sb = new StringBuilder();
            string tag = String.Empty;
            foreach (var mi in menuInfos)
            {
                if (mi.Display != 1)
                {
                    continue;
                }
                dateNameIdx++;
                if (mi.HasChilds)
                {
                    sb.Append("<div title=" + mi.MenuName + ">");
                    sb.Append(" <ul class='tree' style='margin-top: 3px;'>");
                    sb.Append(GenerateMenu(mi.Childs, true, ref dateNameIdx));
                    sb.Append(" </ul> </div>");
                }
                else
                {
                    if (haveParent)
                    {
                        sb.Append("<li url=" + mi.OpenForm + ">");
                        sb.Append("<span>" + mi.MenuName + "</span></li>");
                    }
                    else
                    {
                        sb.Append("<li url=" + mi.OpenForm + ">");
                        sb.Append("<span>" + mi.MenuName + "</span></li>");
                    }
                }
            }
            if (sb.Length == 0)
            {
                Pms.PmsMng.RemoveCookies();
                sb.Append("0");
            }
            return sb.ToString();
        }

        public int LogOut()
        {
            int rlst = 0;
            try
            {
                Com.Winfotian.ServiceProxy.UserServiceProxy.LoginOut(Pms.PmsMng.LogUser, 18, WinManager.GetPublicIP());
                Pms.PmsMng.RemoveCookies();//清除Cookie
                rlst = 1;
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
            }
            return rlst;
        }

        public string ClearCaches()
        {
            StringBuilder rlst = new StringBuilder();
            rlst.Append("操作失败");
            try
            {
                if (Pms.PmsMng.CompanyId == 12)
                {
                   
                    ServerCache.ClearCaches();
                    rlst.Clear().Append("成功清理服务器缓存");
                }
                else
                {
                    rlst.Clear().Append("对不起，当前用户无权限操作");
                }
            }
            catch
            { }
            return rlst.ToString();
        }
    }
}
