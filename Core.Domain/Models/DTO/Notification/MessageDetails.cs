namespace Core.Domain.Models.DTO.Notification
{
    public class MessageDetails
    {
        public string Class { get; set; } = "G2G_Portal_ChangeRqstStatus";
        public string Qualifier { get; set; } = "request";
        public string Function { get; set; } = "submit";
    }
}
