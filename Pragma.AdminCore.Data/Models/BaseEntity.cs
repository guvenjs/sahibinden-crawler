using Pragma.AdminCore.Data.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pragma.AdminCore.Data.Models
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid RowId { get; set; } = Guid.NewGuid();

        public bool IsDeleted { get; set; } = false;

        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public string UserCreated { get; set; }
        public string UserUpdated { get; set; }
        public string UserDeleted { get; set; }

        [ForeignKey("UserCreated")]
        public virtual ApplicationUser CreatedUser { get; set; }

        [ForeignKey("UserUpdated")]
        public virtual ApplicationUser UpdatedUser { get; set; }

        [ForeignKey("UserDeleted")]
        public virtual ApplicationUser DeletedUser { get; set; }

    }
}
