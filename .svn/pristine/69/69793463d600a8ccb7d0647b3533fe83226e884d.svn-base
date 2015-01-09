using Com.Winfotian.Proxy;
using Proxy.CrmServiceGet;
using Proxy.CrmServicePost;
using Proxy.ServiceInstance;
using Proxy.ServiceWinToolRead;
using Proxy.ServiceWinToolWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    public static class ServcieTool
    {
       
        public static ICRMSGet CrmServiceGetInstance
        {
            get { return CrmProxyGet.GetProxy(); }
        }

        public static ICRMSPost CrmServicePostInstance
        {
            get { return CrmProxyPost.GetProxy(); }
        }

        public static IWinfoToolServiceRead WinToolServiceReadInstance
        {
            get { return ServiceProxyRead.GetProxy(); }
        }

        public static IWinfoToolServiceWrite WinToolServiceWriteInstance
        {
            get { return ServiceProxyWrite.GetProxy(); }
        }

        public static SmsService.IMSService SmsServiceInstance {
            get { return SmsProxy.GetProxy(); }
        }

       
    }
}
