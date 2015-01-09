using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //用户账户信息表余额等
    [Serializable]
    [DataContract]
    public class T_User_Account
    {

        /// <summary>
        /// 自增长编号
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
        /// 用户余额
        /// </summary>		
        [DataMember]
        public string UserBalance
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
        /// CreditGrade
        /// </summary>		
        [DataMember]
        public string CreditGrade
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

