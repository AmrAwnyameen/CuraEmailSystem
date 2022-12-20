using Core.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.ViewModels.DashBoard
{
    public class InboxCardViewModel
    {

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Content { get; set; }
        public bool? IsDeleted { get; set; }
        public ApplicationUser user { get; set; }

    }
}
