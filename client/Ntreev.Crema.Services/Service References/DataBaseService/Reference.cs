﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ntreev.Crema.Services.DataBaseService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.ntreev.com", ConfigurationName="DataBaseService.IDataBaseService", CallbackContract=typeof(Ntreev.Crema.Services.DataBaseService.IDataBaseServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    internal interface IDataBaseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/DefinitionType", ReplyAction="http://www.ntreev.com/IDataBaseService/DefinitionTypeResponse")]
        Ntreev.Crema.ServiceModel.ResultBase DefinitionType(Ntreev.Crema.ServiceModel.LogInfo[] param1, Ntreev.Crema.ServiceModel.FindResultInfo[] param2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/Subscribe", ReplyAction="http://www.ntreev.com/IDataBaseService/SubscribeResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DataBaseMetaData> Subscribe(System.Guid authenticationToken, string dataBaseName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/Unsubscribe", ReplyAction="http://www.ntreev.com/IDataBaseService/UnsubscribeResponse")]
        Ntreev.Crema.ServiceModel.ResultBase Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/GetMetaData", ReplyAction="http://www.ntreev.com/IDataBaseService/GetMetaDataResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DataBaseMetaData> GetMetaData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/GetDataSet", ReplyAction="http://www.ntreev.com/IDataBaseService/GetDataSetResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.CremaDataSet> GetDataSet(Ntreev.Crema.ServiceModel.DataSetType dataSetType, string filterExpression, string revision);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/ImportDataSet", ReplyAction="http://www.ntreev.com/IDataBaseService/ImportDataSetResponse")]
        Ntreev.Crema.ServiceModel.ResultBase ImportDataSet(Ntreev.Crema.Data.CremaDataSet dataSet, string comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/NewTableCategory", ReplyAction="http://www.ntreev.com/IDataBaseService/NewTableCategoryResponse")]
        Ntreev.Crema.ServiceModel.ResultBase NewTableCategory(string categoryPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/GetTableItemDataSet", ReplyAction="http://www.ntreev.com/IDataBaseService/GetTableItemDataSetResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.CremaDataSet> GetTableItemDataSet(string itemPath, string revision);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/RenameTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/RenameTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase RenameTableItem(string itemPath, string newName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/MoveTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/MoveTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase MoveTableItem(string itemPath, string parentPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/DeleteTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/DeleteTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase DeleteTableItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/SetPublicTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/SetPublicTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase SetPublicTableItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/SetPrivateTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/SetPrivateTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessInfo> SetPrivateTableItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/AddAccessMemberTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/AddAccessMemberTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> AddAccessMemberTableItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/SetAccessMemberTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/SetAccessMemberTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> SetAccessMemberTableItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/RemoveAccessMemberTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/RemoveAccessMemberTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase RemoveAccessMemberTableItem(string itemPath, string memberID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/LockTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/LockTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LockInfo> LockTableItem(string itemPath, string comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/UnlockTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/UnlockTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase UnlockTableItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/GetTableItemLog", ReplyAction="http://www.ntreev.com/IDataBaseService/GetTableItemLogResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LogInfo[]> GetTableItemLog(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/FindTableItem", ReplyAction="http://www.ntreev.com/IDataBaseService/FindTableItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.FindResultInfo[]> FindTableItem(string itemPath, string text, Ntreev.Crema.ServiceModel.FindOptions options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/CopyTable", ReplyAction="http://www.ntreev.com/IDataBaseService/CopyTableResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> CopyTable(string tableName, string newTableName, string categoryPath, bool copyXml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/InheritTable", ReplyAction="http://www.ntreev.com/IDataBaseService/InheritTableResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> InheritTable(string tableName, string newTableName, string categoryPath, bool copyXml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/EnterTableContentEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/EnterTableContentEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> EnterTableContentEdit(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/LeaveTableContentEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/LeaveTableContentEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> LeaveTableContentEdit(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/BeginTableContentEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/BeginTableContentEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginTableContentEdit(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/EndTableContentEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/EndTableContentEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> EndTableContentEdit(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/CancelTableContentEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/CancelTableContentEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase CancelTableContentEdit(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/BeginTableTemplateEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/BeginTableTemplateEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginTableTemplateEdit(string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/BeginNewTable", ReplyAction="http://www.ntreev.com/IDataBaseService/BeginNewTableResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginNewTable(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/EndTableTemplateEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/EndTableTemplateEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> EndTableTemplateEdit(System.Guid domainID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/CancelTableTemplateEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/CancelTableTemplateEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase CancelTableTemplateEdit(System.Guid domainID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/NewTypeCategory", ReplyAction="http://www.ntreev.com/IDataBaseService/NewTypeCategoryResponse")]
        Ntreev.Crema.ServiceModel.ResultBase NewTypeCategory(string categoryPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/GetTypeItemDataSet", ReplyAction="http://www.ntreev.com/IDataBaseService/GetTypeItemDataSetResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.CremaDataSet> GetTypeItemDataSet(string itemPath, string revision);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/RenameTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/RenameTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase RenameTypeItem(string itemPath, string newName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/MoveTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/MoveTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase MoveTypeItem(string itemPath, string parentPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/DeleteTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/DeleteTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase DeleteTypeItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/CopyType", ReplyAction="http://www.ntreev.com/IDataBaseService/CopyTypeResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TypeInfo> CopyType(string typeName, string newTypeName, string categoryPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/BeginTypeTemplateEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/BeginTypeTemplateEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginTypeTemplateEdit(string typeName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/BeginNewType", ReplyAction="http://www.ntreev.com/IDataBaseService/BeginNewTypeResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginNewType(string categoryPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/EndTypeTemplateEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/EndTypeTemplateEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TypeInfo> EndTypeTemplateEdit(System.Guid domainID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/CancelTypeTemplateEdit", ReplyAction="http://www.ntreev.com/IDataBaseService/CancelTypeTemplateEditResponse")]
        Ntreev.Crema.ServiceModel.ResultBase CancelTypeTemplateEdit(System.Guid domainID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/SetPublicTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/SetPublicTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase SetPublicTypeItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/SetPrivateTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/SetPrivateTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessInfo> SetPrivateTypeItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/AddAccessMemberTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/AddAccessMemberTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> AddAccessMemberTypeItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/SetAccessMemberTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/SetAccessMemberTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> SetAccessMemberTypeItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/RemoveAccessMemberTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/RemoveAccessMemberTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase RemoveAccessMemberTypeItem(string itemPath, string memberID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/LockTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/LockTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LockInfo> LockTypeItem(string itemPath, string comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/UnlockTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/UnlockTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase UnlockTypeItem(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/GetTypeItemLog", ReplyAction="http://www.ntreev.com/IDataBaseService/GetTypeItemLogResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LogInfo[]> GetTypeItemLog(string itemPath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/FindTypeItem", ReplyAction="http://www.ntreev.com/IDataBaseService/FindTypeItemResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.FindResultInfo[]> FindTypeItem(string itemPath, string text, Ntreev.Crema.ServiceModel.FindOptions options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IDataBaseService/IsAlive", ReplyAction="http://www.ntreev.com/IDataBaseService/IsAliveResponse")]
        bool IsAlive();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IDataBaseServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnServiceClosed")]
        void OnServiceClosed(Ntreev.Library.SignatureDate signatureDate, Ntreev.Crema.ServiceModel.CloseInfo closeInfo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTablesChanged")]
        void OnTablesChanged(Ntreev.Library.SignatureDate signatureDate, Ntreev.Crema.Data.TableInfo[] tableInfos);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTablesStateChanged")]
        void OnTablesStateChanged(Ntreev.Library.SignatureDate signatureDate, string[] tableNames, Ntreev.Crema.ServiceModel.TableState[] states);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTableItemsCreated")]
        void OnTableItemsCreated(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths, System.Nullable<Ntreev.Crema.Data.TableInfo>[] args);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTableItemsRenamed")]
        void OnTableItemsRenamed(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths, string[] newNames);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTableItemsMoved")]
        void OnTableItemsMoved(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths, string[] parentPaths);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTableItemsDeleted")]
        void OnTableItemsDeleted(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTableItemsAccessChanged")]
        void OnTableItemsAccessChanged(Ntreev.Library.SignatureDate signatureDate, Ntreev.Crema.ServiceModel.AccessChangeType changeType, Ntreev.Crema.ServiceModel.AccessInfo[] accessInfos, string[] memberIDs, Ntreev.Crema.ServiceModel.AccessType[] accessTypes);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTableItemsLockChanged")]
        void OnTableItemsLockChanged(Ntreev.Library.SignatureDate signatureDate, Ntreev.Crema.ServiceModel.LockChangeType changeType, Ntreev.Crema.ServiceModel.LockInfo[] lockInfos, string[] comments);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypesChanged")]
        void OnTypesChanged(Ntreev.Library.SignatureDate signatureDate, Ntreev.Crema.Data.TypeInfo[] typeInfos);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypesStateChanged")]
        void OnTypesStateChanged(Ntreev.Library.SignatureDate signatureDate, string[] typeNames, Ntreev.Crema.ServiceModel.TypeState[] states);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypeItemsCreated")]
        void OnTypeItemsCreated(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths, System.Nullable<Ntreev.Crema.Data.TypeInfo>[] args);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypeItemsRenamed")]
        void OnTypeItemsRenamed(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths, string[] newNames);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypeItemsMoved")]
        void OnTypeItemsMoved(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths, string[] parentPaths);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypeItemsDeleted")]
        void OnTypeItemsDeleted(Ntreev.Library.SignatureDate signatureDate, string[] itemPaths);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypeItemsAccessChanged")]
        void OnTypeItemsAccessChanged(Ntreev.Library.SignatureDate signatureDate, Ntreev.Crema.ServiceModel.AccessChangeType changeType, Ntreev.Crema.ServiceModel.AccessInfo[] accessInfos, string[] memberIDs, Ntreev.Crema.ServiceModel.AccessType[] accessTypes);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.ntreev.com/IDataBaseService/OnTypeItemsLockChanged")]
        void OnTypeItemsLockChanged(Ntreev.Library.SignatureDate signatureDate, Ntreev.Crema.ServiceModel.LockChangeType changeType, Ntreev.Crema.ServiceModel.LockInfo[] lockInfos, string[] comments);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IDataBaseServiceChannel : Ntreev.Crema.Services.DataBaseService.IDataBaseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class DataBaseServiceClient : System.ServiceModel.DuplexClientBase<Ntreev.Crema.Services.DataBaseService.IDataBaseService>, Ntreev.Crema.Services.DataBaseService.IDataBaseService {
        
        public DataBaseServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DataBaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DataBaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DataBaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DataBaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase DefinitionType(Ntreev.Crema.ServiceModel.LogInfo[] param1, Ntreev.Crema.ServiceModel.FindResultInfo[] param2) {
            return base.Channel.DefinitionType(param1, param2);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DataBaseMetaData> Subscribe(System.Guid authenticationToken, string dataBaseName) {
            return base.Channel.Subscribe(authenticationToken, dataBaseName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase Unsubscribe() {
            return base.Channel.Unsubscribe();
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DataBaseMetaData> GetMetaData() {
            return base.Channel.GetMetaData();
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.CremaDataSet> GetDataSet(Ntreev.Crema.ServiceModel.DataSetType dataSetType, string filterExpression, string revision) {
            return base.Channel.GetDataSet(dataSetType, filterExpression, revision);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase ImportDataSet(Ntreev.Crema.Data.CremaDataSet dataSet, string comment) {
            return base.Channel.ImportDataSet(dataSet, comment);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase NewTableCategory(string categoryPath) {
            return base.Channel.NewTableCategory(categoryPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.CremaDataSet> GetTableItemDataSet(string itemPath, string revision) {
            return base.Channel.GetTableItemDataSet(itemPath, revision);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase RenameTableItem(string itemPath, string newName) {
            return base.Channel.RenameTableItem(itemPath, newName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase MoveTableItem(string itemPath, string parentPath) {
            return base.Channel.MoveTableItem(itemPath, parentPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase DeleteTableItem(string itemPath) {
            return base.Channel.DeleteTableItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase SetPublicTableItem(string itemPath) {
            return base.Channel.SetPublicTableItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessInfo> SetPrivateTableItem(string itemPath) {
            return base.Channel.SetPrivateTableItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> AddAccessMemberTableItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType) {
            return base.Channel.AddAccessMemberTableItem(itemPath, memberID, accessType);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> SetAccessMemberTableItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType) {
            return base.Channel.SetAccessMemberTableItem(itemPath, memberID, accessType);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase RemoveAccessMemberTableItem(string itemPath, string memberID) {
            return base.Channel.RemoveAccessMemberTableItem(itemPath, memberID);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LockInfo> LockTableItem(string itemPath, string comment) {
            return base.Channel.LockTableItem(itemPath, comment);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase UnlockTableItem(string itemPath) {
            return base.Channel.UnlockTableItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LogInfo[]> GetTableItemLog(string itemPath) {
            return base.Channel.GetTableItemLog(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.FindResultInfo[]> FindTableItem(string itemPath, string text, Ntreev.Crema.ServiceModel.FindOptions options) {
            return base.Channel.FindTableItem(itemPath, text, options);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> CopyTable(string tableName, string newTableName, string categoryPath, bool copyXml) {
            return base.Channel.CopyTable(tableName, newTableName, categoryPath, copyXml);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> InheritTable(string tableName, string newTableName, string categoryPath, bool copyXml) {
            return base.Channel.InheritTable(tableName, newTableName, categoryPath, copyXml);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> EnterTableContentEdit(string tableName) {
            return base.Channel.EnterTableContentEdit(tableName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> LeaveTableContentEdit(string tableName) {
            return base.Channel.LeaveTableContentEdit(tableName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginTableContentEdit(string tableName) {
            return base.Channel.BeginTableContentEdit(tableName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> EndTableContentEdit(string tableName) {
            return base.Channel.EndTableContentEdit(tableName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase CancelTableContentEdit(string tableName) {
            return base.Channel.CancelTableContentEdit(tableName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginTableTemplateEdit(string tableName) {
            return base.Channel.BeginTableTemplateEdit(tableName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginNewTable(string itemPath) {
            return base.Channel.BeginNewTable(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TableInfo[]> EndTableTemplateEdit(System.Guid domainID) {
            return base.Channel.EndTableTemplateEdit(domainID);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase CancelTableTemplateEdit(System.Guid domainID) {
            return base.Channel.CancelTableTemplateEdit(domainID);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase NewTypeCategory(string categoryPath) {
            return base.Channel.NewTypeCategory(categoryPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.CremaDataSet> GetTypeItemDataSet(string itemPath, string revision) {
            return base.Channel.GetTypeItemDataSet(itemPath, revision);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase RenameTypeItem(string itemPath, string newName) {
            return base.Channel.RenameTypeItem(itemPath, newName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase MoveTypeItem(string itemPath, string parentPath) {
            return base.Channel.MoveTypeItem(itemPath, parentPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase DeleteTypeItem(string itemPath) {
            return base.Channel.DeleteTypeItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TypeInfo> CopyType(string typeName, string newTypeName, string categoryPath) {
            return base.Channel.CopyType(typeName, newTypeName, categoryPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginTypeTemplateEdit(string typeName) {
            return base.Channel.BeginTypeTemplateEdit(typeName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.DomainMetaData> BeginNewType(string categoryPath) {
            return base.Channel.BeginNewType(categoryPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Data.TypeInfo> EndTypeTemplateEdit(System.Guid domainID) {
            return base.Channel.EndTypeTemplateEdit(domainID);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase CancelTypeTemplateEdit(System.Guid domainID) {
            return base.Channel.CancelTypeTemplateEdit(domainID);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase SetPublicTypeItem(string itemPath) {
            return base.Channel.SetPublicTypeItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessInfo> SetPrivateTypeItem(string itemPath) {
            return base.Channel.SetPrivateTypeItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> AddAccessMemberTypeItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType) {
            return base.Channel.AddAccessMemberTypeItem(itemPath, memberID, accessType);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.AccessMemberInfo> SetAccessMemberTypeItem(string itemPath, string memberID, Ntreev.Crema.ServiceModel.AccessType accessType) {
            return base.Channel.SetAccessMemberTypeItem(itemPath, memberID, accessType);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase RemoveAccessMemberTypeItem(string itemPath, string memberID) {
            return base.Channel.RemoveAccessMemberTypeItem(itemPath, memberID);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LockInfo> LockTypeItem(string itemPath, string comment) {
            return base.Channel.LockTypeItem(itemPath, comment);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase UnlockTypeItem(string itemPath) {
            return base.Channel.UnlockTypeItem(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.LogInfo[]> GetTypeItemLog(string itemPath) {
            return base.Channel.GetTypeItemLog(itemPath);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.ServiceModel.FindResultInfo[]> FindTypeItem(string itemPath, string text, Ntreev.Crema.ServiceModel.FindOptions options) {
            return base.Channel.FindTypeItem(itemPath, text, options);
        }
        
        public bool IsAlive() {
            return base.Channel.IsAlive();
        }
    }
}
