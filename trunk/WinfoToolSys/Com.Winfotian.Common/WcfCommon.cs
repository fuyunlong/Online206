﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Com.Winfotian.Common
{
    public class WcfCommon
    {
        public static bool LoginCheck(string ActiveKey)
        {
            return true;
            if (Com.Winfotian.ServiceProxy.UserServiceProxy.GetLoginState(ActiveKey, GetWCFRequestIP()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**获取客户端IP**/
        public static string GetWCFRequestIP()
        {
            OperationContext operationContext = OperationContext.Current;
            MessageProperties messageProperties = operationContext.IncomingMessageProperties;
            RemoteEndpointMessageProperty remoteEndpointProperty =
            messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return remoteEndpointProperty.Address;

        }
    }


}