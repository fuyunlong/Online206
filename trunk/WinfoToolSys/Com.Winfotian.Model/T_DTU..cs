﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //站点无线终端基本信息
    // 1、编号生成根据“区号+公司号”模糊搜索截取后面三位，然后最大值+1，得到新编号
    [Serializable]
    [DataContract]
    public class T_DTU
    {

        /// <summary>
        /// 无线终端编号
        /// </summary>		
        [DataMember]
        public string Dtuid
        {
            set;
            get;
        }
        /// <summary>
        /// DtuidName
        /// </summary>		
        [DataMember]
        public string DtuidName
        {
            set;
            get;
        }
        /// <summary>
        /// 调压站品牌
        /// </summary>		
        [DataMember]
        public string Skidbrand
        {
            set;
            get;
        }
        /// <summary>
        /// 调压供应商
        /// </summary>		
        [DataMember]
        public string Supplier
        {
            set;
            get;
        }
        /// <summary>
        /// 流量计品牌
        /// </summary>		
        [DataMember]
        public string FlowBrand
        {
            set;
            get;
        }
        /// <summary>
        /// 流量计型号
        /// </summary>		
        [DataMember]
        public string FlowType
        {
            set;
            get;
        }
        /// <summary>
        /// 压力等级(根据压力等级表规范填写)
        /// </summary>		
        [DataMember]
        public string PressureLevel
        {
            set;
            get;
        }
        /// <summary>
        /// 站点具体位置
        /// </summary>		
        [DataMember]
        public string DtuidLocation
        {
            set;
            get;
        }
        /// <summary>
        /// 注册时间
        /// </summary>		
        [DataMember]
        public DateTime RegDate
        {
            set;
            get;
        }
        /// <summary>
        /// 运行时间
        /// </summary>		
        [DataMember]
        public DateTime RunDate
        {
            set;
            get;
        }
        /// <summary>
        /// 经度
        /// </summary>		
        [DataMember]
        public decimal Longitude
        {
            set;
            get;
        }
        /// <summary>
        /// 纬度
        /// </summary>		
        [DataMember]
        public decimal Latitude
        {
            set;
            get;
        }
        /// <summary>
        /// DayFrom
        /// </summary>		
        [DataMember]
        public int DayFrom
        {
            set;
            get;
        }
        /// <summary>
        /// MonthFrom
        /// </summary>		
        [DataMember]
        public int MonthFrom
        {
            set;
            get;
        }
        /// <summary>
        /// DTU登录密码
        /// </summary>		
        [DataMember]
        public string LgPwd
        {
            set;
            get;
        }
        /// <summary>
        /// PhoneNum
        /// </summary>		
        [DataMember]
        public string PhoneNum
        {
            set;
            get;
        }
        /// <summary>
        /// DataInterval
        /// </summary>		
        [DataMember]
        public int DataInterval
        {
            set;
            get;
        }
        /// <summary>
        /// UpLoadInterval
        /// </summary>		
        [DataMember]
        public int UpLoadInterval
        {
            set;
            get;
        }
        /// <summary>
        /// 设备状态
        /// </summary>		
        [DataMember]
        public int Status
        {
            set;
            get;
        }
        /// <summary>
        /// GroupCode
        /// </summary>		
        [DataMember]
        public string GroupCode
        {
            set;
            get;
        }
        /// <summary>
        /// 设备所属公司ID
        /// </summary>		
        [DataMember]
        public string ConfigCode
        {
            set;
            get;
        }
        /// <summary>
        /// ProtocolVersion
        /// </summary>		
        [DataMember]
        public string ProtocolVersion
        {
            set;
            get;
        }
        /// <summary>
        /// OrderId
        /// </summary>		
        [DataMember]
        public int OrderId
        {
            set;
            get;
        }
        /// <summary>
        /// 数据同步标记，修改则增长ID
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
    public class T_Dtu_Ex:T_DTU
    {
        [DataMember]
        public int CompanyId
        {
            set;
            get;
        }
    }
}

