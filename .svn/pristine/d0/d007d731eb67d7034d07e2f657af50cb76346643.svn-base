using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WinfoToolSys.Cache;
using WinfoToolSys.Filters;

namespace WinfoToolSys
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            //启动缓存清理线程
            System.Timers.Timer timer = new System.Timers.Timer(10 * 60 * 1000);//每十分钟执行一次
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<string> OutDateCaches = new List<string>();//保存过期的缓存
            int Time = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CacheOutDateMinate"].ToString());
            foreach (var a in ServerCache.Caches)
            {
                if ((DateTime.Now - a.Value.SetTime).TotalMinutes > Time)//30分钟为过期时间
                { OutDateCaches.Add(a.Key); }
            }
            CacheModel model = null;
            foreach (var a in OutDateCaches)
            {
                if (ServerCache.Caches.ContainsKey(a))
                {
                    ServerCache.Caches.TryRemove(a, out model);//移除所有过期的缓存，减轻服务器内存负担
                }
            }
        }
       
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            //注册全局过滤器
            filters.Add(new UserAuthorization());
        }

        protected void RegisterView()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ViewConfig());
        }
    }
}