using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //用户菜单关系表
    [Serializable]
    [DataContract]
    public class T_User_UserMenu
    {

        /// <summary>
        /// 用户唯一编号
        /// </summary>		
       [DataMember]
        public string UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 菜单编号
        /// </summary>		
       [DataMember]
        public string MenuCode
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

    }
}

