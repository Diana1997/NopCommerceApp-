using System.Collections.Generic;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugins.Basic.Sample
{
    public class SamplePlugin  : BasePlugin, IWidgetPlugin
    {
        public override void Install()
        {
            base.Install();
        }

        public override void Uninstall()
        {
            base.Uninstall();
        }

        

        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomepageBeforeNews };
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "BasicSample";
        }

        public bool HideInWidgetList => false;
    } 
}