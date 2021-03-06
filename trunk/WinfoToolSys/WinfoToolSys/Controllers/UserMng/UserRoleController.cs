﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Proxy;
using Winfotian.Permission.HttpModule;

namespace WinfoToolSys.Controllers.UserMng
{
    public class UserRoleController : Controller
    {
        //用户分组管理
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据名称查询角色信息
        /// </summary>
        public JsonResult GetListByName(string roleName)
        {
            List<Winfotian.Permission.HttpModule.PermissionWCF.RoleDto> list = new List<Winfotian.Permission.HttpModule.PermissionWCF.RoleDto>();
            try
            {
                list = PermissionWCFProxy.QueryRoles(roleName, Pms.PmsMng.DomainId);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //添加页面
        public ActionResult AddRole()
        {
            return View();
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        public string AddUserRole(Winfotian.Permission.HttpModule.PermissionWCF.RoleDto model)
        {
            string result = string.Empty;
            Winfotian.Permission.HttpModule.PermissionWCF.RoleDto role = new Winfotian.Permission.HttpModule.PermissionWCF.RoleDto();

            try
            {
                role.Name = model.Name;
                role.RoleCode = model.RoleCode;
                role.Status = 1;
                role.Description = model.Description == null ? string.Empty : model.Description;
                role.DomainId = Pms.PmsMng.DomainId;

                if (!PermissionWCFProxy.CheckRoleCode(0, role.RoleCode))
                {
                    if (!PermissionWCFProxy.CheckRoleName(0, role.Name))
                    {
                        int count = PermissionWCFProxy.SaveRole(role);
                        if (count > 0)
                        {
                            result = "添加成功";
                        }
                        else
                        {
                            result = "添加角色信息失败！";
                        }
                    }
                    else
                    {
                        result = "该角色名称已存在！";
                    }
                }
                else
                {
                    result = "该角色编号已存在！";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return result;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        public string UpdateUserRole(Winfotian.Permission.HttpModule.PermissionWCF.RoleDto model)
        {
            string result = string.Empty;
            Winfotian.Permission.HttpModule.PermissionWCF.RoleDto role = new Winfotian.Permission.HttpModule.PermissionWCF.RoleDto();

            try
            {
                role.Id = model.Id;
                role.Name = model.Name;
                role.RoleCode = model.RoleCode;
                role.Status = 1;
                role.Description = model.Description == null ? string.Empty : model.Description;
                role.DomainId = Pms.PmsMng.DomainId;

                List<Winfotian.Permission.HttpModule.PermissionWCF.RoleDto> list = PermissionWCFProxy.QueryRoles("", Pms.PmsMng.DomainId);
                var temp = (from row in list where row.Id == model.Id select row).Single();
                if (Pms.DataPermission.IsUserCanUpdateUserInfo())
                {
                    if (!PermissionWCFProxy.CheckRoleCode(0, role.RoleCode) || temp.RoleCode == model.RoleCode)
                    {

                        if (!PermissionWCFProxy.CheckRoleName(0, role.Name) || temp.Name == model.Name)
                        {
                            int count = PermissionWCFProxy.UpdateRole(role);
                            if (count > 0)
                            {
                                result = "更新成功";
                            }
                            else
                            {
                                result = "更新角色信息失败！";
                            }
                        }
                        else
                        {
                            result = "该角色名称已存在！";
                        }
                    }
                    else
                    {
                        result = "该角色编号已存在！";
                    }
                }
                else
                {
                    result = "没有修改权限！";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        public int DeleteUserRole(string id)
        {
            int result = 0;
            try
            {
                if (Pms.DataPermission.IsUserCanDeleteUserInfo())
                {
                    int count = PermissionWCFProxy.DeleteRole(Convert.ToInt32(id));
                    if (count > 0)
                    {
                        result = 1;
                    }
                }
                else
                {
                    result = -1;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return result;
        }

        //详细、修改页面
        public ActionResult RoleDetail(string oper, string id)
        {
            List<Winfotian.Permission.HttpModule.PermissionWCF.RoleDto> list = new List<Winfotian.Permission.HttpModule.PermissionWCF.RoleDto>();
            if (oper == "Show")
            {
                ViewBag.Oper = "";
            }
            if (oper == "Edit")
            {
                ViewBag.Oper = "<input type='button' class='buttonVer2' value='修改' onclick='UserRole.UpdateUserRole();' />";
            }

            try
            {
                list = PermissionWCFProxy.QueryRoles("", Pms.PmsMng.DomainId);
                ViewBag.RoleObj = (from row in list where row.Id == Convert.ToInt32(id) select row).Single();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return View();
        }
    }
}
