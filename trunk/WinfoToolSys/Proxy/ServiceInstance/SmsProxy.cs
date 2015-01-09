﻿using Com.Winfotian.Common;
using Proxy.SmsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel;
using System.Text;

namespace Proxy.ServiceInstance
{
    public class SmsProxy : RealProxy
    {
        public SmsProxy()
            : base(typeof(IMSService))
        {
        }
        private static EndpointAddress GetEndPointAddress()
        {
            string url = ToolHelper.ReadINIValue("Services", "SmsUrl", "AA05A8472187BFD86DF97CC9AF5AFC262F7C93A11EA99D036B");
            EndpointAddress endpoint = new EndpointAddress(Com.Winfotian.Encrypts.DESEncrypt.Decrypt(url) + "/Services/MSService.svc");
            return endpoint;
        }

        public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
        {
            IMethodReturnMessage methodReturn = null;
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            var client = new ChannelFactory<IMSService>(ServiceBindings.GetBasicHttpBinding(), GetEndPointAddress());
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

        internal static IMSService GetProxy()
        {
            return (IMSService)new SmsProxy().GetTransparentProxy();
        }
    }
}
