using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugins.Basic.Sample.Controllers
{
    public class SamplePluginController :  BasePluginController
    {
        [Route("custom")]
        public IActionResult CustomEndpoint()
        {
            return Redirect("https://www.google.com");
        }
    }
}