using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugins.Basic.Sample.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.Basic.Sample.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class BasicSampleController :  BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public BasicSampleController(
            ISettingService settingService,
            IStoreContext storeContext)
        {
            _settingService = settingService;
            _storeContext = storeContext;
        }
        
        [HttpGet]
        public IActionResult Configure()
        {
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<BasicSamplePluginSettings>(storeScope);
            
            var model = new ConfigurationModel()
            {
                Url = settings.Url
            };
           return View("~/Plugins/Basic.Sample/Views/Configure.cshtml", model);
        }

        
        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();
            
            _settingService.SaveSetting(new BasicSamplePluginSettings
            {
                Url = model.Url
            });
            return Configure();
        }

        [Route("SLSyncPortal")]
        [HttpGet]
        public IActionResult Settings()
        {
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<BasicSamplePluginSettings>(storeScope);

            ViewBag.Url = settings.Url;
            return View("~/Plugins/Basic.Sample/Views/Settings.cshtml");
        }
    }
}