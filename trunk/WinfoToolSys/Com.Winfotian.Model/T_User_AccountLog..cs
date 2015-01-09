using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //账户变更记录表
    [Serializable]
    [DataContract]
    public class T_User_AccountLog
    {

        /// <summary>
        /// 自动增长编号
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
        /// 交易发生来自（1充值、2短信、3其他）
        /// </summary>		
        [DataMember]
        public int OrderFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 交易发生来自的编号
        /// </summary>		
        [DataMember]
        public string OrderId
        {
            set;
            get;
        }
        /// <summary>
        /// 操作类型（1充值、2消费）
        /// </summary>		
        [DataMember]
        public int OrderType
        {
            set;
            get;
        }
        /// <summary>
        /// 变更的钱
        /// </summary>		
        [DataMember]
        public decimal ModMoney
        {
            set;
            get;
        }
        /// <summary>
        /// OrderNum
        /// </summary>		
        [DataMember]
        public int OrderNum
        {
            set;
            get;
        }
        /// <summary>
        /// 操作发生人员
        /// </summary>		

        [DataMember]
        public string Operator
        {
            set;
            get;
        }
        /// <summary>
        /// 操作发生变更的IP地址
        /// </summary>		
        [DataMember]
        public string OperIP
        {
            set;
            get;
        }
        /// <summary>
        /// 操作发生的时间
        /// </summary>		
        [DataMember]
        public DateTime OperTime
        {
            set;
            get;
        }
        /// <summary>
        /// 记录信息，充值序列号；消费记录短信ID
        /// </summary>		
        [DataMember]
        public string OrderDesc
        {
            set;
            get;
        }

    }
}

