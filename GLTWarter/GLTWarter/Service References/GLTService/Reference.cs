﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GLTWarter.GLTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GLTService.IServiceAPI")]
    public interface IServiceAPI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAPI/GetData", ReplyAction="http://tempuri.org/IServiceAPI/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceAPI/DoRequest", ReplyAction="http://tempuri.org/IServiceAPI/DoRequestResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Galant.DataEntity.Package))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Galant.DataEntity.Entity))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Galant.DataEntity.Role))]
        Galant.DataEntity.BaseData DoRequest(Galant.DataEntity.BaseData composite, Galant.DataEntity.Entity staff, string OperationType);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceAPIChannel : GLTWarter.GLTService.IServiceAPI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceAPIClient : System.ServiceModel.ClientBase<GLTWarter.GLTService.IServiceAPI>, GLTWarter.GLTService.IServiceAPI {
        
        public ServiceAPIClient() {
        }
        
        public ServiceAPIClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceAPIClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceAPIClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceAPIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public Galant.DataEntity.BaseData DoRequest(Galant.DataEntity.BaseData composite, Galant.DataEntity.Entity staff, string OperationType) {
            return base.Channel.DoRequest(composite, staff, OperationType);
        }
    }
}
