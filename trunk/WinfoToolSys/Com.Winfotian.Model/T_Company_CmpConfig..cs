using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Runtime.Serialization;
namespace Com.Winfotian.Model
{
	 	//T_Company_CmpConfig
    [Serializable]
    [DataContract]
    public class T_Company_CmpConfig
	{
   		     
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
		/// ConfigId
        /// </summary>		
           [DataMember]
        public int ConfigId
        {
            set;
            get;
        }        
		/// <summary>
		/// Status
        /// </summary>		
       [DataMember]
        public int Status
        {
            set;
            get;
        }        
		   
	}
}

