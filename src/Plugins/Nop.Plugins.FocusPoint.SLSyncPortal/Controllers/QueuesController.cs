using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugins.FocusPoint.SLSyncPortal.Models;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class QueuesController : BasePluginController
    {
        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 1, [FromQuery] QueuesFilterModel filter = null)
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

            model.Items = allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            model.CurrentPage = page;
            model.PageSize = pageSize;
            model.TotalPages = (int)Math.Ceiling((decimal)allItems.Count / pageSize);

            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Queues/Index.cshtml", model);
        }
    }
}