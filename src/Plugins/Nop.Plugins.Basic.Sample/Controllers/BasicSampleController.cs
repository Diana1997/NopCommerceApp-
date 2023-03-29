using Microsoft.AspNetCore.Mvc;
using Nop.Plugins.Basic.Sample.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugins.Basic.Sample.Controllers
{
    public class BasicSampleController :  BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly BasicSamplePluginSettings _samplePluginSettings;

        public BasicSampleController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [Route("custom")]
        public IActionResult CustomEndpoint()
        {
            return Redirect("https://www.google.com");
        }
        
        [Area(AreaNames.Admin)]
        public IActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
            };
           return View("~/Plugins/Basic.Sample/Views/Configure.cshtml", model);
        }

        [HttpPost, ActionName("Configure")]
        public IActionResult Configure(ConfigurationModel model)
        {
          //  _settingService.SaveSetting("", model.Url);
            return Ok();
        }
    }
}