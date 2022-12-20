using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.Dashboard
{
    [Table("Attachment", Schema = "Inbox")]
    public class Attachment
    {

        public Attachment()
        {
            this.mailAttachments = new HashSet<MailAttachment>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime? Date { get; set; }

        #region EntityMapping
        public ICollection<MailAttachment> mailAttachments { get; set; }
        #endregion

    }
}
