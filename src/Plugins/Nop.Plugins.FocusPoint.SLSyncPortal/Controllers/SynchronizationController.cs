﻿using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class SynchronizationController :  BasePluginController
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Synchronizations/Index.cshtml");
        }
    }
}