using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.Dashboard
{
    [Table("MailAttachment", Schema = "Inbox")]
    public class MailAttachment
    {

        #region Attributes
        [Key]
        public int Id { get; set; }

        [ForeignKey("Attachment")]
        public int AttachmentId { get; set; }

        [ForeignKey("MailInbox")]
        public int InboxId { get; set; }

        #endregion

        #region virtuals
        public virtual Attachment Attachment { get; set; }
        public virtual MailInbox MailInbox { get; set; }
        #endregion

    }
}
