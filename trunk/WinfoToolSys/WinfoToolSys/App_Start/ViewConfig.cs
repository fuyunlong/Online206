using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WinfoToolSys
{

    public sealed class ViewConfig : RazorViewEngine
    {

        public ViewConfig()
        {
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/ClientInfo/{0}.cshtml",//我们的规则
                "~/Views/Main/{0}.cshtml",
                "~/Views/UserSetting/{0}.cshtml"
                         
            };
        }
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

    }

}