﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel;
using System.Web;
using Proxy.ServiceWinToolRead;
using Proxy;
using Com.Winfotian.Common;

namespace Com.Winfotian.Proxy
{
    internal class ServiceProxyRead : RealProxy
    {

        public ServiceProxyRead()
            : base(typeof(IWinfoToolServiceRead))
        {
        }

        private static EndpointAddress GetEndPointAddress()
        {
            string url = ToolHelper.ReadINIValue("Services", "WinToolUrl", "A4C662002B6E21EEEBA85B535515D7E62011AD3EAA3AF292CFB42014F8A8946BAB");
            EndpointAddress endpoint = new EndpointAddress( Com.Winfotian.Encrypts.DESEncrypt.Decrypt(url) + "/WinfoToolServiceRead.svc");
            return endpoint;
        }

        public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
        {
            IMethodReturnMessage methodReturn = null;
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            var client = new ChannelFactory<IWinfoToolServiceRead>(ServiceBindings.GetBasicHttpBinding(), GetEndPointAddress());
            var channel = client.CreateChannel();
            try
            {
                object[] copiedArgs = Array.CreateInstance(typeof(object), methodCall.Args.Length) as object[];
                methodCall.Args.CopyTo(copiedArgs, 0);
                object returnValue = methodCall.MethodBase.Invoke(channel, copiedArgs);
                methodReturn = new ReturnMessage(returnValue,
                                                copiedArgs,
                                                copiedArgs.Length,
                                                methodCall.LogicalCallContext,
                                                methodCall);
                //TODO:Write log
            }
            catch (Exception ex)
            {
                var exception = ex;
                if (ex.InnerException != null)
                    exception = ex.InnerException;
                methodReturn = new ReturnMessage(exception, methodCall);
            }
            finally
            {
                var commObj = channel as ICommunicationObject;
                if (commObj != null)
                {
                    try
                    {
                        commObj.Close();
                    }
                    catch (CommunicationException)
                    {
                        commObj.Abort();
                    }
                    catch (TimeoutException)
                    {
                        commObj.Abort();
                    }
                    catch (Exception)
                    {
                        commObj.Abort();
                        //TODO:Logging exception
                        throw;
                    }
                }
            }
            return methodReturn;
        }

        internal static IWinfoToolServiceRead GetProxy()
        {
            return (IWinfoToolServiceRead)new ServiceProxyRead().GetTransparentProxy();
        }
    }

}