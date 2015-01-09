using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
	 	//维护类型表
    [Serializable]
    [DataContract]
    public class T_DTU_RepairType
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
		/// 维护设备名称
        /// </summary>		
           [DataMember]
        public string DTUDevice
        {
            set;
            get;
        }        
		/// <summary>
		/// 具体维护设备内容
        /// </summary>		
           [DataMember]
        public string RepairDesc
        {
            set;
            get;
        }        
		   
	}
}

