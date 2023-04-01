using System.ComponentModel.DataAnnotations.Schema;

namespace Pragma.AdminCore.Data.Models.Entities
{
    [Table("Filter")]
    public class Filter : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
