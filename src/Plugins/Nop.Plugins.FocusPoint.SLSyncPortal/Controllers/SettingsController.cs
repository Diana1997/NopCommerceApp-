using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
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
    [Route("Admin/SLSyncPortal/[controller]/[action]")]
    public class SettingsController : BasePluginController
    {
        private readonly  SLSyncPortalPluginSettings _settings;
        private readonly IHttpService _httpService;
        private readonly IMemoryCache _cache;

        public SettingsController(
            ISettingService settingService,
            IStoreContext storeContext, 
            IHttpService httpService, 
            IMemoryCache cache)
        {
            _httpService = httpService;
            _cache = cache;
            _settings = settingService.LoadSetting<SLSyncPortalPluginSettings>(storeContext.ActiveStoreScopeConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            var response = await _httpService.Get<Root>($"{_settings.Url}/portal/settings", CancellationToken.None);

            var model = response.ServiceLayerSettings;


            IList<FormField> list = new List<FormField>();
            foreach (var item in model)
            {
                if (!item.Key.StartsWith("_"))
                {
                    var field = new FormField()
                    {
                        Name = item.Key,
                        Value = item.Value,
                        Description = model.FirstOrDefault(x => x.Key.StartsWith($"_{item.Key}")).Key as string,
                        DescriptionValue = model.FirstOrDefault(x => x.Key.StartsWith($"_{item.Key}")).Value as string,
                        FieldType  = model.FirstOrDefault(x => x.Key.StartsWith($"__{item.Key}")).Value as string,
                    };
                    list.Add(field);
                }
            }

            var settings = JsonConvert.SerializeObject(list);
            _cache.Set("settings", settings);
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Settings/Index.cshtml", list);
        }

        [HttpPost]
        public async Task<IActionResult> Save(IFormCollection model)
        {
            
            var oldSettingsStr = _cache.Get("settings") as string;
            var oldSettings = JsonConvert.DeserializeObject<IList<FormField>>(oldSettingsStr);
            
            IDictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in model)
            {
                var setting = oldSettings.FirstOrDefault(x => x.Name == item.Key);
                if (setting != null)
                {
                    if (setting.FieldType == FieldTypes.Int)
                    {
                        dic.Add(item.Key, Convert.ToInt32(item.Value[0]));
                    }
                    else
                    {
                        dic.Add(item.Key, item.Value[0]);
                    }
                    dic.Add($"_{item.Key}", setting.DescriptionValue);
                    dic.Add($"__{item.Key}", setting.FieldType);
                }
            }


            var settings = new Dictionary<string, object>();
            settings.Add("ServiceLayerSettings", dic);
            var response = await _httpService.Post<object, IDictionary<string, object>>($"{_settings.Url}/portal/saveSettings", settings, CancellationToken.None);
            return RedirectToAction("Index");
        }
    }
}

public class FormField
{
    public string Name { set; get; }
    public object Value { set; get; }
    public string Description { set; get; }
    public string DescriptionValue { set; get; }
    public string FieldType { set; get; }
}

public class FieldTypes
{
    public const string Int = "int";
    public const string String = "string";
    public const string Boolean = "bool";
}