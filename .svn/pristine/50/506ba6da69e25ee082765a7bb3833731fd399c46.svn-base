using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Proxy
{
    public class ServiceBindings
    {
        public static Binding GetBasicHttpBinding()
        {
            return new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                AllowCookies = false,
                CloseTimeout = new TimeSpan(0, 5, 0),
                SendTimeout = new TimeSpan(0, 5, 0),
                OpenTimeout = new TimeSpan(0, 5, 0),
                ReceiveTimeout = new TimeSpan(0, 20, 0),
                BypassProxyOnLocal = false,
                HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                MaxBufferSize = 2147483647,
                MaxBufferPoolSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                MessageEncoding = WSMessageEncoding.Text,
                TextEncoding = System.Text.Encoding.UTF8,
                TransferMode = TransferMode.Buffered,
                UseDefaultWebProxy = true,
                ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
                {
                    MaxDepth = 64,
                    MaxStringContentLength = 2147483647,
                    MaxArrayLength = 2147483647,
                    MaxBytesPerRead = 2147483647,
                    MaxNameTableCharCount = 2147483647
                },
                Security = new BasicHttpSecurity()
                {
                    Mode = BasicHttpSecurityMode.None,
                    Transport = new HttpTransportSecurity()
                    {
                        ClientCredentialType = HttpClientCredentialType.None,
                        ProxyCredentialType = HttpProxyCredentialType.None,
                        Realm = ""
                    },
                    Message = new BasicHttpMessageSecurity()
                    {
                        AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default,
                        ClientCredentialType = BasicHttpMessageCredentialType.UserName
                    }
                }
            };
        }

        public static CustomBinding GetCustomBinding()
        {
            ICollection<BindingElement> bindingElements = new List<BindingElement>();
            HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();
            Com.Winfotian.Common.CompactMessageEncodingBindingElement elem = new Com.Winfotian.Common.CompactMessageEncodingBindingElement();
            httpBindingElement.MaxBufferSize = 2147483647;
            httpBindingElement.MaxBufferPoolSize = 2147483647;
            httpBindingElement.MaxReceivedMessageSize = 2147483647;

            bindingElements.Add(elem);
            bindingElements.Add(httpBindingElement);
            CustomBinding customBinding = new CustomBinding(bindingElements);

            customBinding.CloseTimeout = new TimeSpan(0, 10, 0);
            customBinding.SendTimeout = new TimeSpan(0, 10, 0);
            customBinding.OpenTimeout = new TimeSpan(0, 10, 0);
            customBinding.ReceiveTimeout = new TimeSpan(0, 10, 0);

            return customBinding;
        }

        public static NetTcpBinding GetNetTcpBinding()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.SendTimeout = TimeSpan.FromMinutes(10);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxBufferSize = 2147483647;

            binding.ReaderQuotas.MaxDepth = 64;
            binding.ReaderQuotas.MaxStringContentLength = 2147483647;
            binding.ReaderQuotas.MaxArrayLength = 2147483647;
            binding.ReaderQuotas.MaxBytesPerRead = 4096;
            binding.ReaderQuotas.MaxNameTableCharCount = 16384;

            binding.ReliableSession.Ordered = true;
            binding.ReliableSession.InactivityTimeout = TimeSpan.FromMinutes(10);
            binding.ReliableSession.Enabled = false;

            //binding.Security.Mode = SecurityMode.Transport;
            //binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            //binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            return binding;
        }

    }
}
