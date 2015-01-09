using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //T_Company_LineAction
    [Serializable]
    [DataContract]
    public class T_Company_LineAction
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
        /// LineId
        /// </summary>	
        [DataMember]
        public int LineId
        {
            set;
            get;
        }
        /// <summary>
        /// 关联参数（与SCADA站点关联：站点编号+下划线+字段名称）
        /// </summary>		
        [DataMember]
        public string ReferSite
        {
            set;
            get;
        }
        /// <summary>
        /// 关联参数（与SCADA站点关联：站点字段名称）
        /// </summary>		
        [DataMember]
        public string ReferSiteParam
        {
            set;
            get;
        }
        /// <summary>
        /// 参数最大值，大于该值时发生颜色变化
        /// </summary>		
        [DataMember]
        public decimal MaxValue
        {
            set;
            get;
        }
        /// <summary>
        /// 参数最小值，小于等于该值时改变颜色
        /// </summary>		
        [DataMember]
        public decimal MinValue
        {
            set;
            get;
        }
        /// <summary>
        /// 是否颜色变化（当超过阀值时的颜色）
        /// </summary>		
        [DataMember]
        public int ColorEnable
        {
            set;
            get;
        }
        /// <summary>
        /// 当大于最大值，或小于等于最小值时显示的颜色（格式：#001133）
        /// </summary>		
        [DataMember]
        public string ActionColor
        {
            set;
            get;
        }
        /// <summary>
        /// 是否图形闪烁(当大于最大值，或小于等于最小值时闪烁)
        /// </summary>		
        [DataMember]
        public int GlintEnable
        {
            set;
            get;
        }
        /// <summary>
        /// 闪烁颜色1
        /// </summary>		
        [DataMember]
        public string GlintColor1
        {
            set;
            get;
        }
        /// <summary>
        /// 闪烁颜色2
        /// </summary>		
        [DataMember]
        public string GlintColor2
        {
            set;
            get;
        }
        /// <summary>
        /// 闪烁颜色3
        /// </summary>		
        [DataMember]
        public string GlintColor3
        {
            set;
            get;
        }
        /// <summary>
        /// 图形是否尺寸变化（液位高度等使用）
        /// </summary>		
        [DataMember]
        public int RangeEnable
        {
            set;
            get;
        }
        /// <summary>
        /// 矩形最小值
        /// </summary>		
        [DataMember]
        public decimal RangeMin
        {
            set;
            get;
        }
        /// <summary>
        /// 矩形最大值
        /// </summary>		
        [DataMember]
        public decimal RangeMax
        {
            set;
            get;
        }

    }
}

