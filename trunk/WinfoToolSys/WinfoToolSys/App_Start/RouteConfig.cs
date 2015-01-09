﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WinfoToolSys
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute("SiteOper", "SiteInfo/SiteDetail/{Oper}/{DtuId}", new
            //{
            //    controller = "SiteInfo",
            //    action = "SiteDetail",
            //    id = UrlParameter.Optional
            //});
            routes.MapRoute("ComOper", "ClientInfo/ClientDetail/{Oper}/{ComId}", new
            {
                controller = "ClientInfo",
                action = "ClientDetail",
                id = UrlParameter.Optional
            });
            routes.MapRoute("FileldOper", "FieldInfo/FieldInfoDetail/{Oper}/{ComId}/{FieldName}", new
            {
                controller = "FieldInfo",
                action = "FieldInfoDetail",
                id = UrlParameter.Optional
            });
            routes.MapRoute("SiteDeatailMalodor", "SiteInfoMalodor/SiteDeatailMalodor/{Oper}/{DtuId}", new
            {
                controller = "SiteInfoMalodor",
                action = "SiteDeatailMalodor",
                id = UrlParameter.Optional
            });
            routes.MapRoute(
               name: "Defaulta",
               url: "{controller}/{action}/{Oper}/{ConfigId}",
               defaults: new
               {
                   controller = "Main",
                   action = "Index",
                   id = UrlParameter.Optional
               }
           );
            routes.MapRoute(
                name: "Defaultb",
                url: "{controller}/{action}/{Oper}/{ComId}/{FieldName}",
                defaults: new
                {
                    controller = "Main",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            //routes.MapRoute(
            //    name:"RemoteConrolDel",
            //    url: "RemoteControlSet/DeleteControl",
            //    defaults: new
            //    {
            //        controller = "RemoteControlSet",
            //        action = "DeleteControl",
            //        id = UrlParameter.Optional
            //    }
            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Main",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
           

        }
    }
}