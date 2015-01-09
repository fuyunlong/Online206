using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Com.Winfotian.Model;
using System.Text;
using WinfoToolSys.Pms;
using Proxy;
using Proxy.CrmServicePost;

namespace WinfoToolSys.Controllers.ClientMng
{
    public class ClientInfoController : Controller
    {
        //公司列表
        public ActionResult ClientInfo()
        {
            return View();
        }

        //添加、修改详细、页面
        public ActionResult ClientDetail(string oper, string companyId)
        {
            StringBuilder sb = new StringBuilder();
            Proxy.CrmServiceGet.T_CompanyInfos model = null;

            switch (oper)
            {
                case "Show":
                    ViewBag.Oper = "Show";
                    break;
                case "Edit":
                    ViewBag.Oper = "Edit";
                    sb.Append("<input type='button' class='buttonVer2' value='修改' onclick='ClientMng.Update();' />");
                    break;
                case "Add":
                    ViewBag.Oper = "Add";
                    sb.Append("<input type='button' class='buttonVer2' value='添加' onclick='ClientMng.Add();' />");
                    break;
                default:
                    break;
            }
            sb.Insert(0, "\"");
            sb.Append("\"");
            ViewBag.Button = sb.ToString();

            try
            {
                model = ServcieTool.CrmServiceGetInstance.GetCompanyInfoList(companyId, PmsMng.ActiveKey);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), Pms.PmsMng.LogUser, ex);
            }
            return View(model);
        }

        //添加
        public string Add(T_Companys model)
        {
            string result = "false";
            List<string> list = new List<string>();
            foreach (var item in model.Province.Split(','))
            {
                list.Add(item);
            }

            T_Companys company = new T_Companys();
            company.CompanyName = model.CompanyName;
            company.LinkPerson = model.LinkPerson;
            company.Telphone = model.Telphone;
            company.Email = model.Email;
            company.FaxTel = model.FaxTel;
            company.CmpWebSite = model.CmpWebSite;
            company.CmpAddress = model.CmpAddress;
            company.MobilePhone = model.MobilePhone;
            company.Remark = model.Remark;
            company.ParentCompanyID = model.ParentCompanyID;
            company.CityID = model.CityID;
            company.CityName = model.CityName;
            company.Status = true;

            try
            {
                result = ServcieTool.CrmServicePostInstance.RegisterCompanyInfo(company, PmsMng.ActiveKey);
                if (result == "注册成功!")
                {
                    ServcieTool.CrmServicePostInstance.AddCompanyConfig(model.CompanyName, list, PmsMng.ActiveKey);
                    //添加分组
                    Proxy.ServiceWinToolWrite.T_DTU_Group group = new Proxy.ServiceWinToolWrite.T_DTU_Group();
                    group.GroupCode = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                    group.GroupName = "默认分组";
                    group.GroupDesc = "默认分组";
                    group.ParentCode = "0";
                    group.Status = 1;
                    group.CompanyId = model.CompanyID;
                    group.UpdateFlag = 1;
                    ServcieTool.WinToolServiceWriteInstance.AddSiteGroup(PmsMng.ActiveKey, group);
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //修改
        public string Update(T_Companys model)
        {
            string result = string.Empty;
            List<string> list = new List<string>();
            foreach (var item in model.Province.Split(','))
            {
                list.Add(item);
            }

            T_Companys company = new T_Companys();
            company.CompanyID = model.CompanyID;
            company.CompanyName = model.CompanyName;
            company.LinkPerson = model.LinkPerson;
            company.Telphone = model.Telphone;
            company.Email = model.Email;
            company.FaxTel = model.FaxTel;
            company.CmpWebSite = model.CmpWebSite;
            company.CmpAddress = model.CmpAddress;
            company.MobilePhone = model.MobilePhone;
            company.Remark = model.Remark;
            company.ParentCompanyID = model.ParentCompanyID;
            company.CityID = model.CityID;
            company.CityName = model.CityName;
            company.Status = true;

            try
            {
                if (Pms.DataPermission.IsUserCanUpdateUserInfo())
                {
                    result = ServcieTool.CrmServicePostInstance.ChangeCompanyInfo(company, PmsMng.ActiveKey);
                    if (result == "更新成功")
                    {
                        //先删除再新增配置信息
                        ServcieTool.CrmServicePostInstance.DeleteCompanyConfig(model.CompanyID.ToString(), PmsMng.ActiveKey);
                        ServcieTool.CrmServicePostInstance.AddCompanyConfig(model.CompanyName, list, PmsMng.ActiveKey);
                    }
                }
                else
                {
                    result = "没有修改权限！";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return result;
        }

        //删除
        public string Delete(string companyID)
        {
            string result = string.Empty;

            try
            {
                if (Pms.DataPermission.IsUserCanDeleteUserInfo())
                {
                    if (ServcieTool.CrmServicePostInstance.ChangeCompanyStatus(companyID, 0, PmsMng.ActiveKey))
                    {
                        ServcieTool.CrmServicePostInstance.DeleteCompanyConfig(companyID, PmsMng.ActiveKey);
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
    }
}
