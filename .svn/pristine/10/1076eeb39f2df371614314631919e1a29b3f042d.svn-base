using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Proxy;
using Com.Winfotian.Common;
using System.Web.Script.Serialization;
using Com.Winfotian.DB;
using WinfoToolSys.Pms;
using Proxy.ServiceWinToolWrite;
using Winfotian.Permission.HttpModule;
using Proxy.CrmServiceGet;


namespace WinfoToolSys.Controllers.UserMng
{
    public class UserInfoController : Controller
    {
        //用户信息管理
        public ActionResult Index()
        {
            return View();
        }

        //站点用户管理
        public ActionResult SiteUser()
        {
            return View();
        }

        //根据分组编码查询站点信息
        public JsonResult GetDTUByGroupCode(string companyId, string groupCode)
        {
            List<Proxy.ServiceWinToolRead.T_DTU> list = new List<Proxy.ServiceWinToolRead.T_DTU>();
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
                            list.Add(item);
                        }
                    }
                }
                else
                {
                    list = model;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //根据站点编号查找用户信息
        public JsonResult GetUserInfoByDtuId(string dtuId)
        {
            List<Proxy.CrmServiceGet.T_EmployeeInfo> list = new List<Proxy.CrmServiceGet.T_EmployeeInfo>();
            List<string> ids = new List<string>();
            try
            {
                ids = ServcieTool.WinToolServiceReadInstance.GetUserIdByDTUId(PmsMng.ActiveKey, dtuId);
                list = ServcieTool.CrmServiceGetInstance.QueryListTool(ids, "");
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }

        //获取用户列表
        public JsonResult GetUserList(string companyId, string groupCode)
        {
            List<Proxy.CrmServiceGet.T_UserNewInfo> list = null;
            try
            {
                list = ServcieTool.CrmServiceGetInstance.GetEmployeeInfoTwo(companyId, groupCode, PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            if (list == null)
            {
                list = new List<Proxy.CrmServiceGet.T_UserNewInfo>();
            }
            return Json(list);
        }

        //添加页面
        public ActionResult AddUser(string dtuId)
        {
            ViewBag.SiteId = dtuId;
            return View();
        }

        public ActionResult AddUserV2(string companyId)
        {

            ViewBag.CompanyId = companyId;

            ViewBag.Pwd = new Random().Next(000000, 1000000);
            return View();
        }

        public int AddUserV2Oper(Proxy.CrmServicePost.T_EmployeeInfo obj)
        {
            int rlst = 0;
            try
            {
                obj.IsBuild = 1;
                string Group = obj.EmpSex;
                obj.EmpSex = "";
                obj.DepartName = "";
                obj.RegDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                obj.Remark = "";
                string dd = ServcieTool.CrmServicePostInstance.AddEMployeeInfoTwo(obj, PmsMng.ActiveKey);
                if (dd.ToLower() == "true")
                {
                    if (obj.DepartName != null)
                    {
                        List<string> SiteLit = obj.DepartName.Split(',').ToList();
                        if (SiteLit.Count > 0)
                        {
                            List<Proxy.ServiceWinToolWrite.T_User_UserDtuid> dtus = new List<T_User_UserDtuid>();
                            string logUser = obj.UserName;
                            foreach (var a in SiteLit)
                            {
                                if (a.Length > 0)
                                    dtus.Add(new Proxy.ServiceWinToolWrite.T_User_UserDtuid { Dtuid = a, UserId = logUser, Status = 1 });
                            }
                            ServcieTool.WinToolServiceWriteInstance.AddUserUserDtuid(PmsMng.ActiveKey, PmsMng.LogUser, logUser, dtus);
                            rlst = 1;
                        }
                    }
                }
            }
            catch
            { }
            return rlst;
        }

        //根据用户Id获取用户信息
        public JsonResult GetUserInfo(string id)
        {
            var UserObj = ServcieTool.CrmServiceGetInstance.QueryTool(id, PmsMng.ActiveKey);
            return Json(UserObj);
        }


        /// <summary>
        /// 更新用户信息包括配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateUser(Proxy.CrmServicePost.T_EmployeeInfo obj)
        {
            bool rlst = false;
            try
            {
                if (DataPermission.IsUserCanUpdateUserInfo())
                {
                    obj.IsBuild = 1;
                    List<string> SiteLit = new List<string>();
                    if (obj.DepartName != null)
                        SiteLit = obj.DepartName.Split(',').ToList();
                    List<Proxy.ServiceWinToolWrite.T_User_UserDtuid> dtus = new List<T_User_UserDtuid>();
                    string logUser = obj.UserName;
                    foreach (var a in SiteLit)
                    {
                        if (a.Length > 0)
                            dtus.Add(new Proxy.ServiceWinToolWrite.T_User_UserDtuid { Dtuid = a, UserId = logUser, Status = 1 });
                    }
                    bool aa = ServcieTool.WinToolServiceWriteInstance.AddUserUserDtuid(PmsMng.ActiveKey, PmsMng.LogUser, logUser, dtus);
                    rlst = ServcieTool.CrmServicePostInstance.UpdateTool(obj, Pms.PmsMng.ActiveKey);
                }
                else
                {
                    return 4;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            if (rlst)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除用户信息，包括配置
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int DeleteUserInfo(string UserId, string EmployeeId)
        {
            bool rlst = false;
            try
            {
                if (DataPermission.IsUserCanDeleteUserInfo())
                {
                    rlst = ServcieTool.CrmServicePostInstance.UpdateToolStatus(0, UserId, EmployeeId, PmsMng.ActiveKey);
                    //删除用户所在的配置
                    ServcieTool.WinToolServiceWriteInstance.AddUserUserDtuid(PmsMng.ActiveKey, PmsMng.LogUser, UserId, new List<T_User_UserDtuid>());
                }
                else
                {
                    return 4;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            if (rlst)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ActionResult UserDeatail(string Oper, string UserId)
        {
            var PerList = PermissionWCFProxy.GetUserRolesByDomain(UserId, PmsMng.DomainId);
            //获取用户基本信息
            Proxy.CrmServiceGet.T_EmployeeInfo obj = ServcieTool.CrmServiceGetInstance.QueryTool(UserId, PmsMng.ActiveKey);
            ViewBag.UserObj = obj;
            ViewBag.UserFee = new HtmlCommon().GetUserFeeList(obj.BillCode);//获取计费方式列表
            ViewBag.UserConfig = new HtmlCommon().GetUserConfigList(obj.CCode);//获取用户配置
            ViewBag.ddlCompanyV2 = new HtmlCommon().GetCompanyList(obj.CompanyID.ToString());  //获取当前用户公司及列表
            ViewBag.Departs = new HtmlCommon().GetDepartList(obj.DepartID);//获取当前用户的部门及列表
            int Posid = 0;
            int.TryParse(obj.PosID, out Posid);
            ViewBag.PostionList = new HtmlCommon().GetPosiontionList(obj.DepartID, Posid);
            //获取用户分组名字
            ViewBag.GroupCode = ServcieTool.WinToolServiceReadInstance.GetUserGroupCodeByUserId(PmsMng.ActiveKey, UserId);
            //获取当前用户拥有的站点列表
            ViewBag.UserDtuList = ServcieTool.WinToolServiceReadInstance.GetUserUserDtuListByUserId(Pms.PmsMng.ActiveKey, UserId);
            if (Oper == "Show")
            {
                ViewBag.Oper = "";
            }
            else
            {
                ViewBag.Oper = " <input type='button' class='buttonVer2' value='修改' onclick='UserDTU.UpdateUser()' />";
            }
            return View();
        }

        //添加
        public string Add(string userId, string dtuId)
        {
            string result = "false";
            try
            {
                string[] ids = userId.Split(',');
                foreach (var id in ids)
                {
                    T_User_UserDtuid user = new T_User_UserDtuid();
                    user.UserId = id;
                    user.Dtuid = dtuId;
                    user.Status = 1;
                    if (ServcieTool.WinToolServiceWriteInstance.AddDTUUser(PmsMng.ActiveKey, user))
                    {
                        result = "true";
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //删除
        public string Delete(string userId, string dtuId)
        {
            string result = string.Empty;
            try
            {
                if (Pms.DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.DeleteDTUUser(PmsMng.ActiveKey, userId, dtuId))
                    {
                        result = "删除成功";
                    }
                    else
                    {
                        result = "删除失败";
                    }
                }
                else
                {
                    result = "没有删除权限！";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //根据公司Id查询用户列表
        public JsonResult GetUserListByCompanyId(string companyId, string siteId)
        {
            List<string> ids = new List<string>();
            List<Proxy.CrmServiceGet.T_UserNewInfo> list = new List<T_UserNewInfo>();
            try
            {
                ids = ServcieTool.WinToolServiceReadInstance.GetUserIdByDTUId(PmsMng.ActiveKey, siteId);
                var temp = ServcieTool.CrmServiceGetInstance.GetEmployeeInfoTwo(companyId, "", "");
                foreach (var item in temp)
                {
                    if (!ids.Contains(item.UserId))
                    {
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }
    }
}
