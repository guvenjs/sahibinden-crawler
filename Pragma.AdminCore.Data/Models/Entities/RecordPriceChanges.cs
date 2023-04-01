using System.ComponentModel.DataAnnotations.Schema;

namespace Pragma.AdminCore.Data.Models.Entities
{
    [Table("RecordPriceChanges")]
    public class RecordPriceChanges : BaseEntity
    {
        public int Price { get; set; }
        public int RecordId { get; set; }

        [ForeignKey("RecordId")]
        public virtual Record Record { get; set; }
    }
}
