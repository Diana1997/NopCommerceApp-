using Newtonsoft.Json;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Responses
{
    public class CommonResponse
    {
        [JsonProperty("status")]
        public string Status { set; get; }
        [JsonProperty("message")]
        public string Message { set; get; }
    }
}