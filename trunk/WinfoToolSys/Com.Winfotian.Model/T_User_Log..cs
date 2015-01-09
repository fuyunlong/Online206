using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //用户登录表
    [Serializable]
    [DataContract]
    public class T_User_Log
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
        /// 用户唯一编号
        /// </summary>		
        [DataMember]
        public string UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 用户上次登录时间
        /// </summary>		
        [DataMember]
        public DateTime LastLogDate
        {
            set;
            get;
        }
        /// <summary>
        /// LastValiTime
        /// </summary>		
        [DataMember]
        public DateTime LastValiTime
        {
            set;
            get;
        }
        /// <summary>
        /// 用户上次登录IP
        /// </summary>		
        [DataMember]
        public string LastIP
        {
            set;
            get;
        }
        /// <summary>
        /// 登录来自（Web,Win）
        /// </summary>		
        [DataMember]
        public string LogFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 用户密码
        /// </summary>		
        [DataMember]
        public string ValidateKey
        {
            set;
            get;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        [DataMember]
        public int IsOnline
        {
            set;
            get;
        }
        /// <summary>
        /// 数据同步标记，修改则增长
        /// </summary>		
        [DataMember]
        public int UpdateFlag
        {
            set;
            get;
        }

    }
}

