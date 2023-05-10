using System.IO;
using System.Net;
using System.Security.Policy;
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
    public class SLSyncPortalController :  BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IHttpService _httpService;

        public SLSyncPortalController(
            ISettingService settingService,
            IStoreContext storeContext,
            IHttpService httpService)
        {
            _settingService = settingService;
            _storeContext = storeContext;
            _httpService = httpService;
        }

   
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var settings = GetSettings();
            string version = string.Empty;
            if(settings == null)
            {
                var response = await _httpService.Get($"{settings.Url}/portal/getVersion", CancellationToken.None);
            }

            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Index.cshtml");
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
           var url = GetSettings().Url;

            var request = WebRequest.Create(url);
            request.Method = "GET";
            string data = "init string";
            using(var response = request.GetResponse())
            {
                using(var sr = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(sr))
                    {
                         data = reader.ReadToEnd();
                    }
                               
                }
            }
            
            ViewBag.GetResponse = data;
            ViewBag.Content = data;
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Settings.cshtml");
        }


        private SLSyncPortalPluginSettings GetSettings()
        {
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<SLSyncPortalPluginSettings>(storeScope);
            return settings;
        }
    }
}