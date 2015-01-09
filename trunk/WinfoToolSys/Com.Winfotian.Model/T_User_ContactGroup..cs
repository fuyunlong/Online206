using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //T_User_ContactGroup
    [Serializable]
    [DataContract]
    public class T_User_ContactGroup
    {

        /// <summary>
        /// 分组关键字与T_User_Contact表关联
        /// </summary>		
        [DataMember]
        public int GroupId
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
        /// 用户Id与T_User_Info表关联
        /// </summary>		
        [DataMember]
        public string UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        [DataMember]
        public string GroupDescpt
        {
            set;
            get;
        }
        /// <summary>
        /// ParentId
        /// </summary>		
        [DataMember]
        public int ParentId
        {
            set;
            get;
        }

    }
}

