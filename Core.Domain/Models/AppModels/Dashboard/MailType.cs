using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.Dashboard
{
    [Table("MailType", Schema = "Inbox")]
    public class MailType
    {
        public MailType()
        {
            this.mailInboxes = new HashSet<MailInbox>();
        }

        #region Attributes
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        #endregion

        #region EntityMapping
        public ICollection<MailInbox> mailInboxes { get; set; }
        #endregion

    }
}
