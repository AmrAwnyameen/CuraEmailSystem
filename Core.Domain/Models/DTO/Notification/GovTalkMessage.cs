using Newtonsoft.Json;

namespace Core.Domain.Models.DTO.Notification
{
    public class GovTalkMessage
    {
        [JsonProperty(PropertyName = "@xmlns")]
        public string @xmlns { get; set; } = "http://www.govtalk.gov.uk/CM/envelope";

        public string EnvelopeVersion { get; set; } = "2.0";

        public Header Header { get; set; } = new Header();

        public Body Body { get; set; } = new Body();

    }

    public class GovTalkMessageNotification
    {
        public GovTalkMessage GovTalkMessage { get; set; } = new GovTalkMessage();

      

    }
}
