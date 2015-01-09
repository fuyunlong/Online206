using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.Encrypts;

namespace WinfoToolSys.Filters
{
    /// <summary>
    /// 用户授权过滤器
    /// </summary>
    public class UserAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var keys = filterContext.HttpContext.Request.Cookies;
          
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }


    }
}