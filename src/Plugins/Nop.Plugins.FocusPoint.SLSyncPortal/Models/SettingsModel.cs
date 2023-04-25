using Newtonsoft.Json;
using Nop.Web.Framework.Models;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Models
{
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }

        [JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Root
    {
        public ServiceLayerSettings ServiceLayerSettings { get; set; }
        public Logging Logging { get; set; }
    }


    public class ServiceLayerSettings 
    {
        public string _CurrentVersion_ { get; set; }
        public string _Client_ { get; set; }
        public string _SLSyncUpdateURL_ { get; set; }
        public string _SLSyncUpdateServiceName_ { get; set; }
        public string _SLSyncUpdatePath_ { get; set; }
        public string _UpdateNeeded_ { get; set; }
        public string _UpdateDate_ { get; set; }
        public string _DevelopmentCheckIntervalInSeconds_ { get; set; }
        public string _UpdaterCheckIntervalInSeconds_ { get; set; }
        public string _NewVersionCheckIntervalInSeconds_ { get; set; }
        public string _BackgroundProcessLimit_ { get; set; }
        public string _Protocol_ { get; set; }
        public string _AppMode_ { get; set; }
        public string _ItemSyncPriceVersion_ { get; set; }
        public string _DatabaseServer_ { get; set; }
        public string _DatabaseUserName_ { get; set; }
        public string _DatabasePassword_ { get; set; }
        public string _DatabaseName_ { get; set; }
        public string _Port_ { get; set; }
        public string _Host_ { get; set; }
        public string _AddUrlAcl_ { get; set; }
        public string _ServiceLayerURL_ { get; set; }
        public string _ServiceLayerCompanyUsername_ { get; set; }
        public string _ServiceLayerCompanyPassword_ { get; set; }
        public string _CultureInfo_ { get; set; }
        public string _DecimalSeparator_ { get; set; }
        public string _LogGeneratedXML_ { get; set; }
        public string _Log_FPEcom_xml_ { get; set; }
        public string _CompareXMLs_ { get; set; }
        public string _DebugMode_ { get; set; }
        public string _DeleteSyncedObjects_ { get; set; }
        public string _SyncIntervalInSeconds_ { get; set; }
        public string _InventorySyncIntervalInSeconds_ { get; set; }
        public string _InventoryDeltaSyncIntervalInSeconds_ { get; set; }
        public string _InventorySyncFixedTime_ { get; set; }
        public string _ItemSplitSize_ { get; set; }
        public string _InventorySplitSize_ { get; set; }
        public string _LogFilePath_ { get; set; }
        public string _ClientURL_ { get; set; }
        public string _ImgURL_ { get; set; }
        public string _InventoryQueryName_ { get; set; }
        public string _FetchPriceQueryName_ { get; set; }
        public string _CreateUOInstallMode_ { get; set; }
        public string _CreateUOVersion_ { get; set; }
        public string _AddOrUpdateStoredProcedures_ { get; set; }
        public string _EnableItemSync_ { get; set; }
        public string _EnableSalesOrderSync_ { get; set; }
        public string _EnableInventoryScheduledSync_ { get; set; }
        public string _EnableInventoryDeltaSync_ { get; set; }
        public string _EnableBusinessPartnerSync_ { get; set; }
        public string _EnableInvoiceSync_ { get; set; }
        public string _EnableDeliverySync_ { get; set; }
        public string _EnableSalesTaxCodeSync_ { get; set; }
        public string _EnableLivePriceFetchSync_ { get; set; }
        public string _EnableLogUpdateSync_ { get; set; }
        public string _EnableWS1Sync_ { get; set; }
        public string _CreateUoOnStartup_ { get; set; }
        public string _CreateEventListenerUDT_ { get; set; }
        public string CurrentVersion { get; set; }
        public string Client { get; set; }
        public string DatabaseServer { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUserName { get; set; }
        public string DatabasePassword { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string ServiceLayerURL { get; set; }
        public string ServiceLayerCompanyUsername { get; set; }
        public string ServiceLayerCompanyPassword { get; set; }
        public string SLSyncUpdateURL { get; set; }
        public string SLSyncUpdateServiceName { get; set; }
        public string SLSyncUpdatePath { get; set; }
        public string AppMode { get; set; }
        public string ClientURL { get; set; }
        public string ImgURL { get; set; }
        public string LogFilePath { get; set; }
        public int KeepLogHistoryDays { get; set; }
        public bool LogOutgoingXMLs { get; set; }
        public int BackgroundProcessLimit { get; set; }
        public int DevelopmentCheckIntervalInSeconds { get; set; }
        public int NewVersionCheckIntervalInSeconds { get; set; }
        public int UpdaterCheckIntervalInSeconds { get; set; }
        public int SyncIntervalInSeconds { get; set; }
        public int InventorySyncIntervalInSeconds { get; set; }
        public int InventoryDeltaSyncIntervalInSeconds { get; set; }
        public string InventorySyncFixedTime { get; set; }
        public int ItemSplitSize { get; set; }
        public int InventorySplitSize { get; set; }
        public string InventoryQueryName { get; set; }
        public string FetchPriceQueryName { get; set; }
        public bool LogGeneratedXML { get; set; }
        public bool Log_FPEcom_xml { get; set; }
        public bool CompareXMLs { get; set; }
        public bool DebugMode { get; set; }
        public bool DeleteSyncedObjects { get; set; }
        public bool AddUrlAcl { get; set; }
        public string Protocol { get; set; }
        public string CreateUOInstallMode { get; set; }
        public string CreateUOVersion { get; set; }
        public bool AddOrUpdateStoredProcedures { get; set; }
        public bool CreateUoOnStartup { get; set; }
        public bool CreateEventListenerUDT { get; set; }
        public string CultureInfo { get; set; }
        public string DecimalSeparator { get; set; }
        public bool UpdateNeeded { get; set; }
        public string UpdateDate { get; set; }
        public string ItemSyncPriceVersion { get; set; }
        public bool EnableItemSync { get; set; }
        public bool EnableSalesOrderSync { get; set; }
        public bool EnableInventoryScheduledSync { get; set; }
        public bool EnableInventoryDeltaSync { get; set; }
        public bool EnableBusinessPartnerSync { get; set; }
        public bool EnableInvoiceSync { get; set; }
        public bool EnableDeliverySync { get; set; }
        public bool EnableSalesTaxCodeSync { get; set; }
        public bool EnableLivePriceFetchSync { get; set; }
        public bool EnableLogUpdateSync { get; set; }
        public bool EnableWS1Sync { get; set; }
    }
    
    
    public class SettingsModel : BaseNopModel
    {
        public int CurrentVersion { set; get; }
        public string Client { set; get; }
        public string DatabaseServer { set; get; }
        public string DatabaseName { set; get; }
        public string DatabaseUserName { set; get; }
        public string DatabasePassword { set; get; }
        public string Host { set; get; }
        public string Port { set; get; }
        public string ServiceLayerUrl { set; get; }
        public string ServiceLayerCompanyUsername { set; get; }
        public string ServiceLayerCompanyPassword { set; get; }
        public string SLSyncUpdateURL { set; get; }
        public string SLSyncUpdateServiceName { set; get; }
        public string SLSyncUpdatePath { set; get; }
        public string AppMode { set; get; }
        public string ClientURL { set; get; }
        public string ImgURL { set; get; }
        public string LogFilePath { set; get; }
        public int KeepLoHistoryDays { set; get; }
    }
}