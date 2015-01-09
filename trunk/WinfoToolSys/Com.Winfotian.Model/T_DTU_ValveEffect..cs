﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Com.Winfotian.Model
{
    //T_DTU_ValveEffect
    [Serializable]
    [DataContract]
    public class T_DTU_ValveEffect
    {

        /// <summary>
        /// 站点编号_序号
        /// </summary>		
        [DataMember]
        public string ValveCode
        {
            set;
            get;
        }
        /// <summary>
        /// 关阀时间
        /// </summary>		
        [DataMember]
        public DateTime ClosedTime
        {
            set;
            get;
        }
        /// <summary>
        /// 影响区域
        /// </summary>		
        [DataMember]
        public string EffctArea
        {
            set;
            get;
        }
        /// <summary>
        /// 影响户数
        /// </summary>		
        [DataMember]
        public int EffctUserNum
        {
            set;
            get;
        }
        /// <summary>
        /// 阀门名称
        /// </summary>		
        [DataMember]
        public string ValveName
        {
            set;
            get;
        }
        /// <summary>
        /// Dtuid
        /// </summary>		
        [DataMember]
        public string Dtuid
        {
            set;
            get;
        }
    }

    [Serializable]
    [DataContract]
    public class T_DTU_ValveEffectEx : T_DTU_ValveEffect
    {
        [DataMember]
        public int CompanyId { set; get; }

        [DataMember]
        public string GroupCode { set; get; }
    }
}

