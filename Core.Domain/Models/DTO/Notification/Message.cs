using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.DTO.Notification
{
   public class Message
    {
        [JsonProperty(PropertyName = "@xmlns")]
        public string @xmlns { get; set; } = "urn:gg:eg:envelope:request:v1";

        public HeaderBody Header { get; set; } = new HeaderBody();

        public Data Data { get; set; } = new Data();
    }
}
