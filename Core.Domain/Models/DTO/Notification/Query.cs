using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Core.Domain.Models.DTO.Notification
{
    public class Query
    {
        public string serviceSlug { get; set; }
        public string requestId { get; set; }
        public string status { get; set; }

        public string message { get; set; }
        [JsonIgnore]
        public details AttchmentsDetials { get; set; } = new details();

        public string details { get; set; }

    }
}
