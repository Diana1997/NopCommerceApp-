using System.Collections;
using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Models
{
    public class QueuesModel : BaseNopModel
    {
        public QueuesFilterModel Filter { set; get; }
        public IList<QueuesItem>  Items { set; get; }
        public int CurrentPage { set; get; }
        public int PageSize  { set; get; }
        public int TotalPages   { set; get; }
        
    }
}