﻿using Com.Winfotian.Common;
using Proxy.CrmServicePost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel;
using System.Text;

namespace Proxy.ServiceInstance
{
    class CrmProxyPost : RealProxy
    {
        public CrmProxyPost()
            : base(typeof(ICRMSPost))
        {
        }

        private static EndpointAddress GetEndPointAddress()
        {     
            string url= ToolHelper.ReadINIValue("Services","CrmUrl","A4C662002B6E21EEE18731095628F20B97DA2559D71A62A035224393A3515841DB");
            EndpointAddress endpoint = new EndpointAddress( Com.Winfotian.Encrypts.DESEncrypt.Decrypt(url)+"/Service/crmspostservice.svc");
            return endpoint;
        }

        public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
        {
            IMethodReturnMessage methodReturn = null;
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            var client = new ChannelFactory<ICRMSPost>(ServiceBindings.GetBasicHttpBinding(), GetEndPointAddress());
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

        internal static ICRMSPost GetProxy()
        {
            return (ICRMSPost)new CrmProxyPost().GetTransparentProxy();
        }
    }
}