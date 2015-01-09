﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Com.Winfotian.Model;
using System.EnterpriseServices;


namespace Com.Winfotian.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWinfoToolServiceRead”。
    /// <summary>
    /// 读取接口
    /// </summary>
    [ServiceContract]
    public interface IWinfoToolServiceRead
    {
        [OperationContract]
        List<T_Company_Config> GetConfigList(string ActiveKey, string ConfigId);
        [OperationContract]
        List<int> GetCompanyConfig(string ActiveKey, string CompanyId);
        [OperationContract]
        [Description("获取客户端类型列表")]
        void GetClientTypeList(string ActiveKey, string TypeId);
        [OperationContract]
        [Description("获取站点信息")]
        List<T_Dtu_Ex> GetSite(string ActiveKey, string Company, string Group, string SiteName, bool IsOdor);
        [OperationContract]
        [Description("获取站点信息根据Id")]
        T_Dtu_Ex GetSiteById(string ActiveKey, string DtuId);
        [OperationContract]
        [Description("获取加臭站点")]
        T_Dtu_Ex GetMalodorSiteById(string ActiveKey, string DtuId);
        [OperationContract]
        List<T_DTU_GroupEx> GetSiteGroupByCompanyId(string activeKey, string companyId);
        [OperationContract]
        T_DTU_Group GetGroupDeatail(string ActiveKey, string GroupId);
        [OperationContract]
        List<T_DTU_FieldDesc> GetFiledList(string ActiveKey, string Company, string Group, string SiteName);
        [OperationContract]
        T_DTU_FieldDesc GetFiledById(string ActiveKey, string Id, string FieldName);
        [OperationContract]
        List<T_User_GroupExt> GetGroupListByCompanyID(string ActiveKey, string CompanyId);
        [OperationContract]
        T_User_GroupExt GetGroupByCode(string ActiveKey, string GroupCode);

        #region 用户站点配置
        [OperationContract]
        List<T_DTU> GetSiteByCompanyIdAndGroupCode(string activeKey, string companyId, string groupCode);
        [OperationContract]
        List<string> GetUserIdByDTUId(string ActiveKey, string DTUId);
        [OperationContract]
        List<T_User_Info> GetUserInfroByCompanyId(string ActiveKey, string CompanyId, string DTUId);
        #endregion

        #region 用户配置

        [OperationContract]
        List<T_User_Config> GetUserConfigListByName(string ActiveKey, string ConfigName);
        [OperationContract]
        T_User_Config GetUserConfigByCode(string ActiveKey, string CCode);
        [OperationContract]
        List<T_User_Config> GetUserCoinfigList(string ActiveKey);
        #endregion

        #region DtuConfig
        //获取dtuconfig列表
        [OperationContract]
        List<T_DTU_Config> DtuConfigListV2(string ActiveKey);
        /// <summary>
        /// get Dtuconfig List by sitename or cType
        /// </summary>
        [OperationContract]
        List<T_DTU_Config_Ext> DtuConfigList(string ActiveKey, string siteName, params int[] cType);
        #endregion

        #region 压力等级
        [OperationContract]
        List<T_DTU_PressureLevel> GetPressureLevelList(string ActiveKey, string levelName);
        [OperationContract]
        T_DTU_PressureLevel GetOnePressureLevel(string ActiveKey, string id);
        #endregion

        #region 协议版本
        [OperationContract]
        Dictionary<string, string> GetVerList(string ActiveKey);
        #endregion

        #region 阀门影响
        [OperationContract]
        List<T_DTU_ValveEffect> GetInfluencList(string ActiveKey, string siteId);
        [OperationContract]
        T_DTU_ValveEffectEx GetInfluencByCode(string ActiveKey, string valveCode);
        #endregion

        #region 数据转发
        [OperationContract]
        List<T_DTU_DataTransmit> GetTransSetList(string ActiveKey, string Company);
        [OperationContract]
        T_DTU_DataTransmit GetTransById(string ActiveKey, string TransId);
        [OperationContract]
        List<T_DTU_DataTransmit> GetTransVerList(string ActiveKey);
        #endregion

        #region 站点配置
        [OperationContract]
        List<T_DTU_Config> GetDTUConfigListByConfigName(string ActiveKey, string configName);
        [OperationContract]
        List<T_DTU_Config> GetDtuMalodorListByConfigName(string ActiveKey, string configName);
        [OperationContract]
        T_DTU_Config GetDtuConfigByCode(string ActiveKey, string conifgCode);


        #endregion

        #region 重要设备管理
        [OperationContract]
        List<T_DTU_Device> GetVipDeviceList(string ActiveKey, string SiteName);
        [OperationContract]
        T_DTU_Device GetVipDeviceById(string ActiveKey, string Id);
        [OperationContract]
        T_DTU_Device_Ex GetVipDeviceExById(string ActiveKey, string Id);
        [OperationContract]
        List<T_Dtu_Ex> GetSiteListByComId(string ActiveKey, string ComId);
        [OperationContract]
        Dictionary<string, string> GetDTUListByCompanyId(string ActiveKey, string CompanyId);
        #endregion

        #region 心跳记录查询
        [OperationContract]
        List<T_DTU> GetDTUList(string ActiveKey);
        #endregion

        #region 报警记录查询
        [OperationContract]
        List<T_Alert_Info> GetAlertListBySiteIdAndDate(string ActiveKey, string siteId, DateTime begain, DateTime end);
        #endregion

        #region 站点分组管理
        [OperationContract]
        T_DTU_GroupEx GetSiteGroupByCode(string ActiveKey, string groupCode);
        [OperationContract]
        List<T_User_UserGroup> GetUserUserGroupList(string ActiveKey, string GroupCode);
        #endregion

        #region 角色管理
        [OperationContract]
        List<T_User_Role> GetRoleList(string ActiveKey, string RoleName);
        [OperationContract]
        T_User_Role GetRoleByCode(string ActiveKey, string RoleCode);
        [OperationContract]
        bool AddRole(string ActiveKey, string User, T_User_Role role);
        [OperationContract]
        bool UpdateRole(string ActiveKey, string User, T_User_Role role);
        [OperationContract]
        bool DelRole(string ActiveKey, string User, string RoleCode);

        [OperationContract]
        string GetRoleByUserId(string activeKey, string UserId);
        #endregion

        [OperationContract]
        List<string> GetDTUByUserId(string activeKey, string userId);

        [OperationContract]
        Dictionary<string, string> GetUserUserDtuListByUserId(string activeKey, string userId);

        [OperationContract]
        string GetUserGroupCodeByUserId(string activeKey, string UserId);
       
        [OperationContract]
        bool IsGroupHasSite(string activeKey, string groupCode);
        #region 字段管理
        [OperationContract]
        List<T_DTU_FieldDesc> GetFiledBySite(string activeKey, string siteId);

        [OperationContract]
        List<T_DTU_FieldDesc> GetFiledListByDtuid(string ActiveKey, string Dtuid);
        #endregion
    }
}
