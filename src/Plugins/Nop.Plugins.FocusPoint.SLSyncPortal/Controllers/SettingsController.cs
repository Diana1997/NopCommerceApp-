using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
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

        public SettingsController(
            ISettingService settingService,
            IStoreContext storeContext)
        {
            _settings = settingService.LoadSetting<SLSyncPortalPluginSettings>(storeContext.ActiveStoreScopeConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Settings/Index.cshtml");
        }
    }
}