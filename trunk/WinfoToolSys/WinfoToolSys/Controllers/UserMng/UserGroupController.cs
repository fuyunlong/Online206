﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.DB;
using Com.Winfotian.Common;
using WinfoToolSys.Pms;
using System.Text;
using Proxy;
using Proxy.ServiceWinToolRead;
using Proxy.CrmServicePost;

namespace WinfoToolSys.Controllers.UserMng
{
    public class UserGroupController : Controller
    {
        //用户分组管理
        public ActionResult Index()
        {
            return View();
        }

        //获取单个公司下所以分组(树形结构展开)
        public JsonResult GetGroup(string companyId)
        {
            List<Proxy.CrmServiceGet.T_DepartmentInfos> list = new List<Proxy.CrmServiceGet.T_DepartmentInfos>();
            if (companyId == "0" || companyId == "")
            {
                return Json(new List<int>());
            }

            try
            {
                list = ServcieTool.CrmServiceGetInstance.GetDepartmentNEWInfo(Convert.ToInt32(companyId), 0, "");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            if (list.Count == 0)
            {
                return Json(list);
            }
            return Json(WrapTreeGroup(list));
        }

        // 包装树形结构分组
        private List<Proxy.CrmServiceGet.T_DepartmentInfos> WrapTreeGroup(IList<Proxy.CrmServiceGet.T_DepartmentInfos> list)
        {
            var models = new List<Proxy.CrmServiceGet.T_DepartmentInfos>();
            foreach (var m in list)
            {
                if (m.ParentCode == 0)
                {
                    models.Add(m);
                    SubGroup(list, models, m.DepartID, 0);
                }
            }
            return models;
        }

        /// <summary>
        /// 内部方法-递归分组子集
        /// </summary>
        /// <param name="originalList">原分组</param>
        /// <param name="refModels">新分组集-output</param>
        /// <param name="parentCode">父编号</param>
        /// <param name="index">当前子分组层次深度</param>
        private void SubGroup(IList<Proxy.CrmServiceGet.T_DepartmentInfos> originalList, IList<Proxy.CrmServiceGet.T_DepartmentInfos> refModels, int parentCode, int index)
        {
            ++index;
            var arr = (from row in originalList
                       where row.ParentCode == parentCode
                       select row).ToList();
            foreach (var m in arr)
            {
                m.DepartName = GetTreeviewMarks(index, (m.DepartID == arr.Last().DepartID)) + m.DepartName;
                refModels.Add(m);
                SubGroup(originalList, refModels, m.DepartID, index);
            }
        }

        //生成树形结构线
        private string GetTreeviewMarks(int sum, bool isLast)
        {
            if (sum == 0)
            {
                return "";
            }
            string mark = "";
            for (int i = 0; i < sum; i++)
            {
                mark += "&nbsp&nbsp";
            }
            if (isLast)
            {
                mark += "└ ";
            }
            else
            {
                mark += "├ ";
            }
            return mark;
        }

        //根据名称查询分组信息
        //public string GetUserGroupByCompanyID(string companyId)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    List<T_User_GroupExt> list = new List<T_User_GroupExt>();

        //    try
        //    {
        //        list = ServcieTool.WinToolServiceReadInstance.GetGroupListByCompanyID(PmsMng.ActiveKey, companyId);
        //        if (list.Count == 0)
        //        {
        //            return string.Empty;
        //        }
        //        //顶层
        //        var rows = (from r in list
        //                    where r.ParentCode == "0"
        //                    select r).ToList();

        //        foreach (var row in rows)
        //        {
        //            sb.Append("<tr isHide=" + row.ParentCode + "><td class='com_w25pen' style='padding-left:20px'>");
        //            var arr = (from r in list
        //                       where r.ParentCode == row.GroupCode
        //                       select r).ToList();
        //            if (arr.Count > 0)//有子
        //            {
        //                sb.Append("<img src='/Images/tag_add.png' isHide='" + row.GroupCode + "' onclick='UserGroup.Collapse(this)' style='padding-right:3px;margin-bottom:-3px;cursor:pointer'/>");
        //            }
        //            sb.Append(row.GroupName + "</td>");
        //            sb.Append("<td class='com_w25pen com_TextCenter'>" + row.GroupDesc + "</td>");
        //            sb.Append("<td class='com_w30pen com_TextCenter'>" + GetCompanyNameById(row.CompanyId.ToString()) + "</td>");
        //            sb.Append("<td class='com_w20pen com_TextCenter'>");
        //            sb.Append("<a href='javascript:void(0)' onclick=Common.WinTopBox('分组查看','38%','35%','25%','33%','UserGroup/Operation?oper=Show&configId=" + row.GroupCode + "')>查看|</a>");
        //            sb.Append("<a href='javascript:void(0)' onclick=Common.WinTopBox('分组修改','38%','35%','25%','33%','UserGroup/Operation?oper=Edit&configId=" + row.GroupCode + "')>修改|</a>");
        //            sb.Append("<a href='javascript:void(0)' onclick=javascript:UserGroup.Delete('" + row.GroupCode + "')>删除</a>");
        //            sb.Append("</td>");
        //            sb.Append("</tr>");
        //            sb.Append(SubGroup(list, row.GroupCode, 0));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
        //    }
        //    return sb.ToString();
        //}     

        //分组详细、修改、添加
        public ActionResult Operation(string oper, string departId)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.CrmServiceGet.T_DepartmentInfos model = new Proxy.CrmServiceGet.T_DepartmentInfos();

            try
            {
                switch (oper)
                {
                    case "Show":
                        ViewBag.Oper = "Show";
                        model = ServcieTool.CrmServiceGetInstance.GetDepartmentNEWInfo(0, Convert.ToInt32(departId), "")[0];
                        break;
                    case "Edit":
                        ViewBag.Oper = "Edit";
                        sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='UserGroup.Update();' />");
                        model = ServcieTool.CrmServiceGetInstance.GetDepartmentNEWInfo(0, Convert.ToInt32(departId), "")[0];
                        break;
                    case "Add":
                        ViewBag.Oper = "Add";
                        sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='UserGroup.Add();' />");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();
            return View(model);
        }

        //根据公司Id查询名称
        public string GetCompanyNameById(string companyId)
        {
            string result = string.Empty;
            Proxy.CrmServiceGet.T_CompanyInfos model = null;

            try
            {
                model = ServcieTool.CrmServiceGetInstance.GetCompanyInfoList(companyId, PmsMng.ActiveKey);
                if (model != null)
                {
                    result = model.CompanyName;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //添加分组
        public string Add(T_DepartmentInfos model)
        {
            string result = string.Empty;
            T_DepartmentInfos depart = new T_DepartmentInfos();
            depart.DepartName = model.DepartName;
            depart.CompanyID = model.CompanyID;
            depart.Telphone = "";
            depart.Remark = model.Remark == null ? "" : model.Remark;
            depart.ParentCode = model.ParentCode;
            depart.Status = 1;

            try
            {
                result = ServcieTool.CrmServicePostInstance.AddDepartment(depart, "");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //修改分组
        public string Update(T_DepartmentInfos model)
        {
            string result = string.Empty;
            T_DepartmentInfos depart = new T_DepartmentInfos();
            depart.DepartID = model.DepartID;
            depart.DepartName = model.DepartName;
            depart.CompanyID = model.CompanyID;
            depart.Telphone = "";
            depart.Remark = model.Remark == null ? "" : model.Remark;
            depart.ParentCode = model.ParentCode;
            depart.Status = 1;

            try
            {
                if (Pms.DataPermission.IsUserCanUpdateSite())
                {
                    result = ServcieTool.CrmServicePostInstance.UpdateDepartment(depart, "");
                }
                else
                {
                    result = "没有权限";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //删除分组
        public string Delete(string departId)
        {
            string result = string.Empty;

            try
            {
                if (Pms.DataPermission.IsUserCanDeleteUserInfo())
                {
                    result = ServcieTool.CrmServicePostInstance.Delete(departId, "");
                }
                else
                {
                    result = "没有权限";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //递归查子
        //private string SubGroup(IList<T_User_GroupExt> originalList, string parentCode, int index)
        //{
        //    ++index;
        //    StringBuilder sb = new StringBuilder();
        //    var arr = (from row in originalList
        //               where row.ParentCode == parentCode
        //               select row).ToList();

        //    if (arr.Count > 0)//子
        //    {
        //        for (int i = 0; i < arr.Count; i++)
        //        {
        //            sb.Append("<tr class='com_hide' isHide=" + arr[i].ParentCode + "><td class='com_w25pen' style='padding-left:" + (index * 18 + 20) + "px'>");
        //            var rr = (from r in originalList
        //                      where r.ParentCode == arr[i].GroupCode
        //                      select r).ToList();
        //            if (rr.Count > 0)
        //            {
        //                sb.Append("<img src='/Images/tag_add.png' isHide='" + arr[i].GroupCode + "' onclick='UserGroup.Collapse(this)' style='padding-right:3px;margin-bottom:-3px;cursor:pointer'/>");
        //            }
        //            sb.Append(arr[i].GroupName + "</td>");
        //            sb.Append("<td class='com_w25pen com_TextCenter'>" + arr[i].GroupDesc + "</td>");
        //            sb.Append("<td class='com_w30pen com_TextCenter'>" + GetCompanyNameById(arr[i].CompanyId.ToString()) + "</td>");
        //            sb.Append("<td class='com_w20pen com_TextCenter'>");
        //            sb.Append("<a href='javascript:void(0)' onclick=Common.WinTopBox('分组查看','38%','35%','25%','33%','UserGroup/Operation?Oper=Show&ConfigId=" + arr[i].GroupCode + "')>查看|</a>");
        //            sb.Append("<a href='javascript:void(0)' onclick=Common.WinTopBox('分组修改','38%','35%','25%','33%','UserGroup/Operation?Oper=Edit&ConfigId=" + arr[i].GroupCode + "')>修改|</a>");
        //            sb.Append("<a href='javascript:void(0)' onclick=javascript:UserGroup.Delete('" + arr[i].GroupCode + "')>删除</a>");
        //            sb.Append("</td></tr>");
        //            sb.Append(SubGroup(originalList, arr[i].GroupCode, index));
        //        }
        //    }

        //    return sb.ToString();
        //}
    }
}
