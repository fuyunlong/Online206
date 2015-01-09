using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //用户操作日志
    [Serializable]
    [DataContract]
    public class T_User_OperLog
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
        /// 操作者
        /// </summary>		
        [DataMember]
        public string Operator
        {
            set;
            get;
        }
        /// <summary>
        /// 操作时间
        /// </summary>		
        [DataMember]
        public DateTime OperatorTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作类型
        /// </summary>		
        [DataMember]
        public int OperType
        {
            set;
            get;
        }
        /// <summary>
        /// 操作功能
        /// </summary>		
        [DataMember]
        public string OperFunc
        {
            set;
            get;
        }
        /// <summary>
        /// 操作功能编码
        /// </summary>		
        [DataMember]
        public string OperFunCode
        {
            set;
            get;
        }
        /// <summary>
        /// 操作消息
        /// </summary>		
        [DataMember]
        public string OperMsg
        {
            set;
            get;
        }
        /// <summary>
        /// 操作结果(0失败，1成功)
        /// </summary>		
        [DataMember]
        public int OperResult
        {
            set;
            get;
        }

    }
}

