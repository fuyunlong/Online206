using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Proxy;
using Winfotian.Permission.HttpModule;
using WinfoToolSys.Cache;

namespace WinfoToolSys.Pms
{
    /// <summary>
    /// 数据权限筛选类
    /// </summary>
    public class DataPermission
    {

        // 根据用户ID获取当前用户拥有的站点列表，返回list
        public static List<string> PermisSites(string userId)
        {
            List<string> list = new List<string>();
            try
            {
                list = ServcieTool.WinToolServiceReadInstance.GetDTUByUserId(PmsMng.ActiveKey, userId);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return list;
        }

        // 判断当前用户是否具有修改站点的权限
        public static bool IsUserCanUpdateSite()
        {
            return IsUserHasPermission("RSC_WinTool_201");
        }

        //站点删除权限
        public static bool IsUserCanDeleteSite()
        {
            return IsUserHasPermission("RSC_WinTool_200");
        }

        //用户更新权限
        public static bool IsUserCanUpdateUserInfo()
        {
            return IsUserHasPermission("RSC_WinTool_202");
        }

        //用户删除权限
        public static bool IsUserCanDeleteUserInfo()
        {
            return IsUserHasPermission("RSC_WinTool_203");
        }

        public static bool IsUserReadSiteOriginalData()
        {
            return IsUserHasPermission("RSC_WinTool_204");
        }

        private static bool IsUserHasPermission(string Resource)
        {
            bool rslt = false;
            try
            {
                var list = ServerCache.GetUserResources(PmsMng.LogUser);
                if (list.Contains(Resource))
                { rslt = true; }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rslt;
        }
    }
}