using Newtonsoft.Json;

namespace Core.Domain.Models.DTO.Notification
{
    public class Data
    {
        [JsonProperty(PropertyName = "@xmlns")]
        public string @xmlns { get; set; } = "urn:data:request";

        [JsonProperty(PropertyName = "@encrypted")]
        public string @encrypted { get; set; } = "no";

        [JsonProperty(PropertyName = "@gzip")]
        public string @gzip { get; set; } = "no";

        public Query Query { get; set; } = new Query();
    }
}
