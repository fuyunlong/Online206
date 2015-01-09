using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
    //用户菜单资源表
    [Serializable]
    [DataContract]
    public class T_User_Menu
    {

        /// <summary>
        /// 菜单唯一编号
        /// </summary>		
        [DataMember]
        public string MenuCode
        {
            set;
            get;
        }
        /// <summary>
        /// 资源菜单名称
        /// </summary>		
        [DataMember]
        public string MenuName
        {
            set;
            get;
        }
        /// <summary>
        /// 资源菜单描述
        /// </summary>		
        [DataMember]
        public string MenuDesc
        {
            set;
            get;
        }
        /// <summary>
        /// 业务系统编号
        /// </summary>		
        [DataMember]
        public string DomainId
        {
            set;
            get;
        }
        /// <summary>
        /// 父菜单编号
        ///[DataMember] </summary>		
        [DataMember]
        public string ParentCode
        {
            set;
            get;
        }
        /// <summary>
        /// 打开窗体名称
        /// </summary>		
        [DataMember]
        public string OperForm
        {
            set;
            get;
        }
        /// <summary>
        /// 窗体打开目标
        /// </summary>		  
        [DataMember]
        public string TargetName
        {
            set;
            get;
        }
        /// <summary>
        /// 是否需要权限
        /// </summary>		
        [DataMember]
        public int NeedPermission
        {
            set;
            get;
        }
        /// <summary>
        /// 是否显示
        /// </summary>		
        [DataMember]
        public int IsDisplay
        {
            set;
            get;
        }
        /// <summary>
        /// IsMenu
        /// </summary>		
        [DataMember]
        public int IsMenu
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
        /// UpdateFlag
        /// </summary>		
        [DataMember]
        public int UpdateFlag
        {
            set;
            get;
        }

    }
}

