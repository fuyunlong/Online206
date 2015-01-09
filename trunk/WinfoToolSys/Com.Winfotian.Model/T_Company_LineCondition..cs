using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //T_Company_LineCondition
    [Serializable]
    [DataContract]
    public class T_Company_LineCondition
    {

        /// <summary>
        /// Id
        /// </summary>		
        [DataMember]
        public int Id
        {
            set;
            get;
        }
        /// <summary>
        /// LineId
        /// </summary>		
        [DataMember]
        public int LineId
        {
            set;
            get;
        }
        /// <summary>
        /// 图形条件颜色(颜色对应参数值，键值对)
        /// </summary>		
        [DataMember]
        public string ActionColor
        {
            set;
            get;
        }
        /// <summary>
        /// 颜色对应参数值，键值对
        /// </summary>		
        [DataMember]
        public decimal ActionValue
        {
            set;
            get;
        }

    }
}

