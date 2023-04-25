using Nop.Web.Framework.Models;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Models
{
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