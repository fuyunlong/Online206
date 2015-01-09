using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Proxy;
using Proxy.CrmServiceGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Winfotian.Permission.HttpModule;
using WinfoToolSys.Pms;

namespace WinfoToolSys
{
    public class HtmlCommon
    {
        //获取用户计费方式
        public SelectList GetUserFeeList(string BillCode = "")
        {
            List<Proxy.SmsService.T_SMS_Bill> FeeList = null;
            try
            {
                FeeList = ServcieTool.SmsServiceInstance.GetBillConfigList(PmsMng.StaticKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return new SelectList(FeeList, "BillCode", "BillName", BillCode);
        }

        //获取用户配置
        public SelectList GetUserConfigList(string config = "")
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<Proxy.ServiceWinToolRead.T_User_Config> ConfigList = new List<Proxy.ServiceWinToolRead.T_User_Config>();
            try
            {
                ConfigList = ServcieTool.WinToolServiceReadInstance.GetUserConfigListByName(PmsMng.ActiveKey, "");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }

            return new SelectList(ConfigList, "CCode", "ConfigName", config);
        }

        //获取用户角色
        public SelectList GetUserRoleList(string RoleCode = "")
        {
            List<Winfotian.Permission.HttpModule.PermissionWCF.RoleDto> list = new List<Winfotian.Permission.HttpModule.PermissionWCF.RoleDto>();
            try
            {
                list = PermissionWCFProxy.QueryRoles("", Pms.PmsMng.DomainId);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return new SelectList(list, "RoleCode", "Name", RoleCode);
        }

        //获取公司集合
        public SelectList GetCompanyList(string Company = "")
        {
            List<T_Companys> list = new List<T_Companys>();
            try
            {
                var model = ServcieTool.CrmServiceGetInstance.GetCompanyLists("", "", PmsMng.ActiveKey);
                if (PmsMng.CompanyId == 12)
                {
                    foreach (var a in model)
                    {
                        if (a.CompanyID == 12)
                            list.Insert(0, a);
                        else
                        {
                            list.Add(a);
                        }
                    }
                }
                else
                {
                    list = (from row in model where row.CompanyID == PmsMng.CompanyId select row).ToList();
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }

            return new SelectList(list, "CompanyID", "CompanyName", Company);
        }

        //获取部门列表
        public SelectList GetDepartList(int Company, int Depart = 0)
        {

            List<Proxy.CrmServiceGet.T_DepartmentInfos> departs = null;
            try
            {
                departs = ServcieTool.CrmServiceGetInstance.GetDepartmentInfoList(Company.ToString(), PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            if (departs == null)
            {
                departs = new List<T_DepartmentInfos>();
            }
            departs.Insert(0, new T_DepartmentInfos { DepartID = 0, DepartName = "全部" });

            return new SelectList(departs, "DepartID", "DepartName", Depart);
        }

        //根据部门ID获取职位列表
        public SelectList GetPosiontionList(int Depart, int Postion = 0)
        {

            List<Proxy.CrmServiceGet.T_PostInfos> postion = null;
            try
            {
                postion = new JavaScriptSerializer().Deserialize<List<Proxy.CrmServiceGet.T_PostInfos>>(ServcieTool.CrmServiceGetInstance.GetPostinfo(Depart, PmsMng.ActiveKey));
            }
            catch
            { }
            if (postion == null)
            {
                return null;
            }
            return new SelectList(postion, "PosID", "PostName", Postion);
        }

        //获取终端类型
        public SelectList GetVerTypeList(string Ver = "")
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                Dictionary<string, string> dic = ServcieTool.WinToolServiceReadInstance.GetVerList(PmsMng.ActiveKey);
                foreach (var a in dic)
                {
                    if (a.Key == Ver)
                    {
                        list.Add(new SelectListItem { Value = a.Key, Text = a.Value, Selected = true });
                    }
                    else
                    { list.Add(new SelectListItem { Value = a.Key, Text = a.Value }); }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return new SelectList(list, "Value", "Text", Ver);
        }

        //获取压力等级
        public SelectList GetPressureLevelList(int Level = 0)
        {
            List<Proxy.ServiceWinToolRead.T_DTU_PressureLevel> LevelList = null;
            try
            {
                LevelList = ServcieTool.WinToolServiceReadInstance.GetPressureLevelList(PmsMng.ActiveKey, "");

            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            if (LevelList == null)
            {
                LevelList = new List<Proxy.ServiceWinToolRead.T_DTU_PressureLevel>();
            }
            return new SelectList(LevelList, "Id", "PressureName", Level);
        }

        //获取站点配置
        public SelectList GetDtuConfigList(string ConfigCode = "")
        {
            List<Proxy.ServiceWinToolRead.T_DTU_Config> DtuConfigList = new List<Proxy.ServiceWinToolRead.T_DTU_Config>();
            try
            {
               DtuConfigList = ServcieTool.WinToolServiceReadInstance.DtuConfigListV2(PmsMng.ActiveKey);
              
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return new SelectList(DtuConfigList, "ConfigCode", "ConfigName", ConfigCode);
        }


        public SelectList GetDtuList(string companyId, string groupCode = "0")
        {
           
            List<Proxy.ServiceWinToolRead.T_DTU> DtuList = new List<Proxy.ServiceWinToolRead.T_DTU>();
            try
            {
                var model = ServcieTool.WinToolServiceReadInstance.GetSiteByCompanyIdAndGroupCode(PmsMng.ActiveKey, companyId, groupCode);
                if (PmsMng.CompanyId != 12)
                {
                    //当前用户可以访问的站点
                    var dtuIds = DataPermission.PermisSites(PmsMng.LogUser);
                    foreach (var item in model)
                    {
                        if (dtuIds.Contains(item.Dtuid))
                        {
                            DtuList.Add(item);
                        }
                    }
                }
                else
                {
                    DtuList = model;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
         
            return new SelectList(DtuList, "Dtuid", "DtuidName", groupCode);
        }
    }
}