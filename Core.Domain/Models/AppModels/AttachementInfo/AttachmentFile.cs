using Infrastructure.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.AttachementInfo
{
    [Table("AttachmentFile", Schema = "DIG")]
    public class AttachmentFile
    {
        public AttachmentFile()
        {
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string AttachmentCode { get; set; }
        [Required]
        public string AttachmentName { get; set; }

        [NotMapped]
        [Required]
        public string Attachment { get; set; }

        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;

    }
}
