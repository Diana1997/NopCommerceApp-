using System.Collections.Generic;
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
        public IActionResult Index()
        {
            var model = new QueuesModel();
            model.Items = new List<QueuesItem>()
            {
                new QueuesItem
                {
                    Date = "null",
                    Type = "aaa",
                    Key = "aaaa",
                    Value = "sdfdf",
                    RetryCount = 0
                }
            };
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Queues/Index.cshtml", model);
        }
    }
}