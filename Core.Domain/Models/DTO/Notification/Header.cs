using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.DTO.Notification
{
   public class Header
    {
        public MessageDetails MessageDetails { get; set; } = new MessageDetails();
       
    }
}
