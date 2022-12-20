using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.DTO.Response
{
   public class AppViewModel
    {
        public string Data { get; set; }
        public bool Success { get; set; }
    }

    public class StarredViewModel
    {
        public string Data { get; set; }
        public bool Success { get; set; }
        public string ModelCount { get; set; }
    }
}
