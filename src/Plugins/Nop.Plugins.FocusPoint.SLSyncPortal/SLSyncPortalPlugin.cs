using System.Collections.Generic;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace Nop.Plugins.FocusPoint.SLSyncPortal
{
    public class SLSyncPortalPlugin  : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;

        public SLSyncPortalPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }
        
        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/SLSyncPortal/Configure";
        }
        
        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomepageTop };
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "SLSyncPortal";
        }
        
        public bool HideInWidgetList => false;

    } 
}