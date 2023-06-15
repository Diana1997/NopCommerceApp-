using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            
            
            
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Settings/Index.cshtml", list);
        }

        [HttpPost]
        public async Task<IActionResult> Save(dynamic model)
        {
            IDictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in model)
            {
                dic.Add(item.Name, item.Value);
                dic.Add(item.Description, item.DescriptionValue);
            }
            var response = await _httpService.Post<object, IDictionary<string, object>>($"{_settings.Url}/portal/saveSettings", dic, CancellationToken.None);
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