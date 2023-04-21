using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugins.FocusPoint.SLSyncPortal.Responses;
using Nop.Plugins.FocusPoint.SLSyncPortal.Servies;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class LogsController : BasePluginController
    {
        private readonly IHttpService _httpService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public LogsController(
            IHttpService httpService, 
            ISettingService settingService, 
            IStoreContext storeContext)
        {
            _httpService = httpService;
            _settingService = settingService;
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var settings = GetSettings();
            var response = await _httpService.Get<LogResponse>($"{settings.Url}/portal/log", CancellationToken.None);
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Logs/Index.cshtml");
        }
        
        private SLSyncPortalPluginSettings GetSettings()
        {
            int storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<SLSyncPortalPluginSettings>(storeScope);
            return settings;
        }
    }
}