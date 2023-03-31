using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [Required]
        public string Url { set; get; }
    }
}