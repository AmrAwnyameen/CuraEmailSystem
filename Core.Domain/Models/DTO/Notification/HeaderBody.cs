using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.DTO.Notification
{
   public class HeaderBody
    {

        public string correlationId { get; set; } = "1";
        public string originatingChannel { get; set; } = "1";
        public string channelRequestId { get; set; } = "1";
        public string originatingUserType { get; set; } = "1";
        public string originatingUserIdentifier { get; set; } = "1";
        public string serviceEntityId { get; set; } = "1";
        
    }
}
