using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Com.Winfotian.DB;
using Com.Winfotian.Common;
using Proxy;
using System.Text;
using Proxy.ServiceWinToolWrite;

namespace WinfoToolSys.Controllers.SiteMng
{
    public class SiteGroupController : Controller
    {
        /// <summary>
        /// 内部方法-递归分组子集
        /// </summary>
        /// <param name="originalList">原分组</param>
        /// <param name="refModels">新分组集-output</param>
        /// <param name="parentCode">父编号</param>
        /// <param name="index">当前子分组层次深度</param>
        private void SubGroup(IList<Proxy.ServiceWinToolRead.T_DTU_GroupEx> originalList, IList<Proxy.ServiceWinToolRead.T_DTU_GroupEx> refModels, string parentCode, int index)
        {
            ++index;
            var arr = (from row in originalList
                       where row.ParentCode == parentCode
                       select row).ToList();
            foreach (var m in arr)
            {
                m.GroupName = GetTreeviewMarks(index, (m.GroupCode == arr.Last().GroupCode)) + m.GroupName;
                refModels.Add(m);
                SubGroup(originalList, refModels, m.GroupCode, index);
            }
        }

        /// <summary>
        /// 生成树形结构线
        /// </summary>
        private string GetTreeviewMarks(int sum, bool isLast)
        {
            if (sum == 0)
                return "";
            string mark = "";
            for (int i = 0; i < sum; i++)
            {
                mark += "&nbsp&nbsp";
            }
            if (isLast)
                mark += "└ ";
            else
                mark += "├ ";
            return mark;
        }

        /// <summary>
        /// 包装树形结构分组
        /// </summary>
        private List<Proxy.ServiceWinToolRead.T_DTU_GroupEx> WrapTreeGroup(IList<Proxy.ServiceWinToolRead.T_DTU_GroupEx> list)
        {
            var models = new List<Proxy.ServiceWinToolRead.T_DTU_GroupEx>();
            foreach (var m in list)
            {
                if (m.ParentCode == "0")
                {
                    models.Add(m);
                    SubGroup(list, models, m.GroupCode, 0);
                }
            }
            return models;
        }

        /// <summary>
        /// 获取单个公司下所以分组(树形结构展开)
        /// </summary>
        /// <param name="id">公司Id</param>
        /// <returns></returns>
        public JsonResult GetGroup(string id)
        {
            if (id == "0" || id == "")
                return Json(new List<int>());
            var list = ServcieTool.WinToolServiceReadInstance.GetSiteGroupByCompanyId(PmsMng.ActiveKey, id);
            if (list.Count == 0)
                return Json(list);
            JsonResult json = Json(WrapTreeGroup(list));
            return json;
        }

        //站点分组管理
        public ActionResult Index()
        {
            return View();
        }

        //详细、添加、修改
        public ActionResult ShowDetail(string oper, string groupCode)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.ServiceWinToolRead.T_DTU_GroupEx model = null;
            switch (oper)
            {
                case "Show":
                    ViewBag.Oper = "Show";
                    break;
                case "Edit":
                    ViewBag.Oper = "Edit";
                    sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='SiteGroup.Update();' />");
                    break;
                case "Add":
                    ViewBag.Oper = "Add";
                    sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='SiteGroup.Add();' />");
                    break;
                default:
                    break;
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();
            try
            {
                model = ServcieTool.WinToolServiceReadInstance.GetSiteGroupByCode(PmsMng.ActiveKey, groupCode);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return View(model);
        }

        //添加分组
        public string Add(T_DTU_Group model)
        {
            string result = "false";
            string groupCode = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;

            T_DTU_Group group = new T_DTU_Group();
            group.GroupCode = groupCode;
            group.GroupName = model.GroupName;
            group.GroupDesc = model.GroupDesc == null ? "" : model.GroupDesc;
            group.ParentCode = model.ParentCode;
            group.Status = 1;
            group.CompanyId = model.CompanyId;
            group.UpdateFlag = 1;

            try
            {
                if (ServcieTool.WinToolServiceWriteInstance.AddSiteGroup(PmsMng.ActiveKey, group))
                {
                    result = "true";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //修改分组
        public string Update(T_DTU_Group model)
        {
            string result = "false";

            T_DTU_Group group = new T_DTU_Group();
            group.GroupCode = model.GroupCode;
            group.GroupName = model.GroupName;
            group.GroupDesc = model.GroupDesc == null ? "" : model.GroupDesc;
            group.ParentCode = model.ParentCode;
            group.Status = 1;
            group.CompanyId = model.CompanyId;
            group.UpdateFlag = 1;

            try
            {
                if (DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.UpdateSiteGroup(PmsMng.ActiveKey, group))
                    {
                        result = "true";
                    }
                }
                else
                {
                    result = "4";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //删除分组
        public string Delete(string groupCode)
        {
            string result = "0";
            try
            {
                if (!ServcieTool.WinToolServiceReadInstance.IsGroupHasSite(PmsMng.ActiveKey, groupCode))//没有站点才能进行删除
                {
                    if (DataPermission.IsUserCanDeleteUserInfo())
                    {
                        if (ServcieTool.WinToolServiceWriteInstance.DeleteSiteGroup(PmsMng.ActiveKey, groupCode))
                        {
                            result = "1";
                        }
                    }
                    else
                    {
                        result = "4";
                    }
                }
                else
                {
                    result = "-1";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }
    }
}
