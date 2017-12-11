﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IERM.EccmWcf {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EccmWcf.IECCMService")]
    public interface IECCMService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IECCMService/GetDataByDevID", ReplyAction="http://tempuri.org/IECCMService/GetDataByDevIDResponse")]
        string GetDataByDevID(int devNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IECCMService/GetLiftRunData", ReplyAction="http://tempuri.org/IECCMService/GetLiftRunDataResponse")]
        string GetLiftRunData(string registercode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IECCMService/GetLiftDetail", ReplyAction="http://tempuri.org/IECCMService/GetLiftDetailResponse")]
        string GetLiftDetail(string registercode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IECCMService/GetLiftVideo", ReplyAction="http://tempuri.org/IECCMService/GetLiftVideoResponse")]
        string GetLiftVideo(string registercode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IECCMServiceChannel : IERM.EccmWcf.IECCMService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ECCMServiceClient : System.ServiceModel.ClientBase<IERM.EccmWcf.IECCMService>, IERM.EccmWcf.IECCMService {
        
        public ECCMServiceClient() {
        }
        
        public ECCMServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ECCMServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECCMServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECCMServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDataByDevID(int devNum) {
            return base.Channel.GetDataByDevID(devNum);
        }
        
        public string GetLiftRunData(string registercode) {
            return base.Channel.GetLiftRunData(registercode);
        }
        
        public string GetLiftDetail(string registercode) {
            return base.Channel.GetLiftDetail(registercode);
        }
        
        public string GetLiftVideo(string registercode) {
            return base.Channel.GetLiftVideo(registercode);
        }
    }
}
