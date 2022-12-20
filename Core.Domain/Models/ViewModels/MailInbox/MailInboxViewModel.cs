using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.ViewModels
{
    public class MailInboxViewModel
    {
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string FromUserName { get; set; }
        public Guid InboxGuid { get; set; } = Guid.NewGuid();

        public string ToUserName { get; set; }
        public string ToUserId { get; set; }
        public DateTime? Date { get; set; }
        public string Content { get; set; }

        public string Type { get; set; }
        public string Subject { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsRead { get; set; }

        public bool? IsAttached { get; set; }

        public bool? IsStarred { get; set; }

    }
}
