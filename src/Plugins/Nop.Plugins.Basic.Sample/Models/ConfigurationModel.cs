using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;

namespace Nop.Plugins.Basic.Sample.Models
{
    public class ConfigurationModel 
    {
        [Required]
        public string Url { set; get; }
    }
}