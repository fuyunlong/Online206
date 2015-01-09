using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //压力等级表:主要作为界面规范输入
    [Serializable]
    [DataContract]
    public class T_DTU_PressureLevel
    {

        /// <summary>
        /// 压力等级编号（自增长）
        /// </summary>		
        [DataMember]
        public int Id
        {
            set;
            get;
        }
        /// <summary>
        /// 压力等级名称
        /// </summary>		
        [DataMember]
        public string PressureName
        {
            set;
            get;
        }
        /// <summary>
        /// 压力等级描述
        /// </summary>		
        [DataMember]
        public string PressureDesc
        {
            set;
            get;
        }
        /// <summary>
        /// Status
        /// </summary>		
        [DataMember]
        public int Status
        {
            set;
            get;
        }
        /// <summary>
        /// UpdateFlag
        /// </summary>		
        [DataMember]
        public int UpdateFlag
        {
            set;
            get;
        }

    }
}

