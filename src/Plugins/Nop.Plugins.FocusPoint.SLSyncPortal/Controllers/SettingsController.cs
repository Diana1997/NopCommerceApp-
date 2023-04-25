using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugins.FocusPoint.SLSyncPortal.Models;
using Nop.Plugins.FocusPoint.SLSyncPortal.Servies;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class SettingsController : BasePluginController
    {
        private readonly  SLSyncPortalPluginSettings _settings;
        private readonly IHttpService _httpService;

        public SettingsController(
            ISettingService settingService,
            IStoreContext storeContext, 
            IHttpService httpService)
        {
            _httpService = httpService;
            _settings = settingService.LoadSetting<SLSyncPortalPluginSettings>(storeContext.ActiveStoreScopeConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            var response = await _httpService.Get<Root>($"{_settings.Url}/portal/settings", CancellationToken.None);
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Settings/Index.cshtml", response.ServiceLayerSettings);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ServiceLayerSettings model)
        {

            return RedirectToAction("Index");
        }
    }
}