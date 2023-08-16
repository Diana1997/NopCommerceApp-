using System.Dynamic;
using Newtonsoft.Json;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Models
{
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }

        [JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Root
    {
        public ExpandoObject ServiceLayerSettings { get; set; }
        public Logging Logging { get; set; }
    }

}