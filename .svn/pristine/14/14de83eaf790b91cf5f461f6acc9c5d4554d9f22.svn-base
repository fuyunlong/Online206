using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Com.Winfotian.Common
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class CookieHelperVer2
    {
       
        /// <summary>
        /// 设置Cookie(过期时间暂时不用）
        /// </summary>
        /// <param name="cookiename"></param>
        /// <param name="cookievalue"></param>
        /// <param name="domainname">如果为空，则设置当前域名</param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static bool SetCookie(string cookiename, string cookievalue, string domainname, int hour, int minute)
        {
            if(cookievalue == null)
                return false;

            HttpCookie SessionCookie = null;

            //对 SessionId 进行备份.
            if(HttpContext.Current.Request.Cookies["ASP.NET_SessionId"] != null)
            {
                string SesssionId = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value.ToString();
                SessionCookie = new HttpCookie("ASP.NET_SessionId");
                SessionCookie.Value = SesssionId;
            }
            if(hour != 0 || minute != 0)
            {
                //设定cookie 过期时间.
                DateTime dtExpiry = DateTime.Now.AddHours(hour).AddMinutes(minute);
                HttpContext.Current.Response.Cookies[cookiename].Expires = dtExpiry;
            }
            //设定cookie 域名.
            if(domainname.Length == 0)
            {
                string domain = string.Empty;
                if(HttpContext.Current.Request.Params["HTTP_HOST"] != null)
                {
                    domain = HttpContext.Current.Request.Params["HTTP_HOST"].ToString();
                }

                if(domain.IndexOf(".") > -1)
                {
                    int index = domain.IndexOf(".");
                    domain = domain.Substring(index + 1);
                    HttpContext.Current.Response.Cookies[cookiename].Domain = domain;

                }
            }
            else
            {
                HttpContext.Current.Response.Cookies[cookiename].Domain = domainname;
            }

            HttpContext.Current.Response.Cookies[cookiename].Value = cookievalue;

            //如果cookie总数超过20 个, 重写ASP.NET_SessionId, 以防Session 丢失.
            if(HttpContext.Current.Request.Cookies.Count > 20 && SessionCookie != null)
            {
                if(SessionCookie.Value != string.Empty)
                {
                    HttpContext.Current.Response.Cookies.Remove("ASP.NET_SessionId");
                    HttpContext.Current.Response.Cookies.Add(SessionCookie);
                }
            }

            return true;

        }

        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="cookiekey"></param>
        /// <returns></returns>
        public static string GetCookie(string cookiekey)
        {
            string cookyval = "";
            try
            {
                if(HttpContext.Current.Request.Cookies[cookiekey] == null)
                {
                    return "";
                }
                else
                {
                    cookyval = HttpContext.Current.Request.Cookies[cookiekey].Value;
                }
            }
            catch
            {

                cookyval = "";
            }
            return cookyval;
        }

        /// <summary>
        /// 清除Cookie
        /// </summary>
        /// <param name="cookiekey"></param>
        public static void RemoveCookie(string cookiekey)
        {
            CookieHelper.SetCookie(cookiekey, "", ".scadacn.com", 0, -100);
        }
    }
}
