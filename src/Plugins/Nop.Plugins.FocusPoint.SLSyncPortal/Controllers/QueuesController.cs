using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugins.FocusPoint.SLSyncPortal.Models;
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
    [Route("Admin/SLSyncPortal/[controller]/[action]")]
    public class QueuesController : BasePluginController
    {
        private readonly IHttpService _httpService;
        private readonly  SLSyncPortalPluginSettings _settings;

        public QueuesController(
            ISettingService settingService,
            IStoreContext storeContext, 
            IHttpService httpService)
        {
            _httpService = httpService;
            _settings = settingService.LoadSetting<SLSyncPortalPluginSettings>(storeContext.ActiveStoreScopeConfiguration);
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 1, [FromQuery] QueuesFilterModel filter = null)
        {
            var model = new QueuesModel();
            var allItems = new List<QueuesItem>()
            {
                new QueuesItem
                {
                    Date = "null",
                    Type = "aaa",
                    Key = "aaaa",
                    Value = "sdfdf",
                    RetryCount = 1
                },
                new QueuesItem
                {
                    Date = "null",
                    Type = "aaa",
                    Key = "aaaa",
                    Value = "sdfdf",
                    RetryCount = 2
                },
                new QueuesItem
                {
                    Date = "null",
                    Type = "aaa",
                    Key = "aaaa",
                    Value = "sdfdf",
                    RetryCount = 3
                }
            };

           /* var filteredItems = allItems;
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Type))
                {
                    filteredItems = filteredItems.Where(i => i.Type == filter.Type).ToList();
                }

                if (!string.IsNullOrEmpty(filter.Key))
                {
                    filteredItems = filteredItems.Where(i => i.Key == filter.Key).ToList();
                }
            }*/


           var result = await _httpService.Get<IList<QueuesItem>>($"{_settings.Url}//portal/queue?page-number={page}&page-size={pageSize}",
               CancellationToken.None);

           var totalCountResponse = await _httpService.Get<QueueCountResponse>($"{_settings.Url}//portal/queue/count", CancellationToken.None);
           
            model.Items = result;//allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            model.CurrentPage = page;
            model.PageSize = pageSize;
            model.TotalPages = (int)Math.Ceiling((decimal) totalCountResponse.Count / pageSize);

            //portal/queue/count 
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Queues/Index.cshtml", model);
        }
        
        [HttpGet]
        public async Task<IActionResult> ClearQueue()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/clearQueue", CancellationToken.None);
            return Json(new { success = true, message = "Queue cleared" });
        }
    }
}