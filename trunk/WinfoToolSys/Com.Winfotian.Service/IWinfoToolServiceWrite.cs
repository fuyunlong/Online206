﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Com.Winfotian.Model;

namespace Com.Winfotian.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWinfoToolServiceWrite”。
    [ServiceContract]
    public interface IWinfoToolServiceWrite
    {
        [OperationContract]
        void DoWork();

        #region 站点管理
        [OperationContract]
        bool UpdateSite(string ActiveKey, string UserId, T_DTU dtu);
        [OperationContract]
        bool AddSite(string ActiveKey, string UserId, T_DTU dtu);

        [OperationContract]
        List<string> GenerateSiteCode(string ActiveKey, string UserId, string CompanyId, int Num);
        [OperationContract]
        bool DeleteSite(string ActiveKey, string DtuId, string UserId);
        #endregion

        [OperationContract]
        EmReStatus AddLevel(string ActiveKey, string UserId, T_DTU_PressureLevel model);

        #region 字段管理
        //添加字段
        [OperationContract]
        bool AddFiled(string ActiveKey, string UserId, T_DTU_FieldDesc model);

        //更改字段
        [OperationContract]
        bool EditFiled(string ActiveKey, string UserId, T_DTU_FieldDesc model);
        //删除字段
        [OperationContract]
        bool DeleteFiledd(string ActiveKey, string userId, string id);
        [OperationContract]
        bool AddDtuFiledDescBatch(string ActiveKey, string userId, List<T_DTU_FieldDesc> list);



        #endregion

        #region 阀门管理
        [OperationContract]
        bool AddInfluence(string ActiveKey, T_DTU_ValveEffect model);
        [OperationContract]
        bool UpdateInfluence(string ActiveKey, T_DTU_ValveEffect model);
        [OperationContract]
        bool DeleteInfluence(string ActiveKey, string valveCode);
        #endregion

        #region 用户分组管理
        //添加用户分组
        [OperationContract]
        bool AddGroup(string ActiveKey, T_User_Group model);
        //修改用户分组
        [OperationContract]
        bool UpdateGroup(string ActiveKey, T_User_Group model);
        //删除分组
        [OperationContract]
        bool DeleteGroup(string ActiveKey, string groupCode);
        #endregion

        #region 用户配置管理
        [OperationContract]
        bool AddUserConfig(string ActiveKey, T_User_Config model);

        [OperationContract]
        bool UpdateUserConfig(string ActiveKey, T_User_Config model);

        [OperationContract]
        bool DeleteUserConfig(string ActiveKey, string CCode);
        #endregion

        #region 站点用户管理
        [OperationContract]
        bool AddDTUUser(string ActiveKey, T_User_UserDtuid model);
        [OperationContract]
        bool DeleteDTUUser(string ActiveKey, string UserId, string Dtuid);
        #endregion

        #region 站点配置
        [OperationContract]
        bool AddDtuConfig(string ActiveKey, T_DTU_Config model);
        [OperationContract]
        bool UpdateDtuConfig(string ActiveKey, T_DTU_Config config);
        [OperationContract]
        bool DeleteDtuConfig(string ActiveKey, string configCode);
        #endregion

        #region 站点分组管理
        [OperationContract]
        bool AddSiteGroup(string ActiveKey, T_DTU_Group group);
        [OperationContract]
        bool UpdateSiteGroup(string ActiveKey, T_DTU_Group model);
        [OperationContract]
        bool DeleteSiteGroup(string ActiveKey, string groupCode);

        #endregion

        #region 重要设备
        [OperationContract]
        bool AddVIPDevice(string ActiveKey, T_DTU_Device model);
        [OperationContract]
        bool UpdateVIPDevice(string ActiveKey, T_DTU_Device model);
        [OperationContract]
        bool DeleteVIPDevice(string ActiveKey, int id);
        #endregion

        #region 转发
        [OperationContract]
        bool AddTrans(string ActiveKey, string UserId, T_DTU_DataTransmit model);

        [OperationContract]
        bool DeleteTrans(string ActiveKey, string Id);

        [OperationContract]
        bool UpdateTrans(string ActiveKey, string UserId, T_DTU_DataTransmit model);
        #endregion

        #region 压力等级管理
        [OperationContract]
        bool AddPreLevel(string ActiveKey, T_DTU_PressureLevel model);
        [OperationContract]
        bool UpdatePreLevel(string ActiveKey, T_DTU_PressureLevel model);
        [OperationContract]
        bool DeletePreLevel(string ActiveKey, string id);
        #endregion

        #region 用户角色管理
        [OperationContract]
        bool AddUserRole(string ActiveKey, string UserId, T_User_Role UserRole);
        [OperationContract]
        bool UpdateUserRole(string ActiveKey, string UserId, T_User_Role UserRole);
        [OperationContract]
        bool DelUserRole(string ActiveKey, string UserId, string RoleCode);
        #endregion

        [OperationContract]
        bool AddUserUserGroup(string ActiveKey, T_User_UserGroup UserUserGrop);
        [OperationContract]
        bool AddUserUserRole(string ActiveKey, T_User_UserRole UserUserRole);
        [OperationContract]
        bool AddUserUserDtuid(string ActiveKey, string OperUser, string UserId, List<T_User_UserDtuid> dtus);
    }
}
