﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medical.Synchronization.SynService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Figure", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Figure : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        private int ClinicIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        private System.DateTime LastUpdatedDateField;
        
        private int LastUpdatedUserField;
        
        private int VersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Medical.Synchronization.SynService.FigureDetail[] DetailsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public int ClinicId {
            get {
                return this.ClinicIdField;
            }
            set {
                if ((this.ClinicIdField.Equals(value) != true)) {
                    this.ClinicIdField = value;
                    this.RaisePropertyChanged("ClinicId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.DateTime LastUpdatedDate {
            get {
                return this.LastUpdatedDateField;
            }
            set {
                if ((this.LastUpdatedDateField.Equals(value) != true)) {
                    this.LastUpdatedDateField = value;
                    this.RaisePropertyChanged("LastUpdatedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public int LastUpdatedUser {
            get {
                return this.LastUpdatedUserField;
            }
            set {
                if ((this.LastUpdatedUserField.Equals(value) != true)) {
                    this.LastUpdatedUserField = value;
                    this.RaisePropertyChanged("LastUpdatedUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int Version {
            get {
                return this.VersionField;
            }
            set {
                if ((this.VersionField.Equals(value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public Medical.Synchronization.SynService.FigureDetail[] Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FigureDetail", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class FigureDetail : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        private int FigureIdField;
        
        private int MedicineIdField;
        
        private int VolumnField;
        
        private int VersionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int FigureId {
            get {
                return this.FigureIdField;
            }
            set {
                if ((this.FigureIdField.Equals(value) != true)) {
                    this.FigureIdField = value;
                    this.RaisePropertyChanged("FigureId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public int MedicineId {
            get {
                return this.MedicineIdField;
            }
            set {
                if ((this.MedicineIdField.Equals(value) != true)) {
                    this.MedicineIdField = value;
                    this.RaisePropertyChanged("MedicineId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public int Volumn {
            get {
                return this.VolumnField;
            }
            set {
                if ((this.VolumnField.Equals(value) != true)) {
                    this.VolumnField = value;
                    this.RaisePropertyChanged("Volumn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int Version {
            get {
                return this.VersionField;
            }
            set {
                if ((this.VersionField.Equals(value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SynService.SynServiceSoap")]
    public interface SynServiceSoap {
        
        // CODEGEN: Generating message contract since element name figures from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendFigure", ReplyAction="*")]
        Medical.Synchronization.SynService.SendFigureResponse SendFigure(Medical.Synchronization.SynService.SendFigureRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendFigureRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendFigure", Namespace="http://tempuri.org/", Order=0)]
        public Medical.Synchronization.SynService.SendFigureRequestBody Body;
        
        public SendFigureRequest() {
        }
        
        public SendFigureRequest(Medical.Synchronization.SynService.SendFigureRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendFigureRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Medical.Synchronization.SynService.Figure[] figures;
        
        public SendFigureRequestBody() {
        }
        
        public SendFigureRequestBody(Medical.Synchronization.SynService.Figure[] figures) {
            this.figures = figures;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendFigureResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendFigureResponse", Namespace="http://tempuri.org/", Order=0)]
        public Medical.Synchronization.SynService.SendFigureResponseBody Body;
        
        public SendFigureResponse() {
        }
        
        public SendFigureResponse(Medical.Synchronization.SynService.SendFigureResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendFigureResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool SendFigureResult;
        
        public SendFigureResponseBody() {
        }
        
        public SendFigureResponseBody(bool SendFigureResult) {
            this.SendFigureResult = SendFigureResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SynServiceSoapChannel : Medical.Synchronization.SynService.SynServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SynServiceSoapClient : System.ServiceModel.ClientBase<Medical.Synchronization.SynService.SynServiceSoap>, Medical.Synchronization.SynService.SynServiceSoap {
        
        public SynServiceSoapClient() {
        }
        
        public SynServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SynServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SynServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SynServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Medical.Synchronization.SynService.SendFigureResponse Medical.Synchronization.SynService.SynServiceSoap.SendFigure(Medical.Synchronization.SynService.SendFigureRequest request) {
            return base.Channel.SendFigure(request);
        }
        
        public bool SendFigure(Medical.Synchronization.SynService.Figure[] figures) {
            Medical.Synchronization.SynService.SendFigureRequest inValue = new Medical.Synchronization.SynService.SendFigureRequest();
            inValue.Body = new Medical.Synchronization.SynService.SendFigureRequestBody();
            inValue.Body.figures = figures;
            Medical.Synchronization.SynService.SendFigureResponse retVal = ((Medical.Synchronization.SynService.SynServiceSoap)(this)).SendFigure(inValue);
            return retVal.Body.SendFigureResult;
        }
    }
}
