using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugins.FocusPoint.SLSyncPortal.Responses;
using Nop.Plugins.FocusPoint.SLSyncPortal.Services;
using Nop.Services.Configuration;
using Nop.Services.Tasks;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [Route("Admin/SLSyncPortal/[controller]/[action]")]
    public class InstallationController :  BasePluginController
    {
        private readonly  SLSyncPortalPluginSettings _settings;
        private readonly IHttpService _httpService;

        public InstallationController(
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
            
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Installations/Index.cshtml");
        }


        [HttpGet]
        public async Task<IActionResult> CreateUo()
        {
            
            var response = await _httpService.Get($"{_settings.Url}/portal/install/Create.UO", CancellationToken.None, true);
            return Json(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> InstallWs1()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/install/WS1", CancellationToken.None);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> StoredProcedures()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/install/StoredProcedures", CancellationToken.None);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> EventUDT()
        {
            var response = await _httpService.Get<IList<EventUDTResponse>>($"{_settings.Url}/portal/install/PTN", CancellationToken.None);
            return Json(response);
        }
    }
}