﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Winfotian.Common;
using Com.Winfotian.Encrypts;
using Com.Winfotian.DB;

namespace WinfoToolSys.Pms
{
    public class PmsMng
    {
        public const string StaticKey = "2c37f5c3-6313-435c-a502-2c1cd1a25cf8";

        #region GetCookie
        public static string LogUser
        {
            get
            {
                try
                {
#if DEBUG
                    return "fuyunlong";
#else
                    return DESEncrypt.Decrypt(CookieHelper.GetCookie("UserName"));
#endif
                }
                catch { return ""; }
            }
        }

        public static string DomainId
        {
            get
            {
                return "WinTool";
            }
        }

        public static string TrueName
        {
            get
            {
                try
                {
                    return DESEncrypt.Decrypt(CookieHelper.GetCookie("TrueName"));
                }
                catch (Exception ex)
                {
                    LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
                    return "未知用户";
                }
            }
        }
        public static string ActiveKey
        {
            get
            {
#if DEBUG
                return "2c37f5c3-6313-435c-a502-2c1cd1a25cf8";//测试时使用静态码
#else
                return CookieHelper.GetCookie("ActiveKey");
#endif
            }
        }
        public static string LgDate
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookie("LgDate");
                }
                catch { return DateTime.Now.ToString("yyyy-MM-dd"); }
            }
        }
        public static string LastIP
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookie("LastIP");
                }
                catch { return "192.168.1.252"; }
            }
        }
        public static int CompanyId
        {
            get
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(DESEncrypt.Decrypt(CookieHelper.GetCookie("CompanyId"))))
                    {
                        return 12;
                    }
                    return Int32.Parse(DESEncrypt.Decrypt(CookieHelper.GetCookie("CompanyId")));
                }
                catch { return 12; }
            }
        }

        public static string CompanyName
        {
            get
            {
                try
                {
                    return DESEncrypt.Decrypt(CookieHelper.GetCookie("CompanyName"));
                }
                catch
                {
                    return "未获取到公司信息";
                }
            }
        }
        public static string Pop
        {
            get
            {
                return CookieHelper.GetCookie("Pop");
            }
        }
        #endregion

        /// <summary>
        /// 设置cookie 的信息
        /// </summary>
        /// <param name="cookiename"></param>
        /// <param name="cookievalue"></param>
        /// <param name="domainname"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public bool SetCookie(string cookiename, string cookievalue, string domainname, int hour, int minute)
        {
            if (cookievalue == null)
                return false;
            HttpCookie SessionCookie = null;
            //对 SessionId 进行备份.
            if (HttpContext.Current.Request.Cookies["ASP.NET_SessionId"] != null)
            {
                string SesssionId = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value.ToString();
                SessionCookie = new HttpCookie("ASP.NET_SessionId");
                SessionCookie.Value = SesssionId;

            }
            //设定cookie 过期时间
            DateTime dtExpiry = DateTime.Now.AddHours(hour).AddMinutes(minute);
            HttpContext.Current.Response.Cookies[cookiename].Expires = dtExpiry;

            //设定cookie 域名.
            if (domainname.Length == 0)
            {
                string domain = string.Empty;
                if (HttpContext.Current.Request.Params["HTTP_HOST"] != null)
                {
                    domain = HttpContext.Current.Request.Params["HTTP_HOST"].ToString();
                }

                if (domain.IndexOf(".") > -1)
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

            //如果cookie总数超过20个, 重写ASP.NET_SessionId, 以防session 丢失
            if (HttpContext.Current.Request.Cookies.Count > 20 && SessionCookie != null)
            {
                if (SessionCookie.Value != string.Empty)
                {
                    HttpContext.Current.Response.Cookies.Remove("ASP.NET_SessionId");
                    HttpContext.Current.Response.Cookies.Add(SessionCookie);
                }
            }
            return true;
        }

        /// <summary>
        /// 删除cookies
        /// </summary>
        public static void RemoveCookies()
        {

            string[] sArr = { "UserName", "TrueName", "ActiveKey", "LgDate", "LastIP", "CompanyId", "CompanyName", "Pop", "SSOToken", "SSOCurrentUser", "AD", "EC" };
            HttpContext.Current.Response.Cookies.Clear();
            foreach (string key in sArr)
            {
                Com.Winfotian.Common.CookieHelper.SetCookie(key, "", ".scadacn.com", 0, 0);
            }
        }
    }
}