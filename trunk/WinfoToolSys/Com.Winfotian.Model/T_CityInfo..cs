using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //城市信息
    [Serializable]
    [DataContract]
    public class T_CityInfo
    {

        /// <summary>
        /// 城市编号(自增长)
        /// </summary>		
        [DataMember]
        public int CityId
        {
            set;
            get;
        }
        /// <summary>
        /// 省份名称
        /// </summary>		
        [DataMember]
        public string Province
        {
            set;
            get;
        }
        /// <summary>
        /// 城市名称
        /// </summary>		
        [DataMember]
        public string CityName
        {
            set;
            get;
        }
        /// <summary>
        /// 城市区号
        /// </summary>		
        [DataMember]
        public string PhoneCode
        {
            set;
            get;
        }
        /// <summary>
        /// 城市邮政编码
        /// </summary>		
        [DataMember]
        public string PostCode
        {
            set;
            get;
        }

    }
}

