using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //报警信息表,报警状态(0禁用，1未查看、2已查看、3处理中、4搁置、5已处理)
    //一个设备同一报警只有一条报警记录
    [Serializable]
    [DataContract]
    public class T_Alert_Info
    {

        /// <summary>
        /// 报警编号
        /// </summary>		
        [DataMember]
        public int Id
        {
            set;
            get;
        }
        /// <summary>
        /// 站点唯一编号
        /// </summary>		
        [DataMember]
        public string Dtuid
        {
            set;
            get;
        }
        /// <summary>
        /// 报警简述
        /// </summary>		
        [DataMember]
        public string AlertDesc
        {
            set;
            get;
        }
        /// <summary>
        /// 报警发生时间
        /// </summary>		
        [DataMember]
        public DateTime AlertTime
        {
            set;
            get;
        }
        /// <summary>
        /// 报警等级（1、2、3）
        /// </summary>		
        [DataMember]
        public int AlertLevel
        {
            set;
            get;
        }
        /// <summary>
        /// FieldName
        /// </summary>		
        [DataMember]
        public string FieldName
        {
            set;
            get;
        }
        /// <summary>
        /// FieldValue
        /// </summary>	
        [DataMember]
        public decimal FieldValue
        {
            set;
            get;
        }
        /// <summary>
        /// 报警短信内容
        /// </summary>		
        [DataMember]
        public string SMSContent
        {
            set;
            get;
        }
        /// <summary>
        /// 报警类型
        /// </summary>		
        [DataMember]
        public int AlertType
        {
            set;
            get;
        }
        /// <summary>
        /// 报警通知电话号码
        /// </summary>		
        [DataMember]
        public string PhoneNum
        {
            set;
            get;
        }
        /// <summary>
        /// 报警状态
        /// </summary>		
        [DataMember]
        public int AlertState
        {
            set;
            get;
        }
        /// <summary>
        /// RecentTime
        /// </summary>		
        [DataMember]
        public DateTime RecentTime
        {
            set;
            get;
        }
        /// <summary>
        /// IsReply
        /// </summary>		
        [DataMember]
        public int IsReply
        {
            set;
            get;
        }
        /// <summary>
        /// IsSend
        /// </summary>		
        [DataMember]
        public int IsSend
        {
            set;
            get;
        }
        /// <summary>
        /// CurSendTimes
        /// </summary>		
        [DataMember]
        public int CurSendTimes
        {
            set;
            get;
        }
        /// <summary>
        /// CurAlertCount
        /// </summary>		
        [DataMember]
        public int CurAlertCount
        {
            set;
            get;
        }
        /// <summary>
        /// SendTimes
        /// </summary>		
        [DataMember]
        public int SendTimes
        {
            set;
            get;
        }
        /// <summary>
        /// AlertCount
        /// </summary>		
        [DataMember]
        public int AlertCount
        {
            set;
            get;
        }
        /// <summary>
        /// 数据同步标记，修改则加1
        /// </summary>		
        [DataMember]
        public int UpdateFlag
        {
            set;
            get;
        }

    }
}

