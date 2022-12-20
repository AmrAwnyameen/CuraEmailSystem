using Core.Domain.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.Dashboard
{
    [Table("TrashInboxes", Schema = "Inbox")]
    public class TrashInboxes
    {

        #region Attributes
        [Key]
        public int Id { get; set; }

        [Index("IX_TashUser", 3, IsClustered = false)]
        [ForeignKey("User")]
        public string DeleteBy { get; set; }

        [ForeignKey("MailInbox")]
        public int InboxId { get; set; }

        public DateTime Date { get; set; }

        #endregion

        #region virtuals
        public virtual ApplicationUser User { get; set; }
        public virtual MailInbox MailInbox { get; set; }
        #endregion

    }
}
