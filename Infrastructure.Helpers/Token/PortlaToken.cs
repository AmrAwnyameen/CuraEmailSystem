using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Infrastructure.Helpers.Token
{
    public class PortlaToken
    {

        [JsonProperty("token")]
        [ScriptIgnore]
        public string token { get; set; }

        [JsonProperty("tokenType")]
        public string tokenType { get; set; }

        [JsonProperty("expireIn")]
        public string expireIn { get; set; }

      
    }

    public class PortalUser
    {

        public string Username { get; set; } 
        public string Password { get; set; }

    }
}
