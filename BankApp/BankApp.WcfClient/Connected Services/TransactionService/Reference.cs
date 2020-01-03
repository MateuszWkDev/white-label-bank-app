﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransactionService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionContract", Namespace="http://schemas.datacontract.org/2004/07/MainServices.Services")]
    public partial class TransactionContract : object
    {
        
        private decimal AmountField;
        
        private int FromAccountIdField;
        
        private System.Nullable<int> IdField;
        
        private int ToAccountIdField;
        
        private int UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Amount
        {
            get
            {
                return this.AmountField;
            }
            set
            {
                this.AmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FromAccountId
        {
            get
            {
                return this.FromAccountIdField;
            }
            set
            {
                this.FromAccountIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ToAccountId
        {
            get
            {
                return this.ToAccountIdField;
            }
            set
            {
                this.ToAccountIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId
        {
            get
            {
                return this.UserIdField;
            }
            set
            {
                this.UserIdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TransactionService.ITransactionService")]
    public interface ITransactionService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransactionService/GetTransactionsForUser", ReplyAction="http://tempuri.org/ITransactionService/GetTransactionsForUserResponse")]
        System.Threading.Tasks.Task<TransactionService.TransactionContract[]> GetTransactionsForUserAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransactionService/PerformTransaction", ReplyAction="http://tempuri.org/ITransactionService/PerformTransactionResponse")]
        System.Threading.Tasks.Task PerformTransactionAsync(TransactionService.TransactionContract transaction);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ITransactionServiceChannel : TransactionService.ITransactionService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class TransactionServiceClient : System.ServiceModel.ClientBase<TransactionService.ITransactionService>, TransactionService.ITransactionService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TransactionServiceClient() : 
                base(TransactionServiceClient.GetDefaultBinding(), TransactionServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ITransactionService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TransactionServiceClient.GetBindingForEndpoint(endpointConfiguration), TransactionServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TransactionServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TransactionServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransactionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<TransactionService.TransactionContract[]> GetTransactionsForUserAsync(int userId)
        {
            return base.Channel.GetTransactionsForUserAsync(userId);
        }
        
        public System.Threading.Tasks.Task PerformTransactionAsync(TransactionService.TransactionContract transaction)
        {
            return base.Channel.PerformTransactionAsync(transaction);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITransactionService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITransactionService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:61700/Services/TransactionService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TransactionServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ITransactionService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TransactionServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ITransactionService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ITransactionService,
        }
    }
}
