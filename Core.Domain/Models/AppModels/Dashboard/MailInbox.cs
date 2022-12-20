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
    [Table("MailInbox", Schema = "Inbox")]
    public class MailInbox
    {
        public MailInbox()
        {
            this.mailAttachments = new HashSet<MailAttachment>();
            this.TrashInboxes = new HashSet<TrashInboxes>();
        }
        [Key]
        public int Id { get; set; }

        #region Attributes

        [Index("IX_FromUser", 1, IsClustered = false)]
        [ForeignKey(nameof(FromUser)), Column(Order = 0)]
        public string FromUserId { get; set; }
        [Index("IX_ToUser", 2, IsClustered = false)]
        [ForeignKey(nameof(ToUser)), Column(Order = 1)]
        public string ToUserId { get; set; }



        [ForeignKey("MailType")]
        public int MailTypeId { get; set; }

        public DateTime? Date { get; set; }

        public string Content { get; set; }
        [MaxLength(100)]
        public string Subject { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsRead { get; set; }
        public bool IsStarred { get; set; }
        #endregion


        #region virtuals
        public virtual ApplicationUser FromUser { get; set; }
        public virtual ApplicationUser ToUser { get; set; }


        public virtual MailType MailType { get; set; }
        public ICollection<MailAttachment> mailAttachments { get; set; }
        public ICollection<TrashInboxes> TrashInboxes { get; set; }
        #endregion

    }
}
