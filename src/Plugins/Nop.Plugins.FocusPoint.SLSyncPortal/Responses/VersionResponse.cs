using Newtonsoft.Json;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Responses
{
    public class VersionResponse
    {
        [JsonProperty("value")]
        public string Value { set; get; }
    
        [JsonProperty("buildDateTime")]
        public string BuildDateTime { set; get; }
    }
}