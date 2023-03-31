using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugins.FocusPoint.SLSyncPortal.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class SLSyncPortalController :  BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public SLSyncPortalController(
            ISettingService settingService,
            IStoreContext storeContext)
        {
            _settingService = settingService;
            _storeContext = storeContext;
        }
        
        [HttpGet]
        public IActionResult Configure()
        {
            
            var model = new ConfigurationModel()
            {
                Url = GetSettings().Url
            };
           return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Configure.cshtml", model);
        }

        
        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();
            
            _settingService.SaveSetting(new SLSyncPortalPluginSettings
            {
                Url = model.Url
            });
            return Configure();
        }

        [Route("SLSyncPortal")]
        [HttpGet]
        public IActionResult Settings()
        {
            ViewBag.Url = GetSettings().Url;
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Settings.cshtml");
        }


        private SLSyncPortalPluginSettings GetSettings()
        {
            int storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<SLSyncPortalPluginSettings>(storeScope);
            return settings;
        }
    }
}