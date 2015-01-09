using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //T_User_UserContact
    [Serializable]
    [DataContract]
    public class T_User_UserContact
    {

        /// <summary>
        /// 用户编号,一个用户可能有多个联系方式(ContactId)
        /// </summary>		
        [DataMember]
        public string UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 与通讯簿中ContactId关联
        /// </summary>		
        [DataMember]
        public int ContactId
        {
            set;
            get;
        }
        /// <summary>
        /// 用户状态，如“启用/停用”
        /// </summary>		
        [DataMember]
        public int Status
        {
            set;
            get;
        }

    }
}

