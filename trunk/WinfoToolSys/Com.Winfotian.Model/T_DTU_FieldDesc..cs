using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //无线终端数据字段描述表：描述各字段，阀值等
    [Serializable]
    [DataContract]
    public class T_DTU_FieldDesc
    {

        /// <summary>
        /// 自动编号
        /// </summary>		
        [DataMember]
        public int Id
        {
            set;
            get;
        }
        /// <summary>
        /// 无线终端编号
        /// </summary>		
        [DataMember]
        public string Dtuid
        {
            set;
            get;
        }
        /// <summary>
        /// 字段采集名称字符串
        /// </summary>		
        [DataMember]
        public string ColName
        {
            set;
            get;
        }
        /// <summary>
        /// 字段名称
        /// </summary>		
        [DataMember]
        public string FieldName
        {
            set;
            get;
        }
        /// <summary>
        /// 字段短描述，用于列名等显示
        /// </summary>		
        [DataMember]
        public string FieldShortDesc
        {
            set;
            get;
        }
        /// <summary>
        /// 字段描述
        /// </summary>		
        [DataMember]
        public string FieldDesc
        {
            set;
            get;
        }
        /// <summary>
        /// 字段单位
        /// </summary>		
        [DataMember]
        public string FieldUnit
        {
            set;
            get;
        }
        /// <summary>
        /// 字段最小值
        /// </summary>		
        [DataMember]
        public decimal ValueMin
        {
            set;
            get;
        }
        /// <summary>
        /// 字段最大值
        /// </summary>		
        [DataMember]
        public decimal ValueMax
        {
            set;
            get;
        }
        /// <summary>
        /// 字段值低报警值
        /// </summary>		
        [DataMember]
        public decimal Lowlimit
        {
            set;
            get;
        }
        /// <summary>
        /// 字段值高报警值
        /// </summary>		
        [DataMember]
        public decimal Highlimit
        {
            set;
            get;
        }
        /// <summary>
        /// 字段值最低报警值
        /// </summary>		
        [DataMember]
        public decimal Lololimit
        {
            set;
            get;
        }
        /// <summary>
        /// 字段值最高报警值
        /// </summary>		
        [DataMember]
        public decimal Hihilimit
        {
            set;
            get;
        }
        /// <summary>
        /// 进出口类型(主要对压力字段用)
        /// </summary>		
        [DataMember]
        public int ValueInOrOut
        {
            set;
            get;
        }
        /// <summary>
        /// 是否报警检查
        /// </summary>		
        [DataMember]
        public int IsAlert
        {
            set;
            get;
        }
        /// <summary>
        /// 是否为采集字段
        /// </summary>		
        [DataMember]
        public int IsCollect
        {
            set;
            get;
        }
        /// <summary>
        /// IsShow
        /// </summary>		
        [DataMember]
        public int IsShow
        {
            set;
            get;
        }
        /// <summary>
        /// 数据库同步标记，修改则增长+1
        /// </summary>		
        [DataMember]
        public int UpdateFlag
        {
            set;
            get;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        [DataMember]
        public int OrderId
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
        /// <summary>
        /// KeyValues
        /// </summary>		
        [DataMember]
        public string KeyValues
        {
            set;
            get;
        }
        /// <summary>
        /// FieldType
        /// </summary>		
        [DataMember]
        public int FieldType
        {
            set;
            get;
        }

    }
    [Serializable]
    [DataContract]
    public class T_DTU_FieldDescEX:T_DTU_FieldDesc
    {
        [DataMember]
        public string Oper
        {
            set;
            get;
        }
    }
}

