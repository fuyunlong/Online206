using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Com.Winfotian.Common
{
    /// <summary>
    /// All references to session should go into this class
    /// </summary>
    [System.Serializable]
    public class SessionManager
    {

        public static string CurrentUser
        {
            get
            {
                try
                {
                    string val = CookieHelper.GetCookie("SSOCurrentUser");
                    return System.Text.Encoding.Default.GetString(Convert.FromBase64String(val.Replace("%2B", "+")));
                }
                catch
                {
                    return string.Empty;
                }
            }

        }

    }

    public class SessionHelperVer2
    {
        public static void Add(string key, object value)
        {
            HttpContext.Current.Session.Add(key, value);
        }

        public static object Get(string key)
        {
            return HttpContext.Current.Session[key];
        }

        public static void RemoveAll()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}
