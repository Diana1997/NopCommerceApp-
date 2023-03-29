using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugins.Basic.Sample
{
    public class SamplePlugin  : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;

        public SamplePlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        public override void Install()
        {
            base.Install();
        }

        public override void Uninstall()
        {
            base.Uninstall();
        }
        
        
        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/BasicSample/Configure";
        }



        public string GetWidgetViewComponentName(string widgetZone)
        {
            throw new System.NotImplementedException();
        }

        public bool HideInWidgetList { get; }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomepageTop };
        }
    } 
}