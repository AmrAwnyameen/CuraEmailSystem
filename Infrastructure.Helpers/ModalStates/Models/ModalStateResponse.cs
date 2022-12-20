using Newtonsoft.Json;

namespace Infrastructure.Helpers.ModalStates.Models
{
    public class ModalStateResponse
    {
        [JsonIgnore]
        public string Key { get; set; }
        public string ResponseMessage { get; set; }
        public int ResponseCode { get; set; }
    }
}
