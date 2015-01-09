﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //无线终端分组表
    [Serializable]
    [DataContract]
    public class T_DTU_Group
    {

        /// <summary>
        /// 分组编号
        /// </summary>		
        [DataMember]
        public string GroupCode
        {
            set;
            get;
        }
        /// <summary>
        /// 组名称
        /// </summary>		
        [DataMember]
        public string GroupName
        {
            set;
            get;
        }
        /// <summary>
        /// 组描述
        /// </summary>		
        [DataMember]
        public string GroupDesc
        {
            set;
            get;
        }
        /// <summary>
        /// 父编号
        /// </summary>		
        [DataMember]
        public string ParentCode
        {
            set;
            get;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        [DataMember]
        public int Status
        {
            set;
            get;
        }
        /// <summary>
        /// CompanyId
        /// </summary>		
        [DataMember]
        public int CompanyId
        {
            set;
            get;
        }
        /// <summary>
        /// 数据库同步标记，修改则增长
        /// </summary>		
        [DataMember]
        public int UpdateFlag
        {
            set;
            get;
        }

    }
    [Serializable]
    [DataContract]
    public class T_DTU_GroupEx:T_DTU_Group
    {
        [DataMember]
        public string ParentName
        {
            set;
            get;
        }
    }
}

