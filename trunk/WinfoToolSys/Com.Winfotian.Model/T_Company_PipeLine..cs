using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //T_Company_PipeLine
    [Serializable]
    [DataContract]
    public class T_Company_PipeLine
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
        /// CompanyId
        /// </summary>		
        [DataMember]
        public int CompanyId
        {
            set;
            get;
        }
        /// <summary>
        /// LineName
        /// </summary>		
        [DataMember]
        public string LineName
        {
            set;
            get;
        }
        /// <summary>
        /// 管道口径或线条粗细
        /// </summary>		
        [DataMember]
        public int PipeSize
        {
            set;
            get;
        }
        /// <summary>
        /// 绘制图形类型（1：直线，2：矩形；3：圆）
        /// </summary>		
        [DataMember]
        public int DrawType
        {
            set;
            get;
        }
        /// <summary>
        /// 线条颜色
        /// </summary>		
        [DataMember]
        public string Color
        {
            set;
            get;
        }
        /// <summary>
        /// 是否填充
        /// </summary>		
        [DataMember]
        public int IsFill
        {
            set;
            get;
        }
        /// <summary>
        /// 填充颜色
        /// </summary>		
        [DataMember]
        public string FillColor
        {
            set;
            get;
        }
        /// <summary>
        /// Transparency
        /// </summary>		
        [DataMember]
        public int Transparency
        {
            set;
            get;
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        [DataMember]
        public DateTime CreateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 管道口径
        /// </summary>		
        [DataMember]
        public int LineSize
        {
            set;
            get;
        }
        /// <summary>
        /// 管道类型(钢管、聚乙烯...)
        /// </summary>		
        [DataMember]
        public string LineType
        {
            set;
            get;
        }
        /// <summary>
        /// 压力等级
        /// </summary>		
        [DataMember]
        public string PressureLevel
        {
            set;
            get;
        }
        /// <summary>
        /// PipeLength
        /// </summary>		
        [DataMember]
        public int PipeLength
        {
            set;
            get;
        }
        /// <summary>
        /// 管道深度
        /// </summary>		
        [DataMember]
        public int PipeDepth
        {
            set;
            get;
        }
        /// <summary>
        /// 维护/保养周期
        /// </summary>		
        [DataMember]
        public int RepairInterval
        {
            set;
            get;
        }
        /// <summary>
        /// 所属区域
        /// </summary>		
        [DataMember]
        public string BelongArea
        {
            set;
            get;
        }
        /// <summary>
        /// 竣工时间
        /// </summary>		
        [DataMember]
        public DateTime FinishDate
        {
            set;
            get;
        }
        /// <summary>
        /// 施工单位
        /// </summary>		
        [DataMember]
        public string Contructor
        {
            set;
            get;
        }
        /// <summary>
        /// 施工方联系方式
        /// </summary>		
        [DataMember]
        public string LinkMan
        {
            set;
            get;
        }
        /// <summary>
        /// ProjectCode
        /// </summary>		
        [DataMember]
        public string ProjectCode
        {
            set;
            get;
        }
        /// <summary>
        /// 工程负责人
        /// </summary>		
        [DataMember]
        public string ProjectManager
        {
            set;
            get;
        }
        /// <summary>
        /// 验收人
        /// </summary>		
        [DataMember]
        public string Accepter
        {
            set;
            get;
        }
        /// <summary>
        /// 是否为阀门
        /// </summary>		
        [DataMember]
        public int IsValve
        {
            set;
            get;
        }
        /// <summary>
        /// 阀门影响关联编号(T_DTU_ValveEffect)
        /// </summary>		
        [DataMember]
        public string ValveCode
        {
            set;
            get;
        }
        /// <summary>
        /// 更新时间
        /// </summary>		
        [DataMember]
        public DateTime UpdateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 描述
        /// </summary>		
        [DataMember]
        public string LineDesc
        {
            set;
            get;
        }

    }
}

