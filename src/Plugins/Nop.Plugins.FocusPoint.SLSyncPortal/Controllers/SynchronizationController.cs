using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugins.FocusPoint.SLSyncPortal.Servies;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class SynchronizationController :  BasePluginController
    {
        private readonly IHttpService _httpService;
        private readonly  SLSyncPortalPluginSettings _settings;

        public SynchronizationController(
            ISettingService settingService,
            IStoreContext storeContext, 
            IHttpService httpService)
        {
            _httpService = httpService;
            _settings = settingService.LoadSetting<SLSyncPortalPluginSettings>(storeContext.ActiveStoreScopeConfiguration);
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Synchronizations/Index.cshtml");
        }
        
        
        [HttpGet]
        public async Task<IActionResult> FullItemSync()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/sync/fullItemSync", CancellationToken.None);
            ViewBag.Response = response;
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Synchronizations/Index.cshtml");
        }
        
        [HttpGet]
        public async Task<IActionResult> FullBPSync()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/sync/fullBPSync", CancellationToken.None);
            ViewBag.Response = response;
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Synchronizations/Index.cshtml");
        }
        
        [HttpGet]
        public async Task<IActionResult> InventorySync()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/sync/inventorySync", CancellationToken.None);
            ViewBag.Response = response;
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Synchronizations/Index.cshtml");
        }
        
                
        [HttpGet]
        public async Task<IActionResult> InventoryDeltaSync()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/sync/inventoryDeltaSync", CancellationToken.None);
            ViewBag.Response = response;
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Synchronizations/Index.cshtml");
        }
    }
}