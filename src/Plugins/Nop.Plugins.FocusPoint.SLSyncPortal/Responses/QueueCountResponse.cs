using Newtonsoft.Json;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Responses
{
    public class QueueCountResponse
    {
        [JsonProperty("count")]
        public int Count { set; get; }
    }
}