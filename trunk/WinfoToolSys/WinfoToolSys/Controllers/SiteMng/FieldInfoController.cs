﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Com.Winfotian.Common;
using Com.Winfotian.DB;
using Com.Winfotian.Proxy;
using WinfoToolSys.Pms;
using Proxy;
using Proxy.ServiceWinToolWrite;
using Com.Winfotian.Model;


namespace WinfoToolSys.Controllers.SiteMng
{
    public class FieldInfoController : Controller
    {
        //
        // GET: /FieldInfo/


        public ActionResult Index()
        {
            ViewBag.CompanyList = ServcieTool.CrmServiceGetInstance.GetCompanyLists("", "", PmsMng.ActiveKey);
            return View();
        }

        public ActionResult AddFieldDescBatch(string Oper, string Dtuid)
        {
            List<Proxy.ServiceWinToolRead.T_DTU_FieldDesc> list = ServcieTool.WinToolServiceReadInstance.GetFiledListByDtuid(PmsMng.ActiveKey, Dtuid);
            if (Oper == "Add")
            {
                ViewBag.Oper = " <input type='button' class='buttonVer2' value='批量添加' onclick='FiledMng.AddFiledBatch()' />";
            }
            else
            {
                ViewBag.Oper = " <input type='button' class='buttonVer2' value='批量修改' onclick='FiledMng.UpdateFiledBatch()' />";
            }
            ViewBag.Fields = list;
            //根据dtuid获取字段描述列
            return View();
        }

        public string AddFieldDescBatchOper(string FiledArr)
        {
            StringBuilder rlst = new StringBuilder();
            rlst.Clear().Append("false");
            try
            {
                List<Proxy.ServiceWinToolWrite.T_DTU_FieldDesc> list = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<Proxy.ServiceWinToolWrite.T_DTU_FieldDesc>>(FiledArr);
                if (list != null && list.Count > 0)
                    if (ServcieTool.WinToolServiceWriteInstance.AddDtuFiledDescBatch(PmsMng.ActiveKey, PmsMng.LogUser, list))
                    {
                        rlst.Clear().Append("true");
                    }
            }
            catch (Exception ex)
            { LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex); }
            return rlst.ToString();
        }
        //获取字段信息列表
        public JsonResult GetFiledList(string Company, string Group, string SiteName)
        {
            var list = new List<Proxy.ServiceWinToolRead.T_DTU_FieldDesc>();
            try
            {
                var AllList = ServcieTool.WinToolServiceReadInstance.GetFiledList(PmsMng.ActiveKey, Company, Group, SiteName);
                if (PmsMng.CompanyId != 12)
                {
                    List<string> PerSites = DataPermission.PermisSites(PmsMng.LogUser);
                    foreach (var a in AllList)
                    {
                        if (PerSites.Contains(a.Dtuid))
                        {
                            list.Add(a);
                        }
                    }
                }
                else
                {
                    list = AllList;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return Json(list);
        }
        //获取字段信息详细
        public ActionResult FieldInfoDetail(string Oper, string ComId, string FieldName)
        {
            T_DTU_FieldDescEX TE = new T_DTU_FieldDescEX();
            StringBuilder OperStr = new StringBuilder();
            try
            {
                Proxy.ServiceWinToolRead.T_DTU_FieldDesc model = ServcieTool.WinToolServiceReadInstance.GetFiledById(PmsMng.ActiveKey, ComId, FieldName);
                TE.ColName = model.ColName;
                TE.Dtuid = model.Dtuid;
                TE.FieldDesc = model.FieldDesc;
                TE.FieldName = model.FieldName;
                TE.FieldShortDesc = model.FieldShortDesc;
                TE.FieldType = model.FieldType;
                TE.FieldUnit = model.FieldUnit;
                TE.Highlimit = model.Highlimit;
                TE.Hihilimit = model.Hihilimit;
                TE.Id = model.Id;
                TE.IsAlert = model.IsAlert;
                TE.IsCollect = model.IsCollect;
                TE.IsShow = model.IsShow;
                TE.KeyValues = model.KeyValues;
                TE.Lololimit = model.Lololimit;
                TE.Lowlimit = model.Lowlimit;
                TE.OrderId = model.OrderId;
                TE.ParentId = model.ParentId;
                TE.UpdateFlag = model.UpdateFlag;
                TE.ValueInOrOut = model.ValueInOrOut;
                TE.ValueMax = model.ValueMax;
                TE.ValueMin = model.ValueMin;
                TE.Oper = Oper;
                switch (Oper)
                {
                    case "Show":
                        break;
                    case "Edit":
                        OperStr.Append("<input type='button' class='buttonVer2' value='修改' onclick='FiledMng.EditFiled()' />");
                        break;
                    case "Add":
                        OperStr.Append(@"""<input type='button' class='buttonVer2' value='添加' onclick='FiledMng.AddFiled()'/>""");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            OperStr.Insert(0, "\"");
            OperStr.Append("\"");
            //用户操作按钮
            ViewBag.Oper = OperStr.ToString();
            //用户添加配置权限
            return View(TE);
        }

        //添加
        public ActionResult ShowAddFiled(string CompanyId, string Group)
        {
            List<Proxy.ServiceWinToolRead.T_Dtu_Ex> list = ServcieTool.WinToolServiceReadInstance.GetSite(PmsMng.ActiveKey, CompanyId, "", "", false);
            ViewBag.DtuList = list;
            return View();
        }

        public string AddFiled(Proxy.ServiceWinToolWrite.T_DTU_FieldDesc TE)
        {
            string rlst = "false";
            try
            {
                if (ServcieTool.WinToolServiceWriteInstance.AddFiled(PmsMng.ActiveKey, PmsMng.LogUser, TE))
                {
                    rlst = "true";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rlst;
        }

        //编辑
        public string EditFiled(Proxy.ServiceWinToolWrite.T_DTU_FieldDesc TE)
        {
            string rlst = "false";
            try
            {
                if (DataPermission.IsUserCanUpdateSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.EditFiled(Pms.PmsMng.ActiveKey, PmsMng.LogUser, TE))
                    {
                        rlst = "true";
                    }
                }
                else
                {
                    rlst = "4";
                }
            }
            catch (Exception ex)
            {

                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rlst;
        }

        //删除配置
        public string DeleteFiled(string id)
        {
            string rslt = "false";
            try
            {
                if (DataPermission.IsUserCanDeleteSite())
                {
                    if (ServcieTool.WinToolServiceWriteInstance.DeleteFiledd(PmsMng.ActiveKey, PmsMng.LogUser, id))
                    {
                        rslt = "true";
                    }
                }
                else
                {
                    rslt = "4";
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), PmsMng.LogUser, ex);
            }
            return rslt;
        }
    }
}