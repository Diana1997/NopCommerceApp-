using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugins.Basic.Sample.Components
{
    public class BasicSampleViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Basic.Sample/Views/BasicSample.cshtml");
        }
    }
}