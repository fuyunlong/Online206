using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
 
using Winfotian.Permission.HttpModule;
using WinfoToolSys.Pms;
using System.Web.Mvc;
using System.Web;
namespace WinfoToolSys.Cache
{
    /// <summary>
    /// 服务器缓存类
    /// </summary>
    public class ServerCache
    {
        //服务器缓存
        public static ConcurrentDictionary<string, CacheModel> Caches = new ConcurrentDictionary<string, CacheModel>();

        //获取缓存
        public static List<string> GetUserResources(string UserId)
        {
            try
            {
                if (Caches.ContainsKey(UserId))
                { return Caches[UserId].Resources; }
                else//重新请求当前缓存
                {
                    var list = PermissionWCFProxy.GetGrantedResources(UserId, PmsMng.DomainId);
                    if (list == null)
                    { list = new List<string>(); }
                    Caches.AddOrUpdate(UserId, new CacheModel { Resources = list, SetTime = DateTime.Now, UserName = UserId }, (key, oldValue) => oldValue);
                    return list;
                }
            }
            catch
            {
                return new List<string>();
            }
        }

        //移除缓存
        public static void ClearCaches()
        {
            try
            {              
                Caches.Clear();
            }
            catch { }
        }
 
    }

    public class CacheModel
    {
        //缓存用户名(一般为当前登陆用户)
        public string UserName { set; get; }
        //用户资源列表
        public List<string> Resources { set; get; }
        //缓存创建时间（缓存存活周期为半小时，超过时间的缓存将自动重新请求）
        public DateTime SetTime { set; get; }
    }

}